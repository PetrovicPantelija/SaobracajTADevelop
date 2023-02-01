namespace Saobracaj.Dokumenta
{
    partial class frmRAdniNalogPregledPoLokomotivama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRAdniNalogPregledPoLokomotivama));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLokomotiva = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.chkZA = new System.Windows.Forms.CheckBox();
            this.chkST = new System.Windows.Forms.CheckBox();
            this.chkPL = new System.Windows.Forms.CheckBox();
            this.chkOD = new System.Windows.Forms.CheckBox();
            this.chkLA = new System.Windows.Forms.CheckBox();
            this.chkPR = new System.Windows.Forms.CheckBox();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboLokomotiva);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.chkZA);
            this.panel1.Controls.Add(this.chkST);
            this.panel1.Controls.Add(this.chkPL);
            this.panel1.Controls.Add(this.chkOD);
            this.panel1.Controls.Add(this.chkLA);
            this.panel1.Controls.Add(this.chkPR);
            this.panel1.Controls.Add(this.txtSifra);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 79);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(204)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1021, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 38);
            this.button1.TabIndex = 139;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(716, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 138;
            this.label2.Text = "Lokomotiva";
            // 
            // cboLokomotiva
            // 
            this.cboLokomotiva.FormattingEnabled = true;
            this.cboLokomotiva.Location = new System.Drawing.Point(807, 38);
            this.cboLokomotiva.Margin = new System.Windows.Forms.Padding(4);
            this.cboLokomotiva.Name = "cboLokomotiva";
            this.cboLokomotiva.Size = new System.Drawing.Size(205, 24);
            this.cboLokomotiva.TabIndex = 137;
            this.cboLokomotiva.SelectedValueChanged += new System.EventHandler(this.cboLokomotiva_SelectedValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1175, 27);
            this.toolStrip1.TabIndex = 136;
            this.toolStrip1.Text = "Pošalji mail infrastrukturi";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(154, 24);
            this.toolStripButton1.Text = "Otvori radni nalog";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(76, 24);
            this.toolStripButton2.Text = "Osveži";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.ForeColor = System.Drawing.Color.White;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(136, 24);
            this.toolStripButton3.Text = "Novi radni nlog";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.ForeColor = System.Drawing.Color.White;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(195, 24);
            this.toolStripButton4.Text = "Pošalji mail infrastrukturi";
            // 
            // chkZA
            // 
            this.chkZA.AutoSize = true;
            this.chkZA.Location = new System.Drawing.Point(621, 41);
            this.chkZA.Margin = new System.Windows.Forms.Padding(4);
            this.chkZA.Name = "chkZA";
            this.chkZA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkZA.Size = new System.Drawing.Size(48, 21);
            this.chkZA.TabIndex = 135;
            this.chkZA.Text = "ZA";
            this.chkZA.UseVisualStyleBackColor = true;
            // 
            // chkST
            // 
            this.chkST.AutoSize = true;
            this.chkST.Location = new System.Drawing.Point(545, 41);
            this.chkST.Margin = new System.Windows.Forms.Padding(4);
            this.chkST.Name = "chkST";
            this.chkST.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkST.Size = new System.Drawing.Size(48, 21);
            this.chkST.TabIndex = 134;
            this.chkST.Text = "ST";
            this.chkST.UseVisualStyleBackColor = true;
            // 
            // chkPL
            // 
            this.chkPL.AutoSize = true;
            this.chkPL.Location = new System.Drawing.Point(472, 41);
            this.chkPL.Margin = new System.Windows.Forms.Padding(4);
            this.chkPL.Name = "chkPL";
            this.chkPL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPL.Size = new System.Drawing.Size(47, 21);
            this.chkPL.TabIndex = 133;
            this.chkPL.Text = "PL";
            this.chkPL.UseVisualStyleBackColor = true;
            // 
            // chkOD
            // 
            this.chkOD.AutoSize = true;
            this.chkOD.Location = new System.Drawing.Point(389, 41);
            this.chkOD.Margin = new System.Windows.Forms.Padding(4);
            this.chkOD.Name = "chkOD";
            this.chkOD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOD.Size = new System.Drawing.Size(51, 21);
            this.chkOD.TabIndex = 132;
            this.chkOD.Text = "OD";
            this.chkOD.UseVisualStyleBackColor = true;
            // 
            // chkLA
            // 
            this.chkLA.AutoSize = true;
            this.chkLA.Location = new System.Drawing.Point(311, 41);
            this.chkLA.Margin = new System.Windows.Forms.Padding(4);
            this.chkLA.Name = "chkLA";
            this.chkLA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLA.Size = new System.Drawing.Size(47, 21);
            this.chkLA.TabIndex = 131;
            this.chkLA.Text = "LA";
            this.chkLA.UseVisualStyleBackColor = true;
            // 
            // chkPR
            // 
            this.chkPR.AutoSize = true;
            this.chkPR.Location = new System.Drawing.Point(231, 41);
            this.chkPR.Margin = new System.Windows.Forms.Padding(4);
            this.chkPR.Name = "chkPR";
            this.chkPR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPR.Size = new System.Drawing.Size(49, 21);
            this.chkPR.TabIndex = 130;
            this.chkPR.Text = "PR";
            this.chkPR.UseVisualStyleBackColor = true;
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(79, 37);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(77, 22);
            this.txtSifra.TabIndex = 128;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 129;
            this.label1.Text = "Šifra:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 86);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1175, 453);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // frmRAdniNalogPregledPoLokomotivama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1175, 554);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRAdniNalogPregledPoLokomotivama";
            this.Text = "Pregled Radnih naloga po lokomotivama";
            this.Load += new System.EventHandler(this.frmRAdniNalogPregledPoLokomotivama_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.CheckBox chkZA;
        private System.Windows.Forms.CheckBox chkST;
        private System.Windows.Forms.CheckBox chkPL;
        private System.Windows.Forms.CheckBox chkOD;
        private System.Windows.Forms.CheckBox chkLA;
        private System.Windows.Forms.CheckBox chkPR;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLokomotiva;
        private System.Windows.Forms.Button button1;
    }
}