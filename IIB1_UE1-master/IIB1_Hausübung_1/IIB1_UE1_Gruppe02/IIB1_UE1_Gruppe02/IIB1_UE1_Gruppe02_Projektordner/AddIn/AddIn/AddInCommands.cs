using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Architecture;
using System.ComponentModel;
using Klassen;
using GUI;

namespace AddIn
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class StartApp : IExternalCommand
    {
        private BindingList<Raum> meineRaeume = new BindingList<Raum>();

        public virtual Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            //UIApplication mapp = uiapp;
            UIDocument mdoc = uiApp.ActiveUIDocument;
            Util.Doc = mdoc.Document;

            //Util.loadFamilyExample(mdoc.Document);

            List<Element> Rooms = new FilteredElementCollector(mdoc.Document).OfClass(typeof(SpatialElement)).
                    WhereElementIsNotElementType().Where(room => room.GetType() == typeof(Room)).ToList();
            Util.holeAlleFeuerloescher();
            BindingList<Raum> raeume = new BindingList<Raum>();

            foreach (Element e in Rooms)
            {
                Raum r = Util.parseRaum((Room)e);
                if (r != null)
                    meineRaeume.Add(r);
            }

            App.thisApp.ShowForm(meineRaeume);
            return Result.Succeeded;
        }
    }
}