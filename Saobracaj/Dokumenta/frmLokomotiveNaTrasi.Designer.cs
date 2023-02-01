namespace Saobracaj.Dokumenta
{
    partial class frmLokomotiveNaTrasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLokomotiveNaTrasi));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTrase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSifraRN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLokomotiva = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKomentar = new System.Windows.Forms.TextBox();
            this.chkVucna = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStanicaDo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboStanicaOd = new System.Windows.Forms.ComboBox();
            this.txtVreme = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVreme)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1133, 27);
            this.toolStrip1.TabIndex = 34;
            this.toolStrip1.Text = "toolStrip1";
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
            this.label3.Location = new System.Drawing.Point(240, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Trasa:";
            // 
            // cboTrase
            // 
            this.cboTrase.BackColor = System.Drawing.Color.Yellow;
            this.cboTrase.FormattingEnabled = true;
            this.cboTrase.Location = new System.Drawing.Point(297, 55);
            this.cboTrase.Margin = new System.Windows.Forms.Padding(4);
            this.cboTrase.Name = "cboTrase";
            this.cboTrase.Size = new System.Drawing.Size(220, 24);
            this.cboTrase.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Šifra RN:";
            // 
            // txtSifraRN
            // 
            this.txtSifraRN.BackColor = System.Drawing.Color.Yellow;
            this.txtSifraRN.Location = new System.Drawing.Point(99, 55);
            this.txtSifraRN.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifraRN.Name = "txtSifraRN";
            this.txtSifraRN.Size = new System.Drawing.Size(132, 22);
            this.txtSifraRN.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "Lokomotive:";
            // 
            // cboLokomotiva
            // 
            this.cboLokomotiva.FormattingEnabled = true;
            this.cboLokomotiva.Location = new System.Drawing.Point(297, 89);
            this.cboLokomotiva.Margin = new System.Windows.Forms.Padding(4);
            this.cboLokomotiva.Name = "cboLokomotiva";
            this.cboLokomotiva.Size = new System.Drawing.Size(220, 24);
            this.cboLokomotiva.TabIndex = 45;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 217);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1111, 143);
            this.dataGridView1.TabIndex = 48;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(537, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 137;
            this.label4.Text = "Napomena:";
            // 
            // txtKomentar
            // 
            this.txtKomentar.Location = new System.Drawing.Point(541, 55);
            this.txtKomentar.Margin = new System.Windows.Forms.Padding(4);
            this.txtKomentar.Multiline = true;
            this.txtKomentar.Name = "txtKomentar";
            this.txtKomentar.Size = new System.Drawing.Size(584, 85);
            this.txtKomentar.TabIndex = 136;
            // 
            // chkVucna
            // 
            this.chkVucna.AutoSize = true;
            this.chkVucna.Checked = true;
            this.chkVucna.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVucna.Location = new System.Drawing.Point(16, 94);
            this.chkVucna.Margin = new System.Windows.Forms.Padding(4);
            this.chkVucna.Name = "chkVucna";
            this.chkVucna.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVucna.Size = new System.Drawing.Size(70, 21);
            this.chkVucna.TabIndex = 138;
            this.chkVucna.Text = "Vučna";
            this.chkVucna.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(299, 159);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(13, 28);
            this.button1.TabIndex = 144;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(297, 126);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(13, 28);
            this.button2.TabIndex = 143;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 142;
            this.label6.Text = "Stanica do:";
            // 
            // cboStanicaDo
            // 
            this.cboStanicaDo.FormattingEnabled = true;
            this.cboStanicaDo.Location = new System.Drawing.Point(101, 161);
            this.cboStanicaDo.Margin = new System.Windows.Forms.Padding(4);
            this.cboStanicaDo.Name = "cboStanicaDo";
            this.cboStanicaDo.Size = new System.Drawing.Size(188, 24);
            this.cboStanicaDo.TabIndex = 140;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 126);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 141;
            this.label7.Text = "Stanica od:";
            // 
            // cboStanicaOd
            // 
            this.cboStanicaOd.FormattingEnabled = true;
            this.cboStanicaOd.Location = new System.Drawing.Point(101, 128);
            this.cboStanicaOd.Margin = new System.Windows.Forms.Padding(4);
            this.cboStanicaOd.Name = "cboStanicaOd";
            this.cboStanicaOd.Size = new System.Drawing.Size(187, 24);
            this.cboStanicaOd.TabIndex = 139;
            // 
            // txtVreme
            // 
            this.txtVreme.Location = new System.Drawing.Point(401, 159);
            this.txtVreme.Margin = new System.Windows.Forms.Padding(4);
            this.txtVreme.Name = "txtVreme";
            this.txtVreme.Size = new System.Drawing.Size(88, 22);
            this.txtVreme.TabIndex = 146;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 147;
            this.label5.Text = "Vreme:";
            // 
            // frmLokomotiveNaTrasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1133, 363);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtVreme);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboStanicaDo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboStanicaOd);
            this.Controls.Add(this.chkVucna);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKomentar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLokomotiva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTrase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSifraRN);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLokomotiveNaTrasi";
            this.Text = "Lokomotive na trasi";
            this.Load += new System.EventHandler(this.frmLokomotiveNaTrasi_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVreme)).EndInit();
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
        private System.Windows.Forms.ComboBox cboTrase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSifraRN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLokomotiva;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKomentar;
        private System.Windows.Forms.CheckBox chkVucna;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStanicaDo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboStanicaOd;
        private System.Windows.Forms.NumericUpDown txtVreme;
        private System.Windows.Forms.Label label5;
    }
}