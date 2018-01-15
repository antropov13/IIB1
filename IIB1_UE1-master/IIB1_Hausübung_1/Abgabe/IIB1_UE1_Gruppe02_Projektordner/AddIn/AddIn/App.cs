using System;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

using Autodesk.Revit.DB.Architecture;
using GUI;
using Klassen;
using Autodesk.Revit.DB;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace AddIn
{
    /// <summary>
    /// Ribbon: Neben der Revit Referenzen müssen weitere Referenzen hinzugefügt werden (Für das Handling von Grafiken auf den Buttons):
    /// - PresentationCore
    /// - WindowsBase
    /// - System.Windows.Forms
    /// - System.Windows.Presentation
    /// 
    /// Quellen: 
    /// - Revit 2017 SDK, Sample "Ribbon"
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class App : IExternalApplication
    {
        #region Attribute
        // ExternalCommands assembly path
        static string AddInPath = typeof(App).Assembly.Location;
        // Button icons directory
        static string ButtonIconsFolder = Path.GetDirectoryName(AddInPath);
        // class instance
        public static App thisApp = null;
        // ModelessForm instance
        public static FormMain revitAppForm;
        #endregion

        #region IExternalApplication Members
        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        {
            try
            {
                // eigenes Ribbon Item erstellen
                CreateRibbonSamplePanel(application);
                revitAppForm = null;
                thisApp = this; 


                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Fehler", ex.ToString());

                return Autodesk.Revit.UI.Result.Failed;
            }
        }

        public Autodesk.Revit.UI.Result OnShutdown(UIControlledApplication application)
        {
            //Fenster schließen
            if (revitAppForm != null && revitAppForm.Visible)
            {
                revitAppForm.Close();
            }

            return Autodesk.Revit.UI.Result.Succeeded;
        }
        #endregion

        #region Methoden
        /// <summary>
        /// Diese Methode ruft das Fenster auf.
        /// Quelle: https://knowledge.autodesk.com/search-result/caas/CloudHelp/cloudhelp/2016/ENU/Revit-API/files/GUID-0A0D656E-5C44-49E8-A891-6C29F88E35C0-htm.html
        /// </summary>
        public void ShowForm(UIApplication uiapp)
        {
            // If we do not have a dialog yet, create and show it
            if (revitAppForm == null || revitAppForm.IsDisposed)
            {
                // We give the objects to the new dialog;
                // The dialog becomes the owner responsible for disposing them, eventually.
                UIApplication mapp = uiapp;
                UIDocument mdoc = mapp.ActiveUIDocument;
                Util.Doc = mdoc.Document;

                BindingList<Raum> meineRaeume = new BindingList<Raum>();
                BindingList<Feuerloescher> feuerloescher = new BindingList<Feuerloescher>();

                List<Element> Rooms = new FilteredElementCollector(mdoc.Document).OfClass(typeof(SpatialElement)).
                        WhereElementIsNotElementType().Where(room => room.GetType() == typeof(Room)).ToList();
                BindingList<Raum> raeume = new BindingList<Raum>();
                foreach (Element e in Rooms)
                {
                    Raum r = Util.parseRaum((Room)e);
                    if (r != null)
                        meineRaeume.Add(r);
                }

                //Aufrufen der Form
                revitAppForm = new FormMain(meineRaeume, feuerloescher);
                revitAppForm.Show();
            }
        }

        /// <summary>
        /// In dieser Methode wird das Ribbonpanel mit einem Button erzeugt.
        /// Weitere Informationen unter:
        /// https://knowledge.autodesk.com/search-result/caas/CloudHelp/cloudhelp/2017/ENU/Revit-API/files/GUID-1547E521-59BD-4819-A989-F5A238B9F2B3-htm.html
        /// </summary>
        /// <param name="application">An object that is passed to the external application 
        /// which contains the controlled application.</param>
        private void CreateRibbonSamplePanel(UIControlledApplication application)
        {
            // erstellt ein neues Ribbonpanel mit einem Push Button 
            // für weiter Buttons (Radiobutton, Splitbutton, Stackable Button) siehe Revit 2017 SDK, Sample "Ribbon"
            // um einen neuen Tab zu erstellen: statt CreateRibbonPanel(panelName) --> CreateRibbonTab(tabName)
            string panelName = "Brandschutz";
            RibbonPanel ribbonBrandschutzPanel = application.CreateRibbonPanel(panelName);

            //string classname: Namespace und Klassenname der Klasse, die durchgeführt werden soll, wenn der Button betätigt wird,
            //in diesem Fall: Namespace "Beispiel_Brandschutz", Klasse "StartApp" aus der Datei "AddInCommand.cs
            PushButton myButton = (PushButton)ribbonBrandschutzPanel.AddItem(new PushButtonData("RevitApp", "Brandschutz Tools",
                AddInPath, "AddIn.StartApp"));

            //Beschreibung, die erscheint, wenn man über den Button hovert.
            myButton.ToolTip = "Öffnet ein Tool, in dem erforderliche Feuerlöscher bestimmt werden können.";
        }
        #endregion

    }
}