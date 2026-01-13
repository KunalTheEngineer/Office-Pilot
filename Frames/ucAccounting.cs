using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25.Frames
{
    public partial class ucAccounting : UserControl
    {
        public ucAccounting()
        {
            InitializeComponent();
        }

        #region Variables

        string tempEmployeeName;
        string serviceName;
        string tempClientName;
        string tempWorkType;
        int clientId, flag, tempAccId, tempClientId;
        string service, businessName, clientAddress;

        #endregion

        #region Class and Objects

        DataTable dt;
        DataSet ds;
        cls_EmployeeDL employeeDL;
        cls_ClientsDL client;
        clsProperties objPro;
        cls_AccountingDL accountingDL;

        #endregion

        #region USER DEFINED EVENTS

        private void cmbWorkStatus_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            Color[] bgColors =
            {
                ColorTranslator.FromHtml("#D6DCE4"), // Not Started
                ColorTranslator.FromHtml("#F4B084"), // Waiting for Documents
                ColorTranslator.FromHtml("#A9D08E"), // Document Received
                ColorTranslator.FromHtml("#00B0F0"), // Return Prepared
                ColorTranslator.FromHtml("#FF0000"), // Cancelled
                ColorTranslator.FromHtml("#FFC000"), // Complit
                ColorTranslator.FromHtml("#FFFF00"), // DONE
            };

            Color backColor = bgColors[e.Index];

            // This removes the blue highlight effect
            using (Brush backgroundBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            using (Brush textBrush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(
                    cmbWorkStatus.Items[e.Index].ToString(),
                    e.Font,
                    textBrush,
                    e.Bounds
                );
            }

            e.DrawFocusRectangle();
        }

        #endregion

        #region EVENTS

        private void ucAccounting_Load(object sender, EventArgs e)
        {
            BindEmployee();
            BindSearch();

            show();

            cmbAllocatedTo.SelectedIndex = 0;
            cmbRecurringTask.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

            // USER DEFINED EVENTS
            cmbWorkStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbWorkStatus.DrawItem += cmbWorkStatus_DrawItem;
        }

        private void dgvAllInOne_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowQuery();

            #region CHANGE STATUS COLORS

            Dictionary<string, Color> StatusColors = new Dictionary<string, Color>()
            {
                { "Not Started", ColorTranslator.FromHtml("#D6DCE4") },
                { "Waiting For Documents", ColorTranslator.FromHtml("#F4B084") },
                { "Document Received", ColorTranslator.FromHtml("#A9D08E") },
                { "Return Prepaired", ColorTranslator.FromHtml("#00B0F0") },
                { "Cancelled", ColorTranslator.FromHtml("#FF0000") },
                { "Complete", ColorTranslator.FromHtml("#FFC000") },
                { "Done", ColorTranslator.FromHtml("#FFFF00") }
            };

            if (dgvAllInOne.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();

                    if (StatusColors.ContainsKey(status))
                    {
                        e.CellStyle.BackColor = StatusColors[status];
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }

            #endregion
        }

        private void dgvAllInOne_SelectionChanged(object sender, EventArgs e)
        {
            dgvAllInOne.ClearSelection();
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            if (txtClientName.Text == string.Empty)
            {
                txtTradeName.Clear();
            }
        }

        private void txtClientName_Leave(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void dgvAllInOne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            objPro = new clsProperties();

            objPro.rowID = e.RowIndex;

            if (dgvAllInOne.Rows.Count > 0)
            {
                dtpInputDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[2].Value.ToString();
                txtClientName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[3].Value.ToString();
                txtTaskName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[4].Value.ToString();
                txtYear.Text = dgvAllInOne.Rows[objPro.rowID].Cells[5].Value.ToString();
                dtpDueDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[6].Value.ToString();
                cmbAllocatedTo.Text = dgvAllInOne.Rows[objPro.rowID].Cells[7].Value.ToString().Trim();
                cmbWorkStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                txtDescription.Text = dgvAllInOne.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                txtTradeName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[10].Value.ToString().Trim();
                txtWorkPeriod.Text = dgvAllInOne.Rows[objPro.rowID].Cells[11].Value.ToString();
                cmbRecurringTask.Text = dgvAllInOne.Rows[objPro.rowID].Cells[12].Value.ToString();
                cmbPeriodicity.Text = dgvAllInOne.Rows[objPro.rowID].Cells[13].Value.ToString();
                tempAccId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[14].Value.ToString());
                tempClientId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[15].Value.ToString());

            }

            if (e.ColumnIndex == dgvAllInOne.Columns["btnReply"].Index)
            {
                frm_Query query = new frm_Query(tempEmployeeName);

                query.employeeName = tempEmployeeName;
                query.serviceName = serviceName;
                query.clientName = tempClientName;
                query.workTypeName = tempWorkType;
                query.ShowDialog();
            }
        }

        private void txtTradeName_Leave(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "ACCOUNTING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "ACCOUNTING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkPeriod.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Period", "ACCOUNTING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                objPro.clientID = clientId;
                objPro.clientName = txtClientName.Text;
                objPro.accountInputDate = dtpInputDate.Value;
                objPro.accountTradeName = txtTradeName.Text;
                objPro.accountTaskName = txtTaskName.Text;
                objPro.accountAllocatedEmp = cmbAllocatedTo.Text;
                objPro.accountDueDate = dtpDueDate.Value;
                objPro.accountWorkPeriod = txtWorkPeriod.Text;
                objPro.accountRecurringTask = cmbRecurringTask.Text;
                objPro.accountPeriodicity = cmbPeriodicity.Text;
                objPro.accountStatus = cmbWorkStatus.Text;
                objPro.accountYear = txtYear.Text;
                objPro.accountDescription = txtDescription.Text;

                accountingDL = new cls_AccountingDL();
                flag = accountingDL.saveData(objPro);

                if (flag >= 1)
                {
                    show();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "ACCOUNTING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "ACCOUNTING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkPeriod.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Period", "ACCOUNTING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                objPro.accountId = tempAccId;
                objPro.clientID = tempClientId;
                objPro.clientName = txtClientName.Text;
                objPro.accountInputDate = dtpInputDate.Value;
                objPro.accountTradeName = txtTradeName.Text;
                objPro.accountTaskName = txtTaskName.Text;
                objPro.accountAllocatedEmp = cmbAllocatedTo.Text;
                objPro.accountDueDate = dtpDueDate.Value;
                objPro.accountWorkPeriod = txtWorkPeriod.Text;
                objPro.accountRecurringTask = cmbRecurringTask.Text;
                objPro.accountPeriodicity = cmbPeriodicity.Text;
                objPro.accountStatus = cmbWorkStatus.Text;
                objPro.accountYear = txtYear.Text;
                objPro.accountDescription = txtDescription.Text;

                accountingDL = new cls_AccountingDL();
                flag = accountingDL.updateData(objPro);

                if (flag >= 1)
                {

                    //if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "DONE")
                    //{
                    //    DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "ACCOUNTING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //    if (dial == DialogResult.Yes)
                    //    {
                    //        frm_Narration narr = new frm_Narration();
                    //        narr.clientName = txtClientName.Text;
                    //        narr.service = common.service;
                    //        narr.amount = "";
                    //        narr.workType = txtWorkType.Text;
                    //        narr.businessName = businessName;
                    //        narr.clientAddress = clientAddress;

                    //        narr.Show();
                    //    }
                    //}

                    //MessageBox.Show("Record Updated...");
                    show();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ACCOUNTING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region FUNCTIONS

        private void BindSearch()
        {
            try
            {
                ds = new DataSet();
                client = new cls_ClientsDL();
                ds = client.bindClientsData();

                AutoCompleteStringCollection autoList = new AutoCompleteStringCollection();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        autoList.Add(ds.Tables[0].Rows[i]["c_Name"].ToString());
                        autoList.Add(ds.Tables[0].Rows[i]["c_Mobile"].ToString());
                        autoList.Add(ds.Tables[0].Rows[i]["c_BusinessName"].ToString());
                    }

                    this.txtClientName.AutoCompleteCustomSource = autoList;
                    txtClientName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    this.txtTradeName.AutoCompleteCustomSource = autoList;
                    txtTradeName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtTradeName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SearchClient()
        {
            try
            {
                objPro = new clsProperties();
                client = new cls_ClientsDL();
                ds = new DataSet();

                objPro.search = !string.IsNullOrWhiteSpace(txtTradeName.Text) ? txtTradeName.Text.Trim() : txtClientName.Text.Trim();

                ds = client.searchClientTradeName(objPro);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtClientName.Text = ds.Tables[0].Rows[0]["c_Name"].ToString();
                    txtTradeName.Text = ds.Tables[0].Rows[0]["c_BusinessName"].ToString();
                    clientId = Convert.ToInt32(ds.Tables[0].Rows[0]["clientId"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_INCOMETAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowQuery()
        {
            //query = new cls_Query();
            //ds1 = new DataSet();

            //ds1 = query.QueryRaisedByEmp();

            //foreach (DataGridViewRow row in dgvAllInOne.Rows)
            //{
            //    if (row.IsNewRow)
            //        continue;

            //    string employee = row.Cells["EmployeeName"].Value?.ToString();
            //    string client = row.Cells["ClientName"].Value?.ToString();
            //    string worktype = row.Cells["WorkType"].Value.ToString();

            //    service = "ACCOUNTING";
            //    var queryRow = ds1.Tables[0].AsEnumerable().FirstOrDefault(r =>
            //       r.Field<string>("EmployeeName") == employee &&
            //       r.Field<string>("clientName") == client &&
            //       r.Field<string>("service") == service &&
            //       r.Field<string>("workType") == worktype
            //     //&&
            //     //!string.IsNullOrEmpty(r.Field<string>("queryByEmp"))
            //     );


            //    bool hasQuery = false;

            //    if (queryRow != null)
            //    {
            //        object val = queryRow["HasQuery"];

            //        if (val != DBNull.Value && int.TryParse(val.ToString(), out int parsed))
            //        {
            //            hasQuery = parsed == 1;
            //        }
            //    }

            //    // row.DefaultCellStyle.BackColor = hasQuery ? Color.OrangeRed : DefaultBackColor;
            //    row.Cells["btnQuery"].Style.BackColor = hasQuery ? Color.Crimson : DefaultBackColor;
            //   // row.Cells["btnQuery"].Style.ForeColor = Color.White;
            //    //if(hasQuery)
            //    //{
            //    //    DataGridViewCell buttonCell = row.Cells["btnQuery"];
            //    //    buttonCell.Style.BackColor = Color.Red;
            //    //    buttonCell.Style.ForeColor = Color.Black;
            //    //}
            //}
        }

        private void Clear()
        {
            txtClientName.Clear();
            txtTradeName.Clear();
            txtTaskName.Clear();
            txtWorkPeriod.Clear();
            txtYear.Clear();
            txtDescription.Clear();

            dtpInputDate.Text = DateTime.Now.ToString();
            dtpDueDate.Text = DateTime.Now.ToString();

            cmbAllocatedTo.SelectedIndex = 0;
            cmbRecurringTask.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

            btnSave.Enabled = true;
        }

        private void show()
        {
            try
            {
                ds = new DataSet();
                accountingDL = new cls_AccountingDL();

                ds = accountingDL.ShowData();

                if (ds.Tables[0].Rows.Count >= 0)
                {
                    dgvAllInOne.DataSource = ds.Tables[0];

                    dgvAllInOne.Columns["accountId"].Visible = false;
                    dgvAllInOne.Columns["clientId"].Visible = false;
                    dgvAllInOne.Columns["a_TradeName"].Visible = false;
                    dgvAllInOne.Columns["a_RecurringTask"].Visible = false;
                    dgvAllInOne.Columns["a_Periodicity"].Visible = false;
                    dgvAllInOne.Columns["a_WorkPeriod"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BindEmployee()
        {
            try
            {
                dt = new DataTable();
                employeeDL = new cls_EmployeeDL();
                dt = employeeDL.bindEmployee();

                cmbAllocatedTo.DataSource = dt;
                cmbAllocatedTo.DisplayMember = "e_Name";
                cmbAllocatedTo.ValueMember = "empId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
