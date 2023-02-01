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
    class InsertTelegrami
    {
        string connect = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

       public void InsTelegrami(int BrojTelegrama,int PrugaID,int OdStanice,int DoStanice, string Kolosek, DateTime VaziOd, DateTime VaziDo, 
           DateTime TrajeOd,DateTime TrajeDo,string Napomena,bool Aktivan,string PDF,bool NarocitaPosiljka)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "InsertTelegrami";
            cmd.CommandType = CommandType.StoredProcedure;
            

            SqlParameter paramBrTelegrama = new SqlParameter();
            paramBrTelegrama.ParameterName = "@BrTelegrama";
            paramBrTelegrama.SqlDbType = SqlDbType.Int;
            paramBrTelegrama.Direction = ParameterDirection.Input;
            paramBrTelegrama.Value = BrojTelegrama;
            cmd.Parameters.Add(paramBrTelegrama);

            SqlParameter paramPruga = new SqlParameter();
            paramPruga.ParameterName = "@PrugaID";
            paramPruga.SqlDbType = SqlDbType.Int;
            paramPruga.Direction = ParameterDirection.Input;
            paramPruga.Value = PrugaID;
            cmd.Parameters.Add(paramPruga);

            SqlParameter paramOdStanice = new SqlParameter();
            paramOdStanice.ParameterName = "@OdStanice";
            paramOdStanice.SqlDbType = SqlDbType.Int;
            paramOdStanice.Direction = ParameterDirection.Input;
            paramOdStanice.Value = OdStanice;
            cmd.Parameters.Add(paramOdStanice);

            SqlParameter paramDoStanice = new SqlParameter();
            paramDoStanice.ParameterName = "@DoStanice";
            paramDoStanice.SqlDbType = SqlDbType.Int;
            paramDoStanice.Direction = ParameterDirection.Input;
            paramDoStanice.Value = DoStanice;
            cmd.Parameters.Add(paramDoStanice);

            SqlParameter paramKolosek = new SqlParameter();
            paramKolosek.ParameterName = "@Kolosek";
            paramKolosek.SqlDbType = SqlDbType.NChar;
            paramKolosek.Size = 50;
            paramKolosek.Direction = ParameterDirection.Input;
            paramKolosek.Value = Kolosek;
            cmd.Parameters.Add(paramKolosek);

            SqlParameter paramVaziOd = new SqlParameter();
            paramVaziOd.ParameterName = "@VaziOd";
            paramVaziOd.SqlDbType = SqlDbType.DateTime2;
            paramVaziOd.Direction = ParameterDirection.Input;
            paramVaziOd.Value = VaziOd;
            cmd.Parameters.Add(paramVaziOd);

            SqlParameter paramVaziDo = new SqlParameter();
            paramVaziDo.ParameterName = "@VaziDo";
            paramVaziDo.SqlDbType = SqlDbType.DateTime2;
            paramVaziDo.Direction = ParameterDirection.Input;
            paramVaziDo.Value = VaziDo;
            cmd.Parameters.Add(paramVaziDo);

            SqlParameter paramTrajeOd = new SqlParameter();
            paramTrajeOd.ParameterName = "@TrajeOd";
            paramTrajeOd.SqlDbType = SqlDbType.DateTime;
            //paramTrajeOd.Size = 20;
            paramTrajeOd.Direction = ParameterDirection.Input;
            paramTrajeOd.Value = TrajeOd;
            cmd.Parameters.Add(paramTrajeOd);

            SqlParameter paramTrajeDo = new SqlParameter();
            paramTrajeDo.ParameterName = "@TrajeDo";
            paramTrajeDo.SqlDbType = SqlDbType.DateTime;
            //paramTrajeDo.Size = 20;
            paramTrajeDo.Direction = ParameterDirection.Input;
            paramTrajeDo.Value = TrajeDo;
            cmd.Parameters.Add(paramTrajeDo);

            SqlParameter paramNapomena = new SqlParameter();
            paramNapomena.ParameterName = "@Napomena";
            paramNapomena.SqlDbType = SqlDbType.NVarChar;
            paramNapomena.Size = 250;
            paramNapomena.Direction = ParameterDirection.Input;
            paramNapomena.Value = Napomena;
            cmd.Parameters.Add(paramNapomena);

            SqlParameter paramAktivan = new SqlParameter();
            paramAktivan.ParameterName = "@Aktivan";
            paramAktivan.SqlDbType = SqlDbType.Bit;
            paramAktivan.Direction = ParameterDirection.Input;
            paramAktivan.Value = Aktivan;
            cmd.Parameters.Add(paramAktivan);

            SqlParameter pdf = new SqlParameter();
            pdf.ParameterName = "@PDF";
            pdf.SqlDbType = SqlDbType.NVarChar;
            pdf.Size = 500;
            pdf.Direction = ParameterDirection.Input;
            pdf.Value = PDF;
            cmd.Parameters.Add(pdf);

            SqlParameter paramNarocita = new SqlParameter();
            paramNarocita.ParameterName = "@NarocitaPosiljka";
            paramNarocita.SqlDbType = SqlDbType.Bit;
            paramNarocita.Direction = ParameterDirection.Input;
            paramNarocita.Value = NarocitaPosiljka;
            cmd.Parameters.Add(paramNarocita);

            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                throw new Exception("Neuspešan upis Telegrama brojeva");
            }

            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Unos NHM broja je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }

        }

        public void UpdTelegrami(int ID, int BrojTelegrama, int PrugaID, int OdStanice, int DoStanice, string Kolosek, DateTime VaziOd, DateTime VaziDo,
           DateTime TrajeOd, DateTime TrajeDo, string Napomena,bool Aktivan,string PDF,bool NarocitaPosiljka)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UpdateTelegrami";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramId = new SqlParameter();
            paramId.ParameterName = "@ID";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Direction = ParameterDirection.Input;
            paramId.Value = ID;
            cmd.Parameters.Add(paramId);

            SqlParameter paramBrTelegrama = new SqlParameter();
            paramBrTelegrama.ParameterName = "@BrTelegrama";
            paramBrTelegrama.SqlDbType = SqlDbType.Int;
            paramBrTelegrama.Direction = ParameterDirection.Input;
            paramBrTelegrama.Value = BrojTelegrama;
            cmd.Parameters.Add(paramBrTelegrama);

            SqlParameter paramPruga = new SqlParameter();
            paramPruga.ParameterName = "@PrugaID";
            paramPruga.SqlDbType = SqlDbType.Int;
            paramPruga.Direction = ParameterDirection.Input;
            paramPruga.Value = PrugaID;
            cmd.Parameters.Add(paramPruga);

            SqlParameter paramOdStanice = new SqlParameter();
            paramOdStanice.ParameterName = "@OdStanice";
            paramOdStanice.SqlDbType = SqlDbType.Int;
            paramOdStanice.Direction = ParameterDirection.Input;
            paramOdStanice.Value = OdStanice;
            cmd.Parameters.Add(paramOdStanice);

            SqlParameter paramDoStanice = new SqlParameter();
            paramDoStanice.ParameterName = "@DoStanice";
            paramDoStanice.SqlDbType = SqlDbType.Int;
            paramDoStanice.Direction = ParameterDirection.Input;
            paramDoStanice.Value = DoStanice;
            cmd.Parameters.Add(paramDoStanice);

            SqlParameter paramKolosek = new SqlParameter();
            paramKolosek.ParameterName = "@Kolosek";
            paramKolosek.SqlDbType = SqlDbType.NChar;
            paramKolosek.Size = 50;
            paramKolosek.Direction = ParameterDirection.Input;
            paramKolosek.Value = Kolosek;
            cmd.Parameters.Add(paramKolosek);

            SqlParameter paramVaziOd = new SqlParameter();
            paramVaziOd.ParameterName = "@VaziOd";
            paramVaziOd.SqlDbType = SqlDbType.DateTime;
            paramVaziOd.Direction = ParameterDirection.Input;
            paramVaziOd.Value = VaziOd;
            cmd.Parameters.Add(paramVaziOd);

            SqlParameter paramVaziDo = new SqlParameter();
            paramVaziDo.ParameterName = "@VaziDo";
            paramVaziDo.SqlDbType = SqlDbType.DateTime;
            paramVaziDo.Direction = ParameterDirection.Input;
            paramVaziDo.Value = VaziDo;
            cmd.Parameters.Add(paramVaziDo);

            SqlParameter paramTrajeOd = new SqlParameter();
            paramTrajeOd.ParameterName = "@TrajeOd";
            paramTrajeOd.SqlDbType = SqlDbType.DateTime;
            paramTrajeOd.Direction = ParameterDirection.Input;
            paramTrajeOd.Value = TrajeOd;
            cmd.Parameters.Add(paramTrajeOd);

            SqlParameter paramTrajeDo = new SqlParameter();
            paramTrajeDo.ParameterName = "@TrajeDo";
            paramTrajeDo.SqlDbType = SqlDbType.DateTime;
            paramTrajeDo.Direction = ParameterDirection.Input;
            paramTrajeDo.Value = TrajeDo;
            cmd.Parameters.Add(paramTrajeDo);

            SqlParameter paramNapomena = new SqlParameter();
            paramNapomena.ParameterName = "@Napomena";
            paramNapomena.SqlDbType = SqlDbType.NVarChar;
            paramNapomena.Size = 250;
            paramNapomena.Direction = ParameterDirection.Input;
            paramNapomena.Value = Napomena;
            cmd.Parameters.Add(paramNapomena);

            SqlParameter paramAktivan = new SqlParameter();
            paramAktivan.ParameterName = "@Aktivan";
            paramAktivan.SqlDbType = SqlDbType.Bit;
            paramAktivan.Direction = ParameterDirection.Input;
            paramAktivan.Value = Aktivan;
            cmd.Parameters.Add(paramAktivan);

            SqlParameter pdf = new SqlParameter();
            pdf.ParameterName = "@PDF";
            pdf.SqlDbType = SqlDbType.NVarChar;
            pdf.Size = 500;
            pdf.Direction = ParameterDirection.Input;
            pdf.Value = PDF;
            cmd.Parameters.Add(pdf);

            SqlParameter paramNarocita = new SqlParameter();
            paramNarocita.ParameterName = "@NarocitaPosiljka";
            paramNarocita.SqlDbType = SqlDbType.Bit;
            paramNarocita.Direction = ParameterDirection.Input;
            paramNarocita.Value = NarocitaPosiljka;
            cmd.Parameters.Add(paramNarocita);

            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;
            }

            catch (SqlException)
            {
                throw new Exception("Neuspešna promena Telegrama brojeva");
            }

            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Promena NHM broja je uspešno završena", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }


        }

        public void DeleteTelegrami(int ID)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DeleteTelegrami";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramID = new SqlParameter();
            paramID.ParameterName = "@ID";
            paramID.SqlDbType = SqlDbType.Int;
            paramID.Direction = ParameterDirection.Input;
            paramID.Value = ID;
            cmd.Parameters.Add(paramID);

            conn.Open();
            SqlTransaction tran= conn.BeginTransaction();
            cmd.Transaction = tran;
            bool error = true;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                tran =conn.BeginTransaction();
                cmd.Transaction = tran;
            }

            catch (SqlException)
            {
                throw new Exception("Brisanje neuspešno");
            }

            finally
            {
                if (!error)
                {
                    tran.Commit();
                    MessageBox.Show("Brisanje nije uspešno", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
               conn.Close();

                if (error)
                {
                    // Nedra.DataSet1TableAdapters.QueriesTableAdapter adapter = new Nedra.DataSet1TableAdapters.QueriesTableAdapter();
                }
            }
        }

    }
}


