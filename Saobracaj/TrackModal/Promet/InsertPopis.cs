using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Testiranje.Promet
{
    class InsertPopis
    {
        public void InsPopis(DateTime DatumPopisa, string Napomena, DateTime Datum, string Korisnik)
        {
           /*  @DatumPopisa datetime
           ,@Napomena nvarchar(120)
           ,@Datum datetime
           ,@Korisnik nvarchar(20)
            */
            
         

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPopis";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@DatumPopisa";
            parameter0.SqlDbType = SqlDbType.DateTime;
            // parameter0.Size = 3;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = DatumPopisa;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Napomena";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 120;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Napomena;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Datum";
            parameter7.SqlDbType = SqlDbType.DateTime;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Datum;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Korisnik";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 20;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Korisnik;
            myCommand.Parameters.Add(parameter8);

          

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
                throw new Exception("Neuspešan upis u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdPopis(int ID, DateTime DatumPopisa, string Napomena, DateTime Datum, string Korisnik)
        {
            /*  @DatumPopisa datetime
            ,@Napomena nvarchar(120)
            ,@Datum datetime
            ,@Korisnik nvarchar(20)
             */



            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdatePopis";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter00 = new SqlParameter();
            parameter00.ParameterName = "@ID";
            parameter00.SqlDbType = SqlDbType.Int;
            // parameter0.Size = 3;
            parameter00.Direction = ParameterDirection.Input;
            parameter00.Value = ID;
            myCommand.Parameters.Add(parameter00);

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@DatumPopisa";
            parameter0.SqlDbType = SqlDbType.DateTime;
            // parameter0.Size = 3;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = DatumPopisa;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Napomena";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 120;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Napomena;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Datum";
            parameter7.SqlDbType = SqlDbType.DateTime;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Datum;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Korisnik";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 20;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Korisnik;
            myCommand.Parameters.Add(parameter8);



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
                throw new Exception("Neuspešan upis u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void DelPopis(int ID)
        {
            /*  @DatumPopisa datetime
            ,@Napomena nvarchar(120)
            ,@Datum datetime
            ,@Korisnik nvarchar(20)
             */



            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeletePopis";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter00 = new SqlParameter();
            parameter00.ParameterName = "@ID";
            parameter00.SqlDbType = SqlDbType.Int;
            parameter00.Direction = ParameterDirection.Input;
            parameter00.Value = ID;
            myCommand.Parameters.Add(parameter00);

           

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
                throw new Exception("Neuspešan upis u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void InsPopisStavke(int IDNadredjenog, string BrojKontejnera, int SkladisteU, int LokacijaU, DateTime Datum, string Korisnik)
        {
            /*  
                @IDNadredjenog [int],
	            @BrojKontejnera [nvarchar](20),
	            @SkladisteU [int],
	            @LokacijaU [int], 
	            @Datum datetime,
                @Korisnik nvarchar(20)
             */



            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPopisStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@IDNadredjenog";
            parameter0.SqlDbType = SqlDbType.Int;
            // parameter0.Size = 3;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = IDNadredjenog;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@BrojKontejnera";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 20;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = BrojKontejnera;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@SkladisteU";
            parameter1.SqlDbType = SqlDbType.Int;
          //  parameter1.Size = 20;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = SkladisteU;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@LokacijaU";
            parameter2.SqlDbType = SqlDbType.Int;
            //  parameter1.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = LokacijaU;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Datum";
            parameter7.SqlDbType = SqlDbType.DateTime;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Datum;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Korisnik";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 20;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Korisnik;
            myCommand.Parameters.Add(parameter8);



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
                throw new Exception("Neuspešan upis u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdPopisStavke(int ID, int IDNadredjenog, string BrojKontejnera, int SkladisteU, int LokacijaU, DateTime Datum, string Korisnik)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdatePopisStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter00 = new SqlParameter();
            parameter00.ParameterName = "@ID";
            parameter00.SqlDbType = SqlDbType.Int;
            // parameter0.Size = 3;
            parameter00.Direction = ParameterDirection.Input;
            parameter00.Value = ID;
            myCommand.Parameters.Add(parameter00);
            
            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@IDNadredjenog";
            parameter0.SqlDbType = SqlDbType.Int;
            // parameter0.Size = 3;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = IDNadredjenog;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@BrojKontejnera";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 20;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = BrojKontejnera;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@SkladisteU";
            parameter1.SqlDbType = SqlDbType.Int;
            //  parameter1.Size = 20;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = SkladisteU;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@LokacijaU";
            parameter2.SqlDbType = SqlDbType.Int;
            //  parameter1.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = LokacijaU;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Datum";
            parameter7.SqlDbType = SqlDbType.DateTime;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Datum;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Korisnik";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 20;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Korisnik;
            myCommand.Parameters.Add(parameter8);


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
                throw new Exception("Neuspešan upis u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void DelPopisStavke(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeletePopisStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter00 = new SqlParameter();
            parameter00.ParameterName = "@ID";
            parameter00.SqlDbType = SqlDbType.Int;
            // parameter0.Size = 3;
            parameter00.Direction = ParameterDirection.Input;
            parameter00.Value = ID;
            myCommand.Parameters.Add(parameter00);

 
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
                throw new Exception("Neuspešan upis u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void InsertPopisStavkeUporedni(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "SelectPopisStavkeUporedni";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter00 = new SqlParameter();
            parameter00.ParameterName = "@Dokument";
            parameter00.SqlDbType = SqlDbType.Int;
            // parameter0.Size = 3;
            parameter00.Direction = ParameterDirection.Input;
            parameter00.Value = ID;
            myCommand.Parameters.Add(parameter00);


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
                throw new Exception("Neuspešan upis u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis ", "",
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
