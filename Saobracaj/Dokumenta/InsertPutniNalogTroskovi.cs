using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TrackModal.Dokumeta
{
    class InsertPutniNalogTroskovi
    {
       




        public void InsPutniNalogTroskovi(int IDNadredjeni,DateTime Datum, string Svrha, Double Kolicina, DateTime DatumPotpisa, string Potpisao)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPutniNalogTroskovi";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;



            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDNadredjenog";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDNadredjeni;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Datum";
            parameter2.SqlDbType = SqlDbType.DateTime;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Datum;
            myCommand.Parameters.Add(parameter2);


            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Svrha";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Svrha;
            myCommand.Parameters.Add(parameter3);

   
       

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Kolicina";
            parameter4.SqlDbType = SqlDbType.Decimal;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Kolicina;
            myCommand.Parameters.Add(parameter4);



            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@DatumPotpisa";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = DatumPotpisa;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Potpisao";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 50;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Potpisao;
            myCommand.Parameters.Add(parameter6);

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
                throw new Exception("Neuspešan upis cena u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis cena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdPutniNalogTroskovi(int ID, int IDNadredjeni, DateTime Datum, string Svrha, Double Kolicina, DateTime DatumPotpisa, string Potpisao)

        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdatePutniNalogTroskovi";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);



            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDNadredjeni";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDNadredjeni;
            myCommand.Parameters.Add(parameter1);


            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Datum";
            parameter2.SqlDbType = SqlDbType.DateTime;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Datum;
            myCommand.Parameters.Add(parameter2);


            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Svrha";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Svrha;
            myCommand.Parameters.Add(parameter3);




            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Kolicina";
            parameter4.SqlDbType = SqlDbType.Decimal;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Kolicina;
            myCommand.Parameters.Add(parameter4);



            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@DatumPotpisa";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = DatumPotpisa;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Potpisao";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 50;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Potpisao;
            myCommand.Parameters.Add(parameter6);




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
                throw new Exception("Neuspešan upis ekipe u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis aktivnosti", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void DeletePutniNalogTroskovi(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeletePutniNalogTroskovi";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

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
                throw new Exception("Brisanje neuspešno");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Brisanje Zaposlenog uspešno završeno", "",
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
