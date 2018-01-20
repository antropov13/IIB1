namespace GUI
{
    partial class FormRaumList
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
            this.listBoxRaum = new System.Windows.Forms.ListBox();
            this.buttonRaumDetail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxRaum
            // 
            this.listBoxRaum.FormattingEnabled = true;
            this.listBoxRaum.Location = new System.Drawing.Point(12, 42);
            this.listBoxRaum.Name = "listBoxRaum";
            this.listBoxRaum.Size = new System.Drawing.Size(153, 329);
            this.listBoxRaum.TabIndex = 0;
            // 
            // buttonRaumDetail
            // 
            this.buttonRaumDetail.Location = new System.Drawing.Point(171, 42);
            this.buttonRaumDetail.Name = "buttonRaumDetail";
            this.buttonRaumDetail.Size = new System.Drawing.Size(75, 23);
            this.buttonRaumDetail.TabIndex = 1;
            this.buttonRaumDetail.Text = "Details";
            this.buttonRaumDetail.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bitte wählen Sie einen Raum";
            // 
            // FormRaumList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 376);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRaumDetail);
            this.Controls.Add(this.listBoxRaum);
            this.Name = "FormRaumList";
            this.Text = "Die Liste der Räume";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRaum;
        private System.Windows.Forms.Button buttonRaumDetail;
        private System.Windows.Forms.Label label1;
    }
}