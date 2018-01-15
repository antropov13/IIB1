using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_Demonstrator.Klassen
{
    /// <summary>
    /// Subklasse der Raum-Klasse. Um den gesetzten Startwert von 0,1 für den Grenzwert zu realisieren, wird die Variable grenzwertRatio überschrieben (Hiding).
    /// </summary>
    [Serializable]
    public class Buero : Raum
    {

        public Buero() : base() { grenzwertRatio = 0.1; }
        public Buero(Raum r) : base(r) { grenzwertRatio = 0.1; }
        public Buero(double flaeche, String nummer, BindingList<Fenster> fenster) : base(flaeche,nummer,fenster) { grenzwertRatio = 0.1; }
        
    }
}
