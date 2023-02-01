
namespace Saobracaj.Dokumenta
{
    partial class frmAutomobiliServis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutomobiliServis));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label4 = new System.Windows.Forms.Label();
            this.cboZaposleni = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.dtpDatumServisa = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAutomobilID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPartneri = new System.Windows.Forms.ComboBox();
            this.chkVelikiServis = new System.Windows.Forms.CheckBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.txtKM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1067, 27);
            this.toolStrip1.TabIndex = 144;
            this.toolStrip1.Text = "Unesi cenu za radnika";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 210;
            this.label4.Text = "Servis izvršio:";
            // 
            // cboZaposleni
            // 
            this.cboZaposleni.FormattingEnabled = true;
            this.cboZaposleni.Location = new System.Drawing.Point(127, 90);
            this.cboZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.cboZaposleni.Name = "cboZaposleni";
            this.cboZaposleni.Size = new System.Drawing.Size(227, 24);
            this.cboZaposleni.TabIndex = 212;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 127);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 217;
            this.label8.Text = "Napomena:";
            // 
            // txtNapomena
            // 
            this.txtNapomena.Location = new System.Drawing.Point(21, 149);
            this.txtNapomena.Margin = new System.Windows.Forms.Padding(4);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(755, 102);
            this.txtNapomena.TabIndex = 216;
            // 
            // dtpDatumServisa
            // 
            this.dtpDatumServisa.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumServisa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumServisa.Location = new System.Drawing.Point(491, 54);
            this.dtpDatumServisa.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumServisa.Name = "dtpDatumServisa";
            this.dtpDatumServisa.ShowUpDown = true;
            this.dtpDatumServisa.Size = new System.Drawing.Size(143, 22);
            this.dtpDatumServisa.TabIndex = 214;
            this.dtpDatumServisa.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(380, 52);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 17);
            this.label21.TabIndex = 215;
            this.label21.Text = "Datum servisa:";
            // 
            // txtSifra
            // 
            this.txtSifra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtSifra.Location = new System.Drawing.Point(111, 52);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(68, 22);
            this.txtSifra.TabIndex = 211;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 53);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 213;
            this.label7.Text = "Šifra zapisa:";
            // 
            // txtAutomobilID
            // 
            this.txtAutomobilID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtAutomobilID.Location = new System.Drawing.Point(285, 53);
            this.txtAutomobilID.Margin = new System.Windows.Forms.Padding(4);
            this.txtAutomobilID.Name = "txtAutomobilID";
            this.txtAutomobilID.Size = new System.Drawing.Size(68, 22);
            this.txtAutomobilID.TabIndex = 218;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 219;
            this.label1.Text = "Automobil ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 220;
            this.label2.Text = "Servis izvršen kod:";
            // 
            // cboPartneri
            // 
            this.cboPartneri.FormattingEnabled = true;
            this.cboPartneri.Location = new System.Drawing.Point(517, 92);
            this.cboPartneri.Margin = new System.Windows.Forms.Padding(4);
            this.cboPartneri.Name = "cboPartneri";
            this.cboPartneri.Size = new System.Drawing.Size(227, 24);
            this.cboPartneri.TabIndex = 221;
            // 
            // chkVelikiServis
            // 
            this.chkVelikiServis.AutoSize = true;
            this.chkVelikiServis.Location = new System.Drawing.Point(669, 52);
            this.chkVelikiServis.Margin = new System.Windows.Forms.Padding(4);
            this.chkVelikiServis.Name = "chkVelikiServis";
            this.chkVelikiServis.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVelikiServis.Size = new System.Drawing.Size(104, 21);
            this.chkVelikiServis.TabIndex = 222;
            this.chkVelikiServis.Text = "Veliki servis";
            this.chkVelikiServis.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToResizeRows = false;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView4.Location = new System.Drawing.Point(21, 260);
            this.dataGridView4.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView4.Name = "dataGridView4";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView4.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView4.RowHeadersWidth = 21;
            this.dataGridView4.Size = new System.Drawing.Size(1029, 279);
            this.dataGridView4.TabIndex = 223;
            this.dataGridView4.SelectionChanged += new System.EventHandler(this.dataGridView4_SelectionChanged);
            // 
            // txtKM
            // 
            this.txtKM.BackColor = System.Drawing.Color.White;
            this.txtKM.Location = new System.Drawing.Point(891, 52);
            this.txtKM.Margin = new System.Windows.Forms.Padding(4);
            this.txtKM.Name = "txtKM";
            this.txtKM.Size = new System.Drawing.Size(88, 22);
            this.txtKM.TabIndex = 224;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(797, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 225;
            this.label3.Text = "Kilometraža:";
            // 
            // frmAutomobiliServis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.txtKM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.chkVelikiServis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPartneri);
            this.Controls.Add(this.txtAutomobilID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboZaposleni);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.dtpDatumServisa);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAutomobiliServis";
            this.Text = "frmAutomobiliServis";
            this.Load += new System.EventHandler(this.frmAutomobiliServis_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboZaposleni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.DateTimePicker dtpDatumServisa;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAutomobilID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPartneri;
        private System.Windows.Forms.CheckBox chkVelikiServis;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.TextBox txtKM;
        private System.Windows.Forms.Label label3;
    }
}