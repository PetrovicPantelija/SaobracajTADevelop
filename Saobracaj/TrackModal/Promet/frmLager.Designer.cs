namespace Testiranje.Promet
{
    partial class frmLager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLager));
            this.cboSkladiste = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPregled = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboVlasnikKontejnera = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboTipKontejnera = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboVrstaRobe = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSkladiste
            // 
            this.cboSkladiste.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboSkladiste.FormattingEnabled = true;
            this.cboSkladiste.Location = new System.Drawing.Point(85, 20);
            this.cboSkladiste.Name = "cboSkladiste";
            this.cboSkladiste.Size = new System.Drawing.Size(210, 24);
            this.cboSkladiste.TabIndex = 228;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 227;
            this.label5.Text = "Skladište:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(850, 241);
            this.dataGridView1.TabIndex = 229;
            // 
            // btnPregled
            // 
            this.btnPregled.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPregled.BackgroundImage")));
            this.btnPregled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPregled.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPregled.ForeColor = System.Drawing.Color.White;
            this.btnPregled.Location = new System.Drawing.Point(316, 14);
            this.btnPregled.Name = "btnPregled";
            this.btnPregled.Size = new System.Drawing.Size(147, 35);
            this.btnPregled.TabIndex = 230;
            this.btnPregled.Text = "Pretraži";
            this.btnPregled.UseVisualStyleBackColor = true;
            this.btnPregled.Click += new System.EventHandler(this.btnPregled_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(627, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 231;
            this.label8.Text = "Vlasnik :";
            // 
            // cboVlasnikKontejnera
            // 
            this.cboVlasnikKontejnera.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboVlasnikKontejnera.FormattingEnabled = true;
            this.cboVlasnikKontejnera.Location = new System.Drawing.Point(630, 73);
            this.cboVlasnikKontejnera.Name = "cboVlasnikKontejnera";
            this.cboVlasnikKontejnera.Size = new System.Drawing.Size(179, 24);
            this.cboVlasnikKontejnera.TabIndex = 234;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(382, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 232;
            this.label9.Text = "Tip kontejnera:";
            // 
            // cboTipKontejnera
            // 
            this.cboTipKontejnera.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboTipKontejnera.FormattingEnabled = true;
            this.cboTipKontejnera.Location = new System.Drawing.Point(385, 73);
            this.cboTipKontejnera.Name = "cboTipKontejnera";
            this.cboTipKontejnera.Size = new System.Drawing.Size(188, 24);
            this.cboTipKontejnera.TabIndex = 236;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 235;
            this.label10.Text = "Vrsta robe:";
            // 
            // cboVrstaRobe
            // 
            this.cboVrstaRobe.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboVrstaRobe.FormattingEnabled = true;
            this.cboVrstaRobe.Location = new System.Drawing.Point(12, 73);
            this.cboVrstaRobe.Name = "cboVrstaRobe";
            this.cboVrstaRobe.Size = new System.Drawing.Size(316, 24);
            this.cboVrstaRobe.TabIndex = 233;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(334, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 24);
            this.button1.TabIndex = 237;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(579, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 24);
            this.button2.TabIndex = 238;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(815, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 24);
            this.button3.TabIndex = 239;
            this.button3.Text = "?";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmLager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(872, 356);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboVlasnikKontejnera);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboTipKontejnera);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboVrstaRobe);
            this.Controls.Add(this.btnPregled);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cboSkladiste);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregled Lagera";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSkladiste;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPregled;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboVlasnikKontejnera;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTipKontejnera;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboVrstaRobe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}