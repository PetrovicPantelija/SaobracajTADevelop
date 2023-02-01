namespace Saobracaj.Dokumenta
{
    partial class frmEvidencijaRAdaNeplaceno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvidencijaRAdaNeplaceno));
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboZaposleni = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.chkPlaceno = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.dtpVremePlaceno = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPregledac = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(528, 49);
            this.btnPretrazi.Margin = new System.Windows.Forms.Padding(4);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(148, 28);
            this.btnPretrazi.TabIndex = 101;
            this.btnPretrazi.Text = "Pretraži sve neplaćeno";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 100;
            this.label6.Text = "Zaposleni:";
            // 
            // cboZaposleni
            // 
            this.cboZaposleni.BackColor = System.Drawing.Color.White;
            this.cboZaposleni.FormattingEnabled = true;
            this.cboZaposleni.Location = new System.Drawing.Point(125, 15);
            this.cboZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.cboZaposleni.Name = "cboZaposleni";
            this.cboZaposleni.Size = new System.Drawing.Size(227, 24);
            this.cboZaposleni.TabIndex = 99;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 28);
            this.button1.TabIndex = 102;
            this.button1.Text = "Pretraži radnik";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 190);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1321, 539);
            this.dataGridView1.TabIndex = 103;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(988, 80);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(257, 28);
            this.button4.TabIndex = 164;
            this.button4.Text = "Plati selektovane stavke troškovi";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(988, 44);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(257, 28);
            this.button8.TabIndex = 199;
            this.button8.Text = "Pregled kartica izvršen";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(988, 9);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(257, 28);
            this.button6.TabIndex = 198;
            this.button6.Text = "Pregled računa izvršen";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // chkPlaceno
            // 
            this.chkPlaceno.AutoSize = true;
            this.chkPlaceno.Enabled = false;
            this.chkPlaceno.Location = new System.Drawing.Point(233, 86);
            this.chkPlaceno.Margin = new System.Windows.Forms.Padding(4);
            this.chkPlaceno.Name = "chkPlaceno";
            this.chkPlaceno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPlaceno.Size = new System.Drawing.Size(146, 21);
            this.chkPlaceno.TabIndex = 200;
            this.chkPlaceno.Text = "Pregledano računi";
            this.chkPlaceno.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(411, 86);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(146, 21);
            this.checkBox1.TabIndex = 201;
            this.checkBox1.Text = "Pregledano trošak";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(588, 86);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox2.Size = new System.Drawing.Size(149, 21);
            this.checkBox2.TabIndex = 202;
            this.checkBox2.Text = "Pregledano kartice";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(532, 12);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 28);
            this.button3.TabIndex = 203;
            this.button3.Text = "Otvori zapis";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 205;
            this.label2.Text = "Vreme Do";
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpVremeDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeDo.Location = new System.Drawing.Point(207, 48);
            this.dtpVremeDo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.ShowUpDown = true;
            this.dtpVremeDo.Size = new System.Drawing.Size(145, 22);
            this.dtpVremeDo.TabIndex = 204;
            this.dtpVremeDo.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(1055, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 207;
            this.label5.Text = "Šifra";
            // 
            // txtSifra
            // 
            this.txtSifra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(0)))));
            this.txtSifra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtSifra.Location = new System.Drawing.Point(1121, 114);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(135, 30);
            this.txtSifra.TabIndex = 206;
            this.txtSifra.UseSystemPasswordChar = true;
            // 
            // dtpVremePlaceno
            // 
            this.dtpVremePlaceno.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremePlaceno.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremePlaceno.Location = new System.Drawing.Point(836, 82);
            this.dtpVremePlaceno.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremePlaceno.Name = "dtpVremePlaceno";
            this.dtpVremePlaceno.ShowUpDown = true;
            this.dtpVremePlaceno.Size = new System.Drawing.Size(143, 22);
            this.dtpVremePlaceno.TabIndex = 208;
            this.dtpVremePlaceno.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpVremePlaceno.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(755, 82);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 17);
            this.label21.TabIndex = 209;
            this.label21.Text = "Datum uplate:";
            this.label21.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(728, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 211;
            this.label1.Text = "Pregled izvršio:";
            // 
            // cboPregledac
            // 
            this.cboPregledac.BackColor = System.Drawing.Color.White;
            this.cboPregledac.FormattingEnabled = true;
            this.cboPregledac.Location = new System.Drawing.Point(732, 47);
            this.cboPregledac.Margin = new System.Windows.Forms.Padding(4);
            this.cboPregledac.Name = "cboPregledac";
            this.cboPregledac.Size = new System.Drawing.Size(227, 24);
            this.cboPregledac.TabIndex = 210;
            // 
            // frmEvidencijaRAdaNeplaceno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1353, 743);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPregledac);
            this.Controls.Add(this.dtpVremePlaceno);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpVremeDo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkPlaceno);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboZaposleni);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEvidencijaRAdaNeplaceno";
            this.Text = "Neplaćeno ";
            this.Load += new System.EventHandler(this.frmEvidencijaRAdaNeplaceno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboZaposleni;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox chkPlaceno;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.DateTimePicker dtpVremePlaceno;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPregledac;
    }
}