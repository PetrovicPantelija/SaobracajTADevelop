namespace Testiranje.Promet
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
            this.chkVoz.Location = new System.Drawing.Point(451, 50);
            this.chkVoz.Name = "chkVoz";
            this.chkVoz.Size = new System.Drawing.Size(15, 14);
            this.chkVoz.TabIndex = 227;
            this.chkVoz.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1041, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 35);
            this.button1.TabIndex = 226;
            this.button1.Text = "Pretraži";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboPrijemKamionom
            // 
            this.cboPrijemKamionom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboPrijemKamionom.FormattingEnabled = true;
            this.cboPrijemKamionom.Location = new System.Drawing.Point(658, 46);
            this.cboPrijemKamionom.Name = "cboPrijemKamionom";
            this.cboPrijemKamionom.Size = new System.Drawing.Size(377, 24);
            this.cboPrijemKamionom.TabIndex = 225;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(655, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 224;
            this.label6.Text = "Prijem kamionom:";
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPretrazi.BackgroundImage")));
            this.btnPretrazi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPretrazi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPretrazi.ForeColor = System.Drawing.Color.White;
            this.btnPretrazi.Location = new System.Drawing.Point(488, 40);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(147, 35);
            this.btnPretrazi.TabIndex = 223;
            this.btnPretrazi.Text = "Pretraži";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // cboPrijemVozom
            // 
            this.cboPrijemVozom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboPrijemVozom.FormattingEnabled = true;
            this.cboPrijemVozom.Location = new System.Drawing.Point(12, 46);
            this.cboPrijemVozom.Name = "cboPrijemVozom";
            this.cboPrijemVozom.Size = new System.Drawing.Size(417, 24);
            this.cboPrijemVozom.TabIndex = 222;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 221;
            this.label5.Text = "Prijem vozom:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 92);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1176, 341);
            this.dataGridView2.TabIndex = 220;
            // 
            // frmPregledMedjuskladisniPrenos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1220, 445);
            this.Controls.Add(this.chkVoz);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboPrijemKamionom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.cboPrijemVozom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView2);
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