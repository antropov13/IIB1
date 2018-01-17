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
using Autodesk.Revit.DB.Structure;

namespace AddIn
{
    class Util
    {
        #region Attribute
        private static Document doc = null;
        private static IList<Element> alleFeuerloescher = new List<Element>();
        public static readonly string nutzungsart = "Nutzungsgruppe DIN 277-2";
        //private static IList<Element> alleBoeden = new List<Element>();

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
        /// 
        //private static 


        public static Raum parseRaum(Room room)
        {
            List<FamilyInstance> revitFeuerloescherListe = findeAlleRaumFeuerloescher(room);
            BindingList<Feuerloescher> feuerloescherListe = parseFeuerloescher(revitFeuerloescherListe);
            //BindingList<Feuerloescher> feuerloescherListe = new BindingList<Feuerloescher>();
            Klassen.Material material = new Klassen.Material();
            double flaeche = squarefeetToQuadratmeter(room.Area);
            //string raumtyp = room.GetParameters("Raumschlüssel")[0].AsValueString();
            string raumtyp = room.GetParameters(nutzungsart)[0].AsString();
            if (raumtyp == "2-Büroarbeit")
            {
                Buero buero = new Buero(flaeche, room.Number, feuerloescherListe, material, room.UniqueId);
                return buero;
            }
            else if (raumtyp == "3-Produktion/Hand-Maschinenarbeit/Experimente")
            {
                Seminarraum seminarraum = new Seminarraum(flaeche, room.Number, feuerloescherListe, material, room.UniqueId);
                return seminarraum;
            }
            else if (raumtyp == "7-Sonstige Nutzflächen")
            {
                Sanitaerraum sanitaerraum = new Sanitaerraum(flaeche, room.Number, feuerloescherListe, material, room.UniqueId);
                return sanitaerraum;
            }
            else if (raumtyp == "1-Wohnen und Aufenthalt")
            {
                Flur flur = new Flur(flaeche, room.Number, feuerloescherListe, material, room.UniqueId);
                return flur;
            }
            return null;
        }

        /// <summary>
        /// Parst eine Revit-Fensterliste in ein Fenster-Fensterliste.
        /// </summary>
        /// <param name="revitFensterListe">liste von Fenster, die geparst werden soll.</param>
        /// <returns>Eine Liste der Fenster eines Raumes</returns>
        private static BindingList<Feuerloescher> parseFeuerloescher(List<FamilyInstance> revitFeuerloescherListe)
        {
            if (revitFeuerloescherListe != null)
            {
                BindingList<Feuerloescher> feuerloescherListe = new BindingList<Feuerloescher>();
                foreach (FamilyInstance fi in revitFeuerloescherListe)
                {
                    //double fensterFlaeche = groessteFensterflaeche(fi); public Feuerloescher(string _bezeichnung, int _loescheinheit, double _preis);
                    //Fenster fenster = new Fenster(Util.squarefeetToQuadratmeter(fensterFlaeche), fi.Name, fi.Symbol.ToString());
                    int le = 0;
                    int pr = 0;
                    Feuerloescher feuerloescher = new Feuerloescher(fi.Name, le, pr);
                    feuerloescherListe.Add(feuerloescher);
                }
                return feuerloescherListe;
            }
            return null;
        }


        public static void holeAlleFeuerloescher()
        {
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_SpecialityEquipment);
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            alleFeuerloescher = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();
        }

        /// <summary>
        /// Holt alle Fenster, die in den Waenden des ausgesuchten Zimmers sind. siehe https://boostyourbim.wordpress.com/2012/12/04/the-elements-that-bound-a-room/
        ///                                                                        und http://thebuildingcoder.typepad.com/blog/2013/07/football-and-space-adjacency-for-heat-load-calculation.html#3
        /// </summary>
        /// <param name="room">Raum, der untersucht werden soll.</param>
        /// <returns>Den Raum als Instanz der Klasse Raum</returns>
        private static List<FamilyInstance> findeAlleRaumFeuerloescher(Room room)
        {
            List<FamilyInstance> alleRaumFeuerloescher = new List<FamilyInstance>();
            foreach (Element e in alleFeuerloescher)
            {
                FamilyInstance fi = (FamilyInstance)e;
                if ((fi.ToRoom != null && fi.ToRoom.Number.Equals(room.Number)) || (fi.FromRoom != null && fi.FromRoom.Number.Equals(room.Number)))
                    alleRaumFeuerloescher.Add(fi);
            }
            return alleRaumFeuerloescher;
        }

        public static double squarefeetToQuadratmeter(double squarefeet)
        {
            double quadratmeter = (squarefeet / 10.7639);
            return Math.Round(quadratmeter, 2);
        }

        public static void updateRaumDaten(BindingList<Raum> raeume)
        {
            aendereBekannteProperties(raeume);
            //aendereNeueProperties(raeume);
        }

        private static void aendereBekannteProperties(BindingList<Raum> raeume)
        {
            try
            {
                bool worked;
                foreach (Raum r in raeume)
                {
                    if (r.RevitId != null)
                    {
                        Room room = (Room)doc.GetElement(r.RevitId);
                        using (Transaction trans = new Transaction(doc))
                        {
                            if (trans.Start("ChangeRoomParameters") == TransactionStatus.Started)
                            {
                                room.Number = r.Bezeichung;
                                if (zugehörigeNutzungsart(r) != "")
                                    worked = room.GetParameters(nutzungsart).First().Set(zugehörigeNutzungsart(r));
                                trans.Commit();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                TaskDialog.Show("Fehler", e.Message);
            }
        }

        private static string zugehörigeNutzungsart(Raum r)
        {

            if (r is Buero)
                return "2-Büroarbeit";
            if (r is Flur)
                return "1-Wohnen und Aufenthalt";
            if (r is Sanitaerraum)
                return "7-Sonstige Nutzflächen";
            if (r is Seminarraum)
                return "3-Produktion/Hand-Maschinenarbeit/Experimente";
            else return "";
        }


        public static void platziereFeuerloescher(BindingList<Raum> raeume)
        {
            foreach (Raum r in raeume)
                // if (r.grenzwertUnterschritten())
                platziereFeuerloescherInRaum(r);
        }

        private static void platziereFeuerloescherInRaum(Raum r)
        {
            Room rr = doc.GetElement(r.RevitId) as Room;
            XYZ locR = ((LocationPoint)rr.Location).Point;
            if (null != locR)
            {
                using (Transaction trans = new Transaction(doc))
                {
                    if (trans.Start("PlaceFamily") == TransactionStatus.Started)
                    {
                        FamilyInstance fi = doc.Create.NewFamilyInstance(locR,
                            GetFamilySymbolByName(BuiltInCategory.OST_LightingFixtures, "5A/21B")
                            , StructuralType.NonStructural);
                        trans.Commit();
                    }
                }
            }
            //5A/21B
        }

        private static FamilySymbol GetFamilySymbolByName(BuiltInCategory bic, string name)
        {
            return new FilteredElementCollector(doc).OfCategory(bic).OfClass(typeof(FamilySymbol))
                .FirstOrDefault<Element>(e => e.Name.Equals(name)) as FamilySymbol;
        }
        #endregion

    }
}
