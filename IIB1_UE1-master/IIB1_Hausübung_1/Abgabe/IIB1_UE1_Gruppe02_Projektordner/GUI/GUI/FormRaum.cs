using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klassen;

namespace GUI
{
    public partial class FormRaum : Form
    {
        private Raum raum;
        private BindingList<Feuerloescher> feuerloescherList;
        String gesamptpreis = "0";
        public FormRaum(Raum _raum, BindingList<Feuerloescher> _feuerloescherList, FormMain _parent)
        {
            InitializeComponent();
            this.raum = _raum;
            this.feuerloescherList = _feuerloescherList;
            this.Owner = _parent;
            fuelleBoxen();
        }

        private void fuelleBoxen()
        {   
            //Die Boxen werden gefüllt
            comboBoxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxRaumNutzungsart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            textBoxRaumBezeichnung.Text = raum.Bezeichung;
            textBoxRaumFlaeche.Text = Math.Round(raum.Grundflaeche, 2).ToString();
            textBoxLoeschmeiiteleinheiten.Text = raum.Loeschmitteleinheiten.ToString();
            textBoxHeizwertRaum.Text = Convert.ToString(raum.Heizwert);

            textBoxMaterialDichte.Text = Convert.ToString(raum.Materialien.Dichte);
            textBoxGesamptdickeMaterial.Text = Convert.ToString(raum.Materialien.Gesamtdicke);
            textBoxFlaecheMaterial.Text = Convert.ToString(raum.Materialien.Flaeche);

            String typ = raum.TypRaume;

            switch (typ)
            {
                case "Büro":
                    comboBoxRaumNutzungsart.SelectedIndex = 0;
                    break;
                case "Flur":
                    comboBoxRaumNutzungsart.SelectedIndex = 1;
                    break;
                case "Seminarraum":
                    comboBoxRaumNutzungsart.SelectedIndex = 2;
                    break;
                case "Sanitärraum":
                    comboBoxRaumNutzungsart.SelectedIndex = 3;
                    break;
            }

            //String material = raum.Materialien.Bezeichnung;
            brandlastUpdate();
            switch (raum.Materialien.Bezeichnung)
            {
                case "Beton":
                    comboBoxMaterial.SelectedIndex = 0;
                    break;
                case "Gipskartonplatten":
                    comboBoxMaterial.SelectedIndex = 1;
                    break;
                case "Holzwolle-Leichtbauplatte":
                    comboBoxMaterial.SelectedIndex = 2;
                    break;
                case "Holz":
                    comboBoxMaterial.SelectedIndex = 3;
                    break;

            }
            
            brandlastUpdate(); //Rechnung Brandlast
            feuerloescherUpdate(0); //Aktulisierung Feuerlöschern

        }

        private void feuerloescherUpdate(int index)
        {
            //Aktulisierung Feuerlöschern
            listBoxFeuerlocher.Items.Clear();
            listBoxLE.Items.Clear();
            listBoxPreisFeuerloescher.Items.Clear();
            listBoxCountFeuerloescher.Items.Clear();
            listBoxPreisSummaFeuerloscher.Items.Clear();

            int anzahl = 0;
            double summe = 0;
            int le = 0;
            foreach (Feuerloescher fl in raum.FeuerloescherList)
            {
                double k = fl.Anzahl * fl.Preis;

                listBoxFeuerlocher.Items.Add(fl);
                listBoxLE.Items.Add(fl.Loescheinheit);
                listBoxPreisFeuerloescher.Items.Add(fl.Preis);
                listBoxCountFeuerloescher.Items.Add(fl.Anzahl);
                listBoxPreisSummaFeuerloscher.Items.Add(k);

                anzahl += fl.Anzahl;
                le += fl.Loescheinheit * fl.Anzahl;
                summe += k;
            }

            gesamptpreis = Convert.ToString(summe);
            listBoxFeuerlocher.DisplayMember = "Bezeichnung";
            if (raum.FeuerloescherList.Count > 0)
            {
                listBoxFeuerlocher.SelectedIndex = index;
                listBoxLE.SelectedIndex = index;
                listBoxPreisFeuerloescher.SelectedIndex = index;
                listBoxCountFeuerloescher.SelectedIndex = index;
                listBoxPreisSummaFeuerloscher.SelectedIndex = index;
                buttonFeuerloescherDetails.Enabled = true;
                buttonFeuerloescherloeschen.Enabled = true;
                buttonFeuerloescherDetails.BackColor = Color.FromName("Gold");
                buttonFeuerloescherloeschen.BackColor = Color.FromName("LightCoral");
                if (raum.FeuerloescherList.Count == this.feuerloescherList.Count)
                {
                    buttonNeuerFeuerloescherhinzufuegen.Enabled = false;
                    buttonNeuerFeuerloescherhinzufuegen.BackColor = DefaultBackColor;
                }
                else
                {
                    buttonNeuerFeuerloescherhinzufuegen.Enabled = true;
                    buttonNeuerFeuerloescherhinzufuegen.BackColor = Color.FromName("LightGreen");
                }

            }
            else
            {
                buttonNeuerFeuerloescherhinzufuegen.Enabled = true;
                buttonNeuerFeuerloescherhinzufuegen.BackColor = Color.FromName("LightGreen");
                buttonFeuerloescherDetails.Enabled = false;
                buttonFeuerloescherloeschen.Enabled = false;
                buttonFeuerloescherDetails.BackColor = DefaultBackColor;
                buttonFeuerloescherloeschen.BackColor = DefaultBackColor;
            }

            textBoxLESumme.Text = Convert.ToString(le);
            textBoxAnzahlSumme.Text = Convert.ToString(anzahl);
            textBoxGesamptpreis.Text = Convert.ToString(summe);

        }

        private void buttonAenderungsSpeichern_Click(object sender, EventArgs e)
        {
            //Speichern Änderung des Raum
            String typ = comboBoxRaumNutzungsart.Text;
            raum.TypRaume = typ;
            switch (typ)
            {
                case "Büro":
                    Buero newBuero = new Buero(raum);
                    raum = newBuero;
                    break;
                case "Flur":
                    Flur newFlur = new Flur(raum);
                    raum = newFlur;
                    break;
                case "Seminarraum":
                    Seminarraum newSeminarraum = new Seminarraum(raum);
                    raum = newSeminarraum;
                    break;
                case "Sanitärraum":
                    Sanitaerraum newSanitaerraum = new Sanitaerraum(raum);
                    raum = newSanitaerraum;
                    break;
            }
            raum.Bezeichung = textBoxRaumBezeichnung.Text;
            raum.Grundflaeche = Convert.ToDouble(textBoxRaumFlaeche.Text);
            raum.Loeschmitteleinheiten = Convert.ToInt32(textBoxLoeschmeiiteleinheiten.Text);

            raum.Materialien.Bezeichnung = comboBoxMaterial.Text;
            raum.Materialien.Dichte = Convert.ToDouble(textBoxMaterialDichte.Text);
            raum.Materialien.Gesamtdicke = Convert.ToDouble(textBoxGesamptdickeMaterial.Text);
            raum.Materialien.Flaeche = Convert.ToDouble(textBoxFlaecheMaterial.Text);
            raum.Materialien.BrandbareMasse = Convert.ToDouble(textBoxBrandbareMasse.Text);
            raum.Brandlast = Convert.ToDouble(textBoxBrandlastRaum.Text);
            ((FormMain)Owner).raumAenderung(raum);

        }

        private void textBoxRaumFlaeche_TextChanged(object sender, EventArgs e)
        {
            //textBox Fläche des Raum
            int max = 2147483632;
            try
            {
                if (textBoxRaumFlaeche.Text != "")
                {
                    if (textBoxRaumFlaeche.Text == "00") textBoxRaumFlaeche.Text = "0";

                    double change = Convert.ToDouble(textBoxRaumFlaeche.Text);
                    if (change > max) textBoxLoeschmeiiteleinheiten.Text = "Error";
                    else
                    {
                        textBoxLoeschmeiiteleinheiten.Text = Convert.ToString(raum.countLoeschmitteleinheiten(change));
                    }
                    if (change==0)
                    {
                        textBoxLoeschmeiiteleinheiten.Text = "0";
                    }
                }
                else
                {
                    textBoxRaumFlaeche.Text = "0";
                    textBoxLoeschmeiiteleinheiten.Text = "0";
                }
            }
            catch
            {
                textBoxRaumFlaeche.Text = "0";
                textBoxLoeschmeiiteleinheiten.Text = "0";
            }
            buttonAnderungEnabled();


        }

        private void textBoxRaumBezeichnung_TextChanged(object sender, EventArgs e)
        {
            buttonAnderungEnabled();
        }

        private void buttonAnderungEnabled()
        {
            try
            {
                double flaeche = Convert.ToDouble(textBoxRaumFlaeche.Text);
                if ((textBoxRaumBezeichnung.TextLength > 0) && (flaeche > 0))
                {
                    buttonAenderungsSpeichern.Enabled = true;
                    buttonAenderungsSpeichern.BackColor = Color.FromName("DeepSkyBlue"); ;
                }
                else
                {
                    buttonAenderungsSpeichern.Enabled = false;
                    buttonAenderungsSpeichern.BackColor = DefaultBackColor;
                }
            }
            catch
            {

            }

        }

        private void textBoxRaumFlaeche_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void buttonFeuerloescherDetails_Click(object sender, EventArgs e)
        {
            //Rufe FormFeuerlöscher Details auf
            rufeFormFeuerloescherAuf(f: (Feuerloescher)listBoxFeuerlocher.SelectedItem);
        }

        private void rufeFormFeuerloescherAuf(Feuerloescher f = null)
        {
            //FormFeuerlöscher - Details ausgewählte Feuerlöscher oder neuer Feruerlöscher
            FormFeuerloescher fNewFeuerloescher = new FormFeuerloescher(f, raum, feuerloescherList, this);
            fNewFeuerloescher.ShowDialog();
        }

        private void buttonNeuerFeuerloescherhinzufuegen_Click(object sender, EventArgs e)
        {
            //rufe neuer Feuerlöscher auf
            rufeFormFeuerloescherAuf();
        }

        private void buttonFeuerloescherloeschen_Click(object sender, EventArgs e)
        {
            //Feuerlöscher löschen
            feuerloescheLoeschen();
        }

        public void feuerloescheLoeschen(Feuerloescher f = null)
        {
            //Feuerlöscher löschen
            if (f==null)
                raum.FeuerloescherList.Remove((Feuerloescher)listBoxFeuerlocher.SelectedItem);
            else raum.FeuerloescherList.Remove(f);
            feuerloescherUpdate(0);
        }

        public void feuerloescherHinzufuegen(Feuerloescher feuerloescher)
        {
            //Feuerlöscher hinzufügen oder ändern
            if (raum.FeuerloescherList.IndexOf(feuerloescher) == -1)
            {
                raum.FeuerloescherList.Add(feuerloescher);
                feuerloescherUpdate(raum.FeuerloescherList.Count-1);
            }
            else
            {
                foreach (Feuerloescher f in raum.FeuerloescherList)
                {
                    if (f == feuerloescher)
                    {
                        f.Anzahl = feuerloescher.Anzahl;
                        listBoxFeuerlocher.SelectedItem = f;
                        feuerloescherUpdate(listBoxFeuerlocher.SelectedIndex);
                        break;
                    }
                }
            }
            
        }

        public int returnSelectedFeuerloscher()
        {
            //Rückgabe ausgewählte Feuerlöscher
            return listBoxFeuerlocher.SelectedIndex;
        }

        private void buttonabbrechen_Click(object sender, EventArgs e)
        {
            //Forn schliessen
            this.Close();
        }

        private void textBoxLoeschmeiiteleinheiten_TextChanged(object sender, EventArgs e)
        {
            progressBarBrandschutzplanung.Maximum = Convert.ToInt32(textBoxLoeschmeiiteleinheiten.Text);
            progressBarBrandschutz();
            raum.Loeschmitteleinheiten = Convert.ToInt32(textBoxLoeschmeiiteleinheiten.Text);
        }

        private void textBoxLESumme_TextChanged(object sender, EventArgs e)
        {
            progressBarBrandschutz();
        }

        private void progressBarBrandschutz()
        {
            //ProgressBar und Information über Brandschunzplanung
            int LEFeuerloeschern = 0, LERaum = 0, prozent = 0;
            if (textBoxLoeschmeiiteleinheiten.Text != "")
                LERaum = Convert.ToInt32(textBoxLoeschmeiiteleinheiten.Text);
            if (textBoxLESumme.Text != "")
                LEFeuerloeschern = Convert.ToInt32(textBoxLESumme.Text);
            progressBarBrandschutzplanung.Maximum = LERaum;

            if (LEFeuerloeschern <= LERaum)
            {
                progressBarBrandschutzplanung.Value = LEFeuerloeschern;
            }
            else
            {
                progressBarBrandschutzplanung.Value = LERaum;
            }
            if (LERaum!=0)
                prozent = LEFeuerloeschern * 100 / LERaum;
            if (prozent >= 100)
            {
                labelProgressBar.ForeColor = Color.FromName("ForestGreen");
                textBoxInfoBrandschutz.ForeColor = Color.FromName("ForestGreen");
                textBoxInfoBrandschutz.Text = Convert.ToString("Die Brandschutzplanung erfüllt alle erforderlichen Vorgaben. Dem Raum wurden genügend Feuerlöscher hinzugefügt." + Environment.NewLine + Environment.NewLine + "Die Kosten für die Feuermelder betragen zusammen " + gesamptpreis + "€.");
            }
            else
            {
                labelProgressBar.ForeColor = Color.FromName("Red");
                textBoxInfoBrandschutz.ForeColor = Color.FromName("Red");
                textBoxInfoBrandschutz.Text = Convert.ToString("Die Brandschutzplanung erfüllt nicht alle erforderlichen Vorgaben, dem Raum wurden nicht genügend Feuerlöscher hinzugefügt. Um die Brandschutvorgaben zu erfüllen, fügen Sie weitere Feuerlöscher hinzu");

            }
            if (prozent > 100) prozent = 100;
            if (LERaum > 0)
                labelProgressBar.Text = Convert.ToString("Löschmitteleinheit " + LEFeuerloeschern + " aus " + LERaum + " | " + prozent + "% Brandschutz");
            else labelProgressBar.Text = "Raumfläche darf nicht null sein";
        }

        private void textBoxGesamptpreis_TextChanged(object sender, EventArgs e)
        {
            gesamptpreis = textBoxGesamptpreis.Text;
        }

        private void comboBoxRaumNutzungsart_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox Nutzungsart
            String typ = comboBoxRaumNutzungsart.Text;
            raum.Heizwert = ((FormMain)Owner).returnHeizwert(typ);
            textBoxHeizwertRaum.Text = Convert.ToString(raum.Heizwert);
            brandlastUpdate();
        }

        private void comboBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            brandlastUpdate();
        }

        public void brandlastUpdate()
        {
            //Aktulisierung Brandlast
            String bezeichnung = comboBoxMaterial.Text;
            textBoxMaterialDichte.Text = Convert.ToString(raum.Materialien.Dichte);
            textBoxGesamptdickeMaterial.Text = Convert.ToString(raum.Materialien.Gesamtdicke);
            textBoxFlaecheMaterial.Text = Convert.ToString(raum.Materialien.Flaeche);
            raum.Materialien.BrandbareMasse = raum.Materialien.Dichte * raum.Materialien.Gesamtdicke * raum.Materialien.Flaeche;
            textBoxBrandbareMasse.Text = Convert.ToString(raum.Materialien.BrandbareMasse);
            raum.Brandlast = raum.Materialien.BrandbareMasse * raum.Heizwert;
            textBoxBrandlastRaum.Text = Convert.ToString(raum.Brandlast);
        }


        //textBoxen für BrandLast
        private void textBoxMaterialDichte_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String dichte = textBoxMaterialDichte.Text;
                if (dichte != "")
                {
                    if (dichte == "00") textBoxMaterialDichte.Text = "0";
                    raum.Materialien.Dichte = Convert.ToDouble(dichte);
                }
                else raum.Materialien.Dichte = 0;
                brandlastUpdate();
            }
            catch
            {
                raum.Materialien.Dichte = 0;
                brandlastUpdate();
            }
        }

        private void textBoxGesamptdickeMaterial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String gesamptDicke = textBoxGesamptdickeMaterial.Text;
                if (gesamptDicke != "")
                {
                    if (gesamptDicke == "00") textBoxGesamptdickeMaterial.Text = "0";
                    raum.Materialien.Gesamtdicke = Convert.ToDouble(gesamptDicke);
                }
                else raum.Materialien.Gesamtdicke = 0;
                brandlastUpdate();
            }
            catch
            {
                raum.Materialien.Gesamtdicke = 0;
                brandlastUpdate();
            }
        }

        private void textBoxFlaecheMaterial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                String flaeche = textBoxFlaecheMaterial.Text;
                if (flaeche != "")
                {
                    if (flaeche == "00") textBoxFlaecheMaterial.Text = "0";
                    raum.Materialien.Flaeche = Convert.ToDouble(flaeche);
                }
                else raum.Materialien.Flaeche = 0;
                brandlastUpdate();
            }
            catch {
                raum.Materialien.Flaeche = 0;
                brandlastUpdate();
            }
        }

        private void textBoxMaterialDichte_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBoxGesamptdickeMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBoxFlaecheMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        //Element in ListBoxen mit den Feuerlöschern wird abhängig von dem Auswahl geändert
        private void listBoxFeuerlocher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxFeuerlocher.SelectedIndex;
            listBoxLE.SelectedIndex = index;
            listBoxPreisFeuerloescher.SelectedIndex = index;
            listBoxCountFeuerloescher.SelectedIndex = index;
            listBoxPreisSummaFeuerloscher.SelectedIndex = index;
        }

        private void listBoxLE_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxLE.SelectedIndex;
            listBoxFeuerlocher.SelectedIndex = index;
            listBoxPreisFeuerloescher.SelectedIndex = index;
            listBoxCountFeuerloescher.SelectedIndex = index;
            listBoxPreisSummaFeuerloscher.SelectedIndex = index;

        }

        private void listBoxCountFeuerloescher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxCountFeuerloescher.SelectedIndex;
            listBoxFeuerlocher.SelectedIndex = index;
            listBoxLE.SelectedIndex = index;
            listBoxPreisFeuerloescher.SelectedIndex = index;
            listBoxPreisSummaFeuerloscher.SelectedIndex = index;
        }

        private void listBoxPreisFeuerloescher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxPreisFeuerloescher.SelectedIndex;
            listBoxFeuerlocher.SelectedIndex = index;
            listBoxLE.SelectedIndex = index;
            listBoxCountFeuerloescher.SelectedIndex = index;
            listBoxPreisSummaFeuerloscher.SelectedIndex = index;
        }

        private void listBoxPreisSummaFeuerloscher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxPreisSummaFeuerloscher.SelectedIndex;
            listBoxFeuerlocher.SelectedIndex = index;
            listBoxLE.SelectedIndex = index;
            listBoxCountFeuerloescher.SelectedIndex = index;
            listBoxPreisSummaFeuerloscher.SelectedIndex = index;
        }

    }
}
