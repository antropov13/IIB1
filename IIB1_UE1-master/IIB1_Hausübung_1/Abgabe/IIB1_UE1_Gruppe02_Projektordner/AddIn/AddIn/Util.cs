using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klassen;
using GUI;

namespace AddIn
{
    class Util
    {
        #region Attribute
        private static Document doc = null;
        private static IList<Element> alleBoeden = new List<Element>();

        public static Document Doc
        {
            set
            {
                doc = value;
            }
        }
        #endregion

        #region Methoden
        /// <summary>
        /// Parst einen Revit-Raum in einen Raum-Raum.
        /// </summary>
        /// <param name="room">Raum, der geparst werden soll.</param>
        /// <returns>Den Raum als Instanz der Klasse Raum</returns>

        public static Raum parseRaum(Room room)
        {
            /*List<FamilyInstance> revitFensterListe = findeAlleRaumFenster(room);
            BindingList<Fenster> fensterListe = parseFenster(revitFensterListe);*/
            BindingList<Feuerloescher> feuerloescherListe = new BindingList<Feuerloescher>();
            Klassen.Material material = new Klassen.Material();
            double flaeche = squarefeetToQuadratmeter(room.Area);
            string raumtyp = room.GetParameters("Raumschlüssel")[0].AsValueString();
            if (raumtyp == "2")
            {
                Buero buero = new Buero(flaeche, room.Number, feuerloescherListe, material);
                return buero;
            }
            else if (raumtyp == "5")
            {
                Seminarraum seminarraum = new Seminarraum(flaeche, room.Number, feuerloescherListe, material);
                return seminarraum;
            }
            else if (raumtyp == "7")
            {
                Sanitaerraum sanitaerraum = new Sanitaerraum(flaeche, room.Number, feuerloescherListe, material);
                return sanitaerraum;
            }
            else if (raumtyp == "9")
            {
                Flur flur = new Flur(flaeche, room.Number, feuerloescherListe, material);
                return flur;
            }
            return null;
        }

        public static double squarefeetToQuadratmeter(double squarefeet)
        {
            double quadratmeter = (squarefeet / 10.7639);
            return Math.Round(quadratmeter, 2);
        }
        #endregion

    }
}
