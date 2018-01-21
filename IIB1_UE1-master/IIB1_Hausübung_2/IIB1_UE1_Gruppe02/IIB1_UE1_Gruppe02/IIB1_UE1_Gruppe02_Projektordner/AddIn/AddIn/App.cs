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

            myButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "Feuerloescher.jpg"), UriKind.Absolute));

            //Beschreibung, die erscheint, wenn man über den Button hovert.
            myButton.ToolTip = "Öffnet ein Tool, in dem erforderliche Feuerlöscher bestimmt werden können.";
        }


        public void ShowForm(BindingList<Raum> revitRaeume, BindingList<Feuerloescher> feuerlocherList)
        {
            // If we do not have a dialog yet, create and show it
            if (revitAppForm == null || revitAppForm.IsDisposed)
            {
                
                RaumdatenUpdater updateHandler = new RaumdatenUpdater(); //Update Raumdaten
                FeuerloescherPlatzierer feuerloescherHandler = new FeuerloescherPlatzierer(); //Plazierung Feuerloescher

                ExternalEvent updateEvent = ExternalEvent.Create(updateHandler); 
                ExternalEvent feuerloescherEvent = ExternalEvent.Create(feuerloescherHandler);

                revitAppForm = new FormMain(updateEvent, feuerloescherEvent, feuerlocherList, revitRaeume);
                revitAppForm.Show();
            }
        }
        #endregion

        #region ExternalEventhandler
        public class RaumdatenUpdater : IExternalEventHandler
        {
            public void Execute(UIApplication app)
            {
                Util.updateRaumDaten(revitAppForm.Raeume);
            }

            public string GetName()
            {
                return "RaumdatenUpdater";
            }
        }
        
        public class FeuerloescherPlatzierer : IExternalEventHandler
        {
            public void Execute(UIApplication app)
            {
                Util.platziereFeuerloescher(revitAppForm.Raeume);
            }

            public string GetName()
            {
                return "FeuerlöscherPlatzierer";
            }
        }
        #endregion
    }
}
 