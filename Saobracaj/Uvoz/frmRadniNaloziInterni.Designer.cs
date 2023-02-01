
namespace Saobracaj.Uvoz
{
    partial class frmRadniNaloziInterni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadniNaloziInterni));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cboIzdatOd = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.cboIzdatZa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDatumIzdavanja = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatumRealizacije = new System.Windows.Forms.DateTimePicker();
            this.chkZavrsen = new System.Windows.Forms.CheckBox();
            this.cboOsnov = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRefBroj = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1017, 31);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "Štampaj izveštaj";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(29, 28);
            this.tsNew.Text = "Novi";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(29, 28);
            this.tsSave.Text = "tsSave";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsDelete.Image")));
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(29, 28);
            this.tsDelete.Text = "toolStripButton1";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // cboIzdatOd
            // 
            this.cboIzdatOd.FormattingEnabled = true;
            this.cboIzdatOd.Location = new System.Drawing.Point(72, 79);
            this.cboIzdatOd.Name = "cboIzdatOd";
            this.cboIzdatOd.Size = new System.Drawing.Size(301, 24);
            this.cboIzdatOd.TabIndex = 99;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(12, 82);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(58, 17);
            this.label43.TabIndex = 98;
            this.label43.Text = "Izdat od";
            this.label43.Click += new System.EventHandler(this.label43_Click);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.PeachPuff;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(72, 40);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(81, 22);
            this.txtID.TabIndex = 97;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 17);
            this.label16.TabIndex = 96;
            this.label16.Text = "ID";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(394, 149);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(77, 17);
            this.label44.TabIndex = 101;
            this.label44.Text = "Napomena";
            // 
            // txtNapomena
            // 
            this.txtNapomena.Location = new System.Drawing.Point(397, 169);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(608, 84);
            this.txtNapomena.TabIndex = 100;
            // 
            // cboIzdatZa
            // 
            this.cboIzdatZa.FormattingEnabled = true;
            this.cboIzdatZa.Location = new System.Drawing.Point(72, 109);
            this.cboIzdatZa.Name = "cboIzdatZa";
            this.cboIzdatZa.Size = new System.Drawing.Size(301, 24);
            this.cboIzdatZa.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 102;
            this.label1.Text = "Izdat za";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(394, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 18);
            this.label2.TabIndex = 105;
            this.label2.Text = "Datum i vreme izdavanja:";
            // 
            // dtpDatumIzdavanja
            // 
            this.dtpDatumIzdavanja.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumIzdavanja.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDatumIzdavanja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumIzdavanja.Location = new System.Drawing.Point(628, 79);
            this.dtpDatumIzdavanja.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumIzdavanja.Name = "dtpDatumIzdavanja";
            this.dtpDatumIzdavanja.ShowUpDown = true;
            this.dtpDatumIzdavanja.Size = new System.Drawing.Size(190, 27);
            this.dtpDatumIzdavanja.TabIndex = 104;
            this.dtpDatumIzdavanja.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(394, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 18);
            this.label3.TabIndex = 106;
            this.label3.Text = "Datum i vreme realizacije:";
            // 
            // dtpDatumRealizacije
            // 
            this.dtpDatumRealizacije.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDatumRealizacije.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDatumRealizacije.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumRealizacije.Location = new System.Drawing.Point(628, 113);
            this.dtpDatumRealizacije.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDatumRealizacije.Name = "dtpDatumRealizacije";
            this.dtpDatumRealizacije.ShowUpDown = true;
            this.dtpDatumRealizacije.Size = new System.Drawing.Size(190, 27);
            this.dtpDatumRealizacije.TabIndex = 107;
            this.dtpDatumRealizacije.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // chkZavrsen
            // 
            this.chkZavrsen.AutoSize = true;
            this.chkZavrsen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkZavrsen.ForeColor = System.Drawing.Color.Black;
            this.chkZavrsen.Location = new System.Drawing.Point(12, 149);
            this.chkZavrsen.Margin = new System.Windows.Forms.Padding(4);
            this.chkZavrsen.Name = "chkZavrsen";
            this.chkZavrsen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkZavrsen.Size = new System.Drawing.Size(83, 22);
            this.chkZavrsen.TabIndex = 215;
            this.chkZavrsen.Text = "Završen";
            this.chkZavrsen.UseVisualStyleBackColor = true;
            // 
            // cboOsnov
            // 
            this.cboOsnov.FormattingEnabled = true;
            this.cboOsnov.Items.AddRange(new object[] {
            "PlanUtovara",
            "PlanUtovaraDrumski"});
            this.cboOsnov.Location = new System.Drawing.Point(72, 187);
            this.cboOsnov.Name = "cboOsnov";
            this.cboOsnov.Size = new System.Drawing.Size(301, 24);
            this.cboOsnov.TabIndex = 217;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 216;
            this.label4.Text = "Osnov ";
            // 
            // txtRefBroj
            // 
            this.txtRefBroj.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtRefBroj.Location = new System.Drawing.Point(72, 218);
            this.txtRefBroj.Margin = new System.Windows.Forms.Padding(4);
            this.txtRefBroj.Name = "txtRefBroj";
            this.txtRefBroj.Size = new System.Drawing.Size(156, 26);
            this.txtRefBroj.TabIndex = 218;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 219;
            this.label5.Text = "Ref broj";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(12, 271);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(993, 167);
            this.dataGridView1.TabIndex = 220;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // frmRadniNaloziInterni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1017, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRefBroj);
            this.Controls.Add(this.cboOsnov);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkZavrsen);
            this.Controls.Add(this.dtpDatumRealizacije);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDatumIzdavanja);
            this.Controls.Add(this.cboIzdatZa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboIzdatOd);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRadniNaloziInterni";
            this.Text = "Radni nalozi Interni";
            this.Load += new System.EventHandler(this.frmRadniNaloziInterni_Load);
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
        private System.Windows.Forms.ComboBox cboIzdatOd;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.ComboBox cboIzdatZa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDatumIzdavanja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatumRealizacije;
        private System.Windows.Forms.CheckBox chkZavrsen;
        private System.Windows.Forms.ComboBox cboOsnov;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRefBroj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}