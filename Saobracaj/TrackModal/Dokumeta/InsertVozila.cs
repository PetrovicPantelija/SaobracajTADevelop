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
    class InsertVozila
    {

        public void InsVozila(string Naziv ,string IndividualniBroj ,string LicencaBroj ,DateTime LicencaVaziDo ,string Namena ,string Vrsta ,int BrojOsovina ,string RegistarskaOznaka ,string GodinaProizvodnje ,double SopstvenaTezina ,DateTime NarednaREgistracija ,DateTime SetomesecniTehnicki,DateTime GodisnjiTehnicki  ,DateTime TahografSertifikat ,DateTime PPAparat ,DateTime Servis  ,DateTime Atest  ,double Nosivost ,string Napomena ,string SifraERP,DateTime Datum ,string Korisnik,int UradjenTromesecni ,int UradjenSetomesecni,int UradjenServis,	DateTime DatumUradjenTromesecni,DateTime DatumUradjenSetomesecni,DateTime DatumUradjenServis,DateTime DatumUradjenGodisnji,  DateTime TromesecniTehnicki, int UradjenGodisnji)
        {
            /*
             @Naziv nvarchar(100),
	@RegistarskaOznaka [nvarchar](100) ,
	@IndividualniBroj [nvarchar](100) ,
	@GodinaProizvodnje [datetime] ,
	@NarednaREgistracija [datetime] ,
	@Nosivost [decimal](18, 2) ,
	@Napomena [nvarchar](500),
    @Datum datetime,
    @Korisnik nvarchar(20)
*/

            /*
             @Naziv nvarchar(100),
@IndividualniBroj [nvarchar](10) ,
@LicencaBroj [nvarchar](100),
@LicencaVaziDo datetime,
@Namena [nvarchar](100),
@Vrsta [nvarchar](100),
@BrojOsovina int,
@RegistarskaOznaka [nvarchar](100) ,
@GodinaProizvodnje [datetime] ,
@SopstvenaTezina decimal(18,2),
@NarednaREgistracija [datetime] ,
@SetomesecniTehnicki [datetime] ,
@GodisnjiTehnicki  [datetime],
@TahografSertifikat [datetime],
@PPAparat [datetime],
@Servis [nvarchar](100),
@Atest [datetime],
@Nosivost [decimal](18, 2) ,
@Napomena [nvarchar](500),
@SifraERP nvarchar(10),
@Datum datetime,
@Korisnik nvarchar(20),
@UradjenTromesecni tinyint,
@UradjenSetomesecni tinyint,
@UradjenServis tinyint,
@DatumUradjenTromesecni DateTime,
@DatumUradjenSetomesecni DateTime,
@DatumUradjenServis DateTime
*/


            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertVozila";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


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
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 4;
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

        public void UpdVozila(int ID, string Naziv, string IndividualniBroj, string LicencaBroj, DateTime LicencaVaziDo, string Namena, string Vrsta, int BrojOsovina, string RegistarskaOznaka, string GodinaProizvodnje, double SopstvenaTezina, DateTime NarednaREgistracija, DateTime SetomesecniTehnicki, DateTime GodisnjiTehnicki, DateTime TahografSertifikat, DateTime PPAparat, DateTime Servis, DateTime Atest, double Nosivost, string Napomena, string SifraERP, DateTime Datum, string Korisnik, int UradjenTromesecni, int UradjenSetomesecni, int UradjenServis, DateTime DatumUradjenTromesecni, DateTime DatumUradjenSetomesecni, DateTime DatumUradjenServis, DateTime DatumUradjenGodisnji, DateTime TromesecniTehnicki, int UradjenGodisnji)
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
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 4;
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

          public void DeleteVozila(int ID)
          {
              var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
              SqlConnection myConnection = new SqlConnection(s_connection);
              SqlCommand myCommand = myConnection.CreateCommand();
              myCommand.CommandText = "DeleteVozila";
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

