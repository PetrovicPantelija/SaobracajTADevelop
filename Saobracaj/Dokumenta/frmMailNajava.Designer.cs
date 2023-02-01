
namespace Saobracaj.Dokumenta
{
    partial class frmMailNajava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMailNajava));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Eta = new System.Windows.Forms.CheckBox();
            this.cb_pPrimanje = new System.Windows.Forms.CheckBox();
            this.cbList_Partneri = new System.Windows.Forms.CheckedListBox();
            this.btn_Filter = new System.Windows.Forms.Button();
            this.btn_PosaljiSvi = new System.Windows.Forms.Button();
            this.btn_Posalji = new System.Windows.Forms.Button();
            this.btn_Svi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 191);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1545, 650);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 68);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status";
            // 
            // cb_Eta
            // 
            this.cb_Eta.AutoSize = true;
            this.cb_Eta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Eta.Location = new System.Drawing.Point(300, 37);
            this.cb_Eta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Eta.Name = "cb_Eta";
            this.cb_Eta.Size = new System.Drawing.Size(61, 22);
            this.cb_Eta.TabIndex = 3;
            this.cb_Eta.Text = "ETA";
            this.cb_Eta.UseVisualStyleBackColor = true;
            // 
            // cb_pPrimanje
            // 
            this.cb_pPrimanje.AutoSize = true;
            this.cb_pPrimanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_pPrimanje.Location = new System.Drawing.Point(300, 68);
            this.cb_pPrimanje.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_pPrimanje.Name = "cb_pPrimanje";
            this.cb_pPrimanje.Size = new System.Drawing.Size(183, 22);
            this.cb_pPrimanje.TabIndex = 4;
            this.cb_pPrimanje.Text = "Predviđeno primanje";
            this.cb_pPrimanje.UseVisualStyleBackColor = true;
            // 
            // cbList_Partneri
            // 
            this.cbList_Partneri.FormattingEnabled = true;
            this.cbList_Partneri.Location = new System.Drawing.Point(541, 11);
            this.cbList_Partneri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbList_Partneri.Name = "cbList_Partneri";
            this.cbList_Partneri.Size = new System.Drawing.Size(385, 157);
            this.cbList_Partneri.TabIndex = 5;
            // 
            // btn_Filter
            // 
            this.btn_Filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_Filter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Filter.Location = new System.Drawing.Point(12, 114);
            this.btn_Filter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Filter.Name = "btn_Filter";
            this.btn_Filter.Size = new System.Drawing.Size(115, 33);
            this.btn_Filter.TabIndex = 6;
            this.btn_Filter.Text = "Filtriraj";
            this.btn_Filter.UseVisualStyleBackColor = false;
            this.btn_Filter.Click += new System.EventHandler(this.btn_Filter_Click);
            // 
            // btn_PosaljiSvi
            // 
            this.btn_PosaljiSvi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_PosaljiSvi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_PosaljiSvi.Location = new System.Drawing.Point(981, 53);
            this.btn_PosaljiSvi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_PosaljiSvi.Name = "btn_PosaljiSvi";
            this.btn_PosaljiSvi.Size = new System.Drawing.Size(147, 53);
            this.btn_PosaljiSvi.TabIndex = 7;
            this.btn_PosaljiSvi.Text = "Posalji svima";
            this.btn_PosaljiSvi.UseVisualStyleBackColor = false;
            this.btn_PosaljiSvi.Click += new System.EventHandler(this.btn_PosaljiSvi_Click);
            // 
            // btn_Posalji
            // 
            this.btn_Posalji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_Posalji.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Posalji.Location = new System.Drawing.Point(1172, 53);
            this.btn_Posalji.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Posalji.Name = "btn_Posalji";
            this.btn_Posalji.Size = new System.Drawing.Size(147, 53);
            this.btn_Posalji.TabIndex = 7;
            this.btn_Posalji.Text = "Posalji";
            this.btn_Posalji.UseVisualStyleBackColor = false;
            this.btn_Posalji.Click += new System.EventHandler(this.btn_Posalji_Click);
            // 
            // btn_Svi
            // 
            this.btn_Svi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(185)))), ((int)(((byte)(87)))));
            this.btn_Svi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Svi.Location = new System.Drawing.Point(160, 114);
            this.btn_Svi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Svi.Name = "btn_Svi";
            this.btn_Svi.Size = new System.Drawing.Size(115, 33);
            this.btn_Svi.TabIndex = 7;
            this.btn_Svi.Text = "Sve najave";
            this.btn_Svi.UseVisualStyleBackColor = false;
            this.btn_Svi.Click += new System.EventHandler(this.btn_Svi_Click);
            // 
            // frmMailNajava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.btn_Svi);
            this.Controls.Add(this.btn_Posalji);
            this.Controls.Add(this.btn_PosaljiSvi);
            this.Controls.Add(this.btn_Filter);
            this.Controls.Add(this.cbList_Partneri);
            this.Controls.Add(this.cb_pPrimanje);
            this.Controls.Add(this.cb_Eta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMailNajava";
            this.Text = "frmMailNajava";
            this.Load += new System.EventHandler(this.frmMailNajava_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_Eta;
        private System.Windows.Forms.CheckBox cb_pPrimanje;
        private System.Windows.Forms.CheckedListBox cbList_Partneri;
        private System.Windows.Forms.Button btn_Filter;
        private System.Windows.Forms.Button btn_PosaljiSvi;
        private System.Windows.Forms.Button btn_Posalji;
        private System.Windows.Forms.Button btn_Svi;
    }
}