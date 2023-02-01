namespace Saobracaj.Dokumenta
{
    partial class frmDokumentaNajava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDokumentaNajava));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSifraNajave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPutanja = new System.Windows.Forms.TextBox();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPutanja2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSacuvajTovarniList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTovarniList = new System.Windows.Forms.TextBox();
            this.btnTovarniList = new System.Windows.Forms.Button();
            this.btnCIT23Sacuvaj = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCIT23 = new System.Windows.Forms.TextBox();
            this.btnCIT23 = new System.Windows.Forms.Button();
            this.btnRacunSacuvaj = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRacun = new System.Windows.Forms.TextBox();
            this.btnRacun = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrijemnaTeretnica = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.txtTipPrevoza = new System.Windows.Forms.TextBox();
            this.txtObjedinjen = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1113, 27);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
            // txtSifra
            // 
            this.txtSifra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSifra.Location = new System.Drawing.Point(121, 46);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(73, 22);
            this.txtSifra.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "Šifra";
            // 
            // txtSifraNajave
            // 
            this.txtSifraNajave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSifraNajave.Location = new System.Drawing.Point(313, 46);
            this.txtSifraNajave.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifraNajave.Name = "txtSifraNajave";
            this.txtSifraNajave.Size = new System.Drawing.Size(113, 22);
            this.txtSifraNajave.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 34;
            this.label3.Text = "Šifra najave";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(557, 235);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pronađi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPutanja
            // 
            this.txtPutanja.Location = new System.Drawing.Point(120, 235);
            this.txtPutanja.Margin = new System.Windows.Forms.Padding(4);
            this.txtPutanja.Name = "txtPutanja";
            this.txtPutanja.Size = new System.Drawing.Size(428, 22);
            this.txtPutanja.TabIndex = 3;
            // 
            // ofd1
            // 
            this.ofd1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 239);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "Ostala dok";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 313);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1080, 193);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(656, 235);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 25);
            this.button2.TabIndex = 42;
            this.button2.Text = "Otvori";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "CIM";
            // 
            // txtPutanja2
            // 
            this.txtPutanja2.Enabled = false;
            this.txtPutanja2.Location = new System.Drawing.Point(120, 113);
            this.txtPutanja2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPutanja2.Name = "txtPutanja2";
            this.txtPutanja2.Size = new System.Drawing.Size(428, 22);
            this.txtPutanja2.TabIndex = 43;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.button3.Enabled = false;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(557, 112);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 25);
            this.button3.TabIndex = 44;
            this.button3.Text = "Pronađi";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(765, 234);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 25);
            this.button4.TabIndex = 47;
            this.button4.Text = "Sačuvaj";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button6.Enabled = false;
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(765, 108);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(81, 25);
            this.button6.TabIndex = 48;
            this.button6.Text = "Sačuvaj";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnSacuvajTovarniList
            // 
            this.btnSacuvajTovarniList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btnSacuvajTovarniList.Enabled = false;
            this.btnSacuvajTovarniList.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSacuvajTovarniList.Location = new System.Drawing.Point(765, 76);
            this.btnSacuvajTovarniList.Margin = new System.Windows.Forms.Padding(4);
            this.btnSacuvajTovarniList.Name = "btnSacuvajTovarniList";
            this.btnSacuvajTovarniList.Size = new System.Drawing.Size(81, 25);
            this.btnSacuvajTovarniList.TabIndex = 52;
            this.btnSacuvajTovarniList.Text = "Sačuvaj";
            this.btnSacuvajTovarniList.UseVisualStyleBackColor = false;
            this.btnSacuvajTovarniList.Click += new System.EventHandler(this.btnSacuvajTovarniList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 51;
            this.label5.Text = "Tovarni list";
            // 
            // txtTovarniList
            // 
            this.txtTovarniList.Enabled = false;
            this.txtTovarniList.Location = new System.Drawing.Point(120, 81);
            this.txtTovarniList.Margin = new System.Windows.Forms.Padding(4);
            this.txtTovarniList.Name = "txtTovarniList";
            this.txtTovarniList.Size = new System.Drawing.Size(428, 22);
            this.txtTovarniList.TabIndex = 49;
            // 
            // btnTovarniList
            // 
            this.btnTovarniList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.btnTovarniList.Enabled = false;
            this.btnTovarniList.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTovarniList.Location = new System.Drawing.Point(557, 80);
            this.btnTovarniList.Margin = new System.Windows.Forms.Padding(4);
            this.btnTovarniList.Name = "btnTovarniList";
            this.btnTovarniList.Size = new System.Drawing.Size(79, 25);
            this.btnTovarniList.TabIndex = 50;
            this.btnTovarniList.Text = "Pronađi";
            this.btnTovarniList.UseVisualStyleBackColor = false;
            this.btnTovarniList.Click += new System.EventHandler(this.btnTovarniList_Click);
            // 
            // btnCIT23Sacuvaj
            // 
            this.btnCIT23Sacuvaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btnCIT23Sacuvaj.Enabled = false;
            this.btnCIT23Sacuvaj.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCIT23Sacuvaj.Location = new System.Drawing.Point(765, 140);
            this.btnCIT23Sacuvaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnCIT23Sacuvaj.Name = "btnCIT23Sacuvaj";
            this.btnCIT23Sacuvaj.Size = new System.Drawing.Size(81, 25);
            this.btnCIT23Sacuvaj.TabIndex = 56;
            this.btnCIT23Sacuvaj.Text = "Sačuvaj";
            this.btnCIT23Sacuvaj.UseVisualStyleBackColor = false;
            this.btnCIT23Sacuvaj.Click += new System.EventHandler(this.btnCIT23Sacuvaj_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "CIT23";
            // 
            // txtCIT23
            // 
            this.txtCIT23.Enabled = false;
            this.txtCIT23.Location = new System.Drawing.Point(120, 145);
            this.txtCIT23.Margin = new System.Windows.Forms.Padding(4);
            this.txtCIT23.Name = "txtCIT23";
            this.txtCIT23.Size = new System.Drawing.Size(428, 22);
            this.txtCIT23.TabIndex = 53;
            // 
            // btnCIT23
            // 
            this.btnCIT23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.btnCIT23.Enabled = false;
            this.btnCIT23.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCIT23.Location = new System.Drawing.Point(557, 144);
            this.btnCIT23.Margin = new System.Windows.Forms.Padding(4);
            this.btnCIT23.Name = "btnCIT23";
            this.btnCIT23.Size = new System.Drawing.Size(79, 25);
            this.btnCIT23.TabIndex = 54;
            this.btnCIT23.Text = "Pronađi";
            this.btnCIT23.UseVisualStyleBackColor = false;
            this.btnCIT23.Click += new System.EventHandler(this.btnCIT23_Click);
            // 
            // btnRacunSacuvaj
            // 
            this.btnRacunSacuvaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btnRacunSacuvaj.Enabled = false;
            this.btnRacunSacuvaj.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRacunSacuvaj.Location = new System.Drawing.Point(765, 172);
            this.btnRacunSacuvaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnRacunSacuvaj.Name = "btnRacunSacuvaj";
            this.btnRacunSacuvaj.Size = new System.Drawing.Size(81, 25);
            this.btnRacunSacuvaj.TabIndex = 60;
            this.btnRacunSacuvaj.Text = "Sačuvaj";
            this.btnRacunSacuvaj.UseVisualStyleBackColor = false;
            this.btnRacunSacuvaj.Click += new System.EventHandler(this.btnRacunSacuvaj_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 181);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 59;
            this.label7.Text = "Račun";
            // 
            // txtRacun
            // 
            this.txtRacun.Enabled = false;
            this.txtRacun.Location = new System.Drawing.Point(120, 177);
            this.txtRacun.Margin = new System.Windows.Forms.Padding(4);
            this.txtRacun.Name = "txtRacun";
            this.txtRacun.Size = new System.Drawing.Size(428, 22);
            this.txtRacun.TabIndex = 57;
            // 
            // btnRacun
            // 
            this.btnRacun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.btnRacun.Enabled = false;
            this.btnRacun.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRacun.Location = new System.Drawing.Point(557, 176);
            this.btnRacun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRacun.Name = "btnRacun";
            this.btnRacun.Size = new System.Drawing.Size(79, 25);
            this.btnRacun.TabIndex = 58;
            this.btnRacun.Text = "Pronađi";
            this.btnRacun.UseVisualStyleBackColor = false;
            this.btnRacun.Click += new System.EventHandler(this.btnRacun_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.button12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button12.Location = new System.Drawing.Point(16, 267);
            this.button12.Margin = new System.Windows.Forms.Padding(4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(289, 38);
            this.button12.TabIndex = 61;
            this.button12.Text = "Dokumentacija pripremljena formiraj pdf ";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button13.Location = new System.Drawing.Point(765, 202);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(81, 25);
            this.button13.TabIndex = 65;
            this.button13.Text = "Sačuvaj";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(15, 206);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 33);
            this.label8.TabIndex = 64;
            this.label8.Text = "Prijemna teretnica";
            // 
            // txtPrijemnaTeretnica
            // 
            this.txtPrijemnaTeretnica.Location = new System.Drawing.Point(120, 207);
            this.txtPrijemnaTeretnica.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrijemnaTeretnica.Name = "txtPrijemnaTeretnica";
            this.txtPrijemnaTeretnica.Size = new System.Drawing.Size(428, 22);
            this.txtPrijemnaTeretnica.TabIndex = 62;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.button14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button14.Location = new System.Drawing.Point(557, 206);
            this.button14.Margin = new System.Windows.Forms.Padding(4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(79, 25);
            this.button14.TabIndex = 63;
            this.button14.Text = "Pronađi";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(463, 46);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(87, 17);
            this.label30.TabIndex = 152;
            this.label30.Text = "Tip prevoza:";
            // 
            // txtTipPrevoza
            // 
            this.txtTipPrevoza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTipPrevoza.Location = new System.Drawing.Point(559, 46);
            this.txtTipPrevoza.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipPrevoza.Name = "txtTipPrevoza";
            this.txtTipPrevoza.Size = new System.Drawing.Size(287, 22);
            this.txtTipPrevoza.TabIndex = 153;
            // 
            // txtObjedinjen
            // 
            this.txtObjedinjen.Location = new System.Drawing.Point(313, 274);
            this.txtObjedinjen.Margin = new System.Windows.Forms.Padding(4);
            this.txtObjedinjen.Name = "txtObjedinjen";
            this.txtObjedinjen.Size = new System.Drawing.Size(453, 22);
            this.txtObjedinjen.TabIndex = 154;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(776, 273);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 25);
            this.button5.TabIndex = 155;
            this.button5.Text = "Otvori";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // frmDokumentaNajava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1113, 521);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtObjedinjen);
            this.Controls.Add(this.txtTipPrevoza);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrijemnaTeretnica);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.btnRacunSacuvaj);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRacun);
            this.Controls.Add(this.btnRacun);
            this.Controls.Add(this.btnCIT23Sacuvaj);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCIT23);
            this.Controls.Add(this.btnCIT23);
            this.Controls.Add(this.btnSacuvajTovarniList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTovarniList);
            this.Controls.Add(this.btnTovarniList);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPutanja2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPutanja);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSifraNajave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDokumentaNajava";
            this.Text = "Dokumenta najava";
            this.Load += new System.EventHandler(this.frmDokumentaNajava_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSifraNajave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPutanja;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPutanja2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnSacuvajTovarniList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTovarniList;
        private System.Windows.Forms.Button btnTovarniList;
        private System.Windows.Forms.Button btnCIT23Sacuvaj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCIT23;
        private System.Windows.Forms.Button btnCIT23;
        private System.Windows.Forms.Button btnRacunSacuvaj;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRacun;
        private System.Windows.Forms.Button btnRacun;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrijemnaTeretnica;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtTipPrevoza;
        private System.Windows.Forms.TextBox txtObjedinjen;
        private System.Windows.Forms.Button button5;
    }
}