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
    class InsertForme
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public void InsForme(string Naziv, string Code)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertForme";
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter paramNaziv = new SqlParameter();
            paramNaziv.ParameterName = "@Naziv";
            paramNaziv.SqlDbType = SqlDbType.NChar;
            paramNaziv.Size = 50;
            paramNaziv.Direction = ParameterDirection.Input;
            paramNaziv.Value = Naziv;
            cmd.Parameters.Add(paramNaziv);

            SqlParameter paramCode = new SqlParameter();
            paramCode.ParameterName = "@Code";
            paramCode.SqlDbType = SqlDbType.NChar;
            paramCode.Size = 50;
            paramCode.Direction = ParameterDirection.Input;
            paramCode.Value = Code;
            cmd.Parameters.Add(paramCode);

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
        public void UpdateForme(int IdForme, string Naziv, string Code)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateForme";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@IdForme";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = IdForme;
            cmd.Parameters.Add(paramId);

            SqlParameter paramNaziv = new SqlParameter();
            paramNaziv.ParameterName = "@Naziv";
            paramNaziv.SqlDbType = SqlDbType.NChar;
            paramNaziv.Size = 50;
            paramNaziv.Direction = ParameterDirection.Input;
            paramNaziv.Value = Naziv;
            cmd.Parameters.Add(paramNaziv);

            SqlParameter paramCode = new SqlParameter();
            paramCode.ParameterName = "@Code";
            paramCode.SqlDbType = SqlDbType.NChar;
            paramCode.Size = 50;
            paramCode.Direction = ParameterDirection.Input;
            paramCode.Value = Code;
            cmd.Parameters.Add(paramCode);

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
        public void DeleteForme(int IdForme)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteForme";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@IdForme";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = IdForme;
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
