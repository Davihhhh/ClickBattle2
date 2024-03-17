using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCB
{
    public class Partita
    {
        private string _nome;
        private int _punteggio;
        private DateTime _data;

        public string Nome
        {
            get { return _nome; }
            private set { _nome = value; }
        }
        public int Punteggio
        {
            get { return _punteggio; }
            private set { _punteggio = value; }
        }
        public DateTime Data
        {
            get { return _data; }
            private set { _data = value; }
        }

        public Partita(string nome, int punteggio)
        {
            Nome = nome;
            Punteggio = punteggio;
            _data = DateTime.Now;
        }

    }
}
