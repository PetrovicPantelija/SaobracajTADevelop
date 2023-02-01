
namespace Saobracaj.Dokumenta
{
    partial class frmAutomobiliPregledPrijava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutomobiliPregledPrijava));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_Zaposleni = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDatumPrijave = new MetroFramework.Controls.MetroDateTime();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_Automobil = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Relacija = new System.Windows.Forms.TextBox();
            this.cb_DirPredZad = new System.Windows.Forms.CheckBox();
            this.txt_KmZaduzenje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Plomba1Zad = new System.Windows.Forms.CheckBox();
            this.cb_Plomba2Zad = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.combo_CistocaSpoljaZad = new System.Windows.Forms.ComboBox();
            this.combo_CistocaUnutraZad = new System.Windows.Forms.ComboBox();
            this.combo_NivoUljaZad = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dt_Odjava = new MetroFramework.Controls.MetroDateTime();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_KmRazduzenje = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.combo_CistocaSpoljaRaz = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.combo_CistocaUnutraRaz = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.combo_NivoUljaRaz = new System.Windows.Forms.ComboBox();
            this.cb_DirPredRaz = new System.Windows.Forms.CheckBox();
            this.cb_Plomba1Raz = new System.Windows.Forms.CheckBox();
            this.cb_Plomba2Raz = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Sifra = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_OtvoriSliku = new System.Windows.Forms.Button();
            this.btn_nazad = new System.Windows.Forms.Button();
            this.btn_Napred = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 324);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1785, 411);
            this.dataGridView1.TabIndex = 205;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
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
            this.toolStrip1.Size = new System.Drawing.Size(1827, 27);
            this.toolStrip1.TabIndex = 206;
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
            this.label3.Location = new System.Drawing.Point(21, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 207;
            this.label3.Text = "Zaposleni:";
            // 
            // combo_Zaposleni
            // 
            this.combo_Zaposleni.FormattingEnabled = true;
            this.combo_Zaposleni.Location = new System.Drawing.Point(144, 82);
            this.combo_Zaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Zaposleni.Name = "combo_Zaposleni";
            this.combo_Zaposleni.Size = new System.Drawing.Size(339, 24);
            this.combo_Zaposleni.TabIndex = 208;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 209;
            this.label5.Text = "Datum prijave:";
            // 
            // dtpDatumPrijave
            // 
            this.dtpDatumPrijave.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumPrijave.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumPrijave.Location = new System.Drawing.Point(144, 119);
            this.dtpDatumPrijave.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumPrijave.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtpDatumPrijave.Name = "dtpDatumPrijave";
            this.dtpDatumPrijave.Size = new System.Drawing.Size(265, 30);
            this.dtpDatumPrijave.TabIndex = 210;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 211;
            this.label2.Text = "Automobil:";
            // 
            // combo_Automobil
            // 
            this.combo_Automobil.FormattingEnabled = true;
            this.combo_Automobil.Location = new System.Drawing.Point(144, 210);
            this.combo_Automobil.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Automobil.Name = "combo_Automobil";
            this.combo_Automobil.Size = new System.Drawing.Size(339, 24);
            this.combo_Automobil.TabIndex = 212;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 257);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 211;
            this.label1.Text = "Relacija:";
            // 
            // txt_Relacija
            // 
            this.txt_Relacija.Location = new System.Drawing.Point(144, 252);
            this.txt_Relacija.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Relacija.Name = "txt_Relacija";
            this.txt_Relacija.Size = new System.Drawing.Size(185, 22);
            this.txt_Relacija.TabIndex = 213;
            // 
            // cb_DirPredZad
            // 
            this.cb_DirPredZad.AutoSize = true;
            this.cb_DirPredZad.Location = new System.Drawing.Point(495, 217);
            this.cb_DirPredZad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_DirPredZad.Name = "cb_DirPredZad";
            this.cb_DirPredZad.Size = new System.Drawing.Size(241, 21);
            this.cb_DirPredZad.TabIndex = 214;
            this.cb_DirPredZad.Text = "Direktna primopredaja Zaduženje";
            this.cb_DirPredZad.UseVisualStyleBackColor = true;
            // 
            // txt_KmZaduzenje
            // 
            this.txt_KmZaduzenje.Location = new System.Drawing.Point(676, 42);
            this.txt_KmZaduzenje.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_KmZaduzenje.Name = "txt_KmZaduzenje";
            this.txt_KmZaduzenje.Size = new System.Drawing.Size(191, 22);
            this.txt_KmZaduzenje.TabIndex = 213;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(491, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 211;
            this.label4.Text = "KM Zaduženje:";
            // 
            // cb_Plomba1Zad
            // 
            this.cb_Plomba1Zad.AutoSize = true;
            this.cb_Plomba1Zad.Location = new System.Drawing.Point(495, 249);
            this.cb_Plomba1Zad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Plomba1Zad.Name = "cb_Plomba1Zad";
            this.cb_Plomba1Zad.Size = new System.Drawing.Size(213, 21);
            this.cb_Plomba1Zad.TabIndex = 215;
            this.cb_Plomba1Zad.Text = "Plomba 1 Potvrda Zaduženja";
            this.cb_Plomba1Zad.UseVisualStyleBackColor = true;
            // 
            // cb_Plomba2Zad
            // 
            this.cb_Plomba2Zad.AutoSize = true;
            this.cb_Plomba2Zad.Location = new System.Drawing.Point(495, 279);
            this.cb_Plomba2Zad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Plomba2Zad.Name = "cb_Plomba2Zad";
            this.cb_Plomba2Zad.Size = new System.Drawing.Size(213, 21);
            this.cb_Plomba2Zad.TabIndex = 215;
            this.cb_Plomba2Zad.Text = "Plomba 2 Potvrda Zaduženja";
            this.cb_Plomba2Zad.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(491, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 17);
            this.label6.TabIndex = 211;
            this.label6.Text = "Čistoća Spolja Zaduživanje";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(491, 133);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 17);
            this.label7.TabIndex = 211;
            this.label7.Text = "Čistoća Unutra Zaduživanje";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(491, 176);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 17);
            this.label8.TabIndex = 211;
            this.label8.Text = "Nivo Ulja Zaduživanje:";
            // 
            // combo_CistocaSpoljaZad
            // 
            this.combo_CistocaSpoljaZad.FormattingEnabled = true;
            this.combo_CistocaSpoljaZad.Location = new System.Drawing.Point(676, 85);
            this.combo_CistocaSpoljaZad.Margin = new System.Windows.Forms.Padding(4);
            this.combo_CistocaSpoljaZad.Name = "combo_CistocaSpoljaZad";
            this.combo_CistocaSpoljaZad.Size = new System.Drawing.Size(191, 24);
            this.combo_CistocaSpoljaZad.TabIndex = 212;
            // 
            // combo_CistocaUnutraZad
            // 
            this.combo_CistocaUnutraZad.FormattingEnabled = true;
            this.combo_CistocaUnutraZad.Location = new System.Drawing.Point(676, 130);
            this.combo_CistocaUnutraZad.Margin = new System.Windows.Forms.Padding(4);
            this.combo_CistocaUnutraZad.Name = "combo_CistocaUnutraZad";
            this.combo_CistocaUnutraZad.Size = new System.Drawing.Size(191, 24);
            this.combo_CistocaUnutraZad.TabIndex = 212;
            // 
            // combo_NivoUljaZad
            // 
            this.combo_NivoUljaZad.FormattingEnabled = true;
            this.combo_NivoUljaZad.Location = new System.Drawing.Point(676, 174);
            this.combo_NivoUljaZad.Margin = new System.Windows.Forms.Padding(4);
            this.combo_NivoUljaZad.Name = "combo_NivoUljaZad";
            this.combo_NivoUljaZad.Size = new System.Drawing.Size(191, 24);
            this.combo_NivoUljaZad.TabIndex = 212;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 178);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 209;
            this.label9.Text = "Datum odjave:";
            // 
            // dt_Odjava
            // 
            this.dt_Odjava.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dt_Odjava.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Odjava.Location = new System.Drawing.Point(144, 164);
            this.dt_Odjava.Margin = new System.Windows.Forms.Padding(4);
            this.dt_Odjava.MinimumSize = new System.Drawing.Size(0, 30);
            this.dt_Odjava.Name = "dt_Odjava";
            this.dt_Odjava.Size = new System.Drawing.Size(265, 30);
            this.dt_Odjava.TabIndex = 210;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(879, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 17);
            this.label10.TabIndex = 211;
            this.label10.Text = "KM Razduženje:";
            // 
            // txt_KmRazduzenje
            // 
            this.txt_KmRazduzenje.Location = new System.Drawing.Point(1075, 43);
            this.txt_KmRazduzenje.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_KmRazduzenje.Name = "txt_KmRazduzenje";
            this.txt_KmRazduzenje.Size = new System.Drawing.Size(191, 22);
            this.txt_KmRazduzenje.TabIndex = 213;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(879, 86);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 17);
            this.label11.TabIndex = 211;
            this.label11.Text = "Čistoća Spolja Razduživanje";
            // 
            // combo_CistocaSpoljaRaz
            // 
            this.combo_CistocaSpoljaRaz.FormattingEnabled = true;
            this.combo_CistocaSpoljaRaz.Location = new System.Drawing.Point(1075, 82);
            this.combo_CistocaSpoljaRaz.Margin = new System.Windows.Forms.Padding(4);
            this.combo_CistocaSpoljaRaz.Name = "combo_CistocaSpoljaRaz";
            this.combo_CistocaSpoljaRaz.Size = new System.Drawing.Size(191, 24);
            this.combo_CistocaSpoljaRaz.TabIndex = 212;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(879, 127);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(190, 17);
            this.label12.TabIndex = 211;
            this.label12.Text = "Čistoća Unutra Razduživanje";
            // 
            // combo_CistocaUnutraRaz
            // 
            this.combo_CistocaUnutraRaz.FormattingEnabled = true;
            this.combo_CistocaUnutraRaz.Location = new System.Drawing.Point(1075, 123);
            this.combo_CistocaUnutraRaz.Margin = new System.Windows.Forms.Padding(4);
            this.combo_CistocaUnutraRaz.Name = "combo_CistocaUnutraRaz";
            this.combo_CistocaUnutraRaz.Size = new System.Drawing.Size(191, 24);
            this.combo_CistocaUnutraRaz.TabIndex = 212;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(879, 170);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 17);
            this.label13.TabIndex = 211;
            this.label13.Text = "Nivo Ulja Razduživanje:";
            // 
            // combo_NivoUljaRaz
            // 
            this.combo_NivoUljaRaz.FormattingEnabled = true;
            this.combo_NivoUljaRaz.Location = new System.Drawing.Point(1075, 166);
            this.combo_NivoUljaRaz.Margin = new System.Windows.Forms.Padding(4);
            this.combo_NivoUljaRaz.Name = "combo_NivoUljaRaz";
            this.combo_NivoUljaRaz.Size = new System.Drawing.Size(191, 24);
            this.combo_NivoUljaRaz.TabIndex = 212;
            // 
            // cb_DirPredRaz
            // 
            this.cb_DirPredRaz.AutoSize = true;
            this.cb_DirPredRaz.Location = new System.Drawing.Point(881, 214);
            this.cb_DirPredRaz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_DirPredRaz.Name = "cb_DirPredRaz";
            this.cb_DirPredRaz.Size = new System.Drawing.Size(259, 21);
            this.cb_DirPredRaz.TabIndex = 214;
            this.cb_DirPredRaz.Text = "Direktna primopredaja Razduživanje";
            this.cb_DirPredRaz.UseVisualStyleBackColor = true;
            // 
            // cb_Plomba1Raz
            // 
            this.cb_Plomba1Raz.AutoSize = true;
            this.cb_Plomba1Raz.Location = new System.Drawing.Point(881, 246);
            this.cb_Plomba1Raz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Plomba1Raz.Name = "cb_Plomba1Raz";
            this.cb_Plomba1Raz.Size = new System.Drawing.Size(231, 21);
            this.cb_Plomba1Raz.TabIndex = 215;
            this.cb_Plomba1Raz.Text = "Plomba 1 Potvrda Razduživanje";
            this.cb_Plomba1Raz.UseVisualStyleBackColor = true;
            // 
            // cb_Plomba2Raz
            // 
            this.cb_Plomba2Raz.AutoSize = true;
            this.cb_Plomba2Raz.Location = new System.Drawing.Point(881, 277);
            this.cb_Plomba2Raz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Plomba2Raz.Name = "cb_Plomba2Raz";
            this.cb_Plomba2Raz.Size = new System.Drawing.Size(231, 21);
            this.cb_Plomba2Raz.TabIndex = 215;
            this.cb_Plomba2Raz.Text = "Plomba 2 Potvrda Razduživanje";
            this.cb_Plomba2Raz.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 47);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 17);
            this.label15.TabIndex = 207;
            this.label15.Text = "Šifra:";
            // 
            // txt_Sifra
            // 
            this.txt_Sifra.Location = new System.Drawing.Point(144, 47);
            this.txt_Sifra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Sifra.Name = "txt_Sifra";
            this.txt_Sifra.Size = new System.Drawing.Size(185, 22);
            this.txt_Sifra.TabIndex = 216;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(1273, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(417, 288);
            this.pictureBox1.TabIndex = 217;
            this.pictureBox1.TabStop = false;
            // 
            // btn_OtvoriSliku
            // 
            this.btn_OtvoriSliku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_OtvoriSliku.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_OtvoriSliku.Location = new System.Drawing.Point(1703, 28);
            this.btn_OtvoriSliku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_OtvoriSliku.Name = "btn_OtvoriSliku";
            this.btn_OtvoriSliku.Size = new System.Drawing.Size(109, 34);
            this.btn_OtvoriSliku.TabIndex = 218;
            this.btn_OtvoriSliku.Text = "Otvori";
            this.btn_OtvoriSliku.UseVisualStyleBackColor = false;
            this.btn_OtvoriSliku.Click += new System.EventHandler(this.btn_OtvoriSliku_Click);
            // 
            // btn_nazad
            // 
            this.btn_nazad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_nazad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_nazad.Location = new System.Drawing.Point(1703, 124);
            this.btn_nazad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_nazad.Name = "btn_nazad";
            this.btn_nazad.Size = new System.Drawing.Size(109, 34);
            this.btn_nazad.TabIndex = 218;
            this.btn_nazad.Text = "<<";
            this.btn_nazad.UseVisualStyleBackColor = false;
            this.btn_nazad.Click += new System.EventHandler(this.btn_nazad_Click);
            // 
            // btn_Napred
            // 
            this.btn_Napred.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_Napred.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Napred.Location = new System.Drawing.Point(1703, 73);
            this.btn_Napred.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Napred.Name = "btn_Napred";
            this.btn_Napred.Size = new System.Drawing.Size(109, 34);
            this.btn_Napred.TabIndex = 218;
            this.btn_Napred.Text = ">>";
            this.btn_Napred.UseVisualStyleBackColor = false;
            this.btn_Napred.Click += new System.EventHandler(this.btn_Napred_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(1703, 218);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 34);
            this.button1.TabIndex = 218;
            this.button1.Text = "Otvori folder";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAutomobiliPregledPrijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1827, 750);
            this.Controls.Add(this.btn_Napred);
            this.Controls.Add(this.btn_nazad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_OtvoriSliku);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_Sifra);
            this.Controls.Add(this.cb_Plomba2Raz);
            this.Controls.Add(this.cb_Plomba2Zad);
            this.Controls.Add(this.cb_Plomba1Raz);
            this.Controls.Add(this.cb_Plomba1Zad);
            this.Controls.Add(this.cb_DirPredRaz);
            this.Controls.Add(this.cb_DirPredZad);
            this.Controls.Add(this.txt_KmRazduzenje);
            this.Controls.Add(this.txt_KmZaduzenje);
            this.Controls.Add(this.txt_Relacija);
            this.Controls.Add(this.combo_NivoUljaRaz);
            this.Controls.Add(this.combo_NivoUljaZad);
            this.Controls.Add(this.combo_CistocaUnutraRaz);
            this.Controls.Add(this.combo_CistocaUnutraZad);
            this.Controls.Add(this.combo_CistocaSpoljaRaz);
            this.Controls.Add(this.combo_CistocaSpoljaZad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.combo_Automobil);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt_Odjava);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpDatumPrijave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.combo_Zaposleni);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAutomobiliPregledPrijava";
            this.Text = "Automobili pregled Zaduzenja/Razduzduzenja";
            this.Load += new System.EventHandler(this.frmAutomobiliPregledPrijava_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_Zaposleni;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroDateTime dtpDatumPrijave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_Automobil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Relacija;
        private System.Windows.Forms.CheckBox cb_DirPredZad;
        private System.Windows.Forms.TextBox txt_KmZaduzenje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_Plomba1Zad;
        private System.Windows.Forms.CheckBox cb_Plomba2Zad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combo_CistocaSpoljaZad;
        private System.Windows.Forms.ComboBox combo_CistocaUnutraZad;
        private System.Windows.Forms.ComboBox combo_NivoUljaZad;
        private System.Windows.Forms.Label label9;
        private MetroFramework.Controls.MetroDateTime dt_Odjava;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_KmRazduzenje;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox combo_CistocaSpoljaRaz;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox combo_CistocaUnutraRaz;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox combo_NivoUljaRaz;
        private System.Windows.Forms.CheckBox cb_DirPredRaz;
        private System.Windows.Forms.CheckBox cb_Plomba1Raz;
        private System.Windows.Forms.CheckBox cb_Plomba2Raz;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_Sifra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_OtvoriSliku;
        private System.Windows.Forms.Button btn_nazad;
        private System.Windows.Forms.Button btn_Napred;
        private System.Windows.Forms.Button button1;
    }
}