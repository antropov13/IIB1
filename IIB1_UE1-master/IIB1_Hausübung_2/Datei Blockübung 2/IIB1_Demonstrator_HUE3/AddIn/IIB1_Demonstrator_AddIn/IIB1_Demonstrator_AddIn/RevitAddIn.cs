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
            //TODO: Ribbon und Button erstellen
        }

        public void ShowForm(BindingList<Raum> revitRaeume)
        {
            //TODO: Form öffnen
        }
        #endregion

        #region ExternalEventhandler
        //TODO: EventHandler hinzufügen
        #endregion
    }
}
