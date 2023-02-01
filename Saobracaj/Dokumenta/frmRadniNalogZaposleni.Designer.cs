namespace Saobracaj.Dokumenta
{
    partial class frmRadniNalogZaposleni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadniNalogZaposleni));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPrvi = new System.Windows.Forms.ToolStripButton();
            this.tsNazad = new System.Windows.Forms.ToolStripButton();
            this.tsNapred = new System.Windows.Forms.ToolStripButton();
            this.tsPoslednja = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.txtVreme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTrase = new System.Windows.Forms.ComboBox();
            this.txtBrojNajave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSifraRN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboZaposleni = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpVremePocetka = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpVremeJavljanja = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.chkDirektnaPrimopredaja = new System.Windows.Forms.CheckBox();
            this.dtpVremeZavrsetka = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpVremePrimopredaja = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnUbaci = new System.Windows.Forms.Button();
            this.txtVoznoVreme = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUkupnoVreme = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtJalovoVremeVV = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtJalovoVreme = new System.Windows.Forms.TextBox();
            this.txtRB = new System.Windows.Forms.TextBox();
            this.chkMasinovodja = new System.Windows.Forms.CheckBox();
            this.chkPomocnik = new System.Windows.Forms.CheckBox();
            this.chkVozovodja = new System.Windows.Forms.CheckBox();
            this.chkPregledac = new System.Windows.Forms.CheckBox();
            this.txtRBTrase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboAktivnost = new System.Windows.Forms.ComboBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
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
            this.toolStripSeparator1,
            this.tsPrvi,
            this.tsNazad,
            this.tsNapred,
            this.tsPoslednja,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1619, 27);
            this.toolStrip1.TabIndex = 47;
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
            // tsPrvi
            // 
            this.tsPrvi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPrvi.Image = ((System.Drawing.Image)(resources.GetObject("tsPrvi.Image")));
            this.tsPrvi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrvi.Name = "tsPrvi";
            this.tsPrvi.Size = new System.Drawing.Size(29, 24);
            this.tsPrvi.Text = "toolStripButton1";
            // 
            // tsNazad
            // 
            this.tsNazad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNazad.Image = ((System.Drawing.Image)(resources.GetObject("tsNazad.Image")));
            this.tsNazad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNazad.Name = "tsNazad";
            this.tsNazad.Size = new System.Drawing.Size(29, 24);
            this.tsNazad.Text = "toolStripButton1";
            // 
            // tsNapred
            // 
            this.tsNapred.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNapred.Image = ((System.Drawing.Image)(resources.GetObject("tsNapred.Image")));
            this.tsNapred.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNapred.Name = "tsNapred";
            this.tsNapred.Size = new System.Drawing.Size(29, 24);
            this.tsNapred.Text = "toolStripButton1";
            // 
            // tsPoslednja
            // 
            this.tsPoslednja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPoslednja.Image = ((System.Drawing.Image)(resources.GetObject("tsPoslednja.Image")));
            this.tsPoslednja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPoslednja.Name = "tsPoslednja";
            this.tsPoslednja.Size = new System.Drawing.Size(29, 24);
            this.tsPoslednja.Text = "toolStripButton1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(159, 24);
            this.toolStripButton1.Text = "Kalendar zaposleni";
            // 
            // txtVreme
            // 
            this.txtVreme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtVreme.Location = new System.Drawing.Point(285, 100);
            this.txtVreme.Margin = new System.Windows.Forms.Padding(4);
            this.txtVreme.Name = "txtVreme";
            this.txtVreme.Size = new System.Drawing.Size(71, 22);
            this.txtVreme.TabIndex = 88;
            this.txtVreme.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 87;
            this.label5.Text = "Ukupno:";
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeDo.Location = new System.Drawing.Point(104, 112);
            this.dtpVremeDo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.ShowUpDown = true;
            this.dtpVremeDo.Size = new System.Drawing.Size(149, 22);
            this.dtpVremeDo.TabIndex = 4;
            this.dtpVremeDo.Leave += new System.EventHandler(this.dtpVremeDo_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 108);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 17);
            this.label15.TabIndex = 85;
            this.label15.Text = "Planirano do:";
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeOd.Location = new System.Drawing.Point(105, 80);
            this.dtpVremeOd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.ShowUpDown = true;
            this.dtpVremeOd.Size = new System.Drawing.Size(148, 22);
            this.dtpVremeOd.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(17, 80);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 17);
            this.label21.TabIndex = 83;
            this.label21.Text = "Planirano od:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 80;
            this.label3.Text = "Trasa:";
            // 
            // cboTrase
            // 
            this.cboTrase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboTrase.FormattingEnabled = true;
            this.cboTrase.Location = new System.Drawing.Point(413, 41);
            this.cboTrase.Margin = new System.Windows.Forms.Padding(4);
            this.cboTrase.Name = "cboTrase";
            this.cboTrase.Size = new System.Drawing.Size(213, 24);
            this.cboTrase.TabIndex = 79;
            // 
            // txtBrojNajave
            // 
            this.txtBrojNajave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBrojNajave.Location = new System.Drawing.Point(285, 44);
            this.txtBrojNajave.Margin = new System.Windows.Forms.Padding(4);
            this.txtBrojNajave.Name = "txtBrojNajave";
            this.txtBrojNajave.Size = new System.Drawing.Size(61, 22);
            this.txtBrojNajave.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 77;
            this.label1.Text = "Šifra RN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 78;
            this.label2.Text = "Broj vožnje:";
            // 
            // txtSifraRN
            // 
            this.txtSifraRN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSifraRN.Location = new System.Drawing.Point(84, 47);
            this.txtSifraRN.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifraRN.Name = "txtSifraRN";
            this.txtSifraRN.Size = new System.Drawing.Size(69, 22);
            this.txtSifraRN.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(640, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 90;
            this.label6.Text = "Zaposleni:";
            // 
            // cboZaposleni
            // 
            this.cboZaposleni.BackColor = System.Drawing.Color.White;
            this.cboZaposleni.FormattingEnabled = true;
            this.cboZaposleni.Location = new System.Drawing.Point(723, 41);
            this.cboZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.cboZaposleni.Name = "cboZaposleni";
            this.cboZaposleni.Size = new System.Drawing.Size(227, 24);
            this.cboZaposleni.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(21, 156);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1410, 310);
            this.tabControl1.TabIndex = 91;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1402, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Planirani zaposleni";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 7);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1383, 263);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // dtpVremePocetka
            // 
            this.dtpVremePocetka.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremePocetka.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremePocetka.Location = new System.Drawing.Point(21, 558);
            this.dtpVremePocetka.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremePocetka.Name = "dtpVremePocetka";
            this.dtpVremePocetka.ShowUpDown = true;
            this.dtpVremePocetka.Size = new System.Drawing.Size(149, 22);
            this.dtpVremePocetka.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 538);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 17);
            this.label7.TabIndex = 94;
            this.label7.Text = "Vreme početka vožnje:";
            // 
            // dtpVremeJavljanja
            // 
            this.dtpVremeJavljanja.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeJavljanja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeJavljanja.Location = new System.Drawing.Point(21, 510);
            this.dtpVremeJavljanja.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeJavljanja.Name = "dtpVremeJavljanja";
            this.dtpVremeJavljanja.ShowUpDown = true;
            this.dtpVremeJavljanja.Size = new System.Drawing.Size(148, 22);
            this.dtpVremeJavljanja.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 490);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 17);
            this.label8.TabIndex = 92;
            this.label8.Text = "Vreme javljanja u OJ:";
            // 
            // chkDirektnaPrimopredaja
            // 
            this.chkDirektnaPrimopredaja.AutoSize = true;
            this.chkDirektnaPrimopredaja.Location = new System.Drawing.Point(21, 591);
            this.chkDirektnaPrimopredaja.Margin = new System.Windows.Forms.Padding(4);
            this.chkDirektnaPrimopredaja.Name = "chkDirektnaPrimopredaja";
            this.chkDirektnaPrimopredaja.Size = new System.Drawing.Size(171, 21);
            this.chkDirektnaPrimopredaja.TabIndex = 17;
            this.chkDirektnaPrimopredaja.Text = "Direktna Primopredaja";
            this.chkDirektnaPrimopredaja.UseVisualStyleBackColor = true;
            // 
            // dtpVremeZavrsetka
            // 
            this.dtpVremeZavrsetka.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeZavrsetka.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeZavrsetka.Location = new System.Drawing.Point(21, 683);
            this.dtpVremeZavrsetka.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeZavrsetka.Name = "dtpVremeZavrsetka";
            this.dtpVremeZavrsetka.ShowUpDown = true;
            this.dtpVremeZavrsetka.Size = new System.Drawing.Size(149, 22);
            this.dtpVremeZavrsetka.TabIndex = 19;
            this.dtpVremeZavrsetka.Leave += new System.EventHandler(this.dtpVremeZavrsetka_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 663);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 17);
            this.label9.TabIndex = 99;
            this.label9.Text = "Vreme povratka u OJ:";
            // 
            // dtpVremePrimopredaja
            // 
            this.dtpVremePrimopredaja.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremePrimopredaja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremePrimopredaja.Location = new System.Drawing.Point(21, 635);
            this.dtpVremePrimopredaja.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremePrimopredaja.Name = "dtpVremePrimopredaja";
            this.dtpVremePrimopredaja.ShowUpDown = true;
            this.dtpVremePrimopredaja.Size = new System.Drawing.Size(148, 22);
            this.dtpVremePrimopredaja.TabIndex = 18;
            this.dtpVremePrimopredaja.Leave += new System.EventHandler(this.dtpVremePrimopredaja_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 615);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 17);
            this.label10.TabIndex = 97;
            this.label10.Text = "Vreme Završetka vožnje:";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(389, 474);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1213, 292);
            this.tabControl2.TabIndex = 101;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1205, 263);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Evidencija rada po RN";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 7);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(1187, 245);
            this.dataGridView2.TabIndex = 9;
            // 
            // btnUbaci
            // 
            this.btnUbaci.Location = new System.Drawing.Point(21, 715);
            this.btnUbaci.Margin = new System.Windows.Forms.Padding(4);
            this.btnUbaci.Name = "btnUbaci";
            this.btnUbaci.Size = new System.Drawing.Size(336, 36);
            this.btnUbaci.TabIndex = 20;
            this.btnUbaci.Text = "UBACI";
            this.btnUbaci.UseVisualStyleBackColor = true;
            this.btnUbaci.Click += new System.EventHandler(this.btnUbaci_Click);
            // 
            // txtVoznoVreme
            // 
            this.txtVoznoVreme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtVoznoVreme.Location = new System.Drawing.Point(224, 508);
            this.txtVoznoVreme.Margin = new System.Windows.Forms.Padding(4);
            this.txtVoznoVreme.Name = "txtVoznoVreme";
            this.txtVoznoVreme.Size = new System.Drawing.Size(132, 22);
            this.txtVoznoVreme.TabIndex = 103;
            this.txtVoznoVreme.Leave += new System.EventHandler(this.txtVoznoVreme_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 490);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 17);
            this.label11.TabIndex = 104;
            this.label11.Text = "Vozno vreme:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 537);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 17);
            this.label12.TabIndex = 106;
            this.label12.Text = "Vreme trajanja smene:";
            // 
            // txtUkupnoVreme
            // 
            this.txtUkupnoVreme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUkupnoVreme.Location = new System.Drawing.Point(224, 561);
            this.txtUkupnoVreme.Margin = new System.Windows.Forms.Padding(4);
            this.txtUkupnoVreme.Name = "txtUkupnoVreme";
            this.txtUkupnoVreme.Size = new System.Drawing.Size(132, 22);
            this.txtUkupnoVreme.TabIndex = 105;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(184, 663);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(172, 17);
            this.label13.TabIndex = 110;
            this.label13.Text = "Jalovo vreme van vožnje :";
            // 
            // txtJalovoVremeVV
            // 
            this.txtJalovoVremeVV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtJalovoVremeVV.Location = new System.Drawing.Point(224, 683);
            this.txtJalovoVremeVV.Margin = new System.Windows.Forms.Padding(4);
            this.txtJalovoVremeVV.Name = "txtJalovoVremeVV";
            this.txtJalovoVremeVV.Size = new System.Drawing.Size(132, 22);
            this.txtJalovoVremeVV.TabIndex = 109;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(188, 615);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(183, 17);
            this.label14.TabIndex = 108;
            this.label14.Text = "Jalovo vreme tokom vožnje:";
            // 
            // txtJalovoVreme
            // 
            this.txtJalovoVreme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtJalovoVreme.Location = new System.Drawing.Point(224, 635);
            this.txtJalovoVreme.Margin = new System.Windows.Forms.Padding(4);
            this.txtJalovoVreme.Name = "txtJalovoVreme";
            this.txtJalovoVreme.Size = new System.Drawing.Size(132, 22);
            this.txtJalovoVreme.TabIndex = 107;
            // 
            // txtRB
            // 
            this.txtRB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRB.Location = new System.Drawing.Point(163, 47);
            this.txtRB.Margin = new System.Windows.Forms.Padding(4);
            this.txtRB.Name = "txtRB";
            this.txtRB.Size = new System.Drawing.Size(37, 22);
            this.txtRB.TabIndex = 111;
            // 
            // chkMasinovodja
            // 
            this.chkMasinovodja.AutoSize = true;
            this.chkMasinovodja.Checked = true;
            this.chkMasinovodja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMasinovodja.Location = new System.Drawing.Point(617, 116);
            this.chkMasinovodja.Margin = new System.Windows.Forms.Padding(4);
            this.chkMasinovodja.Name = "chkMasinovodja";
            this.chkMasinovodja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMasinovodja.Size = new System.Drawing.Size(106, 21);
            this.chkMasinovodja.TabIndex = 139;
            this.chkMasinovodja.Text = "Mašinovođa";
            this.chkMasinovodja.UseVisualStyleBackColor = true;
            // 
            // chkPomocnik
            // 
            this.chkPomocnik.AutoSize = true;
            this.chkPomocnik.Location = new System.Drawing.Point(753, 116);
            this.chkPomocnik.Margin = new System.Windows.Forms.Padding(4);
            this.chkPomocnik.Name = "chkPomocnik";
            this.chkPomocnik.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPomocnik.Size = new System.Drawing.Size(91, 21);
            this.chkPomocnik.TabIndex = 140;
            this.chkPomocnik.Text = "Pomoćnik";
            this.chkPomocnik.UseVisualStyleBackColor = true;
            // 
            // chkVozovodja
            // 
            this.chkVozovodja.AutoSize = true;
            this.chkVozovodja.Location = new System.Drawing.Point(872, 116);
            this.chkVozovodja.Margin = new System.Windows.Forms.Padding(4);
            this.chkVozovodja.Name = "chkVozovodja";
            this.chkVozovodja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVozovodja.Size = new System.Drawing.Size(93, 21);
            this.chkVozovodja.TabIndex = 141;
            this.chkVozovodja.Text = "Vozovođa";
            this.chkVozovodja.UseVisualStyleBackColor = true;
            // 
            // chkPregledac
            // 
            this.chkPregledac.AutoSize = true;
            this.chkPregledac.Location = new System.Drawing.Point(997, 112);
            this.chkPregledac.Margin = new System.Windows.Forms.Padding(4);
            this.chkPregledac.Name = "chkPregledac";
            this.chkPregledac.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPregledac.Size = new System.Drawing.Size(94, 21);
            this.chkPregledac.TabIndex = 142;
            this.chkPregledac.Text = "Pregledač";
            this.chkPregledac.UseVisualStyleBackColor = true;
            this.chkPregledac.CheckedChanged += new System.EventHandler(this.chkPregledac_CheckedChanged);
            // 
            // txtRBTrase
            // 
            this.txtRBTrase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRBTrase.Location = new System.Drawing.Point(1047, 38);
            this.txtRBTrase.Margin = new System.Windows.Forms.Padding(4);
            this.txtRBTrase.Name = "txtRBTrase";
            this.txtRBTrase.Size = new System.Drawing.Size(61, 22);
            this.txtRBTrase.TabIndex = 143;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(967, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 144;
            this.label4.Text = "RB trase:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(643, 80);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 17);
            this.label16.TabIndex = 176;
            this.label16.Text = "Aktivnost:";
            // 
            // cboAktivnost
            // 
            this.cboAktivnost.FormattingEnabled = true;
            this.cboAktivnost.Location = new System.Drawing.Point(723, 76);
            this.cboAktivnost.Margin = new System.Windows.Forms.Padding(4);
            this.cboAktivnost.Name = "cboAktivnost";
            this.cboAktivnost.Size = new System.Drawing.Size(385, 24);
            this.cboAktivnost.TabIndex = 175;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(1439, 181);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(164, 281);
            this.dataGridView3.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1439, 156);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 17);
            this.label17.TabIndex = 177;
            this.label17.Text = "Predviđene aktivnosti:";
            // 
            // txtNapomena
            // 
            this.txtNapomena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNapomena.Location = new System.Drawing.Point(1148, 45);
            this.txtNapomena.Margin = new System.Windows.Forms.Padding(4);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(447, 109);
            this.txtNapomena.TabIndex = 179;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1145, 24);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 17);
            this.label18.TabIndex = 178;
            this.label18.Text = "Napomena:";
            // 
            // frmRadniNalogZaposleni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1619, 763);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cboAktivnost);
            this.Controls.Add(this.txtRBTrase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkPregledac);
            this.Controls.Add(this.chkVozovodja);
            this.Controls.Add(this.chkPomocnik);
            this.Controls.Add(this.chkMasinovodja);
            this.Controls.Add(this.txtRB);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtJalovoVremeVV);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtJalovoVreme);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUkupnoVreme);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtVoznoVreme);
            this.Controls.Add(this.btnUbaci);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.dtpVremeZavrsetka);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpVremePrimopredaja);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkDirektnaPrimopredaja);
            this.Controls.Add(this.dtpVremePocetka);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpVremeJavljanja);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboZaposleni);
            this.Controls.Add(this.txtVreme);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpVremeDo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpVremeOd);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTrase);
            this.Controls.Add(this.txtBrojNajave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSifraRN);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRadniNalogZaposleni";
            this.Text = "Radni nalog osoblje ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRadniNalogZaposleni_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsPrvi;
        private System.Windows.Forms.ToolStripButton tsNazad;
        private System.Windows.Forms.ToolStripButton tsNapred;
        private System.Windows.Forms.ToolStripButton tsPoslednja;
        private System.Windows.Forms.TextBox txtVreme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTrase;
        private System.Windows.Forms.TextBox txtBrojNajave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSifraRN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboZaposleni;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpVremePocetka;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpVremeJavljanja;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkDirektnaPrimopredaja;
        private System.Windows.Forms.DateTimePicker dtpVremeZavrsetka;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpVremePrimopredaja;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnUbaci;
        private System.Windows.Forms.TextBox txtVoznoVreme;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUkupnoVreme;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtJalovoVremeVV;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtJalovoVreme;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox txtRB;
        private System.Windows.Forms.CheckBox chkMasinovodja;
        private System.Windows.Forms.CheckBox chkPomocnik;
        private System.Windows.Forms.CheckBox chkVozovodja;
        private System.Windows.Forms.CheckBox chkPregledac;
        private System.Windows.Forms.TextBox txtRBTrase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboAktivnost;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.Label label18;
    }
}