using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Saobracaj.Testiranje
{
    class InsertTestovi
    {
        public void InsTestovi(string Naziv, DateTime Datum, int BrojTacnih, string BrResenja, string Mesto, int Komisija1, int Komisija2, int Komisija3)
        {
         
  


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertTestovi";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Naziv";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 20;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Naziv;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Datum";
            parameter1.SqlDbType = SqlDbType.DateTime;
            // parameter1.Size = 20;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Datum;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@BrojTacnih";
            parameter2.SqlDbType = SqlDbType.Int;
            // parameter1.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = BrojTacnih;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@BrResenja";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = BrResenja;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Mesto";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 50;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Mesto;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Komisija1";
            parameter5.SqlDbType = SqlDbType.Int;
          //  parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Komisija1;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Komisija2";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Komisija2;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Komisija3";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Komisija3;
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
                throw new Exception("Neuspešan upis tehnologije");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos tehnologije je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void UpdTestovi(int ID, string Naziv, DateTime Datum, int BrojTacnih, string BrResenja, string Mesto, int Komisija1, int Komisija2, int Komisija3)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTestovi";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Naziv";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 50;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Naziv;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Datum";
            parameter2.SqlDbType = SqlDbType.DateTime;
            // parameter1.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Datum;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@BrojTacnih";
            parameter3.SqlDbType = SqlDbType.Int;
            // parameter1.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = BrojTacnih;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@BrResenja";
            parameter30.SqlDbType = SqlDbType.NVarChar;
            parameter30.Size = 20;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = BrResenja;
            myCommand.Parameters.Add(parameter30);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Mesto";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 50;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Mesto;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Komisija1";
            parameter5.SqlDbType = SqlDbType.Int;
            //  parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Komisija1;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Komisija2";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Komisija2;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Komisija3";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Komisija3;
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
                throw new Exception("Neuspešna promena tehnologije");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Promena tehnologije je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void DeleteTehnologija(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteTehnologija";
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
                    MessageBox.Show("Brisanje nije uspešno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }


        public void InsTestoviOdgovori(int IDNadredjenog, string Opis, int RBBroj)
        {
           


             var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertTestoviPitanjaOdgovor";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDNadredjenog";
            parameter.SqlDbType = SqlDbType.Int;
           // parameter.Size = 20;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = IDNadredjenog;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Opis";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 100;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Opis;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@RBBroj";
            parameter2.SqlDbType = SqlDbType.Int;
            // parameter1.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = RBBroj;
            myCommand.Parameters.Add(parameter2);

          

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
                throw new Exception("Neuspešan upis tehnologije");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos tehnologije je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void DelTestoviOdgovori(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteTestoviPitanjaOdgovor";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            // parameter.Size = 20;
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
                throw new Exception("Neuspešan upis tehnologije");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos tehnologije je uspešno završena", "",
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
