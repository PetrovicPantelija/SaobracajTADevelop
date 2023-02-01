

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
    class InsertOtprema
    {

        public void InsertOtp( DateTime DatumOtpreme,int StatusOtpreme,int IdVoza, string RegBrKamiona, string ImeVozaca 	 , DateTime VremeOdlaska, int NacinOtpreme,	DateTime Datum, string Korisnik, string Napomena, int PredefinisanePorukeID)
        {
            /*
            	@DatumOtpreme [datetime] ,
	@StatusOtpreme [int] ,
	@IdVoza [int] ,
	@RegBrKamiona nvarchar(20),
	@ImeVozaca nvarchar(50),
	@VremeOdlaska [datetime] ,
	@NacinOtpreme tinyint,
	@Datum [datetime] ,
	@Korisnik [nvarchar](20) 
             * */
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertOtpremaKontejnera";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            
            
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@DatumOtpreme";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = DatumOtpreme;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@StatusOtpreme";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = StatusOtpreme;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter01 = new SqlParameter();
            parameter01.ParameterName = "@IdVoza";
            parameter01.SqlDbType = SqlDbType.Int;
            parameter01.Direction = ParameterDirection.Input;
            parameter01.Value = IdVoza;
            myCommand.Parameters.Add(parameter01);

           


            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@RegBrKamiona";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = RegBrKamiona;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@ImeVozaca";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 20;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = ImeVozaca;
            myCommand.Parameters.Add(parameter4);

          

           

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@VremeOdlaska";
            parameter15.SqlDbType = SqlDbType.DateTime;
            // parameter13.Size = 30;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = VremeOdlaska;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@NacinOtpreme";
            parameter16.SqlDbType = SqlDbType.TinyInt;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = NacinOtpreme;
            myCommand.Parameters.Add(parameter16);

          

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Datum";
            parameter18.SqlDbType = SqlDbType.DateTime;
          
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Datum;
            myCommand.Parameters.Add(parameter18);
            
            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Korisnik";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 20;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Korisnik;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Napomena";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 300;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Napomena;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@PredefinisanePorukeID";
            parameter21.SqlDbType = SqlDbType.Int;
            //parameter20.Size = 300;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = PredefinisanePorukeID;
            myCommand.Parameters.Add(parameter21);




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
                throw new Exception("Neuspešan upis  u bazu");
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

        public void UpdOtpremaKontejnera(int ID, DateTime DatumOtpreme, int StatusOtpreme, int IdVoza, string RegBrKamiona, string ImeVozaca, DateTime VremeOdlaska, int NacinOtpreme, DateTime Datum, string Korisnik, string Napomena, int PredefinisanePorukeID)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateOtpremaKontejnera";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);


            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@DatumOtpreme";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = DatumOtpreme;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@StatusOtpreme";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = StatusOtpreme;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter01 = new SqlParameter();
            parameter01.ParameterName = "@IdVoza";
            parameter01.SqlDbType = SqlDbType.Int;
            parameter01.Direction = ParameterDirection.Input;
            parameter01.Value = IdVoza;
            myCommand.Parameters.Add(parameter01);




            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@RegBrKamiona";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = RegBrKamiona;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@ImeVozaca";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 20;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = ImeVozaca;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@VremeOdlaska";
            parameter15.SqlDbType = SqlDbType.DateTime;
            // parameter13.Size = 30;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = VremeOdlaska;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@NacinOtpreme";
            parameter16.SqlDbType = SqlDbType.TinyInt;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = NacinOtpreme;
            myCommand.Parameters.Add(parameter16);



            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Datum";
            parameter18.SqlDbType = SqlDbType.DateTime;

            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Datum;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Korisnik";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 20;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Korisnik;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Napomena";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 300;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Napomena;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@PredefinisanePorukeID";
            parameter21.SqlDbType = SqlDbType.Int;
            //parameter20.Size = 300;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = PredefinisanePorukeID;
            myCommand.Parameters.Add(parameter21);


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
                throw new Exception("Neuspešan upis u Bazu");
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

          public void DeleteOtpremaKontejnera(int ID)
          {
              var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
              SqlConnection myConnection = new SqlConnection(s_connection);
              SqlCommand myCommand = myConnection.CreateCommand();
              myCommand.CommandText = "DeleteOtpremaKontejnera";
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

        public void UpdateEmailOtpremaNajava(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateEmailOtpremaNajava";
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

        public void UpdateEmailOtpremaOtprema(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateEmailOtpremaOtprema";
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

        public void UpdateZatvorenOtpremaCheck(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateZatvorenOtpremaCheck";
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



