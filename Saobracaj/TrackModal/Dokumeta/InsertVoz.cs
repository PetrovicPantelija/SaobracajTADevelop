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
    class InsertVoz
    {

        public void InsVoz(int BrVoza, string Relacija, string KalendarSaobracaja, DateTime VremePolaska, DateTime VremeDolaska, double MaksimalnaBruto, double MaksimalnaDuzina, double MaksimalanBrojKola, DateTime VremeZavrsetkaUtovara, DateTime VremeZavrsetkaKP, DateTime VremePrimopredaje, string Napomena, DateTime Datum, string Korisnik , int Dolazeci, int PostNaTerminalD, int KontrolniPregledD, int VremeIstovaraD, int VremePrimopredajeD            ,int Ponedeljak, int Utorak, int Sreda, int Cetvrtak, int Petak, int Subota, int Nedelja, int PostNaTerminalO ,int VremeUtovaraO,int VremeKontrolnogO, int VremeIzvlacenjaO,DateTime VremePolaskaO, DateTime VremeDolaskaO, int StanicaOd, int StanicaDo)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertVoz";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

              /*   
             int BrVoza  
           ,string Relacija  nvarchar(200) 
           ,string KalendarSaobracaja nvarchar(100)
           ,DateTime VremePolaska datetime 
           ,DateTime VremeDolaska  datetime 
           ,double MaksimalnaBruto  decimal(18,2) 
           ,double MaksimalnaDuzina  decimal(18,2) 
           ,double MaksimalanBrojKola decimal(18,2) 
           ,DateTime VremeZavrsetkaUtovara datetime
           ,DateTime VremeZavrsetkaKP datetime 
           ,DateTime VremePrimopredaje datetime 
           ,string Napomena nvarchar(500)
           ,DateTime Datum datetime 
           ,string Korisnik nvarchar(20)     

              */

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@BrVoza";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = BrVoza;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "Relacija";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 200;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Relacija;
            myCommand.Parameters.Add(parameter1);

           

              SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@KalendarSaobracaja";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 100;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = KalendarSaobracaja;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@VremePolaska";
            parameter3.SqlDbType = SqlDbType.DateTime;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = VremePolaska;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@VremeDolaska";
            parameter4.SqlDbType = SqlDbType.DateTime;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = VremeDolaska;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@MaksimalnaBruto";
            parameter5.SqlDbType = SqlDbType.Decimal;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = MaksimalnaBruto;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@MaksimalnaDuzina";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = MaksimalnaDuzina;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter61 = new SqlParameter();
            parameter61.ParameterName = "@MaksimalanBrojKola";
            parameter61.SqlDbType = SqlDbType.Decimal;
            parameter61.Direction = ParameterDirection.Input;
            parameter61.Value = MaksimalanBrojKola;
            myCommand.Parameters.Add(parameter61);

            //,@MaksimalanBrojKola

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@VremeZavrsetkaUtovara";
            parameter7.SqlDbType = SqlDbType.DateTime;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = VremeZavrsetkaUtovara;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@VremeZavrsetkaKP";
            parameter8.SqlDbType = SqlDbType.DateTime;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = VremeZavrsetkaKP;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@VremePrimopredaje";
            parameter9.SqlDbType = SqlDbType.DateTime;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = VremePrimopredaje;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Napomena";
            parameter10.SqlDbType = SqlDbType.NVarChar;
            parameter10.Size = 500;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Napomena;
            myCommand.Parameters.Add(parameter10);
            
            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Datum";
            parameter11.SqlDbType = SqlDbType.DateTime;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Datum;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Korisnik";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 20;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Korisnik;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Dolazeci";
            parameter13.SqlDbType = SqlDbType.TinyInt;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Dolazeci;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@PostNaTerminalD";
            parameter14.SqlDbType = SqlDbType.Int;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = PostNaTerminalD;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@KontrolniPregledD";
            parameter15.SqlDbType = SqlDbType.Int;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = KontrolniPregledD;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@VremeIstovaraD";
            parameter16.SqlDbType = SqlDbType.Int;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = VremeIstovaraD;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@VremePrimopredajeD";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = VremePrimopredajeD;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Ponedeljak";
            parameter18.SqlDbType = SqlDbType.TinyInt;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Ponedeljak;
            myCommand.Parameters.Add(parameter18);
           
            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Utorak";
            parameter19.SqlDbType = SqlDbType.TinyInt;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Utorak;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Sreda";
            parameter20.SqlDbType = SqlDbType.TinyInt;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Sreda;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Cetvrtak";
            parameter21.SqlDbType = SqlDbType.TinyInt;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Cetvrtak;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Petak";
            parameter22.SqlDbType = SqlDbType.TinyInt;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Petak;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Subota";
            parameter23.SqlDbType = SqlDbType.TinyInt;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Subota;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Nedelja";
            parameter24.SqlDbType = SqlDbType.TinyInt;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Nedelja;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@PostNaTerminalO";
            parameter25.SqlDbType = SqlDbType.Int;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = PostNaTerminalO;
            myCommand.Parameters.Add(parameter25);

            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@VremeUtovaraO";
            parameter26.SqlDbType = SqlDbType.Int;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = VremeUtovaraO;
            myCommand.Parameters.Add(parameter26);
           
            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@VremeKontrolnogO";
            parameter27.SqlDbType = SqlDbType.Int;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = VremeKontrolnogO;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@VremeIzvlacenjaO";
            parameter28.SqlDbType = SqlDbType.Int;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = VremeIzvlacenjaO;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@VremePolaskaO";
            parameter29.SqlDbType = SqlDbType.DateTime;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = VremePolaskaO;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@VremeDolaskaO";
            parameter30.SqlDbType = SqlDbType.DateTime;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = VremeDolaskaO;
            myCommand.Parameters.Add(parameter30);

            SqlParameter parameter31 = new SqlParameter();
            parameter31.ParameterName = "@StanicaOd";
            parameter31.SqlDbType = SqlDbType.Int;
            parameter31.Direction = ParameterDirection.Input;
            parameter31.Value = StanicaOd;
            myCommand.Parameters.Add(parameter31);

            SqlParameter parameter32 = new SqlParameter();
            parameter32.ParameterName = "@StanicaDo";
            parameter32.SqlDbType = SqlDbType.Int;
            parameter32.Direction = ParameterDirection.Input;
            parameter32.Value = StanicaDo;
            myCommand.Parameters.Add(parameter32);
            /*
           , int Dolazeci, int PostNaTerminalD, int KontrolniPregledD, int VremeIstovaraD, int VremePrimopredajeD
            ,int Ponedeljak, int Utorak, int Sreda, int Cetvrtak, int Petak, int Subota, int Nedelja, int PostNaTerminalO ,int VremeUtovaraO,int VremeKontrolnogO, int VremeIzvlacenjaO
            DateTime VremePolaskaO, DateTime VremeDolaskaO
			
            */
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

            catch (SqlException ex)
            {
                throw new Exception("Neuspešan upis  u bazu" + ex.ErrorCode);
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

        public void UpdVoz(int ID, int BrVoza, string Relacija, string KalendarSaobracaja, DateTime VremePolaska, DateTime VremeDolaska, double MaksimalnaBruto, double MaksimalnaDuzina, double MaksimalanBrojKola, DateTime VremeZavrsetkaUtovara, DateTime VremeZavrsetkaKP, DateTime VremePrimopredaje, string Napomena, DateTime Datum, string Korisnik, int Dolazeci, int PostNaTerminalD, int KontrolniPregledD, int VremeIstovaraD, int VremePrimopredajeD            ,int Ponedeljak, int Utorak, int Sreda, int Cetvrtak, int Petak, int Subota, int Nedelja, int PostNaTerminalO ,int VremeUtovaraO,int VremeKontrolnogO, int VremeIzvlacenjaO,DateTime VremePolaskaO, DateTime VremeDolaskaO, int StanicaOd, int StanicaDo)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateVoz";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);



            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@BrVoza";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = BrVoza;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "Relacija";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 200;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Relacija;
            myCommand.Parameters.Add(parameter1);



            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@KalendarSaobracaja";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 100;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = KalendarSaobracaja;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@VremePolaska";
            parameter3.SqlDbType = SqlDbType.DateTime;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = VremePolaska;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@VremeDolaska";
            parameter4.SqlDbType = SqlDbType.DateTime;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = VremeDolaska;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@MaksimalnaBruto";
            parameter5.SqlDbType = SqlDbType.Decimal;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = MaksimalnaBruto;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@MaksimalnaDuzina";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = MaksimalnaDuzina;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter61 = new SqlParameter();
            parameter61.ParameterName = "@MaksimalanBrojKola";
            parameter61.SqlDbType = SqlDbType.Decimal;
            parameter61.Direction = ParameterDirection.Input;
            parameter61.Value = MaksimalanBrojKola;
            myCommand.Parameters.Add(parameter61);

            //,@MaksimalanBrojKola

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@VremeZavrsetkaUtovara";
            parameter7.SqlDbType = SqlDbType.DateTime;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = VremeZavrsetkaUtovara;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@VremeZavrsetkaKP";
            parameter8.SqlDbType = SqlDbType.DateTime;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = VremeZavrsetkaKP;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@VremePrimopredaje";
            parameter9.SqlDbType = SqlDbType.DateTime;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = VremePrimopredaje;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Napomena";
            parameter10.SqlDbType = SqlDbType.NVarChar;
            parameter10.Size = 500;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Napomena;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Datum";
            parameter11.SqlDbType = SqlDbType.DateTime;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Datum;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Korisnik";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 20;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Korisnik;
            myCommand.Parameters.Add(parameter12);

              SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Dolazeci";
            parameter13.SqlDbType = SqlDbType.TinyInt;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Dolazeci;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@PostNaTerminalD";
            parameter14.SqlDbType = SqlDbType.Int;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = PostNaTerminalD;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@KontrolniPregledD";
            parameter15.SqlDbType = SqlDbType.Int;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = KontrolniPregledD;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@VremeIstovaraD";
            parameter16.SqlDbType = SqlDbType.Int;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = VremeIstovaraD;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@VremePrimopredajeD";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = VremePrimopredajeD;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Ponedeljak";
            parameter18.SqlDbType = SqlDbType.TinyInt;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Ponedeljak;
            myCommand.Parameters.Add(parameter18);
           
            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Utorak";
            parameter19.SqlDbType = SqlDbType.TinyInt;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Utorak;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Sreda";
            parameter20.SqlDbType = SqlDbType.TinyInt;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Sreda;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Cetvrtak";
            parameter21.SqlDbType = SqlDbType.TinyInt;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Cetvrtak;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Petak";
            parameter22.SqlDbType = SqlDbType.TinyInt;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Petak;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Subota";
            parameter23.SqlDbType = SqlDbType.TinyInt;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Subota;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Nedelja";
            parameter24.SqlDbType = SqlDbType.TinyInt;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Nedelja;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@PostNaTerminalO";
            parameter25.SqlDbType = SqlDbType.Int;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = PostNaTerminalO;
            myCommand.Parameters.Add(parameter25);

            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@VremeUtovaraO";
            parameter26.SqlDbType = SqlDbType.Int;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = VremeUtovaraO;
            myCommand.Parameters.Add(parameter26);
           
            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@VremeKontrolnogO";
            parameter27.SqlDbType = SqlDbType.Int;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = VremeKontrolnogO;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@VremeIzvlacenjaO";
            parameter28.SqlDbType = SqlDbType.Int;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = VremeIzvlacenjaO;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@VremePolaskaO";
            parameter29.SqlDbType = SqlDbType.DateTime;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = VremePolaskaO;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@VremeDolaskaO";
            parameter30.SqlDbType = SqlDbType.DateTime;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = VremeDolaskaO;
            myCommand.Parameters.Add(parameter30);

            SqlParameter parameter31 = new SqlParameter();
            parameter31.ParameterName = "@StanicaOd";
            parameter31.SqlDbType = SqlDbType.Int;
            parameter31.Direction = ParameterDirection.Input;
            parameter31.Value = StanicaOd;
            myCommand.Parameters.Add(parameter31);

            SqlParameter parameter32 = new SqlParameter();
            parameter32.ParameterName = "@StanicaDo";
            parameter32.SqlDbType = SqlDbType.Int;
            parameter32.Direction = ParameterDirection.Input;
            parameter32.Value = StanicaDo;
            myCommand.Parameters.Add(parameter32);

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

          public void DeleteVoz(int ID)
          {
              var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
              SqlConnection myConnection = new SqlConnection(s_connection);
              SqlCommand myCommand = myConnection.CreateCommand();
              myCommand.CommandText = "DeleteVoz";
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

          public void PrekopirajVoz(int ID)
          {

              var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
              SqlConnection myConnection = new SqlConnection(s_connection);
              SqlCommand myCommand = myConnection.CreateCommand();
              myCommand.CommandText = "PrekopirajVoz";
              myCommand.CommandType = System.Data.CommandType.StoredProcedure;

           

              SqlParameter parameter = new SqlParameter();
              parameter.ParameterName = "@IDStari";
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

              catch (SqlException ex)
              {
                  throw new Exception("Neuspešan upis  u bazu" + ex.ErrorCode);
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

        public void InsSerijeKola(int IDVoza, int TipKontejnera, int BrojSerija)
        {
            //TipKontejnera je serija kola 
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertVozSerijeKola";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;



            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDVoza";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = IDVoza;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@TipKontejnera";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = TipKontejnera;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@BrojSerija";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = BrojSerija;
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

            catch (SqlException ex)
            {
                throw new Exception("Neuspešan upis  u bazu" + ex.ErrorCode);
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

        public void DelSerijeKola(int ID)
        {
            //TipKontejnera je serija kola 
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteVozSerijeKola";
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

            catch (SqlException ex)
            {
                throw new Exception("Neuspešan upis  u bazu" + ex.ErrorCode);
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
