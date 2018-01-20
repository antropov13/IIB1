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
        private double preis;
        private double loeschmittelkapazitaet;
        List<Loeschvermoegen> loeschvermoegenList = new List<Loeschvermoegen>();
        Loeschvermoegen loeschvermoegen;


        public double Preis { get { return preis; } set { preis = value; } }
        public double Loeschmittelkapazitaet { get { return loeschmittelkapazitaet; } set { loeschmittelkapazitaet = value; } }
        public List<Loeschvermoegen> LoeschvermoegenList { get { return loeschvermoegenList; } set { } }
        public Loeschvermoegen Loeschvermoegen { get { return loeschvermoegen; } set { loeschvermoegen = value; } }


        //Standard Konstruktor
        public Feuerloescher()
        {
            preis = 0;
            loeschmittelkapazitaet = 0;
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "5A/21B", countLoeschmitteleinheiten = 1 });
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "8A/34B", countLoeschmitteleinheiten = 2 });
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "55B", countLoeschmitteleinheiten = 3 });
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "13A/70B", countLoeschmitteleinheiten = 4 });
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "89B", countLoeschmitteleinheiten = 5 });
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "21A/113B", countLoeschmitteleinheiten = 6 });
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "27A/144B", countLoeschmitteleinheiten = 9 });
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "34A", countLoeschmitteleinheiten = 10 });
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "43A/183B", countLoeschmitteleinheiten = 12 });
            loeschvermoegenList.Add(new Loeschvermoegen() { nameLoeschvermoegen = "55A/233B", countLoeschmitteleinheiten = 15 });
        }

        //Allgemeiner Konstruktor2
        public Feuerloescher(double _preis, double _loeschmittelkapazitaet)
        {
            this.preis = _preis;
            this.loeschmittelkapazitaet = _loeschmittelkapazitaet;
        }

        public Feuerloescher(Loeschvermoegen _loeschvermoegen)
        {
            this.loeschvermoegen = _loeschvermoegen;
        }
    }
}
