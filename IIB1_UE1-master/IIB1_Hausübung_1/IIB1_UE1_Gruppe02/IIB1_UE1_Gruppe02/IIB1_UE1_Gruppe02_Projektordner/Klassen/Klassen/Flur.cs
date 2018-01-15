using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    [Serializable]
    public class Flur : Raum
    {
        public String typRaum = "Flur";
        public double heizwert = 19.2;

        public Flur() : base() { TypRaume = typRaum; Heizwert = heizwert; }
        public Flur(Raum raum) : base(raum) { TypRaume = typRaum; Heizwert = heizwert; }
        public Flur(double flaeche, String bezeichnung, BindingList<Feuerloescher> feuerloescher, Material materialien) : base(flaeche, bezeichnung, feuerloescher, materialien) { TypRaume = typRaum; Heizwert = heizwert; }
    }
}
