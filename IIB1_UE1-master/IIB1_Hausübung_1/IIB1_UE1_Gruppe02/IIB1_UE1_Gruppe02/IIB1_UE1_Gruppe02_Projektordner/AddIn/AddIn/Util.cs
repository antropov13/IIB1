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
        /// 
        //private static 


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
                                room.Name = r.Bezeichung;
                                if (zugehörigeNutzungsart(r) != "")
                                    worked = room.GetParameters("Raumschlüssel").First().Set(zugehörigeNutzungsart(r));
                                trans.Commit();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                TaskDialog.Show("", e.Message);
            }
        }

        private static string zugehörigeNutzungsart(Raum r)
        {
            //string raumtyp = room.GetParameters("Raumschlüssel")[0].AsValueString();

            if (r is Buero)
            {
                //Buero buero = new Buero(flaeche, room.Number, feuerloescherListe, material);
                return "2";
            }
            else if (r is Seminarraum)
            {
                //Seminarraum seminarraum = new Seminarraum(flaeche, room.Number, feuerloescherListe, material);
                return "5";
            }
            else if (r is Sanitaerraum)
            {
                //Sanitaerraum sanitaerraum = new Sanitaerraum(flaeche, room.Number, feuerloescherListe, material);
                return "7";
            }
            else if (r is Flur)
            {
                //Flur flur = new Flur(flaeche, room.Number, feuerloescherListe, material);
                return "9";
            }
            else return "";
        }


        #endregion

    }
}
