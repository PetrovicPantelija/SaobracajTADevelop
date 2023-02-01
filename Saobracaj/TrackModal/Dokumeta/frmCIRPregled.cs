using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;

using Microsoft.Reporting.WinForms;

namespace Testiranje.Dokumeta
{
    public partial class frmCIRPregled : Form
    {
        public frmCIRPregled()
        {
            InitializeComponent();
        }

        private void frmCIRPregled_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();

        }

        private void RefreshDataGrid()
        {
            var select = "  SELECT top 4000 [ID] ,[BrKontejnera] ,[Datum] as DatumIzrade " +
" ,[Prijem],[Dokument] " +
" ,[TiKontejnera],[MaterijalCelik],[MaterijalAlumini],[incoming] " +
" ,[Pun],[Tezina],[Plomba1] " +
" ,[Plomba2],[DatumIn],[Vagon],[TruckNo] " +
" ,[Damaged],[Ispravan],[Prevoz],[Containerresponsible] " +
" ,[primedbe],[Received],[Inspected],[Delivery] " +
" ,[Korisnik],[Size] " +
" ,[Duzina],[Sirina],[Visina],[sPlomba] " +
" ,[sPlomba2]  FROM[dbo].[CIR] order by ID desc";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = false;
            dataGridView1.DataSource = ds.Tables[0];

         



        }
    }
}
