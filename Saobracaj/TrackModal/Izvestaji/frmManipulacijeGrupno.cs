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

namespace Testiranje.Izvestaji
{
    public partial class frmManipulacijeGrupno : Form
    {
        public frmManipulacijeGrupno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var select = "     select NaruceneManipulacije.Platilac,Komitenti.Naziv,Count(*) as Ukupno,  Sum(CASE WHEN NaruceneManipulacije.Uradjeno > 0 THEN 1 ELSE 0 END) as Uradjeno " +
 " from NaruceneManipulacije " +
 " inner join Komitenti on NaruceneManipulacije.Platilac = Komitenti.ID " +
 " where  NaruceneManipulacije.DatumOd >= '" + dtpDatumOd.Text + "' and NaruceneManipulacije.DatumDo <= '" + dtpDatumDo.Text + "'" +
            " group by NaruceneManipulacije.Platilac,Komitenti.Naziv ";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = false;
            dataGridView3.DataSource = ds.Tables[0];

            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView3.BackgroundColor = Color.White;

            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;



            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "Platilac id";
            dataGridView3.Columns[0].Width = 40;
          //  dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
            // dataGridView2.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Naziv";
            dataGridView3.Columns[1].Width = 400;
          //  dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Ukupno";
            dataGridView3.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Uradjeno";
            dataGridView3.Columns[3].Width = 250;
            dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

         
        }

        private void frmManipulacijeGrupno_Load(object sender, EventArgs e)
        {

        }
    }
}
