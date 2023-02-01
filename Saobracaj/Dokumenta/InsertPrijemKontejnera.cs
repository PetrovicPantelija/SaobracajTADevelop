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
    class InsertPrijemKontejnera
    {

        public void InsertPrijemKont( DateTime DatumPrijema,int StatusPrijema,string BrojKontejnera ,string RegBrKamiona, string ImeVozaca,int Posiljalac,int Primalac,int VlasnikKontejnera, int TipKontejnera, 	int VrstaRobe,int Buking, int StatusKontejnera,string BrojPlombe,int PlaniraniLager, int IdVoza, DateTime VremeDolaska, 	DateTime VremePripremljen, 	DateTime VremeOdlaska,	DateTime Datum, string Korisnik, Double Tara, Double Neto, string BrojPlombe2, int Organizator)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertPrijemKontejnera";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
            
            
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@DatumPrijema";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = DatumPrijema;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "StatusPrijema";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = StatusPrijema;
            myCommand.Parameters.Add(parameter1);

           

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@BrojKontejnera";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = BrojKontejnera;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@RegBrKamiona";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = RegBrKamiona;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@ImeVozaca";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 20;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = ImeVozaca;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Posiljalac";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Posiljalac;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Primalac";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Primalac;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@VlasnikKontejnera";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = VlasnikKontejnera;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@TipKontejnera";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = VlasnikKontejnera;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@VrstaRobe";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = VrstaRobe;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Buking";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Buking;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@StatusKontejnera";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = StatusKontejnera;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@BrojPlombe";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 30;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = BrojPlombe;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@PlaniraniLager";
            parameter13.SqlDbType = SqlDbType.Int;
           // parameter13.Size = 30;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = PlaniraniLager;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@IdVoza";
            parameter14.SqlDbType = SqlDbType.Int;
            // parameter13.Size = 30;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = IdVoza;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@VremeDolaska";
            parameter15.SqlDbType = SqlDbType.DateTime;
            // parameter13.Size = 30;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = VremeDolaska;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@VremePripremljen";
            parameter16.SqlDbType = SqlDbType.DateTime;
            // parameter13.Size = 30;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = VremePripremljen;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@VremeOdlaska";
            parameter17.SqlDbType = SqlDbType.DateTime;
            // parameter13.Size = 30;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = VremeOdlaska;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Datum";
            parameter18.SqlDbType = SqlDbType.DateTime;
          
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Datum;
            myCommand.Parameters.Add(parameter18);
            
            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Korisnik";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 20;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Korisnik;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Tara";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Tara;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Neto";
            parameter21.SqlDbType = SqlDbType.Decimal;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Neto;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@BrojPlombe2";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 30;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = BrojPlombe2;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Organizator";
            parameter23.SqlDbType = SqlDbType.Int;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Organizator;
            myCommand.Parameters.Add(parameter23);

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

        public void UpdPrijemKontejnera(int ID, DateTime DatumPrijema, int StatusPrijema, string BrojKontejnera, string RegBrKamiona, string ImeVozaca, int Posiljalac, int Primalac, int VlasnikKontejnera, int TipKontejnera, int VrstaRobe, int Buking, int StatusKontejnera, string BrojPlombe, int PlaniraniLager, int IdVoza, DateTime VremeDolaska, DateTime VremePripremljen, DateTime VremeOdlaska, DateTime Datum, string Korisnik, double Tara, double Neto, string BrojPlombe2, int Organizator)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdatePrijemKontejnera";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@DatumPrijema";
            parameter0.SqlDbType = SqlDbType.DateTime;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = DatumPrijema;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "StatusPrijema";
            parameter1.SqlDbType = SqlDbType.Int;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = StatusPrijema;
            myCommand.Parameters.Add(parameter1);



            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@BrojKontejnera";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Size = 20;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = BrojKontejnera;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@RegBrKamiona";
            parameter3.SqlDbType = SqlDbType.NVarChar;
            parameter3.Size = 20;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = RegBrKamiona;
            myCommand.Parameters.Add(parameter3);


            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@ImeVozaca";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 20;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = ImeVozaca;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Posiljalac";
            parameter5.SqlDbType = SqlDbType.Int;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Posiljalac;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Primalac";
            parameter6.SqlDbType = SqlDbType.Int;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Primalac;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@VlasnikKontejnera";
            parameter7.SqlDbType = SqlDbType.Int;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = VlasnikKontejnera;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@TipKontejnera";
            parameter8.SqlDbType = SqlDbType.Int;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = VlasnikKontejnera;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@VrstaRobe";
            parameter9.SqlDbType = SqlDbType.Int;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = VrstaRobe;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@Buking";
            parameter10.SqlDbType = SqlDbType.Int;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = Buking;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@StatusKontejnera";
            parameter11.SqlDbType = SqlDbType.Int;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = StatusKontejnera;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@BrojPlombe";
            parameter12.SqlDbType = SqlDbType.NVarChar;
            parameter12.Size = 30;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = BrojPlombe;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@PlaniraniLager";
            parameter13.SqlDbType = SqlDbType.Int;
            // parameter13.Size = 30;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = PlaniraniLager;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@IdVoza";
            parameter14.SqlDbType = SqlDbType.Int;
            // parameter13.Size = 30;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = IdVoza;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@VremeDolaska";
            parameter15.SqlDbType = SqlDbType.DateTime;
            // parameter13.Size = 30;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = VremeDolaska;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@VremePripremljen";
            parameter16.SqlDbType = SqlDbType.DateTime;
            // parameter13.Size = 30;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = VremePripremljen;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@VremeOdlaska";
            parameter17.SqlDbType = SqlDbType.DateTime;
            // parameter13.Size = 30;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = VremeOdlaska;
            myCommand.Parameters.Add(parameter17);

            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@Datum";
            parameter18.SqlDbType = SqlDbType.NVarChar;
            parameter18.Size = 20;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = Datum;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@Korisnik";
            parameter19.SqlDbType = SqlDbType.NVarChar;
            parameter19.Size = 20;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = Korisnik;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@Tara";
            parameter20.SqlDbType = SqlDbType.Decimal;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = Tara;
            myCommand.Parameters.Add(parameter20);

            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@Neto";
            parameter21.SqlDbType = SqlDbType.Decimal;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = Neto;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@BrojPlombe2";
            parameter22.SqlDbType = SqlDbType.NVarChar;
            parameter22.Size = 30;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = BrojPlombe2;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@Organizator";
            parameter23.SqlDbType = SqlDbType.Int;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = Organizator;
            myCommand.Parameters.Add(parameter23);
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
                throw new Exception("Neuspešan upis u Bazu");
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

          public void DeletePrijemKontejnera(int ID)
          {
              var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
              SqlConnection myConnection = new SqlConnection(s_connection);
              SqlCommand myCommand = myConnection.CreateCommand();
              myCommand.CommandText = "DeletePrijemKontejnera";
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


