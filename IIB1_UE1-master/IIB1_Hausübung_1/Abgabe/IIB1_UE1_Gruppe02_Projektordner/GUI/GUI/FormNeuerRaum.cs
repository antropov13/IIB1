using Klassen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormNeuerRaum : Form
    {
        
        public FormNeuerRaum(int _index, FormMain _parent)
        {
            InitializeComponent();
            this.Owner = _parent;
            textBoxRaumBezeichnung.Text = "Raum";
            textBoxRaumFlaeche.Text = "0,0";
            if (_index == -1) _index = 0;
            comboBoxRaumNutzungsart.SelectedIndex = _index;
            buttonNeuerRaum.Enabled = true;
            comboBoxRaumNutzungsart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void buttonNeuerRaum_Click(object sender, EventArgs e)
        {
            //Neuer Raum wird hinzugefügt
            int t = comboBoxRaumNutzungsart.SelectedIndex;
            
            switch (t) //Abhängig von Nutzungsart wird einen Konstruktor aufgerufen.
            {
                case 0:
                    Buero newBuero = new Buero();
                    newBuero.Bezeichung = textBoxRaumBezeichnung.Text;
                    try
                    {
                        newBuero.Grundflaeche = Double.Parse(textBoxRaumFlaeche.Text);
                    }
                    catch (Exception)
                    {
                        newBuero.Grundflaeche = 0.0;
                    }
                    newBuero.Loeschmitteleinheiten = newBuero.countLoeschmitteleinheiten(newBuero.Grundflaeche);
                    ((FormMain)Owner).raumErstellen(newBuero);
                    this.Close();
                    break;
                case 1:
                    Flur newFlur = new Flur();
                    newFlur.Bezeichung = textBoxRaumBezeichnung.Text;
                    try
                    {
                        newFlur.Grundflaeche = Double.Parse(textBoxRaumFlaeche.Text);
                    }
                    catch (Exception)
                    {
                        newFlur.Grundflaeche = 0.0;
                    }
                    newFlur.Loeschmitteleinheiten = newFlur.countLoeschmitteleinheiten(newFlur.Grundflaeche);
                    ((FormMain)Owner).raumErstellen(newFlur);
                    this.Close();
                    break;
                case 2:
                    Seminarraum newSeminarraum = new Seminarraum();
                    newSeminarraum.Bezeichung = textBoxRaumBezeichnung.Text;
                    try
                    {
                        newSeminarraum.Grundflaeche = Double.Parse(textBoxRaumFlaeche.Text);
                    }
                    catch (Exception)
                    {
                        newSeminarraum.Grundflaeche = 0.0;
                    }
                    newSeminarraum.Loeschmitteleinheiten = newSeminarraum.countLoeschmitteleinheiten(newSeminarraum.Grundflaeche);
                    ((FormMain)Owner).raumErstellen(newSeminarraum);
                    this.Close();
                    break;
                case 3:
                    Sanitaerraum newSanitaerraum = new Sanitaerraum();
                    newSanitaerraum.Bezeichung = textBoxRaumBezeichnung.Text;
                    try
                    {
                        newSanitaerraum.Grundflaeche = Double.Parse(textBoxRaumFlaeche.Text);
                    }
                    catch (Exception)
                    {
                        newSanitaerraum.Grundflaeche = 0.0;
                    }
                    newSanitaerraum.Loeschmitteleinheiten = newSanitaerraum.countLoeschmitteleinheiten(newSanitaerraum.Grundflaeche);
                    ((FormMain)Owner).raumErstellen(newSanitaerraum);
                    this.Close();
                    break;
            }      
          


        }

        private void textBoxRaumFlaeche_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Man darf nur Zahlen und comma einschreiben
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBoxRaumBezeichnung_TextChanged(object sender, EventArgs e)
        {
            buttonNeuerRaumEnabled();
        }

        private void textBoxRaumFlaeche_TextChanged(object sender, EventArgs e)
        {
            try
            {
                buttonNeuerRaumEnabled();
                int max = 2147483632;
                if (textBoxRaumFlaeche.Text != "")
                {
                    double change = Convert.ToDouble(textBoxRaumFlaeche.Text);

                    if (change > max) textBoxRaumFlaeche.Text = "2147483632";
                }
            }
            catch
            {
                textBoxRaumFlaeche.Text = "0";
            }

        }

        private void buttonNeuerRaumEnabled()
        {
         
            if ((textBoxRaumBezeichnung.TextLength > 0) && (textBoxRaumFlaeche.TextLength > 0)) buttonNeuerRaum.Enabled = true;
            else buttonNeuerRaum.Enabled = false;

        }

        private void buttonAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
