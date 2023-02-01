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
    public partial class frmRaspustiVagone : Form
    {
        public static string code = "frmRaspustiVagone";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        public frmRaspustiVagone()
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
                        //tsNew.Enabled = false;
                    }
                    update = Convert.ToBoolean(reader["Izmena"]);
                    if (update == false)
                    {
                        //tsSave.Enabled = false;
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
        private void frmRaspustiVagone_Load(object sender, EventArgs e)
        {
            var select7 = " Select ID  from RadniNalog where StatusRN in ('PL','OD', 'LA') ";
            var s_connection7 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection7 = new SqlConnection(s_connection7);
            var c7 = new SqlConnection(s_connection7);
            var dataAdapter7 = new SqlDataAdapter(select7, c7);

            var commandBuilder7 = new SqlCommandBuilder(dataAdapter7);
            var ds7 = new DataSet();
            dataAdapter7.Fill(ds7);
            cboRadniNalog.DataSource = ds7.Tables[0];
            cboRadniNalog.DisplayMember = "ID";
            cboRadniNalog.ValueMember = "ID";

            var select6 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection6 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection6 = new SqlConnection(s_connection6);
            var c6 = new SqlConnection(s_connection6);
            var dataAdapter6 = new SqlDataAdapter(select6, c6);

            var commandBuilder6 = new SqlCommandBuilder(dataAdapter6);
            var ds6 = new DataSet();
            dataAdapter6.Fill(ds6);
            cboStanicaIsklj.DataSource = ds6.Tables[0];
            cboStanicaIsklj.DisplayMember = "Stanica";
            cboStanicaIsklj.ValueMember = "ID";


            var select8 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection8 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection8 = new SqlConnection(s_connection8);
            var c8 = new SqlConnection(s_connection8);
            var dataAdapter8 = new SqlDataAdapter(select8, c8);

            var commandBuilder8 = new SqlCommandBuilder(dataAdapter8);
            var ds8 = new DataSet();
            dataAdapter8.Fill(ds8);
            cboStanicaOd.DataSource = ds8.Tables[0];
            cboStanicaOd.DisplayMember = "Stanica";
            cboStanicaOd.ValueMember = "ID";

            var select9 = " Select ID, RTrim(Opis) as Stanica From Stanice order by opis";
            var s_connection9 = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection9 = new SqlConnection(s_connection8);
            var c9 = new SqlConnection(s_connection9);
            var dataAdapter9 = new SqlDataAdapter(select9, c9);

            var commandBuilder9 = new SqlCommandBuilder(dataAdapter9);
            var ds9 = new DataSet();
            dataAdapter9.Fill(ds9);
            cboStanicaDo.DataSource = ds9.Tables[0];
            cboStanicaDo.DisplayMember = "Stanica";
            cboStanicaDo.ValueMember = "ID";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var select = " Select TIV.IDTeretnice, TIV.RN, TIV.StatusVagona, " +
            " ts.BrojTeretnice, TS.IDNajave, stanice_3.Opis as Otpravna, stanice_2.Opis as Uputna, ts.BrojKola, ts.Serija, ts.BrojOsovina, ts.Duzina, " +
            " ts.Tara, ts.Neto, ts.G, ts.P, ts.R, ts.RR, ts.Reon, ts.VRNP, ts.RID, ts.Primedba, ts.RucKoc " +
            " from TeretnicaIskljuceniVagoni TIV " +
            " inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id " +
             " inner join stanice AS stanice_3 ON ts.Otpravna = stanice_3.ID INNER JOIN " +
            " stanice AS stanice_2 ON ts.Uputna = stanice_2.ID " +
            " where TIV.RN = " + Convert.ToInt32(cboRadniNalog.SelectedValue) + " and TIV.StatusVagona in (2)";

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
            dataGridView3.Columns[0].HeaderText = "ID Teretnice";
            dataGridView3.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "RN";
            dataGridView3.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Status Vagona";
            dataGridView3.Columns[2].Width = 120;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Prijemna teretnica";
            dataGridView3.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Najava";
            dataGridView3.Columns[4].Width = 40;

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Otpravna";
            dataGridView3.Columns[5].Width = 120;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Uputna";
            dataGridView3.Columns[6].Width = 120;

            DataGridViewColumn column8 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Broj kola";
            dataGridView3.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Serija";
            dataGridView3.Columns[8].Width = 40;

            DataGridViewColumn column10 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "Broj osovina";
            dataGridView3.Columns[9].Width = 40;

            DataGridViewColumn column11 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Dužina";
            dataGridView3.Columns[10].Width = 60;

            DataGridViewColumn column12 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Tara";
            dataGridView3.Columns[11].Width = 60;

            DataGridViewColumn column13 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Neto";
            dataGridView3.Columns[12].Width = 60;

            DataGridViewColumn column14 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "G";
            dataGridView3.Columns[13].Width = 30;

            DataGridViewColumn column15 = dataGridView3.Columns[14];
            dataGridView3.Columns[14].HeaderText = "P";
            dataGridView3.Columns[14].Width = 30;

            DataGridViewColumn column16 = dataGridView3.Columns[15];
            dataGridView3.Columns[15].HeaderText = "R";
            dataGridView3.Columns[15].Width = 30;

            DataGridViewColumn column17 = dataGridView3.Columns[16];
            dataGridView3.Columns[16].HeaderText = "RR";
            dataGridView3.Columns[16].Width = 30;

            DataGridViewColumn column18 = dataGridView3.Columns[17];
            dataGridView3.Columns[17].HeaderText = "Reon";
            dataGridView3.Columns[17].Width = 60;

            DataGridViewColumn column19 = dataGridView3.Columns[18];
            dataGridView3.Columns[18].HeaderText = "VRNR";
            dataGridView3.Columns[18].Width = 60;

            DataGridViewColumn column20 = dataGridView3.Columns[19];
            dataGridView3.Columns[19].HeaderText = "RID";
            dataGridView3.Columns[19].Width = 60;

            DataGridViewColumn column21 = dataGridView3.Columns[20];
            dataGridView3.Columns[20].HeaderText = "Primedba";
            dataGridView3.Columns[20].Width = 60;

            DataGridViewColumn column22 = dataGridView3.Columns[21];
            dataGridView3.Columns[21].HeaderText = "Ruč koč";
            dataGridView3.Columns[21].Width = 60;
        }

        private void RefreshDataGrid()
        {
            var select = " Select TIV.IDTeretnice, TIV.RN, TIV.StatusVagona, " +
              " ts.BrojTeretnice, TS.IDNajave, stanice_3.Opis as Otpravna, stanice_2.Opis as Uputna, ts.BrojKola, ts.Serija, ts.BrojOsovina, ts.Duzina, " +
              " ts.Tara, ts.Neto, ts.G, ts.P, ts.R, ts.RR, ts.Reon, ts.VRNP, ts.RID, ts.Primedba, ts.RucKoc " +
              " from TeretnicaIskljuceniVagoni TIV " +
              " inner join TeretnicaStavke ts on TIV.IDTeretnice = ts.id " +
               " inner join stanice AS stanice_3 ON ts.Otpravna = stanice_3.ID INNER JOIN " +
              " stanice AS stanice_2 ON ts.Uputna = stanice_2.ID " +
              " where TIV.RN = " + Convert.ToInt32(cboRadniNalog.SelectedValue) + " and TIV.StatusVagona in (2)";

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
            dataGridView3.Columns[0].HeaderText = "ID Teretnice";
            dataGridView3.Columns[0].Width = 40;

            DataGridViewColumn column2 = dataGridView3.Columns[1];
            dataGridView3.Columns[1].HeaderText = "RN";
            dataGridView3.Columns[1].Width = 40;

            DataGridViewColumn column3 = dataGridView3.Columns[2];
            dataGridView3.Columns[2].HeaderText = "Status Vagona";
            dataGridView3.Columns[2].Width = 120;

            DataGridViewColumn column4 = dataGridView3.Columns[3];
            dataGridView3.Columns[3].HeaderText = "Prijemna teretnica";
            dataGridView3.Columns[3].Width = 40;

            DataGridViewColumn column5 = dataGridView3.Columns[4];
            dataGridView3.Columns[4].HeaderText = "Najava";
            dataGridView3.Columns[4].Width = 40;

            DataGridViewColumn column6 = dataGridView3.Columns[5];
            dataGridView3.Columns[5].HeaderText = "Otpravna";
            dataGridView3.Columns[5].Width = 120;

            DataGridViewColumn column7 = dataGridView3.Columns[6];
            dataGridView3.Columns[6].HeaderText = "Uputna";
            dataGridView3.Columns[6].Width = 120;

            DataGridViewColumn column8 = dataGridView3.Columns[7];
            dataGridView3.Columns[7].HeaderText = "Broj kola";
            dataGridView3.Columns[7].Width = 100;

            DataGridViewColumn column9 = dataGridView3.Columns[8];
            dataGridView3.Columns[8].HeaderText = "Serija";
            dataGridView3.Columns[8].Width = 40;

            DataGridViewColumn column10 = dataGridView3.Columns[9];
            dataGridView3.Columns[9].HeaderText = "Broj osovina";
            dataGridView3.Columns[9].Width = 40;

            DataGridViewColumn column11 = dataGridView3.Columns[10];
            dataGridView3.Columns[10].HeaderText = "Dužina";
            dataGridView3.Columns[10].Width = 60;

            DataGridViewColumn column12 = dataGridView3.Columns[11];
            dataGridView3.Columns[11].HeaderText = "Tara";
            dataGridView3.Columns[11].Width = 60;

            DataGridViewColumn column13 = dataGridView3.Columns[12];
            dataGridView3.Columns[12].HeaderText = "Neto";
            dataGridView3.Columns[12].Width = 60;

            DataGridViewColumn column14 = dataGridView3.Columns[13];
            dataGridView3.Columns[13].HeaderText = "G";
            dataGridView3.Columns[13].Width = 30;

            DataGridViewColumn column15 = dataGridView3.Columns[14];
            dataGridView3.Columns[14].HeaderText = "P";
            dataGridView3.Columns[14].Width = 30;

            DataGridViewColumn column16 = dataGridView3.Columns[15];
            dataGridView3.Columns[15].HeaderText = "R";
            dataGridView3.Columns[15].Width = 30;

            DataGridViewColumn column17 = dataGridView3.Columns[16];
            dataGridView3.Columns[16].HeaderText = "RR";
            dataGridView3.Columns[16].Width = 30;

            DataGridViewColumn column18 = dataGridView3.Columns[17];
            dataGridView3.Columns[17].HeaderText = "Reon";
            dataGridView3.Columns[17].Width = 60;

            DataGridViewColumn column19 = dataGridView3.Columns[18];
            dataGridView3.Columns[18].HeaderText = "VRNR";
            dataGridView3.Columns[18].Width = 60;

            DataGridViewColumn column20 = dataGridView3.Columns[19];
            dataGridView3.Columns[19].HeaderText = "RID";
            dataGridView3.Columns[19].Width = 60;

            DataGridViewColumn column21 = dataGridView3.Columns[20];
            dataGridView3.Columns[20].HeaderText = "Primedba";
            dataGridView3.Columns[20].Width = 60;

            DataGridViewColumn column22 = dataGridView3.Columns[21];
            dataGridView3.Columns[21].HeaderText = "Ruč koč";
            dataGridView3.Columns[21].Width = 60;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Dokumenta.InsertTeretnica it = new Dokumenta.InsertTeretnica();
               // it.InsTeretnica("", Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToInt32(cboStanicaIsklj.SelectedValue), Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeOd.Value), "", 0, 1, "sa", 0, Convert.ToInt32(cboRadniNalog.SelectedValue));

                Dokumenta.InsertRadniNalog irn = new Dokumenta.InsertRadniNalog();
               // irn.InsRNTeretnica(Convert.ToInt32(cboRadniNalog.SelectedValue));

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        InsertTeretnicaStavke its = new InsertTeretnicaStavke();
                        Dokumenta.InsertIskljuceniVagoni div = new Dokumenta.InsertIskljuceniVagoni();
                        div.UpdateIskljuceniVagRSP(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboStanicaIsklj.SelectedValue));
                        
                    }
                }
                RefreshDataGrid();
                MessageBox.Show("Vagoni su raspušteni sada se nalaze u stanici popisa");
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Dokumenta.InsertTeretnica it = new Dokumenta.InsertTeretnica();
                it.InsTeretnica("", Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue), Convert.ToInt32(cboStanicaIsklj.SelectedValue), Convert.ToDateTime(dtpVremeOd.Value), Convert.ToDateTime(dtpVremeOd.Value), "", 0, 1, "sa", 0, Convert.ToInt32(cboRadniNalog.SelectedValue));

                Dokumenta.InsertRadniNalog irn = new Dokumenta.InsertRadniNalog();
                irn.InsRNTeretnica(Convert.ToInt32(cboRadniNalog.SelectedValue));
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Selected)
                    {
                        InsertTeretnicaStavke its = new InsertTeretnicaStavke();
                        its.InsTeretnicaStavkeRN(Convert.ToInt32(row.Cells[0].Value.ToString()), Convert.ToInt32(cboStanicaOd.SelectedValue), Convert.ToInt32(cboStanicaDo.SelectedValue));

                        Dokumenta.InsertIskljuceniVagoni div = new Dokumenta.InsertIskljuceniVagoni();
                        div.UpdateIskljuceniVagPredaj(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                }
                //dataGridView3
                MessageBox.Show("Vagoni su predati napravljena je i prijemna teretnica");
            }
            catch
            {
                MessageBox.Show("Nije uspela selekcija stavki");
            }



         
        }
    }
        }
