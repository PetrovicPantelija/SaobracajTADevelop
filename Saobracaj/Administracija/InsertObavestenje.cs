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
    class InsertObavestenje
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        public void InsObavestenje(int Kreirao, int Korisnik, string Poruka, DateTime DatumSlanja, bool Procitao, DateTime DatumCitanja)

        {

            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertNotifikacije";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter kreirao = new SqlParameter();
            kreirao.ParameterName = "@Kreirao";
            kreirao.SqlDbType = SqlDbType.Int;
            kreirao.Direction = ParameterDirection.Input;
            kreirao.Value = Kreirao;
            cmd.Parameters.Add(kreirao);

            SqlParameter korisnik = new SqlParameter();
            korisnik.ParameterName = "@Korisnik";
            korisnik.SqlDbType = SqlDbType.Int;
            korisnik.Direction = ParameterDirection.Input;
            korisnik.Value = Korisnik;
            cmd.Parameters.Add(korisnik);

            SqlParameter poruka = new SqlParameter();
            poruka.ParameterName = "@Poruka";
            poruka.SqlDbType = SqlDbType.NChar;
            poruka.Size = 500;
            poruka.Direction = ParameterDirection.Input;
            poruka.Value = Poruka;
            cmd.Parameters.Add(poruka);

            SqlParameter datumS = new SqlParameter();
            datumS.ParameterName = "@DatumSlanja";
            datumS.SqlDbType = SqlDbType.DateTime;
            datumS.Direction = ParameterDirection.Input;
            datumS.Value = DatumSlanja;
            cmd.Parameters.Add(datumS);

            SqlParameter procitao = new SqlParameter();
            procitao.ParameterName = "@Procitao";
            procitao.SqlDbType = SqlDbType.Bit;
            procitao.Direction = ParameterDirection.Input;
            procitao.Value = Procitao;
            cmd.Parameters.Add(procitao);

            SqlParameter datumC = new SqlParameter();
            datumC.ParameterName = "@DatumCitanja";
            datumC.SqlDbType = SqlDbType.DateTime;
            datumC.Direction = ParameterDirection.Input;
            datumC.Value = DatumCitanja;
            cmd.Parameters.Add(datumC);

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

        public void UpdObavestenje(int ID, int Kreirao, int Korisnik, string Poruka, DateTime DatumSlanja, bool Procitao, DateTime DatumCitanja)

        {

            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateNotifikacije";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            SqlParameter kreirao = new SqlParameter();
            kreirao.ParameterName = "@Kreirao";
            kreirao.SqlDbType = SqlDbType.Int;
            kreirao.Direction = ParameterDirection.Input;
            kreirao.Value = Kreirao;
            cmd.Parameters.Add(kreirao);

            SqlParameter korisnik = new SqlParameter();
            korisnik.ParameterName = "@Korisnik";
            korisnik.SqlDbType = SqlDbType.Int;
            korisnik.Direction = ParameterDirection.Input;
            korisnik.Value = Korisnik;
            cmd.Parameters.Add(korisnik);

            SqlParameter poruka = new SqlParameter();
            poruka.ParameterName = "@Poruka";
            poruka.SqlDbType = SqlDbType.NChar;
            poruka.Size = 500;
            poruka.Direction = ParameterDirection.Input;
            poruka.Value = Poruka;
            cmd.Parameters.Add(poruka);

            SqlParameter datumS = new SqlParameter();
            datumS.ParameterName = "@DatumSlanja";
            datumS.SqlDbType = SqlDbType.DateTime;
            datumS.Direction = ParameterDirection.Input;
            datumS.Value = DatumSlanja;
            cmd.Parameters.Add(datumS);

            SqlParameter procitao = new SqlParameter();
            procitao.ParameterName = "@Procitao";
            procitao.SqlDbType = SqlDbType.Bit;
            procitao.Direction = ParameterDirection.Input;
            procitao.Value = Procitao;
            cmd.Parameters.Add(procitao);

            SqlParameter datumC = new SqlParameter();
            datumC.ParameterName = "@DatumCitanja";
            datumC.SqlDbType = SqlDbType.DateTime;
            datumC.Direction = ParameterDirection.Input;
            datumC.Value = DatumCitanja;
            cmd.Parameters.Add(datumC);

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
        public void DelObavestenje(int ID)
        {

            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteNotifikacije";
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
    }
}