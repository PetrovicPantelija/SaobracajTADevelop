using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Saobracaj.Dokumenta
{
    class InsertAutomobiliRegistracija
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public void InsertRegistracija(int IDAutomobila, DateTime DatumRegistracije,int Zaposleni,int Partner,string Napomena)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_InsertAutomobiliRegistracija";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramAuto = new SqlParameter();
            paramAuto.ParameterName = "@IDAutomobila";
            paramAuto.SqlDbType = SqlDbType.Int;
            paramAuto.Direction = ParameterDirection.Input;
            paramAuto.Value = IDAutomobila;
            cmd.Parameters.Add(paramAuto);

            SqlParameter paramDatum = new SqlParameter();
            paramDatum.ParameterName = "@DatumRegistracije";
            paramDatum.SqlDbType = SqlDbType.DateTime;
            paramDatum.Direction = ParameterDirection.Input;
            paramDatum.Value = DatumRegistracije;
            cmd.Parameters.Add(paramDatum);

            SqlParameter paramZaposleni = new SqlParameter();
            paramZaposleni.ParameterName = "@Zaposleni";
            paramZaposleni.SqlDbType = SqlDbType.Int;
            paramZaposleni.Direction = ParameterDirection.Input;
            paramZaposleni.Value = Zaposleni;
            cmd.Parameters.Add(paramZaposleni);

            SqlParameter paramPartner = new SqlParameter();
            paramPartner.ParameterName = "@Partner";
            paramPartner.SqlDbType = SqlDbType.Int;
            paramPartner.Direction = ParameterDirection.Input;
            paramPartner.Value = Partner;
            cmd.Parameters.Add(paramPartner);

            SqlParameter paramNapomena = new SqlParameter();
            paramNapomena.ParameterName = "@Napomena";
            paramNapomena.SqlDbType = SqlDbType.NVarChar;
            paramNapomena.Size = 250;
            paramNapomena.Direction = ParameterDirection.Input;
            paramNapomena.Value = Napomena;
            cmd.Parameters.Add(paramNapomena);

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
                throw new Exception("Neuspešan upis");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Uspešno upisan zapis", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                if (error)
                {

                }
            }
        }
        public void UpdateRegistracija (int ID,int IDAutomobila, DateTime DatumRegistracije, int Zaposleni, int Partner, string Napomena)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_UpdateAutomobiliRegistracija";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paramID = new SqlParameter();
            paramID.ParameterName = "@ID";
            paramID.SqlDbType = SqlDbType.Int;
            paramID.Direction = ParameterDirection.Input;
            paramID.Value = ID;
            cmd.Parameters.Add(paramID);

            SqlParameter paramAuto = new SqlParameter();
            paramAuto.ParameterName = "@IDAutomobila";
            paramAuto.SqlDbType = SqlDbType.Int;
            paramAuto.Direction = ParameterDirection.Input;
            paramAuto.Value = IDAutomobila;
            cmd.Parameters.Add(paramAuto);

            SqlParameter paramDatum = new SqlParameter();
            paramDatum.ParameterName = "@DatumRegistracije";
            paramDatum.SqlDbType = SqlDbType.DateTime;
            paramDatum.Direction = ParameterDirection.Input;
            paramDatum.Value = DatumRegistracije;
            cmd.Parameters.Add(paramDatum);

            SqlParameter paramZaposleni = new SqlParameter();
            paramZaposleni.ParameterName = "@Zaposleni";
            paramZaposleni.SqlDbType = SqlDbType.Int;
            paramZaposleni.Direction = ParameterDirection.Input;
            paramZaposleni.Value = Zaposleni;
            cmd.Parameters.Add(paramZaposleni);

            SqlParameter paramPartner = new SqlParameter();
            paramPartner.ParameterName = "@Partner";
            paramPartner.SqlDbType = SqlDbType.Int;
            paramPartner.Direction = ParameterDirection.Input;
            paramPartner.Value = Partner;
            cmd.Parameters.Add(paramPartner);

            SqlParameter paramNapomena = new SqlParameter();
            paramNapomena.ParameterName = "@Napomena";
            paramNapomena.SqlDbType = SqlDbType.NVarChar;
            paramNapomena.Size = 250;
            paramNapomena.Direction = ParameterDirection.Input;
            paramNapomena.Value = Napomena;
            cmd.Parameters.Add(paramNapomena);

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
                throw new Exception("Neuspešna izmena");
            }
            conn.Close();
            if (error)
            {

            }
        }
        public void DeleteRegistracija(int ID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_DeleteAutomobiliRegistracija";
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
                if (!error)
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
