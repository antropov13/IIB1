using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    [Serializable]
    public class Buero : Raum
    {
        public String typRaum = "Büro";
        public double heizwert = 20.5;

        public Buero() : base() { TypRaume = typRaum; Heizwert = heizwert; }
        public Buero(Raum raum) : base(raum) { TypRaume = typRaum; Heizwert = heizwert; }
        public Buero(double flaeche, String bezeichnung, BindingList<Feuerloescher> feuerloescher, Material materialien) : base(flaeche, bezeichnung, feuerloescher, materialien) { TypRaume = typRaum; Heizwert = heizwert; }
    }
}
