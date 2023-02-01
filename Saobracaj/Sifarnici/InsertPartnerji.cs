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
    class InsertPartnerji
    {
        public void InsPartneri(string Naziv, string Ulica, string Mesto, string Oblast, string Posta, string Drzava, string Telefon, string TR, string Napomena, string MaticniBroj, string Email, string PIB, string UIC, bool Prevoznik, bool Posiljalac, bool Primalac, int Brodar ,  int Vlasnik, int Spediter , int Platilac  , int Organizator)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertParnerji";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@PaNaziv";
            parameter1.SqlDbType = SqlDbType.Char;
            parameter1.Size = 35;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Naziv;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@PaUlicaHisnaSt";
            parameter2.SqlDbType = SqlDbType.Char;
            parameter2.Size = 35;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Ulica;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@PaKraj";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 35;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Mesto;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@PaDelDrzave";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 9;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Oblast;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@PaPostnaSt";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 9;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Posta;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@PaSifDrzave";
            parameter6.SqlDbType = SqlDbType.Char;
            parameter6.Size = 3;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value =Drzava;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@PaTelefon1";
            parameter7.SqlDbType = SqlDbType.Char;
            parameter7.Size = 17;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Telefon;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@PaZiroRac";
            parameter8.SqlDbType = SqlDbType.Char;
            parameter8.Size = 44;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = TR;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@PaOpomba";
            parameter9.SqlDbType = SqlDbType.VarChar;
            parameter9.Size = 2048;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Napomena;
            myCommand.Parameters.Add(parameter9);


            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@PaDMatSt";
            parameter10.SqlDbType = SqlDbType.Char;
            parameter10.Size = 35;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = MaticniBroj;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@PaEMail";
            parameter11.SqlDbType = SqlDbType.Char;
            parameter11.Size = 70;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Email;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@PaEMatSt1";
            parameter12.SqlDbType = SqlDbType.Char;
            parameter12.Size = 35;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = PIB;
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
            parameter13.ParameterName = "@UIC";
            parameter13.SqlDbType = SqlDbType.NVarChar;
            parameter13.Size = 10;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = UIC;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Prevoznik";
            parameter14.SqlDbType = SqlDbType.TinyInt;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Prevoznik;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Posiljalac";
            parameter15.SqlDbType = SqlDbType.TinyInt;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Posiljalac;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Primalac";
            parameter16.SqlDbType = SqlDbType.TinyInt;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Primalac;
            myCommand.Parameters.Add(parameter16);

            

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Brodar";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Brodar;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Vlasnik";
            parameter18.SqlDbType = SqlDbType.Int;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Vlasnik;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Spediter";
            parameter19.SqlDbType = SqlDbType.Int;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Spediter;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Platilac";
            parameter20.SqlDbType = SqlDbType.Int;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Platilac;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Organizator";
            parameter21.SqlDbType = SqlDbType.Int;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Organizator;
            myCommand.Parameters.Add(parameter21);
         
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

        public void UpdPartneri(int ID, string Naziv, string Ulica, string Mesto, string Oblast, string Posta, string Drzava, string Telefon, string TR, string Napomena, string MaticniBroj, string Email, string PIB,  string UIC, bool Prevoznik, bool Posiljalac, bool Primalac, int Brodar, int Vlasnik, int Spediter, int Platilac, int Organizator)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdatePartneri";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@PaNaziv";
            parameter1.SqlDbType = SqlDbType.Char;
            parameter1.Size = 35;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Naziv;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@PaUlicaHisnaSt";
            parameter2.SqlDbType = SqlDbType.Char;
            parameter2.Size = 35;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Ulica;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@PaKraj";
            parameter3.SqlDbType = SqlDbType.Char;
            parameter3.Size = 35;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Mesto;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@PaDelDrzave";
            parameter4.SqlDbType = SqlDbType.Char;
            parameter4.Size = 9;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Oblast;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@PaPostnaSt";
            parameter5.SqlDbType = SqlDbType.Char;
            parameter5.Size = 9;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Posta;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@PaSifDrzave";
            parameter6.SqlDbType = SqlDbType.Char;
            parameter6.Size = 3;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Drzava;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@PaTelefon1";
            parameter7.SqlDbType = SqlDbType.Char;
            parameter7.Size = 17;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Telefon;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@PaZiroRac";
            parameter8.SqlDbType = SqlDbType.Char;
            parameter8.Size = 44;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = TR;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@PaOpomba";
            parameter9.SqlDbType = SqlDbType.VarChar;
            parameter9.Size = 2048;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Napomena;
            myCommand.Parameters.Add(parameter9);


            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@PaDMatSt";
            parameter10.SqlDbType = SqlDbType.Char;
            parameter10.Size = 35;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = MaticniBroj;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@PaEMail";
            parameter11.SqlDbType = SqlDbType.Char;
            parameter11.Size = 70;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Email;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@PaEMatSt1";
            parameter12.SqlDbType = SqlDbType.Char;
            parameter12.Size = 35;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = PIB;
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
            parameter13.ParameterName = "@UIC";
            parameter13.SqlDbType = SqlDbType.NVarChar;
            parameter13.Size = 10;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = UIC;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Prevoznik";
            parameter14.SqlDbType = SqlDbType.TinyInt;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Prevoznik;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Posiljalac";
            parameter15.SqlDbType = SqlDbType.TinyInt;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Posiljalac;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Primalac";
            parameter16.SqlDbType = SqlDbType.TinyInt;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Primalac;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Brodar";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Brodar;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Vlasnik";
            parameter18.SqlDbType = SqlDbType.Int;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Vlasnik;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Spediter";
            parameter19.SqlDbType = SqlDbType.Int;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Spediter;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Platilac";
            parameter20.SqlDbType = SqlDbType.Int;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Platilac;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Organizator";
            parameter21.SqlDbType = SqlDbType.Int;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Organizator;
            myCommand.Parameters.Add(parameter21);

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

        public void DelPartneri(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeletePartnerji";
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
