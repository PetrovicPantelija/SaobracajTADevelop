namespace Saobracaj.Dokumenta
{
    partial class frmKasnjenja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasnjenja));
            this.button1 = new System.Windows.Forms.Button();
            this.dtpVremeKasnjenjaDo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpVremeKasnjenjaOd = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVremeKasnjenja = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboUzroci = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTrase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSifraRN = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(19, 103);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 28);
            this.button1.TabIndex = 89;
            this.button1.Text = "Unesi ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpVremeKasnjenjaDo
            // 
            this.dtpVremeKasnjenjaDo.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeKasnjenjaDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeKasnjenjaDo.Location = new System.Drawing.Point(485, 65);
            this.dtpVremeKasnjenjaDo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeKasnjenjaDo.Name = "dtpVremeKasnjenjaDo";
            this.dtpVremeKasnjenjaDo.ShowUpDown = true;
            this.dtpVremeKasnjenjaDo.Size = new System.Drawing.Size(149, 22);
            this.dtpVremeKasnjenjaDo.TabIndex = 88;
            this.dtpVremeKasnjenjaDo.Leave += new System.EventHandler(this.dtpVremeKasnjenjaDo_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(340, 65);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 17);
            this.label8.TabIndex = 94;
            this.label8.Text = "Vreme kašnjenja do:";
            // 
            // dtpVremeKasnjenjaOd
            // 
            this.dtpVremeKasnjenjaOd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeKasnjenjaOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeKasnjenjaOd.Location = new System.Drawing.Point(165, 65);
            this.dtpVremeKasnjenjaOd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeKasnjenjaOd.Name = "dtpVremeKasnjenjaOd";
            this.dtpVremeKasnjenjaOd.ShowUpDown = true;
            this.dtpVremeKasnjenjaOd.Size = new System.Drawing.Size(148, 22);
            this.dtpVremeKasnjenjaOd.TabIndex = 87;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 65);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 17);
            this.label9.TabIndex = 93;
            this.label9.Text = "Vreme kašnjenja od:";
            // 
            // txtVremeKasnjenja
            // 
            this.txtVremeKasnjenja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtVremeKasnjenja.Location = new System.Drawing.Point(781, 65);
            this.txtVremeKasnjenja.Margin = new System.Windows.Forms.Padding(4);
            this.txtVremeKasnjenja.Name = "txtVremeKasnjenja";
            this.txtVremeKasnjenja.Size = new System.Drawing.Size(81, 22);
            this.txtVremeKasnjenja.TabIndex = 92;
            this.txtVremeKasnjenja.Text = "0";
            this.txtVremeKasnjenja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(656, 65);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 17);
            this.label7.TabIndex = 91;
            this.label7.Text = "Vreme kašnjenja:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 90;
            this.label6.Text = "Uzroci:";
            // 
            // cboUzroci
            // 
            this.cboUzroci.FormattingEnabled = true;
            this.cboUzroci.Location = new System.Drawing.Point(549, 31);
            this.cboUzroci.Margin = new System.Windows.Forms.Padding(4);
            this.cboUzroci.Name = "cboUzroci";
            this.cboUzroci.Size = new System.Drawing.Size(455, 24);
            this.cboUzroci.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 98;
            this.label3.Text = "Trasa:";
            // 
            // cboTrase
            // 
            this.cboTrase.BackColor = System.Drawing.Color.Yellow;
            this.cboTrase.FormattingEnabled = true;
            this.cboTrase.Location = new System.Drawing.Point(259, 27);
            this.cboTrase.Margin = new System.Windows.Forms.Padding(4);
            this.cboTrase.Name = "cboTrase";
            this.cboTrase.Size = new System.Drawing.Size(220, 24);
            this.cboTrase.TabIndex = 96;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 97;
            this.label1.Text = "Šifra RN:";
            // 
            // txtSifraRN
            // 
            this.txtSifraRN.BackColor = System.Drawing.Color.Yellow;
            this.txtSifraRN.Location = new System.Drawing.Point(95, 27);
            this.txtSifraRN.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifraRN.Name = "txtSifraRN";
            this.txtSifraRN.Size = new System.Drawing.Size(80, 22);
            this.txtSifraRN.TabIndex = 95;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(224, 103);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 28);
            this.button2.TabIndex = 99;
            this.button2.Text = "Promeni";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(428, 103);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 28);
            this.button3.TabIndex = 100;
            this.button3.Text = "Izbriši";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1009, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 139;
            this.label4.Text = "Napomena:";
            // 
            // txtNapomena
            // 
            this.txtNapomena.Location = new System.Drawing.Point(1013, 31);
            this.txtNapomena.Margin = new System.Windows.Forms.Padding(4);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(392, 115);
            this.txtNapomena.TabIndex = 138;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(5, 154);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1401, 501);
            this.tabControl1.TabIndex = 140;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1393, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kašnjenja";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 7);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1375, 454);
            this.dataGridView1.TabIndex = 8;
            // 
            // frmKasnjenja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1423, 670);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTrase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSifraRN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpVremeKasnjenjaDo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpVremeKasnjenjaOd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVremeKasnjenja);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboUzroci);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKasnjenja";
            this.Text = "Kašnjenja na trasi";
            this.Load += new System.EventHandler(this.frmKasnjenja_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpVremeKasnjenjaDo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpVremeKasnjenjaOd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVremeKasnjenja;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboUzroci;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTrase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSifraRN;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}