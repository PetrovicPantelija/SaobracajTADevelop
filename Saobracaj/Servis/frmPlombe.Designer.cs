
namespace Saobracaj.Servis
{
    partial class frmPlombe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlombe));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_Korisnik = new System.Windows.Forms.ComboBox();
            this.combo_Najava = new System.Windows.Forms.ComboBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_BrPlombi = new System.Windows.Forms.TextBox();
            this.txt_Slika = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_UcitajSliku = new System.Windows.Forms.Button();
            this.btn_SacuvajSliku = new System.Windows.Forms.Button();
            this.btn_Otvori = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
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
            this.toolStrip1.Size = new System.Drawing.Size(1261, 27);
            this.toolStrip1.TabIndex = 37;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Datum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Korisnik";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Najava";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(735, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Broj potrošenih plombi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(952, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Slika";
            // 
            // combo_Korisnik
            // 
            this.combo_Korisnik.FormattingEnabled = true;
            this.combo_Korisnik.Location = new System.Drawing.Point(315, 83);
            this.combo_Korisnik.Name = "combo_Korisnik";
            this.combo_Korisnik.Size = new System.Drawing.Size(176, 24);
            this.combo_Korisnik.TabIndex = 38;
            // 
            // combo_Najava
            // 
            this.combo_Najava.FormattingEnabled = true;
            this.combo_Najava.Location = new System.Drawing.Point(541, 83);
            this.combo_Najava.Name = "combo_Najava";
            this.combo_Najava.Size = new System.Drawing.Size(124, 24);
            this.combo_Najava.TabIndex = 38;
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(12, 85);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(88, 22);
            this.txt_ID.TabIndex = 39;
            // 
            // txt_BrPlombi
            // 
            this.txt_BrPlombi.Location = new System.Drawing.Point(738, 85);
            this.txt_BrPlombi.Name = "txt_BrPlombi";
            this.txt_BrPlombi.Size = new System.Drawing.Size(88, 22);
            this.txt_BrPlombi.TabIndex = 39;
            // 
            // txt_Slika
            // 
            this.txt_Slika.Location = new System.Drawing.Point(955, 85);
            this.txt_Slika.Name = "txt_Slika";
            this.txt_Slika.Size = new System.Drawing.Size(277, 22);
            this.txt_Slika.TabIndex = 39;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(144, 85);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 22);
            this.dateTimePicker1.TabIndex = 40;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1231, 571);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btn_UcitajSliku
            // 
            this.btn_UcitajSliku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_UcitajSliku.ForeColor = System.Drawing.Color.White;
            this.btn_UcitajSliku.Location = new System.Drawing.Point(1023, 49);
            this.btn_UcitajSliku.Name = "btn_UcitajSliku";
            this.btn_UcitajSliku.Size = new System.Drawing.Size(91, 27);
            this.btn_UcitajSliku.TabIndex = 42;
            this.btn_UcitajSliku.Text = "Učitaj";
            this.btn_UcitajSliku.UseVisualStyleBackColor = false;
            this.btn_UcitajSliku.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_SacuvajSliku
            // 
            this.btn_SacuvajSliku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_SacuvajSliku.ForeColor = System.Drawing.Color.White;
            this.btn_SacuvajSliku.Location = new System.Drawing.Point(1141, 49);
            this.btn_SacuvajSliku.Name = "btn_SacuvajSliku";
            this.btn_SacuvajSliku.Size = new System.Drawing.Size(91, 27);
            this.btn_SacuvajSliku.TabIndex = 42;
            this.btn_SacuvajSliku.Text = "Sačuvaj";
            this.btn_SacuvajSliku.UseVisualStyleBackColor = false;
            this.btn_SacuvajSliku.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Otvori
            // 
            this.btn_Otvori.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_Otvori.ForeColor = System.Drawing.Color.White;
            this.btn_Otvori.Location = new System.Drawing.Point(1141, 113);
            this.btn_Otvori.Name = "btn_Otvori";
            this.btn_Otvori.Size = new System.Drawing.Size(91, 27);
            this.btn_Otvori.TabIndex = 42;
            this.btn_Otvori.Text = "Otvori";
            this.btn_Otvori.UseVisualStyleBackColor = false;
            this.btn_Otvori.Click += new System.EventHandler(this.btn_Otvori_Click);
            // 
            // frmPlombe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1261, 727);
            this.Controls.Add(this.btn_SacuvajSliku);
            this.Controls.Add(this.btn_Otvori);
            this.Controls.Add(this.btn_UcitajSliku);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txt_Slika);
            this.Controls.Add(this.txt_BrPlombi);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.combo_Najava);
            this.Controls.Add(this.combo_Korisnik);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPlombe";
            this.Text = "Plombe";
            this.Load += new System.EventHandler(this.frmPlombe_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_Korisnik;
        private System.Windows.Forms.ComboBox combo_Najava;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.TextBox txt_BrPlombi;
        private System.Windows.Forms.TextBox txt_Slika;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_UcitajSliku;
        private System.Windows.Forms.Button btn_SacuvajSliku;
        private System.Windows.Forms.Button btn_Otvori;
    }
}