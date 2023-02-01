
namespace Saobracaj.Dokumenta
{
    partial class frmKontaktOsobe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKontaktOsobe));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaKOIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPaKOPriimek = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaKOOddelek = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPaKOTel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPaKOMail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPaKOOpomba = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkOperatika = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtPaKOZapSt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPaKOSifra = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(789, 27);
            this.toolStrip1.TabIndex = 200;
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
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 232;
            this.label3.Text = "Partner";
            // 
            // txtPaKOIme
            // 
            this.txtPaKOIme.Location = new System.Drawing.Point(94, 80);
            this.txtPaKOIme.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaKOIme.Name = "txtPaKOIme";
            this.txtPaKOIme.Size = new System.Drawing.Size(294, 22);
            this.txtPaKOIme.TabIndex = 235;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 234;
            this.label1.Text = "Ime";
            // 
            // txtPaKOPriimek
            // 
            this.txtPaKOPriimek.Location = new System.Drawing.Point(94, 110);
            this.txtPaKOPriimek.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaKOPriimek.Name = "txtPaKOPriimek";
            this.txtPaKOPriimek.Size = new System.Drawing.Size(254, 22);
            this.txtPaKOPriimek.TabIndex = 237;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 236;
            this.label2.Text = "Prezime";
            // 
            // txtPaKOOddelek
            // 
            this.txtPaKOOddelek.Location = new System.Drawing.Point(94, 140);
            this.txtPaKOOddelek.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaKOOddelek.Name = "txtPaKOOddelek";
            this.txtPaKOOddelek.Size = new System.Drawing.Size(254, 22);
            this.txtPaKOOddelek.TabIndex = 239;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 238;
            this.label4.Text = "Odeljenje";
            // 
            // txtPaKOTel
            // 
            this.txtPaKOTel.Location = new System.Drawing.Point(94, 170);
            this.txtPaKOTel.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaKOTel.Name = "txtPaKOTel";
            this.txtPaKOTel.Size = new System.Drawing.Size(254, 22);
            this.txtPaKOTel.TabIndex = 241;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 240;
            this.label5.Text = "Telefon";
            // 
            // txtPaKOMail
            // 
            this.txtPaKOMail.Location = new System.Drawing.Point(94, 200);
            this.txtPaKOMail.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaKOMail.Name = "txtPaKOMail";
            this.txtPaKOMail.Size = new System.Drawing.Size(254, 22);
            this.txtPaKOMail.TabIndex = 243;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 200);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 242;
            this.label6.Text = "Email";
            // 
            // txtPaKOOpomba
            // 
            this.txtPaKOOpomba.Location = new System.Drawing.Point(94, 230);
            this.txtPaKOOpomba.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaKOOpomba.Multiline = true;
            this.txtPaKOOpomba.Name = "txtPaKOOpomba";
            this.txtPaKOOpomba.Size = new System.Drawing.Size(676, 43);
            this.txtPaKOOpomba.TabIndex = 245;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 230);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 244;
            this.label7.Text = "Napomena";
            // 
            // chkOperatika
            // 
            this.chkOperatika.AutoSize = true;
            this.chkOperatika.Location = new System.Drawing.Point(437, 82);
            this.chkOperatika.Margin = new System.Windows.Forms.Padding(4);
            this.chkOperatika.Name = "chkOperatika";
            this.chkOperatika.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOperatika.Size = new System.Drawing.Size(127, 21);
            this.chkOperatika.TabIndex = 246;
            this.chkOperatika.Text = "Koristi operater";
            this.chkOperatika.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(765, 206);
            this.groupBox2.TabIndex = 247;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pregled stavki";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(751, 171);
            this.dataGridView1.TabIndex = 229;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // txtPaKOZapSt
            // 
            this.txtPaKOZapSt.Location = new System.Drawing.Point(94, 50);
            this.txtPaKOZapSt.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaKOZapSt.Name = "txtPaKOZapSt";
            this.txtPaKOZapSt.Size = new System.Drawing.Size(75, 22);
            this.txtPaKOZapSt.TabIndex = 249;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 50);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 17);
            this.label8.TabIndex = 248;
            this.label8.Text = "ID";
            // 
            // txtPaKOSifra
            // 
            this.txtPaKOSifra.BackColor = System.Drawing.Color.White;
            this.txtPaKOSifra.ForeColor = System.Drawing.Color.Black;
            this.txtPaKOSifra.FormattingEnabled = true;
            this.txtPaKOSifra.Location = new System.Drawing.Point(280, 50);
            this.txtPaKOSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaKOSifra.Name = "txtPaKOSifra";
            this.txtPaKOSifra.Size = new System.Drawing.Size(294, 24);
            this.txtPaKOSifra.TabIndex = 250;
            // 
            // frmKontaktOsobe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(789, 488);
            this.Controls.Add(this.txtPaKOSifra);
            this.Controls.Add(this.txtPaKOZapSt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkOperatika);
            this.Controls.Add(this.txtPaKOOpomba);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPaKOMail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPaKOTel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPaKOOddelek);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPaKOPriimek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaKOIme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKontaktOsobe";
            this.Text = "Kontakt osobe";
            this.Load += new System.EventHandler(this.frmKontaktOsobe_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaKOIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaKOPriimek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaKOOddelek;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaKOTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPaKOMail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPaKOOpomba;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkOperatika;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPaKOZapSt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtPaKOSifra;
    }
}