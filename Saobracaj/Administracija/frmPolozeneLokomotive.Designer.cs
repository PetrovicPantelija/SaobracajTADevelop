
namespace Saobracaj.Administracija
{
    partial class frmPolozeneLokomotive
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
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPolozeneLokomotive));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Sifra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_Zaposleni = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_Lokomotiva = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_zapolseni = new System.Windows.Forms.Button();
            this.btn_lokomotiva = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.combo_Lokomotiva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 149;
            this.label1.Text = "Šifra";
            // 
            // txt_Sifra
            // 
            this.txt_Sifra.BackColor = System.Drawing.Color.Gold;
            this.txt_Sifra.Enabled = false;
            this.txt_Sifra.Location = new System.Drawing.Point(15, 66);
            this.txt_Sifra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Sifra.Name = "txt_Sifra";
            this.txt_Sifra.Size = new System.Drawing.Size(79, 22);
            this.txt_Sifra.TabIndex = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 151;
            this.label2.Text = "Zaposleni";
            // 
            // combo_Zaposleni
            // 
            this.combo_Zaposleni.FormattingEnabled = true;
            this.combo_Zaposleni.Location = new System.Drawing.Point(155, 66);
            this.combo_Zaposleni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combo_Zaposleni.Name = "combo_Zaposleni";
            this.combo_Zaposleni.Size = new System.Drawing.Size(207, 24);
            this.combo_Zaposleni.TabIndex = 152;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 153;
            this.label3.Text = "Lokomotiva serija";
            // 
            // combo_Lokomotiva
            // 
            this.combo_Lokomotiva.AllowFiltering = false;
            this.combo_Lokomotiva.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.combo_Lokomotiva.BeforeTouchSize = new System.Drawing.Size(243, 24);
            this.combo_Lokomotiva.Filter = null;
            this.combo_Lokomotiva.Location = new System.Drawing.Point(403, 66);
            this.combo_Lokomotiva.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Lokomotiva.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.combo_Lokomotiva.Name = "combo_Lokomotiva";
            this.combo_Lokomotiva.ScrollMetroColorTable = metroColorTable1;
            this.combo_Lokomotiva.Size = new System.Drawing.Size(243, 24);
            this.combo_Lokomotiva.TabIndex = 172;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(677, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 173;
            this.label4.Text = "Datum Polaganja";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(681, 66);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 24);
            this.dateTimePicker1.TabIndex = 174;
            // 
            // btn_zapolseni
            // 
            this.btn_zapolseni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_zapolseni.ForeColor = System.Drawing.Color.White;
            this.btn_zapolseni.Location = new System.Drawing.Point(821, 46);
            this.btn_zapolseni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_zapolseni.Name = "btn_zapolseni";
            this.btn_zapolseni.Size = new System.Drawing.Size(155, 44);
            this.btn_zapolseni.TabIndex = 175;
            this.btn_zapolseni.Text = "Traži po zaposlenom";
            this.btn_zapolseni.UseVisualStyleBackColor = false;
            this.btn_zapolseni.Click += new System.EventHandler(this.btn_zapolseni_Click);
            // 
            // btn_lokomotiva
            // 
            this.btn_lokomotiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_lokomotiva.ForeColor = System.Drawing.Color.White;
            this.btn_lokomotiva.Location = new System.Drawing.Point(995, 46);
            this.btn_lokomotiva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_lokomotiva.Name = "btn_lokomotiva";
            this.btn_lokomotiva.Size = new System.Drawing.Size(173, 44);
            this.btn_lokomotiva.TabIndex = 176;
            this.btn_lokomotiva.Text = "Traži po lokomotivi";
            this.btn_lokomotiva.UseVisualStyleBackColor = false;
            this.btn_lokomotiva.Click += new System.EventHandler(this.btn_lokomotiva_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 119);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1153, 460);
            this.dataGridView1.TabIndex = 177;
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
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1180, 27);
            this.toolStrip1.TabIndex = 178;
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(115, 24);
            this.toolStripButton1.Text = "Položene Pruge";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // frmPolozeneLokomotive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1180, 591);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_lokomotiva);
            this.Controls.Add(this.btn_zapolseni);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.combo_Lokomotiva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_Zaposleni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Sifra);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPolozeneLokomotive";
            this.Text = "Položene lokomotive";
            this.Load += new System.EventHandler(this.frmPolozeneLokomotive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combo_Lokomotiva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Sifra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_Zaposleni;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox combo_Lokomotiva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_zapolseni;
        private System.Windows.Forms.Button btn_lokomotiva;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}