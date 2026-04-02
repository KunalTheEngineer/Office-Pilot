using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25.Frames
{
    public partial class ucAllInOne : UserControl
    {
        public ucAllInOne()
        {
            InitializeComponent();
        }

        #region CLASS AND OBJECTS

        DataSet ds, ds1, ds2;
        DataTable dt;
        cls_ClientsDL client;
        clsProperties objPro;
        cls_IncomeTaxDL incomeTaxDL;
        cls_EmployeeDL employeeDL;
        cls_Query query;

        #endregion

        #region VARIABLES

        int flag = 0;
        int tempIncomeId = 0;
        int tempClientId = 0;

        string tempEmployeeName, businessName, clientAddress, CLIENTNAME;

        public string ROLE { get; set; }

        public string EMPLOYEENAME { get; set; }

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
                ColorTranslator.FromHtml("#C9C9FF"), // Pending
                ColorTranslator.FromHtml("#FFCCFF"), // In Process
                ColorTranslator.FromHtml("#B4C6E7"), // On Hold
                ColorTranslator.FromHtml("#FFD966"), // Tax Payable
                ColorTranslator.FromHtml("#A2C4C9"), // Tax Amount Received
                ColorTranslator.FromHtml("#EAD1DC"), // Return Filed
                ColorTranslator.FromHtml("#D9EAD3"),  // Refund
                ColorTranslator.FromHtml("#FFFF00"), // Filed
                ColorTranslator.FromHtml("#93C47D") // Task Completed
                
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

        private void ShowQuery()
        {
            query = new cls_Query();
            ds1 = new DataSet();

            ds1 = query.QueryRaisedByEmp("INCOME TAX");

            foreach (DataGridViewRow row in dgvAllInOne.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClName"].Value?.ToString();
                string worktype = row.Cells["WorkType"].Value.ToString();
                string service = "INCOME TAX";

                bool hasQuery = ds1.Tables[0].AsEnumerable().Any(r =>
                   r.Field<string>("q_EmpName") == employee &&
                   r.Field<string>("q_ClientName") == client &&
                   r.Field<string>("q_Service") == service &&
                   r.Field<string>("q_TaskName") == worktype &&
                   r.Field<bool>("hasQuery") == true &&
                   r.Field<bool>("isActive") == true
                 );

                row.DefaultCellStyle.BackColor = hasQuery ? Color.LightCoral : dgvAllInOne.DefaultCellStyle.BackColor;

            }

        }

        private void Clear()
        {
            txtClientName.Clear();
            txtTradeName.Clear();
            txtTaskName.Clear();
            txtReturn.Clear();
            txtYear.Clear();

            DateTime today = DateTime.Now.Date;
            
            dtpDueDate.Value = today;
            dtpInputDate.Value = today;
            

            cmbAllocatedTo.SelectedIndex = 0;
            cmbRecurringTask.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;
            txtFessAmt.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            txtDescription.Clear();

            if (ROLE == "Admin")
            {
                btnSave.Enabled = true;
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
                    tempClientId = Convert.ToInt32(ds.Tables[0].Rows[0]["clientId"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_INCOMETAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void show()
        {
            try
            {
                incomeTaxDL = new cls_IncomeTaxDL();
                ds = new DataSet();

                ds = incomeTaxDL.ShowData(ROLE, EMPLOYEENAME);

                if (ds.Tables[0].Rows.Count >= 0)
                {
                    dgvAllInOne.DataSource = ds.Tables[0];

                    if(ROLE == "User")
                    {
                        dgvAllInOne.Columns["EMPLOYEENAME"].Visible = false;
                    }

                    dgvAllInOne.Columns["i_Periodicity"].Visible = false;
                    dgvAllInOne.Columns["i_RecurringTask"].Visible = false;
                    dgvAllInOne.Columns["i_TradeName"].Visible = false;
                    dgvAllInOne.Columns["i_Fees"].Visible = false;
                    dgvAllInOne.Columns["clientId"].Visible = false;
                    dgvAllInOne.Columns["incomeId"].Visible = false;
                    dgvAllInOne.Columns["serial"].Visible = false;
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

        private void ApplyEmployeePermissions()
        {
            if (ROLE == "User")
            {
                dtpInputDate.Enabled = false;
                dtpDueDate.Enabled = false;
                cmbAllocatedTo.Enabled = false;
                cmbRecurringTask.Enabled = false;
                cmbPeriodicity.Enabled = false;
                cmbFeesStatus.Enabled = false;

                txtFessAmt.ReadOnly = false;
                txtClientName.ReadOnly = true;
                txtTradeName.ReadOnly = true;
                txtTaskName.ReadOnly = true;
                txtYear.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtReturn.ReadOnly = true;

                cmbWorkStatus.Items.Remove("Task Completed");

                btnSave.Enabled = false;

            }
        }

        private void ShowReply()
        {
            query = new cls_Query();
            ds2 = new DataSet();

            ds2 = query.showReplyByAdmin("INCOME TAX");

            foreach (DataGridViewRow row in dgvAllInOne.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClName"].Value?.ToString();
                string worktype = row.Cells["WorkType"].Value.ToString();
                string service = "INCOME TAX";

                bool hasReply = ds2.Tables[0].AsEnumerable().Any(r =>
                   r.Field<string>("q_EmpName") == employee &&
                   r.Field<string>("q_ClientName") == client &&
                   r.Field<string>("q_Service") == service &&
                   r.Field<string>("q_TaskName") == worktype &&
                   r.Field<bool>("isClosed") == true &&
                   r.Field<bool>("isActive") == true
                 );

                row.DefaultCellStyle.BackColor = hasReply ? Color.LightGreen : dgvAllInOne.DefaultCellStyle.BackColor;

            }
        }

        private void GetClientAddress()
        {
            try
            {
                objPro = new clsProperties();
                client = new cls_ClientsDL();
                ds = new DataSet();

                objPro.search = !string.IsNullOrWhiteSpace(txtTradeName.Text) ? txtTradeName.Text.Trim() : txtClientName.Text.Trim();

                ds = client.getClientAddress(tempClientId, CLIENTNAME);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    businessName = ds.Tables[0].Rows[0]["c_BusinessName"].ToString();
                    clientAddress = ds.Tables[0].Rows[0]["c_Address"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_INCOMETAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidateDates()
        {
            if (dtpInputDate.Value.Date > dtpDueDate.Value.Date)
            {
                MessageBox.Show("START DATE CANNOT BE GREATER THAN DUE DATE !", "DATE VALIDATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dtpInputDate.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region EVENTS

        private void ucAllInOne_Load(object sender, EventArgs e)
        {

            ApplyEmployeePermissions();

            BindEmployee();
            BindSearch();
            show();

            cmbRecurringTask.SelectedIndex = 0;
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;
            cmbAllocatedTo.SelectedIndex = 0;

            // USER DEFINED EVENTS
            cmbWorkStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbWorkStatus.DrawItem += cmbWorkStatus_DrawItem;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtReturn.Text == string.Empty)
                {
                    MessageBox.Show("Enter Type Of Return", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtYear.Text == string.Empty)
                {
                    MessageBox.Show("Enter Year", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFessAmt.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fees Amount", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(!ValidateDates())
                {
                    return;
                }

                objPro = new clsProperties();
                incomeTaxDL = new cls_IncomeTaxDL();

                objPro.clientID = tempClientId;
                objPro.clientName = txtClientName.Text;
                objPro.incomeService = "INCOME TAX";
                objPro.incomeInputDate = dtpInputDate.Value;
                objPro.incomeTaskName = txtTaskName.Text;
                objPro.incomeTradeName = txtTradeName.Text;
                objPro.incomeAllocatedEmpName = cmbAllocatedTo.Text;
                objPro.incomeDueDate = dtpDueDate.Value;
                objPro.incomeRecurringTask = cmbRecurringTask.Text;
                objPro.incomePeriodicity = cmbPeriodicity.Text;
                objPro.incomeTypeOfReturn = txtReturn.Text;
                objPro.incomeYear = txtYear.Text;
                objPro.incomeFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.incomeFeeStatus = cmbFeesStatus.Text;
                objPro.incomeStatus = cmbWorkStatus.Text;
                objPro.incomeDescription = txtDescription.Text;

                flag = incomeTaxDL.saveData(objPro);

                if (flag >= 1)
                {
                    Clear();
                    show();
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
                    MessageBox.Show("Enter Client Name", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtReturn.Text == string.Empty)
                {
                    MessageBox.Show("Enter Type Of Return", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtYear.Text == string.Empty)
                {
                    MessageBox.Show("Enter Year", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFessAmt.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fees Amount", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(!ValidateDates())
                {
                    return;
                }

                objPro = new clsProperties();

                objPro.clientID = tempClientId;
                objPro.clientName = txtClientName.Text;
                objPro.incomeService = "INCOME TAX";
                objPro.incomeInputDate = dtpInputDate.Value;
                objPro.incomeTaskName = txtTaskName.Text;
                objPro.incomeTradeName = txtTradeName.Text;
                objPro.incomeAllocatedEmpName = cmbAllocatedTo.Text;
                objPro.incomeDueDate = dtpDueDate.Value;
                objPro.incomeRecurringTask = cmbRecurringTask.Text;
                objPro.incomePeriodicity = cmbPeriodicity.Text;
                objPro.incomeTypeOfReturn = txtReturn.Text;
                objPro.incomeYear = txtYear.Text;
                objPro.incomeFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.incomeFeeStatus = cmbFeesStatus.Text;
                objPro.incomeStatus = cmbWorkStatus.Text;
                objPro.incomeDescription = txtDescription.Text;
                objPro.incomeId = tempIncomeId;

                incomeTaxDL = new cls_IncomeTaxDL();
                flag = incomeTaxDL.updateData(objPro);

                if (flag >= 1)
                {
                    
                    if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "Task Completed")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "INCOME TAX", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dial == DialogResult.Yes)
                        {
                            frm_Narration narr = new frm_Narration();
                            narr.clientName = txtClientName.Text;
                            narr.service = "INCOME TAX";
                            narr.amount = txtFessAmt.Text;
                            narr.workType = txtTaskName.Text;
                            narr.businessName = businessName;
                            narr.clientAddress = clientAddress;

                            narr.Show();
                        }
                    }


                }

                Clear();
                show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_INCOME_TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            if(txtClientName.Text == string.Empty)
            {
                txtTradeName.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void dgvAllInOne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;

                objPro = new clsProperties();

                objPro.rowID = e.RowIndex;

                if (dgvAllInOne.Rows.Count > 0)
                {
                    dtpInputDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[2].Value.ToString();
                    txtClientName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[3].Value.ToString();
                    txtTaskName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[4].Value.ToString();
                    txtReturn.Text = dgvAllInOne.Rows[objPro.rowID].Cells[5].Value.ToString();
                    txtYear.Text = dgvAllInOne.Rows[objPro.rowID].Cells[6].Value.ToString();
                    dtpDueDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[7].Value.ToString();
                    cmbAllocatedTo.Text = dgvAllInOne.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                    cmbWorkStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                    cmbFeesStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[10].Value.ToString().Trim();
                    txtDescription.Text = dgvAllInOne.Rows[objPro.rowID].Cells[11].Value.ToString().Trim();
                    txtTradeName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[12].Value.ToString().Trim();
                    cmbRecurringTask.Text = dgvAllInOne.Rows[objPro.rowID].Cells[13].Value.ToString().Trim();
                    cmbPeriodicity.Text = dgvAllInOne.Rows[objPro.rowID].Cells[14].Value.ToString().Trim();
                    txtFessAmt.Text = dgvAllInOne.Rows[objPro.rowID].Cells[15].Value.ToString();
                    tempIncomeId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[16].Value.ToString());
                    tempClientId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[17].Value.ToString());
                    tempEmployeeName = dgvAllInOne.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                    CLIENTNAME = dgvAllInOne.Rows[objPro.rowID].Cells[3].Value.ToString();

                    GetClientAddress();

                }


                if (e.ColumnIndex == dgvAllInOne.Columns["btnReply"].Index)
                {
                    frm_Query query = new frm_Query(tempEmployeeName);

                    query.workId = tempIncomeId;
                    query.role = ROLE;
                    query.employeeName = tempEmployeeName;
                    query.serviceName = "INCOME TAX";
                    query.clientName = txtClientName.Text;
                    query.taskName = txtTaskName.Text;
                    query.ShowDialog();
                }

            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbRecurringTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRecurringTask.Text == "NO")
            {
                cmbPeriodicity.Enabled = false;
            }
            else
            {
                cmbPeriodicity.Enabled = true;
            }
        }

        private void dtpInputDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateDates();
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateDates();
        }

        private void dgvAllInOne_SelectionChanged(object sender, EventArgs e)
        {
            dgvAllInOne.ClearSelection();
        }

        private void dgvAllInOne_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (ROLE == "User")
            {
                dgvAllInOne.Columns["btnReply"].HeaderText = "QUERY";

                foreach (DataGridViewRow row in dgvAllInOne.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    row.Cells["btnReply"].Value = "QUERY";
                }
            }
            else
            {
                dgvAllInOne.Columns["btnReply"].HeaderText = "REPLY";

                foreach (DataGridViewRow row in dgvAllInOne.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    row.Cells["btnReply"].Value = "REPLY";
                }
            }

            dgvAllInOne.Columns["btnReply"].DisplayIndex = dgvAllInOne.Columns.Count - 1;

        }

        private void dgvAllInOne_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (ROLE == "Admin")
            {
                ShowQuery();
            }
            else
            {
                ShowReply();
            }

            #region CHANGE STATUS COLORS

            Dictionary<string, Color> StatusColors = new Dictionary<string, Color>()
            {
                { "Not Started", ColorTranslator.FromHtml("#D6DCE4") },
                { "Waiting For Documents", ColorTranslator.FromHtml("#F4B084") },
                { "Document Received", ColorTranslator.FromHtml("#A9D08E") },
                { "Return Prepaired", ColorTranslator.FromHtml("#00B0F0") },
                { "Cancelled", ColorTranslator.FromHtml("#FF0000") },
                { "Complete", ColorTranslator.FromHtml("#FFC000") },
                { "Pending", ColorTranslator.FromHtml("#C9C9FF") },
                { "In Process", ColorTranslator.FromHtml("#FFCCFF") },
                { "On Hold", ColorTranslator.FromHtml("#B4C6E7") },
                { "Tax Payable", ColorTranslator.FromHtml("#FFD966") },
                { "Tax Amount Received", ColorTranslator.FromHtml("#A2C4C9") },
                { "Return Filed", ColorTranslator.FromHtml("#EAD1DC") },
                { "Refund", ColorTranslator.FromHtml("#D9EAD3") },
                { "Filed", ColorTranslator.FromHtml("#FFFF00") },
                { "Task Completed", ColorTranslator.FromHtml("#93C47D") }

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

            if (dgvAllInOne.Columns[e.ColumnIndex].Name == "btnReply")
            {
                string text = dgvAllInOne.Rows[e.RowIndex].Cells["btnReply"].Value?.ToString();

                if (text == "QUERY")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void txtTradeName_Leave(object sender, EventArgs e)
        {
            if (txtTradeName.Text == string.Empty)
            {
                return;
            }
            else
            {
                SearchClient();
            }
        }

        private void txtClientName_Leave(object sender, EventArgs e)
        {
            if (txtClientName.Text == string.Empty)
            {
                return;
            }
            else
            {
                SearchClient();
            }
       
        }

        #endregion

    }
}
