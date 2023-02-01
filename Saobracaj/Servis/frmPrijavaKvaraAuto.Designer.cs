
namespace Saobracaj.Servis
{
    partial class frmPrijavaKvaraAuto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrijavaKvaraAuto));
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_New = new System.Windows.Forms.ToolStripButton();
            this.tsb_Save = new System.Windows.Forms.ToolStripButton();
            this.tsb_Delete = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Sifra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_Automobil = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_Prijavio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_Prijava = new MetroFramework.Controls.MetroDateTime();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_Kvar = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_Status = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_Promenio = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dt_Promena = new MetroFramework.Controls.MetroDateTime();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Napomena = new MetroFramework.Controls.MetroTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_OtvoriSliku = new System.Windows.Forms.Button();
            this.btn_Napred = new System.Windows.Forms.Button();
            this.btn_nazad = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_Vise = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combo_Kvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_New,
            this.tsb_Save,
            this.tsb_Delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1439, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsb_New
            // 
            this.tsb_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_New.Image = ((System.Drawing.Image)(resources.GetObject("tsb_New.Image")));
            this.tsb_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_New.Name = "tsb_New";
            this.tsb_New.Size = new System.Drawing.Size(29, 24);
            this.tsb_New.Text = "New";
            this.tsb_New.Click += new System.EventHandler(this.tsb_New_Click);
            // 
            // tsb_Save
            // 
            this.tsb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Save.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Save.Image")));
            this.tsb_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Save.Name = "tsb_Save";
            this.tsb_Save.Size = new System.Drawing.Size(29, 24);
            this.tsb_Save.Text = "Save";
            this.tsb_Save.Click += new System.EventHandler(this.tsb_Save_Click);
            // 
            // tsb_Delete
            // 
            this.tsb_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Delete.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Delete.Image")));
            this.tsb_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Delete.Name = "tsb_Delete";
            this.tsb_Delete.Size = new System.Drawing.Size(29, 24);
            this.tsb_Delete.Text = "Delete";
            this.tsb_Delete.Click += new System.EventHandler(this.tsb_Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 156;
            this.label1.Text = "Šifra";
            // 
            // txt_Sifra
            // 
            this.txt_Sifra.Location = new System.Drawing.Point(168, 63);
            this.txt_Sifra.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Sifra.Name = "txt_Sifra";
            this.txt_Sifra.Size = new System.Drawing.Size(132, 22);
            this.txt_Sifra.TabIndex = 157;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 158;
            this.label2.Text = "Automobil:";
            // 
            // combo_Automobil
            // 
            this.combo_Automobil.FormattingEnabled = true;
            this.combo_Automobil.Location = new System.Drawing.Point(168, 103);
            this.combo_Automobil.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Automobil.Name = "combo_Automobil";
            this.combo_Automobil.Size = new System.Drawing.Size(339, 24);
            this.combo_Automobil.TabIndex = 159;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 160;
            this.label3.Text = "Prijavio:";
            // 
            // combo_Prijavio
            // 
            this.combo_Prijavio.FormattingEnabled = true;
            this.combo_Prijavio.Location = new System.Drawing.Point(168, 146);
            this.combo_Prijavio.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Prijavio.Name = "combo_Prijavio";
            this.combo_Prijavio.Size = new System.Drawing.Size(339, 24);
            this.combo_Prijavio.TabIndex = 161;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 202);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 162;
            this.label5.Text = "Vreme prijave:";
            // 
            // dt_Prijava
            // 
            this.dt_Prijava.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dt_Prijava.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Prijava.Location = new System.Drawing.Point(168, 190);
            this.dt_Prijava.Margin = new System.Windows.Forms.Padding(4);
            this.dt_Prijava.MinimumSize = new System.Drawing.Size(0, 30);
            this.dt_Prijava.Name = "dt_Prijava";
            this.dt_Prijava.Size = new System.Drawing.Size(265, 30);
            this.dt_Prijava.TabIndex = 163;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 246);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 164;
            this.label4.Text = "Kvar";
            // 
            // combo_Kvar
            // 
            this.combo_Kvar.AllowFiltering = false;
            this.combo_Kvar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.combo_Kvar.BeforeTouchSize = new System.Drawing.Size(339, 24);
            this.combo_Kvar.Filter = null;
            this.combo_Kvar.Location = new System.Drawing.Point(168, 239);
            this.combo_Kvar.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Kvar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.combo_Kvar.Name = "combo_Kvar";
            this.combo_Kvar.ScrollMetroColorTable = metroColorTable1;
            this.combo_Kvar.Size = new System.Drawing.Size(339, 24);
            this.combo_Kvar.TabIndex = 169;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 292);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 170;
            this.label6.Text = "Status kvara";
            // 
            // combo_Status
            // 
            this.combo_Status.FormattingEnabled = true;
            this.combo_Status.Location = new System.Drawing.Point(168, 286);
            this.combo_Status.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Status.Name = "combo_Status";
            this.combo_Status.Size = new System.Drawing.Size(339, 24);
            this.combo_Status.TabIndex = 171;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 335);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 172;
            this.label7.Text = "Promenio:";
            // 
            // combo_Promenio
            // 
            this.combo_Promenio.FormattingEnabled = true;
            this.combo_Promenio.Location = new System.Drawing.Point(168, 327);
            this.combo_Promenio.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Promenio.Name = "combo_Promenio";
            this.combo_Promenio.Size = new System.Drawing.Size(339, 24);
            this.combo_Promenio.TabIndex = 173;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 368);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 17);
            this.label8.TabIndex = 174;
            this.label8.Text = "Datum promene:";
            // 
            // dt_Promena
            // 
            this.dt_Promena.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dt_Promena.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Promena.Location = new System.Drawing.Point(168, 361);
            this.dt_Promena.Margin = new System.Windows.Forms.Padding(4);
            this.dt_Promena.MinimumSize = new System.Drawing.Size(0, 30);
            this.dt_Promena.Name = "dt_Promena";
            this.dt_Promena.Size = new System.Drawing.Size(265, 30);
            this.dt_Promena.TabIndex = 175;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(547, 82);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 176;
            this.label9.Text = "Napomena";
            // 
            // txt_Napomena
            // 
            this.txt_Napomena.Lines = new string[0];
            this.txt_Napomena.Location = new System.Drawing.Point(549, 103);
            this.txt_Napomena.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Napomena.MaxLength = 32767;
            this.txt_Napomena.Multiline = true;
            this.txt_Napomena.Name = "txt_Napomena";
            this.txt_Napomena.PasswordChar = '\0';
            this.txt_Napomena.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Napomena.SelectedText = "";
            this.txt_Napomena.Size = new System.Drawing.Size(403, 199);
            this.txt_Napomena.TabIndex = 177;
            this.txt_Napomena.UseSelectable = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 404);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1384, 345);
            this.dataGridView1.TabIndex = 178;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(968, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 288);
            this.pictureBox1.TabIndex = 218;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_OtvoriSliku
            // 
            this.btn_OtvoriSliku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_OtvoriSliku.ForeColor = System.Drawing.Color.White;
            this.btn_OtvoriSliku.Location = new System.Drawing.Point(968, 324);
            this.btn_OtvoriSliku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_OtvoriSliku.Name = "btn_OtvoriSliku";
            this.btn_OtvoriSliku.Size = new System.Drawing.Size(109, 34);
            this.btn_OtvoriSliku.TabIndex = 219;
            this.btn_OtvoriSliku.Text = "Otvori";
            this.btn_OtvoriSliku.UseVisualStyleBackColor = false;
            this.btn_OtvoriSliku.Click += new System.EventHandler(this.btn_OtvoriSliku_Click);
            // 
            // btn_Napred
            // 
            this.btn_Napred.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_Napred.ForeColor = System.Drawing.Color.White;
            this.btn_Napred.Location = new System.Drawing.Point(1211, 324);
            this.btn_Napred.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Napred.Name = "btn_Napred";
            this.btn_Napred.Size = new System.Drawing.Size(83, 34);
            this.btn_Napred.TabIndex = 220;
            this.btn_Napred.Text = ">>";
            this.btn_Napred.UseVisualStyleBackColor = false;
            this.btn_Napred.Click += new System.EventHandler(this.btn_Napred_Click);
            // 
            // btn_nazad
            // 
            this.btn_nazad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_nazad.ForeColor = System.Drawing.Color.White;
            this.btn_nazad.Location = new System.Drawing.Point(1115, 324);
            this.btn_nazad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_nazad.Name = "btn_nazad";
            this.btn_nazad.Size = new System.Drawing.Size(91, 34);
            this.btn_nazad.TabIndex = 221;
            this.btn_nazad.Text = "<<";
            this.btn_nazad.UseVisualStyleBackColor = false;
            this.btn_nazad.Click += new System.EventHandler(this.btn_nazad_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1317, 324);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 34);
            this.button1.TabIndex = 222;
            this.button1.Text = "Otvori folder";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Vise
            // 
            this.txt_Vise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.txt_Vise.ForeColor = System.Drawing.Color.White;
            this.txt_Vise.Location = new System.Drawing.Point(550, 322);
            this.txt_Vise.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Vise.Name = "txt_Vise";
            this.txt_Vise.Size = new System.Drawing.Size(145, 42);
            this.txt_Vise.TabIndex = 219;
            this.txt_Vise.Text = "Promeni više";
            this.txt_Vise.UseVisualStyleBackColor = false;
            this.txt_Vise.Click += new System.EventHandler(this.txt_Vise_Click);
            // 
            // frmPrijavaKvaraAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1439, 750);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_nazad);
            this.Controls.Add(this.btn_Napred);
            this.Controls.Add(this.txt_Vise);
            this.Controls.Add(this.btn_OtvoriSliku);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_Napomena);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dt_Promena);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.combo_Promenio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.combo_Status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.combo_Kvar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dt_Prijava);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.combo_Prijavio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_Automobil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Sifra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPrijavaKvaraAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prijava kvara automobili";
            this.Load += new System.EventHandler(this.frmPrijavaKvaraAuto_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combo_Kvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Sifra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_Automobil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_Prijavio;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroDateTime dt_Prijava;
        private System.Windows.Forms.Label label4;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox combo_Kvar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_Status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combo_Promenio;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroDateTime dt_Promena;
        private System.Windows.Forms.Label label9;
        private MetroFramework.Controls.MetroTextBox txt_Napomena;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton tsb_New;
        private System.Windows.Forms.ToolStripButton tsb_Save;
        private System.Windows.Forms.ToolStripButton tsb_Delete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_OtvoriSliku;
        private System.Windows.Forms.Button btn_Napred;
        private System.Windows.Forms.Button btn_nazad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button txt_Vise;
    }
}