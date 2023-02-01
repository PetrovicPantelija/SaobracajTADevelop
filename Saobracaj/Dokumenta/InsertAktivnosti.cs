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
    /*  @ID int,
		   @Zaposleni int,
		   @VremeOd [datetime] ,
		   @VremeDo [datetime] ,
		   @Ukupno [decimal] (18,2),
		   @UkupniTroskovi [decimal] (18,2),
		   @Opis [nvarchar](500) ,
		   @RN [int]
            */
    

    class InsertAktivnosti
    {
        int Postoji = 0;
        string clientName = "";

        public void InsAktivnosti(int Zaposleni, DateTime VremeOd, DateTime VremeDo, double Ukupno, double UkupniTroskovi, string Opis, int RN, string Oznaka, double Racun, double Kartica, int Masinovodja, string Mesto, int milspedsmena, int TipRada, int MestoUpucivanja, int PravoDnevnice, string UserName, int OutSide)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertAktivnosti";
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

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Ukupno";
            parameter3.SqlDbType = SqlDbType.Decimal;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Ukupno;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@UkupniTroskovi";
            parameter4.SqlDbType = SqlDbType.Decimal;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = UkupniTroskovi;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Opis";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 500;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Opis;
            myCommand.Parameters.Add(parameter5);


            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@RN";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = RN;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Oznaka";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Oznaka;
            myCommand.Parameters.Add(parameter7);


            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Racun";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Racun;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Kartica";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Kartica;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Masinovodja";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Masinovodja;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Mesto";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 30;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Mesto;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Milsped";
            parameter12.SqlDbType = SqlDbType.TinyInt;
          
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = milspedsmena;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@TipRada";
            parameter13.SqlDbType = SqlDbType.Int;

            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = TipRada;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@MestoUpucivanja";
            parameter14.SqlDbType = SqlDbType.Int;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = MestoUpucivanja;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@PravoDnevnice";
            parameter15.SqlDbType = SqlDbType.Int;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = PravoDnevnice;
            myCommand.Parameters.Add(parameter15);


            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@UserName";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 30;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = UserName;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@OutSide";
            parameter17.SqlDbType = SqlDbType.Int;
    
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = OutSide;
            myCommand.Parameters.Add(parameter17);

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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void InsAktivnostiPrvi(int Zaposleni, DateTime VremeOd, DateTime VremeDo, double Ukupno, double UkupniTroskovi, string Opis, int RN, string Oznaka, double Racun, double Kartica, int Masinovodja, string Mesto, int milspedsmena, int TipRada, int MestoUpucivanja, int PravoDnevnice, string UserName, int OutSide)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertAktivnostiPrvi";
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

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Ukupno";
            parameter3.SqlDbType = SqlDbType.Decimal;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Ukupno;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@UkupniTroskovi";
            parameter4.SqlDbType = SqlDbType.Decimal;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = UkupniTroskovi;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Opis";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 500;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Opis;
            myCommand.Parameters.Add(parameter5);


            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@RN";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = RN;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Oznaka";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Oznaka;
            myCommand.Parameters.Add(parameter7);


            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Racun";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Racun;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Kartica";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Kartica;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Masinovodja";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Masinovodja;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Mesto";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 30;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Mesto;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Milsped";
            parameter12.SqlDbType = SqlDbType.TinyInt;

            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = milspedsmena;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@TipRada";
            parameter13.SqlDbType = SqlDbType.Int;

            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = TipRada;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@MestoUpucivanja";
            parameter14.SqlDbType = SqlDbType.Int;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = MestoUpucivanja;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@PravoDnevnice";
            parameter15.SqlDbType = SqlDbType.Int;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = PravoDnevnice;
            myCommand.Parameters.Add(parameter15);


            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@UserName";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 30;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = UserName;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@OutSide";
            parameter17.SqlDbType = SqlDbType.Int;

            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = OutSide;
            myCommand.Parameters.Add(parameter17);

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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }


        public void DeleteID()
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteAktivnostiID";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void InsID(int ID)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertAktivnostiID";
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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void InsAktivnotiZaglavlje()
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertAktivnostiZaglavljeID";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

           

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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }


        public Tuple<int> StoredProcWithOutPutParameter(int clientId, DateTime DatumOd, DateTime DatumDo)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ProveriAktivnostPostoji";
            cmd.Parameters.AddWithValue("@ID", clientId);
            cmd.Parameters.AddWithValue("@DatumOd", DatumOd);
            cmd.Parameters.AddWithValue("@DatumDo", DatumDo);

            cmd.Parameters.Add("@Postoji", SqlDbType.Int);
            cmd.Parameters["@Postoji"].Direction = ParameterDirection.Output;
        
            try
            {
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                //Storing the output parameters value in 3 different variables.  
                Postoji = Convert.ToInt32(cmd.Parameters["@Postoji"].Value);
                //clientName = Convert.ToString(cmd.Parameters["@ClientName"].Value);
               // dateCreated = Convert.ToDateTime(cmd.Parameters["@DateCreated"].Value);
                // Here we get all three values from database in above three variables.  
            }
            catch (Exception ex)
            {
                // throw the exception  
            }
            finally
            {
                conn.Close();
            }
            return new Tuple<int>(Postoji);
        }

        public void UpdAktivnosti(int ID, int Zaposleni, DateTime VremeOd, DateTime VremeDo, double Ukupno, double UkupniTroskovi, string Opis, int RN, string Oznaka, double Racun, double Kartica, int Masinovodja, string Mesto, int milspedsmena, int TipRada, int MestoUpucivanja)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAktivnosti";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);
            
            
            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Zaposleni";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Zaposleni;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@VremeOd";
            parameter2.SqlDbType = SqlDbType.DateTime;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = VremeOd;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@VremeDo";
            parameter3.SqlDbType = SqlDbType.DateTime;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = VremeDo;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Ukupno";
            parameter4.SqlDbType = SqlDbType.Decimal;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Ukupno;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@UkupniTroskovi";
            parameter5.SqlDbType = SqlDbType.Decimal;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = UkupniTroskovi;
            myCommand.Parameters.Add(parameter5);


            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Opis";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 500;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Opis;
            myCommand.Parameters.Add(parameter6);


            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@RN";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = RN;
            myCommand.Parameters.Add(parameter7);


            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Oznaka";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 20;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Oznaka;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Racun";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Racun;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10= new SqlParameter();
            parameter10.ParameterName = "@Kartica";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Kartica;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Masinovodja";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Masinovodja;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Mesto";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 30;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Mesto;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Milsped";
            parameter13.SqlDbType = SqlDbType.TinyInt;

            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = milspedsmena;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@TipRada";
            parameter14.SqlDbType = SqlDbType.Int;

            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = TipRada;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@MestoUpucivanja";
            parameter15.SqlDbType = SqlDbType.Int;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = MestoUpucivanja;
            myCommand.Parameters.Add(parameter15);

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

        public void UpdAktivnostiZarada(int ID,  double Izracun, double Razlika, double Zarada)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAktivnostiZarada";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Izracun";
            parameter4.SqlDbType = SqlDbType.Decimal;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Izracun;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Razlika";
            parameter5.SqlDbType = SqlDbType.Decimal;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Razlika;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Zarada";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Zarada;
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
                throw new Exception("Neuspešna upis  u Bazu");
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

        public void UpdatePoslaoMailAktivnosti(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAktivnostiPoslatMail";
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
                throw new Exception("Neuspešan upis aktivnosti u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspela promena aktivnosti", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdateAktivnostiPlaceno(int ID, DateTime VremePlaceno)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAktivnostiPlaceno";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@VremePlaceno";
            parameter1.SqlDbType = SqlDbType.DateTime;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = VremePlaceno;
            myCommand.Parameters.Add(parameter1);

 

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
                    MessageBox.Show("Nije uspela promena aktivnosti", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdateAktivnostiKontrolisanoSpoljno(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAktivnostiKontrolisanoSpoljno";
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
                throw new Exception("Neuspešan upis aktivnosti u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspela promena aktivnosti", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdateAktivnostiPlacenoRacuni(int ID, int Pregledao)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAktivnostiPlacenoRacuni";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Pregledao";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Pregledao;
            myCommand.Parameters.Add(parameter1);


         

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
                    MessageBox.Show("Nije uspela promena aktivnosti", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void UpdateAktivnostiPregledano(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAktivnostiPregledano";
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
                throw new Exception("Neuspešan upis aktivnosti u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspela promena aktivnosti", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void UpdateMasinovodja(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateMasinovodja";
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
                throw new Exception("Neuspešan upis aktivnosti u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspela promena aktivnosti", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void DeleteAktivnosti(int ID)
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
                    MessageBox.Show("Brisanje Teretnice uspešno završeno", "",
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
