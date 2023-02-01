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
    class InsertPutniNalog
    {
        public void InsPutniNalog(int IDNalogZaPrevoz, string MestoIzdavanja, DateTime DatumPrevoza, string UtovarnoMesto, string IstovarnoMesto, int Vozilo, string PrikljucnaVozila, string Napomena, int Dispecer, int Vozac, int TehnickuIspravnost, DateTime Datum, string Korisnik, int PrikljucnoVoziloID, string Marka1, string Tip1, double Tezina1, string Marka2, string Tip2, double Tezina2, string RelacijaOd, string RelacijaDo)
        {

      



          /*
            @ID int,
    @IDNalogZaPrevoz int,
         @MestoIzdavanja nvarchar(50),
           @DatumPrevoza datetime,
           @UtovarnoMesto nvarchar(50),
           @IstovarnoMesto nvarchar(50),
           @Vozilo int,
           @PrikljucnaVozila nvarchar(250),
           @Napomena nvarchar(250),
           @Dispecer int,
           @Vozac int,
           @TehnickuIspravnost int,
           @Datum DateTime,
		   @Korisnik nvarchar(20)

            */
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPutniNalog";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            
          


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDNalogZaPrevoz";
            parameter1.SqlDbType = SqlDbType.Int;
           
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDNalogZaPrevoz;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@MestoIzdavanja";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 50;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = MestoIzdavanja;
            myCommand.Parameters.Add(parameter2);
         
        
            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@DatumPrevoza";
            parameter3.SqlDbType = SqlDbType.DateTime;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = DatumPrevoza;
            myCommand.Parameters.Add(parameter3);


        
            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@UtovarnoMesto";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 50;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = UtovarnoMesto;
            myCommand.Parameters.Add(parameter4);


           
          


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@IstovarnoMesto";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = IstovarnoMesto;
            myCommand.Parameters.Add(parameter5);

          
        


            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Vozilo";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Vozilo;
            myCommand.Parameters.Add(parameter6);


       



            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@PrikljucnaVozila";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 250;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = PrikljucnaVozila;
            myCommand.Parameters.Add(parameter7);


         
         
            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Napomena";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 250;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Napomena;
            myCommand.Parameters.Add(parameter8);


         


            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Dispecer";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Dispecer;
            myCommand.Parameters.Add(parameter9);

           
      
       

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Vozac";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Vozac;
            myCommand.Parameters.Add(parameter10);
   
    

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@TehnickuIspravnost";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = TehnickuIspravnost;
            myCommand.Parameters.Add(parameter11);

         

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Datum";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Datum;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Korisnik";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Korisnik;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@PrikljucnoVoziloID";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = PrikljucnoVoziloID;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Marka1";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 40;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Marka1;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Tip1";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 40;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Tip1;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Tezina1";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Tezina1;
            myCommand.Parameters.Add(parameter20);


            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Marka2";
            parameter21.SqlDbType = SqlDbType.NVarChar;
            parameter21.Size = 40;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Marka2;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Tip2";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 40;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Tip2;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Tezina2";
            parameter23.SqlDbType = SqlDbType.Decimal;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Tezina2;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@RelacijaOd";
            parameter24.SqlDbType = SqlDbType.NVarChar;
            parameter24.Size = 40;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = RelacijaOd;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@RelacijaDo";
            parameter25.SqlDbType = SqlDbType.NVarChar;
            parameter25.Size = 40;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = RelacijaDo;
            myCommand.Parameters.Add(parameter25);

          
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

        public void UpdPutniNalog(int ID, int IDNalogZaPrevoz, string MestoIzdavanja, DateTime DatumPrevoza, string UtovarnoMesto, string IstovarnoMesto, int Vozilo, string PrikljucnaVozila, string Napomena, int Dispecer, int Vozac, int TehnickuIspravnost, DateTime Datum, string Korisnik, int PrikljucnoVoziloID, string Marka1, string Tip1, double Tezina1, string Marka2, string Tip2, double Tezina2, string RelacijaOd, string RelacijaDo)

        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdatePutniNalog";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);



            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDNalogZaPrevoz";
            parameter1.SqlDbType = SqlDbType.Int;

            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDNalogZaPrevoz;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@MestoIzdavanja";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 50;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = MestoIzdavanja;
            myCommand.Parameters.Add(parameter2);


            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@DatumPrevoza";
            parameter3.SqlDbType = SqlDbType.DateTime;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = DatumPrevoza;
            myCommand.Parameters.Add(parameter3);



            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@UtovarnoMesto";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 50;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = UtovarnoMesto;
            myCommand.Parameters.Add(parameter4);





            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@IstovarnoMesto";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = IstovarnoMesto;
            myCommand.Parameters.Add(parameter5);





            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Vozilo";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Vozilo;
            myCommand.Parameters.Add(parameter6);






            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@PrikljucnaVozila";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 250;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = PrikljucnaVozila;
            myCommand.Parameters.Add(parameter7);



            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Napomena";
            parameter8.SqlDbType = SqlDbType.NVarChar;
            parameter8.Size = 250;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Napomena;
            myCommand.Parameters.Add(parameter8);





            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Dispecer";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Dispecer;
            myCommand.Parameters.Add(parameter9);





            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Vozac";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Vozac;
            myCommand.Parameters.Add(parameter10);



            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@TehnickuIspravnost";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = TehnickuIspravnost;
            myCommand.Parameters.Add(parameter11);



            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Datum";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Datum;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Korisnik";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Korisnik;
            myCommand.Parameters.Add(parameter16);


            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@PrikljucnoVoziloID";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = PrikljucnoVoziloID;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Marka1";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 40;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Marka1;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Tip1";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 40;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Tip1;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Tezina1";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Tezina1;
            myCommand.Parameters.Add(parameter20);


            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Marka2";
            parameter21.SqlDbType = SqlDbType.NVarChar;
            parameter21.Size = 40;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Marka2;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Tip2";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 40;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Tip2;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Tezina2";
            parameter23.SqlDbType = SqlDbType.Decimal;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Tezina2;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@RelacijaOd";
            parameter24.SqlDbType = SqlDbType.NVarChar;
            parameter24.Size = 40;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = RelacijaOd;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@RelacijaDo";
            parameter25.SqlDbType = SqlDbType.NVarChar;
            parameter25.Size = 40;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = RelacijaDo;
            myCommand.Parameters.Add(parameter25);

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

        public void DeletePutniNalog(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeletePutniNalog";
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
    }
}


﻿

