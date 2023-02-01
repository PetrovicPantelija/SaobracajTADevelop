namespace Saobracaj
{
    partial class frmPravljenjeVoza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPravljenjeVoza));
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStanicaIsklj = new System.Windows.Forms.ComboBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNeto = new System.Windows.Forms.TextBox();
            this.txtTara = new System.Windows.Forms.TextBox();
            this.txtBruto = new System.Windows.Forms.TextBox();
            this.txtDuzina = new System.Windows.Forms.TextBox();
            this.txtBrojKola = new System.Windows.Forms.TextBox();
            this.lblBrojKola = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboRadniNalog = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboStanicaOd = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboStanicaDo = new System.Windows.Forms.ComboBox();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(240, 15);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 42);
            this.button3.TabIndex = 50;
            this.button3.Text = "Pretraži";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 18);
            this.label2.TabIndex = 49;
            this.label2.Text = "Stanica vagoni / Stanica popisa:";
            // 
            // cboStanicaIsklj
            // 
            this.cboStanicaIsklj.FormattingEnabled = true;
            this.cboStanicaIsklj.Location = new System.Drawing.Point(20, 31);
            this.cboStanicaIsklj.Margin = new System.Windows.Forms.Padding(4);
            this.cboStanicaIsklj.Name = "cboStanicaIsklj";
            this.cboStanicaIsklj.Size = new System.Drawing.Size(187, 24);
            this.cboStanicaIsklj.TabIndex = 48;
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(20, 300);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(1404, 225);
            this.dataGridView3.TabIndex = 47;
            this.dataGridView3.SelectionChanged += new System.EventHandler(this.dataGridView3_SelectionChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(321, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(868, 263);
            this.dataGridView1.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(317, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 18);
            this.label1.TabIndex = 52;
            this.label1.Text = "Pregled po stanicama:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(16, 277);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 53;
            this.label3.Text = "Vagoni:";
            // 
            // txtNeto
            // 
            this.txtNeto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNeto.Location = new System.Drawing.Point(103, 138);
            this.txtNeto.Margin = new System.Windows.Forms.Padding(4);
            this.txtNeto.Name = "txtNeto";
            this.txtNeto.Size = new System.Drawing.Size(104, 22);
            this.txtNeto.TabIndex = 54;
            // 
            // txtTara
            // 
            this.txtTara.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTara.Location = new System.Drawing.Point(103, 170);
            this.txtTara.Margin = new System.Windows.Forms.Padding(4);
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(104, 22);
            this.txtTara.TabIndex = 55;
            // 
            // txtBruto
            // 
            this.txtBruto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBruto.Location = new System.Drawing.Point(103, 202);
            this.txtBruto.Margin = new System.Windows.Forms.Padding(4);
            this.txtBruto.Name = "txtBruto";
            this.txtBruto.Size = new System.Drawing.Size(104, 22);
            this.txtBruto.TabIndex = 56;
            // 
            // txtDuzina
            // 
            this.txtDuzina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDuzina.Location = new System.Drawing.Point(107, 106);
            this.txtDuzina.Margin = new System.Windows.Forms.Padding(4);
            this.txtDuzina.Name = "txtDuzina";
            this.txtDuzina.Size = new System.Drawing.Size(100, 22);
            this.txtDuzina.TabIndex = 57;
            // 
            // txtBrojKola
            // 
            this.txtBrojKola.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBrojKola.Location = new System.Drawing.Point(107, 74);
            this.txtBrojKola.Margin = new System.Windows.Forms.Padding(4);
            this.txtBrojKola.Name = "txtBrojKola";
            this.txtBrojKola.Size = new System.Drawing.Size(100, 22);
            this.txtBrojKola.TabIndex = 58;
            // 
            // lblBrojKola
            // 
            this.lblBrojKola.AutoSize = true;
            this.lblBrojKola.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblBrojKola.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBrojKola.Location = new System.Drawing.Point(28, 74);
            this.lblBrojKola.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrojKola.Name = "lblBrojKola";
            this.lblBrojKola.Size = new System.Drawing.Size(71, 18);
            this.lblBrojKola.TabIndex = 59;
            this.lblBrojKola.Text = "Broj kola:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(28, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 60;
            this.label4.Text = "Dužina:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(28, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 61;
            this.label5.Text = "Neto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(29, 174);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 18);
            this.label6.TabIndex = 62;
            this.label6.Text = "Tara:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(29, 206);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 63;
            this.label7.Text = "Bruto:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1201, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 42);
            this.button1.TabIndex = 64;
            this.button1.Text = "Veži vagone za RN / Napravi  Teretnicu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1197, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 66;
            this.label8.Text = "Radni nalog:";
            // 
            // cboRadniNalog
            // 
            this.cboRadniNalog.FormattingEnabled = true;
            this.cboRadniNalog.Location = new System.Drawing.Point(1201, 79);
            this.cboRadniNalog.Margin = new System.Windows.Forms.Padding(4);
            this.cboRadniNalog.Name = "cboRadniNalog";
            this.cboRadniNalog.Size = new System.Drawing.Size(211, 24);
            this.cboRadniNalog.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1197, 108);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 17);
            this.label9.TabIndex = 68;
            this.label9.Text = "Stanica od / Uvrštena:";
            // 
            // cboStanicaOd
            // 
            this.cboStanicaOd.FormattingEnabled = true;
            this.cboStanicaOd.Location = new System.Drawing.Point(1201, 128);
            this.cboStanicaOd.Margin = new System.Windows.Forms.Padding(4);
            this.cboStanicaOd.Name = "cboStanicaOd";
            this.cboStanicaOd.Size = new System.Drawing.Size(211, 24);
            this.cboStanicaOd.TabIndex = 67;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1197, 158);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 17);
            this.label10.TabIndex = 70;
            this.label10.Text = "Stanica do / Otkačena:";
            // 
            // cboStanicaDo
            // 
            this.cboStanicaDo.FormattingEnabled = true;
            this.cboStanicaDo.Location = new System.Drawing.Point(1201, 177);
            this.cboStanicaDo.Margin = new System.Windows.Forms.Padding(4);
            this.cboStanicaDo.Name = "cboStanicaDo";
            this.cboStanicaDo.Size = new System.Drawing.Size(211, 24);
            this.cboStanicaDo.TabIndex = 69;
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVremeOd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVremeOd.Location = new System.Drawing.Point(1201, 225);
            this.dtpVremeOd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.ShowUpDown = true;
            this.dtpVremeOd.Size = new System.Drawing.Size(143, 22);
            this.dtpVremeOd.TabIndex = 71;
            this.dtpVremeOd.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1197, 206);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 17);
            this.label21.TabIndex = 72;
            this.label21.Text = "Planirano od:";
            // 
            // frmPravljenjeVoza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1429, 532);
            this.Controls.Add(this.dtpVremeOd);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboStanicaDo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboStanicaOd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboRadniNalog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBrojKola);
            this.Controls.Add(this.txtBrojKola);
            this.Controls.Add(this.txtDuzina);
            this.Controls.Add(this.txtBruto);
            this.Controls.Add(this.txtTara);
            this.Controls.Add(this.txtNeto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStanicaIsklj);
            this.Controls.Add(this.dataGridView3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPravljenjeVoza";
            this.Text = "Pravljenje voza";
            this.Load += new System.EventHandler(this.frmPravljenjeVoza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStanicaIsklj;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNeto;
        private System.Windows.Forms.TextBox txtTara;
        private System.Windows.Forms.TextBox txtBruto;
        private System.Windows.Forms.TextBox txtDuzina;
        private System.Windows.Forms.TextBox txtBrojKola;
        private System.Windows.Forms.Label lblBrojKola;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboRadniNalog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboStanicaOd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboStanicaDo;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.Label label21;
    }
}