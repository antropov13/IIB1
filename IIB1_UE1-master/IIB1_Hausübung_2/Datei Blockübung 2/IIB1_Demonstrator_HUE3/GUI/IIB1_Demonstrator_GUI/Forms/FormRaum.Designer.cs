namespace IIB1_Demonstrator_GUI.Forms
{
    partial class FormRaum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRaumNummer = new System.Windows.Forms.TextBox();
            this.textBoxRaumFlaeche = new System.Windows.Forms.TextBox();
            this.textBoxGrenzwert = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFensterFlaeche = new System.Windows.Forms.TextBox();
            this.comboBoxRaumTyp = new System.Windows.Forms.ComboBox();
            this.textBoxRatio = new System.Windows.Forms.TextBox();
            this.listBoxFenster = new System.Windows.Forms.ListBox();
            this.buttonFensterDetail = new System.Windows.Forms.Button();
            this.buttonFensterLoeschen = new System.Windows.Forms.Button();
            this.buttonFensterNeu = new System.Windows.Forms.Button();
            this.buttonZurueck = new System.Windows.Forms.Button();
            this.buttonSpeichern = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nutzungsart";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Raumflaeche [m²]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Raumnummer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Grenzwert";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Verhältnis Fensterfläche zu Raumfläche";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fenster";
            // 
            // textBoxRaumNummer
            // 
            this.textBoxRaumNummer.Location = new System.Drawing.Point(172, 12);
            this.textBoxRaumNummer.Name = "textBoxRaumNummer";
            this.textBoxRaumNummer.Size = new System.Drawing.Size(100, 20);
            this.textBoxRaumNummer.TabIndex = 1;
            // 
            // textBoxRaumFlaeche
            // 
            this.textBoxRaumFlaeche.Location = new System.Drawing.Point(172, 38);
            this.textBoxRaumFlaeche.Name = "textBoxRaumFlaeche";
            this.textBoxRaumFlaeche.ReadOnly = true;
            this.textBoxRaumFlaeche.Size = new System.Drawing.Size(100, 20);
            this.textBoxRaumFlaeche.TabIndex = 1;
            // 
            // textBoxGrenzwert
            // 
            this.textBoxGrenzwert.Location = new System.Drawing.Point(172, 121);
            this.textBoxGrenzwert.Name = "textBoxGrenzwert";
            this.textBoxGrenzwert.Size = new System.Drawing.Size(100, 20);
            this.textBoxGrenzwert.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fensterflaeche [m²]";
            // 
            // textBoxFensterFlaeche
            // 
            this.textBoxFensterFlaeche.Location = new System.Drawing.Point(172, 64);
            this.textBoxFensterFlaeche.Name = "textBoxFensterFlaeche";
            this.textBoxFensterFlaeche.ReadOnly = true;
            this.textBoxFensterFlaeche.Size = new System.Drawing.Size(100, 20);
            this.textBoxFensterFlaeche.TabIndex = 1;
            // 
            // comboBoxRaumTyp
            // 
            this.comboBoxRaumTyp.FormattingEnabled = true;
            this.comboBoxRaumTyp.Items.AddRange(new object[] {
            "Büro",
            "Wohnen"});
            this.comboBoxRaumTyp.Location = new System.Drawing.Point(172, 91);
            this.comboBoxRaumTyp.Name = "comboBoxRaumTyp";
            this.comboBoxRaumTyp.Size = new System.Drawing.Size(100, 21);
            this.comboBoxRaumTyp.TabIndex = 2;
            // 
            // textBoxRatio
            // 
            this.textBoxRatio.Location = new System.Drawing.Point(172, 173);
            this.textBoxRatio.Name = "textBoxRatio";
            this.textBoxRatio.ReadOnly = true;
            this.textBoxRatio.Size = new System.Drawing.Size(100, 20);
            this.textBoxRatio.TabIndex = 3;
            // 
            // listBoxFenster
            // 
            this.listBoxFenster.FormattingEnabled = true;
            this.listBoxFenster.Location = new System.Drawing.Point(15, 251);
            this.listBoxFenster.Name = "listBoxFenster";
            this.listBoxFenster.Size = new System.Drawing.Size(143, 121);
            this.listBoxFenster.TabIndex = 4;
            this.listBoxFenster.DoubleClick += new System.EventHandler(this.buttonFensterDetail_Click);
            // 
            // buttonFensterDetail
            // 
            this.buttonFensterDetail.Location = new System.Drawing.Point(172, 250);
            this.buttonFensterDetail.Name = "buttonFensterDetail";
            this.buttonFensterDetail.Size = new System.Drawing.Size(100, 23);
            this.buttonFensterDetail.TabIndex = 5;
            this.buttonFensterDetail.Text = "Details";
            this.buttonFensterDetail.UseVisualStyleBackColor = true;
            this.buttonFensterDetail.Click += new System.EventHandler(this.buttonFensterDetail_Click);
            // 
            // buttonFensterLoeschen
            // 
            this.buttonFensterLoeschen.Location = new System.Drawing.Point(172, 279);
            this.buttonFensterLoeschen.Name = "buttonFensterLoeschen";
            this.buttonFensterLoeschen.Size = new System.Drawing.Size(100, 23);
            this.buttonFensterLoeschen.TabIndex = 5;
            this.buttonFensterLoeschen.Text = "Fenster löschen";
            this.buttonFensterLoeschen.UseVisualStyleBackColor = true;
            this.buttonFensterLoeschen.Click += new System.EventHandler(this.buttonFensterLoeschen_Click);
            // 
            // buttonFensterNeu
            // 
            this.buttonFensterNeu.Location = new System.Drawing.Point(172, 308);
            this.buttonFensterNeu.Name = "buttonFensterNeu";
            this.buttonFensterNeu.Size = new System.Drawing.Size(100, 35);
            this.buttonFensterNeu.TabIndex = 5;
            this.buttonFensterNeu.Text = "Neues Fenster hinzufügen";
            this.buttonFensterNeu.UseVisualStyleBackColor = true;
            this.buttonFensterNeu.Click += new System.EventHandler(this.buttonFensterNeu_Click);
            // 
            // buttonZurueck
            // 
            this.buttonZurueck.Location = new System.Drawing.Point(172, 349);
            this.buttonZurueck.Name = "buttonZurueck";
            this.buttonZurueck.Size = new System.Drawing.Size(100, 23);
            this.buttonZurueck.TabIndex = 5;
            this.buttonZurueck.Text = "Zurück";
            this.buttonZurueck.UseVisualStyleBackColor = true;
            this.buttonZurueck.Click += new System.EventHandler(this.buttonZurueck_Click);
            // 
            // buttonSpeichern
            // 
            this.buttonSpeichern.Location = new System.Drawing.Point(15, 199);
            this.buttonSpeichern.Name = "buttonSpeichern";
            this.buttonSpeichern.Size = new System.Drawing.Size(257, 23);
            this.buttonSpeichern.TabIndex = 6;
            this.buttonSpeichern.Text = "Änderungen Speichern";
            this.buttonSpeichern.UseVisualStyleBackColor = true;
            this.buttonSpeichern.Click += new System.EventHandler(this.buttonSpeichern_Click);
            // 
            // FormRaum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 382);
            this.Controls.Add(this.buttonSpeichern);
            this.Controls.Add(this.buttonFensterNeu);
            this.Controls.Add(this.buttonZurueck);
            this.Controls.Add(this.buttonFensterLoeschen);
            this.Controls.Add(this.buttonFensterDetail);
            this.Controls.Add(this.listBoxFenster);
            this.Controls.Add(this.textBoxRatio);
            this.Controls.Add(this.comboBoxRaumTyp);
            this.Controls.Add(this.textBoxGrenzwert);
            this.Controls.Add(this.textBoxFensterFlaeche);
            this.Controls.Add(this.textBoxRaumFlaeche);
            this.Controls.Add(this.textBoxRaumNummer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "FormRaum";
            this.Text = "Raum Detailansicht";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRaumNummer;
        private System.Windows.Forms.TextBox textBoxRaumFlaeche;
        private System.Windows.Forms.TextBox textBoxGrenzwert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxFensterFlaeche;
        private System.Windows.Forms.ComboBox comboBoxRaumTyp;
        private System.Windows.Forms.TextBox textBoxRatio;
        private System.Windows.Forms.ListBox listBoxFenster;
        private System.Windows.Forms.Button buttonFensterDetail;
        private System.Windows.Forms.Button buttonFensterLoeschen;
        private System.Windows.Forms.Button buttonFensterNeu;
        private System.Windows.Forms.Button buttonZurueck;
        private System.Windows.Forms.Button buttonSpeichern;
    }
}