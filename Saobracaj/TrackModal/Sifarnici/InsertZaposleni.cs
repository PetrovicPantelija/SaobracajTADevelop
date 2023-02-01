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
    class InsertZaposleni
    {
        public void InsZaposleni(string Prezime, string Ime, string email, string Telefon, string Napomena, string TipRadnika, DateTime Datum, string Korisnik, int SkolskaSprema, int OrganizacionaJedinica, string SifraERP)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertZaposleni";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Prezime";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 100;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Prezime;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Ime";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 100;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Ime;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@email";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = email;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Telefon";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 100;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Telefon;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Napomena";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 500;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Napomena;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@TipRadnika";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 100;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = TipRadnika;
            myCommand.Parameters.Add(parameter6);

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
            parameter9.ParameterName = "@SkolskaSprema";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = SkolskaSprema;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@OrganizacionaJedinica";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = OrganizacionaJedinica;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@SifraERP";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 20;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = SifraERP;
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
                throw new Exception("Neuspešan upis  u bazu");
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

        public void UpdZaposleni(int ID, string Prezime, string Ime, string email, string Telefon, string Napomena, string TipRadnika, DateTime Datum, string Korisnik, int SkolskaSprema, int OrganizacionaJedinica, string SifraERP)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateZaposleni";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Prezime";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 100;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = Prezime;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Ime";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 100;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Ime;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@email";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 100;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = email;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Telefon";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 100;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Telefon;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Napomena";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 500;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Napomena;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@TipRadnika";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 100;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = TipRadnika;
            myCommand.Parameters.Add(parameter6);

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
            parameter9.ParameterName = "@SkolskaSprema";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = SkolskaSprema;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@OrganizacionaJedinica";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = OrganizacionaJedinica;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@SifraERP";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 20;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = SifraERP;
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

        public void DeleteZaposleni(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteZaposleni";
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
