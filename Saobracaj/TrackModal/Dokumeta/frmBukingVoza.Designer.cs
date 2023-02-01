namespace Testiranje.Dokumeta
{
    partial class frmBukingVoza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBukingVoza));
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
            this.label16 = new System.Windows.Forms.Label();
            this.dtpDatumOtpreme = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cboVoz = new System.Windows.Forms.ComboBox();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.txtStanicaOtpreme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnOsvezi = new System.Windows.Forms.Button();
            this.cboSkladiste = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cboOtpremnica = new System.Windows.Forms.ComboBox();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBruto = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtNeto = new System.Windows.Forms.NumericUpDown();
            this.txtTara = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUkupno2 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSopstvenaMasa2 = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNeto2 = new System.Windows.Forms.NumericUpDown();
            this.txtTara2 = new System.Windows.Forms.NumericUpDown();
            this.txtBrojKontejnera = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBruto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUkupno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSopstvenaMasa2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeto2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTara2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
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
            this.toolStrip1.Size = new System.Drawing.Size(1370, 25);
            this.toolStrip1.TabIndex = 111;
            this.toolStrip1.Text = "Refresh buking";
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
            this.toolStripButton1.Size = new System.Drawing.Size(144, 22);
            this.toolStripButton1.Text = "Refresh kontejneri";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(1196, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 16);
            this.label16.TabIndex = 130;
            this.label16.Text = "Datum otpreme:";
            this.label16.Visible = false;
            // 
            // dtpDatumOtpreme
            // 
            this.dtpDatumOtpreme.CalendarFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpDatumOtpreme.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumOtpreme.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpDatumOtpreme.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumOtpreme.Location = new System.Drawing.Point(1199, 101);
            this.dtpDatumOtpreme.Name = "dtpDatumOtpreme";
            this.dtpDatumOtpreme.Size = new System.Drawing.Size(143, 22);
            this.dtpDatumOtpreme.TabIndex = 129;
            this.dtpDatumOtpreme.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDatumOtpreme.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(161, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 128;
            this.label6.Text = "Voz otpreme";
            // 
            // cboVoz
            // 
            this.cboVoz.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboVoz.FormattingEnabled = true;
            this.cboVoz.Location = new System.Drawing.Point(255, 51);
            this.cboVoz.Name = "cboVoz";
            this.cboVoz.Size = new System.Drawing.Size(344, 24);
            this.cboVoz.TabIndex = 127;
            // 
            // txtSifra
            // 
            this.txtSifra.Enabled = false;
            this.txtSifra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSifra.Location = new System.Drawing.Point(66, 54);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(80, 22);
            this.txtSifra.TabIndex = 125;
            // 
            // txtStanicaOtpreme
            // 
            this.txtStanicaOtpreme.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtStanicaOtpreme.Location = new System.Drawing.Point(1199, 57);
            this.txtStanicaOtpreme.Name = "txtStanicaOtpreme";
            this.txtStanicaOtpreme.Size = new System.Drawing.Size(159, 22);
            this.txtStanicaOtpreme.TabIndex = 131;
            this.txtStanicaOtpreme.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1196, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 132;
            this.label2.Text = "Stanica otpreme:";
            this.label2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(368, 424);
            this.dataGridView1.TabIndex = 139;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 16);
            this.label3.TabIndex = 140;
            this.label3.Text = "Spisak kontejnera određen buking pri prijemu:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(839, 157);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(520, 424);
            this.dataGridView2.TabIndex = 141;
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnOsvezi
            // 
            this.btnOsvezi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOsvezi.BackgroundImage")));
            this.btnOsvezi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOsvezi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnOsvezi.ForeColor = System.Drawing.Color.White;
            this.btnOsvezi.Location = new System.Drawing.Point(571, 101);
            this.btnOsvezi.Name = "btnOsvezi";
            this.btnOsvezi.Size = new System.Drawing.Size(43, 25);
            this.btnOsvezi.TabIndex = 234;
            this.btnOsvezi.Text = "?";
            this.btnOsvezi.UseVisualStyleBackColor = true;
            this.btnOsvezi.Click += new System.EventHandler(this.btnOsvezi_Click);
            // 
            // cboSkladiste
            // 
            this.cboSkladiste.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboSkladiste.FormattingEnabled = true;
            this.cboSkladiste.Location = new System.Drawing.Point(436, 104);
            this.cboSkladiste.Name = "cboSkladiste";
            this.cboSkladiste.Size = new System.Drawing.Size(129, 24);
            this.cboSkladiste.TabIndex = 233;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(433, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 232;
            this.label5.Text = "Skladište:";
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(436, 157);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(347, 427);
            this.dataGridView3.TabIndex = 235;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(617, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 237;
            this.label7.Text = "Otpremnica";
            // 
            // cboOtpremnica
            // 
            this.cboOtpremnica.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboOtpremnica.FormattingEnabled = true;
            this.cboOtpremnica.Location = new System.Drawing.Point(705, 53);
            this.cboOtpremnica.Name = "cboOtpremnica";
            this.cboOtpremnica.Size = new System.Drawing.Size(323, 24);
            this.cboOtpremnica.TabIndex = 236;
            this.cboOtpremnica.SelectedIndexChanged += new System.EventHandler(this.cboOtpremnica_SelectedIndexChanged);
            // 
            // btnUnesi
            // 
            this.btnUnesi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnesi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUnesi.BackgroundImage")));
            this.btnUnesi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnesi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUnesi.ForeColor = System.Drawing.Color.White;
            this.btnUnesi.Location = new System.Drawing.Point(789, 157);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(44, 424);
            this.btnUnesi.TabIndex = 238;
            this.btnUnesi.Text = ">>";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(386, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 426);
            this.button1.TabIndex = 239;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1034, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 25);
            this.button2.TabIndex = 240;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(210, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 248;
            this.label9.Text = "BRK:";
            // 
            // txtBruto
            // 
            this.txtBruto.DecimalPlaces = 3;
            this.txtBruto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBruto.Location = new System.Drawing.Point(213, 126);
            this.txtBruto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtBruto.Name = "txtBruto";
            this.txtBruto.Size = new System.Drawing.Size(75, 22);
            this.txtBruto.TabIndex = 247;
            this.txtBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(126, 107);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 16);
            this.label26.TabIndex = 246;
            this.label26.Text = "Neto:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(13, 107);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 16);
            this.label25.TabIndex = 245;
            this.label25.Text = "Tara:";
            // 
            // txtNeto
            // 
            this.txtNeto.DecimalPlaces = 3;
            this.txtNeto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtNeto.Location = new System.Drawing.Point(113, 126);
            this.txtNeto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtNeto.Name = "txtNeto";
            this.txtNeto.Size = new System.Drawing.Size(75, 22);
            this.txtNeto.TabIndex = 242;
            this.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTara
            // 
            this.txtTara.DecimalPlaces = 3;
            this.txtTara.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTara.Location = new System.Drawing.Point(16, 126);
            this.txtTara.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(75, 22);
            this.txtTara.TabIndex = 241;
            this.txtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1090, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 256;
            this.label8.Text = "Broj kola:";
            // 
            // txtUkupno2
            // 
            this.txtUkupno2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUkupno2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtUkupno2.Location = new System.Drawing.Point(1093, 104);
            this.txtUkupno2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtUkupno2.Name = "txtUkupno2";
            this.txtUkupno2.Size = new System.Drawing.Size(65, 22);
            this.txtUkupno2.TabIndex = 255;
            this.txtUkupno2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(1020, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 254;
            this.label10.Text = "Neto:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(927, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 16);
            this.label11.TabIndex = 253;
            this.label11.Text = "Tara:";
            // 
            // txtSopstvenaMasa2
            // 
            this.txtSopstvenaMasa2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSopstvenaMasa2.DecimalPlaces = 2;
            this.txtSopstvenaMasa2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSopstvenaMasa2.InterceptArrowKeys = false;
            this.txtSopstvenaMasa2.Location = new System.Drawing.Point(839, 104);
            this.txtSopstvenaMasa2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtSopstvenaMasa2.Name = "txtSopstvenaMasa2";
            this.txtSopstvenaMasa2.Size = new System.Drawing.Size(75, 22);
            this.txtSopstvenaMasa2.TabIndex = 252;
            this.txtSopstvenaMasa2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(836, 85);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(75, 16);
            this.label23.TabIndex = 251;
            this.label23.Text = "Sop masa:";
            // 
            // txtNeto2
            // 
            this.txtNeto2.DecimalPlaces = 3;
            this.txtNeto2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtNeto2.Location = new System.Drawing.Point(1021, 104);
            this.txtNeto2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtNeto2.Name = "txtNeto2";
            this.txtNeto2.Size = new System.Drawing.Size(66, 22);
            this.txtNeto2.TabIndex = 250;
            this.txtNeto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTara2
            // 
            this.txtTara2.DecimalPlaces = 3;
            this.txtTara2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTara2.Location = new System.Drawing.Point(930, 104);
            this.txtTara2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtTara2.Name = "txtTara2";
            this.txtTara2.Size = new System.Drawing.Size(75, 22);
            this.txtTara2.TabIndex = 249;
            this.txtTara2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBrojKontejnera
            // 
            this.txtBrojKontejnera.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBrojKontejnera.Location = new System.Drawing.Point(620, 103);
            this.txtBrojKontejnera.Name = "txtBrojKontejnera";
            this.txtBrojKontejnera.Size = new System.Drawing.Size(144, 22);
            this.txtBrojKontejnera.TabIndex = 258;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(617, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 257;
            this.label4.Text = "Kontejner:";
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(770, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 25);
            this.button3.TabIndex = 259;
            this.button3.Text = "?";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 260;
            this.label1.Text = "Šifra";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(1165, 28);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(194, 129);
            this.dataGridView4.TabIndex = 270;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1005, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 16);
            this.label12.TabIndex = 271;
            this.label12.Text = "Kontejneri za otpremu:";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(839, 132);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(222, 25);
            this.button4.TabIndex = 272;
            this.button4.Text = "Povezivanje kola i kontejnera";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(1067, 132);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 25);
            this.button5.TabIndex = 273;
            this.button5.Text = "Izbriši";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmBukingVoza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1370, 593);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtBrojKontejnera);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUkupno2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSopstvenaMasa2);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtNeto2);
            this.Controls.Add(this.txtTara2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBruto);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtNeto);
            this.Controls.Add(this.txtTara);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUnesi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboOtpremnica);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.btnOsvezi);
            this.Controls.Add(this.cboSkladiste);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtStanicaOtpreme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtpDatumOtpreme);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboVoz);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBukingVoza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buking Voza otprema";
            this.Load += new System.EventHandler(this.frmBukingVoza_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBruto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUkupno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSopstvenaMasa2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeto2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTara2)).EndInit();
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
        private System.Windows.Forms.ToolStripButton tsPrvi;
        private System.Windows.Forms.ToolStripButton tsNazad;
        private System.Windows.Forms.ToolStripButton tsNapred;
        private System.Windows.Forms.ToolStripButton tsPoslednja;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpDatumOtpreme;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboVoz;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.TextBox txtStanicaOtpreme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnOsvezi;
        private System.Windows.Forms.ComboBox cboSkladiste;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboOtpremnica;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown txtBruto;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown txtNeto;
        private System.Windows.Forms.NumericUpDown txtTara;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtUkupno2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txtSopstvenaMasa2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown txtNeto2;
        private System.Windows.Forms.NumericUpDown txtTara2;
        private System.Windows.Forms.TextBox txtBrojKontejnera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}