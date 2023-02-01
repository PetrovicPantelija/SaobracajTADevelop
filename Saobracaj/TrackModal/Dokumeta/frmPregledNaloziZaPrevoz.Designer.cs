namespace Testiranje.Dokumeta
{
    partial class frmPregledNaloziZaPrevoz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledNaloziZaPrevoz));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(897, 350);
            this.dataGridView1.TabIndex = 130;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chk3.ForeColor = System.Drawing.Color.White;
            this.chk3.Location = new System.Drawing.Point(437, 20);
            this.chk3.Name = "chk3";
            this.chk3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk3.Size = new System.Drawing.Size(178, 20);
            this.chk3.TabIndex = 325;
            this.chk3.Text = "Izvršen nalog za prevoz";
            this.chk3.UseVisualStyleBackColor = true;
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chk2.ForeColor = System.Drawing.Color.White;
            this.chk2.Location = new System.Drawing.Point(227, 20);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk2.Size = new System.Drawing.Size(188, 20);
            this.chk2.TabIndex = 324;
            this.chk2.Text = "Lansiran nalog za prevoz";
            this.chk2.UseVisualStyleBackColor = true;
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chk1.ForeColor = System.Drawing.Color.White;
            this.chk1.Location = new System.Drawing.Point(31, 20);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk1.Size = new System.Drawing.Size(170, 20);
            this.chk1.TabIndex = 323;
            this.chk1.Text = "Radni nalog za prevoz";
            this.chk1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(645, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 27);
            this.button1.TabIndex = 326;
            this.button1.Text = "Pretraga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSifra
            // 
            this.txtSifra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSifra.Location = new System.Drawing.Point(60, 46);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(105, 22);
            this.txtSifra.TabIndex = 327;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 328;
            this.label1.Text = "Šifra:";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(227, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 27);
            this.button2.TabIndex = 329;
            this.button2.Text = "Otvori";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmPregledNaloziZaPrevoz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(921, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chk3);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmPregledNaloziZaPrevoz";
            this.Text = "Pregled naloga za prevoz";
            this.Load += new System.EventHandler(this.frmPregledNaloziZaPrevoz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}