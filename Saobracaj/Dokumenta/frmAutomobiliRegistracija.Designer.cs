
namespace Saobracaj.Dokumenta
{
    partial class frmAutomobiliRegistracija
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutomobiliRegistracija));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Sifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_AutomobilID = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dt_Datum = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_Zaposleni = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_Partner = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Napomena = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.toolStrip1.Size = new System.Drawing.Size(1009, 27);
            this.toolStrip1.TabIndex = 0;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 65);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 214;
            this.label7.Text = "Šifra zapisa:";
            // 
            // txt_Sifra
            // 
            this.txt_Sifra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_Sifra.Location = new System.Drawing.Point(125, 65);
            this.txt_Sifra.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Sifra.Name = "txt_Sifra";
            this.txt_Sifra.Size = new System.Drawing.Size(119, 22);
            this.txt_Sifra.TabIndex = 215;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 220;
            this.label1.Text = "Automobil ID:";
            // 
            // txt_AutomobilID
            // 
            this.txt_AutomobilID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_AutomobilID.Location = new System.Drawing.Point(432, 65);
            this.txt_AutomobilID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AutomobilID.Name = "txt_AutomobilID";
            this.txt_AutomobilID.Size = new System.Drawing.Size(119, 22);
            this.txt_AutomobilID.TabIndex = 221;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(621, 68);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(126, 17);
            this.label21.TabIndex = 222;
            this.label21.Text = "Datum registracije:";
            // 
            // dt_Datum
            // 
            this.dt_Datum.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dt_Datum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_Datum.Location = new System.Drawing.Point(763, 65);
            this.dt_Datum.Margin = new System.Windows.Forms.Padding(4);
            this.dt_Datum.Name = "dt_Datum";
            this.dt_Datum.ShowUpDown = true;
            this.dt_Datum.Size = new System.Drawing.Size(143, 22);
            this.dt_Datum.TabIndex = 223;
            this.dt_Datum.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 224;
            this.label4.Text = "Registraciju izvršio:";
            // 
            // combo_Zaposleni
            // 
            this.combo_Zaposleni.FormattingEnabled = true;
            this.combo_Zaposleni.Location = new System.Drawing.Point(163, 116);
            this.combo_Zaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Zaposleni.Name = "combo_Zaposleni";
            this.combo_Zaposleni.Size = new System.Drawing.Size(276, 24);
            this.combo_Zaposleni.TabIndex = 225;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 226;
            this.label2.Text = "Servis izvršen kod:";
            // 
            // combo_Partner
            // 
            this.combo_Partner.FormattingEnabled = true;
            this.combo_Partner.Location = new System.Drawing.Point(624, 116);
            this.combo_Partner.Margin = new System.Windows.Forms.Padding(4);
            this.combo_Partner.Name = "combo_Partner";
            this.combo_Partner.Size = new System.Drawing.Size(281, 24);
            this.combo_Partner.TabIndex = 227;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 178);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 228;
            this.label8.Text = "Napomena:";
            // 
            // txt_Napomena
            // 
            this.txt_Napomena.Location = new System.Drawing.Point(125, 161);
            this.txt_Napomena.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Napomena.Multiline = true;
            this.txt_Napomena.Name = "txt_Napomena";
            this.txt_Napomena.Size = new System.Drawing.Size(780, 102);
            this.txt_Napomena.TabIndex = 229;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(27, 290);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersWidth = 21;
            this.dataGridView1.Size = new System.Drawing.Size(955, 322);
            this.dataGridView1.TabIndex = 230;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // frmAutomobiliRegistracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1009, 626);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_Napomena);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.combo_Partner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_Zaposleni);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dt_Datum);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txt_AutomobilID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Sifra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAutomobiliRegistracija";
            this.Text = "AutomobiliRegistracija";
            this.Load += new System.EventHandler(this.frmAutomobiliRegistracija_Load);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Sifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_AutomobilID;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dt_Datum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_Zaposleni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_Partner;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Napomena;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}