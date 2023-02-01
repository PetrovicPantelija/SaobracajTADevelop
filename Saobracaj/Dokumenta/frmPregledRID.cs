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
    public partial class frmPregledRID : Form
    {
        public static string code = "frmPregledRID";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        public frmPregledRID()
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
                      //  tsNew.Enabled = false;
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
        private void button4_Click(object sender, EventArgs e)
        {
           
            string VremeOD = "";
            string VremeDO = "";
            VremeOD = dtpPredvidjenoPrimanje.Value.Month.ToString() + "-" + dtpPredvidjenoPrimanje.Value.Day + "-" + dtpPredvidjenoPrimanje.Value.Year;
            VremeDO = dtpStvarnoPrimanje.Value.Month.ToString() + "-" + dtpStvarnoPrimanje.Value.Day + "-" + dtpStvarnoPrimanje.Value.Year;

            var select = "  select  t2.[RID] as BrojRID, t2.IDNajave ,  " +
           " t2.ID as Teretnica, t2.RB, " + 
            " t2.BrojKola,  t2.Neto  , " +
           " t2.Tara, t2.Duzina " + 
           "  from TeretnicaStavke t2 inner join Najava as t1 on t2.IDNajave = t1.Id " +
             " where t1.PredvidjenaPredaja>  '" + VremeOD + "' and t1.StvarnoPrimanje <'" + VremeDO +  
             " ' and t2.RID is not null  order by t2.IDNajave, t2.ID, t2.RB ";
    

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);
            
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];




            ///Iskljuceni vagoni
          
            var select2 = "  select  t2.[RID] as BrojRID, t2.IDNajave ,  " +
           " t2.ID as Teretnica, t2.RB, " +
            " t2.BrojKola,  t2.Neto  , " +
           " t2.Tara, t2.Duzina " +
           "  from TeretnicaStavke t2 inner join Najava as t1 on t2.IDNajave = t1.Id " +
           " inner join TeretnicaIskljuceniVagoni on t2.ID = TeretnicaIskljuceniVagoni.IdTeretnice" +
             " where t1.PredvidjenaPredaja>  '" + VremeOD + "' and t1.StvarnoPrimanje <'" + VremeDO +
             " ' and t2.RID is not null  order by t2.IDNajave, t2.ID, t2.RB ";


            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds2.Tables[0];


            /*
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "RB";
            dataGridView1.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "IDNajave";
            dataGridView1.Columns[2].Width = 40;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Uvrštena";
            dataGridView1.Columns[3].Width = 100;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Otkačena";
            dataGridView1.Columns[4].Width = 100;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Broj Kola";
            dataGridView1.Columns[5].Width = 100;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Serija";
            dataGridView1.Columns[6].Width = 20;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Br. osovina";
            dataGridView1.Columns[7].Width = 30;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Dužina";
            dataGridView1.Columns[8].Width = 30;

            DataGridViewColumn column10 = dataGridView1.Columns[9];
            dataGridView1.Columns[9].HeaderText = "Tara";
            dataGridView1.Columns[9].Width = 30;

            DataGridViewColumn column11 = dataGridView1.Columns[10];
            dataGridView1.Columns[10].HeaderText = "Neto";
            dataGridView1.Columns[10].Width = 30;

            DataGridViewColumn column12 = dataGridView1.Columns[11];
            dataGridView1.Columns[11].HeaderText = "G";
            dataGridView1.Columns[11].Width = 30;

            DataGridViewColumn column13 = dataGridView1.Columns[12];
            dataGridView1.Columns[12].HeaderText = "P";
            dataGridView1.Columns[12].Width = 30;

            DataGridViewColumn column14 = dataGridView1.Columns[13];
            dataGridView1.Columns[13].HeaderText = "R";
            dataGridView1.Columns[13].Width = 30;

            DataGridViewColumn column15 = dataGridView1.Columns[14];
            dataGridView1.Columns[14].HeaderText = "RR";
            dataGridView1.Columns[14].Width = 30;

            DataGridViewColumn column16 = dataGridView1.Columns[15];
            dataGridView1.Columns[15].HeaderText = "VRNP";
            dataGridView1.Columns[15].Width = 30;

            DataGridViewColumn column17 = dataGridView1.Columns[16];
            dataGridView1.Columns[16].HeaderText = "Otpravna";
            dataGridView1.Columns[16].Width = 100;

            DataGridViewColumn column18 = dataGridView1.Columns[17];
            dataGridView1.Columns[17].HeaderText = "Uputna";
            dataGridView1.Columns[17].Width = 100;

            DataGridViewColumn column19 = dataGridView1.Columns[18];
            dataGridView1.Columns[18].HeaderText = "Reon";
            dataGridView1.Columns[18].Width = 70;

            DataGridViewColumn column20 = dataGridView1.Columns[19];
            dataGridView1.Columns[19].HeaderText = "Primedba";
            dataGridView1.Columns[19].Width = 70;

            DataGridViewColumn column21 = dataGridView1.Columns[20];
            dataGridView1.Columns[20].HeaderText = "Ruč. koč";
            dataGridView1.Columns[20].Width = 70;

            DataGridViewColumn column22 = dataGridView1.Columns[21];
            dataGridView1.Columns[21].HeaderText = "RID";
            dataGridView1.Columns[21].Width = 70;
      */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string VremeOD = "";
            string VremeDO = "";
            VremeOD = dtpPredvidjenoPrimanje.Value.Month.ToString() + "-" + dtpPredvidjenoPrimanje.Value.Day + "-" + dtpPredvidjenoPrimanje.Value.Year;
            VremeDO = dtpStvarnoPrimanje.Value.Month.ToString() + "-" + dtpStvarnoPrimanje.Value.Day + "-" + dtpStvarnoPrimanje.Value.Year;

            var select = "  select  t2.[RID] as BrojRID, t2.IDNajave ,  " +
           " t2.ID as Teretnica, t2.RB, " +
            " t2.BrojKola,  t2.Neto  , " +
           " t2.Tara, t2.Duzina " +
           "  from TeretnicaStavke t2 inner join Najava as t1 on t2.IDNajave = t1.Id " +
             " Where t2.RID = " + cboRID.Text + "  order by t2.IDNajave, t2.ID, t2.RB ";


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            var select2 = "  select  t2.[RID] as BrojRID, t2.IDNajave ,  " +
           " t2.ID as Teretnica, t2.RB, " +
           " t2.BrojKola,  t2.Neto  , " +
           " t2.Tara, t2.Duzina " +
           "  from TeretnicaStavke t2 inner join Najava as t1 on t2.IDNajave = t1.Id " +
           " inner join TeretnicaIskljuceniVagoni on t2.ID = TeretnicaIskljuceniVagoni.IdTeretnice" +
           " Where t2.RID = " + cboRID.Text + "  order by t2.IDNajave, t2.ID, t2.RB ";

            var s_connection2 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection2 = new SqlConnection(s_connection2);
            var c2 = new SqlConnection(s_connection2);
            var dataAdapter2 = new SqlDataAdapter(select2, c2);

            var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
            var ds2 = new DataSet();
            dataAdapter2.Fill(ds2);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds2.Tables[0];
        }

    }
}
