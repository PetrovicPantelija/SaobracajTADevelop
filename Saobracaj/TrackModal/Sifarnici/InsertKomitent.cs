using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Testiranje.Sifarnici
{
    class InsertKomitent
    {
        public void InsKomitent(string Naziv,string Adresa, string Telefon, string email, string KontaktOsoba, int Brodar, int Posiljalac , 	int Primalac , 	int Platilac , 	int Organizator , 	int Vlasnik, 	int Operator ,  string  Napomena, DateTime Datum, string Korisnik, string PIB, string MaticniBroj, string SifraERP, string TR)
        {
           
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertKomitenti";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Naziv";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 100;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Naziv;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Adresa";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 200;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Adresa;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Telefon";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Telefon;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@email";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 100;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = email;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@KontaktOsoba";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 100;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = KontaktOsoba;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Brodar";
            parameter6.SqlDbType = SqlDbType.TinyInt;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Brodar;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Posiljalac";
            parameter7.SqlDbType = SqlDbType.TinyInt;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Posiljalac;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Primalac";
            parameter8.SqlDbType = SqlDbType.TinyInt;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Primalac;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Platilac";
            parameter9.SqlDbType = SqlDbType.TinyInt;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Platilac;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Organizator";
            parameter10.SqlDbType = SqlDbType.TinyInt;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Organizator;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Vlasnik";
            parameter11.SqlDbType = SqlDbType.TinyInt;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Vlasnik;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Operator";
            parameter12.SqlDbType = SqlDbType.TinyInt;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Operator;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Napomena";
            parameter13.SqlDbType = SqlDbType.NVarChar;
            parameter13.Size = 500;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Napomena;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Datum";
            parameter14.SqlDbType = SqlDbType.DateTime;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Datum;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Korisnik";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 20;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Korisnik;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@PIB";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = PIB;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@MaticniBroj";
            parameter17.SqlDbType = SqlDbType.NVarChar;
            parameter17.Size = 20;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = MaticniBroj;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@SifraERP";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = SifraERP;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@TR";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 30;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = TR;
            myCommand.Parameters.Add(parameter19);


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

        public void UpdKomitent(int ID, string Naziv, string Adresa, string Telefon, string email, string KontaktOsoba, int Brodar, int Posiljalac, int Primalac, int Platilac, int Organizator, int Vlasnik, int Operator, string Napomena, DateTime Datum, string Korisnik, string PIB, string MaticniBroj, string SifraERP, string TR)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateKomitenti";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Naziv";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 100;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Naziv;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Adresa";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 200;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Adresa;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Telefon";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Telefon;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@email";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 100;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = email;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@KontaktOsoba";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 100;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = KontaktOsoba;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Brodar";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Brodar;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Posiljalac";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Posiljalac;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Primalac";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Primalac;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Platilac";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Platilac;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Organizator";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Organizator;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@Vlasnik";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = Vlasnik;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Operator";
            parameter12.SqlDbType = SqlDbType.Int;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Operator;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Napomena";
            parameter13.SqlDbType = SqlDbType.NVarChar;
            parameter13.Size = 500;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Napomena;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@Datum";
            parameter14.SqlDbType = SqlDbType.DateTime;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = Datum;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@Korisnik";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 20;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = Korisnik;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@PIB";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = PIB;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@MaticniBroj";
            parameter17.SqlDbType = SqlDbType.NVarChar;
            parameter17.Size = 20;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = MaticniBroj;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@SifraERP";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = SifraERP;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@TR";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 20;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = TR;
            myCommand.Parameters.Add(parameter19);

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

        public void DeleteKomitent(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteKomitenti";
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

