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
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms;

using MetroFramework.Forms;

namespace Saobracaj.Testiranje
{
    public partial class Pitanja : Form
    {
        bool status = false;
        public Pitanja()
        {
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "Pitanja";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
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
        private void GrupeTestova()
        {
            var select = "  SELECT ID, Naziv,Datum, BrojTacnih,BrResenja, Mesto, Komisija1,Komisija2,komisija3 from testovi ";


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
            dataGridView1.Columns[0].Width = 25;

            DataGridViewColumn column2 = dataGridView1.Columns[1];
            dataGridView1.Columns[1].HeaderText = "Naziv testa";
            dataGridView1.Columns[1].Width = 305;

            DataGridViewColumn column3 = dataGridView1.Columns[2];
            dataGridView1.Columns[2].HeaderText = "Datum";
            dataGridView1.Columns[2].Width = 80;

            DataGridViewColumn column4 = dataGridView1.Columns[3];
            dataGridView1.Columns[3].HeaderText = "Potrebno tačnih";
            dataGridView1.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView1.Columns[4];
            dataGridView1.Columns[4].HeaderText = "Br rešenja";
            dataGridView1.Columns[4].Width = 80;

            DataGridViewColumn column6 = dataGridView1.Columns[5];
            dataGridView1.Columns[5].HeaderText = "Mesto";
            dataGridView1.Columns[5].Width = 80;

            DataGridViewColumn column7 = dataGridView1.Columns[6];
            dataGridView1.Columns[6].HeaderText = "Komisija 1";
            dataGridView1.Columns[6].Width = 40;

            DataGridViewColumn column8 = dataGridView1.Columns[7];
            dataGridView1.Columns[7].HeaderText = "Komisija 2";
            dataGridView1.Columns[7].Width = 40;

            DataGridViewColumn column9 = dataGridView1.Columns[8];
            dataGridView1.Columns[8].HeaderText = "Komisija 3";
            dataGridView1.Columns[8].Width = 40;

        }

        private void RefreshOdgovori()
        {
           
            var select = "   SELECT ID, [IDNadredjenog] ,[Opis] ,[RBBroj] FROM [TESTIRANJE].[dbo].[TestoviPitanjaOdgovor] where IDNadredjenog =  " + Convert.ToInt32(txtIDStavke.Text);

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView3.ReadOnly = true;
            dataGridView3.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView3.Columns[0];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[0].Width = 45;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "Nadr";
            dataGridView3.Columns[1].Width = 45;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Odgovor";
            dataGridView3.Columns[2].Width = 125;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Broj";
            dataGridView3.Columns[3].Width = 75;

        }

        private void GrupeTestovaPitanja()
        {
            var select = "  SELECT * from testovipitanja where IdStavke =  " + Convert.ToInt32(txtSifra.Text);


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = ds.Tables[0];

            DataGridViewColumn column = dataGridView2.Columns[0];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[0].Width = 45;

            DataGridViewColumn column2 = dataGridView2.Columns[1];
            dataGridView2.Columns[1].HeaderText = "Nadr";
            dataGridView2.Columns[1].Width = 45;

            DataGridViewColumn column3 = dataGridView2.Columns[2];
            dataGridView2.Columns[2].HeaderText = "Pitanje";
            dataGridView2.Columns[2].Width = 625;

            DataGridViewColumn column4 = dataGridView2.Columns[3];
            dataGridView2.Columns[3].HeaderText = "Tacno";
            dataGridView2.Columns[3].Width = 75;


        }

        private void Pitanja_Load(object sender, EventArgs e)
        {
            GrupeTestova();

            var select3 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci order by opis";
            var s_connection3 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection3 = new SqlConnection(s_connection3);
            var c3 = new SqlConnection(s_connection3);
            var dataAdapter3 = new SqlDataAdapter(select3, c3);

            var commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
            var ds3 = new DataSet();
            dataAdapter3.Fill(ds3);
            cboClanKomisije1.DataSource = ds3.Tables[0];
            cboClanKomisije1.DisplayMember = "Opis";
            cboClanKomisije1.ValueMember = "ID";


            var select4 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci order by opis";
            var s_connection4 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection4 = new SqlConnection(s_connection4);
            var c4 = new SqlConnection(s_connection4);
            var dataAdapter4 = new SqlDataAdapter(select4, c4);

            var commandBuilder4 = new SqlCommandBuilder(dataAdapter4);
            var ds4 = new DataSet();
            dataAdapter4.Fill(ds4);
            cboClanKomisije2.DataSource = ds4.Tables[0];
            cboClanKomisije2.DisplayMember = "Opis";
            cboClanKomisije2.ValueMember = "ID";

            var select5 = " select DeSifra as ID, (Rtrim(DePriimek) + ' ' + RTrim(DeIme)) as Opis from Delavci order by opis";
            var s_connection5 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection5 = new SqlConnection(s_connection5);
            var c5 = new SqlConnection(s_connection5);
            var dataAdapter5 = new SqlDataAdapter(select5, c5);

            var commandBuilder5 = new SqlCommandBuilder(dataAdapter5);
            var ds5 = new DataSet();
            dataAdapter5.Fill(ds5);
            cboClanKomisije3.DataSource = ds5.Tables[0];
            cboClanKomisije3.DisplayMember = "Opis";
            cboClanKomisije3.ValueMember = "ID";

        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            txtSifra.Text = "";
            txtSifra.Enabled = false;
            status = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        {

            Testiranje.InsertTestovi ins = new Testiranje.InsertTestovi();
            if (status == true)
            {
                ins.InsTestovi(txtNaziv.Text, Convert.ToDateTime(dtpDatumTesta.Value), Convert.ToInt32(txtBrojTacnih.Value), txtBrojRegistratora.Text, txtMesto.Text, Convert.ToInt32(cboClanKomisije1.SelectedValue), Convert.ToInt32(cboClanKomisije2.SelectedValue), Convert.ToInt32(cboClanKomisije3.SelectedValue));
                GrupeTestova();
            }
            else
            {
                ins.UpdTestovi(Convert.ToInt32(txtSifra.Text), txtNaziv.Text, Convert.ToDateTime(dtpDatumTesta.Value), Convert.ToInt32(txtBrojTacnih.Value), txtBrojRegistratora.Text, txtMesto.Text, Convert.ToInt32(cboClanKomisije1.SelectedValue), Convert.ToInt32(cboClanKomisije2.SelectedValue), Convert.ToInt32(cboClanKomisije3.SelectedValue));
                GrupeTestova();
            }
        }

        private void btnUnesiTrasa_Click(object sender, EventArgs e)
        {
            int Tacno = 0;
            Tehnologija.InsertTestoviPitanja ins = new Tehnologija.InsertTestoviPitanja();
           /*
            if (chkTacno.Checked == true)
            {
                Tacno = 1;
            
            }
           */
                ins.InsTestoviPitanja(Convert.ToInt32(txtSifra.Text), txtPitanje.Text, Convert.ToInt32(txtIspravanOdgovor.Text));
            GrupeTestovaPitanja();
        }

        private void sfButton5_Click(object sender, EventArgs e)
        {
            int Tacno = 0;
            Tehnologija.InsertTestoviPitanja upd = new Tehnologija.InsertTestoviPitanja();
            /*
            if (chkTacno.Checked == true)
            {
                Tacno = 1;

            }
            */
            upd.UpdTestoviPitanja(Convert.ToInt32(txtIDStavke.Text),Convert.ToInt32(txtSifra.Text), txtPitanje.Text,  Convert.ToInt32(txtIspravanOdgovor.Text));
            GrupeTestovaPitanja();
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
                        txtNaziv.Text = row.Cells[1].Value.ToString();
                        dtpDatumTesta.Value  = Convert.ToDateTime(row.Cells[2].Value.ToString());
                        txtBrojTacnih.Value = Convert.ToInt32(row.Cells[3].Value.ToString());
                        txtBrojRegistratora.Text = row.Cells[4].Value.ToString();
                        txtMesto.Text = row.Cells[5].Value.ToString();
                        cboClanKomisije1.SelectedValue = Convert.ToInt32(row.Cells[6].Value.ToString());
                        cboClanKomisije2.SelectedValue = Convert.ToInt32(row.Cells[7].Value.ToString());
                        cboClanKomisije3.SelectedValue = Convert.ToInt32(row.Cells[8].Value.ToString());
                        GrupeTestovaPitanja();
                       
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Selected)
                    {
                        txtIDStavke.Text = row.Cells[0].Value.ToString();
                        txtPitanje.Text = row.Cells[2].Value.ToString();
                        txtIspravanOdgovor.Text = row.Cells[3].Value.ToString();
                        RefreshOdgovori();
                        /*
                          if (row.Cells[3].Value.ToString() == "1")
                          {
                              chkTacno.Checked = true;
                          }
                          else
                          {
                              chkTacno.Checked = false;
                          }
                        */
                        // VratiPodatke(txtSifra.Text);
                        // txtOpis.Text = row.Cells[1].Value.ToString();
                    }
                }


            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void btnIzbaciTrasa_Click(object sender, EventArgs e)
        {
            Tehnologija.InsertTestoviPitanja upd = new Tehnologija.InsertTestoviPitanja();
            upd.DeleteTestoviPitanja(Convert.ToInt32(txtIDStavke.Text));
            GrupeTestovaPitanja();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            Testiranje.InsertTestovi upd = new Testiranje.InsertTestovi();
            upd.DeleteTehnologija(Convert.ToInt32(txtIDStavke.Text));
            GrupeTestova();
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            Testiranje.InsertTestovi ins = new Testiranje.InsertTestovi();
            ins.InsTestoviOdgovori(Convert.ToInt32(txtIDStavke.Text), txtOdgovor.Text, Convert.ToInt32(txtOdgovorBroj.Text));
            RefreshOdgovori();
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            Testiranje.InsertTestovi ins = new Testiranje.InsertTestovi();
            ins.DelTestoviOdgovori(Convert.ToInt32(txtIDOdgovor.Text));
            RefreshOdgovori();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        txtIDOdgovor.Text = row.Cells[0].Value.ToString();
                        txtOdgovor.Text = row.Cells[2].Value.ToString();
                        txtOdgovorBroj.Text = row.Cells[3].Value.ToString();
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
