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
using System.Globalization;

namespace Testiranje
{
    public partial class frmLogovanje : Form
    {

        public frmLogovanje()
        {
            InitializeComponent();
        }

        private void frmLogovanje_Load(object sender, EventArgs e)
        {
            var select = " Select Distinct RTrim(Korisnik) as Korisnik From Korisnici";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            cboKorisnik.DataSource = ds.Tables[0];
            cboKorisnik.DisplayMember = "Korisnik";
            cboKorisnik.ValueMember = "Korisnik";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // var select = " Select Distinct DatumUtovara From RkShipping where Stanje = 1 and Vozilo = '" + cboVozila.Text + "'";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            SqlCommand command = new SqlCommand("SELECT Korisnik FROM Korisnici where Password = '" + txtPassword.Text + "'", myConnection);
            myConnection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows == false)
            {
                MessageBox.Show("Nije ispravno uneta lozinka");
                return;
            }
            else
            {
                while (reader.Read())
                {
                   
                    string myString = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                    // Do somthing with this rows string, for example to put them in to a list
                    if (myString.TrimEnd() == cboKorisnik.Text.TrimEnd())
                    {
                       // Main mainf = new Main(cboKorisnik.Text.TrimEnd(), 1);
                        //mainf.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nije ispravno uneta lozinka");
                        return;
                    }
                }
            }
           
        }

        private void frmLogovanje_Enter(object sender, EventArgs e)
        {
            // var select = " Select Distinct DatumUtovara From RkShipping where Stanje = 1 and Vozilo = '" + cboVozila.Text + "'";
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            SqlCommand command = new SqlCommand("SELECT Korisnik FROM Korisnici where Password = '" + txtPassword.Text + "'", myConnection);
            myConnection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows == false)
            {
                MessageBox.Show("Nije ispravno uneta lozinka");
                return;
            }
            while (reader.Read())
            {
                string myString = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                // Do somthing with this rows string, for example to put them in to a list
                if (myString.TrimEnd() == cboKorisnik.Text.TrimEnd())
                {
                 //   Main mainf = new Main(cboKorisnik.Text.TrimEnd(), 1);
                  //  mainf.Show();
                }
                else
                {
                    MessageBox.Show("Nije ispravno uneta lozinka");
                    return;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}