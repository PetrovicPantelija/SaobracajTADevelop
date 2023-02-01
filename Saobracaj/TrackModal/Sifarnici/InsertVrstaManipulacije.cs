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
    class InsertVrstaManipulacije
    {

          public void InsVrstaManipulacije(string Naziv ,DateTime  Datum , string Korisnik, string JM, int UticeSkladisno, string JM2, int TipManipulacije)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertVrstaManipulacije";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Naziv";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Naziv;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Datum";
            parameter4.SqlDbType = SqlDbType.DateTime;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Datum;
            myCommand.Parameters.Add(parameter4);

             SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Korisnik";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 20;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Korisnik;
            myCommand.Parameters.Add(parameter5);


            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@JM";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 10;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = JM;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@UticeSkladisno";
            parameter7.SqlDbType = SqlDbType.TinyInt;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = UticeSkladisno;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@JM2";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 10;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = JM2;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@TipManipulacije";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = TipManipulacije;
            myCommand.Parameters.Add(parameter9);

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
                throw new Exception("Neuspešan upis manipulacije u bazu");
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

          public void UpdVrstaManipulacije(int ID, string Naziv ,DateTime  Datum , string Korisnik, string JM, int UticeSkladisno, string JM2, int TipManipulacije)
            {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateVrstaManipulacije";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Naziv";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Naziv;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Datum";
            parameter4.SqlDbType = SqlDbType.DateTime;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Datum;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Korisnik";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 20;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Korisnik;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@JM";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 10;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = JM;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@UticeSkladisno";
            parameter7.SqlDbType = SqlDbType.TinyInt;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = UticeSkladisno;
            myCommand.Parameters.Add(parameter7);


            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@JM2";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 10;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = JM2;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@TipManipulacije";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = TipManipulacije;
            myCommand.Parameters.Add(parameter9);


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
                throw new Exception("Neuspešan upis aktivnosti u Bazu");
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

          public void DeleteVrstaManipulacije(int ID)
          {
              var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
              SqlConnection myConnection = new SqlConnection(s_connection);
              SqlCommand myCommand = myConnection.CreateCommand();
              myCommand.CommandText = "DeleteVrstaManipulacije";
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
                      MessageBox.Show("Brisanje Cena uspešno završeno", "",
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
