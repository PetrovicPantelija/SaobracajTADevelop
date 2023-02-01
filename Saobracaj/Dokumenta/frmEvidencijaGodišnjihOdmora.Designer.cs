namespace Saobracaj.Dokumenta
{
    partial class frmEvidencijaGodišnjihOdmora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvidencijaGodišnjihOdmora));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsUnesiCenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.txtSumKorisceno = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSUMUkupno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboZaposleni = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNekorisceno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cboGodina = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbResenje = new System.Windows.Forms.CheckBox();
            this.cbMail = new System.Windows.Forms.CheckBox();
            this.btnPosaljiMail = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtNadredjeni = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbostatusGOdmora = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboOdobrio = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRazlog = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.txtUkupno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpDatumPovratka = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumZahteva = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.tsUnesiCenu,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1328, 31);
            this.toolStrip1.TabIndex = 142;
            this.toolStrip1.Text = "Unesi cenu za radnika";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(29, 28);
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
            // tsUnesiCenu
            // 
            this.tsUnesiCenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsUnesiCenu.Image = ((System.Drawing.Image)(resources.GetObject("tsUnesiCenu.Image")));
            this.tsUnesiCenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUnesiCenu.Name = "tsUnesiCenu";
            this.tsUnesiCenu.Size = new System.Drawing.Size(204, 24);
            this.tsUnesiCenu.Text = "Unesi cenu za zaposlenog";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(165, 24);
            this.toolStripButton1.Text = "Pripremi štampu/email";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(40, 24);
            this.toolStripButton2.Text = "LOG";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // txtSumKorisceno
            // 
            this.txtSumKorisceno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtSumKorisceno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtSumKorisceno.ForeColor = System.Drawing.Color.Blue;
            this.txtSumKorisceno.Location = new System.Drawing.Point(463, 41);
            this.txtSumKorisceno.Margin = new System.Windows.Forms.Padding(4);
            this.txtSumKorisceno.Name = "txtSumKorisceno";
            this.txtSumKorisceno.Size = new System.Drawing.Size(77, 24);
            this.txtSumKorisceno.TabIndex = 195;
            this.txtSumKorisceno.Text = "0";
            this.txtSumKorisceno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(460, 15);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 18);
            this.label16.TabIndex = 194;
            this.label16.Text = "Korišćeno:";
            // 
            // txtSUMUkupno
            // 
            this.txtSUMUkupno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSUMUkupno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtSUMUkupno.Location = new System.Drawing.Point(365, 41);
            this.txtSUMUkupno.Margin = new System.Windows.Forms.Padding(4);
            this.txtSUMUkupno.Name = "txtSUMUkupno";
            this.txtSUMUkupno.Size = new System.Drawing.Size(77, 24);
            this.txtSUMUkupno.TabIndex = 193;
            this.txtSUMUkupno.Text = "0";
            this.txtSUMUkupno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(363, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 192;
            this.label9.Text = "Ukupno:";
            // 
            // cboZaposleni
            // 
            this.cboZaposleni.FormattingEnabled = true;
            this.cboZaposleni.Location = new System.Drawing.Point(96, 14);
            this.cboZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.cboZaposleni.Name = "cboZaposleni";
            this.cboZaposleni.Size = new System.Drawing.Size(227, 24);
            this.cboZaposleni.TabIndex = 187;
            this.cboZaposleni.SelectedIndexChanged += new System.EventHandler(this.cboZaposleni_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 186;
            this.label4.Text = "Zaposleni:";
            // 
            // txtNekorisceno
            // 
            this.txtNekorisceno.BackColor = System.Drawing.Color.Red;
            this.txtNekorisceno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNekorisceno.ForeColor = System.Drawing.Color.White;
            this.txtNekorisceno.Location = new System.Drawing.Point(579, 41);
            this.txtNekorisceno.Margin = new System.Windows.Forms.Padding(4);
            this.txtNekorisceno.Name = "txtNekorisceno";
            this.txtNekorisceno.Size = new System.Drawing.Size(77, 24);
            this.txtNekorisceno.TabIndex = 197;
            this.txtNekorisceno.Text = "0";
            this.txtNekorisceno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(575, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 196;
            this.label1.Text = "Neiskorišćeno:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox2.Location = new System.Drawing.Point(721, 42);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 22);
            this.textBox2.TabIndex = 199;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(717, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 198;
            this.label2.Text = "Planirano:";
            this.label2.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 4);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(1271, 318);
            this.dataGridView2.TabIndex = 200;
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // cboGodina
            // 
            this.cboGodina.FormattingEnabled = true;
            this.cboGodina.Location = new System.Drawing.Point(96, 47);
            this.cboGodina.Margin = new System.Windows.Forms.Padding(4);
            this.cboGodina.Name = "cboGodina";
            this.cboGodina.Size = new System.Drawing.Size(119, 24);
            this.cboGodina.TabIndex = 202;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 201;
            this.label3.Text = "Godina:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbResenje);
            this.groupBox1.Controls.Add(this.cbMail);
            this.groupBox1.Controls.Add(this.btnPosaljiMail);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.txtNadredjeni);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbostatusGOdmora);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboOdobrio);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtRazlog);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNapomena);
            this.groupBox1.Controls.Add(this.txtUkupno);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpVremeDo);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dtpVremeOd);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtSifra);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 101);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1328, 263);
            this.groupBox1.TabIndex = 203;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stavke";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbResenje
            // 
            this.cbResenje.AutoSize = true;
            this.cbResenje.Location = new System.Drawing.Point(950, 59);
            this.cbResenje.Margin = new System.Windows.Forms.Padding(4);
            this.cbResenje.Name = "cbResenje";
            this.cbResenje.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbResenje.Size = new System.Drawing.Size(133, 21);
            this.cbResenje.TabIndex = 213;
            this.cbResenje.Text = "Poslato Resenje";
            this.cbResenje.UseVisualStyleBackColor = true;
            this.cbResenje.CheckedChanged += new System.EventHandler(this.cbResenje_CheckedChanged);
            // 
            // cbMail
            // 
            this.cbMail.AutoSize = true;
            this.cbMail.Location = new System.Drawing.Point(1083, 59);
            this.cbMail.Margin = new System.Windows.Forms.Padding(4);
            this.cbMail.Name = "cbMail";
            this.cbMail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbMail.Size = new System.Drawing.Size(107, 21);
            this.cbMail.TabIndex = 213;
            this.cbMail.Text = "Poslat Email";
            this.cbMail.UseVisualStyleBackColor = true;
            this.cbMail.CheckedChanged += new System.EventHandler(this.cbMail_CheckedChanged);
            // 
            // btnPosaljiMail
            // 
            this.btnPosaljiMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btnPosaljiMail.ForeColor = System.Drawing.Color.White;
            this.btnPosaljiMail.Location = new System.Drawing.Point(1195, 50);
            this.btnPosaljiMail.Margin = new System.Windows.Forms.Padding(4);
            this.btnPosaljiMail.Name = "btnPosaljiMail";
            this.btnPosaljiMail.Size = new System.Drawing.Size(116, 32);
            this.btnPosaljiMail.TabIndex = 210;
            this.btnPosaljiMail.Text = "Pošalji mail";
            this.btnPosaljiMail.UseVisualStyleBackColor = false;
            this.btnPosaljiMail.Click += new System.EventHandler(this.btnPosaljiMail_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(947, 21);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 17);
            this.label18.TabIndex = 209;
            this.label18.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(1032, 20);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(267, 22);
            this.txtEmail.TabIndex = 208;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(725, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 17);
            this.label11.TabIndex = 207;
            this.label11.Text = "Spisak slobodnih dana u godini:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(721, 89);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(582, 167);
            this.dataGridView1.TabIndex = 206;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // txtNadredjeni
            // 
            this.txtNadredjeni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtNadredjeni.Location = new System.Drawing.Point(101, 87);
            this.txtNadredjeni.Margin = new System.Windows.Forms.Padding(4);
            this.txtNadredjeni.Name = "txtNadredjeni";
            this.txtNadredjeni.Size = new System.Drawing.Size(68, 22);
            this.txtNadredjeni.TabIndex = 204;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 89);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 205;
            this.label10.Text = "Nadređeni:";
            // 
            // cbostatusGOdmora
            // 
            this.cbostatusGOdmora.FormattingEnabled = true;
            this.cbostatusGOdmora.Items.AddRange(new object[] {
            "1-Zahtevano",
            "2-Planirano",
            "3-Prihvaćeno",
            "4-Realizovano",
            "5-Odbijeno"});
            this.cbostatusGOdmora.Location = new System.Drawing.Point(493, 89);
            this.cbostatusGOdmora.Margin = new System.Windows.Forms.Padding(4);
            this.cbostatusGOdmora.Name = "cbostatusGOdmora";
            this.cbostatusGOdmora.Size = new System.Drawing.Size(211, 24);
            this.cbostatusGOdmora.TabIndex = 203;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 202;
            this.label5.Text = "Status god odmora:";
            // 
            // cboOdobrio
            // 
            this.cboOdobrio.FormattingEnabled = true;
            this.cboOdobrio.Location = new System.Drawing.Point(493, 55);
            this.cboOdobrio.Margin = new System.Windows.Forms.Padding(4);
            this.cboOdobrio.Name = "cboOdobrio";
            this.cboOdobrio.Size = new System.Drawing.Size(211, 24);
            this.cboOdobrio.TabIndex = 201;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(412, 55);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 17);
            this.label13.TabIndex = 200;
            this.label13.Text = "Odobrio:";
            // 
            // txtRazlog
            // 
            this.txtRazlog.Location = new System.Drawing.Point(101, 55);
            this.txtRazlog.Margin = new System.Windows.Forms.Padding(4);
            this.txtRazlog.Name = "txtRazlog";
            this.txtRazlog.Size = new System.Drawing.Size(301, 22);
            this.txtRazlog.TabIndex = 198;
            this.txtRazlog.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 55);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 17);
            this.label12.TabIndex = 199;
            this.label12.Text = "Razlog";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 153);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 17);
            this.label8.TabIndex = 197;
            this.label8.Text = "Dodatne beleške:";
            // 
            // txtNapomena
            // 
            this.txtNapomena.Location = new System.Drawing.Point(143, 153);
            this.txtNapomena.Margin = new System.Windows.Forms.Padding(4);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(561, 102);
            this.txtNapomena.TabIndex = 196;
            // 
            // txtUkupno
            // 
            this.txtUkupno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUkupno.Location = new System.Drawing.Point(775, 21);
            this.txtUkupno.Margin = new System.Windows.Forms.Padding(4);
            this.txtUkupno.Name = "txtUkupno";
            this.txtUkupno.Size = new System.Drawing.Size(56, 22);
            this.txtUkupno.TabIndex = 193;
            this.txtUkupno.Text = "0";
            this.txtUkupno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(683, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 192;
            this.label6.Text = "Ukupno:";
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeDo.Location = new System.Drawing.Point(493, 23);
            this.dtpVremeDo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.ShowUpDown = true;
            this.dtpVremeDo.Size = new System.Drawing.Size(152, 22);
            this.dtpVremeDo.TabIndex = 189;
            this.dtpVremeDo.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpVremeDo.Leave += new System.EventHandler(this.dtpVremeDo_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(412, 23);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 17);
            this.label15.TabIndex = 191;
            this.label15.Text = "Period do:";
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeOd.Location = new System.Drawing.Point(260, 22);
            this.dtpVremeOd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.ShowUpDown = true;
            this.dtpVremeOd.Size = new System.Drawing.Size(143, 22);
            this.dtpVremeOd.TabIndex = 188;
            this.dtpVremeOd.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(179, 23);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 17);
            this.label21.TabIndex = 190;
            this.label21.Text = "Period od:";
            // 
            // txtSifra
            // 
            this.txtSifra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtSifra.Location = new System.Drawing.Point(101, 22);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(68, 22);
            this.txtSifra.TabIndex = 186;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 187;
            this.label7.Text = "Šifra zapisa:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(224, 47);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 28);
            this.button1.TabIndex = 204;
            this.button1.Text = "Prikaži";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.dtpDatumPovratka);
            this.panel1.Controls.Add(this.dtpDatumZahteva);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboZaposleni);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.cboGodina);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNekorisceno);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtSumKorisceno);
            this.panel1.Controls.Add(this.txtSUMUkupno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1328, 94);
            this.panel1.TabIndex = 205;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(881, 53);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 17);
            this.label17.TabIndex = 211;
            this.label17.Text = "Datum povratka:";
            // 
            // dtpDatumPovratka
            // 
            this.dtpDatumPovratka.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumPovratka.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumPovratka.Location = new System.Drawing.Point(999, 54);
            this.dtpDatumPovratka.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumPovratka.Name = "dtpDatumPovratka";
            this.dtpDatumPovratka.ShowUpDown = true;
            this.dtpDatumPovratka.Size = new System.Drawing.Size(152, 22);
            this.dtpDatumPovratka.TabIndex = 210;
            this.dtpDatumPovratka.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dtpDatumZahteva
            // 
            this.dtpDatumZahteva.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumZahteva.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumZahteva.Location = new System.Drawing.Point(999, 23);
            this.dtpDatumZahteva.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumZahteva.Name = "dtpDatumZahteva";
            this.dtpDatumZahteva.ShowUpDown = true;
            this.dtpDatumZahteva.Size = new System.Drawing.Size(152, 22);
            this.dtpDatumZahteva.TabIndex = 208;
            this.dtpDatumZahteva.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(881, 23);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 17);
            this.label14.TabIndex = 209;
            this.label14.Text = "Datum zahteva:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1328, 364);
            this.panel2.TabIndex = 206;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 399);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1300, 374);
            this.tabControl1.TabIndex = 208;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1292, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stavke";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1292, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rešenje";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Saobracaj.Izvestaji.Najava.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(8, 7);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1273, 327);
            this.reportViewer1.TabIndex = 1;
            // 
            // frmEvidencijaGodišnjihOdmora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1328, 778);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEvidencijaGodišnjihOdmora";
            this.Text = "Evidencija Godišnjih odmora";
            this.Load += new System.EventHandler(this.frmEvidencijaGodišnjihOdmora_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsUnesiCenu;
        private System.Windows.Forms.TextBox txtSumKorisceno;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSUMUkupno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboZaposleni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNekorisceno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cboGodina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUkupno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.TextBox txtNadredjeni;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbostatusGOdmora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboOdobrio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRazlog;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpDatumPovratka;
        private System.Windows.Forms.DateTimePicker dtpDatumZahteva;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnPosaljiMail;
        private System.Windows.Forms.CheckBox cbMail;
        private System.Windows.Forms.CheckBox cbResenje;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}