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
    class Insert1ReportGO
    {
        public void InsReportGO(string Zaposleni, string Prebivaliste, string Ulica, string JMBG, string RadnoMesto, string Godina, string Dana, string DatumOd, string DatumDo, string DatumPovratka, string DanaGodisnjeg, string DanaIskoristio, string DatumZahteva)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "Insert1REportGO";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

          

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Zaposleni";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 100;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Zaposleni;
            myCommand.Parameters.Add(parameter);

           
           

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Prebivaliste";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 100;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Prebivaliste;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Ulica";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 100;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Ulica;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@JMBG";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = JMBG;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@RadnoMesto";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 100;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = RadnoMesto;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Godina";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 10;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Godina;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Dana";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 10;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Dana;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@DatumOd";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = DatumOd;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@DatumDo";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 20;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = DatumDo;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@DatumPovratka";
            parameter9.SqlDbType = SqlDbType.NVarChar;
            parameter9.Size = 20;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = DatumPovratka;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@DanaGodisnjeg";
            parameter10.SqlDbType = SqlDbType.NVarChar;
            parameter10.Size = 10;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = DanaGodisnjeg;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@DanaIskoristio";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 100;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = DanaIskoristio;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@DatumZahteva";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 100;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = DatumZahteva;
            myCommand.Parameters.Add(parameter12);
          

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
                throw new Exception("Neuspešan upis NHM brojeva");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos NHM broja je uspešno završena", "",
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
