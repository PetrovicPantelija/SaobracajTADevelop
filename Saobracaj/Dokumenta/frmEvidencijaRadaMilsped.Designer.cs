namespace Saobracaj.Dokumenta
{
    partial class frmEvidencijaRadaMilsped
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvidencijaRadaMilsped));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPrvi = new System.Windows.Forms.ToolStripButton();
            this.tsNazad = new System.Windows.Forms.ToolStripButton();
            this.tsNapred = new System.Windows.Forms.ToolStripButton();
            this.tsPoslednja = new System.Windows.Forms.ToolStripButton();
            this.txtRad = new System.Windows.Forms.NumericUpDown();
            this.txtMesto = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtKartica = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtRacun = new System.Windows.Forms.TextBox();
            this.chkPlaceno = new System.Windows.Forms.CheckBox();
            this.chkPoslatMail = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnPosaljiMail = new System.Windows.Forms.Button();
            this.txtOznaka = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chkUnosMasinovođa = new System.Windows.Forms.CheckBox();
            this.txtUkupnoMašinovođa = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboVozilo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboNalogodavac = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRazlog = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBrojVagona = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtDodatnaNapomena = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboAktivnost = new System.Windows.Forms.ComboBox();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboZaposleni = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKoeficijent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVreme = new System.Windows.Forms.TextBox();
            this.txtTrosak = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.btnUbaciAktivnost = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKomentar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboRadniNalog = new System.Windows.Forms.ComboBox();
            this.dtpStavke = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.toolStripSeparator1,
            this.tsPrvi,
            this.tsNazad,
            this.tsNapred,
            this.tsPoslednja});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1536, 27);
            this.toolStrip1.TabIndex = 308;
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
            // txtRad
            // 
            this.txtRad.DecimalPlaces = 2;
            this.txtRad.Location = new System.Drawing.Point(665, 167);
            this.txtRad.Margin = new System.Windows.Forms.Padding(4);
            this.txtRad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtRad.Name = "txtRad";
            this.txtRad.Size = new System.Drawing.Size(92, 22);
            this.txtRad.TabIndex = 361;
            this.txtRad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMesto
            // 
            this.txtMesto.Location = new System.Drawing.Point(480, 103);
            this.txtMesto.Margin = new System.Windows.Forms.Padding(4);
            this.txtMesto.Name = "txtMesto";
            this.txtMesto.Size = new System.Drawing.Size(159, 22);
            this.txtMesto.TabIndex = 360;
            this.txtMesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(420, 106);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 17);
            this.label22.TabIndex = 359;
            this.label22.Text = "Mesto:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(409, 144);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 17);
            this.label20.TabIndex = 357;
            this.label20.Text = "Kartica:";
            // 
            // txtKartica
            // 
            this.txtKartica.Location = new System.Drawing.Point(475, 140);
            this.txtKartica.Margin = new System.Windows.Forms.Padding(4);
            this.txtKartica.Name = "txtKartica";
            this.txtKartica.Size = new System.Drawing.Size(63, 22);
            this.txtKartica.TabIndex = 358;
            this.txtKartica.Text = "0";
            this.txtKartica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(209, 144);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 17);
            this.label19.TabIndex = 355;
            this.label19.Text = "Trošak računi:";
            // 
            // txtRacun
            // 
            this.txtRacun.Location = new System.Drawing.Point(317, 138);
            this.txtRacun.Margin = new System.Windows.Forms.Padding(4);
            this.txtRacun.Name = "txtRacun";
            this.txtRacun.Size = new System.Drawing.Size(63, 22);
            this.txtRacun.TabIndex = 356;
            this.txtRacun.Text = "0";
            this.txtRacun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkPlaceno
            // 
            this.chkPlaceno.AutoSize = true;
            this.chkPlaceno.Location = new System.Drawing.Point(715, 138);
            this.chkPlaceno.Margin = new System.Windows.Forms.Padding(4);
            this.chkPlaceno.Name = "chkPlaceno";
            this.chkPlaceno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPlaceno.Size = new System.Drawing.Size(81, 21);
            this.chkPlaceno.TabIndex = 354;
            this.chkPlaceno.Text = "Plaćeno";
            this.chkPlaceno.UseVisualStyleBackColor = true;
            // 
            // chkPoslatMail
            // 
            this.chkPoslatMail.AutoSize = true;
            this.chkPoslatMail.Location = new System.Drawing.Point(565, 139);
            this.chkPoslatMail.Margin = new System.Windows.Forms.Padding(4);
            this.chkPoslatMail.Name = "chkPoslatMail";
            this.chkPoslatMail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPoslatMail.Size = new System.Drawing.Size(107, 21);
            this.chkPoslatMail.TabIndex = 353;
            this.chkPoslatMail.Text = "Poslat Email";
            this.chkPoslatMail.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1263, 206);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 17);
            this.label18.TabIndex = 352;
            this.label18.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(1309, 204);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(271, 22);
            this.txtEmail.TabIndex = 351;
            // 
            // btnPosaljiMail
            // 
            this.btnPosaljiMail.Location = new System.Drawing.Point(1309, 233);
            this.btnPosaljiMail.Margin = new System.Windows.Forms.Padding(4);
            this.btnPosaljiMail.Name = "btnPosaljiMail";
            this.btnPosaljiMail.Size = new System.Drawing.Size(272, 30);
            this.btnPosaljiMail.TabIndex = 350;
            this.btnPosaljiMail.Text = "Pošalji mail";
            this.btnPosaljiMail.UseVisualStyleBackColor = true;
            this.btnPosaljiMail.Click += new System.EventHandler(this.btnPosaljiMail_Click);
            // 
            // txtOznaka
            // 
            this.txtOznaka.Location = new System.Drawing.Point(104, 106);
            this.txtOznaka.Margin = new System.Windows.Forms.Padding(4);
            this.txtOznaka.Name = "txtOznaka";
            this.txtOznaka.Size = new System.Drawing.Size(68, 22);
            this.txtOznaka.TabIndex = 348;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 106);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 17);
            this.label17.TabIndex = 349;
            this.label17.Text = "Broj ot/pr:";
            // 
            // chkUnosMasinovođa
            // 
            this.chkUnosMasinovođa.AutoSize = true;
            this.chkUnosMasinovođa.Location = new System.Drawing.Point(708, 103);
            this.chkUnosMasinovođa.Margin = new System.Windows.Forms.Padding(4);
            this.chkUnosMasinovođa.Name = "chkUnosMasinovođa";
            this.chkUnosMasinovođa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUnosMasinovođa.Size = new System.Drawing.Size(162, 21);
            this.chkUnosMasinovođa.TabIndex = 347;
            this.chkUnosMasinovođa.Text = "Unos za mašinovođu";
            this.chkUnosMasinovođa.UseVisualStyleBackColor = true;
            // 
            // txtUkupnoMašinovođa
            // 
            this.txtUkupnoMašinovođa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUkupnoMašinovođa.Location = new System.Drawing.Point(1043, 102);
            this.txtUkupnoMašinovođa.Margin = new System.Windows.Forms.Padding(4);
            this.txtUkupnoMašinovođa.Name = "txtUkupnoMašinovođa";
            this.txtUkupnoMašinovođa.Size = new System.Drawing.Size(56, 22);
            this.txtUkupnoMašinovođa.TabIndex = 346;
            this.txtUkupnoMašinovođa.Text = "0";
            this.txtUkupnoMašinovođa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(899, 105);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(141, 17);
            this.label16.TabIndex = 345;
            this.label16.Text = "Ukupno mašinovođa:";
            // 
            // cboVozilo
            // 
            this.cboVozilo.FormattingEnabled = true;
            this.cboVozilo.Items.AddRange(new object[] {
            "privatno vozilo",
            "501 L  GE ",
            "501 L  ZW",
            "501 L  VA",
            "501 L  SK",
            "501 L  MF",
            "501 L  PN",
            "501 L  PM",
            "501 L  PO",
            "501 L  RV",
            "501 L  RU",
            "501 L  OU",
            "501 L  OZ",
            "501 L  GD"});
            this.cboVozilo.Location = new System.Drawing.Point(1043, 233);
            this.cboVozilo.Margin = new System.Windows.Forms.Padding(4);
            this.cboVozilo.Name = "cboVozilo";
            this.cboVozilo.Size = new System.Drawing.Size(211, 24);
            this.cboVozilo.TabIndex = 344;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(927, 236);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 17);
            this.label14.TabIndex = 343;
            this.label14.Text = "Vozilo:";
            // 
            // cboNalogodavac
            // 
            this.cboNalogodavac.FormattingEnabled = true;
            this.cboNalogodavac.Location = new System.Drawing.Point(1043, 199);
            this.cboNalogodavac.Margin = new System.Windows.Forms.Padding(4);
            this.cboNalogodavac.Name = "cboNalogodavac";
            this.cboNalogodavac.Size = new System.Drawing.Size(211, 24);
            this.cboNalogodavac.TabIndex = 342;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(927, 203);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 17);
            this.label13.TabIndex = 341;
            this.label13.Text = "Nalogodavac:";
            // 
            // txtRazlog
            // 
            this.txtRazlog.Location = new System.Drawing.Point(680, 233);
            this.txtRazlog.Margin = new System.Windows.Forms.Padding(4);
            this.txtRazlog.Name = "txtRazlog";
            this.txtRazlog.Size = new System.Drawing.Size(233, 22);
            this.txtRazlog.TabIndex = 339;
            this.txtRazlog.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(587, 233);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 17);
            this.label12.TabIndex = 340;
            this.label12.Text = "Razlog";
            // 
            // txtBrojVagona
            // 
            this.txtBrojVagona.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBrojVagona.Location = new System.Drawing.Point(680, 202);
            this.txtBrojVagona.Margin = new System.Windows.Forms.Padding(4);
            this.txtBrojVagona.Name = "txtBrojVagona";
            this.txtBrojVagona.Size = new System.Drawing.Size(76, 22);
            this.txtBrojVagona.TabIndex = 337;
            this.txtBrojVagona.Text = "0";
            this.txtBrojVagona.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(587, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 338;
            this.label2.Text = "Broj vagona:";
            // 
            // btnUnesi
            // 
            this.btnUnesi.Location = new System.Drawing.Point(539, 203);
            this.btnUnesi.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(43, 487);
            this.btnUnesi.TabIndex = 336;
            this.btnUnesi.Text = ">>";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUbaciAktivnost_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 170);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 17);
            this.label11.TabIndex = 335;
            this.label11.Text = "Aktivnost:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(15, 203);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(516, 487);
            this.dataGridView2.TabIndex = 334;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(589, 315);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(992, 375);
            this.dataGridView1.TabIndex = 333;
            // 
            // txtDodatnaNapomena
            // 
            this.txtDodatnaNapomena.Location = new System.Drawing.Point(1043, 170);
            this.txtDodatnaNapomena.Margin = new System.Windows.Forms.Padding(4);
            this.txtDodatnaNapomena.Name = "txtDodatnaNapomena";
            this.txtDodatnaNapomena.Size = new System.Drawing.Size(277, 22);
            this.txtDodatnaNapomena.TabIndex = 331;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(903, 169);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 17);
            this.label10.TabIndex = 332;
            this.label10.Text = "Dodatno napomena";
            // 
            // cboAktivnost
            // 
            this.cboAktivnost.FormattingEnabled = true;
            this.cboAktivnost.Location = new System.Drawing.Point(95, 170);
            this.cboAktivnost.Margin = new System.Windows.Forms.Padding(4);
            this.cboAktivnost.Name = "cboAktivnost";
            this.cboAktivnost.Size = new System.Drawing.Size(435, 24);
            this.cboAktivnost.TabIndex = 322;
            this.cboAktivnost.Leave += new System.EventHandler(this.cboAktivnost_Leave);
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(104, 73);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(68, 22);
            this.txtSifra.TabIndex = 309;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 310;
            this.label1.Text = "Šifra zapisa:";
            // 
            // cboZaposleni
            // 
            this.cboZaposleni.FormattingEnabled = true;
            this.cboZaposleni.Location = new System.Drawing.Point(268, 71);
            this.cboZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.cboZaposleni.Name = "cboZaposleni";
            this.cboZaposleni.Size = new System.Drawing.Size(211, 24);
            this.cboZaposleni.TabIndex = 312;
            this.cboZaposleni.Leave += new System.EventHandler(this.cboZaposleni_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 311;
            this.label4.Text = "Zaposleni:";
            // 
            // txtKoeficijent
            // 
            this.txtKoeficijent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtKoeficijent.Location = new System.Drawing.Point(852, 170);
            this.txtKoeficijent.Margin = new System.Windows.Forms.Padding(4);
            this.txtKoeficijent.Name = "txtKoeficijent";
            this.txtKoeficijent.Size = new System.Drawing.Size(41, 22);
            this.txtKoeficijent.TabIndex = 329;
            this.txtKoeficijent.Text = "100";
            this.txtKoeficijent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(765, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 330;
            this.label5.Text = "Koeficijent:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 317;
            this.label6.Text = "Dodatni trošak:";
            // 
            // txtVreme
            // 
            this.txtVreme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtVreme.Location = new System.Drawing.Point(1043, 68);
            this.txtVreme.Margin = new System.Windows.Forms.Padding(4);
            this.txtVreme.Name = "txtVreme";
            this.txtVreme.Size = new System.Drawing.Size(56, 22);
            this.txtVreme.TabIndex = 328;
            this.txtVreme.Text = "0";
            this.txtVreme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTrosak
            // 
            this.txtTrosak.Location = new System.Drawing.Point(124, 138);
            this.txtTrosak.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrosak.Name = "txtTrosak";
            this.txtTrosak.Size = new System.Drawing.Size(63, 22);
            this.txtTrosak.TabIndex = 318;
            this.txtTrosak.Text = "0";
            this.txtTrosak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 314;
            this.label3.Text = "Rad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(971, 68);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 327;
            this.label9.Text = "Ukupno:";
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeDo.Location = new System.Drawing.Point(809, 69);
            this.dtpVremeDo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.ShowUpDown = true;
            this.dtpVremeDo.Size = new System.Drawing.Size(152, 22);
            this.dtpVremeDo.TabIndex = 324;
            this.dtpVremeDo.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpVremeDo.Leave += new System.EventHandler(this.dtpVremeDo_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(728, 70);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 17);
            this.label15.TabIndex = 326;
            this.label15.Text = "Period do:";
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeOd.Location = new System.Drawing.Point(576, 70);
            this.dtpVremeOd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.ShowUpDown = true;
            this.dtpVremeOd.Size = new System.Drawing.Size(143, 22);
            this.dtpVremeOd.TabIndex = 323;
            this.dtpVremeOd.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(495, 70);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 17);
            this.label21.TabIndex = 325;
            this.label21.Text = "Period od:";
            // 
            // btnUbaciAktivnost
            // 
            this.btnUbaciAktivnost.Location = new System.Drawing.Point(1340, 167);
            this.btnUbaciAktivnost.Margin = new System.Windows.Forms.Padding(4);
            this.btnUbaciAktivnost.Name = "btnUbaciAktivnost";
            this.btnUbaciAktivnost.Size = new System.Drawing.Size(191, 30);
            this.btnUbaciAktivnost.TabIndex = 321;
            this.btnUbaciAktivnost.Text = "Unesi po satu";
            this.btnUbaciAktivnost.UseVisualStyleBackColor = true;
            this.btnUbaciAktivnost.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1133, 53);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 17);
            this.label7.TabIndex = 320;
            this.label7.Text = "Dodatne beleške:";
            // 
            // txtKomentar
            // 
            this.txtKomentar.Location = new System.Drawing.Point(1132, 73);
            this.txtKomentar.Margin = new System.Windows.Forms.Padding(4);
            this.txtKomentar.Multiline = true;
            this.txtKomentar.Name = "txtKomentar";
            this.txtKomentar.Size = new System.Drawing.Size(444, 83);
            this.txtKomentar.TabIndex = 319;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(179, 106);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 316;
            this.label8.Text = "Radni nalog:";
            // 
            // cboRadniNalog
            // 
            this.cboRadniNalog.FormattingEnabled = true;
            this.cboRadniNalog.Location = new System.Drawing.Point(268, 105);
            this.cboRadniNalog.Margin = new System.Windows.Forms.Padding(4);
            this.cboRadniNalog.Name = "cboRadniNalog";
            this.cboRadniNalog.Size = new System.Drawing.Size(143, 24);
            this.cboRadniNalog.TabIndex = 315;
            // 
            // dtpStavke
            // 
            this.dtpStavke.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpStavke.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStavke.Location = new System.Drawing.Point(728, 265);
            this.dtpStavke.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStavke.Name = "dtpStavke";
            this.dtpStavke.ShowUpDown = true;
            this.dtpStavke.Size = new System.Drawing.Size(165, 22);
            this.dtpStavke.TabIndex = 362;
            this.dtpStavke.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(608, 265);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(113, 17);
            this.label29.TabIndex = 363;
            this.label29.Text = "Vreme izvršenja:";
            // 
            // frmEvidencijaRadaMilsped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1536, 718);
            this.Controls.Add(this.dtpStavke);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txtRad);
            this.Controls.Add(this.txtMesto);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtKartica);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtRacun);
            this.Controls.Add(this.chkPlaceno);
            this.Controls.Add(this.chkPoslatMail);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnPosaljiMail);
            this.Controls.Add(this.txtOznaka);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.chkUnosMasinovođa);
            this.Controls.Add(this.txtUkupnoMašinovođa);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cboVozilo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboNalogodavac);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtRazlog);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBrojVagona);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUnesi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDodatnaNapomena);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboAktivnost);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboZaposleni);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKoeficijent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtVreme);
            this.Controls.Add(this.txtTrosak);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpVremeDo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpVremeOd);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnUbaciAktivnost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtKomentar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboRadniNalog);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEvidencijaRadaMilsped";
            this.Text = "Evidencija rada milsped";
            this.Load += new System.EventHandler(this.frmEvidencijaRada_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.ToolStripButton tsPrvi;
        private System.Windows.Forms.ToolStripButton tsNazad;
        private System.Windows.Forms.ToolStripButton tsNapred;
        private System.Windows.Forms.ToolStripButton tsPoslednja;
        private System.Windows.Forms.NumericUpDown txtRad;
        private System.Windows.Forms.TextBox txtMesto;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtKartica;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtRacun;
        private System.Windows.Forms.CheckBox chkPlaceno;
        private System.Windows.Forms.CheckBox chkPoslatMail;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnPosaljiMail;
        private System.Windows.Forms.TextBox txtOznaka;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkUnosMasinovođa;
        private System.Windows.Forms.TextBox txtUkupnoMašinovođa;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboVozilo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboNalogodavac;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRazlog;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBrojVagona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDodatnaNapomena;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboAktivnost;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboZaposleni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKoeficijent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVreme;
        private System.Windows.Forms.TextBox txtTrosak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnUbaciAktivnost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKomentar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboRadniNalog;
        private System.Windows.Forms.DateTimePicker dtpStavke;
        private System.Windows.Forms.Label label29;
    }
}