
namespace Saobracaj.Dokumenta
{
    partial class frmKontrola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKontrola));
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cboNajavaID = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRadnikID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDatumPrijemaKoverte = new MetroFramework.Controls.MetroDateTime();
            this.chkUradio = new System.Windows.Forms.CheckBox();
            this.dtpDatumCekiranja = new MetroFramework.Controls.MetroDateTime();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNapomenaZaglavlje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboGreska = new System.Windows.Forms.ComboBox();
            this.cboGreskaRadnik = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gradientPanel4 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDatumCekiranja2 = new MetroFramework.Controls.MetroDateTime();
            this.chkuradio2 = new System.Windows.Forms.CheckBox();
            this.txtSifraGreske = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gradientPanel5 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.button1 = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton1 = new Syncfusion.WinForms.Controls.SfButton();
            this.txtNapomenaStavka = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.sfButton2 = new Syncfusion.WinForms.Controls.SfButton();
            this.cboTipDokumenta = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtKontrola1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.sfButton3 = new Syncfusion.WinForms.Controls.SfButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNajavaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel4)).BeginInit();
            this.gradientPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel5)).BeginInit();
            this.gradientPanel5.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1621, 27);
            this.toolStrip1.TabIndex = 161;
            this.toolStrip1.Text = "Štampaj izveštaj";
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
            // cboNajavaID
            // 
            this.cboNajavaID.AllowFiltering = false;
            this.cboNajavaID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cboNajavaID.BeforeTouchSize = new System.Drawing.Size(429, 24);
            this.cboNajavaID.Filter = null;
            this.cboNajavaID.Location = new System.Drawing.Point(23, 128);
            this.cboNajavaID.Margin = new System.Windows.Forms.Padding(4);
            this.cboNajavaID.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.cboNajavaID.Name = "cboNajavaID";
            this.cboNajavaID.ScrollMetroColorTable = metroColorTable1;
            this.cboNajavaID.Size = new System.Drawing.Size(429, 24);
            this.cboNajavaID.TabIndex = 163;
            this.cboNajavaID.Leave += new System.EventHandler(this.cboNajavaID_Leave);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(19, 108);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(52, 17);
            this.label33.TabIndex = 162;
            this.label33.Text = "Najava";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 165;
            this.label1.Text = "Radnik";
            // 
            // cboRadnikID
            // 
            this.cboRadnikID.BackColor = System.Drawing.Color.White;
            this.cboRadnikID.FormattingEnabled = true;
            this.cboRadnikID.Location = new System.Drawing.Point(23, 183);
            this.cboRadnikID.Margin = new System.Windows.Forms.Padding(4);
            this.cboRadnikID.Name = "cboRadnikID";
            this.cboRadnikID.Size = new System.Drawing.Size(429, 24);
            this.cboRadnikID.TabIndex = 177;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 311);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 17);
            this.label5.TabIndex = 179;
            this.label5.Text = "Datum prijema koverte:";
            // 
            // dtpDatumPrijemaKoverte
            // 
            this.dtpDatumPrijemaKoverte.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumPrijemaKoverte.Enabled = false;
            this.dtpDatumPrijemaKoverte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumPrijemaKoverte.Location = new System.Drawing.Point(23, 251);
            this.dtpDatumPrijemaKoverte.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumPrijemaKoverte.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtpDatumPrijemaKoverte.Name = "dtpDatumPrijemaKoverte";
            this.dtpDatumPrijemaKoverte.Size = new System.Drawing.Size(265, 30);
            this.dtpDatumPrijemaKoverte.TabIndex = 178;
            // 
            // chkUradio
            // 
            this.chkUradio.AutoSize = true;
            this.chkUradio.Location = new System.Drawing.Point(23, 390);
            this.chkUradio.Margin = new System.Windows.Forms.Padding(4);
            this.chkUradio.Name = "chkUradio";
            this.chkUradio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUradio.Size = new System.Drawing.Size(72, 21);
            this.chkUradio.TabIndex = 202;
            this.chkUradio.Text = "Uradio";
            this.chkUradio.UseVisualStyleBackColor = true;
            // 
            // dtpDatumCekiranja
            // 
            this.dtpDatumCekiranja.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumCekiranja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumCekiranja.Location = new System.Drawing.Point(23, 331);
            this.dtpDatumCekiranja.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumCekiranja.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtpDatumCekiranja.Name = "dtpDatumCekiranja";
            this.dtpDatumCekiranja.Size = new System.Drawing.Size(265, 30);
            this.dtpDatumCekiranja.TabIndex = 203;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 231);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 204;
            this.label2.Text = "ATA";
            // 
            // txtNapomenaZaglavlje
            // 
            this.txtNapomenaZaglavlje.Location = new System.Drawing.Point(509, 199);
            this.txtNapomenaZaglavlje.Margin = new System.Windows.Forms.Padding(4);
            this.txtNapomenaZaglavlje.Multiline = true;
            this.txtNapomenaZaglavlje.Name = "txtNapomenaZaglavlje";
            this.txtNapomenaZaglavlje.Size = new System.Drawing.Size(429, 244);
            this.txtNapomenaZaglavlje.TabIndex = 208;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 209;
            this.label4.Text = "Napomena";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(976, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 210;
            this.label6.Text = "Greška";
            // 
            // cboGreska
            // 
            this.cboGreska.BackColor = System.Drawing.Color.White;
            this.cboGreska.FormattingEnabled = true;
            this.cboGreska.Location = new System.Drawing.Point(976, 166);
            this.cboGreska.Margin = new System.Windows.Forms.Padding(4);
            this.cboGreska.Name = "cboGreska";
            this.cboGreska.Size = new System.Drawing.Size(415, 24);
            this.cboGreska.TabIndex = 211;
            // 
            // cboGreskaRadnik
            // 
            this.cboGreskaRadnik.BackColor = System.Drawing.Color.White;
            this.cboGreskaRadnik.FormattingEnabled = true;
            this.cboGreskaRadnik.Location = new System.Drawing.Point(976, 214);
            this.cboGreskaRadnik.Margin = new System.Windows.Forms.Padding(4);
            this.cboGreskaRadnik.Name = "cboGreskaRadnik";
            this.cboGreskaRadnik.Size = new System.Drawing.Size(415, 24);
            this.cboGreskaRadnik.TabIndex = 212;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(972, 196);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 213;
            this.label7.Text = "Radnik";
            // 
            // gradientPanel4
            // 
            this.gradientPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel4.Controls.Add(this.dataGridView3);
            this.gradientPanel4.Location = new System.Drawing.Point(967, 287);
            this.gradientPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.gradientPanel4.Name = "gradientPanel4";
            this.gradientPanel4.Size = new System.Drawing.Size(643, 163);
            this.gradientPanel4.TabIndex = 214;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(4, 4);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(631, 170);
            this.dataGridView3.TabIndex = 161;
            this.dataGridView3.SelectionChanged += new System.EventHandler(this.dataGridView3_SelectionChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(505, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 17);
            this.label8.TabIndex = 217;
            this.label8.Text = "Datum izvšenog preglda";
            // 
            // dtpDatumCekiranja2
            // 
            this.dtpDatumCekiranja2.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumCekiranja2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumCekiranja2.Location = new System.Drawing.Point(509, 71);
            this.dtpDatumCekiranja2.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumCekiranja2.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtpDatumCekiranja2.Name = "dtpDatumCekiranja2";
            this.dtpDatumCekiranja2.Size = new System.Drawing.Size(265, 30);
            this.dtpDatumCekiranja2.TabIndex = 216;
            // 
            // chkuradio2
            // 
            this.chkuradio2.AutoSize = true;
            this.chkuradio2.Location = new System.Drawing.Point(509, 114);
            this.chkuradio2.Margin = new System.Windows.Forms.Padding(4);
            this.chkuradio2.Name = "chkuradio2";
            this.chkuradio2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkuradio2.Size = new System.Drawing.Size(72, 21);
            this.chkuradio2.TabIndex = 215;
            this.chkuradio2.Text = "Uradio";
            this.chkuradio2.UseVisualStyleBackColor = true;
            // 
            // txtSifraGreske
            // 
            this.txtSifraGreske.Location = new System.Drawing.Point(976, 58);
            this.txtSifraGreske.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifraGreske.Name = "txtSifraGreske";
            this.txtSifraGreske.Size = new System.Drawing.Size(96, 22);
            this.txtSifraGreske.TabIndex = 218;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(976, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 219;
            this.label3.Text = "Šifra:";
            // 
            // gradientPanel5
            // 
            this.gradientPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel5.Controls.Add(this.dataGridView1);
            this.gradientPanel5.Location = new System.Drawing.Point(16, 458);
            this.gradientPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.gradientPanel5.Name = "gradientPanel5";
            this.gradientPanel5.Size = new System.Drawing.Size(1593, 277);
            this.gradientPanel5.TabIndex = 220;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1581, 266);
            this.dataGridView1.TabIndex = 162;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 52);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 221;
            this.label9.Text = "Šifra";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(23, 74);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(96, 22);
            this.txtSifra.TabIndex = 222;
            // 
            // button1
            // 
            this.button1.AccessibleName = "Button";
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(967, 245);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 34);
            this.button1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button1.Style.ForeColor = System.Drawing.Color.White;
            this.button1.TabIndex = 223;
            this.button1.Text = "Unesi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sfButton1
            // 
            this.sfButton1.AccessibleName = "Button";
            this.sfButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.sfButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton1.ForeColor = System.Drawing.Color.White;
            this.sfButton1.Location = new System.Drawing.Point(1268, 245);
            this.sfButton1.Margin = new System.Windows.Forms.Padding(4);
            this.sfButton1.Name = "sfButton1";
            this.sfButton1.Size = new System.Drawing.Size(143, 34);
            this.sfButton1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.sfButton1.Style.ForeColor = System.Drawing.Color.White;
            this.sfButton1.TabIndex = 224;
            this.sfButton1.Text = "Izbaci";
            this.sfButton1.UseVisualStyleBackColor = false;
            this.sfButton1.Click += new System.EventHandler(this.sfButton1_Click);
            // 
            // txtNapomenaStavka
            // 
            this.txtNapomenaStavka.Location = new System.Drawing.Point(1419, 54);
            this.txtNapomenaStavka.Margin = new System.Windows.Forms.Padding(4);
            this.txtNapomenaStavka.Multiline = true;
            this.txtNapomenaStavka.Name = "txtNapomenaStavka";
            this.txtNapomenaStavka.Size = new System.Drawing.Size(191, 224);
            this.txtNapomenaStavka.TabIndex = 225;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1415, 34);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 17);
            this.label10.TabIndex = 226;
            this.label10.Text = "Napomena";
            // 
            // sfButton2
            // 
            this.sfButton2.AccessibleName = "Button";
            this.sfButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.sfButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton2.ForeColor = System.Drawing.Color.White;
            this.sfButton2.Location = new System.Drawing.Point(1117, 245);
            this.sfButton2.Margin = new System.Windows.Forms.Padding(4);
            this.sfButton2.Name = "sfButton2";
            this.sfButton2.Size = new System.Drawing.Size(143, 34);
            this.sfButton2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.sfButton2.Style.ForeColor = System.Drawing.Color.White;
            this.sfButton2.TabIndex = 227;
            this.sfButton2.Text = "Promeni";
            this.sfButton2.UseVisualStyleBackColor = false;
            this.sfButton2.Click += new System.EventHandler(this.sfButton2_Click);
            // 
            // cboTipDokumenta
            // 
            this.cboTipDokumenta.BackColor = System.Drawing.Color.White;
            this.cboTipDokumenta.FormattingEnabled = true;
            this.cboTipDokumenta.Location = new System.Drawing.Point(976, 108);
            this.cboTipDokumenta.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipDokumenta.Name = "cboTipDokumenta";
            this.cboTipDokumenta.Size = new System.Drawing.Size(415, 24);
            this.cboTipDokumenta.TabIndex = 229;
            this.cboTipDokumenta.SelectedValueChanged += new System.EventHandler(this.cboTipDokumenta_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(976, 86);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 17);
            this.label11.TabIndex = 228;
            this.label11.Text = "Tip Dokumenta";
            // 
            // txtKontrola1
            // 
            this.txtKontrola1.BackColor = System.Drawing.Color.Lime;
            this.txtKontrola1.Location = new System.Drawing.Point(240, 71);
            this.txtKontrola1.Margin = new System.Windows.Forms.Padding(4);
            this.txtKontrola1.Name = "txtKontrola1";
            this.txtKontrola1.PasswordChar = '*';
            this.txtKontrola1.Size = new System.Drawing.Size(96, 22);
            this.txtKontrola1.TabIndex = 230;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(161, 75);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 17);
            this.label12.TabIndex = 231;
            this.label12.Text = "Password";
            // 
            // sfButton3
            // 
            this.sfButton3.AccessibleName = "Button";
            this.sfButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.sfButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton3.ForeColor = System.Drawing.Color.White;
            this.sfButton3.Location = new System.Drawing.Point(345, 64);
            this.sfButton3.Margin = new System.Windows.Forms.Padding(4);
            this.sfButton3.Name = "sfButton3";
            this.sfButton3.Size = new System.Drawing.Size(77, 34);
            this.sfButton3.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.sfButton3.Style.ForeColor = System.Drawing.Color.White;
            this.sfButton3.TabIndex = 232;
            this.sfButton3.Text = "?";
            this.sfButton3.UseVisualStyleBackColor = false;
            this.sfButton3.Click += new System.EventHandler(this.sfButton3_Click);
            // 
            // frmKontrola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1621, 737);
            this.Controls.Add(this.sfButton3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtKontrola1);
            this.Controls.Add(this.cboTipDokumenta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.sfButton2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNapomenaStavka);
            this.Controls.Add(this.sfButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gradientPanel5);
            this.Controls.Add(this.txtSifraGreske);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpDatumCekiranja2);
            this.Controls.Add(this.chkuradio2);
            this.Controls.Add(this.gradientPanel4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboGreskaRadnik);
            this.Controls.Add(this.cboGreska);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNapomenaZaglavlje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDatumCekiranja);
            this.Controls.Add(this.chkUradio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDatumPrijemaKoverte);
            this.Controls.Add(this.cboRadnikID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboNajavaID);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKontrola";
            this.Text = "Kontrola";
            this.Load += new System.EventHandler(this.frmKontrola_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNajavaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel4)).EndInit();
            this.gradientPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel5)).EndInit();
            this.gradientPanel5.ResumeLayout(false);
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
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox cboNajavaID;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRadnikID;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroDateTime dtpDatumPrijemaKoverte;
        private System.Windows.Forms.CheckBox chkUradio;
        private MetroFramework.Controls.MetroDateTime dtpDatumCekiranja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNapomenaZaglavlje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboGreska;
        private System.Windows.Forms.ComboBox cboGreskaRadnik;
        private System.Windows.Forms.Label label7;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel4;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroDateTime dtpDatumCekiranja2;
        private System.Windows.Forms.CheckBox chkuradio2;
        private System.Windows.Forms.TextBox txtSifraGreske;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSifra;
        private Syncfusion.WinForms.Controls.SfButton button1;
        private Syncfusion.WinForms.Controls.SfButton sfButton1;
        private System.Windows.Forms.TextBox txtNapomenaStavka;
        private System.Windows.Forms.Label label10;
        private Syncfusion.WinForms.Controls.SfButton sfButton2;
        private System.Windows.Forms.ComboBox cboTipDokumenta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKontrola1;
        private System.Windows.Forms.Label label12;
        private Syncfusion.WinForms.Controls.SfButton sfButton3;
    }
}