
namespace Saobracaj.Sifarnici
{
    partial class frmTelegramiPrikazi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelegramiPrikazi));
            this.btn_dani = new System.Windows.Forms.Button();
            this.btn_Aktivni = new System.Windows.Forms.Button();
            this.btn_svi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.btn_Narocite = new System.Windows.Forms.Button();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_dani
            // 
            this.btn_dani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_dani.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_dani.Location = new System.Drawing.Point(441, 25);
            this.btn_dani.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dani.Name = "btn_dani";
            this.btn_dani.Size = new System.Drawing.Size(185, 52);
            this.btn_dani.TabIndex = 116;
            this.btn_dani.Text = "Narednih 7 dana";
            this.btn_dani.UseVisualStyleBackColor = false;
            this.btn_dani.Click += new System.EventHandler(this.btn_dani_Click);
            // 
            // btn_Aktivni
            // 
            this.btn_Aktivni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_Aktivni.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Aktivni.Location = new System.Drawing.Point(676, 25);
            this.btn_Aktivni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Aktivni.Name = "btn_Aktivni";
            this.btn_Aktivni.Size = new System.Drawing.Size(185, 52);
            this.btn_Aktivni.TabIndex = 117;
            this.btn_Aktivni.Text = "Aktivni";
            this.btn_Aktivni.UseVisualStyleBackColor = false;
            this.btn_Aktivni.Click += new System.EventHandler(this.btn_Aktivni_Click);
            // 
            // btn_svi
            // 
            this.btn_svi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_svi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_svi.Location = new System.Drawing.Point(1127, 25);
            this.btn_svi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_svi.Name = "btn_svi";
            this.btn_svi.Size = new System.Drawing.Size(185, 52);
            this.btn_svi.TabIndex = 118;
            this.btn_svi.Text = "Svi telegrami";
            this.btn_svi.UseVisualStyleBackColor = false;
            this.btn_svi.Click += new System.EventHandler(this.btn_svi_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 82);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1777, 732);
            this.dataGridView1.TabIndex = 119;
            // 
            // timer1
            // 
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 120000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 120000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // btn_Narocite
            // 
            this.btn_Narocite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_Narocite.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Narocite.Location = new System.Drawing.Point(900, 25);
            this.btn_Narocite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Narocite.Name = "btn_Narocite";
            this.btn_Narocite.Size = new System.Drawing.Size(185, 52);
            this.btn_Narocite.TabIndex = 117;
            this.btn_Narocite.Text = "Narocite posiljke";
            this.btn_Narocite.UseVisualStyleBackColor = false;
            this.btn_Narocite.Click += new System.EventHandler(this.btn_Narocite_Click);
            // 
            // timer4
            // 
            this.timer4.Interval = 120000;
            // 
            // frmTelegramiPrikazi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_svi);
            this.Controls.Add(this.btn_Narocite);
            this.Controls.Add(this.btn_Aktivni);
            this.Controls.Add(this.btn_dani);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTelegramiPrikazi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prikaz telegrama";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTelgramiPrikazi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_dani;
        private System.Windows.Forms.Button btn_Aktivni;
        private System.Windows.Forms.Button btn_svi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button btn_Narocite;
        private System.Windows.Forms.Timer timer4;
    }
}