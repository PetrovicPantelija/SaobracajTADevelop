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

namespace TrackModal.Dokumeta
{
    public partial class frmKontejneriNaPrijemnici : Form
    {
        string uKontejner;
        public frmKontejneriNaPrijemnici()
        {
            InitializeComponent();
        }

        public frmKontejneriNaPrijemnici(string ulazkontejner)
        {
            InitializeComponent();
            uKontejner = ulazkontejner;
            RefreshDataGridPoKontejneru();
        }


        private void RefreshDataGridPoKontejneru()
        {
            var select = " SELECT top 20 n1.[ID],  DatumPrijema as ETA,  CASE WHEN n1.StatusPrijema = 0 " +
" THEN '1-Najava' ELSE '2-Prijem' END as Status,  n1.VremeDolaska as VremeDolaska   " +
"  FROM[dbo].[PrijemKontejneraVoz] as n1 inner join PrijemKontejneraVozStavke as vs on n1.ID = vs.IDNadredjenog" +
  " where  vs.BrojKontejnera = '" + uKontejner + "' order by n1.[ID]";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "ETA";
            dataGridView1.Columns[1].Width = 100;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Status prijema";
            dataGridView1.Columns[2].Width = 80;

          
            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "ATA";
            dataGridView1.Columns[3].Width = 80;

        }


        private void frmKontejneriNaPrijemnici_Load(object sender, EventArgs e)
        {

        }
    }
}
