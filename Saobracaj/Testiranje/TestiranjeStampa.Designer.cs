
namespace Saobracaj.Testiranje
{
    partial class TestiranjeStampa
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGrupaTesta = new System.Windows.Forms.ComboBox();
            this.sfButton1 = new Syncfusion.WinForms.Controls.SfButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboKorisnik = new System.Windows.Forms.ComboBox();
            this.sfButton2 = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Saobracaj.Izvestaji.Najava.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 65);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(776, 373);
            this.reportViewer1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 167;
            this.label3.Text = "Grupa testa:";
            // 
            // cboGrupaTesta
            // 
            this.cboGrupaTesta.BackColor = System.Drawing.Color.White;
            this.cboGrupaTesta.FormattingEnabled = true;
            this.cboGrupaTesta.Location = new System.Drawing.Point(12, 27);
            this.cboGrupaTesta.Name = "cboGrupaTesta";
            this.cboGrupaTesta.Size = new System.Drawing.Size(191, 21);
            this.cboGrupaTesta.TabIndex = 166;
            // 
            // sfButton1
            // 
            this.sfButton1.AccessibleName = "Button";
            this.sfButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton1.Location = new System.Drawing.Point(433, 20);
            this.sfButton1.Name = "sfButton1";
            this.sfButton1.Size = new System.Drawing.Size(107, 28);
            this.sfButton1.TabIndex = 168;
            this.sfButton1.Text = "Štampaj rezultat";
            this.sfButton1.Click += new System.EventHandler(this.sfButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 170;
            this.label1.Text = "Korisnik:";
            // 
            // cboKorisnik
            // 
            this.cboKorisnik.BackColor = System.Drawing.Color.White;
            this.cboKorisnik.FormattingEnabled = true;
            this.cboKorisnik.Location = new System.Drawing.Point(222, 27);
            this.cboKorisnik.Name = "cboKorisnik";
            this.cboKorisnik.Size = new System.Drawing.Size(191, 21);
            this.cboKorisnik.TabIndex = 169;
            // 
            // sfButton2
            // 
            this.sfButton2.AccessibleName = "Button";
            this.sfButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton2.Location = new System.Drawing.Point(562, 20);
            this.sfButton2.Name = "sfButton2";
            this.sfButton2.Size = new System.Drawing.Size(120, 28);
            this.sfButton2.TabIndex = 171;
            this.sfButton2.Text = "Štampaj Z8";
            this.sfButton2.Click += new System.EventHandler(this.sfButton2_Click);
            // 
            // TestiranjeStampa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sfButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboKorisnik);
            this.Controls.Add(this.sfButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboGrupaTesta);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TestiranjeStampa";
            this.Text = "Rezultati testiranja";
            this.Load += new System.EventHandler(this.TestiranjeStampa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGrupaTesta;
        private Syncfusion.WinForms.Controls.SfButton sfButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboKorisnik;
        private Syncfusion.WinForms.Controls.SfButton sfButton2;
    }
}