using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    [Serializable]
    public class Seminarraum : Raum
    {
        public String typRaum = "Seminarraum";
        public double heizwert = 18.2;

        public Seminarraum() : base() { TypRaume = typRaum; Heizwert = heizwert; }
        public Seminarraum(Raum raum) : base(raum) { TypRaume = typRaum; Heizwert = heizwert; }
        public Seminarraum(double flaeche, String bezeichnung, BindingList<Feuerloescher> feuerloescher, Material materialien) : base(flaeche, bezeichnung, feuerloescher, materialien) { TypRaume = typRaum; Heizwert = heizwert; }
    }
}
