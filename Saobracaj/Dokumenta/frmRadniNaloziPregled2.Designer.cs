namespace Saobracaj.Dokumenta
{
    partial class frmRadniNaloziPregled2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadniNaloziPregled2));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chkZA = new System.Windows.Forms.CheckBox();
            this.chkST = new System.Windows.Forms.CheckBox();
            this.chkPL = new System.Windows.Forms.CheckBox();
            this.chkOD = new System.Windows.Forms.CheckBox();
            this.chkLA = new System.Windows.Forms.CheckBox();
            this.chkPR = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsSave,
            this.tsDelete,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1201, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "Unos lokomotiva";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(29, 24);
            this.tsNew.Text = "Novi";
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(29, 24);
            this.tsSave.Text = "tsSave";
            // 
            // tsDelete
            // 
            this.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsDelete.Image")));
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(29, 24);
            this.tsDelete.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
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
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(61, 37);
            this.txtSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(77, 22);
            this.txtSifra.TabIndex = 123;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 124;
            this.label1.Text = "Šifra:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 70);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1169, 422);
            this.dataGridView1.TabIndex = 122;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // chkZA
            // 
            this.chkZA.AutoSize = true;
            this.chkZA.Location = new System.Drawing.Point(599, 41);
            this.chkZA.Margin = new System.Windows.Forms.Padding(4);
            this.chkZA.Name = "chkZA";
            this.chkZA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkZA.Size = new System.Drawing.Size(48, 21);
            this.chkZA.TabIndex = 133;
            this.chkZA.Text = "ZA";
            this.chkZA.UseVisualStyleBackColor = true;
            this.chkZA.CheckedChanged += new System.EventHandler(this.chkZA_CheckedChanged);
            // 
            // chkST
            // 
            this.chkST.AutoSize = true;
            this.chkST.Location = new System.Drawing.Point(523, 41);
            this.chkST.Margin = new System.Windows.Forms.Padding(4);
            this.chkST.Name = "chkST";
            this.chkST.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkST.Size = new System.Drawing.Size(48, 21);
            this.chkST.TabIndex = 132;
            this.chkST.Text = "ST";
            this.chkST.UseVisualStyleBackColor = true;
            this.chkST.CheckedChanged += new System.EventHandler(this.chkST_CheckedChanged);
            // 
            // chkPL
            // 
            this.chkPL.AutoSize = true;
            this.chkPL.Location = new System.Drawing.Point(241, 41);
            this.chkPL.Margin = new System.Windows.Forms.Padding(4);
            this.chkPL.Name = "chkPL";
            this.chkPL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPL.Size = new System.Drawing.Size(47, 21);
            this.chkPL.TabIndex = 131;
            this.chkPL.Text = "PL";
            this.chkPL.UseVisualStyleBackColor = true;
            this.chkPL.CheckedChanged += new System.EventHandler(this.chkPL_CheckedChanged);
            // 
            // chkOD
            // 
            this.chkOD.AutoSize = true;
            this.chkOD.Location = new System.Drawing.Point(323, 39);
            this.chkOD.Margin = new System.Windows.Forms.Padding(4);
            this.chkOD.Name = "chkOD";
            this.chkOD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOD.Size = new System.Drawing.Size(51, 21);
            this.chkOD.TabIndex = 130;
            this.chkOD.Text = "OD";
            this.chkOD.UseVisualStyleBackColor = true;
            this.chkOD.CheckedChanged += new System.EventHandler(this.chkOD_CheckedChanged);
            // 
            // chkLA
            // 
            this.chkLA.AutoSize = true;
            this.chkLA.Location = new System.Drawing.Point(424, 41);
            this.chkLA.Margin = new System.Windows.Forms.Padding(4);
            this.chkLA.Name = "chkLA";
            this.chkLA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLA.Size = new System.Drawing.Size(49, 21);
            this.chkLA.TabIndex = 129;
            this.chkLA.Text = "RA";
            this.chkLA.UseVisualStyleBackColor = true;
            this.chkLA.CheckedChanged += new System.EventHandler(this.chkLA_CheckedChanged);
            // 
            // chkPR
            // 
            this.chkPR.AutoSize = true;
            this.chkPR.Location = new System.Drawing.Point(167, 41);
            this.chkPR.Margin = new System.Windows.Forms.Padding(4);
            this.chkPR.Name = "chkPR";
            this.chkPR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPR.Size = new System.Drawing.Size(49, 21);
            this.chkPR.TabIndex = 128;
            this.chkPR.Text = "PR";
            this.chkPR.UseVisualStyleBackColor = true;
            this.chkPR.CheckedChanged += new System.EventHandler(this.chkPR_CheckedChanged);
            // 
            // frmRadniNaloziPregled2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1201, 495);
            this.Controls.Add(this.chkZA);
            this.Controls.Add(this.chkST);
            this.Controls.Add(this.chkPL);
            this.Controls.Add(this.chkOD);
            this.Controls.Add(this.chkLA);
            this.Controls.Add(this.chkPR);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRadniNaloziPregled2";
            this.Text = "Radni nalozi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRadniNaloziPregled2_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkZA;
        private System.Windows.Forms.CheckBox chkST;
        private System.Windows.Forms.CheckBox chkPL;
        private System.Windows.Forms.CheckBox chkOD;
        private System.Windows.Forms.CheckBox chkLA;
        private System.Windows.Forms.CheckBox chkPR;
    }
}