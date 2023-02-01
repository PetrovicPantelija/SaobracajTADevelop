
namespace Saobracaj.Dokumenta
{
    partial class frmPodtrase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPodtrase));
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStanicaOd = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStanicaDo = new System.Windows.Forms.ComboBox();
            this.cmbKlasa = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.chkElektrificirana = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRastojanjeKM = new System.Windows.Forms.NumericUpDown();
            this.txtTrase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtRN = new System.Windows.Forms.TextBox();
            this.cboPruge = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            this.txtRB = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRastojanjeKM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPruge)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsSave,
            this.tsDelete,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1241, 27);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "Osveži";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(29, 24);
            this.tsNew.Text = "Novi";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(29, 24);
            this.tsSave.Text = "tsSave";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsDelete.Image")));
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(29, 24);
            this.tsDelete.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 146;
            this.label6.Text = "Pruga:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(897, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 148;
            this.label1.Text = "Stanica od:";
            // 
            // cboStanicaOd
            // 
            this.cboStanicaOd.FormattingEnabled = true;
            this.cboStanicaOd.Location = new System.Drawing.Point(1003, 47);
            this.cboStanicaOd.Margin = new System.Windows.Forms.Padding(4);
            this.cboStanicaOd.Name = "cboStanicaOd";
            this.cboStanicaOd.Size = new System.Drawing.Size(207, 24);
            this.cboStanicaOd.TabIndex = 147;
            this.cboStanicaOd.Leave += new System.EventHandler(this.cboStanicaOd_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(895, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 150;
            this.label2.Text = "Stanica Do:";
            // 
            // cboStanicaDo
            // 
            this.cboStanicaDo.FormattingEnabled = true;
            this.cboStanicaDo.Location = new System.Drawing.Point(1003, 92);
            this.cboStanicaDo.Margin = new System.Windows.Forms.Padding(4);
            this.cboStanicaDo.Name = "cboStanicaDo";
            this.cboStanicaDo.Size = new System.Drawing.Size(207, 24);
            this.cboStanicaDo.TabIndex = 149;
            this.cboStanicaDo.SelectedValueChanged += new System.EventHandler(this.cboStanicaDo_SelectedValueChanged);
            this.cboStanicaDo.Leave += new System.EventHandler(this.cboStanicaDo_Leave);
            // 
            // cmbKlasa
            // 
            this.cmbKlasa.FormattingEnabled = true;
            this.cmbKlasa.Items.AddRange(new object[] {
            "M",
            "R",
            "L"});
            this.cmbKlasa.Location = new System.Drawing.Point(207, 119);
            this.cmbKlasa.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKlasa.Name = "cmbKlasa";
            this.cmbKlasa.Size = new System.Drawing.Size(112, 24);
            this.cmbKlasa.TabIndex = 153;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(155, 123);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(43, 17);
            this.label28.TabIndex = 154;
            this.label28.Text = "Klasa";
            // 
            // chkElektrificirana
            // 
            this.chkElektrificirana.AutoSize = true;
            this.chkElektrificirana.Location = new System.Drawing.Point(15, 123);
            this.chkElektrificirana.Margin = new System.Windows.Forms.Padding(4);
            this.chkElektrificirana.Name = "chkElektrificirana";
            this.chkElektrificirana.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkElektrificirana.Size = new System.Drawing.Size(115, 21);
            this.chkElektrificirana.TabIndex = 155;
            this.chkElektrificirana.Text = "Elektrificirana";
            this.chkElektrificirana.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 157;
            this.label3.Text = "Rastojanje:";
            // 
            // txtRastojanjeKM
            // 
            this.txtRastojanjeKM.DecimalPlaces = 2;
            this.txtRastojanjeKM.Location = new System.Drawing.Point(431, 122);
            this.txtRastojanjeKM.Margin = new System.Windows.Forms.Padding(4);
            this.txtRastojanjeKM.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtRastojanjeKM.Name = "txtRastojanjeKM";
            this.txtRastojanjeKM.Size = new System.Drawing.Size(85, 22);
            this.txtRastojanjeKM.TabIndex = 156;
            this.txtRastojanjeKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTrase
            // 
            this.txtTrase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTrase.Location = new System.Drawing.Point(91, 53);
            this.txtTrase.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrase.Name = "txtTrase";
            this.txtTrase.Size = new System.Drawing.Size(85, 22);
            this.txtTrase.TabIndex = 160;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 159;
            this.label4.Text = "Šifra:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 153);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1209, 320);
            this.dataGridView1.TabIndex = 161;
            // 
            // txtRN
            // 
            this.txtRN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRN.Location = new System.Drawing.Point(191, 87);
            this.txtRN.Margin = new System.Windows.Forms.Padding(4);
            this.txtRN.Name = "txtRN";
            this.txtRN.Size = new System.Drawing.Size(85, 22);
            this.txtRN.TabIndex = 162;
            // 
            // cboPruge
            // 
            this.cboPruge.AllowFiltering = false;
            this.cboPruge.BackColor = System.Drawing.Color.GreenYellow;
            this.cboPruge.BeforeTouchSize = new System.Drawing.Size(396, 24);
            this.cboPruge.Filter = null;
            this.cboPruge.Location = new System.Drawing.Point(347, 53);
            this.cboPruge.Margin = new System.Windows.Forms.Padding(4);
            this.cboPruge.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.cboPruge.Name = "cboPruge";
            this.cboPruge.ScrollMetroColorTable = metroColorTable1;
            this.cboPruge.Size = new System.Drawing.Size(396, 24);
            this.cboPruge.TabIndex = 163;
            this.cboPruge.Leave += new System.EventHandler(this.cboPruge_Leave);
            // 
            // txtRB
            // 
            this.txtRB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRB.Location = new System.Drawing.Point(91, 87);
            this.txtRB.Margin = new System.Windows.Forms.Padding(4);
            this.txtRB.Name = "txtRB";
            this.txtRB.Size = new System.Drawing.Size(85, 22);
            this.txtRB.TabIndex = 164;
            // 
            // frmPodtrase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1241, 554);
            this.Controls.Add(this.txtRB);
            this.Controls.Add(this.cboPruge);
            this.Controls.Add(this.txtRN);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtTrase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRastojanjeKM);
            this.Controls.Add(this.chkElektrificirana);
            this.Controls.Add(this.cmbKlasa);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStanicaDo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStanicaOd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPodtrase";
            this.Text = "Podtrase";
            this.Load += new System.EventHandler(this.frmPodtrase_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRastojanjeKM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPruge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStanicaOd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStanicaDo;
        private System.Windows.Forms.ComboBox cmbKlasa;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox chkElektrificirana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtRastojanjeKM;
        private System.Windows.Forms.TextBox txtTrase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtRN;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox cboPruge;
        private System.Windows.Forms.TextBox txtRB;
    }
}