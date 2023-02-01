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
    class InsertPolozenePruge
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        public void InsPolozenePruge(int DeSifra,int IDPruga, DateTime DatumPolozen)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_InsertPolozenePruge";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter desifra = new SqlParameter();
            desifra.ParameterName = "@DeSifra";
            desifra.SqlDbType = SqlDbType.Int;
            desifra.Direction = ParameterDirection.Input;
            desifra.Value = DeSifra;
            cmd.Parameters.Add(desifra);

            SqlParameter idpruga = new SqlParameter();
            idpruga.ParameterName = "@IDPruga";
            idpruga.SqlDbType = SqlDbType.Int;
            idpruga.Direction = ParameterDirection.Input;
            idpruga.Value = IDPruga;
            cmd.Parameters.Add(idpruga);

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
        public void UpdPolozenePruge(int ID, int DeSifra, int IDPruga, DateTime DatumPolozen)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_UpdatePolozenePruge";
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

            SqlParameter idpruga = new SqlParameter();
            idpruga.ParameterName = "@IDPruga";
            idpruga.SqlDbType = SqlDbType.Int;
            idpruga.Direction = ParameterDirection.Input;
            idpruga.Value = IDPruga;
            cmd.Parameters.Add(idpruga);

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
        public void DelPolozenePruge(int ID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_DeletePolozenePruge";
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
