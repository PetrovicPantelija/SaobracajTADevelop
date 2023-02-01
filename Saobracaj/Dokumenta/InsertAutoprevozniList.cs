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
    class InsertAutoprevozniList
    {
        public void InsAutoprevozniList(int IDPutniNalog, int IDNalogZaPrevoz, int IDRadniNalog, int Platilac, string Kontakt, int Vozilo, DateTime Dana, string UtovarnoMesto, string IstovarnoMesto, int Primalac, string Ugovor, string Ponuda, string MestoIzdavanja, DateTime Datum)
        {


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertAutoPrevozniList";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDPutniNalog";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDPutniNalog;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDNalogZaPrevoz";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = IDNalogZaPrevoz;
            myCommand.Parameters.Add(parameter2);
           
             SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@IDRadniNalog";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = IDRadniNalog;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Platilac";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Platilac;
            myCommand.Parameters.Add(parameter4);

          SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Kontakt";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 100;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Kontakt;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Vozilo";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Vozilo;
            myCommand.Parameters.Add(parameter6);

         


            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Dana";
            parameter8.SqlDbType = SqlDbType.DateTime;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Dana;
            myCommand.Parameters.Add(parameter8);

          


         SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@UtovarnoMesto";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 50;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = UtovarnoMesto;
            myCommand.Parameters.Add(parameter15);

       

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@IstovarnoMesto";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 50;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = IstovarnoMesto;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Primalac";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Primalac;
            myCommand.Parameters.Add(parameter17);

          



           SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Ugovor";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 50;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Ugovor;
            myCommand.Parameters.Add(parameter18);

            

           SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Ponuda";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Ponuda;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@MestoIzdavanja";
            parameter20.SqlDbType = SqlDbType.NChar;
            parameter20.Size = 10;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = MestoIzdavanja;
            myCommand.Parameters.Add(parameter20);


            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Datum";
            parameter23.SqlDbType = SqlDbType.DateTime;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Datum;
            myCommand.Parameters.Add(parameter23);

          


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

        public void UpdAutoprevozniList(int ID, int IDPutniNalog, int IDNalogZaPrevoz, int IDRadniNalog, int Platilac, string Kontakt, int Vozilo, DateTime Dana, string UtovarnoMesto, string IstovarnoMesto, int Primalac, string Ugovor, string Ponuda, string MestoIzdavanja, DateTime Datum)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAutoprevoznilist";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);



            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDPutniNalog";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDPutniNalog;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDNalogZaPrevoz";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = IDNalogZaPrevoz;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@IDRadniNalog";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = IDRadniNalog;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Platilac";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Platilac;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Kontakt";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 100;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Kontakt;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Vozilo";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Vozilo;
            myCommand.Parameters.Add(parameter6);




            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Dana";
            parameter8.SqlDbType = SqlDbType.DateTime;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Dana;
            myCommand.Parameters.Add(parameter8);




            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@UtovarnoMesto";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 50;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = UtovarnoMesto;
            myCommand.Parameters.Add(parameter15);



            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@IstovarnoMesto";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 50;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = IstovarnoMesto;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Primalac";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Primalac;
            myCommand.Parameters.Add(parameter17);





            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Ugovor";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 50;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Ugovor;
            myCommand.Parameters.Add(parameter18);



            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Ponuda";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Ponuda;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@MestoIzdavanja";
            parameter20.SqlDbType = SqlDbType.NChar;
            parameter20.Size = 10;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = MestoIzdavanja;
            myCommand.Parameters.Add(parameter20);


            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Datum";
            parameter23.SqlDbType = SqlDbType.DateTime;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Datum;
            myCommand.Parameters.Add(parameter23);

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

        public void DelAutoprevozniList(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteAutoprevozniList";
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
                    MessageBox.Show("Brisanje Voza uspešno završeno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        ///End of zaglvlje
        ///

        public void InsAutoprevozniListGeneralni(int IDAutoprevozniList, string Korisnik, string TovList, string Racun, double Dencano, double Kolsko, double DencanoRSD, double OstaloRSD, string Primedba, string Potpisao)
        {


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertAutoPrevozniListGeneralni";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDAutoprevozniList";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDAutoprevozniList;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Korisnik";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 80;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Korisnik;
            myCommand.Parameters.Add(parameter2);


            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@TovList";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 50;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = TovList;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Racun";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Racun;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Dencano";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Dencano;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Kolsko";
            parameter7.SqlDbType = SqlDbType.Decimal;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Kolsko;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@DencanoRSD";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = DencanoRSD;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@OstaloRSD";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = OstaloRSD;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Primedba";
            parameter10.SqlDbType = SqlDbType.NVarChar;
            parameter10.Size = 180;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Primedba;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Potpisao";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 50;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Potpisao;
            myCommand.Parameters.Add(parameter11);




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

        public void UpdAutoprevozniListGeneralni(int ID, int IDAutoprevozniList, string Korisnik, string TovList, string Racun, double Dencano, double Kolsko, double DencanoRSD, double OstaloRSD, string Primedba, string Potpisao)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAutoprevoznilistGeneralni";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDAutoprevozniList";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDAutoprevozniList;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Korisnik";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 80;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Korisnik;
            myCommand.Parameters.Add(parameter2);


            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@TovList";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 50;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = TovList;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Racun";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Racun;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Dencano";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Dencano;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Kolsko";
            parameter7.SqlDbType = SqlDbType.Decimal;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Kolsko;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@DencanoRSD";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = DencanoRSD;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@OstaloRSD";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = OstaloRSD;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Primedba";
            parameter10.SqlDbType = SqlDbType.NVarChar;
            parameter10.Size = 180;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Primedba;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Potpisao";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 50;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Potpisao;
            myCommand.Parameters.Add(parameter11);

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

        public void DelAutoprevozniListGeneralni(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteAutoprevozniListGeneralni";
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
                    MessageBox.Show("Brisanje Voza uspešno završeno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }


        ///End of generalni
        ///

        public void InsAutoprevozniListKameni(int IDAutoprevozniList, string RelacijaOd, string RelacijaDo, string BrojOtpravljanja, double BrojVagona, double NetoMasa, DateTime DatumIstovara)
        {

          
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertAutoPrevozniListKameni";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDAutoprevozniList";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDAutoprevozniList;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@RelacijaOd";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 40;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = RelacijaOd;
            myCommand.Parameters.Add(parameter2);
        
            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@RelacijaDo";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 40;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = RelacijaDo;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@BrojOtpravljanja";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 40;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = BrojOtpravljanja;
            myCommand.Parameters.Add(parameter5);

          


            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@BrojVagona";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = BrojVagona;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@NetoMasa";
            parameter7.SqlDbType = SqlDbType.Decimal;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = NetoMasa;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@DatumIstovara";
            parameter11.SqlDbType = SqlDbType.DateTime;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = DatumIstovara;
            myCommand.Parameters.Add(parameter11);

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

        public void UpdAutoprevozniListKameni(int ID, int IDAutoprevozniList, string RelacijaOd, string RelacijaDo, string BrojOtpravljanja, double BrojVagona, double NetoMasa, DateTime DatumIstovara)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAutoprevoznilistKameni";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);
            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDAutoprevozniList";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDAutoprevozniList;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@RelacijaOd";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 40;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = RelacijaOd;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@RelacijaDo";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 40;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = RelacijaDo;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@BrojOtpravljanja";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 40;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = BrojOtpravljanja;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@BrojVagona";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = BrojVagona;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@NetoMasa";
            parameter7.SqlDbType = SqlDbType.Decimal;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = NetoMasa;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@DatumIstovara";
            parameter11.SqlDbType = SqlDbType.DateTime;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = DatumIstovara;
            myCommand.Parameters.Add(parameter11);

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

        public void DelAutoprevozniListKameni(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteAutoprevozniListKameni";
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
