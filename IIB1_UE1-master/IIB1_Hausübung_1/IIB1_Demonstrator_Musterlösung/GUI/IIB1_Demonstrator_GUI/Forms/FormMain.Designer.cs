namespace IIB1_Demonstrator_GUI.Forms
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
            this.components = new System.ComponentModel.Container();
            this.buttonSchliessen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelErgebnis = new System.Windows.Forms.Label();
            this.listBoxRaum = new System.Windows.Forms.ListBox();
            this.buttonAnalyse = new System.Windows.Forms.Button();
            this.buttonRaumDetails = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStripSpeichernLaden = new System.Windows.Forms.MenuStrip();
            this.speichernLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSpeichernLaden.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSchliessen
            // 
            this.buttonSchliessen.Location = new System.Drawing.Point(256, 243);
            this.buttonSchliessen.Name = "buttonSchliessen";
            this.buttonSchliessen.Size = new System.Drawing.Size(98, 23);
            this.buttonSchliessen.TabIndex = 1;
            this.buttonSchliessen.Text = "Schliessen";
            this.buttonSchliessen.UseVisualStyleBackColor = true;
            this.buttonSchliessen.Click += new System.EventHandler(this.buttonAbbrechen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bitte wählen Sie einen Raum";
            // 
            // labelErgebnis
            // 
            this.labelErgebnis.AutoSize = true;
            this.labelErgebnis.Location = new System.Drawing.Point(112, 59);
            this.labelErgebnis.Name = "labelErgebnis";
            this.labelErgebnis.Size = new System.Drawing.Size(0, 13);
            this.labelErgebnis.TabIndex = 3;
            // 
            // listBoxRaum
            // 
            this.listBoxRaum.FormattingEnabled = true;
            this.listBoxRaum.Location = new System.Drawing.Point(12, 59);
            this.listBoxRaum.Name = "listBoxRaum";
            this.listBoxRaum.Size = new System.Drawing.Size(238, 212);
            this.listBoxRaum.TabIndex = 4;
            this.listBoxRaum.DoubleClick += new System.EventHandler(this.buttonRaumDetails_Click);
            // 
            // buttonAnalyse
            // 
            this.buttonAnalyse.Location = new System.Drawing.Point(256, 195);
            this.buttonAnalyse.Name = "buttonAnalyse";
            this.buttonAnalyse.Size = new System.Drawing.Size(98, 42);
            this.buttonAnalyse.TabIndex = 1;
            this.buttonAnalyse.Text = "Analyse durchführen";
            this.buttonAnalyse.UseVisualStyleBackColor = true;
            this.buttonAnalyse.Click += new System.EventHandler(this.buttonAnalyse_Click);
            // 
            // buttonRaumDetails
            // 
            this.buttonRaumDetails.Location = new System.Drawing.Point(256, 167);
            this.buttonRaumDetails.Name = "buttonRaumDetails";
            this.buttonRaumDetails.Size = new System.Drawing.Size(98, 22);
            this.buttonRaumDetails.TabIndex = 1;
            this.buttonRaumDetails.Text = "Details";
            this.buttonRaumDetails.UseVisualStyleBackColor = true;
            this.buttonRaumDetails.Click += new System.EventHandler(this.buttonRaumDetails_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStripSpeichernLaden
            // 
            this.menuStripSpeichernLaden.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernLadenToolStripMenuItem});
            this.menuStripSpeichernLaden.Location = new System.Drawing.Point(0, 0);
            this.menuStripSpeichernLaden.Name = "menuStripSpeichernLaden";
            this.menuStripSpeichernLaden.Size = new System.Drawing.Size(369, 24);
            this.menuStripSpeichernLaden.TabIndex = 6;
            this.menuStripSpeichernLaden.Text = "menuStrip1";
            // 
            // speichernLadenToolStripMenuItem
            // 
            this.speichernLadenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernToolStripMenuItem,
            this.ladenToolStripMenuItem});
            this.speichernLadenToolStripMenuItem.Name = "speichernLadenToolStripMenuItem";
            this.speichernLadenToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.speichernLadenToolStripMenuItem.Text = "Speichern/Laden";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ladenToolStripMenuItem.Text = "Laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 280);
            this.Controls.Add(this.menuStripSpeichernLaden);
            this.Controls.Add(this.listBoxRaum);
            this.Controls.Add(this.labelErgebnis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRaumDetails);
            this.Controls.Add(this.buttonAnalyse);
            this.Controls.Add(this.buttonSchliessen);
            this.Name = "FormMain";
            this.Text = "Willkommen bei der Belichtungsanalyse";
            this.menuStripSpeichernLaden.ResumeLayout(false);
            this.menuStripSpeichernLaden.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSchliessen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelErgebnis;
        private System.Windows.Forms.ListBox listBoxRaum;
        private System.Windows.Forms.Button buttonAnalyse;
        private System.Windows.Forms.Button buttonRaumDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStripSpeichernLaden;
        private System.Windows.Forms.ToolStripMenuItem speichernLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
    }
}