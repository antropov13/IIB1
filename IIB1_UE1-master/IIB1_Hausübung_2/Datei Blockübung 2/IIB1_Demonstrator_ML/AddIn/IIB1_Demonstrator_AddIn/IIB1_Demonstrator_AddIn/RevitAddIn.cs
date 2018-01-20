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
using System.IO;
using System.Windows.Media.Imaging;

namespace IIB1_Demonstrator_AddIn
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class RevitAddIn : IExternalApplication
    {
        #region Attribute
        // ExternalCommands assembly path
        static string AddInPath = typeof(RevitAddIn).Assembly.Location;
        // Button icons directory (Debug-Ordner)
        static string ButtonIconsFolder = Path.GetDirectoryName(AddInPath);
        // class instance
        public static RevitAddIn thisApp = null;
        // ModelessForm instance
        public static FormMain demoForm;
        #endregion

        #region Interface-Methoden
        public Result OnShutdown(UIControlledApplication application)
        {
            //Schließe die Fenster, sofern diese noch offen sind
            if (demoForm != null && demoForm.Visible)
                demoForm.Close();
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                createRibbonPanel(application);
                demoForm = null;
                thisApp = this;

                return Result.Succeeded;
            }
            catch (Exception e)
            {
                TaskDialog.Show("IIB 1 Demonstrator", e.ToString());

                return Result.Failed;
            }
        }
        #endregion


        #region Methoden
        private void createRibbonPanel(UIControlledApplication application)
        {
            //erstellt ein neues Ribbonpanel für einen Push Button
            //für weiter Buttons (Radiobutton, Splitbutton, Stackable Button) siehe Revit 2017 SDK, Sample "Ribbon"
            //um einen neuen Tab zu erstellen: statt CreateRibbonPanel(panelName) --> CreateRibbonTab(tabName)
            String panelName = "IIB 1 Demonstrator";
            RibbonPanel ribbonDemoPanel = application.CreateRibbonPanel(panelName);

            //string classname: Namespace und Klassenname der Klasse (ExternalCommand), die ausgeführt werden soll, wenn der Button betätigt wird,
            //in diesem Fall: Namespace "IIB1_Demonstrator_AddIn", Klasse "StartApp" aus der Datei "AddInCommand.cs"
            PushButton myButton = (PushButton)ribbonDemoPanel.AddItem(new PushButtonData("IIB1Demo", "Fensterflächenverhältnis",
                AddInPath, "IIB1_Demonstrator_AddIn.StartApp"));

            //Hier werden dem Button Bilder zugefügt (max 32 x 32 Pixel)
            //benötigt Import des PresentationCore Verweises
            myButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "Fenster.png"), UriKind.Absolute));

            //Beschreibung, die erscheint, wenn man über den Button hovert. Beim längeren Verbleib der Maus über dem Button erscheint außerdem
            //das BitMapImage (beliebig groß).
            myButton.ToolTip = "Öffnet ein Tool, in dem das Fensterflächenverhältnis bestimmt wird.";
            myButton.ToolTipImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "panoramafenster.jpg"), UriKind.Absolute));
        }

        public void ShowForm(BindingList<Raum> revitRaeume)
        {
            if (demoForm == null || demoForm.IsDisposed)
            {
                RaumdatenUpdater updateHandler = new RaumdatenUpdater();
                LampenPlatzierer lampenHandler = new LampenPlatzierer();

                ExternalEvent updateEvent = ExternalEvent.Create(updateHandler);
                ExternalEvent lampenEvent = ExternalEvent.Create(lampenHandler);

                demoForm = new FormMain(updateEvent, lampenEvent, revitRaeume);
                demoForm.Show();
            }
        }
        #endregion

        #region ExternalEventhandler
        public class RaumdatenUpdater : IExternalEventHandler
        {
            public void Execute(UIApplication app)
            {
                Util.updateRaumDaten(demoForm.Raeume);
            }

            public string GetName()
            {
                return "RaumdatenUpdater";
            }
        }

        public class LampenPlatzierer : IExternalEventHandler
        {
            public void Execute(UIApplication app)
            {
                Util.platziereLampen(demoForm.Raeume);
            }

            public string GetName()
            {
                return "LampenPlatzierer";
            }
        }
        #endregion
    }
}
