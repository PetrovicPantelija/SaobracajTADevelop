using Saobracaj.Dokumenta.TrainList;
using Saobracaj.Dokumenta.TrainListItem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Saobracaj.Dokumenta
{
    public partial class frmTrainList : Form
    {
        private TrainListDAO _trainList = new TrainListDAO();
        private TrainListItemDAO _trainListItem = new TrainListItemDAO();

         int trainListSelectedRow;
         int trainListItemSelectedRow;

        public frmTrainList()
        {
            InitializeComponent();
            setStyle();
        }
        private void frmTrainList_Load(object sender, EventArgs e)
        {
            groupBoxAddEdit.Visible = false;

            var data = _trainList.GetAll();
            if (data.Count>0)
            {
                dataGrid1.DataSource = data;
                trainListSelectedRow = dataGrid1.CurrentRow.Index;

                List<TrainListItemModel> itemList = _trainListItem.GetAllBySuperiorId((int)dataGrid1.Rows[trainListSelectedRow].Cells[0].Value);
                if (itemList.Count>0)
                {
                    dataGrid2.DataSource = itemList;

                    Total totalCalc = new Total(itemList, (int)dataGrid1.Rows[trainListSelectedRow].Cells[0].Value);
                    txt_TotalUnitTare.Text = totalCalc.TotalUnitTare.ToString() + " kg";
                    txt_TotalGoods.Text = totalCalc.TotalGoods.ToString() + " kg";
                    txt_TotalWagonTare.Text = totalCalc.TotalWagonTare.ToString() + " kg";
                    txt_TotalWeight.Text = totalCalc.TotalWeight.ToString() + " kg";
                    txt_TotalTrainLength.Text = totalCalc.TotalTrainLength.ToString() + " m";

                    trainListItemSelectedRow = dataGrid2.CurrentRow.Index;
                    List<int> NHM = _trainListItem.GetAllNHMBySuperiorId((int)dataGrid2.Rows[trainListItemSelectedRow].Cells[0].Value);
                    txt_NHM.Text = "";
                    foreach (int n in NHM)
                    {
                        txt_NHM.Text += n.ToString() + Environment.NewLine;
                    }
                    List<string> MRN = _trainListItem.GetAllMRNBySuperiorId((int)dataGrid2.Rows[trainListItemSelectedRow].Cells[0].Value);
                    txt_MRN.Text = "";
                    foreach (string n in MRN)
                    {
                        txt_MRN.Text += n + Environment.NewLine;
                    }
                    List<string> Seals = _trainListItem.GetAllSealsBySuperiorId((int)dataGrid2.Rows[trainListItemSelectedRow].Cells[0].Value);
                    txt_Seals.Text = "";
                    foreach (string n in Seals)
                    {
                        txt_Seals.Text += n + Environment.NewLine;
                    }
                }
                
            }

        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            trainListSelectedRow = dataGrid1.CurrentRow.Index;
            List<TrainListItemModel> itemList = _trainListItem.GetAllBySuperiorId((int)dataGrid1.Rows[trainListSelectedRow].Cells[0].Value);
            dataGrid2.DataSource = itemList;

            Total totalCalc = new Total(itemList, (int)dataGrid1.Rows[trainListSelectedRow].Cells[0].Value);
            txt_TotalUnitTare.Text = totalCalc.TotalUnitTare.ToString() + " kg";
            txt_TotalGoods.Text = totalCalc.TotalGoods.ToString() + " kg";
            txt_TotalWagonTare.Text = totalCalc.TotalWagonTare.ToString() + " kg";
            txt_TotalWeight.Text = totalCalc.TotalWeight.ToString() + " kg";
            txt_TotalTrainLength.Text = totalCalc.TotalTrainLength.ToString() + " m";
        }
        private void dataGrid2_Click(object sender, EventArgs e)
        {
            trainListItemSelectedRow = dataGrid2.CurrentRow.Index;
            List<int> NHM = _trainListItem.GetAllNHMBySuperiorId((int)dataGrid2.Rows[trainListItemSelectedRow].Cells[0].Value);
            txt_NHM.Text = "";
            foreach (int n in NHM)
            {
                txt_NHM.Text += n.ToString() + Environment.NewLine;
            }
            List<string> MRN = _trainListItem.GetAllMRNBySuperiorId((int)dataGrid2.Rows[trainListItemSelectedRow].Cells[0].Value);
            txt_MRN.Text = "";
            foreach (string n in MRN)
            {
                txt_MRN.Text += n + Environment.NewLine;
            }
            List<string> Seals = _trainListItem.GetAllSealsBySuperiorId((int)dataGrid2.Rows[trainListItemSelectedRow].Cells[0].Value);
            txt_Seals.Text = "";
            foreach (string n in Seals)
            {
                txt_Seals.Text += n + Environment.NewLine;
            }
        }

        private void btn_ImportExcel_Click(object sender, EventArgs e)
        {
            trainListSelectedRow = dataGrid1.CurrentRow.Index;
            _trainListItem.ReadFromExcel((int)dataGrid1.Rows[trainListSelectedRow].Cells[0].Value);

            dataGrid2.DataSource = _trainListItem.GetAllBySuperiorId((int)dataGrid1.Rows[trainListSelectedRow].Cells[0].Value);
            dataGrid2.ClearSelection();
            dataGrid2.Rows[dataGrid2.Rows.Count - 1].Selected = true;
            dataGrid2.FirstDisplayedScrollingRowIndex = dataGrid2.RowCount - 1;

            trainListItemSelectedRow = dataGrid2.Rows.Count - 1;
            List<int> NHM = _trainListItem.GetAllNHMBySuperiorId((int)dataGrid2.Rows[trainListItemSelectedRow].Cells[0].Value);
            txt_NHM.Text = "";
            foreach (int n in NHM)
            {
                txt_NHM.Text += n.ToString() + Environment.NewLine;
            }
            List<string> MRN = _trainListItem.GetAllMRNBySuperiorId((int)dataGrid2.Rows[trainListItemSelectedRow].Cells[0].Value);
            txt_MRN.Text = "";
            foreach (string n in MRN)
            {
                txt_MRN.Text += n + Environment.NewLine;
            }
            List<string> Seals = _trainListItem.GetAllSealsBySuperiorId((int)dataGrid2.Rows[trainListItemSelectedRow].Cells[0].Value);
            txt_Seals.Text = "";
            foreach (string n in Seals)
            {
                txt_Seals.Text += n + Environment.NewLine;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGrid1.Rows.Count != 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item?",
                     "Confirm Delete!",
                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    trainListSelectedRow = dataGrid1.CurrentRow.Index;
                    int id = (int)dataGrid1.Rows[trainListSelectedRow].Cells[0].Value;
                    int resoult = _trainList.Delete(id);
                      MessageBox.Show(resoult + " row(s) is deleted");

                    // Refresh the table
                    dataGrid1.DataSource = _trainList.GetAll();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGrid1.Rows.Count != 0)
            {
                groupBoxAddEdit.Visible = true;
                groupBoxAddEdit.Text = "Edit Train Item";
                btnAddUpdate.Text = "Update";
                trainListSelectedRow = dataGrid1.CurrentRow.Index;
                departure_time.Value = (DateTime)dataGrid1.Rows[trainListSelectedRow].Cells[1].Value;
                txt_trainNo.Text = (string)dataGrid1.Rows[trainListSelectedRow].Cells[2].Value;
                txt_note.Text = (string)dataGrid1.Rows[trainListSelectedRow].Cells[3].Value;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            groupBoxAddEdit.Visible = true;
            groupBoxAddEdit.Text = "Insert Train Item";
            btnAddUpdate.Text = "Add";
            departure_time.Value = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search")
            {
                if (string.IsNullOrEmpty(textBoxSearch.Text))
                {
                    dataGrid1.DataSource = _trainList.GetAll();
                }
                else
                {
                    dataGrid1.DataSource = _trainList.Search(textBoxSearch.Text);
                    btnSearch.Text = "Show All";
                }
            }
            else
            {
                dataGrid1.DataSource = _trainList.GetAll();
                btnSearch.Text = "Search";
                textBoxSearch.Text = string.Empty;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            groupBoxAddEdit.Visible = false;
            trainListSelectedRow = dataGrid1.CurrentRow.Index;
            txt_trainNo.Text = string.Empty;
            departure_time.Value = DateTime.Now;
            txt_note.Text = string.Empty;
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (btnAddUpdate.Text == "Add")
            {
                TrainListModel trainList = new TrainListModel()
                {
                    DepartureTime = departure_time.Value,
                    TrainNo = txt_trainNo.Text,
                    Note = txt_note.Text
                };
                int resoult = _trainList.Insert(trainList);
                 MessageBox.Show(resoult + " row(s) is added");
                // Refresh the table
                dataGrid1.DataSource = _trainList.GetAll();
                dataGrid1.ClearSelection();
                dataGrid1.Rows[dataGrid1.Rows.Count - 1].Selected = true;
                dataGrid1.FirstDisplayedScrollingRowIndex = dataGrid1.RowCount - 1;
                groupBoxAddEdit.Visible = false;
            }
            else
            {
                int id = (int)dataGrid1.Rows[trainListSelectedRow].Cells[0].Value;
                TrainListModel trainList = new TrainListModel()
                {
                    Id=id,
                    DepartureTime = departure_time.Value,
                    TrainNo = txt_trainNo.Text,
                    Note = txt_note.Text
                };
                int resoult = _trainList.Update(trainList);
                MessageBox.Show(resoult + " row is updated");
                // Refresh the table
                dataGrid1.DataSource = _trainList.GetAll();
                groupBoxAddEdit.Visible = false;
            }

        }

        private void setStyle()
        {
            //dataGrid1.BorderStyle = BorderStyle.None;
            dataGrid1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGrid1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGrid1.BackgroundColor = Color.White;
            dataGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGrid1.AllowUserToAddRows = false;
            dataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid1.RowHeadersVisible = false;
            dataGrid1.AutoSizeColumnsMode= (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;


            //dataGrid2.BorderStyle = BorderStyle.None;
            dataGrid2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGrid2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGrid2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGrid2.BackgroundColor = Color.White;
            dataGrid2.AllowUserToAddRows = false;
            dataGrid2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid2.RowHeadersVisible = false;
            dataGrid2.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
        }


    }
}
