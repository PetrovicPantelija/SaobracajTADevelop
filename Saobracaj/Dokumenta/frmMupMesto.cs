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
    public partial class frmMupMesto : Form
    {
        bool status = false;
        public static string code = "frmMupMesto";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";

        public frmMupMesto()
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
                        tsNew.Enabled = false;
                    }
                    update = Convert.ToBoolean(reader["Izmena"]);
                    if (update == false)
                    {
                        tsSave.Enabled = false;
                    }
                    delete = Convert.ToBoolean(reader["Brisanje"]);
                    if (delete == false)
                    {
                        tsDelete.Enabled = false;
                    }
                }
            }

            conn.Close();
        }
        private void tsNew_Click(object sender, EventArgs e)
        {
            status = true;
            txtSifra.Enabled = false;
            txtSifra.Text = "";
            txtAdresa.Text = "";
           
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            int Stan = 0;
            if (chkStan.Checked)
            {
                Stan = 1;
            }
            else
            {
                Stan = 0;
            }

            if (status == true)
            {
                InsertMUPMesto ins = new InsertMUPMesto();
                if (Stan == 1)
                {
                    //Unos stana
                    ins.InsMUPMesto(0, "",txtAdresa.Text, Stan);
                    status = false;
                }
                else
                {
                    ins.InsMUPMesto(Convert.ToInt32(cboZaposleni.SelectedValue), txtAdresa.Text, "", Stan);
                    status = false;
                }
               
            }
            else
            {
               
                InsertMUPMesto upd = new InsertMUPMesto();
                if (Stan == 1)
                {
                    //Unos stana
                    upd.UpdMUPMesto(Convert.ToInt32(txtSifra.Text),0, "", txtAdresa.Text, Stan);
                    status = false;
                }
                else
                {
                    upd.UpdMUPMesto(Convert.ToInt32(txtSifra.Text), Convert.ToInt32(cboZaposleni.SelectedValue), txtAdresa.Text, "", Stan);
                    status = false;
                }
            }
            VratiPodatkeMax();
            RefreshDataGRid();
        }

        private void VratiPodatkeMax()
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select Max([ID]) as ID from MUPMesto", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtSifra.Text = dr["ID"].ToString();
            }

            con.Close();
        }

        private void frmMupMesto_Load(object sender, EventArgs e)
        {
            RefreshDataGRid();
        }

        private void RefreshDataGRid()
        {
            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci order by opis";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboZaposleni.DataSource = ds3.Tables[0];
            cboZaposleni.DisplayMember = "Opis";
            cboZaposleni.ValueMember = "ID";



            var select = "  select MUPMesto.ID as ID, MUPMesto.Zaposleni, " +
            " Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme) as ZaposleniNaziv, " +
            " MUPMesto.AdresaStanovanja, MUPMesto.AdresaStana, MUPMesto.Stan from MUPMesto " +
            " inner join Delavci on Delavci.DeSifra = MUPMesto.Zaposleni " +
            " where Stan = 0 " +
            " union " +
            " select MUPMesto.ID as ID,'' as Zaposleni," +
            " '' as ZaposleniNaziv, " +
            " MUPMesto.AdresaStanovanja, MUPMesto.AdresaStana, MUPMesto.Stan from MUPMesto " +
            " where Stan = 1 ";

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
            dataGridView1.Columns[0].HeaderText = "Šifra";
            dataGridView1.Columns[0].Width = 50;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Zaposleni ID";
            dataGridView1.Columns[1].Width = 50;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Zaposleni naziv";
            dataGridView1.Columns[2].Width = 150;


            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Adresa stanovanja";
            dataGridView1.Columns[3].Width = 250;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Adresa Stana";
            dataGridView1.Columns[4].Width = 250;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Stan";
            dataGridView1.Columns[5].Width = 50;

        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            InsertAutomobili ins = new InsertAutomobili();
            ins.DeleteAutomobili(Convert.ToInt32(txtSifra.Text));
            status = false;
        }

        private void VratiPodatke(string ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);

            con.Open();

            SqlCommand cmd = new SqlCommand("select ID, Zaposleni, AdresaStanovanja,AdresaStana, Stan from MUPMesto where ID=" + txtSifra.Text, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Stan"].ToString() == "1")
                {
                    chkStan.Checked = true;
                    cboZaposleni.SelectedValue = 0;
                    txtAdresa.Text = dr["AdresaStana"].ToString();
                }
                else
                {
                    chkStan.Checked = false;
                    cboZaposleni.SelectedValue = Convert.ToInt32(dr["Zaposleni"].ToString());
                    txtAdresa.Text = dr["AdresaStanovanja"].ToString();
                }

                cboZaposleni.SelectedValue = Convert.ToInt32(dr["Zaposleni"].ToString());

            }

            con.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        txtSifra.Text = row.Cells[0].Value.ToString();
                        VratiPodatke(txtSifra.Text);
                       
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }


    }
}
