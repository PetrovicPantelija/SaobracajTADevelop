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
    class InsertGrupe
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public void InsGrupe(string Naziv)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertGrupeKorisnik";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramNaziv = new SqlParameter();
            paramNaziv.ParameterName = "@Naziv";
            paramNaziv.SqlDbType = SqlDbType.NChar;
            paramNaziv.Size = 50;
            paramNaziv.Direction = ParameterDirection.Input;
            paramNaziv.Value = Naziv;
            cmd.Parameters.Add(paramNaziv);

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
            catch(SqlException ex)
            {
                throw new Exception("Neuspešan upis" +ex.ToString());
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Unos grupe uspešan", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }
            if (error)
            {

            }
        }
        public void UpdateGrupe(int ID,int IdGrupe,string Naziv)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateGrupeKorisnik";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@ID";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = ID;
            cmd.Parameters.Add(paramId);

            SqlParameter paramIdG = new SqlParameter();
            paramIdG.ParameterName = "@IdGrupe";
            paramIdG.SqlDbType = SqlDbType.Int;
            paramIdG.Direction = ParameterDirection.Input;
            paramIdG.Value = IdGrupe;
            cmd.Parameters.Add(paramIdG);

            SqlParameter paramNaziv = new SqlParameter();
            paramNaziv.ParameterName = "@Naziv";
            paramNaziv.SqlDbType = SqlDbType.NChar;
            paramNaziv.Size = 50;
            paramNaziv.Direction = ParameterDirection.Input;
            paramNaziv.Value = Naziv;
            cmd.Parameters.Add(paramNaziv);

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
                throw new Exception("Neuspešan upis"+ex.ToString());
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Unos grupe uspešan", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }
            if (error)
            {

            }
        }
        public void DeleteGrupe(int ID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteGrupeKorisnik";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@ID";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = ID;
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
                throw new Exception("Neuspešan upis" + ex.ToString());
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Unos grupe uspešan", "",
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
