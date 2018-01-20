using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    [Serializable]
    public class Material
    {
        private String bezeichnung;
        private String brandschutzklasse;
        private double brandbareMasse;
        private double dichte;
        private double gesamtdicke;
        private double flaeche;


        public String Bezeichnung { get { return bezeichnung; } set { bezeichnung = value; } }
        public String Brandschutzklasse { get { return brandschutzklasse; } set { brandschutzklasse = value; } }
        public double Dichte { get { return dichte; } set { dichte = value; } }
        public double Gesamtdicke { get { return gesamtdicke; } set { gesamtdicke = value; } }
        public double Flaeche { get { return flaeche; } set { flaeche = value; } }
        public double BrandbareMasse { get { return brandbareMasse; } set { brandbareMasse = value; } }


        //Standardkonstruktor
        public Material()
        {
            bezeichnung = "";
            brandschutzklasse = "";
            brandbareMasse = 0;
            dichte = 0;
            gesamtdicke = 0;
            flaeche = 0;
        }


        //Allgemeiner Konstruktor
        public Material(string _bezeichnung, string _brandschutzklasse, double _dichte, double _gesamptdicke, double _flaeche)
        {
            this.Bezeichnung = _bezeichnung;
            this.Brandschutzklasse = _brandschutzklasse;
            this.dichte = _dichte;
            this.gesamtdicke = _gesamptdicke;
            this.flaeche = _flaeche;
            brandbareMasseRechnung();
        }



        private void brandbareMasseRechnung()
        {
            this.brandbareMasse = this.dichte * this.gesamtdicke * this.flaeche; 
        }

    }

  
}
