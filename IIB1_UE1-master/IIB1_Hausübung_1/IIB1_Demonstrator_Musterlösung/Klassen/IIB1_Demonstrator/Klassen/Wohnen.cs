using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_Demonstrator.Klassen
{
    /// <summary>
    /// Subklasse der Raum-Klasse. Um den gesetzten Startwert von 0,125 für den Grenzwert zu realisieren, werden die Konstruktoren neu geschrieben.
    /// </summary>
    [Serializable]
    public class Wohnen : Raum
    {
        #region Konstruktoren
        /// <summary>
        /// Allgemeiner Konstruktor 1, Ruft den allgemeinen Konstruktor 2 der Basisklasse auf.
        /// </summary>
        /// <param name="flaeche">Raumfläche</param>
        /// <param name="raumNummer">Raumbezeichnung (z.B. "Raum 224")</param>
        /// <param name="fensterListe">Liste aller dem Raum zugehöriger Fenster</param>
        public Wohnen(double flaeche, String raumNummer, BindingList<Fenster> fensterListe) : base(flaeche, raumNummer, fensterListe)
        {
            this.grenzwertRatio = 0.125;
        }

        /// <summary>
        /// Allgemeiner Konstruktor 2, ruft den allgemeinen Konstruktor 1 der Basisklasse auf.
        /// </summary>
        /// <param name="raum">Der Raum, der neu instanziiert werden soll (z.B. um die Subklasse zu ändern)</param>
        public Wohnen (Raum raum) : base(raum)
        {
            this.grenzwertRatio = 0.125;
        }
        #endregion
    }
}
