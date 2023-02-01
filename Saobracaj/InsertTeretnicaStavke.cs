using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Saobracaj
{
    class InsertTeretnicaStavke
    {
        public void InsTeretnicaStavke(int BrojTeretnice, int IDNajave, int Uvrstena, int Otkacena, string BrojKola, string Serija, double BrojOsovina, double Duzina, double Tara, double Neto, double G, double P, double R, double RR, string VRNP, int Otpravna, int Uputna, string Reon, string Primedba, double RucKoc, int Uvozna, int Izvozna, string RID, string Dokument)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertTeretnicaStavka";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@BrojTeretnice";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = BrojTeretnice;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDNajave";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = IDNajave;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Uvrstena";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Uvrstena;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Otkacena";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Otkacena;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@BrojKola";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 20;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = BrojKola;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Serija";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 20;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Serija;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@BrojOsovina";
            parameter7.SqlDbType = SqlDbType.Decimal;
           // parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = BrojOsovina;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Duzina";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Duzina;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Tara";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Tara;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Neto";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Neto;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@G";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = G;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@P";
            parameter12.SqlDbType = SqlDbType.Decimal;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = P;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@R";
            parameter13.SqlDbType = SqlDbType.Decimal;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = R;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@RR";
            parameter14.SqlDbType = SqlDbType.Decimal;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = RR;
            myCommand.Parameters.Add(parameter14);  
  
            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@VRNP";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 20;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = VRNP;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Otpravna";
            parameter16.SqlDbType = SqlDbType.Int;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Otpravna;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Uputna";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Uputna;
            myCommand.Parameters.Add(parameter17);
       
            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Reon";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Reon;
            myCommand.Parameters.Add(parameter18);
       
            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Primedba";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Primedba;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@RucKoc";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = RucKoc;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Uvozna";
            parameter21.SqlDbType = SqlDbType.Int;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Uvozna;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Izvozna";
            parameter22.SqlDbType = SqlDbType.Int;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Izvozna;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@RID";
            parameter23.SqlDbType = SqlDbType.NVarChar;
            parameter23.Size = 30;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = RID;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Dokument";
            parameter24.SqlDbType = SqlDbType.NVarChar;
            parameter24.Size = 20;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Dokument;
            myCommand.Parameters.Add(parameter24);

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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdTeretnicaStavke(int Rb, int BrojTeretnice, int IDNajave, int Uvrstena, int Otkacena, string BrojKola, string Serija, double BrojOsovina, double Duzina, double Tara, double Neto, double G, double P, double R, double RR, string VRNP, int Otpravna, int Uputna, string Reon, string Primedba, double RucKoc, int Uvozna, int Izvozna, string RID, string Dokument)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTeretnicaStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@RB";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = Rb;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@BrojTeretnice";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = BrojTeretnice;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDNajave";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = IDNajave;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Uvrstena";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Uvrstena;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Otkacena";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Otkacena;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@BrojKola";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 20;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = BrojKola;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Serija";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 20;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Serija;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@BrojOsovina";
            parameter7.SqlDbType = SqlDbType.Decimal;
           // parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = BrojOsovina;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Duzina";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Duzina;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Tara";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Tara;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Neto";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Neto;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@G";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = G;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@P";
            parameter12.SqlDbType = SqlDbType.Decimal;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = P;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@R";
            parameter13.SqlDbType = SqlDbType.Decimal;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = R;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@RR";
            parameter14.SqlDbType = SqlDbType.Decimal;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = RR;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@VRNP";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 20;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = VRNP;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Otpravna";
            parameter16.SqlDbType = SqlDbType.Int;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Otpravna;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Uputna";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Uputna;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Reon";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Reon;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Primedba";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Primedba;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@RucKoc";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = RucKoc;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Uvozna";
            parameter21.SqlDbType = SqlDbType.Int;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Uvozna;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Izvozna";
            parameter22.SqlDbType = SqlDbType.Int;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Izvozna;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@RID";
            parameter23.SqlDbType = SqlDbType.NVarChar;
            parameter23.Size = 30;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = RID;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Dokument";
            parameter24.SqlDbType = SqlDbType.NVarChar;
            parameter24.Size = 20;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Dokument;
            myCommand.Parameters.Add(parameter24);


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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void DeleteTeretnicaStavke(int BrojTeretnice, int RB)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteTeretnicaStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@BrojTeretnice";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = BrojTeretnice;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@RB";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = RB;
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
                throw new Exception("Brisanje neuspešno");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Brisanje Teretnice uspešno završeno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void UpdateRB(int ID, int RB)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTeretnicaStavkeRB";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@RB";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = RB;
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
                throw new Exception("Brisanje neuspešno");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Brisanje Teretnice uspešno završeno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void InsTeretnicaStavkeKopiranje(int TeretnicaIz, int TeretnicaU, int IDStavke)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertTeretnicaStavkaKopiraj";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@TeretnicaIz";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = TeretnicaIz;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@TeretnicaU";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = TeretnicaU;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@IDStavke";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = IDStavke;
            myCommand.Parameters.Add(parameter3);

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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        
        }

        public void InsTeretnicaStavkeRN(int IDStavke, int StanicaOd, int StanicaDo)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertTeretnicaStavkaRN";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDStavke";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = IDStavke;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@StanicaOd";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = StanicaOd;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@StanicaDo";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = StanicaDo;
            myCommand.Parameters.Add(parameter3);


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
                throw new Exception("Neuspešan upis stavki teretnice u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdTeretnicaStavkeSve(int ID, int Rb, int BrojTeretnice, int IDNajave, int Uvrstena, int Otkacena, string BrojKola, string Serija, double BrojOsovina, double Duzina, double Tara, double Neto, double G, double P, double R, double RR, string VRNP, int Otpravna, int Uputna, string Reon, string Primedba, double RucKoc, int Uvozna, int Izvozna, string RID, string Dokument)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTeretnicaStavkeSve";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@RB";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = Rb;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@BrojTeretnice";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = BrojTeretnice;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@IDNajave";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = IDNajave;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Uvrstena";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Uvrstena;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Otkacena";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Otkacena;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@BrojKola";
            parameter5.SqlDbType = SqlDbType.NVarChar;
            parameter5.Size = 20;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = BrojKola;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Serija";
            parameter6.SqlDbType = SqlDbType.NVarChar;
            parameter6.Size = 20;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Serija;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@BrojOsovina";
            parameter7.SqlDbType = SqlDbType.Decimal;
            // parameter7.Size = 20;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = BrojOsovina;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@Duzina";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = Duzina;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Tara";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Tara;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Neto";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Neto;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@G";
            parameter11.SqlDbType = SqlDbType.Decimal;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = G;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@P";
            parameter12.SqlDbType = SqlDbType.Decimal;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = P;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@R";
            parameter13.SqlDbType = SqlDbType.Decimal;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = R;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@RR";
            parameter14.SqlDbType = SqlDbType.Decimal;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = RR;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@VRNP";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 20;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = VRNP;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Otpravna";
            parameter16.SqlDbType = SqlDbType.Int;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Otpravna;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@Uputna";
            parameter17.SqlDbType = SqlDbType.Int;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = Uputna;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Reon";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Reon;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Primedba";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Primedba;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@RucKoc";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = RucKoc;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Uvozna";
            parameter21.SqlDbType = SqlDbType.Int;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Uvozna;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@Izvozna";
            parameter22.SqlDbType = SqlDbType.Int;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = Izvozna;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@RID";
            parameter23.SqlDbType = SqlDbType.NVarChar;
            parameter23.Size = 30;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = RID;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Dokument";
            parameter24.SqlDbType = SqlDbType.NVarChar;
            parameter24.Size = 20;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Dokument;
            myCommand.Parameters.Add(parameter24);

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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }


            }
        }

        public void UpdateTeretnicaRBUpDown(int BrojTeretnice, int RB, int ID, int Smer)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTeretnicaRBUpDown";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@BrojTeretnice";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = BrojTeretnice;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@RB";
            parameter2.SqlDbType = SqlDbType.Int;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = RB;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@ID";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = ID;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Smer";
            parameter4.SqlDbType = SqlDbType.Int;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Smer;
            myCommand.Parameters.Add(parameter4);

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
                    MessageBox.Show("Brisanje Teretnice uspešno završeno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

        public void UpdateOstaleStavke(int ID, int RB, string BrojKola, string Serija, double BrojOsovina, double Duzina, double Tara, double Neto, double G, double P, double R, double RR, string VRNP,  string Reon, string Primedba, double RucKoc,  string RID, string Dokument)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateTeretnicaOstaleStavke";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@RB";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = RB;
            myCommand.Parameters.Add(parameter0);

           
            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@BrojKola";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 20;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = BrojKola;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Serija";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Serija;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@BrojOsovina";
            parameter3.SqlDbType = SqlDbType.Decimal;
            // parameter7.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = BrojOsovina;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Duzina";
            parameter4.SqlDbType = SqlDbType.Decimal;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Duzina;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Tara";
            parameter5.SqlDbType = SqlDbType.Decimal;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Tara;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Neto";
            parameter6.SqlDbType = SqlDbType.Decimal;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Neto;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@G";
            parameter7.SqlDbType = SqlDbType.Decimal;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = G;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@P";
            parameter8.SqlDbType = SqlDbType.Decimal;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = P;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@R";
            parameter9.SqlDbType = SqlDbType.Decimal;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = R;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@RR";
            parameter10.SqlDbType = SqlDbType.Decimal;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = RR;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@VRNP";
            parameter11.SqlDbType = SqlDbType.NVarChar;
            parameter11.Size = 20;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = VRNP;
            myCommand.Parameters.Add(parameter11);

           
            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@Reon";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 20;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = Reon;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@Primedba";
            parameter13.SqlDbType = SqlDbType.NVarChar;
            parameter13.Size = 50;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = Primedba;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@RucKoc";
            parameter14.SqlDbType = SqlDbType.Decimal;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = RucKoc;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@RID";
            parameter15.SqlDbType = SqlDbType.NVarChar;
            parameter15.Size = 30;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = RID;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@Dokument";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 20;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = Dokument;
            myCommand.Parameters.Add(parameter16);

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
                throw new Exception("Neuspešan upis prevoznika u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis prevoznika", "",
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
