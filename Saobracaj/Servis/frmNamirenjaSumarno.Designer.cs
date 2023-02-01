
namespace Saobracaj.Servis
{
    partial class frmNamirenjaSumarno
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
            Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor gridSummaryColumnDescriptor1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNamirenjaSumarno));
            this.gridGroupingControl1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridGroupingControl1
            // 
            this.gridGroupingControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridGroupingControl1.BackColor = System.Drawing.SystemColors.Window;
            this.gridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGroupingControl1.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2016;
            this.gridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2016Colorful;
            this.gridGroupingControl1.Location = new System.Drawing.Point(0, 0);
            this.gridGroupingControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridGroupingControl1.Name = "gridGroupingControl1";
            this.gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridGroupingControl1.Size = new System.Drawing.Size(1189, 481);
            this.gridGroupingControl1.TabIndex = 0;
            this.gridGroupingControl1.TableDescriptor.AllowNew = false;
            gridSummaryColumnDescriptor1.DisplayColumn = "Kolicina";
            gridSummaryColumnDescriptor1.Format = "{Sum}";
            gridSummaryColumnDescriptor1.Name = "Kolicina";
            gridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.Int32Aggregate;
            this.gridGroupingControl1.TableDescriptor.SummaryRows.Add(new Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor("Kolicina", new Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor[] {
                gridSummaryColumnDescriptor1}));
            this.gridGroupingControl1.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 28;
            this.gridGroupingControl1.TableDescriptor.TableOptions.RecordRowHeight = 28;
            this.gridGroupingControl1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridGroupingControl1.TableOptions.SelectionTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.gridGroupingControl1.Text = "gridGroupingControl1";
            this.gridGroupingControl1.TopLevelGroupOptions.CaptionSummaryRow = "";
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaptionSummaryCells = true;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowGroupHeader = true;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowGroupSummaryWhenCollapsed = true;
            this.gridGroupingControl1.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeFilter;
            this.gridGroupingControl1.UseRightToLeftCompatibleTextBox = true;
            this.gridGroupingControl1.VersionInfo = "18.4460.0.34";
            // 
            // frmNamirenjaSumarno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 481);
            this.Controls.Add(this.gridGroupingControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmNamirenjaSumarno";
            this.Text = "Namirenja sumarno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNamirenjaSumarno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridGroupingControl1;
    }
}