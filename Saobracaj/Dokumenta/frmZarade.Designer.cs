namespace Saobracaj.Dokumenta
{
    partial class frmZarade
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZarade));
            this.perftechBeogradDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TESTIRANJEDataSet3 = new Saobracaj.TESTIRANJEDataSet3();
            this.btnStampa = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label6 = new System.Windows.Forms.Label();
            this.cboZaposleni = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.chkMilsped = new System.Windows.Forms.CheckBox();
            this.chkLokomotiva = new System.Windows.Forms.CheckBox();
            this.chkVanLokomotive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.perftechBeogradDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTIRANJEDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // perftechBeogradDataSet3BindingSource
            // 
            this.perftechBeogradDataSet3BindingSource.DataSource = this.TESTIRANJEDataSet3;
            this.perftechBeogradDataSet3BindingSource.Position = 0;
            // 
            // TESTIRANJEDataSet3
            // 
            this.TESTIRANJEDataSet3.DataSetName = "TESTIRANJEDataSet3";
            this.TESTIRANJEDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnStampa
            // 
            this.btnStampa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btnStampa.ForeColor = System.Drawing.Color.White;
            this.btnStampa.Location = new System.Drawing.Point(1005, 10);
            this.btnStampa.Margin = new System.Windows.Forms.Padding(4);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(104, 41);
            this.btnStampa.TabIndex = 90;
            this.btnStampa.Text = "Štampaj";
            this.btnStampa.UseVisualStyleBackColor = false;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSetZarada";
            reportDataSource1.Value = this.perftechBeogradDataSet3BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Saobracaj.Dokumenta.Zarada.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(17, 89);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1091, 388);
            this.reportViewer1.TabIndex = 91;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 93;
            this.label6.Text = "Zaposleni:";
            // 
            // cboZaposleni
            // 
            this.cboZaposleni.BackColor = System.Drawing.Color.White;
            this.cboZaposleni.FormattingEnabled = true;
            this.cboZaposleni.Location = new System.Drawing.Point(97, 15);
            this.cboZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.cboZaposleni.Name = "cboZaposleni";
            this.cboZaposleni.Size = new System.Drawing.Size(191, 24);
            this.cboZaposleni.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 112;
            this.label2.Text = "VremeDo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 111;
            this.label1.Text = "VremeOd";
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeDo.Location = new System.Drawing.Point(605, 14);
            this.dtpVremeDo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.ShowUpDown = true;
            this.dtpVremeDo.Size = new System.Drawing.Size(145, 22);
            this.dtpVremeDo.TabIndex = 110;
            this.dtpVremeDo.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeOd.Location = new System.Drawing.Point(375, 14);
            this.dtpVremeOd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.ShowUpDown = true;
            this.dtpVremeOd.Size = new System.Drawing.Size(145, 22);
            this.dtpVremeOd.TabIndex = 109;
            this.dtpVremeOd.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // chkMilsped
            // 
            this.chkMilsped.AutoSize = true;
            this.chkMilsped.Location = new System.Drawing.Point(772, 17);
            this.chkMilsped.Margin = new System.Windows.Forms.Padding(4);
            this.chkMilsped.Name = "chkMilsped";
            this.chkMilsped.Size = new System.Drawing.Size(78, 21);
            this.chkMilsped.TabIndex = 113;
            this.chkMilsped.Text = "Milšped";
            this.chkMilsped.UseVisualStyleBackColor = true;
            // 
            // chkLokomotiva
            // 
            this.chkLokomotiva.AutoSize = true;
            this.chkLokomotiva.Location = new System.Drawing.Point(863, 17);
            this.chkLokomotiva.Margin = new System.Windows.Forms.Padding(4);
            this.chkLokomotiva.Name = "chkLokomotiva";
            this.chkLokomotiva.Size = new System.Drawing.Size(102, 21);
            this.chkLokomotiva.TabIndex = 114;
            this.chkLokomotiva.Text = "Lokomotiva";
            this.chkLokomotiva.UseVisualStyleBackColor = true;
            // 
            // chkVanLokomotive
            // 
            this.chkVanLokomotive.AutoSize = true;
            this.chkVanLokomotive.Location = new System.Drawing.Point(863, 46);
            this.chkVanLokomotive.Margin = new System.Windows.Forms.Padding(4);
            this.chkVanLokomotive.Name = "chkVanLokomotive";
            this.chkVanLokomotive.Size = new System.Drawing.Size(131, 21);
            this.chkVanLokomotive.TabIndex = 115;
            this.chkVanLokomotive.Text = "Van Lokomotive";
            this.chkVanLokomotive.UseVisualStyleBackColor = true;
            // 
            // frmZarade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1125, 492);
            this.Controls.Add(this.chkVanLokomotive);
            this.Controls.Add(this.chkLokomotiva);
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
            this.Name = "frmZarade";
            this.Text = "Obračun po satu";
            this.Load += new System.EventHandler(this.frmZarade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.perftechBeogradDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTIRANJEDataSet3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStampa;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource perftechBeogradDataSet3BindingSource;
        private TESTIRANJEDataSet3 TESTIRANJEDataSet3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboZaposleni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.CheckBox chkMilsped;
        private System.Windows.Forms.CheckBox chkLokomotiva;
        private System.Windows.Forms.CheckBox chkVanLokomotive;
    }
}