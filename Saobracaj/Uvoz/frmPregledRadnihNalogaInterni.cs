using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Uvoz
{
    public partial class frmPregledRadnihNalogaInterni : Form
    {
        bool status = false;
        string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public frmPregledRadnihNalogaInterni()
        {
            InitializeComponent();
        }

        private void FillGV()
        {
            var select = "SELECT RadniNalogInterni.[ID] " +
            ",[OJIzdavanja] , o1.Naziv as Izdao " +
            ",[OJRealizacije] ,o2.Naziv as Realizuje " +
            ",[DatumIzdavanja] ,[DatumRealizacije]" +
            ",[Napomena] ,[Uradjen]" +
            ",[Osnov] ,[BrojOsnov]" +
            ",[KorisnikIzdao] ,[KorisnikZavrsio]" +
            "     FROM [RadniNalogInterni]" +
            " inner join OrganizacioneJedinice as o1 on OjIzdavanja = O1.ID" +
            " inner join OrganizacioneJedinice as o2 on OjRealizacije = O2.ID order by RadniNalogInterni.ID desc";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "OJIZD";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Izdao";
            dataGridView1.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "OJ REAL";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Realizuje";
            dataGridView1.Columns[4].Width = 90;

        }

        private void FillGVOtvoreni()
        {
            var select = "SELECT RadniNalogInterni.[ID] " +
            ",[OJIzdavanja] , o1.Naziv as Izdao " +
            ",[OJRealizacije] ,o2.Naziv as Realizuje " +
            ",[DatumIzdavanja] ,[DatumRealizacije]" +
            ",[Napomena] ,[Uradjen]" +
            ",[Osnov] ,[BrojOsnov]" +
            ",[KorisnikIzdao] ,[KorisnikZavrsio]" +
            "     FROM [RadniNalogInterni]" +
            " inner join OrganizacioneJedinice as o1 on OjIzdavanja = O1.ID" +
            " inner join OrganizacioneJedinice as o2 on OjRealizacije = O2.ID " +
            " where Uradjen = 0 " +
            " order by RadniNalogInterni.ID desc";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "OJIZD";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Izdao";
            dataGridView1.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "OJ REAL";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Realizuje";
            dataGridView1.Columns[4].Width = 90;

        }

        private void FillGVZatvoreni()
        {
            var select = "SELECT RadniNalogInterni.[ID] " +
            ",[OJIzdavanja] , o1.Naziv as Izdao " +
            ",[OJRealizacije] ,o2.Naziv as Realizuje " +
            ",[DatumIzdavanja] ,[DatumRealizacije]" +
            ",[Napomena] ,[Uradjen]" +
            ",[Osnov] ,[BrojOsnov]" +
            ",[KorisnikIzdao] ,[KorisnikZavrsio]" +
            "     FROM [RadniNalogInterni]" +
            " inner join OrganizacioneJedinice as o1 on OjIzdavanja = O1.ID" +
            " inner join OrganizacioneJedinice as o2 on OjRealizacije = O2.ID " +
            " where Uradjen = 1 " +
            " order by RadniNalogInterni.ID desc";
            SqlConnection conn = new SqlConnection(connection);
            var da = new SqlDataAdapter(select, conn);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "OJIZD";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Izdao";
            dataGridView1.Columns[2].Width = 90;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "OJ REAL";
            dataGridView1.Columns[3].Width = 50;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Realizuje";
            dataGridView1.Columns[4].Width = 90;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InsertRadniNalogInterni ins = new InsertRadniNalogInterni();
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        ins.UpdRadniNalogInterniZavrsen(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                }
            }
            catch { }
            FillGVOtvoreni();
       
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FillGV();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FillGVOtvoreni();
        }
    }
}
