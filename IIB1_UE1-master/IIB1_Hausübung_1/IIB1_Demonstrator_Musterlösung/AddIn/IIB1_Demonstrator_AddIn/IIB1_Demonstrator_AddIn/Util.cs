using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using IIB1_Demonstrator.Klassen;
using IIB1_Demonstrator_GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_Demonstrator_AddIn
{
    public class Util
    {
        #region Attribute
        private static Document doc = null;
        private static IList<Element> alleFenster = new List<Element>();

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
            List<FamilyInstance> revitFensterListe = findeAlleRaumFenster(room);
            BindingList<Fenster> fensterListe = parseFenster(revitFensterListe);
            double flaeche = squarefeetToQuadratmeter(room.Area);
            string raumtyp = room.GetParameters("Nutzungsgruppe DIN 277-2")[0].AsString();
            if (raumtyp == "2-Büroarbeit")
            {
                Buero buero = new Buero(flaeche, room.Number, fensterListe);
                return buero;
            }
            else if (raumtyp == "1-Wohnen und Aufenthalt")
            {
                Wohnen flur = new Wohnen(flaeche, room.Number, fensterListe);
                return flur;
            }
            return null;

        }

        /// <summary>
        /// Parst eine Revit-Fensterliste in ein Fenster-Fensterliste.
        /// </summary>
        /// <param name="revitFensterListe">liste von Fenster, die geparst werden soll.</param>
        /// <returns>Eine Liste der Fenster eines Raumes</returns>
        private static BindingList<Fenster> parseFenster(List<FamilyInstance> revitFensterListe)
        {
            if (revitFensterListe != null)
            {
                BindingList<Fenster> fensterListe = new BindingList<Fenster>();
                foreach (FamilyInstance fi in revitFensterListe)
                {
                    double fensterFlaeche = groessteFensterflaeche(fi);
                    Fenster fenster = new Fenster(Util.squarefeetToQuadratmeter(
              fensterFlaeche), fi.Name, fi.Symbol.ToString());
                    fensterListe.Add(fenster);
                }
                return fensterListe;
            }
            return null;
        }

        private static double groessteFensterflaeche(FamilyInstance fenster)
        {
            double re = 0;
            Autodesk.Revit.DB.Options opt = new Options();
            GeometryElement geomFenster = fenster.Symbol.get_Geometry(opt);
            foreach(GeometryObject geomObj in geomFenster)
            {
                Solid geomSolid = geomObj as Solid;
                if (geomSolid != null)
                {
                    foreach(Face geomFace in geomSolid.Faces)
                    {
                        if (geomFace.Area > re)
                            re = geomFace.Area;
                    }
                }
            }
            return re;
        }

        public static void holeAlleFenster()
        {
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Windows);
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            alleFenster = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();
        }

        /// <summary>
        /// Holt alle Fenster, die in den Waenden des ausgesuchten Zimmers sind. siehe https://boostyourbim.wordpress.com/2012/12/04/the-elements-that-bound-a-room/
        ///                                                                        und http://thebuildingcoder.typepad.com/blog/2013/07/football-and-space-adjacency-for-heat-load-calculation.html#3
        /// </summary>
        /// <param name="room">Raum, der untersucht werden soll.</param>
        /// <returns>Den Raum als Instanz der Klasse Raum</returns>
        private static List<FamilyInstance> findeAlleRaumFenster(Room room)
        {
            List<FamilyInstance> alleRaumFenster = new List<FamilyInstance>();
            foreach (Element e in alleFenster)
            {
                FamilyInstance fi = (FamilyInstance)e;
                if ((fi.ToRoom != null && fi.ToRoom.Number.Equals(room.Number)) || (fi.FromRoom != null && fi.FromRoom.Number.Equals(room.Number)))
                    alleRaumFenster.Add(fi);
            }
            return alleRaumFenster;
        }

        public static double squarefeetToQuadratmeter(double squarefeet)
        {
            double quadratmeter = (squarefeet / 10.7639);
            return Math.Round(quadratmeter, 2);
        }
        #endregion
    }
}
