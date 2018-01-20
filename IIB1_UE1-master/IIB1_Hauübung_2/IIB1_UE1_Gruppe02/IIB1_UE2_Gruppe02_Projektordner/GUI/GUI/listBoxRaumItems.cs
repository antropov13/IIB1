using Klassen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class listBoxRaumItems
    {
        //Klass benötigt für die Farbe der Räume
        private Color raumColor;
        private Raum raum;
        public listBoxRaumItems(Color _color, Raum _raum)
        {
            this.raumColor = _color;
            this.raum = _raum;
        }

        public Color RaumColor { get { return raumColor; } set { raumColor = value; } }
        public Raum Raum { get { return raum; } set { raum = value; } }
    }
}
