using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Saobracaj.Servis
{
    class InsertPrijavaKvaraAuto
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public void InsertPrijava(string Automobil, int Prijavio, DateTime DatumPrijave, int Kvar, int StatusKvara, int Promenio, string Napomena, int AutomobilID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_InsertPrijavaKvaraAuto";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramAuto = new SqlParameter();
            paramAuto.ParameterName = "@Automobil";
            paramAuto.SqlDbType = SqlDbType.NChar;
            paramAuto.Size = 20;
            paramAuto.Direction = ParameterDirection.Input;
            paramAuto.Value = Automobil;
            cmd.Parameters.Add(paramAuto);

            SqlParameter paramPrijava = new SqlParameter();
            paramPrijava.ParameterName = "@Prijavio";
            paramPrijava.SqlDbType = SqlDbType.Int;
            paramPrijava.Direction = ParameterDirection.Input;
            paramPrijava.Value = Prijavio;
            cmd.Parameters.Add(paramPrijava);

            SqlParameter paramDatum = new SqlParameter();
            paramDatum.ParameterName = "@DatumPrijave";
            paramDatum.SqlDbType = SqlDbType.DateTime;
            paramDatum.Direction = ParameterDirection.Input;
            paramDatum.Value = DatumPrijave;
            cmd.Parameters.Add(paramDatum);

            SqlParameter paramKvar = new SqlParameter();
            paramKvar.ParameterName = "@Kvar";
            paramKvar.SqlDbType = SqlDbType.Int;
            paramKvar.Direction = ParameterDirection.Input;
            paramKvar.Value = Kvar;
            cmd.Parameters.Add(paramKvar);

            SqlParameter paramStatus = new SqlParameter();
            paramStatus.ParameterName = "@StatusKvara";
            paramStatus.SqlDbType = SqlDbType.Int;
            paramStatus.Direction = ParameterDirection.Input;
            paramStatus.Value = StatusKvara;
            cmd.Parameters.Add(paramStatus);

            SqlParameter paramPromenio = new SqlParameter();
            paramPromenio.ParameterName = "@Promenio";
            paramPromenio.SqlDbType = SqlDbType.Int;
            paramPromenio.Direction = ParameterDirection.Input;
            paramPromenio.Value = Promenio;
            cmd.Parameters.Add(paramPromenio);

            SqlParameter paramNapomena = new SqlParameter();
            paramNapomena.ParameterName = "@Napomena";
            paramNapomena.SqlDbType = SqlDbType.NVarChar;
            paramNapomena.Size = 250;
            paramNapomena.Direction = ParameterDirection.Input;
            paramNapomena.Value = Napomena;
            cmd.Parameters.Add(paramNapomena);

            SqlParameter paramAutomobilID = new SqlParameter();
            paramAutomobilID.ParameterName = "@AutomobilID";
            paramAutomobilID.SqlDbType = SqlDbType.Int;
            paramAutomobilID.Direction = ParameterDirection.Input;
            paramAutomobilID.Value = AutomobilID;
            cmd.Parameters.Add(paramAutomobilID);



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
            catch(SqlException)
            {
                throw new Exception("Neuspešan upis NHM brojeva");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Unos NHM broja je uspešeno završen", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                if (error)
                {

                }
            }

        }
        public void UpdatePrijava(int ID, string Automobil, int Prijavio, DateTime DatumPrijave, int Kvar, int StatusKvara, int Promenio, string Napomena, int AutomobilID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_UpdatePrijavaKvaraAuto";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramID = new SqlParameter();
            paramID.ParameterName = "@ID";
            paramID.SqlDbType = SqlDbType.Int;
            paramID.Direction = ParameterDirection.Input;
            paramID.Value = ID;
            cmd.Parameters.Add(paramID);

            SqlParameter paramAuto = new SqlParameter();
            paramAuto.ParameterName = "@Automobil";
            paramAuto.SqlDbType = SqlDbType.NChar;
            paramAuto.Size = 20;
            paramAuto.Direction = ParameterDirection.Input;
            paramAuto.Value = Automobil;
            cmd.Parameters.Add(paramAuto);

            SqlParameter paramPrijava = new SqlParameter();
            paramPrijava.ParameterName = "@Prijavio";
            paramPrijava.SqlDbType = SqlDbType.Int;
            paramPrijava.Direction = ParameterDirection.Input;
            paramPrijava.Value = Prijavio;
            cmd.Parameters.Add(paramPrijava);

            SqlParameter paramDatum = new SqlParameter();
            paramDatum.ParameterName = "@DatumPrijave";
            paramDatum.SqlDbType = SqlDbType.DateTime;
            paramDatum.Direction = ParameterDirection.Input;
            paramDatum.Value = DatumPrijave;
            cmd.Parameters.Add(paramDatum);

            SqlParameter paramKvar = new SqlParameter();
            paramKvar.ParameterName = "@Kvar";
            paramKvar.SqlDbType = SqlDbType.Int;
            paramKvar.Direction = ParameterDirection.Input;
            paramKvar.Value = Kvar;
            cmd.Parameters.Add(paramKvar);

            SqlParameter paramStatus = new SqlParameter();
            paramStatus.ParameterName = "@StatusKvara";
            paramStatus.SqlDbType = SqlDbType.Int;
            paramStatus.Direction = ParameterDirection.Input;
            paramStatus.Value = StatusKvara;
            cmd.Parameters.Add(paramStatus);

            SqlParameter paramPromenio = new SqlParameter();
            paramPromenio.ParameterName = "@Promenio";
            paramPromenio.SqlDbType = SqlDbType.Int;
            paramPromenio.Direction = ParameterDirection.Input;
            paramPromenio.Value = Promenio;
            cmd.Parameters.Add(paramPromenio);


            SqlParameter paramNapomena = new SqlParameter();
            paramNapomena.ParameterName = "@Napomena";
            paramNapomena.SqlDbType = SqlDbType.NVarChar;
            paramNapomena.Size = 250;
            paramNapomena.Direction = ParameterDirection.Input;
            paramNapomena.Value = Napomena;
            cmd.Parameters.Add(paramNapomena);

            SqlParameter paramAutomobilID = new SqlParameter();
            paramAutomobilID.ParameterName = "@AutomobilID";
            paramAutomobilID.SqlDbType = SqlDbType.Int;
            paramAutomobilID.Direction = ParameterDirection.Input;
            paramAutomobilID.Value = AutomobilID;
            cmd.Parameters.Add(paramAutomobilID);

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
                MessageBox.Show(ex.ToString());
                throw new Exception("Neuspešna promena prijave kvarova");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Promena NHM broja je uspešno završena", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                if (error)
                { 

                }
            }

        }
        public void DeletePrijava (int ID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_DeletePrijavaKvarAuto";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramID = new SqlParameter();
            paramID.ParameterName = "@ID";
            paramID.SqlDbType = SqlDbType.Int;
            paramID.Direction = ParameterDirection.Input;
            paramID.Value = ID;
            cmd.Parameters.Add(paramID);

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
            catch (SqlException)
            {
                throw new Exception("Brisanje neuspešno");
            }
            finally
            {
                if(!error)
                {
                    tran.Commit();
                    MessageBox.Show("Uspešno obrisano", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                if (error)
                {

                }
            }
        }
    }
}
