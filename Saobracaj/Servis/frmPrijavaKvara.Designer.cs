namespace Saobracaj.Servis
{
    partial class frmPrijavaKvara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrijavaKvara));
            this.dtpDatumPrijave = new MetroFramework.Controls.MetroDateTime();
            this.dtpDatumPromene = new MetroFramework.Controls.MetroDateTime();
            this.txtNapomena = new MetroFramework.Controls.MetroTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.cboLokomotiva = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPrijavio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStatusKvara = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboPromenio = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboKvar = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDatumPrijave
            // 
            this.dtpDatumPrijave.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumPrijave.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumPrijave.Location = new System.Drawing.Point(16, 238);
            this.dtpDatumPrijave.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumPrijave.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtpDatumPrijave.Name = "dtpDatumPrijave";
            this.dtpDatumPrijave.Size = new System.Drawing.Size(279, 30);
            this.dtpDatumPrijave.TabIndex = 10;
            // 
            // dtpDatumPromene
            // 
            this.dtpDatumPromene.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumPromene.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumPromene.Location = new System.Drawing.Point(851, 63);
            this.dtpDatumPromene.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumPromene.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtpDatumPromene.Name = "dtpDatumPromene";
            this.dtpDatumPromene.Size = new System.Drawing.Size(279, 30);
            this.dtpDatumPromene.TabIndex = 19;
            // 
            // txtNapomena
            // 
            this.txtNapomena.Lines = new string[0];
            this.txtNapomena.Location = new System.Drawing.Point(433, 124);
            this.txtNapomena.Margin = new System.Windows.Forms.Padding(4);
            this.txtNapomena.MaxLength = 32767;
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.PasswordChar = '\0';
            this.txtNapomena.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNapomena.SelectedText = "";
            this.txtNapomena.Size = new System.Drawing.Size(699, 270);
            this.txtNapomena.TabIndex = 21;
            this.txtNapomena.UseSelectable = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsSave,
            this.tsDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1146, 27);
            this.toolStrip1.TabIndex = 144;
            this.toolStrip1.Text = "Osveži";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
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
            this.tsSave.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
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
            this.tsDelete.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(29, 24);
            this.tsDelete.Text = "toolStripButton1";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // cboLokomotiva
            // 
            this.cboLokomotiva.FormattingEnabled = true;
            this.cboLokomotiva.Location = new System.Drawing.Point(16, 122);
            this.cboLokomotiva.Margin = new System.Windows.Forms.Padding(4);
            this.cboLokomotiva.Name = "cboLokomotiva";
            this.cboLokomotiva.Size = new System.Drawing.Size(279, 24);
            this.cboLokomotiva.TabIndex = 154;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 153;
            this.label2.Text = "Lokomotiva:";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(16, 63);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(125, 22);
            this.txtSifra.TabIndex = 156;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 155;
            this.label1.Text = "Šifra";
            // 
            // cboPrijavio
            // 
            this.cboPrijavio.FormattingEnabled = true;
            this.cboPrijavio.Location = new System.Drawing.Point(16, 182);
            this.cboPrijavio.Margin = new System.Windows.Forms.Padding(4);
            this.cboPrijavio.Name = "cboPrijavio";
            this.cboPrijavio.Size = new System.Drawing.Size(279, 24);
            this.cboPrijavio.TabIndex = 158;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 157;
            this.label3.Text = "Prijavio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 277);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 160;
            this.label4.Text = "Kvar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 218);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 161;
            this.label5.Text = "Vreme prijave:";
            // 
            // cboStatusKvara
            // 
            this.cboStatusKvara.FormattingEnabled = true;
            this.cboStatusKvara.Location = new System.Drawing.Point(16, 363);
            this.cboStatusKvara.Margin = new System.Windows.Forms.Padding(4);
            this.cboStatusKvara.Name = "cboStatusKvara";
            this.cboStatusKvara.Size = new System.Drawing.Size(279, 24);
            this.cboStatusKvara.TabIndex = 162;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 338);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 163;
            this.label6.Text = "Status kvara";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(433, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 165;
            this.label7.Text = "Promenio:";
            // 
            // cboPromenio
            // 
            this.cboPromenio.FormattingEnabled = true;
            this.cboPromenio.Location = new System.Drawing.Point(433, 63);
            this.cboPromenio.Margin = new System.Windows.Forms.Padding(4);
            this.cboPromenio.Name = "cboPromenio";
            this.cboPromenio.Size = new System.Drawing.Size(279, 24);
            this.cboPromenio.TabIndex = 164;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(845, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 20);
            this.label8.TabIndex = 166;
            this.label8.Text = "Datum promene:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(433, 97);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 167;
            this.label9.Text = "Napomena";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 410);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1116, 446);
            this.dataGridView1.TabIndex = 169;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // cboKvar
            // 
            this.cboKvar.BackColor = System.Drawing.Color.SlateGray;
            this.cboKvar.ForeColor = System.Drawing.Color.White;
            this.cboKvar.FormattingEnabled = true;
            this.cboKvar.Location = new System.Drawing.Point(16, 302);
            this.cboKvar.Margin = new System.Windows.Forms.Padding(4);
            this.cboKvar.Name = "cboKvar";
            this.cboKvar.Size = new System.Drawing.Size(279, 24);
            this.cboKvar.TabIndex = 184;
            // 
            // frmPrijavaKvara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1146, 869);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cboPromenio);
            this.Controls.Add(this.cboStatusKvara);
            this.Controls.Add(this.cboPrijavio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.cboLokomotiva);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.dtpDatumPromene);
            this.Controls.Add(this.dtpDatumPrijave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboKvar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrijavaKvara";
            this.Text = "Prijava kvara";
            this.Load += new System.EventHandler(this.frmPrijavaKvara_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroDateTime dtpDatumPrijave;
        private MetroFramework.Controls.MetroDateTime dtpDatumPromene;
        private MetroFramework.Controls.MetroTextBox txtNapomena;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ComboBox cboLokomotiva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPrijavio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStatusKvara;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboPromenio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboKvar;
    }
}