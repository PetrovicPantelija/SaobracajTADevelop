
namespace Saobracaj.Sifarnici
{
    partial class frmDelavci
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDelavci));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtDeKrajBivS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDeUlHisStBivS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDeEMail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeTelefon2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDeTelefon1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeIme = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeSifra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDePriimek = new System.Windows.Forms.TextBox();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtDeSifDelMes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeSifStat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkManevrista = new System.Windows.Forms.CheckBox();
            this.chkPregledacKola = new System.Windows.Forms.CheckBox();
            this.chkVozovodja = new System.Windows.Forms.CheckBox();
            this.chkPomocnik = new System.Windows.Forms.CheckBox();
            this.chkMasinovodja = new System.Windows.Forms.CheckBox();
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
            this.toolStrip1.Size = new System.Drawing.Size(1153, 27);
            this.toolStrip1.TabIndex = 197;
            this.toolStrip1.Text = "Osveži";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(29, 24);
            this.tsNew.Text = "Novi";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(29, 24);
            this.tsSave.Text = "tsSave";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
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
            // txtDeKrajBivS
            // 
            this.txtDeKrajBivS.Location = new System.Drawing.Point(501, 107);
            this.txtDeKrajBivS.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeKrajBivS.Name = "txtDeKrajBivS";
            this.txtDeKrajBivS.Size = new System.Drawing.Size(304, 22);
            this.txtDeKrajBivS.TabIndex = 215;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(401, 107);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 214;
            this.label10.Text = "Mesto";
            // 
            // txtDeUlHisStBivS
            // 
            this.txtDeUlHisStBivS.Location = new System.Drawing.Point(501, 75);
            this.txtDeUlHisStBivS.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeUlHisStBivS.Name = "txtDeUlHisStBivS";
            this.txtDeUlHisStBivS.Size = new System.Drawing.Size(304, 22);
            this.txtDeUlHisStBivS.TabIndex = 213;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(401, 78);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 212;
            this.label9.Text = "Adresa";
            // 
            // txtDeEMail
            // 
            this.txtDeEMail.Location = new System.Drawing.Point(501, 45);
            this.txtDeEMail.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeEMail.Name = "txtDeEMail";
            this.txtDeEMail.Size = new System.Drawing.Size(304, 22);
            this.txtDeEMail.TabIndex = 209;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(403, 45);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 208;
            this.label7.Text = "E Mail";
            // 
            // txtDeTelefon2
            // 
            this.txtDeTelefon2.Location = new System.Drawing.Point(77, 176);
            this.txtDeTelefon2.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeTelefon2.Name = "txtDeTelefon2";
            this.txtDeTelefon2.Size = new System.Drawing.Size(304, 22);
            this.txtDeTelefon2.TabIndex = 207;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 176);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 206;
            this.label6.Text = "Telefon 2";
            // 
            // txtDeTelefon1
            // 
            this.txtDeTelefon1.Location = new System.Drawing.Point(77, 144);
            this.txtDeTelefon1.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeTelefon1.Name = "txtDeTelefon1";
            this.txtDeTelefon1.Size = new System.Drawing.Size(304, 22);
            this.txtDeTelefon1.TabIndex = 205;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 204;
            this.label5.Text = "Telefon 1";
            // 
            // txtDeIme
            // 
            this.txtDeIme.Location = new System.Drawing.Point(77, 112);
            this.txtDeIme.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeIme.Name = "txtDeIme";
            this.txtDeIme.Size = new System.Drawing.Size(304, 22);
            this.txtDeIme.TabIndex = 203;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 202;
            this.label4.Text = "Ime";
            // 
            // txtDeSifra
            // 
            this.txtDeSifra.Location = new System.Drawing.Point(78, 45);
            this.txtDeSifra.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeSifra.Name = "txtDeSifra";
            this.txtDeSifra.Size = new System.Drawing.Size(140, 22);
            this.txtDeSifra.TabIndex = 201;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 200;
            this.label3.Text = "Šifra";
            // 
            // txtDePriimek
            // 
            this.txtDePriimek.Location = new System.Drawing.Point(78, 80);
            this.txtDePriimek.Margin = new System.Windows.Forms.Padding(4);
            this.txtDePriimek.Name = "txtDePriimek";
            this.txtDePriimek.Size = new System.Drawing.Size(304, 22);
            this.txtDePriimek.TabIndex = 199;
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(11, 80);
            this.lblNaziv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(59, 17);
            this.lblNaziv.TabIndex = 198;
            this.lblNaziv.Text = "Prezime";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 243);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1117, 312);
            this.dataGridView1.TabIndex = 216;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // txtDeSifDelMes
            // 
            this.txtDeSifDelMes.Location = new System.Drawing.Point(501, 137);
            this.txtDeSifDelMes.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeSifDelMes.Name = "txtDeSifDelMes";
            this.txtDeSifDelMes.Size = new System.Drawing.Size(304, 22);
            this.txtDeSifDelMes.TabIndex = 218;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(401, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 217;
            this.label1.Text = "Radno mesto";
            // 
            // txtDeSifStat
            // 
            this.txtDeSifStat.Location = new System.Drawing.Point(501, 167);
            this.txtDeSifStat.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeSifStat.Name = "txtDeSifStat";
            this.txtDeSifStat.Size = new System.Drawing.Size(304, 22);
            this.txtDeSifStat.TabIndex = 220;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 219;
            this.label2.Text = "Status";
            // 
            // chkManevrista
            // 
            this.chkManevrista.AutoSize = true;
            this.chkManevrista.Location = new System.Drawing.Point(856, 163);
            this.chkManevrista.Margin = new System.Windows.Forms.Padding(4);
            this.chkManevrista.Name = "chkManevrista";
            this.chkManevrista.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkManevrista.Size = new System.Drawing.Size(99, 21);
            this.chkManevrista.TabIndex = 225;
            this.chkManevrista.Text = "Manevrista";
            this.chkManevrista.UseVisualStyleBackColor = true;
            // 
            // chkPregledacKola
            // 
            this.chkPregledacKola.AutoSize = true;
            this.chkPregledacKola.Location = new System.Drawing.Point(831, 134);
            this.chkPregledacKola.Margin = new System.Windows.Forms.Padding(4);
            this.chkPregledacKola.Name = "chkPregledacKola";
            this.chkPregledacKola.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPregledacKola.Size = new System.Drawing.Size(124, 21);
            this.chkPregledacKola.TabIndex = 224;
            this.chkPregledacKola.Text = "Pregledač kola";
            this.chkPregledacKola.UseVisualStyleBackColor = true;
            // 
            // chkVozovodja
            // 
            this.chkVozovodja.AutoSize = true;
            this.chkVozovodja.Location = new System.Drawing.Point(862, 105);
            this.chkVozovodja.Margin = new System.Windows.Forms.Padding(4);
            this.chkVozovodja.Name = "chkVozovodja";
            this.chkVozovodja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkVozovodja.Size = new System.Drawing.Size(93, 21);
            this.chkVozovodja.TabIndex = 223;
            this.chkVozovodja.Text = "Vozovođa";
            this.chkVozovodja.UseVisualStyleBackColor = true;
            // 
            // chkPomocnik
            // 
            this.chkPomocnik.AutoSize = true;
            this.chkPomocnik.Location = new System.Drawing.Point(864, 76);
            this.chkPomocnik.Margin = new System.Windows.Forms.Padding(4);
            this.chkPomocnik.Name = "chkPomocnik";
            this.chkPomocnik.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPomocnik.Size = new System.Drawing.Size(91, 21);
            this.chkPomocnik.TabIndex = 222;
            this.chkPomocnik.Text = "Pomoćnik";
            this.chkPomocnik.UseVisualStyleBackColor = true;
            // 
            // chkMasinovodja
            // 
            this.chkMasinovodja.AutoSize = true;
            this.chkMasinovodja.Location = new System.Drawing.Point(849, 47);
            this.chkMasinovodja.Margin = new System.Windows.Forms.Padding(4);
            this.chkMasinovodja.Name = "chkMasinovodja";
            this.chkMasinovodja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMasinovodja.Size = new System.Drawing.Size(106, 21);
            this.chkMasinovodja.TabIndex = 221;
            this.chkMasinovodja.Text = "Mašinovođa";
            this.chkMasinovodja.UseVisualStyleBackColor = true;
            // 
            // frmDelavci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1153, 558);
            this.Controls.Add(this.chkManevrista);
            this.Controls.Add(this.chkPregledacKola);
            this.Controls.Add(this.chkVozovodja);
            this.Controls.Add(this.chkPomocnik);
            this.Controls.Add(this.chkMasinovodja);
            this.Controls.Add(this.txtDeSifStat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDeSifDelMes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDeKrajBivS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDeUlHisStBivS);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDeEMail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDeTelefon2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDeTelefon1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDeIme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDeSifra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDePriimek);
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDelavci";
            this.Text = "Zaposleni";
            this.Load += new System.EventHandler(this.frmDelavci_Load);
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
        private System.Windows.Forms.TextBox txtDeKrajBivS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDeUlHisStBivS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDeEMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeTelefon2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeTelefon1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeIme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeSifra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDePriimek;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDeSifDelMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeSifStat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkManevrista;
        private System.Windows.Forms.CheckBox chkPregledacKola;
        private System.Windows.Forms.CheckBox chkVozovodja;
        private System.Windows.Forms.CheckBox chkPomocnik;
        private System.Windows.Forms.CheckBox chkMasinovodja;
    }
}