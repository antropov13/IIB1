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
        public static readonly string nutzungsart = "Nutzungsgruppe DIN 277-2";
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
        /// 
        //private static 


        public static Raum parseRaum(Room room)
        {
            /*List<FamilyInstance> revitFensterListe = findeAlleRaumFenster(room);
            BindingList<Fenster> fensterListe = parseFenster(revitFensterListe);*/
            BindingList<Feuerloescher> feuerloescherListe = new BindingList<Feuerloescher>();
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
        #endregion

    }
}
