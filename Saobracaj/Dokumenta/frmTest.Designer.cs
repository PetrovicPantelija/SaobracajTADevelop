namespace Saobracaj.Dokumenta
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Stanica = new System.Windows.Forms.Button();
            this.combo_Stanice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_Stanica);
            this.panel1.Controls.Add(this.combo_Stanice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 1055);
            this.panel1.TabIndex = 0;
            // 
            // btn_Stanica
            // 
            this.btn_Stanica.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Stanica.Location = new System.Drawing.Point(253, 45);
            this.btn_Stanica.Name = "btn_Stanica";
            this.btn_Stanica.Size = new System.Drawing.Size(136, 37);
            this.btn_Stanica.TabIndex = 172;
            this.btn_Stanica.Text = "Prikaži stanice";
            this.btn_Stanica.UseVisualStyleBackColor = false;
            this.btn_Stanica.Click += new System.EventHandler(this.btn_Stanica_Click);
            // 
            // combo_Stanice
            // 
            this.combo_Stanice.BackColor = System.Drawing.SystemColors.Control;
            this.combo_Stanice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Stanice.FormattingEnabled = true;
            this.combo_Stanice.Location = new System.Drawing.Point(4, 49);
            this.combo_Stanice.Name = "combo_Stanice";
            this.combo_Stanice.Size = new System.Drawing.Size(229, 28);
            this.combo_Stanice.TabIndex = 1;
            this.combo_Stanice.TextChanged += new System.EventHandler(this.combo_Stanice_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stanice";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1661, 1055);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox combo_Stanice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Stanica;
    }
}