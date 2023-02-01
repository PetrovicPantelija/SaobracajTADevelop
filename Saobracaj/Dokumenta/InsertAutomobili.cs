using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Saobracaj.Dokumenta
{
    class InsertAutomobili
    {
        public void InsAutomobiliServis(int IDAutomobila, DateTime DatumServisa, int VelikiServis, string KM, int Zaposleni, int Partner, string Napomena)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertAutomobiliServis";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDAutomobila";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = IDAutomobila;
            myCommand.Parameters.Add(parameter);
 

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@DatumServisa";
            parameter2.SqlDbType = SqlDbType.DateTime;
           // parameter2.Size = 500;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = DatumServisa;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@VelikiServis";
            parameter3.SqlDbType = SqlDbType.Int;
            // parameter2.Size = 500;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = VelikiServis;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@KM";
            parameter4.SqlDbType = SqlDbType.NVarChar;
             parameter4.Size = 50;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = VelikiServis;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Zaposleni";
            parameter5.SqlDbType = SqlDbType.Int;
          //  parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Zaposleni;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Partner";
            parameter6.SqlDbType = SqlDbType.Int;
            //  parameter5.Size = 50;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Partner;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Napomena";
            parameter7.SqlDbType = SqlDbType.NVarChar;
              parameter7.Size = 250;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Napomena;
            myCommand.Parameters.Add(parameter7);

           


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
                throw new Exception("Neuspešan upis dokumenta u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis dokumenta u bazu", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void UpdAutomobiliServis(int ID, int IDAutomobila, DateTime DatumServisa, int VelikiServis, string KM, int Zaposleni, int Partner, string Napomena)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAutomobiliServis";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@IDAutomobila";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = IDAutomobila;
            myCommand.Parameters.Add(parameter);


            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@DatumServisa";
            parameter2.SqlDbType = SqlDbType.DateTime;
            // parameter2.Size = 500;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = DatumServisa;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@VelikiServis";
            parameter3.SqlDbType = SqlDbType.Int;
            // parameter2.Size = 500;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = VelikiServis;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@KM";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 50;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = VelikiServis;
            myCommand.Parameters.Add(parameter4);


            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@Zaposleni";
            parameter5.SqlDbType = SqlDbType.Int;
            //  parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = Zaposleni;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@Partner";
            parameter6.SqlDbType = SqlDbType.Int;
            //  parameter5.Size = 50;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = Partner;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Napomena";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 250;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Napomena;
            myCommand.Parameters.Add(parameter7);




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
                throw new Exception("Neuspešan upis dokumenta u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis dokumenta u bazu", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void DelAutomobiliServis(int ID)
        {

            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteAutomobiliServis";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@ID";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = ID;
            myCommand.Parameters.Add(parameter0);


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
                throw new Exception("Neuspešan upis dokumenta u Bazu");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Nije uspeo upis dokumenta u bazu", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }



        public void InsAutomobili(int Zaposleni, string RegBr, string Marka, int Sluzbeni  
            , string Model, DateTime DatumRegistracije, int GodinaProizvodnje, string Gorivo 
           , int ZapreminaMotora, string Kategorija, DateTime VServisUradjen, double VServisKM
           , DateTime VServisSledeci, DateTime MServisUradjen, double MServisKM, DateTime MServisSledeci
           , string BrojPlombe1, string BrojPlombe2, DateTime PPAparatDatumOvere, DateTime PPAparatDatumIsteka
           , string PPAparatSeriski, DateTime PRvaPomocDatumIsteka, int TrougaoIma, int SajlaZaVucu
             , int Marker, int Lanci, string LokacijaLanci, string ZGDOT
           , string ZGLokacija, string ZGDubinaSare, string LGDot, string LGLokacija
           , string LGDubinaSare, string Napomena, string CistocaSpolja, string CistocaUnutra
           , string NivoUlja, string Nepravilnosti, string MestoTroska
            )
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "InsertAutomobili";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


            



            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@Zaposleni";
            parameter0.SqlDbType = SqlDbType.Int;

            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = Zaposleni;
            myCommand.Parameters.Add(parameter0);


            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@RegBr";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 30;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = RegBr;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Marka";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 60;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Marka;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Sluzbeni";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Sluzbeni;
            myCommand.Parameters.Add(parameter3);

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Model";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 50;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Model;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@DatumRegistracije";
            parameter5.SqlDbType = SqlDbType.DateTime;
           // parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = DatumRegistracije;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@GodinaProizvodnje";
            parameter6.SqlDbType = SqlDbType.Int;
            // parameter5.Size = 50;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = GodinaProizvodnje;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Gorivo";
            parameter7.SqlDbType = SqlDbType.NVarChar;
             parameter7.Size = 50;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Gorivo;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@ZapreminaMotora";
            parameter8.SqlDbType = SqlDbType.Int;
           // parameter8.Size = 50;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = ZapreminaMotora;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Kategorija";
            parameter9.SqlDbType = SqlDbType.NVarChar;
            parameter9.Size = 50;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Kategorija;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@VServisUradjen";
            parameter10.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = VServisUradjen;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@VServisKM";
            parameter11.SqlDbType = SqlDbType.Decimal;
            // parameter9.Size = 50;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = VServisKM;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@VServisSledeci";
            parameter12.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = VServisSledeci;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@MServisUradjen";
            parameter13.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = MServisUradjen;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@MServisKM";
            parameter14.SqlDbType = SqlDbType.Decimal;
            // parameter9.Size = 50;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = MServisKM;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@MServisSledeci";
            parameter15.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = MServisSledeci;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@BrojPlombe1";
            parameter16.SqlDbType = SqlDbType.NVarChar;
             parameter16.Size = 50;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = BrojPlombe1;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@BrojPlombe2";
            parameter17.SqlDbType = SqlDbType.NVarChar;
             parameter17.Size = 50;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = BrojPlombe2;
            myCommand.Parameters.Add(parameter17);


            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@PPAparatDatumOvere";
            parameter18.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = PPAparatDatumOvere;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@PPAparatDatumIsteka";
            parameter19.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = PPAparatDatumIsteka;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@PPAparatSeriski";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 50;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = PPAparatSeriski;
            myCommand.Parameters.Add(parameter20);


            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@PRvaPomocDatumIsteka";
            parameter21.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = PRvaPomocDatumIsteka;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@TrougaoIma";
            parameter22.SqlDbType = SqlDbType.Int;
            // parameter9.Size = 50;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = TrougaoIma;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@SajlaZaVucu";
            parameter23.SqlDbType = SqlDbType.Int;
            // parameter9.Size = 50;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = SajlaZaVucu;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Marker";
            parameter24.SqlDbType = SqlDbType.Int;
            // parameter9.Size = 50;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Marker;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@Lanci";
            parameter25.SqlDbType = SqlDbType.Int;
            // parameter9.Size = 50;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = Lanci;
            myCommand.Parameters.Add(parameter25);


            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@LokacijaLanci";
            parameter26.SqlDbType = SqlDbType.NVarChar;
            parameter26.Size = 50;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = LokacijaLanci;
            myCommand.Parameters.Add(parameter26);

            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@ZGDOT";
            parameter27.SqlDbType = SqlDbType.NVarChar;
            parameter27.Size = 50;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = ZGDOT;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@ZGLokacija";
            parameter28.SqlDbType = SqlDbType.NVarChar;
            parameter28.Size = 50;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = ZGLokacija;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@ZGDubinaSare";
            parameter29.SqlDbType = SqlDbType.NVarChar;
            parameter29.Size = 50;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = ZGDubinaSare;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@LGDot";
            parameter30.SqlDbType = SqlDbType.NVarChar;
            parameter30.Size = 50;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = LGDot;
            myCommand.Parameters.Add(parameter30);

            SqlParameter parameter31 = new SqlParameter();
            parameter31.ParameterName = "@LGLokacija";
            parameter31.SqlDbType = SqlDbType.NVarChar;
            parameter31.Size = 50;
            parameter31.Direction = ParameterDirection.Input;
            parameter31.Value = LGLokacija;
            myCommand.Parameters.Add(parameter31);

            SqlParameter parameter32 = new SqlParameter();
            parameter32.ParameterName = "@LGDubinaSare";
            parameter32.SqlDbType = SqlDbType.NVarChar;
            parameter32.Size = 50;
            parameter32.Direction = ParameterDirection.Input;
            parameter32.Value = LGDubinaSare;
            myCommand.Parameters.Add(parameter32);

            SqlParameter parameter33 = new SqlParameter();
            parameter33.ParameterName = "@Napomena";
            parameter33.SqlDbType = SqlDbType.NVarChar;
            parameter33.Size = 350;
            parameter33.Direction = ParameterDirection.Input;
            parameter33.Value = Napomena;
            myCommand.Parameters.Add(parameter33);

            SqlParameter parameter34 = new SqlParameter();
            parameter34.ParameterName = "@CistocaSpolja";
            parameter34.SqlDbType = SqlDbType.NVarChar;
            parameter34.Size = 50;
            parameter34.Direction = ParameterDirection.Input;
            parameter34.Value = CistocaSpolja;
            myCommand.Parameters.Add(parameter34);

            SqlParameter parameter35 = new SqlParameter();
            parameter35.ParameterName = "@CistocaUnutra";
            parameter35.SqlDbType = SqlDbType.NVarChar;
            parameter35.Size = 50;
            parameter35.Direction = ParameterDirection.Input;
            parameter35.Value = CistocaUnutra;
            myCommand.Parameters.Add(parameter35);

            SqlParameter parameter36 = new SqlParameter();
            parameter36.ParameterName = "@NivoUlja";
            parameter36.SqlDbType = SqlDbType.NVarChar;
            parameter36.Size = 50;
            parameter36.Direction = ParameterDirection.Input;
            parameter36.Value = NivoUlja;
            myCommand.Parameters.Add(parameter36);

            SqlParameter parameter37 = new SqlParameter();
            parameter37.ParameterName = "@Nepravilnosti";
            parameter37.SqlDbType = SqlDbType.NVarChar;
            parameter37.Size = 50;
            parameter37.Direction = ParameterDirection.Input;
            parameter37.Value = Nepravilnosti;
            myCommand.Parameters.Add(parameter37);


            SqlParameter parameter38 = new SqlParameter();
            parameter38.ParameterName = "@MestoTroska";
            parameter38.SqlDbType = SqlDbType.NVarChar;
            parameter38.Size = 50;
            parameter38.Direction = ParameterDirection.Input;
            parameter38.Value = MestoTroska;
            myCommand.Parameters.Add(parameter38);
         

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
                throw new Exception("Neuspešan upis NHM brojeva");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Unos NHM broja je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }


        public void UpdAutobili(int ID, int Zaposleni, string RegBr, string Marka, int Sluzbeni
            , string Model, DateTime DatumRegistracije, int GodinaProizvodnje, string Gorivo
           , int ZapreminaMotora, string Kategorija, DateTime VServisUradjen, double VServisKM
           , DateTime VServisSledeci, DateTime MServisUradjen, double MServisKM, DateTime MServisSledeci
           , string BrojPlombe1, string BrojPlombe2, DateTime PPAparatDatumOvere, DateTime PPAparatDatumIsteka
           , string PPAparatSeriski, DateTime PRvaPomocDatumIsteka, int TrougaoIma, int SajlaZaVucu
             , int Marker, int Lanci, string LokacijaLanci, string ZGDOT
           , string ZGLokacija, string ZGDubinaSare, string LGDot, string LGLokacija
           , string LGDubinaSare, string Napomena, string CistocaSpolja, string CistocaUnutra
           , string NivoUlja, string Nepravilnosti, string MestoTroska)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "UpdateAutomobili";
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;


            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ID;
            myCommand.Parameters.Add(parameter);

            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "@Zaposleni";
            parameter0.SqlDbType = SqlDbType.Int;
            parameter0.Direction = ParameterDirection.Input;
            parameter0.Value = Zaposleni;
            myCommand.Parameters.Add(parameter0);


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@RegBr";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Size = 30;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = RegBr;
            myCommand.Parameters.Add(parameter1);

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Marka";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter.Size = 60;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = Marka;
            myCommand.Parameters.Add(parameter2);

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@Sluzbeni";
            parameter3.SqlDbType = SqlDbType.Int;
            parameter3.Direction = ParameterDirection.Input;
            parameter3.Value = Sluzbeni;
            myCommand.Parameters.Add(parameter3);
            
            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@Model";
            parameter4.SqlDbType = SqlDbType.NVarChar;
            parameter4.Size = 50;
            parameter4.Direction = ParameterDirection.Input;
            parameter4.Value = Model;
            myCommand.Parameters.Add(parameter4);

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@DatumRegistracije";
            parameter5.SqlDbType = SqlDbType.DateTime;
            // parameter5.Size = 50;
            parameter5.Direction = ParameterDirection.Input;
            parameter5.Value = DatumRegistracije;
            myCommand.Parameters.Add(parameter5);

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "@GodinaProizvodnje";
            parameter6.SqlDbType = SqlDbType.Int;
            // parameter5.Size = 50;
            parameter6.Direction = ParameterDirection.Input;
            parameter6.Value = GodinaProizvodnje;
            myCommand.Parameters.Add(parameter6);

            SqlParameter parameter7 = new SqlParameter();
            parameter7.ParameterName = "@Gorivo";
            parameter7.SqlDbType = SqlDbType.NVarChar;
            parameter7.Size = 50;
            parameter7.Direction = ParameterDirection.Input;
            parameter7.Value = Gorivo;
            myCommand.Parameters.Add(parameter7);

            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "@ZapreminaMotora";
            parameter8.SqlDbType = SqlDbType.Int;
            // parameter8.Size = 50;
            parameter8.Direction = ParameterDirection.Input;
            parameter8.Value = ZapreminaMotora;
            myCommand.Parameters.Add(parameter8);

            SqlParameter parameter9 = new SqlParameter();
            parameter9.ParameterName = "@Kategorija";
            parameter9.SqlDbType = SqlDbType.NVarChar;
            parameter9.Size = 50;
            parameter9.Direction = ParameterDirection.Input;
            parameter9.Value = Kategorija;
            myCommand.Parameters.Add(parameter9);

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "@VServisUradjen";
            parameter10.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter10.Direction = ParameterDirection.Input;
            parameter10.Value = VServisUradjen;
            myCommand.Parameters.Add(parameter10);

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "@VServisKM";
            parameter11.SqlDbType = SqlDbType.Decimal;
            // parameter9.Size = 50;
            parameter11.Direction = ParameterDirection.Input;
            parameter11.Value = VServisKM;
            myCommand.Parameters.Add(parameter11);

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "@VServisSledeci";
            parameter12.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter12.Direction = ParameterDirection.Input;
            parameter12.Value = VServisSledeci;
            myCommand.Parameters.Add(parameter12);

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "@MServisUradjen";
            parameter13.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter13.Direction = ParameterDirection.Input;
            parameter13.Value = MServisUradjen;
            myCommand.Parameters.Add(parameter13);

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "@MServisKM";
            parameter14.SqlDbType = SqlDbType.Decimal;
            // parameter9.Size = 50;
            parameter14.Direction = ParameterDirection.Input;
            parameter14.Value = MServisKM;
            myCommand.Parameters.Add(parameter14);

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "@MServisSledeci";
            parameter15.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter15.Direction = ParameterDirection.Input;
            parameter15.Value = MServisSledeci;
            myCommand.Parameters.Add(parameter15);

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "@BrojPlombe1";
            parameter16.SqlDbType = SqlDbType.NVarChar;
            parameter16.Size = 50;
            parameter16.Direction = ParameterDirection.Input;
            parameter16.Value = BrojPlombe1;
            myCommand.Parameters.Add(parameter16);

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "@BrojPlombe2";
            parameter17.SqlDbType = SqlDbType.NVarChar;
            parameter17.Size = 50;
            parameter17.Direction = ParameterDirection.Input;
            parameter17.Value = BrojPlombe2;
            myCommand.Parameters.Add(parameter17);


            SqlParameter parameter18 = new SqlParameter();
            parameter18.ParameterName = "@PPAparatDatumOvere";
            parameter18.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter18.Direction = ParameterDirection.Input;
            parameter18.Value = PPAparatDatumOvere;
            myCommand.Parameters.Add(parameter18);

            SqlParameter parameter19 = new SqlParameter();
            parameter19.ParameterName = "@PPAparatDatumIsteka";
            parameter19.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter19.Direction = ParameterDirection.Input;
            parameter19.Value = PPAparatDatumIsteka;
            myCommand.Parameters.Add(parameter19);

            SqlParameter parameter20 = new SqlParameter();
            parameter20.ParameterName = "@PPAparatSeriski";
            parameter20.SqlDbType = SqlDbType.NVarChar;
            parameter20.Size = 50;
            parameter20.Direction = ParameterDirection.Input;
            parameter20.Value = PPAparatSeriski;
            myCommand.Parameters.Add(parameter20);


            SqlParameter parameter21 = new SqlParameter();
            parameter21.ParameterName = "@PRvaPomocDatumIsteka";
            parameter21.SqlDbType = SqlDbType.DateTime;
            // parameter9.Size = 50;
            parameter21.Direction = ParameterDirection.Input;
            parameter21.Value = PRvaPomocDatumIsteka;
            myCommand.Parameters.Add(parameter21);

            SqlParameter parameter22 = new SqlParameter();
            parameter22.ParameterName = "@TrougaoIma";
            parameter22.SqlDbType = SqlDbType.Int;
            // parameter9.Size = 50;
            parameter22.Direction = ParameterDirection.Input;
            parameter22.Value = TrougaoIma;
            myCommand.Parameters.Add(parameter22);

            SqlParameter parameter23 = new SqlParameter();
            parameter23.ParameterName = "@SajlaZaVucu";
            parameter23.SqlDbType = SqlDbType.Int;
            // parameter9.Size = 50;
            parameter23.Direction = ParameterDirection.Input;
            parameter23.Value = SajlaZaVucu;
            myCommand.Parameters.Add(parameter23);

            SqlParameter parameter24 = new SqlParameter();
            parameter24.ParameterName = "@Marker";
            parameter24.SqlDbType = SqlDbType.Int;
            // parameter9.Size = 50;
            parameter24.Direction = ParameterDirection.Input;
            parameter24.Value = Marker;
            myCommand.Parameters.Add(parameter24);

            SqlParameter parameter25 = new SqlParameter();
            parameter25.ParameterName = "@Lanci";
            parameter25.SqlDbType = SqlDbType.Int;
            // parameter9.Size = 50;
            parameter25.Direction = ParameterDirection.Input;
            parameter25.Value = Lanci;
            myCommand.Parameters.Add(parameter25);


            SqlParameter parameter26 = new SqlParameter();
            parameter26.ParameterName = "@LokacijaLanci";
            parameter26.SqlDbType = SqlDbType.NVarChar;
            parameter26.Size = 50;
            parameter26.Direction = ParameterDirection.Input;
            parameter26.Value = LokacijaLanci;
            myCommand.Parameters.Add(parameter26);

            SqlParameter parameter27 = new SqlParameter();
            parameter27.ParameterName = "@ZGDOT";
            parameter27.SqlDbType = SqlDbType.NVarChar;
            parameter27.Size = 50;
            parameter27.Direction = ParameterDirection.Input;
            parameter27.Value = ZGDOT;
            myCommand.Parameters.Add(parameter27);

            SqlParameter parameter28 = new SqlParameter();
            parameter28.ParameterName = "@ZGLokacija";
            parameter28.SqlDbType = SqlDbType.NVarChar;
            parameter28.Size = 50;
            parameter28.Direction = ParameterDirection.Input;
            parameter28.Value = ZGLokacija;
            myCommand.Parameters.Add(parameter28);

            SqlParameter parameter29 = new SqlParameter();
            parameter29.ParameterName = "@ZGDubinaSare";
            parameter29.SqlDbType = SqlDbType.NVarChar;
            parameter29.Size = 50;
            parameter29.Direction = ParameterDirection.Input;
            parameter29.Value = ZGDubinaSare;
            myCommand.Parameters.Add(parameter29);

            SqlParameter parameter30 = new SqlParameter();
            parameter30.ParameterName = "@LGDot";
            parameter30.SqlDbType = SqlDbType.NVarChar;
            parameter30.Size = 50;
            parameter30.Direction = ParameterDirection.Input;
            parameter30.Value = LGDot;
            myCommand.Parameters.Add(parameter30);

            SqlParameter parameter31 = new SqlParameter();
            parameter31.ParameterName = "@LGLokacija";
            parameter31.SqlDbType = SqlDbType.NVarChar;
            parameter31.Size = 50;
            parameter31.Direction = ParameterDirection.Input;
            parameter31.Value = LGLokacija;
            myCommand.Parameters.Add(parameter31);

            SqlParameter parameter32 = new SqlParameter();
            parameter32.ParameterName = "@LGDubinaSare";
            parameter32.SqlDbType = SqlDbType.NVarChar;
            parameter32.Size = 50;
            parameter32.Direction = ParameterDirection.Input;
            parameter32.Value = LGDubinaSare;
            myCommand.Parameters.Add(parameter32);

            SqlParameter parameter33 = new SqlParameter();
            parameter33.ParameterName = "@Napomena";
            parameter33.SqlDbType = SqlDbType.NVarChar;
            parameter33.Size = 350;
            parameter33.Direction = ParameterDirection.Input;
            parameter33.Value = Napomena;
            myCommand.Parameters.Add(parameter33);

            SqlParameter parameter34 = new SqlParameter();
            parameter34.ParameterName = "@CistocaSpolja";
            parameter34.SqlDbType = SqlDbType.NVarChar;
            parameter34.Size = 50;
            parameter34.Direction = ParameterDirection.Input;
            parameter34.Value = CistocaSpolja;
            myCommand.Parameters.Add(parameter34);

            SqlParameter parameter35 = new SqlParameter();
            parameter35.ParameterName = "@CistocaUnutra";
            parameter35.SqlDbType = SqlDbType.NVarChar;
            parameter35.Size = 50;
            parameter35.Direction = ParameterDirection.Input;
            parameter35.Value = CistocaUnutra;
            myCommand.Parameters.Add(parameter35);

            SqlParameter parameter36 = new SqlParameter();
            parameter36.ParameterName = "@NivoUlja";
            parameter36.SqlDbType = SqlDbType.NVarChar;
            parameter36.Size = 50;
            parameter36.Direction = ParameterDirection.Input;
            parameter36.Value = NivoUlja;
            myCommand.Parameters.Add(parameter36);

            SqlParameter parameter37 = new SqlParameter();
            parameter37.ParameterName = "@Nepravilnosti";
            parameter37.SqlDbType = SqlDbType.NVarChar;
            parameter37.Size = 50;
            parameter37.Direction = ParameterDirection.Input;
            parameter37.Value = Nepravilnosti;
            myCommand.Parameters.Add(parameter37);


            SqlParameter parameter38 = new SqlParameter();
            parameter38.ParameterName = "@MestoTroska";
            parameter38.SqlDbType = SqlDbType.NVarChar;
            parameter38.Size = 50;
            parameter38.Direction = ParameterDirection.Input;
            parameter38.Value = MestoTroska;
            myCommand.Parameters.Add(parameter38);




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
                throw new Exception("Neuspešna promena NHM brojeva");
            }

            finally
            {
                if (!error)
                {
                    myTransaction.Commit();
                    MessageBox.Show("Promena NHM broja je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                myConnection.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }


        public void DeleteAutomobili(int ID)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "DeleteAutomobili";
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
                    MessageBox.Show("Brisanje nije uspešno", "",
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
