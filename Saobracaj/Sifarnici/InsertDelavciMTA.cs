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
    class InsertDelavciMTA
    {
        public void InsDelavciMTA( string DePriimek, string DeIme, string DeTelefon1, string DeTelefon2, string DeEMail, string DeUlHisStBivS, string DeKrajBivS, int DeSifDelMes, string DeSifStat, int PomManevrista, int PomPomocnik, int PomVozovodja, int PomPregledacKola, int PomMasinovodja)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertDelavciMTA";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@DePriimek";
            parameter1.SqlDbType = SqlDbType.Char;
            parameter1.Size = 35;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = DePriimek;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@DeIme";
            parameter2.SqlDbType = SqlDbType.Char;
            parameter2.Size = 35;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = DeIme;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@DeTelefon1";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 17;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = DeTelefon1;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@DeTelefon2";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 17;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = DeTelefon2;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@DeEMail";
            parameter5.SqlDbType = SqlDbType.VarChar;
            parameter5.Size = 100;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = DeEMail;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@DeUlHisStBivS";
            parameter6.SqlDbType = SqlDbType.Char;
            parameter6.Size = 35;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = DeUlHisStBivS;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@DeKrajBivS";
            parameter7.SqlDbType = SqlDbType.Char;
            parameter7.Size = 35;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = DeKrajBivS;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@DeSifStat";
            parameter8.SqlDbType = SqlDbType.Char;
            parameter8.Size = 2;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = DeSifStat;
            myCommand.Parameters.Add(parameter8);

           // int PomManevrista, int PomPomocnik, int PomVozovodja, int PomPregledacKola, int PomMasinovodja

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@PomManevrista";
            parameter9.SqlDbType = SqlDbType.Int;
          //  parameter9.Size = 2048;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = PomManevrista;
            myCommand.Parameters.Add(parameter9);


            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@PomPomocnik";
            parameter10.SqlDbType = SqlDbType.Int;
          //  parameter10.Size = 35;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = PomPomocnik;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@PomVozovodja";
            parameter11.SqlDbType = SqlDbType.Int;
          //  parameter11.Size = 70;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = PomVozovodja;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@PomPregledacKola";
            parameter12.SqlDbType = SqlDbType.Int;
        //    parameter12.Size = 35;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = PomPregledacKola;
            myCommand.Parameters.Add(parameter12);
            /*
                     ,< PaNaziv, char(35),>
                     ,< PaUlicaHisnaSt, char(35),>
                     ,< PaKraj, char(35),>
                     ,< PaDelDrzave, char(9),>
                     ,< PaPostnaSt, char(9),>
                     ,< PaSifDrzave, char(3),>
                     ,< PaTelefon1, char(17),>
                     ,< PaZiroRac, char(44),>
                     ,< PaOpomba, varchar(2048),>
                     ,< PaDMatSt, char(35),>
                     ,< PaEMail, char(70),>
                     ,< PaEMatSt1, char(35),>

                     ,< UIC, nvarchar(10),>
                     ,< Prevoznik, tinyint,>
                     ,< Posiljalac, tinyint,>
                     ,< Primalac, tinyint,>)
            */
            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@PomMasinovodja";
            parameter13.SqlDbType = SqlDbType.Int;
         //   parameter13.Size = 10;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = PomMasinovodja;
            myCommand.Parameters.Add(parameter13);

           


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
                throw new Exception("Neuspešna promena podataka");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Neuspešna promena podataka", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void UpdDelavciMTA(int DeSifra, string DePriimek, string DeIme, string DeTelefon1, string DeTelefon2, string DeEMail, string DeUlHisStBivS, string DeKrajBivS, int DeSifDelMes, string DeSifStat,int PomManevrista, int PomPomocnik, int PomVozovodja, int PomPregledacKola, int PomMasinovodja)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateDelavciMTA";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@DeSifra";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = DeSifra;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@DePriimek";
            parameter1.SqlDbType = SqlDbType.Char;
            parameter1.Size = 35;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = DePriimek;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@DeIme";
            parameter2.SqlDbType = SqlDbType.Char;
            parameter2.Size = 35;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = DeIme;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@DeTelefon1";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 17;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = DeTelefon1;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@DeTelefon2";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 17;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = DeTelefon2;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@DeEMail";
            parameter5.SqlDbType = SqlDbType.VarChar;
            parameter5.Size = 100;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = DeEMail;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@DeUlHisStBivS";
            parameter6.SqlDbType = SqlDbType.Char;
            parameter6.Size = 35;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = DeUlHisStBivS;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@DeKrajBivS";
            parameter7.SqlDbType = SqlDbType.Char;
            parameter7.Size = 35;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = DeKrajBivS;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@DeSifStat";
            parameter8.SqlDbType = SqlDbType.Char;
            parameter8.Size = 2;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = DeSifStat;
            myCommand.Parameters.Add(parameter8);

            // int PomManevrista, int PomPomocnik, int PomVozovodja, int PomPregledacKola, int PomMasinovodja

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@PomManevrista";
            parameter9.SqlDbType = SqlDbType.Int;
            //  parameter9.Size = 2048;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = PomManevrista;
            myCommand.Parameters.Add(parameter9);


            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@PomPomocnik";
            parameter10.SqlDbType = SqlDbType.Int;
            //  parameter10.Size = 35;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = PomPomocnik;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@PomVozovodja";
            parameter11.SqlDbType = SqlDbType.Int;
            //  parameter11.Size = 70;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = PomVozovodja;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@PomPregledacKola";
            parameter12.SqlDbType = SqlDbType.Int;
            //    parameter12.Size = 35;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = PomPregledacKola;
            myCommand.Parameters.Add(parameter12);
           
            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@PomMasinovodja";
            parameter13.SqlDbType = SqlDbType.Int;
            //   parameter13.Size = 10;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = PomMasinovodja;
            myCommand.Parameters.Add(parameter13);


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
                throw new Exception("Neuspešna promena podataka");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Neuspešna promena podataka", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void DelDelavciMTA(int DeSifra)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteDelavciMTA";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@DeSifra";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = DeSifra;
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
                throw new Exception("Neuspešna promena podataka");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Neuspešna promena podataka", "",
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
