using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Saobracaj.Sifarnici
{
    class InsertTrase
    {
        public void InsTras(int Pocetna, int Krajnja, string Relacija, string OpisRelacije, string Voz, string Rang, double TezinaVoza, double TezinaLokomotive, int Prevoznik, double DuzinaVoza, double ProcenatKocenja, double Cena, double Rastojanje, System.DateTime VremePolaska, System.DateTime VremeDolaska, int DuzinaTrajanja, bool Rezi, string Godina, double CenaKalk, double RastojanjeMag, double RastojanjeReg, double RastojanjeLok, double Dana, double NajveciOtpor, double NajkraciKol, double OsovinskoOpter, int TipED, double ElektroKM, double DizelKM, double PrevoznoRastojanje)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertTrase";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            /*
            
           ,<Krajnja, nvarchar(50),>
           ,<Relacija, nvarchar(150),>
           ,<OpisRelacije, nvarchar(150),>
           ,<Voz, nvarchar(10),>
           ,<Rang, nvarchar(1),>
           ,<TezinaVoza, decimal(18,2),>
           ,<TezinaLokomotive, decimal(18,2),>
           ,<Prevoznik, int,>
           ,<DuzinaVoza, decimal(18,2),>
           ,<ProcenatKocenja, decimal(18,2),>
           ,<Cena, decimal(18,2),>
           ,<Rastojanje, decimal(18,2),>
           ,<VremePolaska, datetime,>
           ,<VremeDolaska, datetime,>
           ,<DuzinaTrajanja, int,>
           ,<Rezi, tinyint,>
           ,<Godina, nvarchar(4),>)
            */

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Pocetna";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Pocetna;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Krajnja";
            parameter.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Krajnja;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Relacija";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 150;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Relacija;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@OpisRelacije";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 150;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = OpisRelacije;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Voz";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 10;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Voz;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Rang";
            parameter6.SqlDbType = SqlDbType.Char;
            parameter6.Size = 1;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Rang;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@TezinaVoza";
            parameter7.SqlDbType = SqlDbType.Decimal;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = TezinaVoza;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@TezinaLokomotive";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = TezinaLokomotive;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Prevoznik";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Prevoznik;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@DuzinaVoza";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = DuzinaVoza;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@ProcenatKocenja";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = ProcenatKocenja;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Cena";
            parameter12.SqlDbType = SqlDbType.Decimal;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Cena;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Rastojanje";
            parameter13.SqlDbType = SqlDbType.Decimal;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Rastojanje;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@VremePolaska";
            parameter14.SqlDbType = SqlDbType.DateTime;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = VremePolaska;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@VremeDolaska";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = VremeDolaska;
            myCommand.Parameters.Add(parameter15);


            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@DuzinaTrajanja";
            parameter16.SqlDbType = SqlDbType.Int;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = DuzinaTrajanja;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Rezi";
            parameter17.SqlDbType = SqlDbType.TinyInt;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Rezi;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Godina";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 4;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Godina;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@CenaKalk";
            parameter19.SqlDbType = SqlDbType.Decimal;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = CenaKalk;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@RastojanjeMag";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = RastojanjeMag;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@RastojanjeReg";
             parameter21.SqlDbType = SqlDbType.Decimal;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = RastojanjeReg;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@RastojanjeLok";
            parameter22.SqlDbType = SqlDbType.Decimal;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = RastojanjeLok;
            myCommand.Parameters.Add(parameter22);
            
            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Dana";
            parameter23.SqlDbType = SqlDbType.Decimal;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Dana;
            myCommand.Parameters.Add(parameter23);
            
            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@NajveciOtpor";
            parameter24.SqlDbType = SqlDbType.Decimal;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = NajveciOtpor;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@NajkraciKol";
            parameter25.SqlDbType = SqlDbType.Decimal;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = NajkraciKol;
            myCommand.Parameters.Add(parameter25);

            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@OsovinskoOpter";
            parameter26.SqlDbType = SqlDbType.Decimal;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = OsovinskoOpter;
            myCommand.Parameters.Add(parameter26);

            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@TipED";
            parameter27.SqlDbType = SqlDbType.TinyInt;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = TipED;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@ElektroKM";
            parameter28.SqlDbType = SqlDbType.Decimal;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = ElektroKM;
            myCommand.Parameters.Add(parameter28);

	        SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@DizelKM";
            parameter29.SqlDbType = SqlDbType.Decimal;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = DizelKM;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@PrevoznoRastojanje";
            parameter30.SqlDbType = SqlDbType.Decimal;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = PrevoznoRastojanje;
            myCommand.Parameters.Add(parameter30);


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
                throw new Exception("Neuspešan upis računa u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos Trase je uspesno zavrsen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }


        public void UpdTrase(int ID, int Pocetna, int Krajnja, string Relacija, string OpisRelacije, string Voz, string Rang, double TezinaVoza, double TezinaLokomotive, int Prevoznik, double DuzinaVoza, double ProcenatKocenja, double Cena, double Rastojanje, System.DateTime VremePolaska, System.DateTime VremeDolaska, int DuzinaTrajanja, bool Rezi, string Godina, double CenaKalk, double RastojanjeMag, double RastojanjeReg, double RastojanjeLok, double Dana, double NajveciOtpor, double NajkraciKol, double OsovinskoOpter, int TipED, double ElektroKM, double DizelKM, double PrevoznoRastojanje)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTrase";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Pocetna";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Pocetna;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Krajnja";
            parameter.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Krajnja;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Relacija";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 150;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Relacija;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@OpisRelacije";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 150;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = OpisRelacije;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Voz";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 10;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Voz;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Rang";
            parameter6.SqlDbType = SqlDbType.Char;
            parameter6.Size = 1;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Rang;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@TezinaVoza";
            parameter7.SqlDbType = SqlDbType.Decimal;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = TezinaVoza;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@TezinaLokomotive";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = TezinaLokomotive;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Prevoznik";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Prevoznik;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@DuzinaVoza";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = DuzinaVoza;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@ProcenatKocenja";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = ProcenatKocenja;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Cena";
            parameter12.SqlDbType = SqlDbType.Decimal;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Cena;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Rastojanje";
            parameter13.SqlDbType = SqlDbType.Decimal;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Rastojanje;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@VremePolaska";
            parameter14.SqlDbType = SqlDbType.DateTime;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = VremePolaska;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@VremeDolaska";
            parameter15.SqlDbType = SqlDbType.DateTime;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = VremeDolaska;
            myCommand.Parameters.Add(parameter15);


            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@DuzinaTrajanja";
            parameter16.SqlDbType = SqlDbType.Int;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = DuzinaTrajanja;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Rezi";
            parameter17.SqlDbType = SqlDbType.TinyInt;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Rezi;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Godina";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 4;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Godina;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@CenaKalk";
            parameter19.SqlDbType = SqlDbType.Decimal;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = CenaKalk;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@RastojanjeMag";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = RastojanjeMag;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@RastojanjeReg";
            parameter21.SqlDbType = SqlDbType.Decimal;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = RastojanjeReg;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@RastojanjeLok";
            parameter22.SqlDbType = SqlDbType.Decimal;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = RastojanjeLok;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Dana";
            parameter23.SqlDbType = SqlDbType.Decimal;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Dana;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@NajveciOtpor";
            parameter24.SqlDbType = SqlDbType.Decimal;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = NajveciOtpor;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@NajkraciKol";
            parameter25.SqlDbType = SqlDbType.Decimal;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = NajkraciKol;
            myCommand.Parameters.Add(parameter25);

            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@OsovinskoOpter";
            parameter26.SqlDbType = SqlDbType.Decimal;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = OsovinskoOpter;
            myCommand.Parameters.Add(parameter26);

            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@TipED";
            parameter27.SqlDbType = SqlDbType.TinyInt;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = TipED;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@ElektroKM";
            parameter28.SqlDbType = SqlDbType.Decimal;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = ElektroKM;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@DizelKM";
            parameter29.SqlDbType = SqlDbType.Decimal;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = DizelKM;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@PrevoznoRastojanje";
            parameter30.SqlDbType = SqlDbType.Decimal;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = PrevoznoRastojanje;
            myCommand.Parameters.Add(parameter30);

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
                throw new Exception("Neuspešan upis računa u bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos stanice je uspesno zavrsen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }


        public void DeleteTrase(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteTrase";
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
                    MessageBox.Show("Unos stanice je uspesno zavrsen", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }


        public void InsPodTras(int IDRadnogNaloga, int IDTrase, int StanicaOD, int StanicaDO, double Rastojanje, int Elektrificirana, string PrugaOznaka, string TipPruge, int RB)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPodTrase";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDRadnogNaloga";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = IDRadnogNaloga;
            myCommand.Parameters.Add(parameter);
   

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDTrase";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = IDTrase;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@StanicaOD";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = StanicaOD;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@StanicaDO";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = StanicaDO;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Rastojanje";
            parameter5.SqlDbType = SqlDbType.Decimal;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Rastojanje;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Elektrificirana";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Elektrificirana;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@PrugaOznaka";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 50;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = PrugaOznaka;
            myCommand.Parameters.Add(parameter7);


            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@TipPruge";
            parameter8.SqlDbType = SqlDbType.NChar;
            parameter8.Size = 1;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = TipPruge;
            myCommand.Parameters.Add(parameter8);


            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@RB";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = RB;
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
                throw new Exception("Neuspešan upis ");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos Trase je uspesno zavrsen", "",
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
