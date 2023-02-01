using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Saobracaj.Uvoz
{
    class InsertCarinarnice
    {
        string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.TestiranjeConnectionString"].ConnectionString;
        public void InsCarinarnice(string Naziv,string CINaziv , string CIOznaka, string CIEmail, string CITelefon)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertCarinarnice";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter naziv = new SqlParameter();
            naziv.ParameterName = "@Naziv";
            naziv.SqlDbType = SqlDbType.NVarChar;
            naziv.Size = 50;
            naziv.Direction = ParameterDirection.Input;
            naziv.Value = Naziv;
            cmd.Parameters.Add(naziv);

            SqlParameter cINaziv = new SqlParameter();
            cINaziv.ParameterName = "@CINaziv";
            cINaziv.SqlDbType = SqlDbType.NVarChar;
            cINaziv.Size = 100;
            cINaziv.Direction = ParameterDirection.Input;
            cINaziv.Value = CINaziv;
            cmd.Parameters.Add(cINaziv);
            
            SqlParameter cIOznaka = new SqlParameter();
            cIOznaka.ParameterName = "@CIOznaka";
            cIOznaka.SqlDbType = SqlDbType.NVarChar;
            cIOznaka.Size = 100;
            cIOznaka.Direction = ParameterDirection.Input;
            cIOznaka.Value = CIOznaka;
            cmd.Parameters.Add(cIOznaka);

            SqlParameter cIEmail = new SqlParameter();
            cIEmail.ParameterName = "@CIEmail";
            cIEmail.SqlDbType = SqlDbType.NVarChar;
            cIEmail.Size = 100;
            cIEmail.Direction = ParameterDirection.Input;
            cIEmail.Value = CIEmail;
            cmd.Parameters.Add(cIEmail);

            SqlParameter cITelefon = new SqlParameter();
            cITelefon.ParameterName = "@CITelefon";
            cITelefon.SqlDbType = SqlDbType.NVarChar;
            cITelefon.Size = 100;
            cITelefon.Direction = ParameterDirection.Input;
            cITelefon.Value = CITelefon;
            cmd.Parameters.Add(cITelefon);


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
                throw new Exception("Neuspešan upis ");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }
        public void UpdCarinarnice(int ID,string Naziv, string CINaziv, string CIOznaka, string CIEmail, string CITelefon)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateCarinarnice";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            SqlParameter naziv = new SqlParameter();
            naziv.ParameterName = "@Naziv";
            naziv.SqlDbType = SqlDbType.NVarChar;
            naziv.Size = 50;
            naziv.Direction = ParameterDirection.Input;
            naziv.Value = Naziv;
            cmd.Parameters.Add(naziv);

            SqlParameter cINaziv = new SqlParameter();
            cINaziv.ParameterName = "@CINaziv";
            cINaziv.SqlDbType = SqlDbType.NVarChar;
            cINaziv.Size = 100;
            cINaziv.Direction = ParameterDirection.Input;
            cINaziv.Value = CINaziv;
            cmd.Parameters.Add(cINaziv);

            SqlParameter cIOznaka = new SqlParameter();
            cIOznaka.ParameterName = "@CIOznaka";
            cIOznaka.SqlDbType = SqlDbType.NVarChar;
            cIOznaka.Size = 100;
            cIOznaka.Direction = ParameterDirection.Input;
            cIOznaka.Value = CIOznaka;
            cmd.Parameters.Add(cIOznaka);

            SqlParameter cIEmail = new SqlParameter();
            cIEmail.ParameterName = "@CIEmail";
            cIEmail.SqlDbType = SqlDbType.NVarChar;
            cIEmail.Size = 100;
            cIEmail.Direction = ParameterDirection.Input;
            cIEmail.Value = CIEmail;
            cmd.Parameters.Add(cIEmail);

            SqlParameter cITelefon = new SqlParameter();
            cITelefon.ParameterName = "@CITelefon";
            cITelefon.SqlDbType = SqlDbType.NVarChar;
            cITelefon.Size = 100;
            cITelefon.Direction = ParameterDirection.Input;
            cITelefon.Value = CITelefon;
            cmd.Parameters.Add(cITelefon);

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
                throw new Exception("Neuspešan upis ");
            }
            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos uspešno završen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }
        public void DelCarinarnice(int ID)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteCarinarnice";
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
                throw new Exception("Neuspešan upis ");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos uspešno završen", "",
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
