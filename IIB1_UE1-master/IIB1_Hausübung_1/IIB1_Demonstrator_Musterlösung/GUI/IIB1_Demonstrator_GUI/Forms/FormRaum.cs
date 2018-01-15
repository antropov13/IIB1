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

namespace IIB1_Demonstrator_GUI.Forms
{
    public partial class FormRaum : Form
    {
        private Raum r;
        private List<String> fensterTypen;
        public FormRaum(Raum _r, List<String> _fensterTypen, FormMain _parent)
        {
            InitializeComponent();
            this.r = _r;
            this.fensterTypen = _fensterTypen;
            this.Owner = _parent;
            fuelleBoxen();
        }

        private void fuelleBoxen()
        {
            textBoxRaumNummer.Text = r.RaumNummer;
            textBoxRaumFlaeche.Text = Math.Round(r.Flaeche, 2).ToString();
            textBoxRatio.Text = Math.Round(r.berechneRatio(), 2).ToString();
            textBoxGrenzwert.Text = Math.Round(r.GrenzwertRatio, 2).ToString();
            textBoxFensterFlaeche.Text = Math.Round(r.fensterFlaeche(), 2).ToString();
            int art = 0;
            if (r is Wohnen)
                art = 1;
            comboBoxRaumTyp.SelectedIndex = art;
            listBoxFenster.DataSource = r.FensterListe;
            listBoxFenster.DisplayMember = "Bezeichung";
        }
        
        private void buttonFensterDetail_Click(object sender, EventArgs e)
        {
            rufeFormFensterAuf(f:(Fenster)listBoxFenster.SelectedItem);
        }

        private void buttonFensterLoeschen_Click(object sender, EventArgs e)
        {
            r.entferneFenster((Fenster)listBoxFenster.SelectedItem);
            ((FormMain)Owner).raumAenderung(r);
            fuelleBoxen();
        }

        private void buttonFensterNeu_Click(object sender, EventArgs e)
        {
            rufeFormFensterAuf();
        }

        private void rufeFormFensterAuf(Fenster f = null)
        {
            FormFenster fFenster = new FormFenster(f, fensterTypen);
            fFenster.owner = this;
            fFenster.ShowDialog();
        }
        
        private void buttonZurueck_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void fensterHinzu(Fenster f)
        {
            r.FensterHinzu(f);
            ((FormMain)Owner).raumAenderung(r);
            fuelleBoxen();
        }

        public void fensterAendern(Fenster f)
        {
            r.entferneFenster((Fenster)listBoxFenster.SelectedItem);
            r.FensterHinzu(f);
            ((FormMain)Owner).raumAenderung(r);
            fuelleBoxen();
        }

        private void buttonSpeichern_Click(object sender, EventArgs e)
        {
            r.RaumNummer = textBoxRaumNummer.Text;
            r.GrenzwertRatio = Double.Parse(textBoxGrenzwert.Text);
            int art = 0;
            if (r is Wohnen)
                art = 1;
            Raum neuerRaum = new Raum();
            if (comboBoxRaumTyp.SelectedIndex != art)
            {
                if (r is Wohnen)
                    neuerRaum = new Buero(r);
                else
                    neuerRaum = new Wohnen(r);
                r = neuerRaum;
            }
            ((FormMain)Owner).raumAenderung(r);
        }
    }
}
