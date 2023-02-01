using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Administracija
{
    class InsertKorisnikGrupa
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public void InsKorisnikGrupa(string Korisnik, int IdGrupe)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertKorisnikGrupa";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramKorisnik = new SqlParameter();
            paramKorisnik.ParameterName = "@Korisnik";
            paramKorisnik.SqlDbType = SqlDbType.NChar;
            paramKorisnik.Size = 50;
            paramKorisnik.Direction = ParameterDirection.Input;
            paramKorisnik.Value = Korisnik;
            cmd.Parameters.Add(paramKorisnik);

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@IdGrupe";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = IdGrupe;
            cmd.Parameters.Add(paramId);

            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
            }
            catch (SqlException ex)
            {
                throw new Exception("Neuspešan upis");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Unos NHM broja je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }
            if (error)
            {

            }
        }
       /* public void UpdateKorisnikGrupa(string Korisnik, int IdGrupe)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateKorisnikGrupa";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramKorisnik = new SqlParameter();
            paramKorisnik.ParameterName = "@Korisnik";
            paramKorisnik.SqlDbType = SqlDbType.NChar;
            paramKorisnik.Size = 50;
            paramKorisnik.Direction = ParameterDirection.Input;
            paramKorisnik.Value = Korisnik;
            cmd.Parameters.Add(paramKorisnik);

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@IdGrupe";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = IdGrupe;
            cmd.Parameters.Add(paramId);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
            }
            catch (SqlException ex)
            {
                throw new Exception("Neuspešano brisanje");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Uspešno obrisano", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }
            if (error)
            {

            }
        }*/
        public void DeleteKorisnikGrupa(string Korisnik, int IdGrupe)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteKorisnikGrupa";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramKorisnik = new SqlParameter();
            paramKorisnik.ParameterName = "@Korisnik";
            paramKorisnik.SqlDbType = SqlDbType.NChar;
            paramKorisnik.Size = 50;
            paramKorisnik.Direction = ParameterDirection.Input;
            paramKorisnik.Value = Korisnik;
            cmd.Parameters.Add(paramKorisnik);

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@IdGrupe";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = IdGrupe;
            cmd.Parameters.Add(paramId);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
            }
            catch (SqlException ex)
            {
                throw new Exception("Neuspešano brisanje");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Uspešno obrisano", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }
            if (error)
            {

            }
        }
    }
}
