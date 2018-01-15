using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using System.ComponentModel;
using IIB1_Demonstrator.Klassen;
using Autodesk.Revit.DB.Architecture;
using IIB1_Demonstrator_GUI.Forms;
using Autodesk.Revit.Attributes;

namespace IIB1_Demonstrator_AddIn
{
    [Transaction(TransactionMode.Manual)]
    public class StartApp : IExternalCommand
    {
        private BindingList<Raum> meineRaeume = new BindingList<Raum>();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {

                UIApplication uiApp = commandData.Application;
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
                RevitAddIn.thisApp.ShowForm(meineRaeume);
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception e) { return Result.Failed; }
        }
    }
}
