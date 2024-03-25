using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using System.IO.Ports;

namespace ServerCB
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Server s = new Server();
                //Console.WriteLine("Arrivato");
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }

    public class Server
    {
        // Variabili Server
        private List<Giocatore> giocatori;
        private List<Partita> partite;
        private TcpListener server;
        private TcpClient client;
        private const string fileName = @".\giocatori.xml";
        private const string fileNamePartite = @".\partite.xml";
        private const int portaDefault = 10000;
        private IPAddress ipAddress;

        // Inizializza Server
        public Server()
        {
            Start();
        }

        // Funzioni Server

        // Funzione per caricare in memoria il file dei giocatori
        private void CaricaGiocatori()
        {
            giocatori = new List<Giocatore>();
            // Controlla se il file esiste
            if (File.Exists(fileName))
            {
                XmlDocument lista = new XmlDocument();
                lista.Load(fileName);

                XmlNode giocatorii = lista.SelectSingleNode("giocatori");
                XmlNode nome, punteggio, vittorie;
                Giocatore x;
                foreach (XmlNode giocatore in giocatorii)
                {
                    nome = giocatore.SelectSingleNode("nome");
                    punteggio = giocatore.SelectSingleNode("punteggiomassimo");
                    vittorie = giocatore.SelectSingleNode("vittorie");

                    x = new Giocatore(nome.InnerText, Convert.ToInt32(punteggio.InnerText), Convert.ToInt32(vittorie.InnerText));

                    giocatori.Add(x);
                }
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDeclaration);

                XmlElement root = xmlDoc.CreateElement("giocatori");
                xmlDoc.AppendChild(root);

                xmlDoc.Save(fileName);
            }
        }

        // Gestione connessioni
        private void AttendiClient()
        {
            // Ip macchina locale
            ipAddress = IPAddress.Parse("127.0.0.1");

            // Istanzia un oggetto "ascoltatore" (un Listener, appunto) in grado
            // di accettare connessioni su qualunque interfaccia ip, sulla porta definita dalla variabile porta          
            server = new TcpListener(ipAddress, portaDefault);

            // Avvia il server di ascolto
            server.Start();

            // Ascolto
            while (true)
            {
                try
                {
                    // Accetta la richiesta di connessione di un client e crea un thread dedicato a lui
                    client = server.AcceptTcpClient();

                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.Start(client);
                }
                catch (Exception eccezione)
                {
                    Console.WriteLine(eccezione.ToString());
                }
            }
        }
        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            try
            {
                // Ottiene la porta locale
                IPEndPoint localEndPoint = (IPEndPoint)client.Client.LocalEndPoint;

                int localPort = localEndPoint.Port;

                // Genera una nuova porta per la connessione
                int newPort = GetNextAvailablePort();
                string p = "porta;" + newPort;

                // Associa il nuovo TcpListener alla nuova porta
                TcpListener newListener = new TcpListener(IPAddress.Any, newPort);
                newListener.Start();

                // Notifica al client la nuova porta
                byte[] data = Encoding.UTF8.GetBytes(p);
                client.GetStream().Write(data, 0, data.Length);

                // Accetta una nuova connessione sulla nuova porta
                client = newListener.AcceptTcpClient();

                newListener.Stop();

                // Variabili del client
                NetworkStream stream;
                byte[] buffer = new byte[1024];
                int bytesRead;
                string dataReceived = "";
                string[] msg;
                string nome, comando;
                string response = "";
                byte[] responseData;
                bool logged = false;
                Giocatore giocatore = new Giocatore("tmp", 0, 0);
                Partita partita = new Partita(giocatore.Nome, giocatore.PunteggioMassimo);
                while (true)
                {
                    try
                    {
                        // Leggi i dati inviati dal client
                        stream = client.GetStream();
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                        dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        msg = dataReceived.Split(';');
                        nome = msg[0];
                        comando = msg[1];

                        switch (comando)
                        {
                            case "login":
                                if (Login(nome))
                                {
                                    logged = true;
                                    giocatore = GetGiocatore(nome);
                                    response = $"loggato;{giocatore.PunteggioMassimo};{giocatore.Vittorie}";
                                }
                                else if (SalvaUtente(nome))
                                {
                                    response = $"loggato;0;0";
                                }
                                break;
                            case "punteggio":
                                if (logged)
                                {
                                    partita = new Partita(nome, int.Parse(msg[2]));
                                    SalvaPartita(partita);
                                }
                                break;
                            case "classifica":
                                if (logged)
                                {
                                    response = GetClassifica();
                                }
                                break;
                            case "disconnetto":
                                if (logged)
                                {
                                    logged = false;
                                    giocatore = null;
                                    response = "disconnesso";
                                }
                                break;
                            default:
                                response = "comando invalido";
                                break;
                        }
                        responseData = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseData, 0, responseData.Length);
                        if (response == "disconnetto")
                        {
                            client.Close();
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        client.Close();
                        Thread.CurrentThread.Abort();
                    }
                }
            }
            catch (Exception eccezione)
            {
                Console.WriteLine(eccezione.Message);
                Thread.CurrentThread.Abort();
            }
        }
        private int GetNextAvailablePort()
        {
            // Crea un nuovo TcpListener con porta 0 per ottenere automaticamente una porta disponibile
            TcpListener listener = new TcpListener(IPAddress.Any, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
        private string GetClassifica()
        {
            try
            {
                string classifica = "";
                giocatori = giocatori.OrderByDescending(o => o.PunteggioMassimo).ToList();
                foreach (Giocatore g in giocatori)
                {
                    classifica += g.Nome + ':' + g.PunteggioMassimo + ';';
                }
                classifica = classifica.Remove(classifica.Length - 1);
                return classifica;
            } catch (Exception e) { return e.Message; }           
        }
        private bool Login(string nome)
        {
            foreach (Giocatore g in giocatori)
            {
                if (g.Nome.Equals(nome))
                    return true;
            }
            return false;
        }
        private Giocatore GetGiocatore(string nome)
        {
            foreach (Giocatore g in giocatori)
            {
                if (g.Nome.Equals(nome))
                    return g;
            }
            return null;
        }       

        // Controllo del server
        private void Start()
        {
            CaricaGiocatori();
            AttendiClient();
        }

        // Gestione dei file XML
        private void SalvaPartita(Partita partita)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileNamePartite);

            XmlElement root = xmlDoc.DocumentElement;

            XmlElement nuovaPartita = xmlDoc.CreateElement("partita");

            // Crea il nodo "nome" e assegna il valore ricevuto come parametro
            XmlElement nomeElement = xmlDoc.CreateElement("nome");
            XmlElement punteggioElement = xmlDoc.CreateElement("punteggio");

            nomeElement.InnerText = partita.Nome;
            punteggioElement.InnerText = partita.Punteggio.ToString();

            nuovaPartita.AppendChild(nomeElement);
            nuovaPartita.AppendChild(punteggioElement);

            root.AppendChild(nuovaPartita);

            xmlDoc.Save(fileNamePartite);
            AggiornaUtenti(partita);
        }
        private void AggiornaUtenti(Partita p)
        {
            foreach(Giocatore g in giocatori)
            {
                if(p.Nome.Equals(g.Nome))
                {
                    if(p.Punteggio > g.PunteggioMassimo)
                    {
                        g.AggiornaPunteggio(p.Punteggio);
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(fileName);
                        
                        XmlNodeList partiteList = xmlDoc.GetElementsByTagName("partita");
                        foreach (XmlNode partitaNode in partiteList)
                        {
                            XmlNode nomeNode = partitaNode.SelectSingleNode("nome");
                            if (nomeNode != null && nomeNode.InnerText == p.Nome)
                            {                               
                                XmlNode punteggioNode = partitaNode.SelectSingleNode("punteggio");
                                if (punteggioNode != null)
                                {
                                    punteggioNode.InnerText = p.Punteggio.ToString(); // Aggiorna il punteggio a 150
                                    xmlDoc.Save(fileName);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }
        private bool SalvaUtente(string nome)
        {
            foreach (Giocatore giocatore in giocatori)
            {
                if (giocatore.Nome.Equals(nome))
                    return false;
            }
            Giocatore g = new Giocatore(nome, 0, 0);
            giocatori.Add(g);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlElement root = xmlDoc.DocumentElement;

            XmlElement nuovoGiocatore = xmlDoc.CreateElement("giocatore");

            XmlElement nomeElement = xmlDoc.CreateElement("nome");
            XmlElement punteggioElement = xmlDoc.CreateElement("punteggiomassimo");
            XmlElement vittorieElement = xmlDoc.CreateElement("vittorie");

            nomeElement.InnerText = nome;
            punteggioElement.InnerText = "0";
            vittorieElement.InnerText = "0";

            nuovoGiocatore.AppendChild(nomeElement);
            nuovoGiocatore.AppendChild(punteggioElement);
            nuovoGiocatore.AppendChild(vittorieElement);

            root.AppendChild(nuovoGiocatore);

            xmlDoc.Save(fileName);

            return true;

        }
    }
}

