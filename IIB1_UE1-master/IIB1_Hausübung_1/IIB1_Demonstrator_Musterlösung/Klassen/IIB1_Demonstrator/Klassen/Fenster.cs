using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_Demonstrator.Klassen
{
    /// <summary>
    /// Klasse zur Beschreibung von Fenstern
    /// </summary>
    [Serializable]
    public class Fenster
    {
        #region Attribute und Properties
        //Attribute
        private double flaeche;
        private String bezeichung;
        private String typ;

        //Properties
        public double Flaeche { get { return flaeche; } set { flaeche = value; } }
        public string Bezeichung { get { return bezeichung; } set { bezeichung = value; } }
        public string Typ { get { return typ; } set { typ = value; } }
        #endregion

        #region Konstruktoren
        /// <summary>
        /// Standard Konstruktor
        /// </summary>
        public Fenster()
        {
            flaeche = 0;
            bezeichung = "";
        }

        /// <summary>
        /// Allgemeiner Konstruktor
        /// </summary>
        /// <param name="_flaeche">Fensterfläche</param>
        /// <param name="_bezeichnung">Bezeichnung des Fensters</param>
        public Fenster(double _flaeche, String _bezeichnung, String _typ)
        {
            this.flaeche = _flaeche;
            this.bezeichung = _bezeichnung;
            this.typ = _typ;
        }
        #endregion
    }
}
