using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System;
using IIB1_Demonstrator.Klassen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using IIB1_Demonstrator_GUI.Forms;
using Autodesk.Revit.DB.Architecture;

namespace IIB1_Demonstrator_AddIn
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class RevitAddIn : IExternalCommand
    {
        private static BindingList<Raum> meineRaeume = new BindingList<Raum>();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try {

                /* UIApplication uiApp = commandData.Application;
                 UIDocument mdoc = uiApp.ActiveUIDocument;
                 Util.Doc = mdoc.Document;

                 List<Element> Rooms = new FilteredElementCollector(mdoc.Document).OfClass(typeof(SpatialElement)).
                     WhereElementIsNotElementType().Where(room => room.GetType() == typeof(Room)).ToList();
                 Util.holeAlleFenster();
                 BindingList<Raum> raeume = new BindingList<Raum>();
                 foreach (Element e in Rooms)
                 {
                     Raum r = Util.parseRaum((Room)e);
                     if (r != null)
                         meineRaeume.Add(r);
                 }
                 */

                bspRaeume();

                FormMain m = new FormMain(meineRaeume);
                m.ShowDialog();
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception e) { return Result.Failed; }
        }

        private static void bspRaeume()
        {
            Random rd = new Random();
            for (int i = 0; i < 4; i++)
            {
                double bFlaeche = rd.NextDouble() * rd.Next(50, 100);
                double wFlaeche = rd.NextDouble() * rd.Next(50, 100);
                String bNummer = rd.Next(1, 75).ToString() + "a";
                String wNummer = rd.Next(1, 75).ToString() + "b";
                int bFenster = rd.Next(1, 5);
                int wFenster = rd.Next(1, 5);
                BindingList<Fenster> bFensterListe = new BindingList<Fenster>();
                BindingList<Fenster> wFensterListe = new BindingList<Fenster>();
                for (int j = 0; j < bFenster; j++)
                {
                    String fBez = j + "";
                    double fFlaeche = rd.NextDouble() * 2;
                    String typ = "test";
                    bFensterListe.Add(new Fenster(fFlaeche, fBez, typ));
                }
                for (int j = 0; j < wFenster; j++)
                {
                    String fBez = j + "";
                    double fFlaeche = rd.NextDouble() * 2;
                    String typ = "test";
                    wFensterListe.Add(new Fenster(fFlaeche, fBez, typ));
                }
                Buero b = new Buero(bFlaeche, bNummer, bFensterListe);
                Wohnen w = new Wohnen(wFlaeche, wNummer, wFensterListe);
                meineRaeume.Add(b);
                meineRaeume.Add(w);
            }
        }
    }
}
