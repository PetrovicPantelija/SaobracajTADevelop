namespace TrackModal.Promet
{
    partial class frmPregledMedjuskladisniPrenos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledMedjuskladisniPrenos));
            this.chkVoz = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboPrijemKamionom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.cboPrijemVozom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // chkVoz
            // 
            this.chkVoz.AutoSize = true;
            this.chkVoz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkVoz.Location = new System.Drawing.Point(601, 62);
            this.chkVoz.Margin = new System.Windows.Forms.Padding(4);
            this.chkVoz.Name = "chkVoz";
            this.chkVoz.Size = new System.Drawing.Size(18, 17);
            this.chkVoz.TabIndex = 227;
            this.chkVoz.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1388, 49);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 43);
            this.button1.TabIndex = 226;
            this.button1.Text = "Pretraži";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboPrijemKamionom
            // 
            this.cboPrijemKamionom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboPrijemKamionom.FormattingEnabled = true;
            this.cboPrijemKamionom.Location = new System.Drawing.Point(877, 57);
            this.cboPrijemKamionom.Margin = new System.Windows.Forms.Padding(4);
            this.cboPrijemKamionom.Name = "cboPrijemKamionom";
            this.cboPrijemKamionom.Size = new System.Drawing.Size(501, 27);
            this.cboPrijemKamionom.TabIndex = 225;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(873, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 17);
            this.label6.TabIndex = 224;
            this.label6.Text = "Prijem kamionom:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btnPretrazi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPretrazi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPretrazi.ForeColor = System.Drawing.Color.White;
            this.btnPretrazi.Location = new System.Drawing.Point(651, 49);
            this.btnPretrazi.Margin = new System.Windows.Forms.Padding(4);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(196, 43);
            this.btnPretrazi.TabIndex = 223;
            this.btnPretrazi.Text = "Pretraži";
            this.btnPretrazi.UseVisualStyleBackColor = false;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // cboPrijemVozom
            // 
            this.cboPrijemVozom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboPrijemVozom.FormattingEnabled = true;
            this.cboPrijemVozom.Location = new System.Drawing.Point(16, 57);
            this.cboPrijemVozom.Margin = new System.Windows.Forms.Padding(4);
            this.cboPrijemVozom.Name = "cboPrijemVozom";
            this.cboPrijemVozom.Size = new System.Drawing.Size(555, 27);
            this.cboPrijemVozom.TabIndex = 222;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 221;
            this.label5.Text = "Prijem vozom:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(16, 113);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(1568, 420);
            this.dataGridView2.TabIndex = 220;
            // 
            // frmPregledMedjuskladisniPrenos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1627, 548);
            this.Controls.Add(this.chkVoz);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboPrijemKamionom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.cboPrijemVozom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPregledMedjuskladisniPrenos";
            this.Text = "Međuskladisni prenosi po prijemu";
            this.Load += new System.EventHandler(this.frmPregledSkladistePrijem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkVoz;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboPrijemKamionom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.ComboBox cboPrijemVozom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}