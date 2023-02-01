﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TrackModal.Sifarnici
{
    class InsertCIR
    {

        public void InsCIR(int Size , int TiKontejnera , int MaterijalCelik ,int MaterijalAlumini ,int incoming ,int Pun ,double Tezina , string BrKontejnera ,int Plomba1 , int Plomba2 , DateTime DatumIn , string Vagon ,string TruckNo , int Damaged ,int Ispravan ,int Prevoz ,string Containerresponsible , string primedbe ,string Received ,string Inspected, string Delivery , DateTime Datum,  string Korisnik, int Prijem, int Dokumenta, double Duzina, double Sirina, double Visina, string sPlomba, string sPlomba2)
        {
      
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertCIR";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Size";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Size;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@TiKontejnera";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = TiKontejnera;
            myCommand.Parameters.Add(parameter1);

         
            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@MaterijalCelik";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = MaterijalCelik;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@MaterijalAlumini";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = MaterijalAlumini;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@incoming";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = incoming;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Pun";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Pun;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Tezina";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Tezina;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@BrKontejnera";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = BrKontejnera;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Plomba1";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Plomba1;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Plomba2";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Plomba2;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@DatumIn";
            parameter10.SqlDbType = SqlDbType.DateTime;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = DatumIn;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Vagon";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 20;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Vagon;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@TruckNo";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 20;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = TruckNo;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Damaged";
            parameter13.SqlDbType = SqlDbType.Int;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Damaged;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Ispravan";
            parameter14.SqlDbType = SqlDbType.Int;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Ispravan;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Prevoz";
            parameter15.SqlDbType = SqlDbType.Int;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Prevoz;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Containerresponsible";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 100;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Containerresponsible;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@primedbe";
            parameter17.SqlDbType = SqlDbType.NVarChar;
            parameter17.Size = 200;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = primedbe;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Received";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 100;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Received;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Inspected";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 100;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Inspected;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Delivery";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 100;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Delivery;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Datum";
            parameter21.SqlDbType = SqlDbType.DateTime;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Datum;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Korisnik";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 20;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Korisnik;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Prijem";
            parameter23.SqlDbType = SqlDbType.Int;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Prijem;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Dokument";
            parameter24.SqlDbType = SqlDbType.Int;
         //   parameter24.Size
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Dokumenta;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@Duzina";
            parameter25.SqlDbType = SqlDbType.Decimal;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = Duzina;
            myCommand.Parameters.Add(parameter25);

            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@Sirina";
            parameter26.SqlDbType = SqlDbType.Decimal;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = Sirina;
            myCommand.Parameters.Add(parameter26);

              SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@Visina";
            parameter27.SqlDbType = SqlDbType.Decimal;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = Visina;
            myCommand.Parameters.Add(parameter27);


            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@sPlomba";
            parameter28.SqlDbType = SqlDbType.NVarChar;
            parameter28.Size = 20;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = sPlomba;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@sPlomba2";
            parameter29.SqlDbType = SqlDbType.NVarChar;
            parameter29.Size = 20;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = sPlomba2;
            myCommand.Parameters.Add(parameter29);

            /*   

    
 
   
     @primedbe nvarchar(200),@Received nvarchar(100),
     @Inspected nvarchar(100), @Delivery nvarchar(100),
     @Datum datetime,  @Korisnik nvarchar(20)
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

        public void UpdateCIRPrijem(int ID)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdatePrijemKontejneraVozCIR";
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

        public void UpdateCIROtprema(int ID)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateOtpremaKontejneraCIR";
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

        public void UpdCIR(int Id, int Size, int TiKontejnera, int MaterijalCelik, int MaterijalAlumini, int incoming, int Pun, double Tezina, string BrKontejnera, int Plomba1, int Plomba2, DateTime DatumIn, string Vagon, string TruckNo, int Damaged, int Ispravan, int Prevoz, string Containerresponsible, string primedbe, string Received, string Inspected, string Delivery, DateTime Datum, string Korisnik, int Prijem, int Dokumenta, double Duzina, double Sirina, double Visina, string sPlomba, string sPlomba2)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateCIR";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = Id;
            myCommand.Parameters.Add(parameter0);


            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Size";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Size;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@TiKontejnera";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = TiKontejnera;
            myCommand.Parameters.Add(parameter1);


            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@MaterijalCelik";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = MaterijalCelik;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@MaterijalAlumini";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = MaterijalAlumini;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@incoming";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = incoming;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Pun";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Pun;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Tezina";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Tezina;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@BrKontejnera";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = BrKontejnera;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Plomba1";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Plomba1;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Plomba2";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Plomba2;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@DatumIn";
            parameter10.SqlDbType = SqlDbType.DateTime;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = DatumIn;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Vagon";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 20;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Vagon;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@TruckNo";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 20;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = TruckNo;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Damaged";
            parameter13.SqlDbType = SqlDbType.Int;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Damaged;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Ispravan";
            parameter14.SqlDbType = SqlDbType.Int;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Ispravan;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Prevoz";
            parameter15.SqlDbType = SqlDbType.Int;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Prevoz;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Containerresponsible";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 100;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Containerresponsible;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@primedbe";
            parameter17.SqlDbType = SqlDbType.NVarChar;
            parameter17.Size = 200;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = primedbe;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Received";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 100;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Received;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Inspected";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 100;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Inspected;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Delivery";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 100;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Delivery;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Datum";
            parameter21.SqlDbType = SqlDbType.DateTime;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Datum;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Korisnik";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 20;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Korisnik;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Prijem";
            parameter23.SqlDbType = SqlDbType.Int;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Prijem;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Dokument";
            parameter24.SqlDbType = SqlDbType.Int;
            //   parameter24.Size
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Dokumenta;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@Duzina";
            parameter25.SqlDbType = SqlDbType.Decimal;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = Duzina;
            myCommand.Parameters.Add(parameter25);

            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@Sirina";
            parameter26.SqlDbType = SqlDbType.Decimal;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = Sirina;
            myCommand.Parameters.Add(parameter26);

            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@Visina";
            parameter27.SqlDbType = SqlDbType.Decimal;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = Visina;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@sPlomba";
            parameter28.SqlDbType = SqlDbType.NVarChar;
            parameter28.Size = 20;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = sPlomba;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@sPlomba2";
            parameter29.SqlDbType = SqlDbType.NVarChar;
            parameter29.Size = 20;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = sPlomba2;
            myCommand.Parameters.Add(parameter29);


            /*   

    
 
   
     @primedbe nvarchar(200),@Received nvarchar(100),
     @Inspected nvarchar(100), @Delivery nvarchar(100),
     @Datum datetime,  @Korisnik nvarchar(20)
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


        public void InsCIRGreske(int IDNadredjenog, int IDGreske, int IDDela  ,DateTime Datum, string Korisnik)
        {

       


            /*  int ID , int Size , int TiKontejnera , 
             * int MaterijalCelik ,int MaterijalAlumini ,int incoming ,
             * int Pun ,double Tezina , string BrKontejnera ,int Plomba1 , int Plomba2 , DateTime DatumIn , string Vagon ,string TruckNo , int Damaged ,int Ispravan ,int Prevoz ,string Containerresponsible , string primedbe ,string Received ,string Inspected, string Delivery , DateTime Datum datetime,  string Korisnik
*/

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertCIRGreske";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDNadredjenog";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = IDNadredjenog;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDGreske";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDGreske;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Datum";
            parameter2.SqlDbType = SqlDbType.DateTime;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Datum;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Korisnik";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Korisnik;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@IDDela";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = IDDela;
            myCommand.Parameters.Add(parameter4);

            /*   

    
 
   
     @primedbe nvarchar(200),@Received nvarchar(100),
     @Inspected nvarchar(100), @Delivery nvarchar(100),
     @Datum datetime,  @Korisnik nvarchar(20)
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

        public void DelCIRGreske( int IDGreske)
        {




            /*  int ID , int Size , int TiKontejnera , 
             * int MaterijalCelik ,int MaterijalAlumini ,int incoming ,
             * int Pun ,double Tezina , string BrKontejnera ,int Plomba1 , int Plomba2 , DateTime DatumIn , string Vagon ,string TruckNo , int Damaged ,int Ispravan ,int Prevoz ,string Containerresponsible , string primedbe ,string Received ,string Inspected, string Delivery , DateTime Datum datetime,  string Korisnik
*/

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteCIRGreske";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

          

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@IDGreske";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = IDGreske;
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
    }
}
