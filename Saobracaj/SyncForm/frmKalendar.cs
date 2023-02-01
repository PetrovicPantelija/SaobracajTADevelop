using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using Syncfusion.Windows.Forms.Grid.Grouping;

using Syncfusion.Windows.Forms.Schedule;
using GridScheduleSample;
using Syncfusion.Schedule;
using System.Collections.Specialized;
using MDB_ScheduleSample_CS;
using Syncfusion.Windows.Forms;



namespace Saobracaj.SyncForm
{
    public partial class frmKalendar : Syncfusion.Windows.Forms.Office2010Form
    {
        MDB_ScheduleDataProvider scheduleProvider = new MDB_ScheduleDataProvider("..\\..\\ScheduleData.mdb");
        ///MasterListArray list2 = new MasterListArray();
        // MDB_ScheduleItemList list = new MDB_ScheduleItemList(DataView dv);
        ArrayListAppointmentList list = new ArrayListAppointmentList();

        public frmKalendar()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void RefreshDataGrid()
        {
            //ArrayListAppointmentList list = new ArrayListAppointmentList();
            string path = Application.ExecutablePath;
            ReadData();
            scheduleProvider.MasterList = list;
            scheduleControl1.ScheduleType = ScheduleViewType.Month;
            scheduleControl1.Appearance.VisualStyle = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            scheduleControl1.DataSource = scheduleProvider;
        }

        private void frmKalendar_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }


        private void ReadData()
        {

            var s_connection = ConfigurationManager.ConnectionStrings["Saobracaj.Properties.Settings.TESTIRANJEConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s_connection);
            string sql = "SELECT * FROM Appointments";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ScheduleAppointment item = new ScheduleAppointment();
                item.UniqueID = (int)dr["ID"];
                item.Subject = (string)dr["Subject"];
                item.StartTime = (DateTime)dr["StartTime"];
                item.ReminderValue = (int)dr["ReminderValue"];
                item.Reminder = false;
                item.Owner = (int)dr["Owner"];
                item.MarkerValue = (int)dr["MarkerValue"];
                item.LocationValue = (string)dr["LocationValue"];
                item.LabelValue = (int)dr["LabelValue"];
                item.EndTime = (DateTime)dr["EndTime"];
                item.Content = (string)dr["Content"];
                item.AllDay = false;

                item.Dirty = false;
                if (ProveriPostojiItem2(item) == true)
                {
                    list.Add(item);

                };


            }
        }

        void CheckAndSaveIfNeeded(bool prompt)
        {//MasterList
            if (this.scheduleControl1.DataSource.IsDirty
                 && (!prompt || MessageBox.Show("Save changes?", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                 == DialogResult.Yes))
            {
                // scheduleProvider.CommitChanges();
                // MDB_ScheduleDataProvider.ScheduleDataProvider.CommitChanges();
                // foreach (IScheduleAppointment item in IScheduleAppointmentList)
                // {

                //  }
                //scheduleProvider.SaveModifiedItem(
                this.scheduleControl1.DataSource.CommitChanges();
                ReadData();
                scheduleProvider.MasterList = list;
                // SimpleScheduleDataProvider dataProvider = new SimpleScheduleDataProvider();
                //dataProvider.MasterList = SimpleScheduleDataProvider.InitializeRandomDataSource();
                //scheduleControl1.DataSource = scheduleProvider;


                scheduleControl1.ScheduleType = ScheduleViewType.Month;
                scheduleControl1.Appearance.VisualStyle = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Silver;
                this.scheduleControl1.Culture = Application.CurrentCulture;
                scheduleControl1.DataSource = scheduleProvider;

                RefreshDataGrid();
            }

        }

        private bool ProveriPostojiItem2(ScheduleAppointment item)
        {
            foreach (ScheduleAppointment item2 in list)
            {
                if (item2.UniqueID == item.UniqueID)
                {
                    return false;
                }
            }
            return true;
        }

        private void buttonAdv1_Click(object sender, EventArgs e)
        {
            // MDB_ScheduleDataProvider novi = new MDB_ScheduleDataProvider();
            // novi.UpdateAdmins(scheduleControl1.DataSource);
            foreach (ScheduleAppointment item in list)
            {
                if (item.Dirty == true)
                {
                    scheduleProvider.UpdateChanges(item);
                }
            }

            // scheduleControl1.DataSource.UpdateAdmins(DataSet ds);
            CheckAndSaveIfNeeded(false);
        }

        private void scheduleControl1_ParseDisplayItem(object sender, ParseDisplayItemEventArgs e)
        {
            e.FormattedText = e.Item.Subject + "-" + e.Item.StartTime.Hour + ":" + e.Item.StartTime.Minute + " " +
               +e.Item.EndTime.Hour + ":" + e.Item.EndTime.Minute + " " + e.Item.LocationValue;
            e.Handled = true;
        }
    }
}
