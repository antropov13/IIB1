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
    public partial class FormFeuerloescher : Form
    {
        private Raum raum;
        private BindingList<Feuerloescher> feuerloescherList;
        Feuerloescher feuerloescher = new Feuerloescher();
        private Boolean neuer = false;

        public FormFeuerloescher(Feuerloescher f, Raum _raum, BindingList<Feuerloescher> _feuerloescherList, FormRaum _parent)
        {
            InitializeComponent();
            this.raum = _raum;
            this.feuerloescherList = _feuerloescherList;
            this.Owner = _parent;
            this.feuerloescher = f;
            fuelleBoxen();
        }

        //Die Boxen werden gefüllt
        private void fuelleBoxen()
        {
            comboBoxBezeichnungFeuerloescher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxBezeichnungFeuerloescher.Items.Clear();

            if (feuerloescher!=null) //Wenn Änderung Feuerlöscher
            {
                this.Text = "Details Feuerlöschern";
                if (raum.FeuerloescherList.Count > 0)
                {
                    foreach (Feuerloescher f in raum.FeuerloescherList)
                    {
                        if (raum.FeuerloescherList.IndexOf(f) > -1)
                        {
                            comboBoxBezeichnungFeuerloescher.Items.Add(f);
                        }
                    }
                    comboBoxBezeichnungFeuerloescher.SelectedIndex = ((FormRaum)Owner).returnSelectedFeuerloscher();
                    trackBarAnzahlFeuerloescher.Value = feuerloescher.Anzahl;
                    buttonNeuerFeuerloescherSpeichern.Text = "Änderung speichern";
                    buttonFeuerloescherloeschen.Visible = true;
                    buttonFeuerloescherloeschen.Enabled = true;
                    buttonNeuerFeuerloescherSpeichern.Enabled = true;
                    comboBoxBezeichnungFeuerloescher.Enabled = true;
                    trackBarAnzahlFeuerloescher.Enabled = true;
                }
                else
                {
                    neuer = true;
                    buttonFeuerloescherloeschen.Enabled = false;
                    buttonNeuerFeuerloescherSpeichern.Enabled = false;
                    comboBoxBezeichnungFeuerloescher.Enabled = false;
                    trackBarAnzahlFeuerloescher.Enabled = false;
                }
            }
            else  //Oder wenn Neuer Feuerlöscher
            {
                buttonFeuerloescherloeschen.Visible = false;
                if (raum.FeuerloescherList.Count == feuerloescherList.Count)
                {
                    comboBoxBezeichnungFeuerloescher.Enabled = false;
                    buttonNeuerFeuerloescherSpeichern.Enabled = false;
                    trackBarAnzahlFeuerloescher.Enabled = false;
                }

                foreach (Feuerloescher f in feuerloescherList)
                {
                    if (raum.FeuerloescherList.IndexOf(f) == -1)
                    {
                            comboBoxBezeichnungFeuerloescher.Items.Add(f);
                    }
                }
                if(comboBoxBezeichnungFeuerloescher.Items.Count > 0)
                    comboBoxBezeichnungFeuerloescher.SelectedIndex = 0;
            }

            comboBoxBezeichnungFeuerloescher.DisplayMember = "Bezeichnung";

            labelAnzahlFeuerloescher.Text = Convert.ToString(trackBarAnzahlFeuerloescher.Value);
            textBoxLERaum.Text = Convert.ToString(raum.Loeschmitteleinheiten);

            changedTextBoxen(); //Die Funktion, die alle Boxen füllt.
        }

        private void comboBoxBezeichnungFeuerloescher_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //Wenn man Feuerlöscher wechselt 
            if (feuerloescher == null)
            {
                trackBarAnzahlFeuerloescher.Value = 1;
                feuerloescher = new Feuerloescher();
                neuer = true;
            }

            feuerloescher = (Feuerloescher)comboBoxBezeichnungFeuerloescher.SelectedItem;
            if (!neuer) trackBarAnzahlFeuerloescher.Value = feuerloescher.Anzahl;
            changedTextBoxen();
        }

        private void trackBarAnzahlFeuerloescher_ValueChanged(object sender, EventArgs e)
        {
            //Wenn man Anzahl der Feuerlöschern verändert
            changedTextBoxen();
        }


        private void textBoxLEFeuerloescher_TextChanged(object sender, EventArgs e)
        {
            changedTextBoxen();
        }

        private void textBoxBenoetigeLE_TextChanged(object sender, EventArgs e)
        {
            //label mit Anzahl der Feuerlöschern Grün oder Red, abhängig von Löschmitteleinheiten 
            int bLE = Convert.ToInt32(textBoxBenoetigeLE.Text);
            if (bLE == 0) labelAnzahlFeuerloescher.ForeColor = Color.Green;
            else labelAnzahlFeuerloescher.ForeColor = Color.Red;
        }

        private void changedTextBoxen()
        {
            int countFeuerloescher = 0;
            int leFeuerloeschen = 0;
            double preis = 0;
            int gesamtLE = 0;
            int benoetigeLE = 0;
            try
            {
                
                foreach (Feuerloescher f in raum.FeuerloescherList) //Alle Feuerlöschern, die sich im Raum befinden
                {
                    if (f != feuerloescher) //außer dem, den man verändert
                    {
                        countFeuerloescher += f.Anzahl;
                        leFeuerloeschen += f.Anzahl * f.Loescheinheit;
                        preis += f.Preis * f.Anzahl;
                        gesamtLE += f.Loescheinheit * f.Anzahl;
                    }
                    
                }
                benoetigeLE = raum.Loeschmitteleinheiten - (gesamtLE + trackBarAnzahlFeuerloescher.Value * feuerloescher.Loescheinheit);
                if (benoetigeLE < 0) benoetigeLE = 0;
                textBoxBenoetigeLE.Text = Convert.ToString(benoetigeLE);
                textBoxLEFeuerloescher.Text = Convert.ToString(trackBarAnzahlFeuerloescher.Value * feuerloescher.Loescheinheit);
                textBoxGesamtLE.Text = Convert.ToString(trackBarAnzahlFeuerloescher.Value * feuerloescher.Loescheinheit + gesamtLE);
                textBoxAnzahlFeuerloschen.Text = Convert.ToString(trackBarAnzahlFeuerloescher.Value + countFeuerloescher);
                textBoxGesamptpreisFeuerloscher.Text = Convert.ToString(trackBarAnzahlFeuerloescher.Value * feuerloescher.Preis + preis);
                labelAnzahlFeuerloescher.Text = Convert.ToString(trackBarAnzahlFeuerloescher.Value);

            }
            catch
            {

            }
        }

        private void buttonNeuerFeuerloescherSpeichern_Click(object sender, EventArgs e)
        {
            //Speichern Feuerlöscher
            feuerloescher.Anzahl = trackBarAnzahlFeuerloescher.Value;
            feuerloescher.Bezeichnung = comboBoxBezeichnungFeuerloescher.Text;
            ((FormRaum)Owner).feuerloescherHinzufuegen(feuerloescher);
            if (neuer) feuerloescher = null;
            fuelleBoxen();
        }

        private void buttonFeuerloescherloeschen_Click(object sender, EventArgs e)
        {
            //Löschen Feuerlöscher aus dem Raum
            ((FormRaum)Owner).feuerloescheLoeschen(f: (Feuerloescher)comboBoxBezeichnungFeuerloescher.SelectedItem);
            fuelleBoxen();
        }

        private void buttonabbrechen_Click(object sender, EventArgs e)
        {
            //Schliessen Form
            this.Close();
        }
    }
}
