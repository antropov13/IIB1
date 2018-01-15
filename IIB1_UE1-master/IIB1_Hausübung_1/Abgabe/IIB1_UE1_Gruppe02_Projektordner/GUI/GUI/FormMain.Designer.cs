namespace GUI
{
    partial class FormMain
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
            this.listBoxRaum = new System.Windows.Forms.ListBox();
            this.buttonRaumDetail = new System.Windows.Forms.Button();
            this.comboBoxTypRaum = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.speihernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonabbrechen = new System.Windows.Forms.Button();
            this.buttonLoeschenRaum = new System.Windows.Forms.Button();
            this.buttonErstellenRaum = new System.Windows.Forms.Button();
            this.labelGesamptpreis = new System.Windows.Forms.Label();
            this.textBoxGesamptpreis = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bitte wählen Sie einen Raum";
            // 
            // listBoxRaum
            // 
            this.listBoxRaum.ForeColor = System.Drawing.Color.Black;
            this.listBoxRaum.FormattingEnabled = true;
            this.listBoxRaum.Location = new System.Drawing.Point(15, 79);
            this.listBoxRaum.Name = "listBoxRaum";
            this.listBoxRaum.Size = new System.Drawing.Size(227, 290);
            this.listBoxRaum.TabIndex = 6;
            this.listBoxRaum.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxRaum_DrawItem);
            this.listBoxRaum.DoubleClick += new System.EventHandler(this.buttonRaumDetail_Click);
            // 
            // buttonRaumDetail
            // 
            this.buttonRaumDetail.Location = new System.Drawing.Point(248, 79);
            this.buttonRaumDetail.Name = "buttonRaumDetail";
            this.buttonRaumDetail.Size = new System.Drawing.Size(119, 23);
            this.buttonRaumDetail.TabIndex = 7;
            this.buttonRaumDetail.Text = "Details";
            this.buttonRaumDetail.UseVisualStyleBackColor = true;
            this.buttonRaumDetail.Click += new System.EventHandler(this.buttonRaumDetail_Click);
            // 
            // comboBoxTypRaum
            // 
            this.comboBoxTypRaum.FormattingEnabled = true;
            this.comboBoxTypRaum.Location = new System.Drawing.Point(15, 52);
            this.comboBoxTypRaum.Name = "comboBoxTypRaum";
            this.comboBoxTypRaum.Size = new System.Drawing.Size(227, 21);
            this.comboBoxTypRaum.TabIndex = 8;
            this.comboBoxTypRaum.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypRaum_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernToolStripMenuItem,
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(379, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernToolStripMenuItem1,
            this.ladenToolStripMenuItem1});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // speichernToolStripMenuItem1
            // 
            this.speichernToolStripMenuItem1.Name = "speichernToolStripMenuItem1";
            this.speichernToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.speichernToolStripMenuItem1.Text = "Speichern";
            this.speichernToolStripMenuItem1.Click += new System.EventHandler(this.speichernToolStripMenuItem1_Click);
            // 
            // ladenToolStripMenuItem1
            // 
            this.ladenToolStripMenuItem1.Name = "ladenToolStripMenuItem1";
            this.ladenToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.ladenToolStripMenuItem1.Text = "Laden";
            this.ladenToolStripMenuItem1.Click += new System.EventHandler(this.ladenToolStripMenuItem1_Click);
            // 
            // speihernToolStripMenuItem
            // 
            this.speihernToolStripMenuItem.Name = "speihernToolStripMenuItem";
            this.speihernToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // buttonabbrechen
            // 
            this.buttonabbrechen.Location = new System.Drawing.Point(248, 346);
            this.buttonabbrechen.Name = "buttonabbrechen";
            this.buttonabbrechen.Size = new System.Drawing.Size(119, 23);
            this.buttonabbrechen.TabIndex = 10;
            this.buttonabbrechen.Text = "Schliessen";
            this.buttonabbrechen.UseVisualStyleBackColor = true;
            this.buttonabbrechen.Click += new System.EventHandler(this.buttonabbrechen_Click);
            // 
            // buttonLoeschenRaum
            // 
            this.buttonLoeschenRaum.Location = new System.Drawing.Point(248, 137);
            this.buttonLoeschenRaum.Name = "buttonLoeschenRaum";
            this.buttonLoeschenRaum.Size = new System.Drawing.Size(119, 23);
            this.buttonLoeschenRaum.TabIndex = 11;
            this.buttonLoeschenRaum.Text = "Löschen";
            this.buttonLoeschenRaum.UseVisualStyleBackColor = true;
            this.buttonLoeschenRaum.Click += new System.EventHandler(this.buttonLoeschenRaum_Click);
            // 
            // buttonErstellenRaum
            // 
            this.buttonErstellenRaum.Location = new System.Drawing.Point(248, 108);
            this.buttonErstellenRaum.Name = "buttonErstellenRaum";
            this.buttonErstellenRaum.Size = new System.Drawing.Size(119, 23);
            this.buttonErstellenRaum.TabIndex = 12;
            this.buttonErstellenRaum.Text = "Erstellen";
            this.buttonErstellenRaum.UseVisualStyleBackColor = true;
            this.buttonErstellenRaum.Click += new System.EventHandler(this.buttonErstellenRaum_Click);
            // 
            // labelGesamptpreis
            // 
            this.labelGesamptpreis.Location = new System.Drawing.Point(248, 172);
            this.labelGesamptpreis.Name = "labelGesamptpreis";
            this.labelGesamptpreis.Size = new System.Drawing.Size(119, 60);
            this.labelGesamptpreis.TabIndex = 13;
            this.labelGesamptpreis.Text = "label2";
            this.labelGesamptpreis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxGesamptpreis
            // 
            this.textBoxGesamptpreis.Location = new System.Drawing.Point(248, 235);
            this.textBoxGesamptpreis.Name = "textBoxGesamptpreis";
            this.textBoxGesamptpreis.ReadOnly = true;
            this.textBoxGesamptpreis.Size = new System.Drawing.Size(119, 20);
            this.textBoxGesamptpreis.TabIndex = 14;
            this.textBoxGesamptpreis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 383);
            this.Controls.Add(this.textBoxGesamptpreis);
            this.Controls.Add(this.labelGesamptpreis);
            this.Controls.Add(this.buttonErstellenRaum);
            this.Controls.Add(this.buttonLoeschenRaum);
            this.Controls.Add(this.buttonabbrechen);
            this.Controls.Add(this.comboBoxTypRaum);
            this.Controls.Add(this.buttonRaumDetail);
            this.Controls.Add(this.listBoxRaum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Willkommen bei der Brandschutzplanung";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxRaum;
        private System.Windows.Forms.Button buttonRaumDetail;
        private System.Windows.Forms.ComboBox comboBoxTypRaum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speihernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem1;
        private System.Windows.Forms.Button buttonabbrechen;
        private System.Windows.Forms.Button buttonLoeschenRaum;
        private System.Windows.Forms.Button buttonErstellenRaum;
        private System.Windows.Forms.Label labelGesamptpreis;
        private System.Windows.Forms.TextBox textBoxGesamptpreis;
    }
}

