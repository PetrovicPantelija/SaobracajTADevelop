
namespace Saobracaj.Administracija
{
    partial class frmNotifikacije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotifikacije));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Obavestenje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbList_Korisnici = new System.Windows.Forms.CheckedListBox();
            this.cb_Procitan = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dt_Slanje = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_Citanje = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.combo_RadnoMesto = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.toolStrip1.Size = new System.Drawing.Size(1641, 27);
            this.toolStrip1.TabIndex = 146;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 147;
            this.label1.Text = "Obaveštenje";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_Obavestenje
            // 
            this.txt_Obavestenje.Location = new System.Drawing.Point(117, 70);
            this.txt_Obavestenje.Multiline = true;
            this.txt_Obavestenje.Name = "txt_Obavestenje";
            this.txt_Obavestenje.Size = new System.Drawing.Size(482, 138);
            this.txt_Obavestenje.TabIndex = 148;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 147;
            this.label2.Text = "Za korisnika";
            // 
            // cbList_Korisnici
            // 
            this.cbList_Korisnici.FormattingEnabled = true;
            this.cbList_Korisnici.Location = new System.Drawing.Point(117, 303);
            this.cbList_Korisnici.Name = "cbList_Korisnici";
            this.cbList_Korisnici.Size = new System.Drawing.Size(253, 395);
            this.cbList_Korisnici.TabIndex = 150;
            // 
            // cb_Procitan
            // 
            this.cb_Procitan.AutoSize = true;
            this.cb_Procitan.Location = new System.Drawing.Point(402, 443);
            this.cb_Procitan.Name = "cb_Procitan";
            this.cb_Procitan.Size = new System.Drawing.Size(82, 21);
            this.cb_Procitan.TabIndex = 151;
            this.cb_Procitan.Text = "Procitan";
            this.cb_Procitan.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(629, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 654);
            this.dataGridView1.TabIndex = 152;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // dt_Slanje
            // 
            this.dt_Slanje.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dt_Slanje.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Slanje.Location = new System.Drawing.Point(402, 330);
            this.dt_Slanje.Name = "dt_Slanje";
            this.dt_Slanje.Size = new System.Drawing.Size(197, 22);
            this.dt_Slanje.TabIndex = 153;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 147;
            this.label3.Text = "Datum slanja";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 147;
            this.label4.Text = "Datum citanja";
            // 
            // dt_Citanje
            // 
            this.dt_Citanje.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dt_Citanje.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Citanje.Location = new System.Drawing.Point(402, 400);
            this.dt_Citanje.Name = "dt_Citanje";
            this.dt_Citanje.Size = new System.Drawing.Size(197, 22);
            this.dt_Citanje.TabIndex = 153;
            this.dt_Citanje.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 147;
            this.label5.Text = "ID";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(11, 74);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(86, 22);
            this.txt_ID.TabIndex = 148;
            // 
            // combo_RadnoMesto
            // 
            this.combo_RadnoMesto.FormattingEnabled = true;
            this.combo_RadnoMesto.Location = new System.Drawing.Point(11, 251);
            this.combo_RadnoMesto.Name = "combo_RadnoMesto";
            this.combo_RadnoMesto.Size = new System.Drawing.Size(359, 24);
            this.combo_RadnoMesto.TabIndex = 154;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(376, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 39);
            this.button1.TabIndex = 155;
            this.button1.Text = "Nađi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmNotifikacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1641, 716);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combo_RadnoMesto);
            this.Controls.Add(this.dt_Citanje);
            this.Controls.Add(this.dt_Slanje);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cb_Procitan);
            this.Controls.Add(this.cbList_Korisnici);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.txt_Obavestenje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNotifikacije";
            this.Text = "Notifikacije";
            this.Load += new System.EventHandler(this.frmNotifikacije_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Obavestenje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cbList_Korisnici;
        private System.Windows.Forms.CheckBox cb_Procitan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dt_Slanje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dt_Citanje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.ComboBox combo_RadnoMesto;
        private System.Windows.Forms.Button button1;
    }
}