namespace Saobracaj
{
    partial class frmZaposleniUkupno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZaposleniUkupno));
            this.SelectSumVremeAktivnostiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TESTIRANJEDataSet4 = new Saobracaj.TESTIRANJEDataSet4();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.btnStampa = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SelectSumVremeAktivnostiTableAdapter = new Saobracaj.TESTIRANJEDataSet4TableAdapters.SelectSumVremeAktivnostiTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SelectSumVremeAktivnostiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTIRANJEDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectSumVremeAktivnostiBindingSource
            // 
            this.SelectSumVremeAktivnostiBindingSource.DataMember = "SelectSumVremeAktivnosti";
            this.SelectSumVremeAktivnostiBindingSource.DataSource = this.TESTIRANJEDataSet4;
            // 
            // TESTIRANJEDataSet4
            // 
            this.TESTIRANJEDataSet4.DataSetName = "TESTIRANJEDataSet4";
            this.TESTIRANJEDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(279, 22);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 18);
            this.label17.TabIndex = 75;
            this.label17.Text = "*VremeDo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(13, 22);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 18);
            this.label16.TabIndex = 74;
            this.label16.Text = "*VremeOd:";
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeDo.Location = new System.Drawing.Point(364, 22);
            this.dtpVremeDo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.ShowUpDown = true;
            this.dtpVremeDo.Size = new System.Drawing.Size(145, 22);
            this.dtpVremeDo.TabIndex = 73;
            this.dtpVremeDo.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeOd.Location = new System.Drawing.Point(99, 22);
            this.dtpVremeOd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.ShowUpDown = true;
            this.dtpVremeOd.Size = new System.Drawing.Size(145, 22);
            this.dtpVremeOd.TabIndex = 72;
            this.dtpVremeOd.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // btnStampa
            // 
            this.btnStampa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnStampa.ForeColor = System.Drawing.Color.White;
            this.btnStampa.Location = new System.Drawing.Point(533, 15);
            this.btnStampa.Margin = new System.Windows.Forms.Padding(4);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(196, 46);
            this.btnStampa.TabIndex = 90;
            this.btnStampa.Text = "Štampaj";
            this.btnStampa.UseVisualStyleBackColor = false;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet7";
            reportDataSource1.Value = this.SelectSumVremeAktivnostiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Saobracaj.Izvestaji.rptUkupnoZaPeriod.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 93);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1042, 349);
            this.reportViewer1.TabIndex = 91;
            // 
            // SelectSumVremeAktivnostiTableAdapter
            // 
            this.SelectSumVremeAktivnostiTableAdapter.ClearBeforeFill = true;
            // 
            // frmZaposleniUkupno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1068, 455);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnStampa);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtpVremeDo);
            this.Controls.Add(this.dtpVremeOd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmZaposleniUkupno";
            this.Text = "Zaposleni ukupno";
            this.Load += new System.EventHandler(this.frmZaposleniUkupno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SelectSumVremeAktivnostiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTIRANJEDataSet4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.Button btnStampa;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SelectSumVremeAktivnostiBindingSource;
        private TESTIRANJEDataSet4 TESTIRANJEDataSet4;
        private TESTIRANJEDataSet4TableAdapters.SelectSumVremeAktivnostiTableAdapter SelectSumVremeAktivnostiTableAdapter;
    }
}