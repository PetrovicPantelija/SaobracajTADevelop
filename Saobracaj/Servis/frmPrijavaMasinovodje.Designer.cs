namespace Saobracaj.Servis
{
    partial class frmPrijavaMasinovodje
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrijavaMasinovodje));
            this.txtSifra = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkPrijava = new MetroFramework.Controls.MetroCheckBox();
            this.cboZaposleni = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cboStanica = new MetroFramework.Controls.MetroComboBox();
            this.txtMotoSati = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtKM = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtGorivo = new MetroFramework.Controls.MetroTextBox();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtNapomena = new MetroFramework.Controls.MetroTextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.txtLokomotiva = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtAktivnostID = new MetroFramework.Controls.MetroTextBox();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.dataGridView1 = new MetroFramework.Controls.MetroGrid();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.txtDana = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSifra
            // 
            this.txtSifra.Lines = new string[0];
            this.txtSifra.Location = new System.Drawing.Point(143, 74);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSifra.MaxLength = 32767;
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.PasswordChar = '\0';
            this.txtSifra.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSifra.SelectedText = "";
            this.txtSifra.Size = new System.Drawing.Size(100, 28);
            this.txtSifra.TabIndex = 0;
            this.txtSifra.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(32, 70);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(22, 20);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "ID";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(32, 119);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(80, 20);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Lokomotiva";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // chkPrijava
            // 
            this.chkPrijava.AutoSize = true;
            this.chkPrijava.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPrijava.Location = new System.Drawing.Point(141, 158);
            this.chkPrijava.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPrijava.Name = "chkPrijava";
            this.chkPrijava.Size = new System.Drawing.Size(116, 17);
            this.chkPrijava.Style = MetroFramework.MetroColorStyle.Lime;
            this.chkPrijava.TabIndex = 4;
            this.chkPrijava.Text = "Prijava - Odjava";
            this.chkPrijava.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPrijava.UseCustomBackColor = true;
            this.chkPrijava.UseSelectable = true;
            // 
            // cboZaposleni
            // 
            this.cboZaposleni.FormattingEnabled = true;
            this.cboZaposleni.ItemHeight = 24;
            this.cboZaposleni.Location = new System.Drawing.Point(143, 185);
            this.cboZaposleni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboZaposleni.Name = "cboZaposleni";
            this.cboZaposleni.Size = new System.Drawing.Size(265, 30);
            this.cboZaposleni.TabIndex = 5;
            this.cboZaposleni.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(32, 182);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(69, 20);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Zaposleni";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(456, 70);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(101, 20);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Datum i vreme";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(456, 119);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(52, 20);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "Stanica";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // cboStanica
            // 
            this.cboStanica.FormattingEnabled = true;
            this.cboStanica.ItemHeight = 24;
            this.cboStanica.Location = new System.Drawing.Point(609, 119);
            this.cboStanica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboStanica.Name = "cboStanica";
            this.cboStanica.Size = new System.Drawing.Size(265, 30);
            this.cboStanica.TabIndex = 9;
            this.cboStanica.UseSelectable = true;
            // 
            // txtMotoSati
            // 
            this.txtMotoSati.Lines = new string[] {
        "0"};
            this.txtMotoSati.Location = new System.Drawing.Point(1012, 114);
            this.txtMotoSati.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMotoSati.MaxLength = 32767;
            this.txtMotoSati.Name = "txtMotoSati";
            this.txtMotoSati.PasswordChar = '\0';
            this.txtMotoSati.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMotoSati.SelectedText = "";
            this.txtMotoSati.Size = new System.Drawing.Size(109, 28);
            this.txtMotoSati.TabIndex = 11;
            this.txtMotoSati.Text = "0";
            this.txtMotoSati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMotoSati.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(899, 114);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(66, 20);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "Moto Sati";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(899, 70);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(29, 20);
            this.metroLabel7.TabIndex = 14;
            this.metroLabel7.Text = "KM";
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // txtKM
            // 
            this.txtKM.Lines = new string[] {
        "0"};
            this.txtKM.Location = new System.Drawing.Point(1012, 74);
            this.txtKM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKM.MaxLength = 32767;
            this.txtKM.Name = "txtKM";
            this.txtKM.PasswordChar = '\0';
            this.txtKM.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtKM.SelectedText = "";
            this.txtKM.Size = new System.Drawing.Size(109, 28);
            this.txtKM.TabIndex = 13;
            this.txtKM.Text = "0";
            this.txtKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKM.UseSelectable = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(899, 158);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(50, 20);
            this.metroLabel8.TabIndex = 16;
            this.metroLabel8.Text = "Gorivo";
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // txtGorivo
            // 
            this.txtGorivo.Lines = new string[] {
        "0"};
            this.txtGorivo.Location = new System.Drawing.Point(1012, 158);
            this.txtGorivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGorivo.MaxLength = 32767;
            this.txtGorivo.Name = "txtGorivo";
            this.txtGorivo.PasswordChar = '\0';
            this.txtGorivo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGorivo.SelectedText = "";
            this.txtGorivo.Size = new System.Drawing.Size(109, 28);
            this.txtGorivo.TabIndex = 15;
            this.txtGorivo.Text = "0";
            this.txtGorivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGorivo.UseSelectable = true;
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(-4, 302);
            this.metroGrid1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidth = 51;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(320, 185);
            this.metroGrid1.TabIndex = 17;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.Location = new System.Drawing.Point(1151, 70);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(263, 32);
            this.metroButton1.TabIndex = 19;
            this.metroButton1.Text = "Ažuriraj podatke";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(456, 162);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(78, 20);
            this.metroLabel9.TabIndex = 21;
            this.metroLabel9.Text = "Napomena";
            this.metroLabel9.UseCustomBackColor = true;
            // 
            // txtNapomena
            // 
            this.txtNapomena.Lines = new string[0];
            this.txtNapomena.Location = new System.Drawing.Point(609, 162);
            this.txtNapomena.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNapomena.MaxLength = 32767;
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.PasswordChar = '\0';
            this.txtNapomena.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNapomena.SelectedText = "";
            this.txtNapomena.Size = new System.Drawing.Size(267, 58);
            this.txtNapomena.TabIndex = 20;
            this.txtNapomena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNapomena.UseSelectable = true;
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.metroButton2.ForeColor = System.Drawing.Color.White;
            this.metroButton2.Location = new System.Drawing.Point(1441, 116);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(263, 32);
            this.metroButton2.TabIndex = 22;
            this.metroButton2.Text = "Briši zapis";
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseCustomForeColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.metroButton3.ForeColor = System.Drawing.Color.White;
            this.metroButton3.Location = new System.Drawing.Point(1151, 154);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(263, 32);
            this.metroButton3.TabIndex = 23;
            this.metroButton3.Text = "Promeni zapis";
            this.metroButton3.UseCustomBackColor = true;
            this.metroButton3.UseCustomForeColor = true;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // txtLokomotiva
            // 
            this.txtLokomotiva.FormattingEnabled = true;
            this.txtLokomotiva.ItemHeight = 24;
            this.txtLokomotiva.Location = new System.Drawing.Point(143, 112);
            this.txtLokomotiva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLokomotiva.Name = "txtLokomotiva";
            this.txtLokomotiva.Size = new System.Drawing.Size(265, 30);
            this.txtLokomotiva.TabIndex = 24;
            this.txtLokomotiva.UseSelectable = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(899, 198);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(82, 20);
            this.metroLabel10.TabIndex = 26;
            this.metroLabel10.Text = "Aktivnost ID";
            this.metroLabel10.UseCustomBackColor = true;
            // 
            // txtAktivnostID
            // 
            this.txtAktivnostID.Lines = new string[] {
        "0"};
            this.txtAktivnostID.Location = new System.Drawing.Point(1012, 198);
            this.txtAktivnostID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAktivnostID.MaxLength = 32767;
            this.txtAktivnostID.Name = "txtAktivnostID";
            this.txtAktivnostID.PasswordChar = '\0';
            this.txtAktivnostID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAktivnostID.SelectedText = "";
            this.txtAktivnostID.Size = new System.Drawing.Size(109, 28);
            this.txtAktivnostID.TabIndex = 25;
            this.txtAktivnostID.Text = "0";
            this.txtAktivnostID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAktivnostID.UseSelectable = true;
            // 
            // metroButton4
            // 
            this.metroButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.metroButton4.ForeColor = System.Drawing.Color.White;
            this.metroButton4.Location = new System.Drawing.Point(1441, 74);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(263, 32);
            this.metroButton4.TabIndex = 27;
            this.metroButton4.Text = "Dodaj zapis";
            this.metroButton4.UseCustomBackColor = true;
            this.metroButton4.UseCustomForeColor = true;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.metroButton5.ForeColor = System.Drawing.Color.White;
            this.metroButton5.Location = new System.Drawing.Point(1151, 110);
            this.metroButton5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(263, 32);
            this.metroButton5.TabIndex = 28;
            this.metroButton5.Text = "Odjavi prijavu";
            this.metroButton5.UseCustomBackColor = true;
            this.metroButton5.UseCustomForeColor = true;
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(31, 245);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1765, 649);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged_1);
            // 
            // dtpDatum
            // 
            this.dtpDatum.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatum.Location = new System.Drawing.Point(609, 74);
            this.dtpDatum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.ShowUpDown = true;
            this.dtpDatum.Size = new System.Drawing.Size(265, 22);
            this.dtpDatum.TabIndex = 30;
            this.dtpDatum.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // txtDana
            // 
            this.txtDana.Lines = new string[] {
        "-2"};
            this.txtDana.Location = new System.Drawing.Point(1595, 177);
            this.txtDana.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDana.MaxLength = 32767;
            this.txtDana.Name = "txtDana";
            this.txtDana.PasswordChar = '\0';
            this.txtDana.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDana.SelectedText = "";
            this.txtDana.Size = new System.Drawing.Size(109, 28);
            this.txtDana.TabIndex = 31;
            this.txtDana.Text = "-2";
            this.txtDana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDana.UseSelectable = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(1484, 177);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(41, 20);
            this.metroLabel11.TabIndex = 32;
            this.metroLabel11.Text = "Dana";
            this.metroLabel11.UseCustomBackColor = true;
            // 
            // frmPrijavaMasinovodje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1827, 922);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.txtDana);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.txtAktivnostID);
            this.Controls.Add(this.txtLokomotiva);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.txtGorivo);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtKM);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtMotoSati);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cboStanica);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cboZaposleni);
            this.Controls.Add(this.chkPrijava);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtSifra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPrijavaMasinovodje";
            this.Text = "Prijave - Odjave Mašinovođe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrijavaMasinovodje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtSifra;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox chkPrijava;
        private MetroFramework.Controls.MetroComboBox cboZaposleni;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cboStanica;
        private MetroFramework.Controls.MetroTextBox txtMotoSati;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtKM;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtGorivo;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txtNapomena;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroComboBox txtLokomotiva;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txtAktivnostID;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroGrid dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private MetroFramework.Controls.MetroTextBox txtDana;
        private MetroFramework.Controls.MetroLabel metroLabel11;
    }
}