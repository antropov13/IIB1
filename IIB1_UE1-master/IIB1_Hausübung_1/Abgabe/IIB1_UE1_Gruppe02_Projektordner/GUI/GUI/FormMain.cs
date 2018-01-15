using Klassen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormMain : Form
    {
        private BindingList<Raum> raeume;
        private BindingList<Feuerloescher> feuerloescherList;
        private listBoxRaumItems item;
        public FormMain(BindingList<Raum> _raeume, BindingList<Feuerloescher> _feuerloescherList)
        {
            InitializeComponent();
            this.raeume = _raeume;
            this.feuerloescherList = _feuerloescherList;
            fuelleListe();
        }

        //Die Boxen werden gefüllt
        private void fuelleListe()
        {
            //In comboBox alle Räume oder abhähgig von Nutzungsart
            comboBoxTypRaum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            if (comboBoxTypRaum.Items.IndexOf("Alle") == -1)
                comboBoxTypRaum.Items.Add("Alle");

            foreach (Raum r in raeume)
            {
                if (comboBoxTypRaum.Items.IndexOf(r.TypRaume) == -1)
                    comboBoxTypRaum.Items.Add(r.TypRaume);
            }

            comboBoxTypRaum.SelectedIndex = 0;    
            
        }

        public void raumErstellen(Raum raum)
        {
            //Neuer Raum hinzufügen
            raeume.Add(raum);
            comboBoxTypRaum.SelectedItem = raum.TypRaume;
            listBoxUpdate();
            listBoxRaum.SelectedIndex = listBoxRaum.Items.Count - 1;
            item = listBoxRaum.Items[listBoxRaum.SelectedIndex] as listBoxRaumItems;
            FormRaum formRaum = new FormRaum(item.Raum, feuerloescherList, this);
            formRaum.ShowDialog();
        }

        public void raumAenderung(Raum raum)
        {
            //Raum wird ändert
            item = listBoxRaum.Items[listBoxRaum.SelectedIndex] as listBoxRaumItems;
            raeume.Remove(item.Raum);
            raeume.Add(raum);
            comboBoxTypRaum.SelectedItem = raum.TypRaume;
            listBoxUpdate();
            listBoxRaum.SelectedIndex = listBoxRaum.Items.Count - 1;
        }


        private void listBoxRaum_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            item = listBoxRaum.Items[e.Index] as listBoxRaumItems;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Cyan);

            e.DrawBackground();
            e.Graphics.DrawString(item.Raum.Bezeichung, e.Font, new SolidBrush(item.RaumColor), new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }
        private void listBoxUpdate()
        {
            //Aktulisierung ListBox mit deb Räume
            listBoxRaum.Items.Clear();
            listBoxRaum.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxRaum.DrawItem += listBoxRaum_DrawItem;

            
            String typ = (String)comboBoxTypRaum.SelectedItem;
            double gesamptpreis = 0;
            if (typ.Equals("Alle"))
            {
                foreach (Raum r in raeume)
                {
                    int LEFeurloescher = 0;
                    foreach(Feuerloescher f in r.FeuerloescherList)
                    {
                        LEFeurloescher += f.Anzahl * f.Loescheinheit;
                        gesamptpreis += f.Anzahl * f.Preis; //Gesamptpreis Brandschutzplanung für alle Räume
                    }
                    if (LEFeurloescher>=r.Loeschmitteleinheiten) //Die Farbe für Raum abhängig von Branschutzplanung (Grün oder Red)
                        listBoxRaum.Items.Add(new listBoxRaumItems(Color.Green, r));
                    else listBoxRaum.Items.Add(new listBoxRaumItems(Color.Red, r));
                }

                labelGesamptpreis.Text = "Gesamtpreis der Feuerlöscher für alle Räume";
                textBoxGesamptpreis.Text = Convert.ToString(gesamptpreis);
            }

            else
            {
                foreach (Raum r in raeume)
                {

                    if (r.TypRaume.Equals(typ))
                    {
                    int LEFeurloescher = 0;
                    foreach(Feuerloescher f in r.FeuerloescherList)
                    {
                        LEFeurloescher += f.Anzahl * f.Loescheinheit;
                        gesamptpreis += f.Anzahl * f.Preis; //Gesamptpreis Brandschutzplanung abhängig von Nutzungsart
                    }
                    if (LEFeurloescher>=r.Loeschmitteleinheiten) //Die Farbe für Raum abhängig von Branschutzplanung (Grün oder Red)
                        listBoxRaum.Items.Add(new listBoxRaumItems(Color.Green, r));
                    else listBoxRaum.Items.Add(new listBoxRaumItems(Color.Red, r));
                    }
                }

                labelGesamptpreis.Text = "Gesamtpreis der Feuerlöscher für die Räume mit der Nutzungsart " + typ;
                textBoxGesamptpreis.Text = Convert.ToString(gesamptpreis);
            }

            if (listBoxRaum.Items.Count > 0)
            { 
                listBoxRaum.SelectedIndex = 0;
                buttonRaumDetail.Enabled = true;
                buttonLoeschenRaum.Enabled = true;
            }
            else
            {
                buttonRaumDetail.Enabled = false;
                buttonLoeschenRaum.Enabled = false;
            }
            
        }
        private void comboBoxTypRaum_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxUpdate();
        }

        private void buttonRaumDetail_Click(object sender, EventArgs e)
        {
            //FormRaum - Details Raum
            item = listBoxRaum.Items[listBoxRaum.SelectedIndex] as listBoxRaumItems;
            FormRaum formRaum = new FormRaum(item.Raum, feuerloescherList, this);
            formRaum.ShowDialog();
        }

        private void buttonErstellenRaum_Click(object sender, EventArgs e)
        {
            //FormNeuerRaum - Neuer Raum hinzufügen
            FormNeuerRaum formNeuerRaum = new FormNeuerRaum(comboBoxTypRaum.SelectedIndex - 1, this);
            formNeuerRaum.ShowDialog();
        }

        private void speichernToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Menu speichern Datei
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, raeume);
                fs.Close();
            }
        }

        private void ladenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Menu laden Datei
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                raeume = (BindingList<Raum>)bf.Deserialize(fs);
                fuelleListe();
                fs.Close();
            }
            listBoxUpdate();
        }

        public double returnHeizwert(String typ)
        {
            //Die Funktion für die Rückgabe Heizwert des Raum
            double heizwert = 0;
            foreach (Raum r in raeume)
            {
                if (r.TypRaume.Equals(typ))
                {
                    heizwert = r.Heizwert;
                    break;
                }
            }
            return heizwert;
        }

        private void buttonLoeschenRaum_Click(object sender, EventArgs e)
        {
            //Raum löschen
            item = listBoxRaum.Items[listBoxRaum.SelectedIndex] as listBoxRaumItems;
            raeume.Remove(item.Raum);
            listBoxUpdate();
        }

        private void buttonabbrechen_Click(object sender, EventArgs e)
        {
            //Form schliessen
            this.Close();
        }
    }
}
