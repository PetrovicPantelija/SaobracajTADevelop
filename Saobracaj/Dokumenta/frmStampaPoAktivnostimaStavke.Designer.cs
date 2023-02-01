namespace Saobracaj.Dokumenta
{
    partial class frmStampaPoAktivnostimaStavke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStampaPoAktivnostimaStavke));
            this.btnStampa = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label6 = new System.Windows.Forms.Label();
            this.cboZaposleni = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMilsped = new System.Windows.Forms.CheckBox();
            this.chkMasinovodja = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnStampa
            // 
            this.btnStampa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btnStampa.ForeColor = System.Drawing.Color.White;
            this.btnStampa.Location = new System.Drawing.Point(1025, 4);
            this.btnStampa.Margin = new System.Windows.Forms.Padding(4);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(127, 35);
            this.btnStampa.TabIndex = 92;
            this.btnStampa.Text = "Štampaj";
            this.btnStampa.UseVisualStyleBackColor = false;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
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
            this.reportViewer1.Location = new System.Drawing.Point(16, 47);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1135, 409);
            this.reportViewer1.TabIndex = 93;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 95;
            this.label6.Text = "Zaposleni:";
            // 
            // cboZaposleni
            // 
            this.cboZaposleni.BackColor = System.Drawing.Color.White;
            this.cboZaposleni.FormattingEnabled = true;
            this.cboZaposleni.Location = new System.Drawing.Point(99, 14);
            this.cboZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.cboZaposleni.Name = "cboZaposleni";
            this.cboZaposleni.Size = new System.Drawing.Size(227, 24);
            this.cboZaposleni.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 107;
            this.label1.Text = "VremeOd";
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeDo.Location = new System.Drawing.Point(655, 15);
            this.dtpVremeDo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.ShowUpDown = true;
            this.dtpVremeDo.Size = new System.Drawing.Size(145, 22);
            this.dtpVremeDo.TabIndex = 106;
            this.dtpVremeDo.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeOd.Location = new System.Drawing.Point(424, 15);
            this.dtpVremeOd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.ShowUpDown = true;
            this.dtpVremeOd.Size = new System.Drawing.Size(145, 22);
            this.dtpVremeOd.TabIndex = 105;
            this.dtpVremeOd.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(579, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 108;
            this.label2.Text = "VremeDo";
            // 
            // chkMilsped
            // 
            this.chkMilsped.AutoSize = true;
            this.chkMilsped.Location = new System.Drawing.Point(809, 16);
            this.chkMilsped.Margin = new System.Windows.Forms.Padding(4);
            this.chkMilsped.Name = "chkMilsped";
            this.chkMilsped.Size = new System.Drawing.Size(78, 21);
            this.chkMilsped.TabIndex = 114;
            this.chkMilsped.Text = "Milšped";
            this.chkMilsped.UseVisualStyleBackColor = true;
            // 
            // chkMasinovodja
            // 
            this.chkMasinovodja.AutoSize = true;
            this.chkMasinovodja.Location = new System.Drawing.Point(900, 16);
            this.chkMasinovodja.Margin = new System.Windows.Forms.Padding(4);
            this.chkMasinovodja.Name = "chkMasinovodja";
            this.chkMasinovodja.Size = new System.Drawing.Size(109, 21);
            this.chkMasinovodja.TabIndex = 115;
            this.chkMasinovodja.Text = "Mašinovodja";
            this.chkMasinovodja.UseVisualStyleBackColor = true;
            // 
            // frmStampaPoAktivnostimaStavke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1168, 465);
            this.Controls.Add(this.chkMasinovodja);
            this.Controls.Add(this.chkMilsped);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpVremeDo);
            this.Controls.Add(this.dtpVremeOd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboZaposleni);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnStampa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStampaPoAktivnostimaStavke";
            this.Text = "Štampaj po stavkama aktivnosti";
            this.Load += new System.EventHandler(this.frmStampaPoAktivnostimaStavke_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStampa;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboZaposleni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkMilsped;
        private System.Windows.Forms.CheckBox chkMasinovodja;
    }
}