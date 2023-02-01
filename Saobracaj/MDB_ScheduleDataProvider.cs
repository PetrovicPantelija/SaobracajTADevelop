#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.Schedule;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using Syncfusion.Windows.Forms.Schedule;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MDB_ScheduleSample_CS
{
    #region Schedule Item

    public class MDB_ScheduleItem : ScheduleAppointment
    {
        public static string Column_AllDay = "AllDay";
        public static string Column_Content = "Content";
        public static string Column_Dirty = "Dirty";
        public static string Column_EndTime = "EndTime";
        public static string Column_IgnoreChanges = "IgnoreChanges";
        public static string Column_LabelValue = "LabelValue";
        public static string Column_LocationValue = "LocationValue";
        public static string Column_MarkerValue = "MarkerValue";
        public static string Column_Owner = "Owner";
        public static string Column_Reminder = "Reminder";
        public static string Column_ReminderValue = "ReminderValue";
        public static string Column_StartTime = "StartTime";
        public static string Column_Subject = "Subject";
        public static string Column_UniqueID = "ID";
        public static string Column_RecurrenceRule = "RecurrenceRule";



        public MDB_ScheduleItem(DataRow dr)
        {
            this.dr = dr;
        }

        

        private DataRow dr;

        public DataRow Dr
        {
            get { return dr; }
        }

        public /*override*/ new bool AllDay
        {
            get
            {
                return (bool) dr[Column_AllDay];
            }
            set
            {
                dr[Column_AllDay] = value;
            }
        }
        public /*override*/ new string Content
        {
            get
            {
                return (string) dr[Column_Content];
            }
            set
            {
                dr[Column_Content] = value;
            }
        }

        internal bool dirtyFlagExplicitlySet = false;
        internal static MDB_ScheduleItem changedItem = null;
        public /*override*/ new bool Dirty
        {
            get
            {
                return dr.RowState != DataRowState.Unchanged;// dr[Column_Dirty];
            }
            set
            {
                dirtyFlagExplicitlySet = true;
                changedItem = this;
                int iii = this.LabelValue;
              //  dr[Column_Dirty] = value;

               
            }
        }


        public /*override*/ new DateTime EndTime
        {
            get
            {
                return (DateTime) dr[Column_EndTime];
            }
            set
            {
                dr[Column_EndTime] = value;
            }
        }
        public /*override*/new bool IgnoreChanges
        {
            get
            {
                return (bool)dr[Column_IgnoreChanges];
            }
            set
            {
                dr[Column_IgnoreChanges] = value;
            }
        }
        public /*override*/new int LabelValue
        {
            get
            {
                return (int)dr[Column_LabelValue];
            }
            set
            {
                dr[Column_LabelValue] = value;
            }
        }
        public /*override*/ new string LocationValue
        {
            get
            {
                return (string)dr[Column_LocationValue];
            }
            set
            {
                dr[Column_LocationValue] = value;
            }
        }

        private string FindLookupValue(LookUpObjectList list, int itemToFind)
        {
            string val = "";
            foreach (ListObject drv in list)
            {
                if (itemToFind.Equals(drv.ValueMember))
                {
                    val = drv.DisplayMember;
                    break;
                }
            }
            return val;
        }

        public /*override*/new int MarkerValue
        {
            get
            {
                return (int)dr[Column_MarkerValue];
            }
            set
            {
                dr[Column_MarkerValue] = value;
            }
        }
        public /*override*/ new int Owner
        {
            get
            {
                return (int)dr[Column_Owner];
            }
            set
            {
                dr[Column_Owner] = value;
            }
        }
        public /*override*/ new bool Reminder
        {
            get
            {
                return (bool)dr[Column_Reminder];
            }
            set
            {
                dr[Column_Reminder] = value;
            }
        }
        public /*override*/ new int ReminderValue
        {
            get
            {
                return (int)dr[Column_ReminderValue];
            }
            set
            {
                dr[Column_ReminderValue] = value;
            }
        }
        public /*override*/ new DateTime StartTime
        {
            get
            {
                return (DateTime)dr[Column_StartTime];
            }
            set
            {
                dr[Column_StartTime] = value;
            }
        }
        public /*override*/ new string Subject
        {
            get
            {
                if (dr[Column_Subject] == DBNull.Value)
                    return "";
                return (string)dr[Column_Subject];
            }
            set
            {
                dr[Column_Subject] = value;
            }
        }
        public /*override*/ new int UniqueID
        {
            get
            {
                return (int)dr[Column_UniqueID];
            }
            set
            {
                dr[Column_UniqueID] = value;
            }
        }

        #region IRecurringScheduleAppointment Members

        private RecurrenceList dateList;

         public RecurrenceList DateList
        {
            get
            {
                if (dateList == null &&
                    RecurrenceRule != null &&
                    RecurrenceRule.StartsWith(RecurrenceSupport.SpanMarker))
                {
                    InitSpanDateList();
                }
                return dateList;
            }
            set { dateList = value; }
        }


        //added to provide dynamic initialization for DateList in span rules.
        private void InitSpanDateList()
        {
            string[] parts = RecurrenceRule.Split(new char[] { RecurrenceSupport.RuleDelimiter });
            if (parts.GetLength(0) == 3)
            {
                dateList = new RecurrenceList();
                dateList.BaseDate = DateTime.Parse(parts[1], System.Globalization.CultureInfo.InstalledUICulture.DateTimeFormat);
                dateList.TerminalDate = DateTime.Parse(parts[2], System.Globalization.CultureInfo.InstalledUICulture.DateTimeFormat);
            }
        }

        public string RecurrenceRule
        {
            get
            {
                 
                    if (dr.Table == null)
                        return "";

                    if (dr.RowState == DataRowState.Deleted)
                        return "";

                    if (dr[Column_RecurrenceRule] == DBNull.Value)
                        return "";
                 
                return (string)dr[Column_RecurrenceRule];
            }
            set
            {
                dr[Column_RecurrenceRule] = value;
            }
        }

        private int recurrenceRuleID = 0;//int.MinValue;
        public int RecurrenceRuleID
        {
            get
            {
                //if (recurrenceRuleID == int.MinValue && RecurrenceRule.Length > 0)
                //    recurrenceRuleID = MDB_ScheduleDataProvider.ScheduleDataProvider.GetUniqueID();
                return recurrenceRuleID;
            }
            set
            {
                recurrenceRuleID = value;
            }
        }

        #endregion

        #region IScheduleAppointment Members - these members not used in the Windows Forms ScheduleControl


        public new bool AllowClickable
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public new bool AllowDrag
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public new bool AllowResize
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public new Color BackColor
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public new string CustomToolTip
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public new bool IsConflict(DateTime dtStart, DateTime dtEnd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public new bool IsConflict(IScheduleAppointment item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public new object Tag
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public new Color TimeSpanColor
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public new ScheduleAppointmentToolTip ToolTip
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public new int Version
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region IComparable Members

        public new int CompareTo(object obj)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region ICloneable Members

        
        private string lastRecurrenceRule = "";
        public new object Clone()
        {

            DataRow dr1 = this.Dr.Table.NewRow();
            dr1.ItemArray = this.Dr.ItemArray.Clone() as object[];
            if (dr1[MDB_ScheduleItem.Column_UniqueID] == null || dr1[MDB_ScheduleItem.Column_UniqueID] == DBNull.Value)
                dr1[MDB_ScheduleItem.Column_UniqueID] = MDB_ScheduleDataProvider.GetNextID();
            MDB_ScheduleItem item1 = new MDB_ScheduleItem(dr1);
            if (dr1[MDB_ScheduleItem.Column_RecurrenceRule].Equals(lastRecurrenceRule))
            {
                item1.recurrenceRuleID = this.recurrenceRuleID;
                item1.dirtyFlagExplicitlySet = this.dirtyFlagExplicitlySet;
                item1.UniqueID = MDB_ScheduleDataProvider.GetNextID();
            }
            lastRecurrenceRule = dr1[MDB_ScheduleItem.Column_RecurrenceRule].ToString();
            return item1;
        }

        #endregion
    }

    #endregion

    #region Schedule Item List

    public class MDB_ScheduleItemList : ArrayListAppointmentList
    {
        public MDB_ScheduleItemList(DataView dv)
        {
            SetDataView(dv);
        }

        protected void SetDataView(DataView dv)
        {
            foreach (DataRowView drv in dv)
            {
                this.Add(new MDB_ScheduleItem(drv.Row));
            }
        }


        public override void Remove(IScheduleAppointment item1)
        {
           base.Remove(item1);

                MDB_ScheduleItem item = item1 as MDB_ScheduleItem;
                if (item != null && item.RecurrenceRule.Length > 0)
                {
                    if (MDB_ScheduleDataProvider.itemsToDelete == null)
                    {
                        MDB_ScheduleDataProvider.itemsToDelete = new List<DataRow>();
                    }
                    foreach (DataRow dr in MDB_ScheduleDataProvider.scheduleDataSet.Tables[MDB_ScheduleDataProvider.Table_Appointments].Rows)
                    {
                        if(dr.RowState != DataRowState.Deleted
                            && dr.RowState != DataRowState.Detached
                            && item.RecurrenceRule.Equals(dr[MDB_ScheduleItem.Column_RecurrenceRule]))
                            MDB_ScheduleDataProvider.itemsToDelete.Add(dr);
                    }
                 }
          }
    }

    #endregion

    #region Schedule Provider

    public class MDB_ScheduleDataProvider : ArrayListDataProvider//ScheduleDataProvider, IRecurringScheduleDataProvider
    {
        public static string DataSet_Name = "Schedule";
        public static string Table_Appointments = "Appointments";
        public static string Table_Markers = "Markers";
        public static string Table_Labels = "Labels";
        public static string Table_Reminders = "Reminders";
        public static string Table_Delavci = "Delavci";


        internal static DataSet scheduleDataSet = null;
        internal static List<DataRow> itemsToDelete;

        public static MDB_ScheduleDataProvider ScheduleDataProvider;
         
        public DataSet ScheduleDataSet
        {
            get { return scheduleDataSet; }
        }
        SqlDataAdapter dataAdapter;
        SqlConnection connection;
        public MDB_ScheduleDataProvider(string MDBpathName)
        {
            
            itemsToDelete = new List<DataRow>();
            
            MDB_ScheduleDataProvider.ScheduleDataProvider = this;

            MDB_ScheduleDataProvider.scheduleDataSet = new DataSet(DataSet_Name);

            var s_connection = ConfigurationManager.ConnectionStrings["Saobracaj.Properties.Settings.TESTIRANJEConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            var c = new SqlConnection(s_connection);
            /*
            string connString = @"Provider=Microsoft.JET.OLEDB.4.0;data source=" + MDBpathName;
           // string connString = @"Provider=Microsoft.JET.OLEDB.4.0;data source=" + GetPath(@"Data\nwind.mdb");
			
            connection = new OleDbConnection(connString);
            */
            string sqlString = "SELECT * FROM " + Table_Markers;
            dataAdapter = new SqlDataAdapter(sqlString, c);
            dataAdapter.Fill(scheduleDataSet, Table_Markers);

            sqlString = "SELECT * FROM " + Table_Labels;
            dataAdapter = new SqlDataAdapter(sqlString, c);
            dataAdapter.Fill(scheduleDataSet, Table_Labels);

            sqlString = "SELECT * FROM " + Table_Reminders;
            dataAdapter = new SqlDataAdapter(sqlString, c);
            dataAdapter.Fill(scheduleDataSet, Table_Reminders);

           

            sqlString = "SELECT * FROM " + Table_Appointments;
            dataAdapter = new SqlDataAdapter(sqlString, c);
            dataAdapter.Fill(scheduleDataSet, Table_Appointments);

            sqlString = "SELECT DeSifra, (Rtrim(DePriimek) + ' ' + Rtrim(DeIme)) as Ime FROM " + Table_Delavci;
            dataAdapter = new SqlDataAdapter(sqlString, c);
            dataAdapter.Fill(scheduleDataSet, Table_Delavci);

            nextID = int.MinValue;
          //  connection.Close();
        }

    

        static int nextID = int.MinValue;
        internal static int GetNextID()
        {
            if (nextID == int.MinValue)
            {
                int id = int.MinValue;
                foreach (DataRow dr in scheduleDataSet.Tables[Table_Appointments].Rows)
                {
                    if (dr[MDB_ScheduleItem.Column_UniqueID] != null &&
                        dr[MDB_ScheduleItem.Column_UniqueID] != DBNull.Value &&
                        (int)dr[MDB_ScheduleItem.Column_UniqueID] > id)
                    {
                        id = (int)dr[MDB_ScheduleItem.Column_UniqueID] + 1;
                    }
                }
                nextID = id;
            }
            return nextID++;
        }

        public void UpdateChanges(IScheduleAppointment item)
        {
            DataTable dt = ScheduleDataSet.Tables[3];
            //Panta

            foreach (DataRow dr in MDB_ScheduleDataProvider.scheduleDataSet.Tables[MDB_ScheduleDataProvider.Table_Appointments].Rows)
            {
                if (Convert.ToInt32(dr.ItemArray[0].ToString()) == item.UniqueID)
                {
                    dr.SetField("AllDay", item.AllDay);
                    dr.SetField("Content", item.Content);
                    dr.SetField("EndTime", item.EndTime);
                    dr.SetField("LabelValue", item.LabelValue);
                    dr.SetField("LocationValue", item.LocationValue);
                    dr.SetField("MarkerValue", item.MarkerValue);
                    dr.SetField("Owner", item.Owner);
                    dr.SetField("Reminder", item.Reminder);
                    dr.SetField("ReminderValue", item.ReminderValue);
                    dr.SetField("StartTime", item.StartTime);
                    dr.SetField("Subject", item.Subject.ToString());


                }

                /*
                    rv.ItemArray[1] = item.AllDay;
                    rv.ItemArray[2] = item.Content;
                    rv.ItemArray[3] = item.EndTime;
                    rv.ItemArray[4] = item.LabelValue;
                    rv.ItemArray[5] = item.LocationValue;
                    rv.ItemArray[6] = item.MarkerValue;
                    rv.ItemArray[7] = item.Owner;
                    rv.ItemArray[8] = item.Reminder;
                    rv.ItemArray[9] = item.ReminderValue;
                    rv.ItemArray[10] = item.StartTime;
                    rv.ItemArray[11] = item.Subject.ToString();
                    rv.AcceptChanges();
                */

            }


            //scheduleDataSet.Tables[Table_Appointments].Rows.Add(((MDB_ScheduleItem)item).Dr);
            //    base.AddItem(item);
        }
        public override void AddItem(IScheduleAppointment item)
        {
            if (((MDB_ScheduleItem)item).Dr[MDB_ScheduleItem.Column_UniqueID] == DBNull.Value)
                ((MDB_ScheduleItem)item).Dr[MDB_ScheduleItem.Column_UniqueID] = GetNextID();
            ((MDB_ScheduleItem)item).Dr[1] = item.AllDay;
            ((MDB_ScheduleItem)item).Dr[2] = item.Content;
            ((MDB_ScheduleItem)item).Dr[3] = item.EndTime;
            ((MDB_ScheduleItem)item).Dr[4] = item.LabelValue;
            ((MDB_ScheduleItem)item).Dr[5] = item.LocationValue;
            ((MDB_ScheduleItem)item).Dr[6] = item.MarkerValue;
            ((MDB_ScheduleItem)item).Dr[7] = item.Owner;
            ((MDB_ScheduleItem)item).Dr[8] = item.Reminder;
            ((MDB_ScheduleItem)item).Dr[9] = item.ReminderValue;
            ((MDB_ScheduleItem)item).Dr[10] = item.StartTime;
            ((MDB_ScheduleItem)item).Dr[11] = item.Subject;
          //  ((MDB_ScheduleItem)item).Dr[12] = item.RecurrenceRule;
         
           


            scheduleDataSet.Tables[Table_Appointments].Rows.Add(((MDB_ScheduleItem) item).Dr);
        //    base.AddItem(item);
        }

        private void Dodaj(DataRow item)
        { 
        
        
        
        }

        public bool UpdateAdmins(DataSet ds)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["Saobracaj.Properties.Settings.TESTIRANJEConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            try
            {
               // for (int i = 0; i < ds.Tables["Appointments"].Rows.Count; i++)
                    foreach (DataRow item in ds.Tables["Appointments"].Rows)
                {
                    switch (item.RowState)
                    {
                        case DataRowState.Added:
                            {
                               
                                //Insert
                                //PInsert
                                using (SqlConnection conn = new SqlConnection(s_connection))
                                {
                                    //declare adapter
                                    SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Appointments", conn);
                                    //set commands
                                    dataAdapter.UpdateCommand = new SqlCommand("Update Admins Set" +
                                        " Password = @Password, Salt = @Salt" +
                                        " Where Username = @Username", conn);

                                    dataAdapter.DeleteCommand = new SqlCommand("delete from Admins where Username = @Username", conn);

                                    dataAdapter.InsertCommand = new SqlCommand("INSERT INTO [dbo].[Appointments]  ([AllDay] ,[Content] ,[EndTime],[LabelValue] " +
                          " ,[LocationValue],[MarkerValue],[Owner],[Reminder] " +
                         "  ,[ReminderValue],[StartTime],[Subject],[RecurrenceRule]) " +
                    " VALUES " +
                         "  (@AllDay, @Content, @EndTime, @LabelValue, @LocationValue " +
                         "  , @MarkerValue, @Owner, @Reminder, @ReminderValue " +
                         "  , @StartTime, @Subject, @RecurrenceRule)", conn);


                                    //execute delete and update
                                    // int deleted = dataAdapter.Update(ds.Tables[0].Select(null, null, DataViewRowState.Deleted));
                                    //  int updated = dataAdapter.Update(ds.Tables[0].Select(null, null, DataViewRowState.ModifiedCurrent));



                                    SqlParameter parameter0INS = new SqlParameter();
                                    parameter0INS.ParameterName = "@AllDay";
                                    parameter0INS.SqlDbType = SqlDbType.Bit;
                                    parameter0INS.Direction = ParameterDirection.Input;
                                    string pom = "";
                                    pom = item["AllDay"].ToString();
                                   // ds.Tables[3].Rows[]["AllDay"].ToString();
                                    parameter0INS.Value = 1;
                                    dataAdapter.InsertCommand.Parameters.Add(parameter0INS);

                                    SqlParameter parameter1INS = new SqlParameter();
                                    parameter1INS.ParameterName = "@Content";
                                    parameter1INS.SqlDbType = SqlDbType.NVarChar;
                                    parameter1INS.Size = 100;
                                    parameter1INS.Direction = ParameterDirection.Input;
                                    parameter1INS.Value = item["Content"].ToString();
                                    dataAdapter.InsertCommand.Parameters.Add(parameter1INS);




                                    SqlParameter parameter2INS = new SqlParameter();
                                    parameter2INS.ParameterName = "@EndTime";
                                    parameter2INS.SqlDbType = SqlDbType.DateTime;
                                    parameter2INS.Direction = ParameterDirection.Input;
                                    parameter2INS.Value = Convert.ToDateTime(item["EndTime"].ToString());
                                    dataAdapter.InsertCommand.Parameters.Add(parameter2INS);





                                    SqlParameter parameter3INS = new SqlParameter();
                                    parameter3INS.ParameterName = "@LabelValue";
                                    parameter3INS.SqlDbType = SqlDbType.Int;
                                    parameter3INS.Direction = ParameterDirection.Input;
                                    parameter3INS.Value = Convert.ToInt32(item["LabelValue"].ToString());
                                    dataAdapter.InsertCommand.Parameters.Add(parameter3INS);

                                    SqlParameter parameter4INS = new SqlParameter();
                                    parameter4INS.ParameterName = "@LocationValue";
                                    parameter4INS.SqlDbType = SqlDbType.NVarChar;
                                    parameter4INS.Size = 1000;
                                    parameter4INS.Direction = ParameterDirection.Input;
                                    parameter4INS.Value = item["LocationValue"].ToString();
                                    dataAdapter.InsertCommand.Parameters.Add(parameter4INS);

                                    SqlParameter parameter5INS = new SqlParameter();
                                    parameter5INS.ParameterName = "@MarkerValue";
                                    parameter5INS.SqlDbType = SqlDbType.Int;
                                    parameter5INS.Direction = ParameterDirection.Input;
                                    parameter5INS.Value = Convert.ToInt32(item["MarkerValue"].ToString());
                                    dataAdapter.InsertCommand.Parameters.Add(parameter5INS);



                                    SqlParameter parameter6INS = new SqlParameter();
                                    parameter6INS.ParameterName = "@Owner";
                                    parameter6INS.SqlDbType = SqlDbType.Int;
                                    parameter6INS.Direction = ParameterDirection.Input;
                                    parameter6INS.Value = Convert.ToInt32(item["Owner"].ToString());
                                    dataAdapter.InsertCommand.Parameters.Add(parameter6INS);

                                    SqlParameter parameter7INS = new SqlParameter();
                                    parameter7INS.ParameterName = "@Reminder";
                                    parameter7INS.SqlDbType = SqlDbType.Bit;
                                    parameter7INS.Direction = ParameterDirection.Input;
                                    parameter7INS.Value = 0;
                                    dataAdapter.InsertCommand.Parameters.Add(parameter7INS);

                                    SqlParameter parameter8INS = new SqlParameter();
                                    parameter8INS.ParameterName = "@ReminderValue";
                                    parameter8INS.SqlDbType = SqlDbType.Int;
                                    parameter8INS.Direction = ParameterDirection.Input;
                                    parameter8INS.Value = Convert.ToInt32(item["ReminderValue"].ToString()); ;
                                    dataAdapter.InsertCommand.Parameters.Add(parameter8INS);


                                    SqlParameter parameter9INS = new SqlParameter();
                                    parameter9INS.ParameterName = "@StartTime";
                                    parameter9INS.SqlDbType = SqlDbType.DateTime;
                                    parameter9INS.Direction = ParameterDirection.Input;
                                    parameter9INS.Value = Convert.ToDateTime(item["StartTime"].ToString());
                                    dataAdapter.InsertCommand.Parameters.Add(parameter9INS);

                                    SqlParameter parameter10INS = new SqlParameter();
                                    parameter10INS.ParameterName = "@Subject";
                                    parameter10INS.SqlDbType = SqlDbType.NVarChar;
                                    parameter10INS.Size = 100;
                                    parameter10INS.Direction = ParameterDirection.Input;
                                    parameter10INS.Value = item["Subject"].ToString();
                                    dataAdapter.InsertCommand.Parameters.Add(parameter10INS);

                                    SqlParameter parameter12INS = new SqlParameter();
                                    parameter12INS.ParameterName = "@RecurrenceRule";
                                    parameter12INS.SqlDbType = SqlDbType.NVarChar;
                                    parameter12INS.Size = 100;
                                    parameter12INS.Direction = ParameterDirection.Input;
                                    parameter12INS.Value = item["RecurrenceRule"].ToString();
                                    dataAdapter.InsertCommand.Parameters.Add(parameter12INS);


                                    int added = dataAdapter.Update(ds.Tables[3].Select(null, null, DataViewRowState.Added));
                                    //PENDInsert
                                    break;
                                }
                            }
                        case DataRowState.Modified:
                            {
                                //Update
                                using (SqlConnection conn = new SqlConnection(s_connection))
                                {
                                    //declare adapter
                                    SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Appointments", conn);
                                    //set commands
                                    dataAdapter.UpdateCommand = new SqlCommand("Update Admins Set" +
                                        " Password = @Password, Salt = @Salt" +
                                        " Where Username = @Username", conn);

                                    dataAdapter.DeleteCommand = new SqlCommand("delete from Admins where Username = @Username", conn);

                                    dataAdapter.InsertCommand = new SqlCommand("INSERT INTO [dbo].[Appointments]  ([AllDay] ,[Content] ,[EndTime],[LabelValue] " +
                          " ,[LocationValue],[MarkerValue],[Owner],[Reminder] " +
                         "  ,[ReminderValue],[StartTime],[Subject],[RecurrenceRule]) " +
                    " VALUES " +
                         "  (@AllDay, @Content, @EndTime, @LabelValue, @LocationValue " +
                         "  , @MarkerValue, @Owner, @Reminder, @ReminderValue " +
                         "  , @StartTime, @Subject, @RecurrenceRule)", conn);


                                    dataAdapter.UpdateCommand = new SqlCommand("Update [dbo].[Appointments] Set" +
                                       "[AllDay] = @AllDay ,[Content] = @Content ,[EndTime] = @EndTime,[LabelValue] = @LabelValue " +
                                        " ,[LocationValue] = @LocationValue,[MarkerValue] = @MarkerValue,[Owner] = @Owner,[Reminder]  = @Reminder" +
                                        "  ,[ReminderValue] = @ReminderValue,[StartTime] = @StartTime,[Subject] = @Subject,[RecurrenceRule] = @RecurrenceRule " +
                                        " Where ID = @ID", conn);


                                    //execute delete and update
                                    // int deleted = dataAdapter.Update(ds.Tables[0].Select(null, null, DataViewRowState.Deleted));
                                    //  int updated = dataAdapter.Update(ds.Tables[0].Select(null, null, DataViewRowState.ModifiedCurrent));
                                    SqlParameter parameter00INS = new SqlParameter();
                                    parameter00INS.ParameterName = "@ID";
                                    parameter00INS.SqlDbType = SqlDbType.Int;
                                    parameter00INS.Direction = ParameterDirection.Input;
                                    parameter00INS.Value = Convert.ToInt32(item["ID"].ToString());
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter00INS);


                                    SqlParameter parameter0INS = new SqlParameter();
                                    parameter0INS.ParameterName = "@AllDay";
                                    parameter0INS.SqlDbType = SqlDbType.Bit;
                                    parameter0INS.Direction = ParameterDirection.Input;
                                    string pom = "";
                                    pom = item["AllDay"].ToString();
                                    // ds.Tables[3].Rows[]["AllDay"].ToString();
                                    parameter0INS.Value = 1;
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter0INS);

                                    SqlParameter parameter1INS = new SqlParameter();
                                    parameter1INS.ParameterName = "@Content";
                                    parameter1INS.SqlDbType = SqlDbType.NVarChar;
                                    parameter1INS.Size = 100;
                                    parameter1INS.Direction = ParameterDirection.Input;
                                    parameter1INS.Value = item["Content"].ToString();
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter1INS);




                                    SqlParameter parameter2INS = new SqlParameter();
                                    parameter2INS.ParameterName = "@EndTime";
                                    parameter2INS.SqlDbType = SqlDbType.DateTime;
                                    parameter2INS.Direction = ParameterDirection.Input;
                                    parameter2INS.Value = Convert.ToDateTime(item["EndTime"].ToString());
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter2INS);





                                    SqlParameter parameter3INS = new SqlParameter();
                                    parameter3INS.ParameterName = "@LabelValue";
                                    parameter3INS.SqlDbType = SqlDbType.Int;
                                    parameter3INS.Direction = ParameterDirection.Input;
                                    parameter3INS.Value = Convert.ToInt32(item["LabelValue"].ToString());
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter3INS);

                                    SqlParameter parameter4INS = new SqlParameter();
                                    parameter4INS.ParameterName = "@LocationValue";
                                    parameter4INS.SqlDbType = SqlDbType.NVarChar;
                                    parameter4INS.Size = 1000;
                                    parameter4INS.Direction = ParameterDirection.Input;
                                    parameter4INS.Value = item["LocationValue"].ToString();
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter4INS);

                                    SqlParameter parameter5INS = new SqlParameter();
                                    parameter5INS.ParameterName = "@MarkerValue";
                                    parameter5INS.SqlDbType = SqlDbType.Int;
                                    parameter5INS.Direction = ParameterDirection.Input;
                                    parameter5INS.Value = Convert.ToInt32(item["MarkerValue"].ToString());
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter5INS);



                                    SqlParameter parameter6INS = new SqlParameter();
                                    parameter6INS.ParameterName = "@Owner";
                                    parameter6INS.SqlDbType = SqlDbType.Int;
                                    parameter6INS.Direction = ParameterDirection.Input;
                                    parameter6INS.Value = Convert.ToInt32(item["Owner"].ToString());
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter6INS);

                                    SqlParameter parameter7INS = new SqlParameter();
                                    parameter7INS.ParameterName = "@Reminder";
                                    parameter7INS.SqlDbType = SqlDbType.Bit;
                                    parameter7INS.Direction = ParameterDirection.Input;
                                    parameter7INS.Value = 0;
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter7INS);

                                    SqlParameter parameter8INS = new SqlParameter();
                                    parameter8INS.ParameterName = "@ReminderValue";
                                    parameter8INS.SqlDbType = SqlDbType.Int;
                                    parameter8INS.Direction = ParameterDirection.Input;
                                    parameter8INS.Value = Convert.ToInt32(item["ReminderValue"].ToString()); ;
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter8INS);


                                    SqlParameter parameter9INS = new SqlParameter();
                                    parameter9INS.ParameterName = "@StartTime";
                                    parameter9INS.SqlDbType = SqlDbType.DateTime;
                                    parameter9INS.Direction = ParameterDirection.Input;
                                    parameter9INS.Value = Convert.ToDateTime(item["StartTime"].ToString());
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter9INS);

                                    SqlParameter parameter10INS = new SqlParameter();
                                    parameter10INS.ParameterName = "@Subject";
                                    parameter10INS.SqlDbType = SqlDbType.NVarChar;
                                    parameter10INS.Size = 100;
                                    parameter10INS.Direction = ParameterDirection.Input;
                                    parameter10INS.Value = item["Subject"].ToString();
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter10INS);

                                    SqlParameter parameter12INS = new SqlParameter();
                                    parameter12INS.ParameterName = "@RecurrenceRule";
                                    parameter12INS.SqlDbType = SqlDbType.NVarChar;
                                    parameter12INS.Size = 100;
                                    parameter12INS.Direction = ParameterDirection.Input;
                                    parameter12INS.Value = item["RecurrenceRule"].ToString();
                                    dataAdapter.UpdateCommand.Parameters.Add(parameter12INS);


                                    int added = dataAdapter.Update(ds.Tables[3].Select(null, null, DataViewRowState.ModifiedCurrent));
                                    break;
                                }
                            }
                        case DataRowState.Deleted:
                            {//Update
                            
                                break;
                            
                    }
                    default:
                            break;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        /// <summary>
        /// Panta
        /// </summary>

        public override void CommitChanges()
        {
            UpdateAdmins(scheduleDataSet);
        }

        private static LookUpObjectList labels;

        internal static LookUpObjectList Labels
        {
            get 
            {
                if (labels == null)
                {
                    labels = new LookUpObjectList(scheduleDataSet.Tables[Table_Labels].DefaultView);
                }
                return MDB_ScheduleDataProvider.labels; 
            }
            set { MDB_ScheduleDataProvider.labels = value; }
        }
        public override ILookUpObjectList GetLabels()
        {
            return Labels;
        }

        private static LookUpObjectList markers;

        internal static LookUpObjectList Markers
        {
            get
            {
                if (markers == null)
                {
                    markers = new LookUpObjectList(scheduleDataSet.Tables[Table_Markers].DefaultView);
                }
                return MDB_ScheduleDataProvider.markers;
            }
            set { MDB_ScheduleDataProvider.markers = value; }
        }
        public override ILookUpObjectList GetMarkers()
        {
            return Markers;
        }

        //not used in this sample...
        public override IScheduleResourceList GetOwners()
        {
            return base.GetOwners();
        }

        private static LookUpObjectList reminders;

        internal static LookUpObjectList Reminders
        {
            get
            {
                if (reminders == null)
                {
                    reminders = new LookUpObjectList(scheduleDataSet.Tables[Table_Reminders].DefaultView);
                }

                return reminders;
            }
            set { reminders = value; }
        }
        public override ILookUpObjectList GetReminders()
        {
            return Reminders;
        }

        //void display(DataView dv)
        //{
        //    foreach (DataRowView drv in dv)
        //    {
        //        if (drv[MDB_ScheduleItem.Column_RecurrenceRule].ToString().Length > 0)
        //        {
        //            Console.WriteLine("{0}  [{1}] {2}", drv[MDB_ScheduleItem.Column_UniqueID], drv[MDB_ScheduleItem.Column_RecurrenceRule], drv[MDB_ScheduleItem.Column_LabelValue]);
        //        }
        //    }
        //    Console.WriteLine("========");
        //}

        //void display(ArrayListAppointmentList dv)
        //{
        //    foreach (MDB_ScheduleItem drv in dv)
        //    {
        //        if (drv.RecurrenceRule.Length > 0)
        //        {
        //            Console.WriteLine("{0}  [{1}] {2}  {3}  {4}", drv.UniqueID, drv.RecurrenceRule, drv.RecurrenceRuleID, drv.LabelValue, drv.dirtyFlagExplicitlySet);
        //        }
        //    }
        //    Console.WriteLine("+++++========");
        //}

        DataView theDataView = null;
       /* public override IScheduleAppointmentList GetSchedule(DateTime startDate, DateTime endDate)
        {
          //Ps  ProcessOldMasterListForUnSaveRecurrences();
            theDataView = new DataView(scheduleDataSet.Tables[Table_Appointments]);
            string filter = string.Format("[{0}] >= #{1}# AND [{2}] < #{3}#", MDB_ScheduleItem.Column_StartTime, startDate.Date,
               MDB_ScheduleItem.Column_EndTime, endDate.Date.AddDays(1));
            foreach (DataRow dr in itemsToDelete)
            {
                filter = string.Format("{0} AND [{1}]<>{2} ", filter, MDB_ScheduleItem.Column_UniqueID, dr[MDB_ScheduleItem.Column_UniqueID]);

            }
            //panta theDataView.RowFilter = filter;
            //display(theDataView);

            //display(this.MasterList);
                     MasterList = new MDB_ScheduleItemList(theDataView);

            //  MasterList[0].StartTime;
            //Panta EnforceUniqueIDs();
            // display(this.MasterList);
                    MasterList.SortStartTime();
              return MasterList;
        }
      */
        private void ProcessOldMasterListForUnSaveRecurrences()
        {
            if (itemsToDelete.Count > 0)
            {
                  this.IsDirty = true;
               // MDB_ScheduleDataProvider.scheduleDataSet.Tables[MDB_ScheduleDataProvider.Table_Appointments].AcceptChanges();

            }
            GetUniqueIdsForRecurrences();

             foreach (MDB_ScheduleItem item in MasterList)
            {
                if (item.Dr.RowState == DataRowState.Detached)
                {
                    if (item.RecurrenceRule.Length > 0)
                    {
                        int loc = recurrences.BinarySearch(item.RecurrenceRule);
                        if (loc < 0)
                        {
                            scheduleDataSet.Tables[Table_Appointments].Rows.Add(item.Dr);
                        }
                        else
                        {
                            //need to replace
                            string filter = string.Format("[{0}] = #{1}# AND [{2}]='{3}'", MDB_ScheduleItem.Column_StartTime, item.StartTime, MDB_ScheduleItem.Column_RecurrenceRule, item.RecurrenceRule);
                            DataView dv = new DataView(scheduleDataSet.Tables[Table_Appointments], filter, "", DataViewRowState.CurrentRows);
                            if (dv.Count == 1)
                            {
                                 itemsToDelete.Add(dv[0].Row);
                                 scheduleDataSet.Tables[Table_Appointments].Rows.Add(item.Dr);
                             }
                        }
                    }
                }
                
                
            }
            
            MDB_ScheduleItem.changedItem = null;
            
        }

        List<string> recurrences = new List<string>();
        List<int> recurrenceIDs = new List<int>();
        private void GetUniqueIdsForRecurrences()
        {
            foreach (DataRow dr in scheduleDataSet.Tables[Table_Appointments].Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    string s = dr[MDB_ScheduleItem.Column_RecurrenceRule].ToString();
                    if (s.Length > 0)
                    {
                        int loc = recurrences.BinarySearch(s);
                        if (loc < 0)
                        {
                            recurrences.Insert(-loc - 1, s);
                            recurrenceIDs.Insert(-loc - 1, recurrences.Count);
                        }

                    }
                }
            }
        }
        private void EnforceUniqueIDs()
        {
            foreach (MDB_ScheduleItem item in MasterList)
            {
                if (item.RecurrenceRule.Length > 0)
                {
                    int loc = recurrences.BinarySearch(item.RecurrenceRule);
                    if (loc > -1)
                    {
                        item.RecurrenceRuleID = recurrenceIDs[loc];
                    }
                }
            }
        }
        public override IScheduleAppointmentList GetSchedule(DateTime startDate, DateTime endDate, int owner)
        {
            //owner not supported...
            //return base.GetSchedule(startDate, endDate, owner);
            return GetSchedule(startDate, endDate);
        }
        public override IScheduleAppointmentList GetScheduleForDay(DateTime day)
        {
            return GetSchedule(day, day); ;
        }
        public override IScheduleAppointmentList GetScheduleForDay(DateTime day, int owner)
        {
            //return base.GetScheduleForDay(day, owner);
            //owner not supported
            return GetScheduleForDay(day);
        }
        public override bool IsDirty
        {
            get
            {
                DataTable dt = scheduleDataSet.Tables[Table_Appointments].GetChanges();
                return base.IsDirty || (dt != null && dt.Rows.Count > 0);
            }
            set
            {
               base.IsDirty = value;
            }
        }
        public override IScheduleAppointment NewScheduleAppointment()
        {
            DataRow dr = scheduleDataSet.Tables[Table_Appointments].NewRow();

            PopulateDefaults(dr);
            return new MDB_ScheduleItem(dr); 
        }

        private void PopulateDefaults(DataRow dr)
        {
             dr[MDB_ScheduleItem.Column_AllDay] = false;
             dr[MDB_ScheduleItem.Column_Content] = "";
       // dr[MDB_ScheduleItem.Column_Dirty] = false;
        dr[MDB_ScheduleItem.Column_EndTime] = DateTime.Now;
       // dr[MDB_ScheduleItem.Column_IgnoreChanges] = false;
        dr[MDB_ScheduleItem.Column_LabelValue] = 0;
        dr[MDB_ScheduleItem.Column_LocationValue] = "";
        dr[MDB_ScheduleItem.Column_MarkerValue] = 0;
        dr[MDB_ScheduleItem.Column_Owner] = 0;
        dr[MDB_ScheduleItem.Column_Reminder] = false;
        dr[MDB_ScheduleItem.Column_ReminderValue] = 0;
        dr[MDB_ScheduleItem.Column_StartTime] = DateTime.Now;
        dr[MDB_ScheduleItem.Column_Subject] = "";
        dr[MDB_ScheduleItem.Column_RecurrenceRule] = "";
        //dr[MDB_ScheduleItem.Column_UniqueID] = "ID"; 
        }
        
        public override void RemoveItem(IScheduleAppointment item)
        {
            var s_connection = ConfigurationManager.ConnectionStrings["Saobracaj.Properties.Settings.TESTIRANJEConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(s_connection);
            using (SqlConnection conn = new SqlConnection(s_connection))
    {
        //declare adapter
        SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Appointments", conn);
        dataAdapter.DeleteCommand = new SqlCommand("delete from [Appointments] where ID = @ID", conn);
        
        SqlParameter parameter00INS2 = new SqlParameter();
        parameter00INS2.ParameterName = "@ID";
        parameter00INS2.SqlDbType = SqlDbType.Int;
        parameter00INS2.Direction = ParameterDirection.Input;
        parameter00INS2.Value = Convert.ToInt32(item.UniqueID);
                conn.Open();
                dataAdapter.DeleteCommand.Parameters.Add(parameter00INS2);
                dataAdapter.DeleteCommand.ExecuteNonQuery();
        //int deleted = dataAdapter.Update(scheduleDataSet.Tables[3].Select(null, null, DataViewRowState.Unchanged));

              
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = null;
               // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                
                sql = "delete from [Appointments] where ID = " + Convert.ToInt32(item.UniqueID);
                try
                {
                    myConnection.Open();
                    adapter.DeleteCommand = myConnection.CreateCommand();
                    adapter.DeleteCommand.CommandText = sql;
                    adapter.DeleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Row(s) deleted !! ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


                //int added = dataAdapter.Update(scheduleDataSet.Tables[0].Select(null, null, DataViewRowState.Deleted));



                /*

                if (MDB_ScheduleDataProvider.itemsToDelete == null)
                {
                    MDB_ScheduleDataProvider.itemsToDelete = new List<DataRow>();
                }
                MDB_ScheduleDataProvider.itemsToDelete.Add((item as MDB_ScheduleItem).Dr);
                */
            }
    }
        public override void SaveModifiedItem(IScheduleAppointment appModifiedItem, IScheduleAppointment appOriginalItem)
        {
            (appOriginalItem as MDB_ScheduleItem).Dr.ItemArray = (appModifiedItem as MDB_ScheduleItem).Dr.ItemArray.Clone() as object[];
        }

       
    }

    #endregion

    #region lookup lists

    public class LookUpObjectList : ListObjectList 
    {
        
        public LookUpObjectList(DataView dv)
        {
            foreach (DataRowView drv in dv)
            {
                this.Add(new LookUpObject(drv) as ILookUpObject);
            }
        }
    }

    public class LookUpObject : ListObject
    {
        public static string Column_ID = "ID";
        public static string Column_ColorRed = "ColorRed";
        public static string Column_ColorBlue = "ColorBlue";
        public static string Column_ColorGreen = "ColorGreen";
        public static string Column_Display = "Display";

        DataRowView drv;
        public LookUpObject(DataRowView drv)
            : base((int)drv[Column_ID], drv[Column_Display].ToString(), Color.FromArgb((int)drv[Column_ColorRed], (int)drv[Column_ColorBlue], (int)drv[Column_ColorGreen]))
        {
            this.drv = drv;
        }

        public override Color ColorMember
        {
            get
            {
                return Color.FromArgb((int)drv[Column_ColorRed], (int)drv[Column_ColorBlue], (int)drv[Column_ColorGreen]);
            }
            set
            {
                drv[Column_ColorRed] = value.R;
                drv[Column_ColorBlue] = value.B;
                drv[Column_ColorGreen] = value.G;
            }
        }

        public override string DisplayMember
        {
            get
            {
                return drv[Column_Display].ToString();
            }
            set
            {
                drv[Column_Display] = value;
            }
        }

        public override int ValueMember
        {
            get
            {
                return (int)drv[Column_ID];
            }
            set
            {
                drv[Column_ID] = value;
            }
        }
    }
    #endregion
}
