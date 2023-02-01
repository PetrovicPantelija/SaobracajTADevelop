
namespace Saobracaj.Dokumenta
{
    partial class frmDogovori
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDogovori));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtNaStNar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNaStatus = new System.Windows.Forms.TextBox();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpNaDatNar = new System.Windows.Forms.DateTimePicker();
            this.cboNaPartPlac = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNaPNote = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNaPOpomba = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNaPKolNar2 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNaPKolNar = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNaPem2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNaPEM = new System.Windows.Forms.TextBox();
            this.cboNaPSifra = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNaPNarZap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboNaNacinDobave = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboNaSifObjekt = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNaOpomba1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNaPKolNar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNaPKolNar)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1102, 27);
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
            // txtNaStNar
            // 
            this.txtNaStNar.Location = new System.Drawing.Point(87, 49);
            this.txtNaStNar.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaStNar.Name = "txtNaStNar";
            this.txtNaStNar.Size = new System.Drawing.Size(75, 22);
            this.txtNaStNar.TabIndex = 231;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 230;
            this.label3.Text = "Šifra";
            // 
            // txtNaStatus
            // 
            this.txtNaStatus.Location = new System.Drawing.Point(87, 145);
            this.txtNaStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaStatus.Name = "txtNaStatus";
            this.txtNaStatus.Size = new System.Drawing.Size(32, 22);
            this.txtNaStatus.TabIndex = 229;
            this.txtNaStatus.Text = "PO";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(13, 145);
            this.lblNaziv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(48, 17);
            this.lblNaziv.TabIndex = 228;
            this.lblNaziv.Text = "Status";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 81);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 17);
            this.label16.TabIndex = 233;
            this.label16.Text = "Datum:";
            // 
            // dtpNaDatNar
            // 
            this.dtpNaDatNar.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpNaDatNar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNaDatNar.Location = new System.Drawing.Point(87, 81);
            this.dtpNaDatNar.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNaDatNar.Name = "dtpNaDatNar";
            this.dtpNaDatNar.ShowUpDown = true;
            this.dtpNaDatNar.Size = new System.Drawing.Size(138, 22);
            this.dtpNaDatNar.TabIndex = 232;
            this.dtpNaDatNar.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // cboNaPartPlac
            // 
            this.cboNaPartPlac.BackColor = System.Drawing.Color.White;
            this.cboNaPartPlac.ForeColor = System.Drawing.Color.Black;
            this.cboNaPartPlac.FormattingEnabled = true;
            this.cboNaPartPlac.Location = new System.Drawing.Point(87, 113);
            this.cboNaPartPlac.Margin = new System.Windows.Forms.Padding(4);
            this.cboNaPartPlac.Name = "cboNaPartPlac";
            this.cboNaPartPlac.Size = new System.Drawing.Size(315, 24);
            this.cboNaPartPlac.TabIndex = 234;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 113);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 17);
            this.label26.TabIndex = 235;
            this.label26.Text = "Platilac:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNaPNote);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNaPOpomba);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNaPKolNar2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtNaPKolNar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNaPem2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNaPEM);
            this.groupBox1.Controls.Add(this.cboNaPSifra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNaPNarZap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1074, 224);
            this.groupBox1.TabIndex = 236;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usluge dogovora";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(910, 111);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 28);
            this.button2.TabIndex = 252;
            this.button2.Text = "Izbriši";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(910, 75);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 28);
            this.button1.TabIndex = 251;
            this.button1.Text = "Promeni";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button11.Location = new System.Drawing.Point(910, 39);
            this.button11.Margin = new System.Windows.Forms.Padding(4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(136, 28);
            this.button11.TabIndex = 250;
            this.button11.Text = "Ubaci";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 125);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 249;
            this.label8.Text = "Beleška:";
            // 
            // txtNaPNote
            // 
            this.txtNaPNote.Location = new System.Drawing.Point(500, 125);
            this.txtNaPNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaPNote.Multiline = true;
            this.txtNaPNote.Name = "txtNaPNote";
            this.txtNaPNote.Size = new System.Drawing.Size(374, 80);
            this.txtNaPNote.TabIndex = 248;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(376, 95);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 17);
            this.label7.TabIndex = 247;
            this.label7.Text = "NHM/Napomena:";
            // 
            // txtNaPOpomba
            // 
            this.txtNaPOpomba.Location = new System.Drawing.Point(500, 95);
            this.txtNaPOpomba.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaPOpomba.Name = "txtNaPOpomba";
            this.txtNaPOpomba.Size = new System.Drawing.Size(374, 22);
            this.txtNaPOpomba.TabIndex = 246;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(701, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 245;
            this.label6.Text = "Količina 2:";
            // 
            // txtNaPKolNar2
            // 
            this.txtNaPKolNar2.Location = new System.Drawing.Point(782, 66);
            this.txtNaPKolNar2.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaPKolNar2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtNaPKolNar2.Name = "txtNaPKolNar2";
            this.txtNaPKolNar2.Size = new System.Drawing.Size(92, 22);
            this.txtNaPKolNar2.TabIndex = 244;
            this.txtNaPKolNar2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(499, 68);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 243;
            this.label11.Text = "Količina:";
            // 
            // txtNaPKolNar
            // 
            this.txtNaPKolNar.Location = new System.Drawing.Point(594, 67);
            this.txtNaPKolNar.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaPKolNar.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtNaPKolNar.Name = "txtNaPKolNar";
            this.txtNaPKolNar.Size = new System.Drawing.Size(92, 22);
            this.txtNaPKolNar.TabIndex = 242;
            this.txtNaPKolNar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(724, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 241;
            this.label5.Text = "JM 2";
            // 
            // txtNaPem2
            // 
            this.txtNaPem2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtNaPem2.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNaPem2.Location = new System.Drawing.Point(782, 36);
            this.txtNaPem2.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaPem2.Name = "txtNaPem2";
            this.txtNaPem2.Size = new System.Drawing.Size(66, 22);
            this.txtNaPem2.TabIndex = 240;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(586, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 239;
            this.label4.Text = "JM";
            // 
            // txtNaPEM
            // 
            this.txtNaPEM.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtNaPEM.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNaPEM.Location = new System.Drawing.Point(620, 37);
            this.txtNaPEM.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaPEM.Name = "txtNaPEM";
            this.txtNaPEM.Size = new System.Drawing.Size(66, 22);
            this.txtNaPEM.TabIndex = 238;
            // 
            // cboNaPSifra
            // 
            this.cboNaPSifra.BackColor = System.Drawing.Color.White;
            this.cboNaPSifra.ForeColor = System.Drawing.Color.Black;
            this.cboNaPSifra.FormattingEnabled = true;
            this.cboNaPSifra.Location = new System.Drawing.Point(259, 37);
            this.cboNaPSifra.Margin = new System.Windows.Forms.Padding(4);
            this.cboNaPSifra.Name = "cboNaPSifra";
            this.cboNaPSifra.Size = new System.Drawing.Size(294, 24);
            this.cboNaPSifra.TabIndex = 236;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 237;
            this.label2.Text = "Usluga:";
            // 
            // txtNaPNarZap
            // 
            this.txtNaPNarZap.Location = new System.Drawing.Point(67, 37);
            this.txtNaPNarZap.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaPNarZap.Name = "txtNaPNarZap";
            this.txtNaPNarZap.Size = new System.Drawing.Size(66, 22);
            this.txtNaPNarZap.TabIndex = 233;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 232;
            this.label1.Text = "Šifra";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(16, 426);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1074, 130);
            this.groupBox2.TabIndex = 237;
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
            this.dataGridView1.Size = new System.Drawing.Size(1060, 95);
            this.dataGridView1.TabIndex = 229;
            // 
            // cboNaNacinDobave
            // 
            this.cboNaNacinDobave.BackColor = System.Drawing.Color.White;
            this.cboNaNacinDobave.ForeColor = System.Drawing.Color.Black;
            this.cboNaNacinDobave.FormattingEnabled = true;
            this.cboNaNacinDobave.Location = new System.Drawing.Point(524, 46);
            this.cboNaNacinDobave.Margin = new System.Windows.Forms.Padding(4);
            this.cboNaNacinDobave.Name = "cboNaNacinDobave";
            this.cboNaNacinDobave.Size = new System.Drawing.Size(286, 24);
            this.cboNaNacinDobave.TabIndex = 238;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(410, 46);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 239;
            this.label9.Text = "Način isporuke:";
            // 
            // cboNaSifObjekt
            // 
            this.cboNaSifObjekt.BackColor = System.Drawing.Color.White;
            this.cboNaSifObjekt.ForeColor = System.Drawing.Color.Black;
            this.cboNaSifObjekt.FormattingEnabled = true;
            this.cboNaSifObjekt.Location = new System.Drawing.Point(524, 78);
            this.cboNaSifObjekt.Margin = new System.Windows.Forms.Padding(4);
            this.cboNaSifObjekt.Name = "cboNaSifObjekt";
            this.cboNaSifObjekt.Size = new System.Drawing.Size(286, 24);
            this.cboNaSifObjekt.TabIndex = 240;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(410, 78);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 17);
            this.label10.TabIndex = 241;
            this.label10.Text = "Tip prevoza:";
            // 
            // txtNaOpomba1
            // 
            this.txtNaOpomba1.Location = new System.Drawing.Point(524, 110);
            this.txtNaOpomba1.Margin = new System.Windows.Forms.Padding(4);
            this.txtNaOpomba1.Multiline = true;
            this.txtNaOpomba1.Name = "txtNaOpomba1";
            this.txtNaOpomba1.Size = new System.Drawing.Size(559, 80);
            this.txtNaOpomba1.TabIndex = 249;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(410, 113);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 17);
            this.label12.TabIndex = 250;
            this.label12.Text = "Napomena:";
            // 
            // frmDogovori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1102, 568);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNaOpomba1);
            this.Controls.Add(this.cboNaSifObjekt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboNaNacinDobave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboNaPartPlac);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtpNaDatNar);
            this.Controls.Add(this.txtNaStNar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNaStatus);
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDogovori";
            this.Text = "Ugovori";
            this.Load += new System.EventHandler(this.frmDogovori_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNaPKolNar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNaPKolNar)).EndInit();
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
        private System.Windows.Forms.TextBox txtNaStNar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNaStatus;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpNaDatNar;
        private System.Windows.Forms.ComboBox cboNaPartPlac;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNaPem2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNaPEM;
        private System.Windows.Forms.ComboBox cboNaPSifra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNaPNarZap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNaPNote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNaPOpomba;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtNaPKolNar2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txtNaPKolNar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboNaNacinDobave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboNaSifObjekt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNaOpomba1;
        private System.Windows.Forms.Label label12;
    }
}