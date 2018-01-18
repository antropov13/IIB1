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
using System.Text.RegularExpressions;
using System.Diagnostics;

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

                    int leInt = 0;
                    int preisInt = 0;

                    FamilySymbol s = GetFamilySymbolByName(BuiltInCategory.OST_SpecialityEquipment, fi.Name);

                    foreach (Parameter p in s.Parameters)
                    {
                        if (p.Definition.Name.Equals("Kosten"))
                        {
                            string preis = p.AsValueString();
                            preisInt = Convert.ToInt32(Regex.Replace(preis, @"[^\d]+", ""));

                        }

                        else if (p.Definition.Name.Equals("Loescheinheit"))
                        {
                            string LE = p.AsValueString();
                            leInt = Convert.ToInt32(LE);
                        }
                    }

                    Feuerloescher feuerloescher = new Feuerloescher(fi.Name, leInt, preisInt);

                    bool flag = false;
                    foreach (Feuerloescher f in feuerloescherListe)
                    {
                        if (f.Bezeichnung.Equals(feuerloescher.Bezeichnung))
                        {
                            f.Anzahl += 1;
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        feuerloescher.Anzahl = 1;
                        feuerloescherListe.Add(feuerloescher);
                    }

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

            listFeuerloescherSuebern();
        }

        public static void listFeuerloescherSuebern()
        {
            IList<Element> alleFeuerloescherBuffer = new List<Element>();
            //int count = alleFeuerloescher.Count;
            //TaskDialog.Show("Count:", count.ToString());
            foreach (Element e in alleFeuerloescher)
            {
                FamilyInstance fi = (FamilyInstance)e;
                FamilySymbol s = GetFamilySymbolByName(BuiltInCategory.OST_SpecialityEquipment, fi.Name);

                foreach (Parameter p in s.Parameters)
                {
                    if (p.Definition.Name.Equals("Beschreibung"))
                    {
                        string beschreibung = p.AsString();
                        if (beschreibung == "Feuerloescher")
                        {
                            alleFeuerloescherBuffer.Add(e);
                        }
                    }
                }
            }
            alleFeuerloescher.Clear();
            alleFeuerloescher = alleFeuerloescherBuffer;
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
                FamilySymbol s = GetFamilySymbolByName(BuiltInCategory.OST_SpecialityEquipment, fi.Name);

                if (fi.Room != null && fi.Room.Number.Equals(room.Number))
                {

                    alleRaumFeuerloescher.Add(fi);
                }
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
            aendereNeueProperties(raeume);
        }

        private static void aendereNeueProperties(BindingList<Raum> raeume)
        {
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
            Feuerloescher f = new Feuerloescher("5A/21B", 1, 20);
            f.Anzahl = 1;
            foreach (Raum r in raeume)
            {
                //r.feueloescherHinzu(f);
                platziereFeuerloescherInRaum(r);
            }
        }


        private static void platziereFeuerloescherInRaum(Raum r)
        {
            //TaskDialog.Show("ID, Name", r.Bezeichung);
            Room rr = doc.GetElement(r.RevitId) as Room;
            XYZ locR = ((LocationPoint)rr.Location).Point;
            
            //XYZ locR = new XYZ(0, 0, 0); ;
            if (null != locR)
            {
                using (Transaction trans = new Transaction(doc))
                {
                    if (trans.Start("PlaceFamily") == TransactionStatus.Started)
                    {
                        FamilyInstance fi = doc.Create.NewFamilyInstance(locR,
                            GetFamilySymbolByName(BuiltInCategory.OST_SpecialityEquipment, "5A/21B")
                            , StructuralType.NonStructural);
                        //FamilyInstance fii = doc.Create.New
                        trans.Commit();
                        Debug.WriteLine("Raum id:" + rr.UniqueId + " - " + r.RevitId);
                        Debug.WriteLine("Raum Name:" + rr.Name + " - " + r.Bezeichung);
                        Debug.WriteLine("locR:" + locR);
                        Debug.WriteLine("");
                    }
                }
            }
        }

        private static FamilySymbol GetFamilySymbolByName(BuiltInCategory bic, string name)
        {
            return new FilteredElementCollector(doc).OfCategory(bic).OfClass(typeof(FamilySymbol))
                .FirstOrDefault<Element>(e => e.Name.Equals(name)) as FamilySymbol;
        }


        public static void loadFamilyExample(Document doc)
        {
            try
            {
                Family family = null;
                string fileName = @"C:\Users\igora\Desktop\IIB1_UE1-master\IIB1_UE1-master\IIB1_Hausübung_1\Feuerloescher-Familie.rfa";
                using (Transaction t = new Transaction(doc))
                {
                    if (t.Start("LoadFamily") == TransactionStatus.Started)
                    {
                        // try to load family
                        if (!doc.LoadFamily(fileName, out family))
                        {
                            throw new Exception("Unable to load " + fileName);
                        }
                        t.Commit();

                    }
                }

                string symbolNames = "";
                foreach (ElementId symbolId in family.GetFamilySymbolIds())
                {
                    symbolNames += family.Name + " - " + ((FamilySymbol)
                    family.Document.GetElement(symbolId)).Name + "\n";
                }
                TaskDialog.Show("Loaded", symbolNames);
            }
            catch
            {
                
            }
        }
        #endregion
    }
}
