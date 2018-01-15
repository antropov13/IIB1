using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_Demonstrator.Klassen
{
    /// <summary>
    /// Superklasse für alle Raumarten
    /// </summary>
    [Serializable]
    public class Raum
    {
        #region Attribute und Properties
        //Attribute der Klasse
        protected double flaeche;
        protected String raumNummer;
        protected double grenzwertRatio=0;
        protected BindingList<Fenster> fensterListe;

        //Properties der Klasse, beachte: nicht jeder Setter hat tatsächlich eine Funktion
        public double Flaeche { get { return flaeche; } set { } }
        public double GrenzwertRatio { get { return grenzwertRatio; } set { grenzwertRatio = value; } }
        public BindingList<Fenster> FensterListe { get { return fensterListe; } set { } }
        public string RaumNummer { get { return "Raum "+raumNummer; } set { raumNummer = value.Split(' ')[value.Split(' ').Length-1]; } }
        #endregion

        #region Konstruktoren
        /// <summary>
        /// Standard Konstruktor
        /// </summary>
        public Raum()
        {
            flaeche = 0;
            raumNummer = "";
            fensterListe = new BindingList<Fenster>();
        }
        /// <summary>
        /// Allgemeiner Konstruktor 1
        /// </summary>
        /// <param name="_raum">Der Raum, der neu instanziiert werden soll (z.B. um die Subklasse zu ändern)</param>
        public Raum(Raum _raum)
        {
            this.flaeche = _raum.Flaeche;
            this.raumNummer = _raum.RaumNummer.Split(' ')[_raum.RaumNummer.Split(' ').Length-1];
            this.fensterListe = _raum.FensterListe;
        }

        /// <summary>
        /// Allgemeiner Konstruktor 2
        /// </summary>
        /// <param name="flaeche">Raumfläche</param>
        /// <param name="raumNummer">Raumbezeichnung (z.B. "Raum 224")</param>
        /// <param name="fensterListe">Liste aller dem Raum zugehöriger Fenster</param>
        public Raum (double flaeche, String raumNummer, BindingList<Fenster> fensterListe)
        {
            this.flaeche = flaeche;
            this.fensterListe = fensterListe;
            this.raumNummer = raumNummer;
        }
        #endregion
        
        #region Methoden
        /// <summary>
        /// Berechnet das Verhältnis zwischen Fenster- und Raumfläche. Ruft hierzu die Funktion fensterflaeche() auf
        /// </summary>
        /// <returns>Verhältnis der Fenster- zur Raumfläche</returns>
        public double berechneRatio()
        {
            if (flaeche != 0)
                return fensterFlaeche() / flaeche;
            else return 0;
        }

        /// <summary>
        /// Prüft, ob der Grenzwert unterschritten ist
        /// </summary>
        /// <returns>true, wenn der Grenzwert unterschritten wurde</returns>
        public bool grenzwertUnterschritten()
        {
            if (berechneRatio() < GrenzwertRatio)
            {
                return true;
            }
            else return false;
        }

        public void entferneFenster(Fenster f)
        {
            fensterListe.Remove(f);
        }

        public void FensterHinzu(Fenster f)
        {
            fensterListe.Add(f);
        }

        /// <summary>
        /// Ermittelt die Gesamtfensterfläche des Raumes
        /// </summary>
        /// <returns>Summe aller Fensterflächen des Raumes</returns>
        public double fensterFlaeche()
        {
            double gesamtFensterflaeche = 0;
            //Iteration über alle Fenster in der Liste
            if (fensterListe != null)
            {
                foreach (Fenster fenster in fensterListe)
                {
                    //+= addiert Werte auf; Kurz für a = a + b
                    gesamtFensterflaeche += fenster.Flaeche;
                }
            }
            return gesamtFensterflaeche;
        }
        #endregion
    }
}
