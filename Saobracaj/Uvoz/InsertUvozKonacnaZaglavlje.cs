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
    class InsertUvozKonacnaZaglavlje
    {
        string connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.TestiranjeConnectionString"].ConnectionString;
        public void InsUvozKonacnaZaglavlje(int Voz, string Napomena, int Vozom, string VoziloOznaka, DateTime VoziloDatum, string VoziloVozac, string BrojTelefona)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertUvozKonacnaZaglavlje";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter voz = new SqlParameter();
            voz.ParameterName = "@IDVoza";
            voz.SqlDbType = SqlDbType.Int;
            voz.Direction = ParameterDirection.Input;
            voz.Value = Voz;
            cmd.Parameters.Add(voz);

            SqlParameter napomena = new SqlParameter();
            napomena.ParameterName = "@Napomena";
            napomena.SqlDbType = SqlDbType.NVarChar;
            napomena.Size = 250;
            napomena.Direction = ParameterDirection.Input;
            napomena.Value = Napomena;
            cmd.Parameters.Add(napomena);

            SqlParameter vozom = new SqlParameter();
            vozom.ParameterName = "@Vozom";
            vozom.SqlDbType = SqlDbType.Int;
          //  vozom.Size = 250;
            vozom.Direction = ParameterDirection.Input;
            vozom.Value = Vozom;
            cmd.Parameters.Add(vozom);

            SqlParameter vozilooznaka = new SqlParameter();
            vozilooznaka.ParameterName = "@VoziloOznaka";
            vozilooznaka.SqlDbType = SqlDbType.NVarChar;
            vozilooznaka.Size = 100;
            vozilooznaka.Direction = ParameterDirection.Input;
            vozilooznaka.Value = VoziloOznaka;
            cmd.Parameters.Add(vozilooznaka);

            SqlParameter vozilodatum = new SqlParameter();
            vozilodatum.ParameterName = "@VoziloDatum";
            vozilodatum.SqlDbType = SqlDbType.DateTime;
            //   vozilooznaka.Size = 100;
            vozilodatum.Direction = ParameterDirection.Input;
            vozilodatum.Value = VoziloDatum;
            cmd.Parameters.Add(vozilodatum);

            SqlParameter vozilovozac = new SqlParameter();
            vozilovozac.ParameterName = "@VoziloVozac";
            vozilovozac.SqlDbType = SqlDbType.NVarChar;
            vozilovozac.Size = 100;
            vozilovozac.Direction = ParameterDirection.Input;
            vozilovozac.Value = VoziloVozac;
            cmd.Parameters.Add(vozilovozac);

            SqlParameter brojtelefona = new SqlParameter();
            brojtelefona.ParameterName = "@BrojTelefona";
            brojtelefona.SqlDbType = SqlDbType.NVarChar;
            brojtelefona.Size = 100;
            brojtelefona.Direction = ParameterDirection.Input;
            brojtelefona.Value = BrojTelefona;
            cmd.Parameters.Add(brojtelefona);

   
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
        public void UpdUvozKonacnaZaglavlje(int ID, int Voz, string Napomena, int Vozom, string VoziloOznaka, DateTime VoziloDatum, string VoziloVozac, string BrojTelefona)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateUvozKonacnaZaglavlje";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@ID";
            id.SqlDbType = SqlDbType.Int;
            id.Direction = ParameterDirection.Input;
            id.Value = ID;
            cmd.Parameters.Add(id);

            SqlParameter voz = new SqlParameter();
            voz.ParameterName = "@Voz";
            voz.SqlDbType = SqlDbType.Int;
            voz.Direction = ParameterDirection.Input;
            voz.Value = Voz;
            cmd.Parameters.Add(voz);

            SqlParameter napomena = new SqlParameter();
            napomena.ParameterName = "@Napomena";
            napomena.SqlDbType = SqlDbType.NVarChar;
            napomena.Size = 250;
            napomena.Direction = ParameterDirection.Input;
            napomena.Value = Napomena;
            cmd.Parameters.Add(napomena);

            SqlParameter vozom = new SqlParameter();
            vozom.ParameterName = "@Vozom";
            vozom.SqlDbType = SqlDbType.Int;
            //  vozom.Size = 250;
            vozom.Direction = ParameterDirection.Input;
            vozom.Value = Vozom;
            cmd.Parameters.Add(vozom);

            SqlParameter vozilooznaka = new SqlParameter();
            vozilooznaka.ParameterName = "@VoziloOznaka";
            vozilooznaka.SqlDbType = SqlDbType.NVarChar;
            vozilooznaka.Size = 100;
            vozilooznaka.Direction = ParameterDirection.Input;
            vozilooznaka.Value = VoziloOznaka;
            cmd.Parameters.Add(vozilooznaka);

            SqlParameter vozilodatum = new SqlParameter();
            vozilodatum.ParameterName = "@VoziloDatum";
            vozilodatum.SqlDbType = SqlDbType.DateTime;
            //   vozilooznaka.Size = 100;
            vozilodatum.Direction = ParameterDirection.Input;
            vozilodatum.Value = VoziloDatum;
            cmd.Parameters.Add(vozilodatum);

            SqlParameter vozilovozac = new SqlParameter();
            vozilovozac.ParameterName = "@VoziloVozac";
            vozilovozac.SqlDbType = SqlDbType.NVarChar;
            vozilovozac.Size = 100;
            vozilovozac.Direction = ParameterDirection.Input;
            vozilovozac.Value = VoziloVozac;
            cmd.Parameters.Add(vozilovozac);

            SqlParameter brojtelefona = new SqlParameter();
            brojtelefona.ParameterName = "@BrojTelefona";
            brojtelefona.SqlDbType = SqlDbType.NVarChar;
            brojtelefona.Size = 100;
            brojtelefona.Direction = ParameterDirection.Input;
            brojtelefona.Value = BrojTelefona;
            cmd.Parameters.Add(brojtelefona);


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
        public void DelUvozKonacnaZaglavlje(int ID)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteUvozKonacnaZaglavlje";
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
