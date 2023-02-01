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
using Syncfusion.Data;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;

namespace Saobracaj.Mobile
{
    public partial class frmAnalizaGOSum : Syncfusion.Windows.Forms.Office2010Form
    {
        public frmAnalizaGOSum()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
            IdGrupe();
            IdForme();
            PravoPristupa();
        }
        public static string code = "frmAnalizaGOSum";
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
        private void frmAnalizaGOSum_Load(object sender, EventArgs e)
        {

            var select = " Select RazporeditveStrMesto.RzSMSifStrMesta as MestoTroska, DelovnaMesta.DmNaziv as RadnoMesto, SUM(DoSkupaj) as Dana, (CASE WHEN Sum(Iskorisceno) IS NULL THEN 0 ELSE Sum(Iskorisceno) END) as Iskorisceno, (SUM(DoSkupaj) - (CASE WHEN Sum(Iskorisceno) IS NULL THEN 0 ELSE Sum(Iskorisceno) END)) as Preostalo, (Rtrim(Delavci.DePriimek) + ' ' + Rtrim(Delavci.DeIme)) as Zaposleni from Dopust " +
             "   inner join Delavci on Delavci.DeSifra = Dopust.DoSifDe " +
             "   inner join DelovnaMesta on DelovnaMesta.DmSifra = Delavci.DeSifDelMes " +
             "   inner join RazporeditveStrMesto on RazporeditveStrMesto.RzSMSifDe = Delavci.DeSifra " +
             "   left join(select SUM(Ukupno) as Iskorisceno, Delavci.DeSifra from DopustStavke " +
             "   inner join Dopust on Dopust.DoStZapisa = DopustStavke.IDNadredjena " +
             "   inner join Delavci on Delavci.DeSifra = Dopust.DoSifDe " +
             "   Where DeSifStat IN('A', 'R') " +
             "   group by Delavci.DeSifra) t1 on T1.DeSifra = Delavci.DeSifra " +
             "   group by(Rtrim(Delavci.DePriimek) +' ' + Rtrim(Delavci.DeIme)), RazporeditveStrMesto.RzSMSifStrMesta, DelovnaMesta.DmNaziv ";



                var s_connection = ConfigurationManager.ConnectionStrings["Saobracaj.Properties.Settings.TESTIRANJEConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(s_connection);
                var c = new SqlConnection(s_connection);
                var dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
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

