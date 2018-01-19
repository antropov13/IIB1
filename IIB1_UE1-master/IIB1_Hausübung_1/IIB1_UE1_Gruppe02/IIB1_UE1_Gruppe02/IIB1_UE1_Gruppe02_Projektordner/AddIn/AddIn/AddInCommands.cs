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
using System.Text.RegularExpressions;

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
            BindingList<Feuerloescher> feuerlocherList = new BindingList<Feuerloescher>();

            Family family =  Util.getFamily("Feuerloescher-Familie");
            if (family==null) family = Util.loadFamilyExample(mdoc.Document);
            
            feuerlocherList = parseFamilyFeuerloescher(family);

            foreach (Element e in Rooms)
            {
                Raum r = Util.parseRaum((Room)e);
                if (r != null)
                    meineRaeume.Add(r);
            }

            App.thisApp.ShowForm(meineRaeume, feuerlocherList);
            return Result.Succeeded;
        }

        public static BindingList<Feuerloescher> parseFamilyFeuerloescher(Family family)
        {
            BindingList<Feuerloescher> feuerlocherList = new BindingList<Feuerloescher>();

            string fName = "";
            int fLE = 0;
            int fPreis = 0;
            string preis = "";
            foreach (ElementId symbolId in family.GetFamilySymbolIds())
            {
                //symbolNames += family.Name + " - " + ((FamilySymbol)family.Document.GetElement(symbolId)).Name + " ";
                //symbolNames += ((FamilySymbol)family.Document.GetElement(symbolId)).GetParameters("Loescheinheit")[0].AsValueString() + "\n";
                fName = ((FamilySymbol)family.Document.GetElement(symbolId)).Name;
                fLE = Convert.ToInt32(((FamilySymbol)family.Document.GetElement(symbolId)).GetParameters("Loescheinheit")[0].AsValueString());
                preis = ((FamilySymbol)family.Document.GetElement(symbolId)).GetParameters("Kosten")[0].AsValueString();
                fPreis = Convert.ToInt32(Regex.Replace(preis, @"[^\d]+", ""));

                Feuerloescher f = new Feuerloescher(fName, fLE, fPreis);
                feuerlocherList.Add(f);
            }

            return feuerlocherList;
        }
    }
}