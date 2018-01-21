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
        public Flur(double flaeche, String bezeichnung, String nummer, BindingList<Feuerloescher> feuerloescher, Material materialien, String revitID) : base(flaeche, bezeichnung, nummer, feuerloescher, materialien, revitID) { TypRaume = typRaum; Heizwert = heizwert; }
    }
}
