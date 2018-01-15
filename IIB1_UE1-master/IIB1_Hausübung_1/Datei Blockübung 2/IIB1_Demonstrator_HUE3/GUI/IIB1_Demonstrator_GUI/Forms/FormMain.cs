using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IIB1_Demonstrator.Klassen;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Autodesk.Revit.UI;

namespace IIB1_Demonstrator_GUI.Forms
{
    public partial class FormMain : Form
    {
        private BindingList<Raum> raeume;
        private ExternalEvent ex_updateEvent;
        private ExternalEvent ex_lampenEvent;

        public BindingList<Raum> Raeume { get { return raeume; } }

        public FormMain(ExternalEvent update, ExternalEvent lampen, BindingList<Raum> _raeume)
        {
            this.ex_updateEvent = update;
            this.ex_lampenEvent = lampen;
            InitializeComponent();
            this.raeume = _raeume;
            fuelleListe();
        }

        private void fuelleListe()
        {
            listBoxRaum.DataSource = raeume;
            listBoxRaum.DisplayMember = "RaumName";
        }

        private void buttonAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRaumDetails_Click(object sender, EventArgs e)
        {
            FormRaum fRaum = new FormRaum((Raum)listBoxRaum.SelectedItem, getAlleFensterTypen(), this);
            fRaum.ShowDialog();
        }

        public void raumAenderung(Raum r)
        {
            raeume.Remove((Raum)listBoxRaum.SelectedItem);
            raeume.Add(r);
            listBoxRaum.SelectedItem = r;
        }

        private List<String> getAlleFensterTypen()
        {
            List<String> re = new List<string>();
            foreach (Raum r in raeume)
            {
                foreach (Fenster f in r.FensterListe)
                {
                    if (!re.Contains(f.Typ))
                        re.Add(f.Typ);
                }
            }
            return re;
        }

        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            String kritischeRaeume = "";
            foreach (Raum r in raeume)
            {
                if (r.grenzwertUnterschritten())
                {
                    kritischeRaeume += r.RaumName + ", ";
                }
            }
            MessageBox.Show("Grenzwert wurde in folgenden Räumen nicht 				eingehalten: " + kritischeRaeume, "Warnung!");
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, raeume);
                fs.Close();
            }
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                raeume = (BindingList<Raum>)bf.Deserialize(fs);
                fuelleListe();
                fs.Close();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //TODO: Daten in Revit übergeben
        }

        private void buttonLampen_Click(object sender, EventArgs e)
        {
            //TODO: Lampen platzieren
        }
    }
}
