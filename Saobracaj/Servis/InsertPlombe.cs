using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Servis
{
    class InsertPlombe
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public void InsPlombe(DateTime Datum, string Korisnik, int Najava, int BrojPotrosenihPlombi, string Slika)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertPlombe";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter datum = new SqlParameter();
            datum.ParameterName = "@Datum";
            datum.SqlDbType = SqlDbType.DateTime;
            datum.Direction = ParameterDirection.Input;
            datum.Value = Datum;
            cmd.Parameters.Add(datum);

            SqlParameter korisnik = new SqlParameter();
            korisnik.ParameterName = "@Korisnik";
            korisnik.SqlDbType = SqlDbType.NVarChar;
            korisnik.Size = 50;
            korisnik.Direction = ParameterDirection.Input;
            korisnik.Value = Korisnik;
            cmd.Parameters.Add(korisnik);

            SqlParameter najava = new SqlParameter();
            najava.ParameterName = "@Najava";
            najava.SqlDbType = SqlDbType.Int;
            najava.Direction = ParameterDirection.Input;
            najava.Value = Najava;
            cmd.Parameters.Add(najava);

            SqlParameter brPlombi = new SqlParameter();
            brPlombi.ParameterName = "@BrojPotrosenihPlombi";
            brPlombi.SqlDbType = SqlDbType.Int;
            brPlombi.Direction = ParameterDirection.Input;
            brPlombi.Value = BrojPotrosenihPlombi;
            cmd.Parameters.Add(brPlombi);

            SqlParameter slika = new SqlParameter();
            slika.ParameterName = "@Slika";
            slika.SqlDbType = SqlDbType.NVarChar;
            slika.Size = 500;
            slika.Direction = ParameterDirection.Input;
            slika.Value = Slika;
            cmd.Parameters.Add(slika);

            conn.Open();
            SqlTransaction myTransaction = conn.BeginTransaction();
            cmd.Transaction = myTransaction;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = conn.BeginTransaction();
                cmd.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešan upis NHM brojeva");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos NHM broja je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }
        public void UpdPlombe(int ID, DateTime Datum, string Korisnik, int Najava, int BrojPotrosenihPlombi, string Slika)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdatePlombe";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            SqlParameter datum = new SqlParameter();
            datum.ParameterName = "@Datum";
            datum.SqlDbType = SqlDbType.DateTime;
            datum.Direction = ParameterDirection.Input;
            datum.Value = Datum;
            cmd.Parameters.Add(datum);

            SqlParameter korisnik = new SqlParameter();
            korisnik.ParameterName = "@Korisnik";
            korisnik.SqlDbType = SqlDbType.NVarChar;
            korisnik.Size = 50;
            korisnik.Direction = ParameterDirection.Input;
            korisnik.Value = Korisnik;
            cmd.Parameters.Add(korisnik);

            SqlParameter najava = new SqlParameter();
            najava.ParameterName = "@Najava";
            najava.SqlDbType = SqlDbType.Int;
            najava.Direction = ParameterDirection.Input;
            najava.Value = Najava;
            cmd.Parameters.Add(najava);

            SqlParameter brPlombi = new SqlParameter();
            brPlombi.ParameterName = "@BrojPotrosenihPlombi";
            brPlombi.SqlDbType = SqlDbType.Int;
            brPlombi.Direction = ParameterDirection.Input;
            brPlombi.Value = BrojPotrosenihPlombi;
            cmd.Parameters.Add(brPlombi);

            SqlParameter slika = new SqlParameter();
            slika.ParameterName = "@Slika";
            slika.SqlDbType = SqlDbType.NVarChar;
            slika.Size = 500;
            slika.Direction = ParameterDirection.Input;
            slika.Value = Slika;
            cmd.Parameters.Add(slika);

            conn.Open();
            SqlTransaction myTransaction = conn.BeginTransaction();
            cmd.Transaction = myTransaction;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = conn.BeginTransaction();
                cmd.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešan upis NHM brojeva");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos NHM broja je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }
        public void DelPlombe(int ID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeletePlombe";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            conn.Open();
            SqlTransaction myTransaction = conn.BeginTransaction();
            cmd.Transaction = myTransaction;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = conn.BeginTransaction();
                cmd.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešan upis NHM brojeva");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos NHM broja je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }
    }
}
