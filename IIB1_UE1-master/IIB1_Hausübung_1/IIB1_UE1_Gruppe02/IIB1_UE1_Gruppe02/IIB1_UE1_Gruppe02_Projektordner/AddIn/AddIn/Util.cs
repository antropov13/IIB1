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
using System.Windows.Forms;
using System.IO;

namespace AddIn
{
    class Util
    {
        #region Attribute
        private static Document doc = null;
        private static Family family = null;
        private static IList<Element> alleFeuerloescher = new List<Element>();
        public static readonly string nutzungsart = "Nutzungsgruppe DIN 277-2";
        private static UIDocument mdoc = null;

        public static Document Doc
        {
            set
            {
                doc = value;
            }
        }

        public static UIDocument Mdoc
        {
            set
            {
                mdoc = value;
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
        public static Raum parseRaum(Room room)
        {
            //Parse Raum
            List<FamilyInstance> revitFeuerloescherListe = findeAlleRaumFeuerloescher(room);
            BindingList<Feuerloescher> feuerloescherListe = parseFeuerloescher(revitFeuerloescherListe);
            Klassen.Material material = new Klassen.Material();
            double flaeche = squarefeetToQuadratmeter(room.Area); //Fläche
            string raumtyp = room.GetParameters("Raumschlüssel")[0].AsValueString(); //Raumnutzungsart
            string name = room.Name.Replace(room.Number, "").Trim();

            if (raumtyp == "1" || raumtyp == "4")
            {
                Flur flur = new Flur(flaeche, name, room.Number, feuerloescherListe, material, room.UniqueId);
                return flur;
            }

            if (raumtyp == "2")
            {
                Buero buero = new Buero(flaeche, name, room.Number, feuerloescherListe, material, room.UniqueId); //UniqueID - einzigartiger Nummer jedes Raum
                return buero;
            }
            else if (raumtyp == "3" || raumtyp == "5")
            {
                Seminarraum seminarraum = new Seminarraum(flaeche, name, room.Number, feuerloescherListe, material, room.UniqueId);
                return seminarraum;
            }
            else if (raumtyp == "6" || raumtyp == "7")
            {
                Sanitaerraum sanitaerraum = new Sanitaerraum(flaeche, name, room.Number, feuerloescherListe, material, room.UniqueId);
                return sanitaerraum;
            }
            return null;
        }

        /// <summary>
        /// Parst eine Revit-FeuerloescherListe in ein Feuerloescher-FeuerloescherListe.
        /// </summary>
        /// <param name="revitFeuerloescherListe">liste von Fenster, die geparst werden soll.</param>
        /// <returns>Eine Liste der Feuerloescher eines Raumes</returns>
        /// 
        private static BindingList<Feuerloescher> parseFeuerloescher(List<FamilyInstance> revitFeuerloescherListe)
        {
            //Parse Feuerloescher
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

        // Suche alle Revit-Feuerloescher in der Raum.
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

        // Suche alle Revit-Feuerloescher im Document.
        public static void holeAlleFeuerloescher()
        {
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_SpecialityEquipment);
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            alleFeuerloescher = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();

            listFeuerloescherSuebern();
        }

        //Reinigung der Revit-Feuerloescherliste (nur die Feuerloescher, die in der Feld "Beschreibung" als "Feuerloescher aufgezeichnet haben)
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


        //Berechnung die Fläsche des Raum
        public static double squarefeetToQuadratmeter(double squarefeet)
        {
            double quadratmeter = (squarefeet / 10.7639);
            return Math.Round(quadratmeter, 2);
        }

        public static void updateRaumDaten(BindingList<Raum> raeume)
        {
            aendereBekannteProperties(raeume);
        }

        //Update Raumdaten
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
                             //   room.Name = r.Bezeichung;
                                room.Number = r.Nummer;
                                if (zugehörigeNutzungsart(r) != "")
                                    worked = room.GetParameters("Raumschlüssel")[0].Set(zugehörigeNutzungsart(r));
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

        //Empfang der Nutzungsart des Raum
        private static string zugehörigeNutzungsart(Raum r)
        {

            if (r is Buero)
                return "2";
            if (r is Flur)
                return "1";
            if (r is Sanitaerraum)
                return "7";
            if (r is Seminarraum)
                return "3";
            else return "";
        }


        public static bool mengeFeuerloscher(Raum r)
        {
            return (r.FeuerloescherList.Count <= 29);
        }


        public static bool getFeuerloscher(Raum r, Feuerloescher f)
        {
            foreach(Feuerloescher fr in r.FeuerloescherList)
            {
                if (fr.Bezeichnung.Equals(f.Bezeichnung)) return true;
            }
            return false;
        }

        //Plazierung der Feuerloescher
        public static void platziereFeuerloescher(BindingList<Raum> raeume)
        {
            Feuerloescher f = new Feuerloescher("27A/144B", 9, 140);
            f.Anzahl = 1;
            foreach (Raum r in raeume)
            {
                if (mengeFeuerloscher(r)) {
                    platziereFeuerloescherInRaum(r);
                    if (getFeuerloscher(r,f))
                        r.feueloescherAnzahlHinzu(f);
                    else
                        r.feueloescherHinzu(f);                   
                }
            }
        }

        //Empfang der Familie
        public static Family getFamily(String FamilyName)
        {
            FilteredElementCollector a = new FilteredElementCollector(doc).OfClass(typeof(Family));
            family = a.FirstOrDefault<Element>(e => e.Name.Equals(FamilyName)) as Family;
            return family;
        }

        //Plazierung der Feuerloescher in den Raum
        private static void platziereFeuerloescherInRaum(Raum r)
        {
            Room rr = doc.GetElement(r.RevitId) as Room;
            XYZ locR = mdoc.Selection.PickPoint("Bitte Punkt auswählen");

            
            if (null != locR)
            {
                using (Transaction trans = new Transaction(doc))
                {
                    if (trans.Start("PlaceFamily") == TransactionStatus.Started)
                    {
                        FamilyInstance fi = doc.Create.NewFamilyInstance(locR, GetFamilySymbolByName(BuiltInCategory.OST_SpecialityEquipment, "27A/144B"), StructuralType.NonStructural);
                        trans.Commit();
                    }
                }
            }
        }


        //Empfang des Feuerloescher als FamilieSymbol
        private static FamilySymbol GetFamilySymbolByName(BuiltInCategory bic, string name)
        {

            return new FilteredElementCollector(doc).OfCategory(bic).OfClass(typeof(FamilySymbol))
                .FirstOrDefault<Element>(e => e.Name.Equals(name)) as FamilySymbol;
        }

        //Ladung der Familie
        public static Family loadFamilyExample(Document doc, String path, String fileFamily)
        {
            try
            {
                string file = path + fileFamily;
                string fileName = @file;

                Debug.WriteLine("FileFamily: ", fileName);

                if (!File.Exists(fileName))
                {
                    string fehler = "Die Feuerlöscher-Familie wurde nicht gefunden.\nBitte wählen Sie den Speicherort der Familie im Dialogfenster aus.";
                    TaskDialog.Show("Familie ", fehler);
                    OpenFileDialog ofd = new OpenFileDialog();
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        //FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                        Debug.WriteLine("Load Family: " + ofd.FileName);
                    }
                    fileName = ofd.FileName;
                }

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

                string symbolNames = family.Name+"\n";
                foreach (ElementId symbolId in family.GetFamilySymbolIds())
                {
                    symbolNames += ((FamilySymbol)family.Document.GetElement(symbolId)).Name + "\n";
                }
                TaskDialog.Show("Load", symbolNames);
                return family;
            }
            catch
            {
                family = null;
                return family;
            }
            

        }
        #endregion
    }
}
