
namespace Saobracaj.Dokumenta
{
    partial class frmObracunFiksni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObracunFiksni));
            this.txtCenaSata = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrojSati = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPostaviPrviDeo = new MetroFramework.Controls.MetroButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.txtCenaSata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrojSati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCenaSata
            // 
            this.txtCenaSata.DecimalPlaces = 2;
            this.txtCenaSata.Location = new System.Drawing.Point(425, 34);
            this.txtCenaSata.Margin = new System.Windows.Forms.Padding(4);
            this.txtCenaSata.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtCenaSata.Name = "txtCenaSata";
            this.txtCenaSata.Size = new System.Drawing.Size(96, 22);
            this.txtCenaSata.TabIndex = 151;
            this.txtCenaSata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 150;
            this.label1.Text = "Cena sata:";
            // 
            // txtBrojSati
            // 
            this.txtBrojSati.DecimalPlaces = 2;
            this.txtBrojSati.Location = new System.Drawing.Point(179, 34);
            this.txtBrojSati.Margin = new System.Windows.Forms.Padding(4);
            this.txtBrojSati.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtBrojSati.Name = "txtBrojSati";
            this.txtBrojSati.Size = new System.Drawing.Size(131, 22);
            this.txtBrojSati.TabIndex = 149;
            this.txtBrojSati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 148;
            this.label2.Text = "Broj mesečnih sati:";
            // 
            // btnPostaviPrviDeo
            // 
            this.btnPostaviPrviDeo.Location = new System.Drawing.Point(36, 82);
            this.btnPostaviPrviDeo.Margin = new System.Windows.Forms.Padding(4);
            this.btnPostaviPrviDeo.Name = "btnPostaviPrviDeo";
            this.btnPostaviPrviDeo.Size = new System.Drawing.Size(212, 28);
            this.btnPostaviPrviDeo.TabIndex = 152;
            this.btnPostaviPrviDeo.Text = "Povuci podatke";
            this.btnPostaviPrviDeo.UseSelectable = true;
            this.btnPostaviPrviDeo.Click += new System.EventHandler(this.btnPostaviPrviDeo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 140);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1508, 505);
            this.dataGridView1.TabIndex = 153;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(785, 36);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 17);
            this.label15.TabIndex = 209;
            this.label15.Text = "Period do:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(552, 36);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 17);
            this.label21.TabIndex = 208;
            this.label21.Text = "Period od:";
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(344, 82);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(212, 28);
            this.metroButton2.TabIndex = 210;
            this.metroButton2.Text = "Povuci sate";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpVremeOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeOd.Location = new System.Drawing.Point(633, 34);
            this.dtpVremeOd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.ShowUpDown = true;
            this.dtpVremeOd.Size = new System.Drawing.Size(145, 22);
            this.dtpVremeOd.TabIndex = 215;
            this.dtpVremeOd.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpVremeDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeDo.Location = new System.Drawing.Point(867, 34);
            this.dtpVremeDo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.ShowUpDown = true;
            this.dtpVremeDo.Size = new System.Drawing.Size(145, 22);
            this.dtpVremeDo.TabIndex = 214;
            this.dtpVremeDo.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // frmObracunFiksni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1531, 649);
            this.Controls.Add(this.dtpVremeOd);
            this.Controls.Add(this.dtpVremeDo);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPostaviPrviDeo);
            this.Controls.Add(this.txtCenaSata);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBrojSati);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmObracunFiksni";
            this.Text = "Obračun zarade";
            ((System.ComponentModel.ISupportInitialize)(this.txtCenaSata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrojSati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtCenaSata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtBrojSati;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton btnPostaviPrviDeo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label21;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
    }
}