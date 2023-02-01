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
    class InsertPolozeneLokomotive
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        public void InsPolozeneLokomotive(int DeSifra, int IDLokomotive, DateTime DatumPolozen)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_InsertPolozeneLokomotive";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter desifra = new SqlParameter();
            desifra.ParameterName = "@DeSifra";
            desifra.SqlDbType = SqlDbType.Int;
            desifra.Direction = ParameterDirection.Input;
            desifra.Value = DeSifra;
            cmd.Parameters.Add(desifra);

            SqlParameter idlokomotive = new SqlParameter();
            idlokomotive.ParameterName = "@IDLokomotive";
            idlokomotive.SqlDbType = SqlDbType.Int;
            idlokomotive.Direction = ParameterDirection.Input;
            idlokomotive.Value = IDLokomotive;
            cmd.Parameters.Add(idlokomotive);

            SqlParameter datum = new SqlParameter();
            datum.ParameterName = "@DatumPolozen";
            datum.SqlDbType = SqlDbType.Date;
            datum.Value = DatumPolozen;
            cmd.Parameters.Add(datum);

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
        public void UpdPolozeneLokomotive(int ID, int DeSifra, int IDLokomotive, DateTime DatumPolozen)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_UpdatePolozeneLokomotive";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            SqlParameter desifra = new SqlParameter();
            desifra.ParameterName = "@DeSifra";
            desifra.SqlDbType = SqlDbType.Int;
            desifra.Direction = ParameterDirection.Input;
            desifra.Value = DeSifra;
            cmd.Parameters.Add(desifra);

            SqlParameter idlokomotive = new SqlParameter();
            idlokomotive.ParameterName = "@IDLokomotive";
            idlokomotive.SqlDbType = SqlDbType.Int;
            idlokomotive.Direction = ParameterDirection.Input;
            idlokomotive.Value = IDLokomotive;
            cmd.Parameters.Add(idlokomotive);

            SqlParameter datum = new SqlParameter();
            datum.ParameterName = "@DatumPolozen";
            datum.SqlDbType = SqlDbType.Date;
            datum.Value = DatumPolozen;
            cmd.Parameters.Add(datum);

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
        public void DelPolozeneLokomotive(int ID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_DeletePolozeneLokomotive";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

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
                throw new Exception("Neuspešno brisanje");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Brisanje uspešno završeno", "",
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
