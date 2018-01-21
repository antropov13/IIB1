namespace GUI
{
    partial class FormFeuerloescher
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
            this.comboBoxBezeichnungFeuerloescher = new System.Windows.Forms.ComboBox();
            this.labelAnzahlFeuerloescher = new System.Windows.Forms.Label();
            this.buttonNeuerFeuerloescherSpeichern = new System.Windows.Forms.Button();
            this.textBoxGesamptpreisFeuerloscher = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLEFeuerloescher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarAnzahlFeuerloescher = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonabbrechen = new System.Windows.Forms.Button();
            this.textBoxLERaum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAnzahlFeuerloschen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGesamtLE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxBenoetigeLE = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonFeuerloescherloeschen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnzahlFeuerloescher)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxBezeichnungFeuerloescher
            // 
            this.comboBoxBezeichnungFeuerloescher.FormattingEnabled = true;
            this.comboBoxBezeichnungFeuerloescher.Location = new System.Drawing.Point(312, 12);
            this.comboBoxBezeichnungFeuerloescher.Name = "comboBoxBezeichnungFeuerloescher";
            this.comboBoxBezeichnungFeuerloescher.Size = new System.Drawing.Size(143, 21);
            this.comboBoxBezeichnungFeuerloescher.TabIndex = 0;
            this.comboBoxBezeichnungFeuerloescher.SelectedIndexChanged += new System.EventHandler(this.comboBoxBezeichnungFeuerloescher_SelectedIndexChanged);
            // 
            // labelAnzahlFeuerloescher
            // 
            this.labelAnzahlFeuerloescher.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelAnzahlFeuerloescher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAnzahlFeuerloescher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAnzahlFeuerloescher.Location = new System.Drawing.Point(280, 40);
            this.labelAnzahlFeuerloescher.Name = "labelAnzahlFeuerloescher";
            this.labelAnzahlFeuerloescher.Size = new System.Drawing.Size(26, 22);
            this.labelAnzahlFeuerloescher.TabIndex = 40;
            this.labelAnzahlFeuerloescher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNeuerFeuerloescherSpeichern
            // 
            this.buttonNeuerFeuerloescherSpeichern.Location = new System.Drawing.Point(60, 257);
            this.buttonNeuerFeuerloescherSpeichern.Name = "buttonNeuerFeuerloescherSpeichern";
            this.buttonNeuerFeuerloescherSpeichern.Size = new System.Drawing.Size(112, 42);
            this.buttonNeuerFeuerloescherSpeichern.TabIndex = 39;
            this.buttonNeuerFeuerloescherSpeichern.Text = "Neuer Feuerlöscher hinzufügen";
            this.buttonNeuerFeuerloescherSpeichern.UseVisualStyleBackColor = true;
            this.buttonNeuerFeuerloescherSpeichern.Click += new System.EventHandler(this.buttonNeuerFeuerloescherSpeichern_Click);
            // 
            // textBoxGesamptpreisFeuerloscher
            // 
            this.textBoxGesamptpreisFeuerloscher.Location = new System.Drawing.Point(312, 208);
            this.textBoxGesamptpreisFeuerloscher.Name = "textBoxGesamptpreisFeuerloscher";
            this.textBoxGesamptpreisFeuerloscher.ReadOnly = true;
            this.textBoxGesamptpreisFeuerloscher.Size = new System.Drawing.Size(143, 20);
            this.textBoxGesamptpreisFeuerloscher.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Preis ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Anzahl";
            // 
            // textBoxLEFeuerloescher
            // 
            this.textBoxLEFeuerloescher.Location = new System.Drawing.Point(312, 78);
            this.textBoxLEFeuerloescher.Name = "textBoxLEFeuerloescher";
            this.textBoxLEFeuerloescher.ReadOnly = true;
            this.textBoxLEFeuerloescher.Size = new System.Drawing.Size(143, 20);
            this.textBoxLEFeuerloescher.TabIndex = 35;
            this.textBoxLEFeuerloescher.TextChanged += new System.EventHandler(this.textBoxLEFeuerloescher_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Löschmitteleinheit des Feuerlöscher";
            // 
            // trackBarAnzahlFeuerloescher
            // 
            this.trackBarAnzahlFeuerloescher.Location = new System.Drawing.Point(312, 39);
            this.trackBarAnzahlFeuerloescher.Maximum = 30;
            this.trackBarAnzahlFeuerloescher.Minimum = 1;
            this.trackBarAnzahlFeuerloescher.Name = "trackBarAnzahlFeuerloescher";
            this.trackBarAnzahlFeuerloescher.Size = new System.Drawing.Size(143, 45);
            this.trackBarAnzahlFeuerloescher.TabIndex = 33;
            this.trackBarAnzahlFeuerloescher.Value = 1;
            this.trackBarAnzahlFeuerloescher.ValueChanged += new System.EventHandler(this.trackBarAnzahlFeuerloescher_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Bezeichnung";
            // 
            // buttonabbrechen
            // 
            this.buttonabbrechen.Location = new System.Drawing.Point(296, 257);
            this.buttonabbrechen.Name = "buttonabbrechen";
            this.buttonabbrechen.Size = new System.Drawing.Size(112, 42);
            this.buttonabbrechen.TabIndex = 41;
            this.buttonabbrechen.Text = "Schliessen";
            this.buttonabbrechen.UseVisualStyleBackColor = true;
            this.buttonabbrechen.Click += new System.EventHandler(this.buttonabbrechen_Click);
            // 
            // textBoxLERaum
            // 
            this.textBoxLERaum.Location = new System.Drawing.Point(312, 130);
            this.textBoxLERaum.Name = "textBoxLERaum";
            this.textBoxLERaum.ReadOnly = true;
            this.textBoxLERaum.Size = new System.Drawing.Size(143, 20);
            this.textBoxLERaum.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Benötigte Anzahl der Löschmitteleinheit für den Raum";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAnzahlFeuerloschen
            // 
            this.textBoxAnzahlFeuerloschen.Location = new System.Drawing.Point(312, 182);
            this.textBoxAnzahlFeuerloschen.Name = "textBoxAnzahlFeuerloschen";
            this.textBoxAnzahlFeuerloschen.ReadOnly = true;
            this.textBoxAnzahlFeuerloschen.Size = new System.Drawing.Size(143, 20);
            this.textBoxAnzahlFeuerloschen.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(230, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Gesamtanzahl den Feuerlöschern in dem Raum";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxGesamtLE
            // 
            this.textBoxGesamtLE.Location = new System.Drawing.Point(312, 156);
            this.textBoxGesamtLE.Name = "textBoxGesamtLE";
            this.textBoxGesamtLE.ReadOnly = true;
            this.textBoxGesamtLE.Size = new System.Drawing.Size(143, 20);
            this.textBoxGesamtLE.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Gesamtanzahl Löschmitteleinheit, die es gibt";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxBenoetigeLE
            // 
            this.textBoxBenoetigeLE.Location = new System.Drawing.Point(312, 104);
            this.textBoxBenoetigeLE.Name = "textBoxBenoetigeLE";
            this.textBoxBenoetigeLE.ReadOnly = true;
            this.textBoxBenoetigeLE.Size = new System.Drawing.Size(143, 20);
            this.textBoxBenoetigeLE.TabIndex = 49;
            this.textBoxBenoetigeLE.TextChanged += new System.EventHandler(this.textBoxBenoetigeLE_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Der Raum brauch noch Löschmitteleinheiten";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonFeuerloescherloeschen
            // 
            this.buttonFeuerloescherloeschen.Location = new System.Drawing.Point(178, 257);
            this.buttonFeuerloescherloeschen.Name = "buttonFeuerloescherloeschen";
            this.buttonFeuerloescherloeschen.Size = new System.Drawing.Size(112, 42);
            this.buttonFeuerloescherloeschen.TabIndex = 50;
            this.buttonFeuerloescherloeschen.Text = "Feuerlöscher löschen";
            this.buttonFeuerloescherloeschen.UseVisualStyleBackColor = true;
            this.buttonFeuerloescherloeschen.Click += new System.EventHandler(this.buttonFeuerloescherloeschen_Click);
            // 
            // FormFeuerloescher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 309);
            this.Controls.Add(this.buttonFeuerloescherloeschen);
            this.Controls.Add(this.textBoxBenoetigeLE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxGesamtLE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAnzahlFeuerloschen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxLERaum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonabbrechen);
            this.Controls.Add(this.labelAnzahlFeuerloescher);
            this.Controls.Add(this.buttonNeuerFeuerloescherSpeichern);
            this.Controls.Add(this.textBoxGesamptpreisFeuerloscher);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLEFeuerloescher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarAnzahlFeuerloescher);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxBezeichnungFeuerloescher);
            this.Name = "FormFeuerloescher";
            this.Text = "Neuer Feuerlöscher";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnzahlFeuerloescher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBezeichnungFeuerloescher;
        private System.Windows.Forms.Label labelAnzahlFeuerloescher;
        private System.Windows.Forms.Button buttonNeuerFeuerloescherSpeichern;
        private System.Windows.Forms.TextBox textBoxGesamptpreisFeuerloscher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLEFeuerloescher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarAnzahlFeuerloescher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonabbrechen;
        private System.Windows.Forms.TextBox textBoxLERaum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAnzahlFeuerloschen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGesamtLE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxBenoetigeLE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonFeuerloescherloeschen;
    }
}