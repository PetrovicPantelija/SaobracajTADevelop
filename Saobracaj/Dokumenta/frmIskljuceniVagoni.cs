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

using Microsoft.Reporting.WinForms;

namespace Saobracaj.Dokumenta
{
    public partial class frmIskljuceniVagoni : Form
    {
        public static string code = "frmIskljuceniVagoni";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        public frmIskljuceniVagoni()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }

        public string IdGrupe()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            //Sifarnici.frmLogovanje frm = new Sifarnici.frmLogovanje();         
            string query = "Select IdGrupe from KorisnikGrupa Where Korisnik = " + "'" + Kor.TrimEnd() + "'";
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;

            while (dr.Read())
            {
                if (count == 0)
                {
                    niz = dr["IdGrupe"].ToString();
                    count++;
                }
                else
                {
                    niz = niz + "," + dr["IdGrupe"].ToString();
                    count++;
                }

            }
            conn.Close();
            return niz;
        }
        private int IdForme()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            string query = "Select IdForme from Forme where Rtrim(Code)=" + "'" + code + "'";
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idForme = Convert.ToInt32(dr["IdForme"].ToString());
            }
            conn.Close();
            return idForme;
        }

        private void PravoPristupa()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            string query = "Select * From GrupeForme Where IdGrupe in (" + niz + ") and IdForme=" + idForme;
            SqlConnection conn = new SqlConnection(s_connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == false)
            {
                MessageBox.Show("Nemate prava za pristup ovoj formi", code);
                Pravo = false;
            }
            else
            {
                Pravo = true;
                while (reader.Read())
                {
                    insert = Convert.ToBoolean(reader["Upis"]);
                    if (insert == false)
                    {
                       // tsNew.Enabled = false;
                    }
                    update = Convert.ToBoolean(reader["Izmena"]);
                    if (update == false)
                    {
                       // tsSave.Enabled = false;
                    }
                    delete = Convert.ToBoolean(reader["Brisanje"]);
                    if (delete == false)
                    {
                        //tsDelete.Enabled = false;
                    }
                }
            }

            conn.Close();
        }
        private void frmIskljuceniVagoni_Load(object sender, EventArgs e)
        {
            /*
            SELECT      TeretnicaStavke.VRNP, 
                         stanice_3.Opis AS Otpravna, stanice_4.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, TeretnicaStavke.RucKoc
   FROM         TeretnicaIskljuceniVagoni INNER JOIN
                         stanice ON TeretnicaIskljuceniVagoni.StanicaIskljucenja = stanice.ID INNER JOIN
                         TeretnicaStavke ON TeretnicaIskljuceniVagoni.IDTeretnice = TeretnicaStavke.ID INNER JOIN
                         stanice AS stanice_1 ON TeretnicaStavke.Uvrstena = stanice_1.ID INNER JOIN
                         stanice AS stanice_2 ON TeretnicaStavke.Otkacena = stanice_2.ID INNER JOIN
                         stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN
            */


            var select = " SELECT     TeretnicaIskljuceniVagoni.ID, TeretnicaIskljuceniVagoni.IDTeretnice, stanice.Opis, TeretnicaStavke.RB, TeretnicaStavke.BrojTeretnice, TeretnicaStavke.IDNajave, " +
                        " stanice_1.Opis AS Uvrstena, stanice_2.Opis AS Otkacena, TeretnicaStavke.BrojKola, TeretnicaStavke.Serija, TeretnicaStavke.BrojOsovina, TeretnicaStavke.Duzina, " +
                        " TeretnicaStavke.Tara, TeretnicaStavke.Neto, TeretnicaStavke.G, TeretnicaStavke.P, TeretnicaStavke.R, TeretnicaStavke.RR, TeretnicaStavke.VRNP, " +
                        " stanice_3.Opis AS Otpravna, stanice_4.Opis AS Uputna, TeretnicaStavke.Reon, TeretnicaStavke.Primedba, TeretnicaStavke.RucKoc " +
                        " FROM TeretnicaIskljuceniVagoni INNER JOIN " +
                        " stanice ON TeretnicaIskljuceniVagoni.StanicaIskljucenja = stanice.ID INNER JOIN " +
                        " TeretnicaStavke ON TeretnicaIskljuceniVagoni.IDTeretnice = TeretnicaStavke.ID INNER JOIN " +
                        " stanice AS stanice_1 ON TeretnicaStavke.Uvrstena = stanice_1.ID INNER JOIN " +
                        " stanice AS stanice_2 ON TeretnicaStavke.Otkacena = stanice_2.ID INNER JOIN " +
                        " stanice AS stanice_3 ON TeretnicaStavke.Otpravna = stanice_3.ID INNER JOIN " +
                        " stanice AS stanice_4 ON TeretnicaStavke.Uputna = stanice_4.ID";

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
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
            dataGridView3.Columns[0].HeaderText = "Isklj vag ID";
            dataGridView3.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Stavka ID";
            dataGridView3.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Stanica isklj.";
            dataGridView3.Columns[2].Width = 100;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "RB";
            dataGridView3.Columns[3].Width = 30;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Br teretnice";
            dataGridView3.Columns[4].Width = 30;

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Najava ID";
            dataGridView3.Columns[5].Width = 40;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Uvrštena";
            dataGridView3.Columns[6].Width = 100;

            DataGridViewColumn column8 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Otkačena";
            dataGridView3.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Broj kola";
            dataGridView3.Columns[8].Width = 50;

            DataGridViewColumn column10 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "Serija";
            dataGridView3.Columns[9].Width = 50;

            DataGridViewColumn column11 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Broj osovina";
            dataGridView3.Columns[10].Width = 50;

            DataGridViewColumn column12 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Dužina";
            dataGridView3.Columns[11].Width = 50;

            DataGridViewColumn column13 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Tara";
            dataGridView3.Columns[12].Width = 50;

            DataGridViewColumn column14 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "Neto";
            dataGridView3.Columns[13].Width = 50;

            DataGridViewColumn column15 = dataGridView3.Columns[14];
            dataGridView3.Columns[14].HeaderText = "G";
            dataGridView3.Columns[14].Width = 50;

            DataGridViewColumn column16 = dataGridView3.Columns[15];
            dataGridView3.Columns[15].HeaderText = "P";
            dataGridView3.Columns[15].Width = 50;

            DataGridViewColumn column17 = dataGridView3.Columns[16];
            dataGridView3.Columns[16].HeaderText = "R";
            dataGridView3.Columns[16].Width = 50;

            DataGridViewColumn column18 = dataGridView3.Columns[17];
            dataGridView3.Columns[17].HeaderText = "RR";
            dataGridView3.Columns[17].Width = 50;

            DataGridViewColumn column19 = dataGridView3.Columns[18];
            dataGridView3.Columns[18].HeaderText = "Vrs. rob nam pr";
            dataGridView3.Columns[18].Width = 50;

            DataGridViewColumn column20 = dataGridView3.Columns[19];
            dataGridView3.Columns[19].HeaderText = "Otpravna";
            dataGridView3.Columns[19].Width = 100;

            DataGridViewColumn column21 = dataGridView3.Columns[20];
            dataGridView3.Columns[20].HeaderText = "Uputna";
            dataGridView3.Columns[20].Width = 100;

            DataGridViewColumn column22 = dataGridView3.Columns[21];
            dataGridView3.Columns[21].HeaderText = "Reon";
            dataGridView3.Columns[21].Width = 70;
        }
    }
}
