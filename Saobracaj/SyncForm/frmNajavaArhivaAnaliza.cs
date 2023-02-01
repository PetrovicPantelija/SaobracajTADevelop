using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace Saobracaj.SyncForm
{
    public partial class frmNajavaArhivaAnaliza : Syncfusion.Windows.Forms.Office2010Form
    {
        public static string code = "frmNajavaArhivaAnaliza";
        public bool Pravo;
        int idGrupe;
        int idForme;
        bool insert;
        bool update;
        bool delete;
        string Kor = Sifarnici.frmLogovanje.user.ToString();
        string niz = "";
        public frmNajavaArhivaAnaliza()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
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
        private void frmNajavaArhivaAnaliza_Load(object sender, EventArgs e)
        {
          
            var select = "  SELECT    najava.ID, stanice_4.opis as Granicna, " +
" Najava.BrojNajave, Najava.Voz, Partnerji_1.PaNaziv as Posiljalac,  " +
" Partnerji.PaNaziv AS Prevoznik, Partnerji_2.PaNaziv AS Primalac, " +
" stanice.Opis AS Uputna, stanice_1.Opis AS Otpravna,  Najava.PrevozniPut as Relacija , " +
" Najava.PredvidjenoPrimanje, Najava.StvarnoPrimanje, " +
" Najava.PredvidjenaPredaja, Najava.StvarnaPredaja, " +
" CASE WHEN Najava.RID > 0 THEN Cast(1 as bit) ELSE Cast(0 as BIT) END as StatusN , " +
" Najava.ONBroj,  Najava.Status, Najava.Tezina, Najava.Duzina, " +
" Najava.BrojKola, Najava.DatumUnosa, Partnerji_3.PaNaziv as PrevoznikZa, Najava.Faktura, Najava.Korisnik, " +
" najava.RobaNHM " +
" FROM  Najava INNER JOIN Partnerji AS Partnerji_1 ON " +
" Najava.Posiljalac = Partnerji_1.PaSifra " +
" INNER JOIN Partnerji ON Najava.Prevoznik = Partnerji.PaSifra " +
" INNER JOIN Partnerji AS Partnerji_2 ON Najava.Primalac = Partnerji_2.PaSifra " +
" INNER JOIN  stanice ON Najava.Uputna = stanice.ID " +
" INNER JOIN  stanice AS stanice_1 ON Najava.Otpravna = stanice_1.ID " +
" inner JOIN  stanice AS stanice_4 ON Najava.Granicna = stanice_4.ID " +
" INNER JOIN Partnerji as Partnerji_3 ON Najava.PrevoznikZa = Partnerji_3.PaSifra " +
" order by Najava.ID desc ";

            var s_connection = ConfigurationManager.ConnectionStrings["Saobracaj.Properties.Settings.TESTIRANJEConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            // dataGridView1.ReadOnly = true;
            gridGroupingControl1.DataSource = ds.Tables[0];
            gridGroupingControl1.ShowGroupDropArea = true;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = true;
            foreach (GridColumnDescriptor column in this.gridGroupingControl1.TableDescriptor.Columns)
            {
                column.AllowFilter = true;
            }
        }
    }
}
