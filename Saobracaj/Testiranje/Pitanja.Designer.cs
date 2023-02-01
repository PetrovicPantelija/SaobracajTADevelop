
namespace Saobracaj.Testiranje
{
    partial class Pitanja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pitanja));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.txtPitanje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDStavke = new System.Windows.Forms.TextBox();
            this.sfButton5 = new Syncfusion.WinForms.Controls.SfButton();
            this.btnIzbaciTrasa = new Syncfusion.WinForms.Controls.SfButton();
            this.btnUnesiTrasa = new Syncfusion.WinForms.Controls.SfButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBrojTacnih = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDatumTesta = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cboClanKomisije1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboClanKomisije2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboClanKomisije3 = new System.Windows.Forms.ComboBox();
            this.txtBrojRegistratora = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMesto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIspravanOdgovor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.txtOdgovor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOdgovorBroj = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.sfButton1 = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton2 = new Syncfusion.WinForms.Controls.SfButton();
            this.txtIDOdgovor = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrojTacnih)).BeginInit();
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
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1496, 27);
            this.toolStrip1.TabIndex = 8;
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
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(119, 80);
            this.txtNaziv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(524, 22);
            this.txtNaziv.TabIndex = 21;
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(16, 80);
            this.lblNaziv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(82, 17);
            this.lblNaziv.TabIndex = 23;
            this.lblNaziv.Text = "Naziv testa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Šifra:";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(119, 48);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(77, 22);
            this.txtSifra.TabIndex = 20;
            // 
            // txtPitanje
            // 
            this.txtPitanje.Location = new System.Drawing.Point(24, 319);
            this.txtPitanje.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPitanje.Multiline = true;
            this.txtPitanje.Name = "txtPitanje";
            this.txtPitanje.Size = new System.Drawing.Size(524, 175);
            this.txtPitanje.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 299);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Pitanje:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Šifra pitanja:";
            // 
            // txtIDStavke
            // 
            this.txtIDStavke.Location = new System.Drawing.Point(24, 241);
            this.txtIDStavke.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIDStavke.Name = "txtIDStavke";
            this.txtIDStavke.Size = new System.Drawing.Size(77, 22);
            this.txtIDStavke.TabIndex = 24;
            // 
            // sfButton5
            // 
            this.sfButton5.AccessibleName = "Button";
            this.sfButton5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton5.Location = new System.Drawing.Point(271, 277);
            this.sfButton5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfButton5.Name = "sfButton5";
            this.sfButton5.Size = new System.Drawing.Size(128, 34);
            this.sfButton5.TabIndex = 181;
            this.sfButton5.Text = "Promeni";
            this.sfButton5.Click += new System.EventHandler(this.sfButton5_Click);
            // 
            // btnIzbaciTrasa
            // 
            this.btnIzbaciTrasa.AccessibleName = "Button";
            this.btnIzbaciTrasa.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnIzbaciTrasa.Location = new System.Drawing.Point(421, 277);
            this.btnIzbaciTrasa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIzbaciTrasa.Name = "btnIzbaciTrasa";
            this.btnIzbaciTrasa.Size = new System.Drawing.Size(128, 34);
            this.btnIzbaciTrasa.TabIndex = 180;
            this.btnIzbaciTrasa.Text = "Izbaci";
            this.btnIzbaciTrasa.Click += new System.EventHandler(this.btnIzbaciTrasa_Click);
            // 
            // btnUnesiTrasa
            // 
            this.btnUnesiTrasa.AccessibleName = "Button";
            this.btnUnesiTrasa.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnUnesiTrasa.Location = new System.Drawing.Point(119, 277);
            this.btnUnesiTrasa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUnesiTrasa.Name = "btnUnesiTrasa";
            this.btnUnesiTrasa.Size = new System.Drawing.Size(128, 34);
            this.btnUnesiTrasa.TabIndex = 179;
            this.btnUnesiTrasa.Text = "Unesi";
            this.btnUnesiTrasa.Click += new System.EventHandler(this.btnUnesiTrasa_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1027, 68);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(453, 197);
            this.dataGridView1.TabIndex = 182;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(21, 502);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(1459, 343);
            this.dataGridView2.TabIndex = 183;
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1023, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 184;
            this.label4.Text = "Grupe testova:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Green;
            this.label17.Location = new System.Drawing.Point(652, 84);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(176, 17);
            this.label17.TabIndex = 211;
            this.label17.Text = "Potrebno tačnih odgovora:";
            // 
            // txtBrojTacnih
            // 
            this.txtBrojTacnih.BackColor = System.Drawing.Color.White;
            this.txtBrojTacnih.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBrojTacnih.ForeColor = System.Drawing.Color.Black;
            this.txtBrojTacnih.Location = new System.Drawing.Point(837, 81);
            this.txtBrojTacnih.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBrojTacnih.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtBrojTacnih.Name = "txtBrojTacnih";
            this.txtBrojTacnih.Size = new System.Drawing.Size(131, 26);
            this.txtBrojTacnih.TabIndex = 210;
            this.txtBrojTacnih.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(652, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 209;
            this.label5.Text = "Datum testa:";
            // 
            // dtpDatumTesta
            // 
            this.dtpDatumTesta.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumTesta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumTesta.Location = new System.Drawing.Point(804, 49);
            this.dtpDatumTesta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDatumTesta.Name = "dtpDatumTesta";
            this.dtpDatumTesta.ShowUpDown = true;
            this.dtpDatumTesta.Size = new System.Drawing.Size(163, 22);
            this.dtpDatumTesta.TabIndex = 208;
            this.dtpDatumTesta.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(652, 116);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 212;
            this.label6.Text = "Član komisije 1:";
            // 
            // cboClanKomisije1
            // 
            this.cboClanKomisije1.FormattingEnabled = true;
            this.cboClanKomisije1.Location = new System.Drawing.Point(767, 116);
            this.cboClanKomisije1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboClanKomisije1.Name = "cboClanKomisije1";
            this.cboClanKomisije1.Size = new System.Drawing.Size(227, 24);
            this.cboClanKomisije1.TabIndex = 213;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(652, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 214;
            this.label7.Text = "Član komisije 2:";
            // 
            // cboClanKomisije2
            // 
            this.cboClanKomisije2.FormattingEnabled = true;
            this.cboClanKomisije2.Location = new System.Drawing.Point(767, 149);
            this.cboClanKomisije2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboClanKomisije2.Name = "cboClanKomisije2";
            this.cboClanKomisije2.Size = new System.Drawing.Size(227, 24);
            this.cboClanKomisije2.TabIndex = 215;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(652, 182);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 17);
            this.label8.TabIndex = 216;
            this.label8.Text = "Član komisije 3:";
            // 
            // cboClanKomisije3
            // 
            this.cboClanKomisije3.FormattingEnabled = true;
            this.cboClanKomisije3.Location = new System.Drawing.Point(767, 182);
            this.cboClanKomisije3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboClanKomisije3.Name = "cboClanKomisije3";
            this.cboClanKomisije3.Size = new System.Drawing.Size(227, 24);
            this.cboClanKomisije3.TabIndex = 217;
            // 
            // txtBrojRegistratora
            // 
            this.txtBrojRegistratora.Location = new System.Drawing.Point(119, 112);
            this.txtBrojRegistratora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBrojRegistratora.Name = "txtBrojRegistratora";
            this.txtBrojRegistratora.Size = new System.Drawing.Size(165, 22);
            this.txtBrojRegistratora.TabIndex = 218;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 112);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 219;
            this.label9.Text = "Rešenje broj:";
            // 
            // txtMesto
            // 
            this.txtMesto.Location = new System.Drawing.Point(119, 149);
            this.txtMesto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMesto.Name = "txtMesto";
            this.txtMesto.Size = new System.Drawing.Size(165, 22);
            this.txtMesto.TabIndex = 220;
            this.txtMesto.Text = "Beogradu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 152);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 221;
            this.label10.Text = "Mesto:";
            // 
            // txtIspravanOdgovor
            // 
            this.txtIspravanOdgovor.Location = new System.Drawing.Point(157, 240);
            this.txtIspravanOdgovor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIspravanOdgovor.Name = "txtIspravanOdgovor";
            this.txtIspravanOdgovor.Size = new System.Drawing.Size(49, 22);
            this.txtIspravanOdgovor.TabIndex = 222;
            this.txtIspravanOdgovor.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(153, 217);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 17);
            this.label11.TabIndex = 223;
            this.label11.Text = "Ispravan odgovor broj:";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(1027, 286);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(453, 209);
            this.dataGridView3.TabIndex = 224;
            this.dataGridView3.SelectionChanged += new System.EventHandler(this.dataGridView3_SelectionChanged);
            // 
            // txtOdgovor
            // 
            this.txtOdgovor.Location = new System.Drawing.Point(587, 382);
            this.txtOdgovor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOdgovor.Multiline = true;
            this.txtOdgovor.Name = "txtOdgovor";
            this.txtOdgovor.Size = new System.Drawing.Size(407, 112);
            this.txtOdgovor.TabIndex = 225;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(583, 322);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 17);
            this.label12.TabIndex = 227;
            this.label12.Text = "Odgovor broj:";
            // 
            // txtOdgovorBroj
            // 
            this.txtOdgovorBroj.Location = new System.Drawing.Point(685, 322);
            this.txtOdgovorBroj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOdgovorBroj.Name = "txtOdgovorBroj";
            this.txtOdgovorBroj.Size = new System.Drawing.Size(49, 22);
            this.txtOdgovorBroj.TabIndex = 226;
            this.txtOdgovorBroj.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(583, 362);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.TabIndex = 228;
            this.label13.Text = "Odgovor:";
            // 
            // sfButton1
            // 
            this.sfButton1.AccessibleName = "Button";
            this.sfButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton1.Location = new System.Drawing.Point(867, 286);
            this.sfButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfButton1.Name = "sfButton1";
            this.sfButton1.Size = new System.Drawing.Size(128, 34);
            this.sfButton1.TabIndex = 229;
            this.sfButton1.Text = "Unesi";
            this.sfButton1.Click += new System.EventHandler(this.sfButton1_Click);
            // 
            // sfButton2
            // 
            this.sfButton2.AccessibleName = "Button";
            this.sfButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton2.Location = new System.Drawing.Point(867, 340);
            this.sfButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sfButton2.Name = "sfButton2";
            this.sfButton2.Size = new System.Drawing.Size(128, 34);
            this.sfButton2.TabIndex = 230;
            this.sfButton2.Text = "Izbaci";
            this.sfButton2.Click += new System.EventHandler(this.sfButton2_Click);
            // 
            // txtIDOdgovor
            // 
            this.txtIDOdgovor.Location = new System.Drawing.Point(685, 287);
            this.txtIDOdgovor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIDOdgovor.Name = "txtIDOdgovor";
            this.txtIDOdgovor.Size = new System.Drawing.Size(49, 22);
            this.txtIDOdgovor.TabIndex = 231;
            this.txtIDOdgovor.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(583, 286);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 17);
            this.label14.TabIndex = 232;
            this.label14.Text = "ID odg:";
            // 
            // Pitanja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1496, 860);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtIDOdgovor);
            this.Controls.Add(this.sfButton2);
            this.Controls.Add(this.sfButton1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtOdgovorBroj);
            this.Controls.Add(this.txtOdgovor);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtIspravanOdgovor);
            this.Controls.Add(this.txtMesto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBrojRegistratora);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboClanKomisije3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboClanKomisije2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboClanKomisije1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtBrojTacnih);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDatumTesta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.sfButton5);
            this.Controls.Add(this.btnIzbaciTrasa);
            this.Controls.Add(this.btnUnesiTrasa);
            this.Controls.Add(this.txtPitanje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIDStavke);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Pitanja";
            this.Text = "Pitanja";
            this.Load += new System.EventHandler(this.Pitanja_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrojTacnih)).EndInit();
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
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.TextBox txtPitanje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIDStavke;
        private Syncfusion.WinForms.Controls.SfButton sfButton5;
        private Syncfusion.WinForms.Controls.SfButton btnIzbaciTrasa;
        private Syncfusion.WinForms.Controls.SfButton btnUnesiTrasa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown txtBrojTacnih;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDatumTesta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboClanKomisije1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboClanKomisije2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboClanKomisije3;
        private System.Windows.Forms.TextBox txtBrojRegistratora;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMesto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIspravanOdgovor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TextBox txtOdgovor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOdgovorBroj;
        private System.Windows.Forms.Label label13;
        private Syncfusion.WinForms.Controls.SfButton sfButton1;
        private Syncfusion.WinForms.Controls.SfButton sfButton2;
        private System.Windows.Forms.TextBox txtIDOdgovor;
        private System.Windows.Forms.Label label14;
    }
}