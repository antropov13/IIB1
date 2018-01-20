using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    [Serializable]
    public class Feuerloescher
    {
        private String bezeichnung;
        private int loescheinheit;
        private double preis;
        private int anzahl;

        public String Bezeichnung { get { return bezeichnung; } set { bezeichnung = value; } }
        public int Loescheinheit { get { return loescheinheit; } set { loescheinheit = value; } }
        public double Preis { get { return preis; } set { preis = value; } }
        public int Anzahl { get { return anzahl; } set { anzahl = value; } }


        //Standard Konstruktor
        public Feuerloescher()
        {
            bezeichnung = "";
            loescheinheit = 0;
            preis = 0;
            anzahl = 0;
        }

        //Allgemeiner Konstruktor2
        public Feuerloescher(String _bezeichnung, int _loescheinheit, double _preis)
        {
            this.bezeichnung = _bezeichnung;
            this.loescheinheit = _loescheinheit;
            this.preis = _preis;
        }

    }
}
