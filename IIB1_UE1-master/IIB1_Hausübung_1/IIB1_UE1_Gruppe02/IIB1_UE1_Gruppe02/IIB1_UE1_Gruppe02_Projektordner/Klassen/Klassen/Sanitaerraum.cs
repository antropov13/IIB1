using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    [Serializable]
    public class Sanitaerraum : Raum
    {
        public String typRaum = "Sanitärraum";
        public double heizwert = 17.2;

        public Sanitaerraum() : base() { TypRaume = typRaum; Heizwert = heizwert; }
        public Sanitaerraum(Raum raum) : base(raum) { TypRaume = typRaum; Heizwert = heizwert; }
        public Sanitaerraum(double flaeche, String bezeichnung, BindingList<Feuerloescher> feuerloescher, Material materialien) : base(flaeche, bezeichnung, feuerloescher, materialien) { TypRaume = typRaum; Heizwert = heizwert; }
    }
}
