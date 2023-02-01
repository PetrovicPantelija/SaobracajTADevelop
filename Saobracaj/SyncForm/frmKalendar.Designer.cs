
namespace Saobracaj.SyncForm
{
    partial class frmKalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKalendar));
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAdv1 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.comboBoxAdv5 = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdv6 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scheduleControl1 = new Syncfusion.Windows.Forms.Schedule.ScheduleControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonAdv1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.comboBoxAdv5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonAdv6);
            this.panel2.Location = new System.Drawing.Point(17, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1296, 76);
            this.panel2.TabIndex = 34;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // buttonAdv1
            // 
            this.buttonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonAdv1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAdv1.BeforeTouchSize = new System.Drawing.Size(112, 31);
            this.buttonAdv1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv1.ForeColor = System.Drawing.Color.White;
            this.buttonAdv1.Location = new System.Drawing.Point(431, 34);
            this.buttonAdv1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdv1.Name = "buttonAdv1";
            this.buttonAdv1.Size = new System.Drawing.Size(112, 31);
            this.buttonAdv1.TabIndex = 29;
            this.buttonAdv1.Text = "Save";
            this.buttonAdv1.ThemeName = "Metro";
            this.buttonAdv1.UseVisualStyle = true;
            this.buttonAdv1.Click += new System.EventHandler(this.buttonAdv1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(661, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(164, 69);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // comboBoxAdv5
            // 
            this.comboBoxAdv5.AllowNewText = false;
            this.comboBoxAdv5.BackColor = System.Drawing.Color.White;
            this.comboBoxAdv5.BeforeTouchSize = new System.Drawing.Size(250, 25);
            this.comboBoxAdv5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAdv5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.comboBoxAdv5.Location = new System.Drawing.Point(8, 42);
            this.comboBoxAdv5.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAdv5.Name = "comboBoxAdv5";
            this.comboBoxAdv5.Size = new System.Drawing.Size(250, 25);
            this.comboBoxAdv5.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.comboBoxAdv5.TabIndex = 27;
            this.comboBoxAdv5.ThemeName = "Metro";
            this.comboBoxAdv5.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Choose Data Source";
            this.label1.Visible = false;
            // 
            // buttonAdv6
            // 
            this.buttonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonAdv6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAdv6.BeforeTouchSize = new System.Drawing.Size(112, 31);
            this.buttonAdv6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv6.ForeColor = System.Drawing.Color.White;
            this.buttonAdv6.Location = new System.Drawing.Point(311, 34);
            this.buttonAdv6.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdv6.Name = "buttonAdv6";
            this.buttonAdv6.Size = new System.Drawing.Size(112, 31);
            this.buttonAdv6.TabIndex = 10;
            this.buttonAdv6.Text = "Osveži";
            this.buttonAdv6.ThemeName = "Metro";
            this.buttonAdv6.UseVisualStyle = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.scheduleControl1);
            this.panel1.Location = new System.Drawing.Point(16, 98);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1297, 657);
            this.panel1.TabIndex = 35;
            // 
            // scheduleControl1
            // 
            this.scheduleControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleControl1.Appearance.WeekHeaderFormat = "MMMM dd";
            this.scheduleControl1.Appearance.WeekMonthFullFormat = "dddd, dd MMMM yyyy";
            this.scheduleControl1.BackColor = System.Drawing.Color.Gray;
            this.scheduleControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scheduleControl1.Culture = new System.Globalization.CultureInfo("");
            this.scheduleControl1.DataSource = null;
            this.scheduleControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.scheduleControl1.ISO8601CalenderFormat = false;
            this.scheduleControl1.Location = new System.Drawing.Point(0, 4);
            this.scheduleControl1.Margin = new System.Windows.Forms.Padding(4);
            this.scheduleControl1.Name = "scheduleControl1";
            this.scheduleControl1.ShowRoundedCorners = true;
            this.scheduleControl1.Size = new System.Drawing.Size(1293, 649);
            this.scheduleControl1.TabIndex = 3;
            this.scheduleControl1.ParseDisplayItem += new Syncfusion.Windows.Forms.Schedule.ParseDisplayItemEventHandler(this.scheduleControl1_ParseDisplayItem);
            // 
            // frmKalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(1327, 757);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKalendar";
            this.Text = "Kalendar";
            this.Load += new System.EventHandler(this.frmKalendar_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv comboBoxAdv5;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv6;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Schedule.ScheduleControl scheduleControl1;
    }
}