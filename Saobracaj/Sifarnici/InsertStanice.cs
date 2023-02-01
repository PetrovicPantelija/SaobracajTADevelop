using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Saobracaj.Sifarnici
{
    class InsertStanice
    {
         public void InsStanice(string Opis, int Granicna, string Kod, string Drzava, double Longitude, double Latitude)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertStanice";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
         
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Opis";
            parameter.SqlDbType = SqlDbType.Char;
            parameter.Size = 50;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Opis;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Granicna";
            parameter2.SqlDbType = SqlDbType.TinyInt;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Granicna;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Kod";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 15;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Kod;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Drzava";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 3;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Drzava;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Longitude";
            parameter5.SqlDbType = SqlDbType.Float;
           // parameter5.Size = 3;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Longitude;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Latitude";
            parameter6.SqlDbType = SqlDbType.Float;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Latitude;
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
                throw new Exception("Neuspešan upis računa u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos stanice je uspesno zavrsen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }


         public void UpdStanice(int ID, string Opis, int Granicna, string Kod, string Drzava,  double Longitude, double Latitude)
         {
             var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
             SqlConnection myConnection = new SqlConnection(s_connection);
             SqlCommand myCommand = myConnection.CreateCommand();
             myCommand.CommandText = "UpdateStanice";
             myCommand.CommandType = System.Data.CommandType.StoredProcedure;

             SqlParameter parameter = new SqlParameter();
             parameter.ParameterName = "@ID";
             parameter.SqlDbType = SqlDbType.Int;
             parameter.Direction = ParameterDirection.Input;
             parameter.Value = ID;
             myCommand.Parameters.Add(parameter);


             SqlParameter parameter2 = new SqlParameter();
             parameter2.ParameterName = "@Opis"; 
             parameter2.SqlDbType = SqlDbType.Char;
             parameter2.Size = 35;
             parameter2.Direction = ParameterDirection.Input;
             parameter2.Value = Opis;
             myCommand.Parameters.Add(parameter2);

             SqlParameter parameter3 = new SqlParameter();
             parameter3.ParameterName = "@Granicna";
             parameter3.SqlDbType = SqlDbType.TinyInt;
             parameter3.Direction = ParameterDirection.Input;
             parameter3.Value = Granicna;
             myCommand.Parameters.Add(parameter3);

             SqlParameter parameter4 = new SqlParameter();
             parameter4.ParameterName = "@Kod";
             parameter4.SqlDbType = SqlDbType.Char;
             parameter4.Size = 15;
             parameter4.Direction = ParameterDirection.Input;
             parameter4.Value = Kod;
             myCommand.Parameters.Add(parameter4);

             SqlParameter parameter5 = new SqlParameter();
             parameter5.ParameterName = "@Drzava";
             parameter5.SqlDbType = SqlDbType.Char;
             parameter5.Size = 3;
             parameter5.Direction = ParameterDirection.Input;
             parameter5.Value = Drzava;
             myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Longitude";
            parameter6.SqlDbType = SqlDbType.Float;
            // parameter5.Size = 3;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Longitude;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Latitude";
            parameter7.SqlDbType = SqlDbType.Float;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Latitude;
            myCommand.Parameters.Add(parameter7);

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
                 throw new Exception("Neuspešan upis računa u bazu");
             }

             finally
             {
                 if (!error)
                 {
                     myTransaction.Commit();
                     MessageBox.Show("Unos stanice je uspesno zavrsen", "",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                 }
                 myConnection.Close();

                 if (error)
                 {
                     // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                 }
             }


         }


        public void DeleteStanice(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteStanice";
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
                    MessageBox.Show("Unos stanice je uspesno zavrsen", "",
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

