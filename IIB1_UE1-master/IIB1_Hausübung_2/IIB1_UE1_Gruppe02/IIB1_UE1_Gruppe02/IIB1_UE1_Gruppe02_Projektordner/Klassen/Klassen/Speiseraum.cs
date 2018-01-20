using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{

    [Serializable]
    public class Speiseraum : Wohnung
    {
        public Speiseraum(double flaeche, double brandgefahr, String bezeichnung) : base(flaeche, brandgefahr, bezeichnung) { }

    }
}
