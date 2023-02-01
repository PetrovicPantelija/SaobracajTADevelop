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

namespace Testiranje
{
    public partial class frmManipulacijeFilter : Form
    {
        public frmManipulacijeFilter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var select = "    select  NaruceneManipulacije.IDPrijemaVoza, NaruceneManipulacije.BrojKontejnera, VrstaManipulacije.ID, VrstaManipulacije.Naziv, " +
" CASE WHEN NaruceneManipulacije.Uradjeno > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as Uradjeno, " +
"  NaruceneManipulacije.DatumOd,NaruceneManipulacije.DatumDo, NaruceneManipulacije.Datum, NaruceneManipulacije.Korisnik,  NaruceneManipulacije.ID, NaruceneManipulacije.Broj from NaruceneManipulacije " +
" inner join VrstaManipulacije on NaruceneManipulacije.VrstaManipulacije = VrstaManipulacije.ID " +
" inner join Komitenti on NaruceneManipulacije.Platilac = Komitenti.ID " +
" where NaruceneManipulacije.Platilac =  " + Convert.ToInt32(cboPlatilac.SelectedValue) + " and DatumUradjeno >=  " + dtpVremeOd.Value + " and   DatumUradjeno<= " + dtpVremeDo.Value;

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = false;
            dataGridView3.DataSource = ds.Tables[0];



            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "Prijem";
            dataGridView3.Columns[0].Width = 40;
            dataGridView3.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
            // dataGridView2.Columns[0].Visible = false;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Broj kontejnera";
            dataGridView3.Columns[1].Width = 100;
            dataGridView3.Columns[1].DefaultCellStyle.BackColor = Color.LightSeaGreen;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Man ID";
            dataGridView3.Columns[2].Width = 50;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Manipulacija";
            dataGridView3.Columns[3].Width = 250;
            dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.LightYellow;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Urađeno";
            dataGridView3.Columns[4].Width = 50;

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Datum od";
            dataGridView3.Columns[5].Width = 150;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Datum do";
            dataGridView3.Columns[6].Width = 150;

            DataGridViewColumn column8 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Datum";
            dataGridView3.Columns[7].Width = 80;

            DataGridViewColumn column9 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Korisnik";
            dataGridView3.Columns[8].Width = 80;

            DataGridViewColumn column10 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "ID";
            dataGridView3.Columns[9].Width = 70;

            DataGridViewColumn column11 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Broj";
            dataGridView3.Columns[10].Width = 70;
            dataGridView3.Columns[10].DefaultCellStyle.BackColor = Color.LightSeaGreen;

            DataGridViewColumn column12 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Datum urađeno";
            dataGridView3.Columns[11].Width = 80;
        }
    }
}
