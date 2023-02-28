using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Saobracaj.Dokumenta.TrainListItem
{
    internal class TrainListItemDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.NedraConnectionString"].ConnectionString;

        internal void ReadFromExcel(int id_sup)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string file = "";   //variable for the Excel File Location
            DataTable dt = new DataTable();   //container for our excel data
            DataRow row;
            DialogResult result = openFileDialog1.ShowDialog();  // Show the dialog.
            if (result == DialogResult.OK)   // Check if Result == "OK".
            {
                file = openFileDialog1.FileName; //get the filename with the location of the file
                try

                {
                    //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);

                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;


                    int rowCount = excelRange.Rows.Count;  //get row count of excel data

                    int colCount = excelRange.Columns.Count; // get column count of excel data

                    //Get the first Column of excel file which is the Column Name                  

                    for (int j = 1; j <= colCount; j++)
                    {
                        dt.Columns.Add(excelRange.Cells[1, j].Value2.ToString());
                    }

                    dt.Columns[0].DataType = typeof(string);
                    dt.Columns[1].DataType = typeof(decimal);
                    dt.Columns[2].DataType = typeof(decimal);
                    dt.Columns[3].DataType = typeof(string);
                    dt.Columns[4].DataType = typeof(int);
                    dt.Columns[5].DataType = typeof(int);
                    dt.Columns[6].DataType = typeof(int);
                    dt.Columns[7].DataType = typeof(decimal);
                    dt.Columns[8].DataType = typeof(decimal);
                    dt.Columns[9].DataType = typeof(decimal);
                    dt.Columns[10].DataType = typeof(decimal);
                    dt.Columns[11].DataType = typeof(string);
                    dt.Columns[12].DataType = typeof(string);
                    dt.Columns[13].DataType = typeof(decimal);
                    dt.Columns[14].DataType = typeof(string);
                    dt.Columns[15].DataType = typeof(string);
                    dt.Columns[16].DataType = typeof(int);
                    dt.Columns[17].DataType = typeof(int);

                    dt.Columns.Add("TrainListID", typeof(int)).SetOrdinal(0);

                    //Get Row Data of Excel              
                    for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data
                    {
                        row = dt.NewRow();  //assign new row to DataTable
                        row[0] = id_sup;
                        for (int j = 1; j <= colCount; j++) //Loop for available column of excel data
                        {
                            //check if cell is empty
                            if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                            {
                                row[j] = excelRange.Cells[i, j].Value;
                            }
                            else
                            {
                                row[j] = "";
                            }
                        }
                        dt.Rows.Add(row); //add row to DataTable

                        // obrada podataka
                        DataTable tab = dt.Copy();

                        char[] separators = new char[] { '-' };
                        string[] subsNHM = tab.Rows[0].Field<string>("NHM").Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        tab.Columns.Remove("NHM");
                        string[] subsMRN = tab.Rows[0].Field<string>("MRN").Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        tab.Columns.Remove("MRN");
                        string[] subsSeals = tab.Rows[0].Field<string>("Seals").Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        tab.Columns.Remove("Seals");

                        int resoult = Insert(tab);
                       // MessageBox.Show(resoult + " row(s) is added");

                        int id_last = GetLastRowID();

                        DataTable tabNHM = new DataTable();
                        tabNHM.Columns.Add("NHM", typeof(int));
                        tabNHM.Columns.Add("TrainListItemID", typeof(int)).SetOrdinal(0);
                        foreach (string item in subsNHM)
                        {
                            DataRow rowNHM = tabNHM.NewRow();
                            rowNHM[0] = id_last;
                            rowNHM[1] = (int)Convert.ToInt64(item);
                            tabNHM.Rows.Add(rowNHM);
                        }
                        resoult = InsertNHM(tabNHM);
                        //MessageBox.Show(resoult + " row(s) is added");

                        DataTable tabMRN = new DataTable();
                        tabMRN.Columns.Add("MRN", typeof(string));
                        tabMRN.Columns.Add("TrainListItemID", typeof(int)).SetOrdinal(0);
                        foreach (string item in subsMRN)
                        {
                            DataRow rowMRN = tabMRN.NewRow();
                            rowMRN[0] = id_last;
                            rowMRN[1] = (string)item;
                            tabMRN.Rows.Add(rowMRN);
                        }
                        resoult = InsertMRN(tabMRN);
                       // MessageBox.Show(resoult + " row(s) is added");

                        DataTable tabSeals = new DataTable();
                        tabSeals.Columns.Add("Seals", typeof(string));
                        tabSeals.Columns.Add("TrainListItemID", typeof(int)).SetOrdinal(0);
                        foreach (string item in subsSeals)
                        {
                            DataRow rowSeals = tabSeals.NewRow();
                            rowSeals[0] = id_last;
                            rowSeals[1] = (string)item;
                            tabSeals.Rows.Add(rowSeals);
                        }
                        resoult = InsertSeals(tabSeals);
                        //MessageBox.Show(resoult + " row(s) is added");

                        // brisanje vrste iz tabele
                        dt.Rows.RemoveAt(0);
                    }

                    //Close and Clean excel process
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(excelRange);
                    Marshal.ReleaseComObject(excelWorksheet);
                    excelWorkbook.Close();
                    Marshal.ReleaseComObject(excelWorkbook);

                    //quit 
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        internal List<TrainListItemModel> GetAllBySuperiorId(int id)
        {
            List<TrainListItemModel> returnThese = new List<TrainListItemModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("TrainListItem_GetAllBySuperiorId", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnThese.Add(new TrainListItemModel
                            {
                                Id = (int)reader[0],
                                TrainListId = (int)reader[1],
                                WagonNumber = (string)reader[2],
                                WagonTare = (decimal)reader[3],
                                WagonLength = (decimal)reader[4],
                                UnitNumber = (string)reader[5],
                                Type = (int)reader[6],
                                UnitTare = (int)reader[7],
                                ADRType = (int)reader[8],
                                KG = (decimal)reader[9],
                                KG2 = (decimal)reader[10],
                                Total = (decimal)reader[11],
                                PCS = (decimal)reader[12],
                                InvoiceNo = (string)reader[13],
                                InvoiceValue = (decimal)reader[14],
                                ArrivalTerminal = (int)reader[15],
                                Customer = (int)reader[16]
                            });
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new Exception("Can not get TrainListItems");
                }
            }
            return returnThese;
        }

        internal List<int> GetAllNHMBySuperiorId(int id)
        {
            List<int> returnThese = new List<int>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("NHM_GetAllBySuperiorId", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnThese.Add((int)reader[0]);

                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new Exception("Can not get NHM");
                }
            }
            return returnThese;
        }

        internal List<string> GetAllMRNBySuperiorId(int id)
        {
            List<string> returnThese = new List<string>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("MRN_GetAllBySuperiorId", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnThese.Add((string)reader[0]);

                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new Exception("Can not get MRN");
                }
            }
            return returnThese;
        }

        internal List<string> GetAllSealsBySuperiorId(int id)
        {
            List<string> returnThese = new List<string>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("Seals_GetAllBySuperiorId", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnThese.Add((string)reader[0]);

                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new Exception("Can not get Seals");
                }
            }
            return returnThese;
        }

        private int Insert(DataTable data)
        {
            int success = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("TrainListItem_Insert", con);
                command.CommandType = CommandType.StoredProcedure;
                //List<JObject> proba = Table2Object(data);
                SqlParameter Parameter = new SqlParameter();
                Parameter.ParameterName = "@items";
                Parameter.SqlDbType = SqlDbType.Structured;
                Parameter.Direction = ParameterDirection.Input;
                Parameter.Value = data;
                command.Parameters.Add(Parameter);

                try
                {
                    success = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new Exception("TrainListItem NOT inserted!");
                }
            }
            return success;
        }

        private int GetLastRowID()
        {
            int returnThese = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("TrainListItem_GetLastRow", con);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnThese = (int)reader[0];
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new Exception("Can not get TrainListItems");
                }
            }
            return returnThese;
        }

        private int InsertNHM(DataTable data)
        {
            int success = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("NHM_Insert", con);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter Parameter = new SqlParameter();
                Parameter.ParameterName = "@items";
                Parameter.SqlDbType = SqlDbType.Structured;
                Parameter.Direction = ParameterDirection.Input;
                Parameter.Value = data;
                command.Parameters.Add(Parameter);

                try
                {
                    success = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new Exception("NHM NOT inserted!");
                }
            }
            return success;
        }

        private int InsertMRN(DataTable data)
        {
            int success = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("MRN_Insert", con);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter Parameter = new SqlParameter();
                Parameter.ParameterName = "@items";
                Parameter.SqlDbType = SqlDbType.Structured;
                Parameter.Direction = ParameterDirection.Input;
                Parameter.Value = data;
                command.Parameters.Add(Parameter);

                try
                {
                    success = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new Exception("MRN NOT inserted!");
                }
            }
            return success;
        }

        private int InsertSeals(DataTable data)
        {
            int success = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("Seals_Insert", con);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter Parameter = new SqlParameter();
                Parameter.ParameterName = "@items";
                Parameter.SqlDbType = SqlDbType.Structured;
                Parameter.Direction = ParameterDirection.Input;
                Parameter.Value = data;
                command.Parameters.Add(Parameter);

                try
                {
                    success = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new Exception("Seals NOT inserted!");
                }
            }
            return success;
        }
    }
}
