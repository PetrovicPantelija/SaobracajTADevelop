using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Dokumenta
{
    class InsertEvidencijaGOLog
    {
        public string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
        public void InsertGoLOG(string Korisnik,DateTime Datum,string Akcija)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_InsertGoLOG";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramKorisnik = new SqlParameter();
            paramKorisnik.ParameterName = "@Korisnik";
            paramKorisnik.SqlDbType = SqlDbType.NVarChar;
            paramKorisnik.Size = 50;
            paramKorisnik.Direction = ParameterDirection.Input;
            paramKorisnik.Value = Korisnik;
            cmd.Parameters.Add(paramKorisnik);

            SqlParameter paramDatum = new SqlParameter();
            paramDatum.ParameterName = "@Datum";
            paramDatum.SqlDbType = SqlDbType.DateTime;
            paramDatum.Direction = ParameterDirection.Input;
            paramDatum.Value = Datum;
            cmd.Parameters.Add(paramDatum);

            SqlParameter paramAkcija = new SqlParameter();
            paramAkcija.ParameterName = "@Akcija";
            paramAkcija.SqlDbType = SqlDbType.NVarChar;
            paramAkcija.Size = 250;
            paramAkcija.Direction = ParameterDirection.Input;
            paramAkcija.Value = Akcija;
            cmd.Parameters.Add(paramAkcija);

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
                MessageBox.Show(ex.Message.ToString());
                throw new Exception("Neuspešan upis LOG");
            }
            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Uspesno upisan zapis", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
                if (error) { }
            }
        }
    }
}
