namespace Testiranje.Dokumeta
{
    partial class frmPrijemKontejneraKamionom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrijemKontejneraKamionom));
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpDatumPrijema = new System.Windows.Forms.DateTimePicker();
            this.cboStatusPrijema = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBrojKontejnera = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegBrKamiona = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImeVozaca = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPosiljalac = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPrimalac = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboVlasnikKontejnera = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipKontejnera = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboVrstaRobe = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboStatusKontejnera = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBrojPlombe = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPlaniraniLager = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboBukingOtpreme = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpVremeOdlaska = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpVremePripremljen = new System.Windows.Forms.DateTimePicker();
            this.dtpVremeDolaska = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnManipulacija = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPrvi = new System.Windows.Forms.ToolStripButton();
            this.tsNazad = new System.Windows.Forms.ToolStripButton();
            this.tsNapred = new System.Windows.Forms.ToolStripButton();
            this.tsPoslednja = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.txtNeto = new System.Windows.Forms.NumericUpDown();
            this.txtTara = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnPosaljiMail = new System.Windows.Forms.Button();
            this.cboBuking = new System.Windows.Forms.ComboBox();
            this.txtBrojPlombe2 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cboOrganizator = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.btnManipulacija.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTara)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSifra
            // 
            this.txtSifra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSifra.Location = new System.Drawing.Point(128, 37);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(105, 22);
            this.txtSifra.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 128;
            this.label1.Text = "Šifra:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(12, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 16);
            this.label16.TabIndex = 132;
            this.label16.Text = "Datum prijema:";
            // 
            // dtpDatumPrijema
            // 
            this.dtpDatumPrijema.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumPrijema.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpDatumPrijema.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumPrijema.Location = new System.Drawing.Point(128, 67);
            this.dtpDatumPrijema.Name = "dtpDatumPrijema";
            this.dtpDatumPrijema.Size = new System.Drawing.Size(150, 22);
            this.dtpDatumPrijema.TabIndex = 131;
            this.dtpDatumPrijema.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // cboStatusPrijema
            // 
            this.cboStatusPrijema.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboStatusPrijema.FormattingEnabled = true;
            this.cboStatusPrijema.Items.AddRange(new object[] {
            "1-Najava",
            "2-Primljeno"});
            this.cboStatusPrijema.Location = new System.Drawing.Point(128, 97);
            this.cboStatusPrijema.Name = "cboStatusPrijema";
            this.cboStatusPrijema.Size = new System.Drawing.Size(210, 24);
            this.cboStatusPrijema.TabIndex = 133;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 134;
            this.label2.Text = "Status prijema:";
            // 
            // txtBrojKontejnera
            // 
            this.txtBrojKontejnera.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBrojKontejnera.Location = new System.Drawing.Point(128, 127);
            this.txtBrojKontejnera.Name = "txtBrojKontejnera";
            this.txtBrojKontejnera.Size = new System.Drawing.Size(210, 22);
            this.txtBrojKontejnera.TabIndex = 135;
            this.txtBrojKontejnera.Leave += new System.EventHandler(this.txtBrojKontejnera_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 136;
            this.label3.Text = "Broj kontejnera:";
            // 
            // txtRegBrKamiona
            // 
            this.txtRegBrKamiona.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtRegBrKamiona.Location = new System.Drawing.Point(128, 158);
            this.txtRegBrKamiona.Name = "txtRegBrKamiona";
            this.txtRegBrKamiona.Size = new System.Drawing.Size(210, 22);
            this.txtRegBrKamiona.TabIndex = 137;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 138;
            this.label4.Text = "Reg br vozila:";
            // 
            // txtImeVozaca
            // 
            this.txtImeVozaca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtImeVozaca.Location = new System.Drawing.Point(128, 188);
            this.txtImeVozaca.Name = "txtImeVozaca";
            this.txtImeVozaca.Size = new System.Drawing.Size(210, 22);
            this.txtImeVozaca.TabIndex = 139;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 140;
            this.label5.Text = "Ime Vozaca:";
            // 
            // cboPosiljalac
            // 
            this.cboPosiljalac.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboPosiljalac.FormattingEnabled = true;
            this.cboPosiljalac.Location = new System.Drawing.Point(128, 218);
            this.cboPosiljalac.Name = "cboPosiljalac";
            this.cboPosiljalac.Size = new System.Drawing.Size(210, 24);
            this.cboPosiljalac.TabIndex = 141;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 142;
            this.label6.Text = "Pošiljalac:";
            // 
            // cboPrimalac
            // 
            this.cboPrimalac.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboPrimalac.FormattingEnabled = true;
            this.cboPrimalac.Location = new System.Drawing.Point(128, 249);
            this.cboPrimalac.Name = "cboPrimalac";
            this.cboPrimalac.Size = new System.Drawing.Size(210, 24);
            this.cboPrimalac.TabIndex = 143;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 144;
            this.label7.Text = "Primalac:";
            // 
            // cboVlasnikKontejnera
            // 
            this.cboVlasnikKontejnera.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboVlasnikKontejnera.FormattingEnabled = true;
            this.cboVlasnikKontejnera.Location = new System.Drawing.Point(530, 36);
            this.cboVlasnikKontejnera.Name = "cboVlasnikKontejnera";
            this.cboVlasnikKontejnera.Size = new System.Drawing.Size(210, 24);
            this.cboVlasnikKontejnera.TabIndex = 145;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(394, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 16);
            this.label8.TabIndex = 146;
            this.label8.Text = "Vlasnik kontejnera:";
            // 
            // cboTipKontejnera
            // 
            this.cboTipKontejnera.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboTipKontejnera.FormattingEnabled = true;
            this.cboTipKontejnera.Location = new System.Drawing.Point(530, 67);
            this.cboTipKontejnera.Name = "cboTipKontejnera";
            this.cboTipKontejnera.Size = new System.Drawing.Size(210, 24);
            this.cboTipKontejnera.TabIndex = 147;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(394, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 148;
            this.label9.Text = "Tip kontejnera:";
            // 
            // cboVrstaRobe
            // 
            this.cboVrstaRobe.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboVrstaRobe.FormattingEnabled = true;
            this.cboVrstaRobe.Location = new System.Drawing.Point(530, 97);
            this.cboVrstaRobe.Name = "cboVrstaRobe";
            this.cboVrstaRobe.Size = new System.Drawing.Size(210, 24);
            this.cboVrstaRobe.TabIndex = 149;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(394, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 150;
            this.label10.Text = "Vrsta robe:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(394, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 16);
            this.label11.TabIndex = 152;
            this.label11.Text = "Buking dolaska:";
            // 
            // cboStatusKontejnera
            // 
            this.cboStatusKontejnera.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboStatusKontejnera.FormattingEnabled = true;
            this.cboStatusKontejnera.Items.AddRange(new object[] {
            "1-Tovaren za otpremu vozom",
            "2-Tovaren za otpremu kamionom",
            "3-Prazan- za otrpemu kamionom na utovar, ",
            "4-Prazan – povratak vozom vlasniku",
            "5-Prazan za utovar na terminalu, ",
            "6-Prazan  na terminalu bez instukcija ",
            "7-Kontejner za popravku",
            "8-Kontejner za čišćenje",
            "9-Kontejner za dezinfekciju",
            "10Kontejner za deretizaciju"});
            this.cboStatusKontejnera.Location = new System.Drawing.Point(530, 157);
            this.cboStatusKontejnera.Name = "cboStatusKontejnera";
            this.cboStatusKontejnera.Size = new System.Drawing.Size(210, 24);
            this.cboStatusKontejnera.TabIndex = 153;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(394, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 16);
            this.label12.TabIndex = 154;
            this.label12.Text = "Status kontejnera:";
            // 
            // txtBrojPlombe
            // 
            this.txtBrojPlombe.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBrojPlombe.Location = new System.Drawing.Point(530, 188);
            this.txtBrojPlombe.Name = "txtBrojPlombe";
            this.txtBrojPlombe.Size = new System.Drawing.Size(150, 22);
            this.txtBrojPlombe.TabIndex = 155;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(394, 192);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 16);
            this.label13.TabIndex = 156;
            this.label13.Text = "Broj plombe:";
            // 
            // txtPlaniraniLager
            // 
            this.txtPlaniraniLager.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPlaniraniLager.Location = new System.Drawing.Point(971, 189);
            this.txtPlaniraniLager.Name = "txtPlaniraniLager";
            this.txtPlaniraniLager.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaniraniLager.Size = new System.Drawing.Size(63, 22);
            this.txtPlaniraniLager.TabIndex = 157;
            this.txtPlaniraniLager.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(827, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 16);
            this.label14.TabIndex = 158;
            this.label14.Text = "Planirani lager:";
            // 
            // cboBukingOtpreme
            // 
            this.cboBukingOtpreme.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboBukingOtpreme.FormattingEnabled = true;
            this.cboBukingOtpreme.Location = new System.Drawing.Point(971, 218);
            this.cboBukingOtpreme.Name = "cboBukingOtpreme";
            this.cboBukingOtpreme.Size = new System.Drawing.Size(210, 24);
            this.cboBukingOtpreme.TabIndex = 159;
            this.cboBukingOtpreme.SelectedIndexChanged += new System.EventHandler(this.cboBukingOtpreme_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(826, 222);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(139, 16);
            this.label15.TabIndex = 160;
            this.label15.Text = "Voz buking otpreme:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(826, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(132, 16);
            this.label17.TabIndex = 166;
            this.label17.Text = "Vreme Pripremljen:";
            // 
            // dtpVremeOdlaska
            // 
            this.dtpVremeOdlaska.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeOdlaska.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpVremeOdlaska.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeOdlaska.Location = new System.Drawing.Point(971, 98);
            this.dtpVremeOdlaska.Name = "dtpVremeOdlaska";
            this.dtpVremeOdlaska.Size = new System.Drawing.Size(150, 22);
            this.dtpVremeOdlaska.TabIndex = 163;
            this.dtpVremeOdlaska.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(826, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 16);
            this.label18.TabIndex = 165;
            this.label18.Text = "Vreme Dolaska:";
            // 
            // dtpVremePripremljen
            // 
            this.dtpVremePripremljen.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremePripremljen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpVremePripremljen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremePripremljen.Location = new System.Drawing.Point(971, 68);
            this.dtpVremePripremljen.Name = "dtpVremePripremljen";
            this.dtpVremePripremljen.Size = new System.Drawing.Size(150, 22);
            this.dtpVremePripremljen.TabIndex = 162;
            this.dtpVremePripremljen.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dtpVremeDolaska
            // 
            this.dtpVremeDolaska.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeDolaska.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpVremeDolaska.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeDolaska.Location = new System.Drawing.Point(971, 38);
            this.dtpVremeDolaska.Name = "dtpVremeDolaska";
            this.dtpVremeDolaska.Size = new System.Drawing.Size(150, 22);
            this.dtpVremeDolaska.TabIndex = 161;
            this.dtpVremeDolaska.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(827, 101);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 16);
            this.label19.TabIndex = 164;
            this.label19.Text = "Vreme Odlaska:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 413);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1298, 324);
            this.dataGridView1.TabIndex = 167;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnManipulacija
            // 
            this.btnManipulacija.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnManipulacija.BackgroundImage")));
            this.btnManipulacija.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsSave,
            this.tsDelete,
            this.toolStripSeparator1,
            this.tsPrvi,
            this.tsNazad,
            this.tsNapred,
            this.tsPoslednja,
            this.toolStripButton1,
            this.toolStripButton2});
            this.btnManipulacija.Location = new System.Drawing.Point(0, 0);
            this.btnManipulacija.Name = "btnManipulacija";
            this.btnManipulacija.Size = new System.Drawing.Size(1322, 25);
            this.btnManipulacija.TabIndex = 168;
            this.btnManipulacija.Text = "Manipulacije kontejnerom";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(23, 22);
            this.tsNew.Text = "Novi";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(23, 22);
            this.tsSave.Text = "tsSave";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsDelete.Image")));
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(23, 22);
            this.tsDelete.Text = "toolStripButton1";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsPrvi
            // 
            this.tsPrvi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPrvi.Image = ((System.Drawing.Image)(resources.GetObject("tsPrvi.Image")));
            this.tsPrvi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrvi.Name = "tsPrvi";
            this.tsPrvi.Size = new System.Drawing.Size(23, 22);
            this.tsPrvi.Text = "toolStripButton1";
            // 
            // tsNazad
            // 
            this.tsNazad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNazad.Image = ((System.Drawing.Image)(resources.GetObject("tsNazad.Image")));
            this.tsNazad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNazad.Name = "tsNazad";
            this.tsNazad.Size = new System.Drawing.Size(23, 22);
            this.tsNazad.Text = "toolStripButton1";
            this.tsNazad.Click += new System.EventHandler(this.tsNazad_Click);
            // 
            // tsNapred
            // 
            this.tsNapred.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNapred.Image = ((System.Drawing.Image)(resources.GetObject("tsNapred.Image")));
            this.tsNapred.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNapred.Name = "tsNapred";
            this.tsNapred.Size = new System.Drawing.Size(23, 22);
            this.tsNapred.Text = "toolStripButton1";
            // 
            // tsPoslednja
            // 
            this.tsPoslednja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPoslednja.Image = ((System.Drawing.Image)(resources.GetObject("tsPoslednja.Image")));
            this.tsPoslednja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPoslednja.Name = "tsPoslednja";
            this.tsPoslednja.Size = new System.Drawing.Size(23, 22);
            this.tsPoslednja.Text = "toolStripButton1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton1.Text = "Dokumenta";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(115, 22);
            this.toolStripButton2.Text = "Pošalji e-mail";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // txtNeto
            // 
            this.txtNeto.DecimalPlaces = 3;
            this.txtNeto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtNeto.Location = new System.Drawing.Point(971, 159);
            this.txtNeto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtNeto.Name = "txtNeto";
            this.txtNeto.Size = new System.Drawing.Size(75, 22);
            this.txtNeto.TabIndex = 215;
            this.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTara
            // 
            this.txtTara.DecimalPlaces = 3;
            this.txtTara.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTara.Location = new System.Drawing.Point(971, 129);
            this.txtTara.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(75, 22);
            this.txtTara.TabIndex = 214;
            this.txtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(827, 132);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 16);
            this.label20.TabIndex = 216;
            this.label20.Text = "Tara:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(827, 162);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 16);
            this.label21.TabIndex = 217;
            this.label21.Text = "Neto:";
            // 
            // btnPosaljiMail
            // 
            this.btnPosaljiMail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPosaljiMail.BackgroundImage")));
            this.btnPosaljiMail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPosaljiMail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPosaljiMail.ForeColor = System.Drawing.Color.White;
            this.btnPosaljiMail.Location = new System.Drawing.Point(1034, 276);
            this.btnPosaljiMail.Name = "btnPosaljiMail";
            this.btnPosaljiMail.Size = new System.Drawing.Size(147, 35);
            this.btnPosaljiMail.TabIndex = 218;
            this.btnPosaljiMail.Text = "Slanje maila";
            this.btnPosaljiMail.UseVisualStyleBackColor = true;
            this.btnPosaljiMail.Click += new System.EventHandler(this.btnPosaljiMail_Click);
            // 
            // cboBuking
            // 
            this.cboBuking.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboBuking.FormattingEnabled = true;
            this.cboBuking.Location = new System.Drawing.Point(530, 128);
            this.cboBuking.Name = "cboBuking";
            this.cboBuking.Size = new System.Drawing.Size(210, 24);
            this.cboBuking.TabIndex = 219;
            // 
            // txtBrojPlombe2
            // 
            this.txtBrojPlombe2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBrojPlombe2.Location = new System.Drawing.Point(530, 218);
            this.txtBrojPlombe2.Name = "txtBrojPlombe2";
            this.txtBrojPlombe2.Size = new System.Drawing.Size(150, 22);
            this.txtBrojPlombe2.TabIndex = 220;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(394, 222);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 16);
            this.label22.TabIndex = 221;
            this.label22.Text = "Broj plombe 2:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(395, 252);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(87, 16);
            this.label28.TabIndex = 230;
            this.label28.Text = "Organizator:";
            // 
            // cboOrganizator
            // 
            this.cboOrganizator.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboOrganizator.FormattingEnabled = true;
            this.cboOrganizator.Location = new System.Drawing.Point(530, 248);
            this.cboOrganizator.Name = "cboOrganizator";
            this.cboOrganizator.Size = new System.Drawing.Size(210, 24);
            this.cboOrganizator.TabIndex = 229;
            // 
            // frmPrijemKontejneraKamionom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1322, 749);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.cboOrganizator);
            this.Controls.Add(this.txtBrojPlombe2);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cboBuking);
            this.Controls.Add(this.btnPosaljiMail);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtNeto);
            this.Controls.Add(this.txtTara);
            this.Controls.Add(this.btnManipulacija);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dtpVremeOdlaska);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dtpVremePripremljen);
            this.Controls.Add(this.dtpVremeDolaska);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cboBukingOtpreme);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPlaniraniLager);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtBrojPlombe);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboStatusKontejnera);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboVrstaRobe);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboTipKontejnera);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboVlasnikKontejnera);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboPrimalac);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboPosiljalac);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImeVozaca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRegBrKamiona);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBrojKontejnera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboStatusPrijema);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtpDatumPrijema);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrijemKontejneraKamionom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prijem kontejnera kamionom";
            this.Load += new System.EventHandler(this.frmPrijemKontejneraKamionom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.btnManipulacija.ResumeLayout(false);
            this.btnManipulacija.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpDatumPrijema;
        private System.Windows.Forms.ComboBox cboStatusPrijema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBrojKontejnera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegBrKamiona;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImeVozaca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPosiljalac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPrimalac;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboVlasnikKontejnera;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipKontejnera;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboVrstaRobe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboStatusKontejnera;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBrojPlombe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPlaniraniLager;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboBukingOtpreme;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpVremeOdlaska;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpVremePripremljen;
        private System.Windows.Forms.DateTimePicker dtpVremeDolaska;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip btnManipulacija;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsPrvi;
        private System.Windows.Forms.ToolStripButton tsNazad;
        private System.Windows.Forms.ToolStripButton tsNapred;
        private System.Windows.Forms.ToolStripButton tsPoslednja;
        private System.Windows.Forms.NumericUpDown txtNeto;
        private System.Windows.Forms.NumericUpDown txtTara;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnPosaljiMail;
        private System.Windows.Forms.ComboBox cboBuking;
        private System.Windows.Forms.TextBox txtBrojPlombe2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboOrganizator;
    }
}