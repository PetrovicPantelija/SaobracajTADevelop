

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
    class InsertPromet
    {

       public void InsProm(DateTime DatumTransakcije, string VrstaDokumenta,int PrStDokumenta,string BrojKontejnera,string PrSifVrstePrometa, double PrPrimKol, double PrIzdKol, int SkladisteU,int LokacijaU, int SkladisteIz, int LokacijaIz, string PrOznSled, DateTime Datum, string Korisnik, int SredstvoRada, int Zaposleni, DateTime DatumRasporeda )
        {
            /*
            	@VrstaDokumenta [char](3),
	                        @PrStDokumenta [int],
	                        @BrojKontejnera [int],
	                        @PrSifVrstePrometa [char](3),
	                        @PrPrimKol [decimal](18, 2) ,
	                        @PrIzdKol [decimal](18, 2) ,
	                        @SkladisteU [int],
	                        @LokacijaU int  ,
	                        @SkladisteIz [int] ,
	                        @LokacijaIz int  ,
	                        @PrOznSled [nvarchar](35),
	                        @Datum [datetime],
	                        @Korisnik [char](20)

            */

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPromet";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@DatumTransakcije";
            parameter0.SqlDbType = SqlDbType.DateTime;
           // parameter0.Size = 3;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = DatumTransakcije;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@VrstaDokumenta";
            parameter.SqlDbType = SqlDbType.Char;
            parameter.Size = 3;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = VrstaDokumenta;
            myCommand.Parameters.Add(parameter);

           

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@PrStDokumenta";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = PrStDokumenta;
            myCommand.Parameters.Add(parameter2);


            SqlParameter parameter2a = new SqlParameter();
            parameter2a.ParameterName = "@BrojKontejnera";
            parameter2a.SqlDbType = SqlDbType.NVarChar;
            parameter2a.Size = 20;
            parameter2a.Direction = ParameterDirection.Input;
            parameter2a.Value = BrojKontejnera;
            myCommand.Parameters.Add(parameter2a);

            SqlParameter parameter2aa = new SqlParameter();
            parameter2aa.ParameterName = "@PrSifVrstePrometa";
            parameter2aa.SqlDbType = SqlDbType.Char;
            parameter2aa.Size = 3;
            parameter2aa.Direction = ParameterDirection.Input;
            parameter2aa.Value = PrSifVrstePrometa;
            myCommand.Parameters.Add(parameter2aa);

            SqlParameter parameter2a1 = new SqlParameter();
            parameter2a1.ParameterName = "@PrPrimKol";
            parameter2a1.SqlDbType = SqlDbType.Decimal;
            //parameter2a1.Size = 100;
            parameter2a1.Direction = ParameterDirection.Input;
            parameter2a1.Value = PrPrimKol;
            myCommand.Parameters.Add(parameter2a1);

            //LicencaVaziDo
            SqlParameter parameter2a2 = new SqlParameter();
            parameter2a2.ParameterName = "@PrIzdKol";
            parameter2a2.SqlDbType = SqlDbType.Decimal;
           // parameter2a2.Size = 100;
            parameter2a2.Direction = ParameterDirection.Input;
            parameter2a2.Value = PrIzdKol;
            myCommand.Parameters.Add(parameter2a2);

            SqlParameter parameter2a3 = new SqlParameter();
            parameter2a3.ParameterName = "@SkladisteU";
            parameter2a3.SqlDbType = SqlDbType.Int;
            //parameter2a3.Size = 100;
            parameter2a3.Direction = ParameterDirection.Input;
            parameter2a3.Value = SkladisteU;
            myCommand.Parameters.Add(parameter2a3);

          SqlParameter parameter2a4 = new SqlParameter();
            parameter2a4.ParameterName = "@LokacijaU";
            parameter2a4.SqlDbType = SqlDbType.Int;
            //parameter2a3.Size = 100;
            parameter2a4.Direction = ParameterDirection.Input;
            parameter2a4.Value = LokacijaU;
            myCommand.Parameters.Add(parameter2a4);

             SqlParameter parameter2a5 = new SqlParameter();
            parameter2a5.ParameterName = "@SkladisteIz";
            parameter2a5.SqlDbType = SqlDbType.Int;
            //parameter2a3.Size = 100;
            parameter2a5.Direction = ParameterDirection.Input;
            parameter2a5.Value = SkladisteIz;
            myCommand.Parameters.Add(parameter2a5);

          SqlParameter parameter2a6 = new SqlParameter();
            parameter2a6.ParameterName = "@LokacijaIz";
            parameter2a6.SqlDbType = SqlDbType.Int;
            //parameter2a3.Size = 100;
            parameter2a6.Direction = ParameterDirection.Input;
            parameter2a6.Value = LokacijaIz;
            myCommand.Parameters.Add(parameter2a6);

            SqlParameter parameter2a7 = new SqlParameter();
            parameter2a7.ParameterName = "@PrOznSled";
            parameter2a7.SqlDbType = SqlDbType.NVarChar;
            parameter2a7.Size = 35;
            parameter2a7.Direction = ParameterDirection.Input;
            parameter2a7.Value = PrOznSled;
            myCommand.Parameters.Add(parameter2a7);

          
            
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

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@SredstvoRada";
            parameter9.SqlDbType = SqlDbType.Int;
            //parameter2a3.Size = 100;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = SredstvoRada;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Zaposleni";
            parameter10.SqlDbType = SqlDbType.Int;
            //parameter2a3.Size = 100;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Zaposleni;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@DatumRasporeda";
            parameter11.SqlDbType = SqlDbType.DateTime;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = DatumRasporeda;
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

       public void InsPromMan( int PRStDokumenta  , string BrojKontejnera  ,int ManipulacijaID ,int NajavaID ,int SredstvoRada ,int Zaposleni ,DateTime Datum,string @Korisnik, string SkladisteIz, string PozicijaIz, string SkladisteU, string PozicijaU)
       {
           var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(s_connection);
           SqlCommand myCommand = myConnection.CreateCommand();
           myCommand.CommandText = "InsertPrometManipulacije";
           myCommand.CommandType = System.Data.CommandType.StoredProcedure;

           SqlParameter parameter = new SqlParameter();
           parameter.ParameterName = "@PRStDokumenta";
           parameter.SqlDbType = SqlDbType.Int;
           // parameter0.Size = 3;
           parameter.Direction = ParameterDirection.Input;
           parameter.Value = PRStDokumenta;
           myCommand.Parameters.Add(parameter);

           SqlParameter parameter1 = new SqlParameter();
           parameter1.ParameterName = "@BrojKontejnera";
           parameter1.SqlDbType = SqlDbType.NVarChar;
           parameter1.Size = 20;
           parameter1.Direction = ParameterDirection.Input;
           parameter1.Value = BrojKontejnera;
           myCommand.Parameters.Add(parameter1);


           SqlParameter parameter2 = new SqlParameter();
           parameter2.ParameterName = "@ManipulacijaID";
           parameter2.SqlDbType = SqlDbType.Int;
           parameter2.Direction = ParameterDirection.Input;
           parameter2.Value = ManipulacijaID;
           myCommand.Parameters.Add(parameter2);

           SqlParameter parameter3 = new SqlParameter();
           parameter3.ParameterName = "@NajavaID";
           parameter3.SqlDbType = SqlDbType.Int;
           //parameter2a3.Size = 100;
           parameter3.Direction = ParameterDirection.Input;
           parameter3.Value = NajavaID;
           myCommand.Parameters.Add(parameter3);

           SqlParameter parameter4 = new SqlParameter();
           parameter4.ParameterName = "@SredstvoRada";
           parameter4.SqlDbType = SqlDbType.Int;
           //parameter2a3.Size = 100;
           parameter4.Direction = ParameterDirection.Input;
           parameter4.Value = SredstvoRada;
           myCommand.Parameters.Add(parameter4);

           SqlParameter parameter5 = new SqlParameter();
           parameter5.ParameterName = "@Zaposleni";
           parameter5.SqlDbType = SqlDbType.Int;
           //parameter2a3.Size = 100;
           parameter5.Direction = ParameterDirection.Input;
           parameter5.Value = Zaposleni;
           myCommand.Parameters.Add(parameter5);


           SqlParameter parameter6 = new SqlParameter();
           parameter6.ParameterName = "@Datum";
           parameter6.SqlDbType = SqlDbType.DateTime;
           parameter6.Direction = ParameterDirection.Input;
           parameter6.Value = Datum;
           myCommand.Parameters.Add(parameter6);

           SqlParameter parameter7 = new SqlParameter();
           parameter7.ParameterName = "@Korisnik";
           parameter7.SqlDbType = SqlDbType.NVarChar;
           parameter7.Size = 20;
           parameter7.Direction = ParameterDirection.Input;
           parameter7.Value = Korisnik;
           myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@SkladisteIz";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 100;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = SkladisteIz;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@PozicijaIz";
            parameter9.SqlDbType = SqlDbType.NVarChar;
            parameter9.Size = 20;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = PozicijaIz;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@SkladisteU";
            parameter10.SqlDbType = SqlDbType.NVarChar;
            parameter10.Size = 100;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = SkladisteU;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@PozicijaU";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 20;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = PozicijaU;
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

       public void UpdProm(int ID, string Naziv, string IndividualniBroj, string LicencaBroj, DateTime LicencaVaziDo, string Namena, string Vrsta, int BrojOsovina, string RegistarskaOznaka, DateTime GodinaProizvodnje, double SopstvenaTezina, DateTime NarednaREgistracija, DateTime SetomesecniTehnicki, DateTime GodisnjiTehnicki, DateTime TahografSertifikat, DateTime PPAparat, DateTime Servis, DateTime Atest, double Nosivost, string Napomena, string SifraERP, DateTime Datum, string Korisnik, int UradjenTromesecni, int UradjenSetomesecni, int UradjenServis, DateTime DatumUradjenTromesecni, DateTime DatumUradjenSetomesecni, DateTime DatumUradjenServis, DateTime DatumUradjenGodisnji, DateTime TromesecniTehnicki, int UradjenGodisnji)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateVozila";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Naziv";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 100;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Naziv;
            myCommand.Parameters.Add(parameter);



            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IndividualniBroj";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 10;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = IndividualniBroj;
            myCommand.Parameters.Add(parameter2);


            SqlParameter parameter2a = new SqlParameter();
            parameter2a.ParameterName = "@LicencaBroj";
            parameter2a.SqlDbType = SqlDbType.NVarChar;
            parameter2a.Size = 100;
            parameter2a.Direction = ParameterDirection.Input;
            parameter2a.Value = LicencaBroj;
            myCommand.Parameters.Add(parameter2a);

            SqlParameter parameter2a1 = new SqlParameter();
            parameter2a1.ParameterName = "@LicencaVaziDo";
            parameter2a1.SqlDbType = SqlDbType.DateTime;
            //parameter2a1.Size = 100;
            parameter2a1.Direction = ParameterDirection.Input;
            parameter2a1.Value = LicencaVaziDo;
            myCommand.Parameters.Add(parameter2a1);

            //LicencaVaziDo
            SqlParameter parameter2a2 = new SqlParameter();
            parameter2a2.ParameterName = "@Namena";
            parameter2a2.SqlDbType = SqlDbType.NVarChar;
            parameter2a2.Size = 100;
            parameter2a2.Direction = ParameterDirection.Input;
            parameter2a2.Value = Namena;
            myCommand.Parameters.Add(parameter2a2);

            SqlParameter parameter2a3 = new SqlParameter();
            parameter2a3.ParameterName = "@Vrsta";
            parameter2a3.SqlDbType = SqlDbType.NVarChar;
            parameter2a3.Size = 100;
            parameter2a3.Direction = ParameterDirection.Input;
            parameter2a3.Value = Vrsta;
            myCommand.Parameters.Add(parameter2a3);

            SqlParameter parameter2a4 = new SqlParameter();
            parameter2a4.ParameterName = "@BrojOsovina";
            parameter2a4.SqlDbType = SqlDbType.Int;
            //  parameter2a4.Size = 100;
            parameter2a4.Direction = ParameterDirection.Input;
            parameter2a4.Value = BrojOsovina;
            myCommand.Parameters.Add(parameter2a4);

            SqlParameter parameter2a5 = new SqlParameter();
            parameter2a5.ParameterName = "RegistarskaOznaka";
            parameter2a5.SqlDbType = SqlDbType.NVarChar;
            parameter2a5.Size = 100;
            parameter2a5.Direction = ParameterDirection.Input;
            parameter2a5.Value = RegistarskaOznaka;
            myCommand.Parameters.Add(parameter2a5);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@GodinaProizvodnje";
            parameter3.SqlDbType = SqlDbType.DateTime;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = GodinaProizvodnje;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter31 = new SqlParameter();
            parameter31.ParameterName = "@SopstvenaTezina";
            parameter31.SqlDbType = SqlDbType.Decimal;
            parameter31.Direction = ParameterDirection.Input;
            parameter31.Value = SopstvenaTezina;
            myCommand.Parameters.Add(parameter31);



            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@NarednaREgistracija";
            parameter4.SqlDbType = SqlDbType.DateTime;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = NarednaREgistracija;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter4a = new SqlParameter();
            parameter4a.ParameterName = "@SetomesecniTehnicki";
            parameter4a.SqlDbType = SqlDbType.DateTime;
            parameter4a.Direction = ParameterDirection.Input;
            parameter4a.Value = SetomesecniTehnicki;
            myCommand.Parameters.Add(parameter4a);

            SqlParameter parameter4a1 = new SqlParameter();
            parameter4a1.ParameterName = "@GodisnjiTehnicki";
            parameter4a1.SqlDbType = SqlDbType.DateTime;
            parameter4a1.Direction = ParameterDirection.Input;
            parameter4a1.Value = GodisnjiTehnicki;
            myCommand.Parameters.Add(parameter4a1);

            SqlParameter parameter4a2 = new SqlParameter();
            parameter4a2.ParameterName = "@TahografSertifikat";
            parameter4a2.SqlDbType = SqlDbType.DateTime;
            parameter4a2.Direction = ParameterDirection.Input;
            parameter4a2.Value = TahografSertifikat;
            myCommand.Parameters.Add(parameter4a2);

            SqlParameter parameter4a3 = new SqlParameter();
            parameter4a3.ParameterName = "@PPAparat";
            parameter4a3.SqlDbType = SqlDbType.DateTime;
            parameter4a3.Direction = ParameterDirection.Input;
            parameter4a3.Value = PPAparat;
            myCommand.Parameters.Add(parameter4a3);

            SqlParameter parameter4a4 = new SqlParameter();
            parameter4a4.ParameterName = "@Servis";
            parameter4a4.SqlDbType = SqlDbType.DateTime;
            parameter4a4.Direction = ParameterDirection.Input;
            parameter4a4.Value = Servis;
            myCommand.Parameters.Add(parameter4a4);

            SqlParameter parameter4a5 = new SqlParameter();
            parameter4a5.ParameterName = "@Atest";
            parameter4a5.SqlDbType = SqlDbType.DateTime;
            parameter4a5.Direction = ParameterDirection.Input;
            parameter4a5.Value = Atest;
            myCommand.Parameters.Add(parameter4a5);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Nosivost";
            parameter5.SqlDbType = SqlDbType.Decimal;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Nosivost;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Napomena";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 500;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Napomena;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter6a = new SqlParameter();
            parameter6a.ParameterName = "@SifraErp";
            parameter6a.SqlDbType = SqlDbType.NVarChar;
            parameter6a.Size = 10;
            parameter6a.Direction = ParameterDirection.Input;
            parameter6a.Value = SifraERP;
            myCommand.Parameters.Add(parameter6a);

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

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@UradjenTromesecni";
            parameter9.SqlDbType = SqlDbType.TinyInt;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = UradjenTromesecni;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@UradjenSetomesecni";
            parameter10.SqlDbType = SqlDbType.TinyInt;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = UradjenSetomesecni;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@UradjenServis";
            parameter11.SqlDbType = SqlDbType.TinyInt;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = UradjenServis;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@DatumUradjenTromesecni";
            parameter12.SqlDbType = SqlDbType.DateTime;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = DatumUradjenTromesecni;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@DatumUradjenSetomesecni";
            parameter13.SqlDbType = SqlDbType.DateTime;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = DatumUradjenSetomesecni;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@DatumUradjenServis";
            parameter14.SqlDbType = SqlDbType.DateTime;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = DatumUradjenServis;
            myCommand.Parameters.Add(parameter14);

            //Polje nije trebalo da ima prefix Datum
            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@DatumUradjenGodisnji";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = DatumUradjenGodisnji;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@TromesecniTehnicki";
            parameter16.SqlDbType = SqlDbType.DateTime;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = TromesecniTehnicki;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@UradjenGodisnji";
            parameter17.SqlDbType = SqlDbType.TinyInt;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = UradjenGodisnji;
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

       public void DeleteProm(int ID)
          {
              var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
              SqlConnection myConnection = new SqlConnection(s_connection);
              SqlCommand myCommand = myConnection.CreateCommand();
              myCommand.CommandText = "DeletePromet";
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

        public void DeletePromManipulacije(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeletePrometManipulacije";
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

        public void UpdateZatvoren(int ID)
       {
           var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(s_connection);
           SqlCommand myCommand = myConnection.CreateCommand();
           myCommand.CommandText = "UpdateZatvoren";
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
               throw new Exception("Zatvaranje neuspešno");
           }

           finally
           {
               if (!error)
               {
                   myTransaction.Commit();
                   MessageBox.Show("Zatvaranje uspešno", "",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

               }
               myConnection.Close();

               if (error)
               {
                   // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
               }
           }
       }

       public void UpdateZatvorenOtprema(string ID, DateTime DatumOtpreme, int BrojOtpremnice)
       {
           var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(s_connection);
           SqlCommand myCommand = myConnection.CreateCommand();
           myCommand.CommandText = "UpdateZatvorenOtprema";
           myCommand.CommandType = System.Data.CommandType.StoredProcedure;

           SqlParameter parameter = new SqlParameter();
           parameter.ParameterName = "@ID";
           parameter.SqlDbType = SqlDbType.NVarChar;
           parameter.Size = 20;
           parameter.Direction = ParameterDirection.Input;
           parameter.Value = ID;
           myCommand.Parameters.Add(parameter);

           SqlParameter parameter1 = new SqlParameter();
           parameter1.ParameterName = "@DatumOtpreme";
           parameter1.SqlDbType = SqlDbType.DateTime;
           parameter1.Direction = ParameterDirection.Input;
           parameter1.Value = DatumOtpreme;
           myCommand.Parameters.Add(parameter1);

           SqlParameter parameter2 = new SqlParameter();
           parameter2.ParameterName = "@BrojOtpremnice";
           parameter2.SqlDbType = SqlDbType.Int;
           parameter2.Direction = ParameterDirection.Input;
           parameter2.Value = BrojOtpremnice;
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
               throw new Exception("Zatvaranje neuspešno");
           }

           finally
           {
               if (!error)
               {
                   myTransaction.Commit();
                   MessageBox.Show("Zatvaranje uspešno", "",
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


