using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Saobracaj.Dokumenta
{
    class InsertMUPDozvola
    {
        public void InsMUPDozvola(int Zaposleni, DateTime VremeOd, DateTime VremeDo, string JMBG, string RadnoMesto, string Relacija, string Lokacija, string Adresa, int Automobil)
        {
            /*
             
             * */

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertMUPDozvola";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Zaposleni";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Zaposleni;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@VremeOd";
            parameter1.SqlDbType = SqlDbType.DateTime;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = VremeOd;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@VremeDo";
            parameter2.SqlDbType = SqlDbType.DateTime;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = VremeDo;
            myCommand.Parameters.Add(parameter2);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@JMBG";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 30;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = JMBG;
            myCommand.Parameters.Add(parameter5);


            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@RadnoMesto";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 60;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = RadnoMesto;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Relacija";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 500;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Relacija;
            myCommand.Parameters.Add(parameter7);


            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Lokacija";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 60;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Lokacija;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Adresa";
            parameter9.SqlDbType = SqlDbType.NVarChar;
            parameter9.Size = 60;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Adresa;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Automobil";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Automobil;
            myCommand.Parameters.Add(parameter10);

            myConnection.Open();
            SqlTransaction myTransaction = myConnection.BeginTransaction();
            myCommand.Transaction = myTransaction;
            bool error = true;
            try
            {
                myCommand.ExecuteNonQuery();
                myTransaction.Commit();
                myTransaction = myConnection.BeginTransaction();
                myCommand.Transaction = myTransaction;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešan upis dozvole u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis dozvole u bazu", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

    }
}
