﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Klassen
{
    [Serializable]
    public abstract class Raum
    {
        //Attribute der Klasse
        protected double grundflaeche;
        protected String bezeichung;
        protected String nummer;
        protected int loeschmitteleinheiten;
        protected double brandlast;
        protected Material materialien;
        protected BindingList<Feuerloescher> feuerloescherList;
        protected String typRaum;
        protected double heizwert;
        protected String revitID;

        public string RaumName
        {
            get { return this.GetType().Name + bezeichung; }
        }
        public string RevitId
        {
            get { return revitID; }
        }
        //protected double brandgefahr;

        //Properties der Klasse
        public double Grundflaeche { get { return grundflaeche; } set { grundflaeche = value; } }
        public String BezeichungLB { get { return "№" + nummer + " " + bezeichung; } set { bezeichung = value;  } }
        public String Bezeichung { get { return bezeichung; } set { bezeichung = value; } }
        public String Nummer { get { return nummer; } set { nummer = value; } }
        public int Loeschmitteleinheiten { get { return loeschmitteleinheiten; } set { loeschmitteleinheiten = value; } }
        public double Brandlast { get { return brandlast; } set { brandlast = value; } } 
        public Material Materialien {  get { return materialien; } set { materialien = value; } }
        public BindingList<Feuerloescher > FeuerloescherList { get { return feuerloescherList; } set { feuerloescherList = value; } }
        public String TypRaume { get { return typRaum; } set { typRaum = value; } }
        public double Heizwert { get { return heizwert; } set { heizwert = value; } }

        //Standard Konstruktor
        public Raum()
        {
            grundflaeche = 0;
            //brandgefahr = 0;
            bezeichung = "";
            typRaum = "";
            materialien = new Material();
            feuerloescherList = new BindingList<Feuerloescher>();
            loeschmitteleinheiten = 0;
            heizwert = 0;
            brandlast = 0;
            nummer = "";
        }

        //Allgemeiner Konstruktor1
        public Raum(Raum _raum)
        {
            this.bezeichung = _raum.Bezeichung;
            this.nummer = _raum.nummer;
            this.grundflaeche = _raum.Grundflaeche;
            //this.brandgefahr = _raum.Brandgefahr;
            this.typRaum = _raum.TypRaume;
            this.brandlast = _raum.Brandlast;
            this.feuerloescherList = _raum.FeuerloescherList;
            this.loeschmitteleinheiten = _raum.loeschmitteleinheiten;
            this.materialien = _raum.materialien;
            this.heizwert = _raum.heizwert;
            this.revitID = _raum.revitID;
        }

        //Allgemeiner Konstruktor2
        public Raum(double _grundflaeche, String _bezeichnung, String _nummer, BindingList<Feuerloescher> _feuerloecher, Material _materialien)
        {
            this.bezeichung = _bezeichnung;
            this.nummer = _nummer;
            this.grundflaeche = _grundflaeche;
            this.loeschmitteleinheiten = countLoeschmitteleinheiten(_grundflaeche);
            this.feuerloescherList = _feuerloecher;
            this.materialien = _materialien;

        }

        //Allgemeiner Konstruktor3
        public Raum(double _grundflaeche, String _bezeichnung, String _nummer, BindingList<Feuerloescher> _feuerloecher, Material _materialien, string _revitId)
        {
            this.bezeichung = _bezeichnung;
            this.nummer = _nummer;
            this.grundflaeche = _grundflaeche;
            this.loeschmitteleinheiten = countLoeschmitteleinheiten(_grundflaeche);
            this.feuerloescherList = _feuerloecher;
            this.materialien = _materialien;
            this.revitID = _revitId;

        }

        public void feueloescherHinzu(Feuerloescher f)
        {
            feuerloescherList.Add(f);
        }

        public void feueloescherAnzahlHinzu(Feuerloescher f)
        {
            foreach (Feuerloescher ff in feuerloescherList)
            {
                if (ff.Bezeichnung.Equals(f.Bezeichnung)) {
                    ff.Anzahl ++;
                    break;
                }
            }
        }

        public void entferneFeuerloescher(Feuerloescher f)
        {
            feuerloescherList.Remove(f);
        }

        public int countLoeschmitteleinheiten(double raumflaeche)
        {

            int LE = 6;
            if (raumflaeche <= 50) return LE;
            LE += 3;
            if (raumflaeche > 50 && raumflaeche <= 100) return LE;
            LE += 3;
            for (int k = 200; k <= 1000; k += 100, LE += 3)
            {
                if (raumflaeche <= k) return LE;
            }
            LE += 3;
            for (int k = 1250; ; k += 250, LE += 6)
            {

                if (raumflaeche <= k) return LE;
            }
        }
    }
}
