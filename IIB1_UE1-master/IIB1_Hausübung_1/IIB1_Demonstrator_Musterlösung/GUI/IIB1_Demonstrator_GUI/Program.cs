using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IIB1_Demonstrator_GUI.Forms;
using System.ComponentModel;
using IIB1_Demonstrator.Klassen;

namespace IIB1_Demonstrator_GUI
{
    static class Program
    {

        private static BindingList<Raum> meineRaeume = new BindingList<Raum>();
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bspRaeume();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(meineRaeume));
        }

        private static void bspRaeume()
        {
            Random rd = new Random();
            for (int i=0; i < 4; i++)
            {
                double bFlaeche = rd.NextDouble() * rd.Next(50,100);
                double wFlaeche = rd.NextDouble() * rd.Next(50, 100);
                String bNummer = rd.Next(1, 75).ToString()+"a";
                String wNummer = rd.Next(1, 75).ToString()+"b";
                int bFenster = rd.Next(1, 5);
                int wFenster = rd.Next(1, 5);
                BindingList<Fenster> bFensterListe = new BindingList<Fenster>();
                BindingList<Fenster> wFensterListe = new BindingList<Fenster>();
                for (int j =0; j < bFenster; j++)
                {
                    String fBez = j + "";
                    double fFlaeche = rd.NextDouble() * 2;
                    String typ = "test";
                    bFensterListe.Add(new Fenster(fFlaeche, fBez, typ));
                }
                for(int j=0; j<wFenster; j++)
                {
                    String fBez = j + "";
                    double fFlaeche = rd.NextDouble() * 2;
                    String typ = "test";
                    wFensterListe.Add(new Fenster(fFlaeche, fBez, typ));
                }
                Buero b = new Buero(bFlaeche,bNummer,bFensterListe);
                Wohnen w = new Wohnen(wFlaeche, wNummer, wFensterListe);
                meineRaeume.Add(b);
                meineRaeume.Add(w);
            }
        }
    }
}
