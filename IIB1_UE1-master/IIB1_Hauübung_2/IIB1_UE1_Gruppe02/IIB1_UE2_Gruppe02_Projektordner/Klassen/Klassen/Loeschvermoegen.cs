using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    [Serializable]
    public class Loeschvermoegen
    {
        public string nameLoeschvermoegen { get; set; }
        public int countLoeschmitteleinheiten { get; set; }

        public override string ToString()
        {
            return nameLoeschvermoegen;
        }

    }
}
