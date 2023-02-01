
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Projekat
{
    class InsertCene
    {

          public void InsCene(int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertCene";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

               



            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@TipCenovnika";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = TipCenovnika;
            myCommand.Parameters.Add(parameter);

              SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Komitent";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value =  Komitent;
            myCommand.Parameters.Add(parameter1);

              SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Cena";
            parameter2.SqlDbType = SqlDbType.Decimal;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Cena;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@VrstaManipulacije";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = VrstaManipulacije;
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

          public void UpdCene(int ID, int TipCenovnika ,int Komitent, double Cena , int VrstaManipulacije ,DateTime  Datum , string Korisnik)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateCene";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);
            
            
           
            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@TipCenovnika";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = TipCenovnika;
            myCommand.Parameters.Add(parameter1);

              SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Komitent";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Komitent;
            myCommand.Parameters.Add(parameter2);

              SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Cena";
            parameter3.SqlDbType = SqlDbType.Decimal;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Cena;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@VrstaManipulacije";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = VrstaManipulacije;
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

          public void DeleteCene(int ID)
          {
              var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
              SqlConnection myConnection = new SqlConnection(s_connection);
              SqlCommand myCommand = myConnection.CreateCommand();
              myCommand.CommandText = "DeleteAktivnosti";
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









