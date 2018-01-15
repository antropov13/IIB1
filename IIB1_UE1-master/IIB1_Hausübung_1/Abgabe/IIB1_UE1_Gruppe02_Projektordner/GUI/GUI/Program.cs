using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using Klassen;


namespace GUI
{
    static class Program
    {
        private static BindingList<Raum> raeume = new BindingList<Raum>();
        private static BindingList<Feuerloescher> feuerlocherList = new BindingList<Feuerloescher>();
        private static BindingList<Material> materialien = new BindingList<Material>();
        static Random rd = new Random();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            createFeuerloecher(); //ListFeuerlöscher hinzufügen
            createRaume(); //Räume hinzufügen
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(raeume, feuerlocherList));
        }

        private static void createFeuerloecher()
        {
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "5A/21B", Loescheinheit = 1, Preis = 20 });
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "8A/34B", Loescheinheit = 2, Preis = 40 });
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "55B", Loescheinheit = 3, Preis = 60 });
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "13A/70B", Loescheinheit = 4, Preis = 80 });
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "89B", Loescheinheit = 5, Preis = 100 });
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "21A/113B", Loescheinheit = 6, Preis = 120 });
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "27A/144B", Loescheinheit = 9, Preis = 140 });
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "34A", Loescheinheit = 10, Preis = 160 });
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "43A / 183B", Loescheinheit = 12, Preis = 180 });
            feuerlocherList.Add(new Feuerloescher() { Bezeichnung = "55A/233B", Loescheinheit = 15, Preis = 200 });
        }


        private static BindingList<Feuerloescher> empfangFeuerlocher(int _anzahl)
        {
            //Der Raum bekommt Feuerlöschern
            BindingList<Feuerloescher> ffeuerlocherList = new BindingList<Feuerloescher>();
            Feuerloescher feuerloecher;
            for (int i=0; i<_anzahl; i++)
            {
                while (true)
                {
                    feuerloecher = feuerlocherList[rd.Next(1, feuerlocherList.Count)];
                    if (ffeuerlocherList.IndexOf(feuerloecher)==-1) {
                        feuerloecher.Anzahl = 1;
                        ffeuerlocherList.Add(feuerloecher);
                        break;
                    }
                }
            }
            return ffeuerlocherList;
        }

        private static void createRaume()
        {
            
            String name = "Raum ";
            for (int i=0; i<=4; i++)
            {
                //Fläche der Räume
                double bueroFlaeche = (rd.NextDouble() + 1) * rd.Next(30, 100);
                double flurFlaeche = (rd.NextDouble() + 1) * rd.Next(30, 100);
                double seminarraumFlaeche = (rd.NextDouble() + 1) * rd.Next(50, 100);
                double satinaerramFlaeche = (rd.NextDouble() + 1) * rd.Next(20, 70);

                //Bezeichnung der Räume
                String bezeichnungBueroRaum = name + rd.Next(1, 75).ToString() + "a";
                String bezeichnungFlurRaum = name + rd.Next(1, 75).ToString() + "b";
                String bezeichnungSeminarRaum = name + rd.Next(1, 75).ToString() + "c";
                String bezeichnunSanitaerRaum = name + rd.Next(1, 75).ToString() + "d";

                //Anzahl der Feuerlöschern der Räume
                int bueroFeuerloescherAnzahl = rd.Next(1, 5);
                int flurFeuerloescherAnzahl = rd.Next(1, 5);
                int seminarraumFeuerloescherAnzahl = rd.Next(1, 5);
                int sanitaerraumFeuerloescherAnzahl = rd.Next(1, 5);

                //ListFeuerlöschern für den Räume
                BindingList<Feuerloescher> bueroFeuerlocherListe = empfangFeuerlocher(bueroFeuerloescherAnzahl);
                BindingList<Feuerloescher> flurFeuerlocherListe = empfangFeuerlocher(flurFeuerloescherAnzahl);
                BindingList<Feuerloescher> seminarraumFeuerlocherListe = empfangFeuerlocher(seminarraumFeuerloescherAnzahl);
                BindingList<Feuerloescher> sanitaerraumFeuerlocherListe = empfangFeuerlocher(sanitaerraumFeuerloescherAnzahl);

                //Material der Räume
                Material bueroMaterial = new Material();
                Material flurMaterial = new Material();
                Material seminarraumMaterial = new Material();
                Material sanitaerraumMaterial = new Material();

                //Konstruktor der Räume aufrufen
                Buero buero = new Buero(bueroFlaeche, bezeichnungBueroRaum, bueroFeuerlocherListe, bueroMaterial);
                Flur flur = new Flur(flurFlaeche, bezeichnungFlurRaum, flurFeuerlocherListe, flurMaterial);
                Seminarraum seminarraum = new Seminarraum(seminarraumFlaeche, bezeichnungSeminarRaum, seminarraumFeuerlocherListe, seminarraumMaterial);
                Sanitaerraum sanitaerraum = new Sanitaerraum(satinaerramFlaeche, bezeichnunSanitaerRaum, sanitaerraumFeuerlocherListe, sanitaerraumMaterial);

                //Räume in ListRäume hinzufügen
                raeume.Add(buero);
                raeume.Add(flur);
                raeume.Add(seminarraum);
                raeume.Add(sanitaerraum);

            }

        }

    }
}
