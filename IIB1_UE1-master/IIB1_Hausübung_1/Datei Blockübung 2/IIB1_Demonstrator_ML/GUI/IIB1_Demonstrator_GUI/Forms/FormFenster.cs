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
    public partial class FormFenster : Form
    {
        private Fenster f;
        public FormRaum owner;
        private bool neuesFenster = false;
        private List<String> fensterTypen;

        public FormFenster(Fenster _f, List<String> _fensterTypen)
        {
            InitializeComponent();
            if (_f != null)
                this.f = _f;
            else
            {
                this.f = new Fenster();
                neuesFenster = true;
            }
            this.fensterTypen = _fensterTypen;
            fuelleBoxen();
        }
        
        private void fuelleBoxen()
        {
            textBoxBezeichnung.Text = f.Bezeichung;
            textBoxFlaeche.Text = Math.Round(f.Flaeche,2).ToString();
            comboBoxTyp.DataSource = fensterTypen;
            comboBoxTyp.SelectedItem = f.Typ;
        }

        private void buttonSpeichern_Click(object sender, EventArgs e)
        {
            f.Bezeichung = textBoxBezeichnung.Text;
            f.Flaeche = Double.Parse(textBoxFlaeche.Text);
            f.Typ = comboBoxTyp.SelectedItem.ToString();
            if (neuesFenster)
                owner.fensterHinzu(f);
            else
                owner.fensterAendern(f);
            this.Close();

        }

        private void buttonAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
