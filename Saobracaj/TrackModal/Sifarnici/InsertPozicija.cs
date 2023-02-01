using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Testiranje.Sifarnici
{
    class InsertPozicija
    {

        public void InsPozicija(int Skladiste, string Oznaka, string Opis, string namena,  DateTime Datum, string Korisnik)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPozicija";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Skladiste";
            parameter1.SqlDbType = SqlDbType.Int;
           
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Skladiste;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Oznaka";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Oznaka;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Opis";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 30;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Opis;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Namena";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 10;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = namena;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Datum";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Datum;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Korisnik";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 20;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Korisnik;
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
                throw new Exception("Neuspešan upis Pozicije u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis Pozicije", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdPozicija(int ID, int Skladiste, string Oznaka, string Opis, string namena,  DateTime Datum, string Korisnik)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdatePozicija";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Skladiste";
            parameter1.SqlDbType = SqlDbType.Int;

            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Skladiste;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Oznaka";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Oznaka;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Opis";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 30;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Opis;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Namena";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 10;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = namena;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Datum";
            parameter5.SqlDbType = SqlDbType.DateTime;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Datum;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Korisnik";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 20;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Korisnik;
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
                throw new Exception("Neuspešan upis Vrste Robe u Bazu");
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

        public void DeletePozicija(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeletePozicija";
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
                    MessageBox.Show("Brisanje uspešno završeno", "",
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



