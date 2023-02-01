namespace Saobracaj.Sifarnici
{
    partial class frmOsoblje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOsoblje));
            this.cboPartneri = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLokomotiva = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPruga = new System.Windows.Forms.ComboBox();
            this.chkMasinovodja = new System.Windows.Forms.CheckBox();
            this.chkPomocnik = new System.Windows.Forms.CheckBox();
            this.chkVozovodja = new System.Windows.Forms.CheckBox();
            this.chkPregledacKola = new System.Windows.Forms.CheckBox();
            this.chkManevrista = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPartneri
            // 
            this.cboPartneri.FormattingEnabled = true;
            this.cboPartneri.Location = new System.Drawing.Point(83, 44);
            this.cboPartneri.Margin = new System.Windows.Forms.Padding(4);
            this.cboPartneri.Name = "cboPartneri";
            this.cboPartneri.Size = new System.Drawing.Size(347, 24);
            this.cboPartneri.TabIndex = 14;
            this.cboPartneri.SelectedIndexChanged += new System.EventHandler(this.cboPartneri_SelectedIndexChanged);
            this.cboPartneri.Leave += new System.EventHandler(this.cboPartneri_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Radnik:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSave,
            this.tsDelete,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1144, 27);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "Unos lokomotive";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(196, 24);
            this.toolStripButton1.Text = "Dodeljivanje lokomotive";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(160, 24);
            this.toolStripButton2.Text = "Dodeljivanje pruge";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 110);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1128, 348);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1120, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Osnovni podaci";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 7);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1101, 302);
            this.dataGridView1.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1120, 319);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lokomotive";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 7);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(1101, 302);
            this.dataGridView2.TabIndex = 18;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1120, 319);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dodeljene pruge";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(8, 7);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(1101, 302);
            this.dataGridView3.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 49;
            this.label2.Text = "Lokomotive:";
            // 
            // cboLokomotiva
            // 
            this.cboLokomotiva.FormattingEnabled = true;
            this.cboLokomotiva.Location = new System.Drawing.Point(533, 44);
            this.cboLokomotiva.Margin = new System.Windows.Forms.Padding(4);
            this.cboLokomotiva.Name = "cboLokomotiva";
            this.cboLokomotiva.Size = new System.Drawing.Size(220, 24);
            this.cboLokomotiva.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(784, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "Pruga:";
            // 
            // cboPruga
            // 
            this.cboPruga.FormattingEnabled = true;
            this.cboPruga.Location = new System.Drawing.Point(843, 44);
            this.cboPruga.Margin = new System.Windows.Forms.Padding(4);
            this.cboPruga.Name = "cboPruga";
            this.cboPruga.Size = new System.Drawing.Size(220, 24);
            this.cboPruga.TabIndex = 50;
            // 
            // chkMasinovodja
            // 
            this.chkMasinovodja.AutoSize = true;
            this.chkMasinovodja.Location = new System.Drawing.Point(20, 81);
            this.chkMasinovodja.Margin = new System.Windows.Forms.Padding(4);
            this.chkMasinovodja.Name = "chkMasinovodja";
            this.chkMasinovodja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMasinovodja.Size = new System.Drawing.Size(106, 21);
            this.chkMasinovodja.TabIndex = 52;
            this.chkMasinovodja.Text = "Mašinovođa";
            this.chkMasinovodja.UseVisualStyleBackColor = true;
            // 
            // chkPomocnik
            // 
            this.chkPomocnik.AutoSize = true;
            this.chkPomocnik.Location = new System.Drawing.Point(159, 81);
            this.chkPomocnik.Margin = new System.Windows.Forms.Padding(4);
            this.chkPomocnik.Name = "chkPomocnik";
            this.chkPomocnik.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPomocnik.Size = new System.Drawing.Size(91, 21);
            this.chkPomocnik.TabIndex = 53;
            this.chkPomocnik.Text = "Pomoćnik";
            this.chkPomocnik.UseVisualStyleBackColor = true;
            // 
            // chkVozovodja
            // 
            this.chkVozovodja.AutoSize = true;
            this.chkVozovodja.Location = new System.Drawing.Point(296, 81);
            this.chkVozovodja.Margin = new System.Windows.Forms.Padding(4);
            this.chkVozovodja.Name = "chkVozovodja";
            this.chkVozovodja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVozovodja.Size = new System.Drawing.Size(93, 21);
            this.chkVozovodja.TabIndex = 54;
            this.chkVozovodja.Text = "Vozovođa";
            this.chkVozovodja.UseVisualStyleBackColor = true;
            // 
            // chkPregledacKola
            // 
            this.chkPregledacKola.AutoSize = true;
            this.chkPregledacKola.Location = new System.Drawing.Point(425, 81);
            this.chkPregledacKola.Margin = new System.Windows.Forms.Padding(4);
            this.chkPregledacKola.Name = "chkPregledacKola";
            this.chkPregledacKola.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPregledacKola.Size = new System.Drawing.Size(124, 21);
            this.chkPregledacKola.TabIndex = 55;
            this.chkPregledacKola.Text = "Pregledač kola";
            this.chkPregledacKola.UseVisualStyleBackColor = true;
            // 
            // chkManevrista
            // 
            this.chkManevrista.AutoSize = true;
            this.chkManevrista.Location = new System.Drawing.Point(580, 79);
            this.chkManevrista.Margin = new System.Windows.Forms.Padding(4);
            this.chkManevrista.Name = "chkManevrista";
            this.chkManevrista.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkManevrista.Size = new System.Drawing.Size(99, 21);
            this.chkManevrista.TabIndex = 56;
            this.chkManevrista.Text = "Manevrista";
            this.chkManevrista.UseVisualStyleBackColor = true;
            // 
            // frmOsoblje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1144, 462);
            this.Controls.Add(this.chkManevrista);
            this.Controls.Add(this.chkPregledacKola);
            this.Controls.Add(this.chkVozovodja);
            this.Controls.Add(this.chkPomocnik);
            this.Controls.Add(this.chkMasinovodja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboPruga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLokomotiva);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cboPartneri);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOsoblje";
            this.Text = "Osoblje";
            this.Load += new System.EventHandler(this.frmOsoblje_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPartneri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLokomotiva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPruga;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.CheckBox chkMasinovodja;
        private System.Windows.Forms.CheckBox chkPomocnik;
        private System.Windows.Forms.CheckBox chkVozovodja;
        private System.Windows.Forms.CheckBox chkPregledacKola;
        private System.Windows.Forms.CheckBox chkManevrista;
    }
}