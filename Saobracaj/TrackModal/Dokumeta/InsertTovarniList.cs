using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Testiranje.Dokumeta
{
    class InsertTovarniList
    {
        public void InsTovarniList(int Posiljalac, int Primalac, string KorisnickaSIfraPosiljalac, string KorisnickaSifraPrimalac, string FrankiraneTroskove, string NeFrankiraneTroskove, string IzjavePosiljaoca, string ObavestenjePosiljaoca, string Prilozi, int MestoIzdavanja, string SifraMestaIzdavanja, string SifraStaniceMestaIzdavanja, string KomercijalniUslovi, string KorisnickiSporazum, string ObavestenjePrimaocu, string PreuzimanjeNaPrevoz, string BrojKola, string FakturisanjeTranzita, string PlacanjeTroskova, string NarocitaPosiljka, string RID, double Vrednost, double BrutoMasaRobe, double NetoRobe, double BrutoMasaVoza, string ObezbedjenjeIsporuke, string Pouzece, string MestoIspostavljanja, DateTime DatumIspostavljanja, string OznakaDokumenta, string CIMBroj, string VrstaRobe, string NHM, string MestoPreuzimanja)
        {
         
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertTovarniList";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Posiljalac ";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Posiljalac;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Primalac";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Primalac;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@KorisnickaSIfraPosiljalac";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = KorisnickaSIfraPosiljalac;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@KorisnickaSifraPrimalac";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 20;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = KorisnickaSifraPrimalac;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@FrankiraneTroskove";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = FrankiraneTroskove;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@NeFrankiraneTroskove";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 50;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = NeFrankiraneTroskove;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@IzjavePosiljaoca";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 100;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = IzjavePosiljaoca;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@ObavestenjePosiljaoca";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 100;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = ObavestenjePosiljaoca;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Prilozi";
            parameter9.SqlDbType = SqlDbType.NVarChar;
            parameter9.Size = 100;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Prilozi;
            myCommand.Parameters.Add(parameter9);


            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@MestoIzdavanja";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = MestoIzdavanja;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@SifraMestaIzdavanja";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 20;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = SifraMestaIzdavanja;
            myCommand.Parameters.Add(parameter11);



            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@SifraStaniceMestaIzdavanja";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 50;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = SifraStaniceMestaIzdavanja;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@KomercijalniUslovi";
            parameter13.SqlDbType = SqlDbType.NVarChar;
            parameter13.Size = 150;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = KomercijalniUslovi;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@KorisnickiSporazum";
            parameter14.SqlDbType = SqlDbType.NVarChar;
            parameter14.Size = 50;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = KorisnickiSporazum;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@ObavestenjePrimaocu";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 50;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = ObavestenjePrimaocu;
            myCommand.Parameters.Add(parameter15);


            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@PreuzimanjeNaPrevoz";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 50;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = PreuzimanjeNaPrevoz;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@BrojKola";
            parameter17.SqlDbType = SqlDbType.NVarChar;
            parameter17.Size = 50;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = BrojKola;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@FakturisanjeTranzita";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = FakturisanjeTranzita;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@PlacanjeTroskova";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = PlacanjeTroskova;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@NarocitaPosiljka";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 5;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = NarocitaPosiljka;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@RID";
            parameter21.SqlDbType = SqlDbType.NVarChar;
            parameter21.Size = 5;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = RID;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Vrednost";
            parameter22.SqlDbType = SqlDbType.Decimal;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Vrednost;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@BrutoMasaRobe";
            parameter23.SqlDbType = SqlDbType.Decimal;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = BrutoMasaRobe;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@NetoRobe";
            parameter24.SqlDbType = SqlDbType.Decimal;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = NetoRobe;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@BrutoMasaVoza";
            parameter25.SqlDbType = SqlDbType.Decimal;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = BrutoMasaVoza;
            myCommand.Parameters.Add(parameter25);

            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@ObezbedjenjeIsporuke";
            parameter26.SqlDbType = SqlDbType.NVarChar;
            parameter26.Size = 50;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = ObezbedjenjeIsporuke;
            myCommand.Parameters.Add(parameter26);

            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@Pouzece";
            parameter27.SqlDbType = SqlDbType.NVarChar;
            parameter27.Size = 20;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = Pouzece;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@MestoIspostavljanja";
            parameter28.SqlDbType = SqlDbType.NVarChar;
            parameter28.Size = 50;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = MestoIspostavljanja;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@DatumIspostavljanja";
            parameter29.SqlDbType = SqlDbType.DateTime;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = DatumIspostavljanja;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@OznakaDokumenta";
            parameter30.SqlDbType = SqlDbType.NVarChar;
            parameter30.Size = 50;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = OznakaDokumenta;
            myCommand.Parameters.Add(parameter30);

            SqlParameter parameter31 = new SqlParameter();
            parameter31.ParameterName = "@CIMBroj";
            parameter31.SqlDbType = SqlDbType.NVarChar;
            parameter31.Size = 30;
            parameter31.Direction = ParameterDirection.Input;
            parameter31.Value = CIMBroj;
            myCommand.Parameters.Add(parameter31);

            SqlParameter parameter32 = new SqlParameter();
            parameter32.ParameterName = "@VrstaRobe";
            parameter32.SqlDbType = SqlDbType.NVarChar;
            parameter32.Size = 200;
            parameter32.Direction = ParameterDirection.Input;
            parameter32.Value = VrstaRobe;
            myCommand.Parameters.Add(parameter32);

            SqlParameter parameter33 = new SqlParameter();
            parameter33.ParameterName = "@NHM";
            parameter33.SqlDbType = SqlDbType.NVarChar;
            parameter33.Size = 40;
            parameter33.Direction = ParameterDirection.Input;
            parameter33.Value = NHM;
            myCommand.Parameters.Add(parameter33);

            SqlParameter parameter34 = new SqlParameter();
            parameter34.ParameterName = "@Mestopreuzimanja";
            parameter34.SqlDbType = SqlDbType.NVarChar;
            parameter34.Size = 50;
            parameter34.Direction = ParameterDirection.Input;
            parameter34.Value = MestoPreuzimanja;
            myCommand.Parameters.Add(parameter34);

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

        public void UpdTovarniList(int ID, int Posiljalac, int Primalac, string KorisnickaSIfraPosiljalac, string KorisnickaSifraPrimalac, string FrankiraneTroskove, string NeFrankiraneTroskove, string IzjavePosiljaoca, string ObavestenjePosiljaoca, string Prilozi, int MestoIzdavanja, string SifraMestaIzdavanja, string SifraStaniceMestaIzdavanja, string KomercijalniUslovi, string KorisnickiSporazum, string ObavestenjePrimaocu, string PreuzimanjeNaPrevoz, string BrojKola, string FakturisanjeTranzita, string PlacanjeTroskova, string NarocitaPosiljka, string RID, double Vrednost, double BrutoMasaRobe, double NetoRobe, double BrutoMasaVoza, string ObezbedjenjeIsporuke, string Pouzece, string MestoIspostavljanja, DateTime DatumIspostavljanja, string OznakaDokumenta, string CIMBroj, string VrstaRobe, string NHM, string MestoPreuzimanja)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTovarniList";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);



            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Posiljalac ";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Posiljalac;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Primalac";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Primalac;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@KorisnickaSIfraPosiljalac";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = KorisnickaSIfraPosiljalac;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@KorisnickaSifraPrimalac";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 20;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = KorisnickaSifraPrimalac;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@FrankiraneTroskove";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = FrankiraneTroskove;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@NeFrankiraneTroskove";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 50;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = NeFrankiraneTroskove;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@IzjavePosiljaoca";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 100;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = IzjavePosiljaoca;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@ObavestenjePosiljaoca";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 100;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = ObavestenjePosiljaoca;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Prilozi";
            parameter9.SqlDbType = SqlDbType.NVarChar;
            parameter9.Size = 100;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Prilozi;
            myCommand.Parameters.Add(parameter9);


            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@MestoIzdavanja";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = MestoIzdavanja;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@SifraMestaIzdavanja";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 20;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = SifraMestaIzdavanja;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@SifraStaniceMestaIzdavanja";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 50;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = SifraStaniceMestaIzdavanja;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@KomercijalniUslovi";
            parameter13.SqlDbType = SqlDbType.NVarChar;
            parameter13.Size = 150;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = KomercijalniUslovi;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@KorisnickiSporazum";
            parameter14.SqlDbType = SqlDbType.NVarChar;
            parameter14.Size = 50;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = KorisnickiSporazum;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@ObavestenjePrimaocu";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 50;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = ObavestenjePrimaocu;
            myCommand.Parameters.Add(parameter15);


            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@PreuzimanjeNaPrevoz";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 50;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = PreuzimanjeNaPrevoz;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@BrojKola";
            parameter17.SqlDbType = SqlDbType.NVarChar;
            parameter17.Size = 50;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = BrojKola;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@FakturisanjeTranzita";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = FakturisanjeTranzita;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@PlacanjeTroskova";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = PlacanjeTroskova;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@NarocitaPosiljka";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 5;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = NarocitaPosiljka;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@RID";
            parameter21.SqlDbType = SqlDbType.NVarChar;
            parameter21.Size = 5;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = RID;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Vrednost";
            parameter22.SqlDbType = SqlDbType.Decimal;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Vrednost;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@BrutoMasaRobe";
            parameter23.SqlDbType = SqlDbType.Decimal;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = BrutoMasaRobe;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@NetoRobe";
            parameter24.SqlDbType = SqlDbType.Decimal;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = NetoRobe;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@BrutoMasaVoza";
            parameter25.SqlDbType = SqlDbType.Decimal;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = BrutoMasaVoza;
            myCommand.Parameters.Add(parameter25);

            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@ObezbedjenjeIsporuke";
            parameter26.SqlDbType = SqlDbType.NVarChar;
            parameter26.Size = 50;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = ObezbedjenjeIsporuke;
            myCommand.Parameters.Add(parameter26);

            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@Pouzece";
            parameter27.SqlDbType = SqlDbType.NVarChar;
            parameter27.Size = 20;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = Pouzece;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@MestoIspostavljanja";
            parameter28.SqlDbType = SqlDbType.NVarChar;
            parameter28.Size = 50;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = MestoIspostavljanja;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@DatumIspostavljanja";
            parameter29.SqlDbType = SqlDbType.DateTime;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = DatumIspostavljanja;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@OznakaDokumenta";
            parameter30.SqlDbType = SqlDbType.NVarChar;
            parameter30.Size = 50;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = OznakaDokumenta;
            myCommand.Parameters.Add(parameter30);


            SqlParameter parameter31 = new SqlParameter();
            parameter31.ParameterName = "@CIMBroj";
            parameter31.SqlDbType = SqlDbType.NVarChar;
            parameter31.Size = 30;
            parameter31.Direction = ParameterDirection.Input;
            parameter31.Value = CIMBroj;
            myCommand.Parameters.Add(parameter31);

            SqlParameter parameter32 = new SqlParameter();
            parameter32.ParameterName = "@VrstaRobe";
            parameter32.SqlDbType = SqlDbType.NVarChar;
            parameter32.Size = 200;
            parameter32.Direction = ParameterDirection.Input;
            parameter32.Value = VrstaRobe;
            myCommand.Parameters.Add(parameter32);

            SqlParameter parameter33 = new SqlParameter();
            parameter33.ParameterName = "@NHM";
            parameter33.SqlDbType = SqlDbType.NVarChar;
            parameter33.Size = 40;
            parameter33.Direction = ParameterDirection.Input;
            parameter33.Value = NHM;
            myCommand.Parameters.Add(parameter33);

            SqlParameter parameter35 = new SqlParameter();
            parameter35.ParameterName = "@Mestopreuzimanja";
            parameter35.SqlDbType = SqlDbType.NVarChar;
            parameter35.Size = 50;
            parameter35.Direction = ParameterDirection.Input;
            parameter35.Value = MestoPreuzimanja;
            myCommand.Parameters.Add(parameter35);

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

        public void DelTovarniList(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteTovarniList";
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
