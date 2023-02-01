using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Data;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;

namespace Saobracaj.Uvoz
{
    public partial class frmRadniNalogInterniPregled : Syncfusion.Windows.Forms.Office2010Form
    {
        public frmRadniNalogInterniPregled()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var select = "  SELECT RadniNalogInterni.[ID] " +
         " ,[OJIzdavanja]      , o1.Naziv as Izdao " +
         " ,[OJRealizacije]      ,o2.Naziv as Realizuje " +
         " ,[DatumIzdavanja]      ,[DatumRealizacije] " +
         " ,RadniNalogInterni.[Napomena]      ,[Uradjen] " +
         " ,[Osnov]      ,[BrojOsnov] " +
         " ,[KorisnikIzdao]      ,[KorisnikZavrsio] " +
         " ,UvozKonacna.BrojKontejnera      , uv.PaNaziv as Uvoznik " +
         " , VL.PaSifra as Vlasnik      , TipKontenjera.Naziv as Tipkontejnera " +
         " FROM [RadniNalogInterni] " +
         " inner join OrganizacioneJedinice as o1 on OjIzdavanja = O1.ID " +
         " inner join OrganizacioneJedinice as o2 on OjRealizacije = O2.ID " +
         " inner join UvozKonacna on UvozKonacna.ID = BrojOsnov " +
         " inner join Partnerji uv on uv.PaSifra = UvozKonacna.Uvoznik " +
         " inner join Partnerji VL on VL.PaSifra = UvozKonacna.VlasnikKontejnera " +
         " inner join TipKontenjera on TipKontenjera.ID = UvozKonacna.TipKontejnera " +
         " where OJIzdavanja = " + Convert.ToInt32(cboIzdatOd.SelectedValue) + 
         " order by RadniNalogInterni.ID desc";

            var s_connection = ConfigurationManager.ConnectionStrings["Saobracaj.Properties.Settings.TESTIRANJEConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            gridGroupingControl1.DataSource = ds.Tables[0];
            gridGroupingControl1.ShowGroupDropArea = true;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = true;
            foreach (GridColumnDescriptor column in this.gridGroupingControl1.TableDescriptor.Columns)
            {
                column.AllowFilter = true;
            }
            GridSummaryColumnDescriptor summaryColumnDescriptor = new GridSummaryColumnDescriptor();
            summaryColumnDescriptor.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
            summaryColumnDescriptor.DataMember = "Uradjen";
            summaryColumnDescriptor.Format = "{Sum}";
            summaryColumnDescriptor.Name = "Uradjeno";
            summaryColumnDescriptor.SummaryType = Syncfusion.Grouping.SummaryType.Int32Aggregate;

            GridSummaryRowDescriptor summaryRowDescriptor = new GridSummaryRowDescriptor();
            summaryRowDescriptor.SummaryColumns.Add(summaryColumnDescriptor);
            summaryRowDescriptor.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(255, 231, 162));

            this.gridGroupingControl1.TableDescriptor.SummaryRows.Add(summaryRowDescriptor);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var select = "  SELECT RadniNalogInterni.[ID] " +
      " ,[OJIzdavanja]      , o1.Naziv as Izdao " +
      " ,[OJRealizacije]      ,o2.Naziv as Realizuje " +
      " ,[DatumIzdavanja]      ,[DatumRealizacije] " +
      " ,RadniNalogInterni.[Napomena]      ,[Uradjen] " +
      " ,[Osnov]      ,[BrojOsnov] " +
      " ,[KorisnikIzdao]      ,[KorisnikZavrsio] " +
      " ,UvozKonacna.BrojKontejnera      , uv.PaNaziv as Uvoznik " +
      " , VL.PaSifra as Vlasnik      , TipKontenjera.Naziv as Tipkontejnera " +
      " FROM [RadniNalogInterni] " +
      " inner join OrganizacioneJedinice as o1 on OjIzdavanja = O1.ID " +
      " inner join OrganizacioneJedinice as o2 on OjRealizacije = O2.ID " +
      " inner join UvozKonacna on UvozKonacna.ID = BrojOsnov " +
      " inner join Partnerji uv on uv.PaSifra = UvozKonacna.Uvoznik " +
      " inner join Partnerji VL on VL.PaSifra = UvozKonacna.VlasnikKontejnera " +
      " inner join TipKontenjera on TipKontenjera.ID = UvozKonacna.TipKontejnera " +
      " where OJRealizacije = " + Convert.ToInt32(cboIzdatZa.SelectedValue) +
      " order by RadniNalogInterni.ID desc";

            var s_connection = ConfigurationManager.ConnectionStrings["Saobracaj.Properties.Settings.TESTIRANJEConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            gridGroupingControl1.DataSource = ds.Tables[0];
            gridGroupingControl1.ShowGroupDropArea = true;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = true;
            foreach (GridColumnDescriptor column in this.gridGroupingControl1.TableDescriptor.Columns)
            {
                column.AllowFilter = true;
            }
            GridSummaryColumnDescriptor summaryColumnDescriptor = new GridSummaryColumnDescriptor();
            summaryColumnDescriptor.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
            summaryColumnDescriptor.DataMember = "Uradjen";
            summaryColumnDescriptor.Format = "{Sum}";
            summaryColumnDescriptor.Name = "Uradjeno";
            summaryColumnDescriptor.SummaryType = Syncfusion.Grouping.SummaryType.Int32Aggregate;

            GridSummaryRowDescriptor summaryRowDescriptor = new GridSummaryRowDescriptor();
            summaryRowDescriptor.SummaryColumns.Add(summaryColumnDescriptor);
            summaryRowDescriptor.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(255, 231, 162));

            this.gridGroupingControl1.TableDescriptor.SummaryRows.Add(summaryRowDescriptor);
        }

        private void frmRadniNalogInterniPregled_Load(object sender, EventArgs e)
        {
            var select8 = "  Select Distinct ID, Naziv   From OrganizacioneJedinice ";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboIzdatOd.DataSource = ds8.Tables[0];
            cboIzdatOd.DisplayMember = "Naziv";
            cboIzdatOd.ValueMember = "ID";



            var select9 = "  Select Distinct ID, Naziv   From OrganizacioneJedinice ";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection9);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);

            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            cboIzdatZa.DataSource = ds9.Tables[0];
            cboIzdatZa.DisplayMember = "Naziv";
            cboIzdatZa.ValueMember = "ID";
        }
    }
}
