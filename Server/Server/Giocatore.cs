using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCB
{
    public class Giocatore
    {
        private string _nome;
        private int _punteggioMassimo, _vittorie;

        public string Nome
        {
            get { return _nome; }
            private set { _nome = value; }
        }
        public int PunteggioMassimo
        {
            get { return _punteggioMassimo; }
            private set { _punteggioMassimo = value; }
        }
        public int Vittorie
        {
            get { return _vittorie; }
            private set { _vittorie = value; }
        }

        public Giocatore(string nome, int punteggioMassimo, int vittorie)
        {
            Nome = nome;
            PunteggioMassimo = punteggioMassimo;
            Vittorie = vittorie;
        }
        public Giocatore()
        {
            Nome = "";
            PunteggioMassimo = -1;
            Vittorie = -1;
        }

        public void AggiungiVittoria(int punteggio)
        {
            Vittorie += 1;
            if (PunteggioMassimo < punteggio)
            {
                PunteggioMassimo = punteggio;
            }
        }

        public void AggiornaPunteggio(int punteggio)
        {
            if(punteggio > PunteggioMassimo)
            {
                PunteggioMassimo = punteggio;
            }
        }
    }
}
