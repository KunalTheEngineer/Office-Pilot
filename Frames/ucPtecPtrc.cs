
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25.Frames
{
    public partial class ucPtecPtrc : UserControl
    {
        public ucPtecPtrc()
        {
            InitializeComponent();
        }

        #region CLASS AND OBJECTS

        DataTable dt;
        DataSet ds, ds1, ds2;
        cls_EmployeeDL employeeDL;
        clsProperties objPro;
        cls_PtecDL ptecDL;
        cls_ClientUserPassDL clientUserPassDL;
        cls_Query query;
        cls_BusinessDL bus;
        cls_ClientsDL client;

        #endregion

        #region VARIABLES

        int clientId, flag, tempPtecId, tempClientId;
        int present = 0;
        string tempEmployeeName, tempClientName, tempWorkType, serviceName, service, businessName, clientAddress, CLIENTNAME;

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
                ColorTranslator.FromHtml("#FFC000"), // Complete
                ColorTranslator.FromHtml("#FFFF00"), // Filed
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

        private void ucPtecPtrc_Load(object sender, EventArgs e)
        {

            ApplyEmployeePermissions();

            BindSearch();
            BindEmployee();
            show();

            cmbAllocatedTo.SelectedIndex = 0;
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            cmbRecurringTask.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;

            // USER DEFINED EVENTS
            cmbWorkStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbWorkStatus.DrawItem += cmbWorkStatus_DrawItem;
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            if(txtClientName.Text == string.Empty)
            {
                txtTradeName.Clear();
            }
        }

        private void txtClientName_Leave(object sender, EventArgs e)
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
                    MessageBox.Show("Enter Client Name", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtYear.Text == string.Empty)
                {
                    MessageBox.Show("Enter Year", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFees.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fess Amount", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(!ValidateDates())
                {
                    return;
                }


                objPro = new clsProperties();

                objPro.clientID = tempClientId;
                objPro.ptecInputDate = dtpInputDate.Value;
                objPro.clientName = txtClientName.Text;
                objPro.ptecTradeName = txtTradeName.Text;
                objPro.ptecTaskName = txtTaskName.Text;
                objPro.ptecDueDate = dtpDueDate.Value;
                objPro.ptecAllocatedEmp = cmbAllocatedTo.Text;
                objPro.ptecRecurringTask = cmbRecurringTask.Text;
                objPro.ptecPeriodicity = cmbPeriodicity.Text;
                objPro.ptecYear = txtYear.Text;
                objPro.ptecFees = Convert.ToInt32(txtFees.Text);
                objPro.ptecFeeStatus = cmbFeesStatus.Text;
                objPro.ptecStatus = cmbWorkStatus.Text;
                objPro.ptecDescription = txtDescription.Text;

                ptecDL = new cls_PtecDL();
                flag = ptecDL.saveData(objPro);

                if (flag >= 1)
                {
                    show();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_PTEC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (txtYear.Text == string.Empty)
                {
                    MessageBox.Show("Enter Year", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (txtFees.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fess Amount", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(!ValidateDates())
                {
                    return;
                }

                objPro = new clsProperties();


                objPro.clientID = clientId;
                objPro.ptecInputDate = dtpInputDate.Value;
                objPro.clientName = txtClientName.Text;
                objPro.ptecTradeName = txtTradeName.Text;
                objPro.ptecTaskName = txtTaskName.Text;
                objPro.ptecDueDate = dtpDueDate.Value;
                objPro.ptecAllocatedEmp = cmbAllocatedTo.Text;
                objPro.ptecRecurringTask = cmbRecurringTask.Text;
                objPro.ptecPeriodicity = cmbPeriodicity.Text;
                objPro.ptecYear = txtYear.Text;
                objPro.ptecFees = Convert.ToInt32(txtFees.Text);
                objPro.ptecFeeStatus = cmbFeesStatus.Text;
                objPro.ptecStatus = cmbWorkStatus.Text;
                objPro.ptecDescription = txtDescription.Text;
                objPro.ptecId = tempPtecId;

                ptecDL = new cls_PtecDL();
                flag = ptecDL.updateData(objPro);

                if (flag >= 1)
                {

                    if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "Filed")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "PTEC/PTRC", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dial == DialogResult.Yes)
                        {
                            frm_Narration narr = new frm_Narration();
                            narr.clientName = txtClientName.Text;
                            narr.service = "PTEC/PTRC";
                            narr.amount = txtFees.Text;
                            narr.workType = txtTaskName.Text;
                            narr.businessName = businessName;
                            narr.clientAddress = clientAddress;

                            narr.Show();
                        }
                    }

                }

                show();
                Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_PTEC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTradeName_Leave(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void dgvPTEC_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (ROLE == "User")
            {
                foreach (DataGridViewRow row in dgvPTEC.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }

                    row.Cells["btnReply"].Value = "QUERY";
                    dgvPTEC.Columns["btnReply"].HeaderText = "QUERY";
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvPTEC.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }

                    row.Cells["btnReply"].Value = "REPLY";
                    dgvPTEC.Columns["btnReply"].HeaderText = "REPLY";
                }
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

        private void dgvPTEC_SelectionChanged(object sender, EventArgs e)
        {
            dgvPTEC.ClearSelection();
        }

        private void dtpInputDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateDates();
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateDates();
        }

        private void dgvPTEC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
                { "Filed", ColorTranslator.FromHtml("#FFFF00") }
            };

            if (dgvPTEC.Columns[e.ColumnIndex].Name == "Status")
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

            if (dgvPTEC.Columns[e.ColumnIndex].Name == "btnReply")
            {
                string text = dgvPTEC.Rows[e.RowIndex].Cells["btnReply"].Value?.ToString();

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

        private void dgvPTEC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            objPro = new clsProperties();

            objPro.rowID = e.RowIndex;

            if (dgvPTEC.Rows.Count > 0)
            {
                dtpInputDate.Text = dgvPTEC.Rows[objPro.rowID].Cells[2].Value.ToString();
                txtClientName.Text = dgvPTEC.Rows[objPro.rowID].Cells[3].Value.ToString();
                txtTradeName.Text = dgvPTEC.Rows[objPro.rowID].Cells[4].Value.ToString();
                txtTaskName.Text = dgvPTEC.Rows[objPro.rowID].Cells[5].Value.ToString();
                cmbAllocatedTo.Text = dgvPTEC.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();
                dtpDueDate.Text = dgvPTEC.Rows[objPro.rowID].Cells[7].Value.ToString();
                cmbFeesStatus.Text = dgvPTEC.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                cmbWorkStatus.Text = dgvPTEC.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                 txtDescription.Text = dgvPTEC.Rows[objPro.rowID].Cells[10].Value.ToString().Trim();
                cmbRecurringTask.Text = dgvPTEC.Rows[objPro.rowID].Cells[11].Value.ToString().Trim();
                cmbPeriodicity.Text = dgvPTEC.Rows[objPro.rowID].Cells[12].Value.ToString().Trim();
                txtYear.Text = dgvPTEC.Rows[objPro.rowID].Cells[13].Value.ToString().Trim();
                txtFees.Text = dgvPTEC.Rows[objPro.rowID].Cells[14].Value.ToString();
                clientId = Convert.ToInt32(dgvPTEC.Rows[objPro.rowID].Cells[15].Value.ToString());
                tempPtecId = Convert.ToInt32(dgvPTEC.Rows[objPro.rowID].Cells[16].Value.ToString());
                tempEmployeeName = dgvPTEC.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();

                CLIENTNAME = dgvPTEC.Rows[objPro.rowID].Cells[3].Value.ToString();

                GetClientAddress();
            }

            if (e.ColumnIndex == dgvPTEC.Columns["btnReply"].Index)
            {
                frm_Query query = new frm_Query(tempEmployeeName);

                query.workId = tempPtecId;
                query.role = ROLE;
                query.employeeName = tempEmployeeName;
                query.serviceName = "PTEC/PTRC";
                query.clientName = txtClientName.Text;
                query.taskName = txtTaskName.Text;
                query.ShowDialog();
            }
        }

        #endregion

        #region FUNCTIONS

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
        private void GetClientAddress()
        {
            try
            {
                objPro = new clsProperties();
                client = new cls_ClientsDL();
                ds = new DataSet();

                objPro.search = !string.IsNullOrWhiteSpace(txtTradeName.Text) ? txtTradeName.Text.Trim() : txtClientName.Text.Trim();

                ds = client.getClientAddress(clientId, CLIENTNAME);

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

        private void show()
        {
            ptecDL = new cls_PtecDL();
            ds = new DataSet();

            ds = ptecDL.showData(ROLE, EMPLOYEENAME);

            if (ds.Tables[0].Rows.Count < 0)
            {

            }
            else
            {
                dgvPTEC.DataSource = ds.Tables[0];

                if (ROLE == "User")
                {
                    dgvPTEC.Columns["EMPLOYEENAME"].Visible = false;

                }

                dgvPTEC.Columns["ptecId"].Visible = false;
                dgvPTEC.Columns["p_Fees"].Visible = false;
                dgvPTEC.Columns["clientId"].Visible = false;
                dgvPTEC.Columns["p_RecurringTask"].Visible = false;
                dgvPTEC.Columns["p_Periodicity"].Visible = false;
            }


        }

        private void Clear()
        {
            dtpInputDate.Text = DateTime.Now.ToString();
            txtClientName.Clear();
           txtTaskName.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            dtpDueDate.Text = DateTime.Now.ToString();
            txtYear.Clear();
            txtFees.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;   
            cmbRecurringTask.SelectedIndex = 0;
            txtTradeName.Clear();
            
            btnSave.Enabled = true;
        }

        private void ShowQuery()
        {
            query = new cls_Query();
            ds1 = new DataSet();

            ds1 = query.QueryRaisedByEmp("PTEC/PTRC");

            foreach (DataGridViewRow row in dgvPTEC.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClientName"].Value?.ToString();
                string worktype = row.Cells["WorkType"].Value.ToString();
                string service = "PTEC/PTRC";

                bool hasQuery = ds1.Tables[0].AsEnumerable().Any(r =>
                   r.Field<string>("q_EmpName") == employee &&
                   r.Field<string>("q_ClientName") == client &&
                   r.Field<string>("q_Service") == service &&
                   r.Field<string>("q_TaskName") == worktype &&
                   r.Field<bool>("hasQuery") == true &&
                   r.Field<bool>("isActive") == true
                 );

                row.DefaultCellStyle.BackColor = hasQuery ? Color.LightCoral : dgvPTEC.DefaultCellStyle.BackColor;

            }

        }

        private void ShowReply()
        {
            query = new cls_Query();
            ds2 = new DataSet();

            ds2 = query.showReplyByAdmin("PTEC/PTRC");

            foreach (DataGridViewRow row in dgvPTEC.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClientName"].Value?.ToString();
                string worktype = row.Cells["WorkType"].Value.ToString();
                string service = "PTEC/PTRC";

                bool hasReply = ds2.Tables[0].AsEnumerable().Any(r =>
                   r.Field<string>("q_EmpName") == employee &&
                   r.Field<string>("q_ClientName") == client &&
                   r.Field<string>("q_Service") == service &&
                   r.Field<string>("q_TaskName") == worktype &&
                   r.Field<bool>("isClosed") == true &&
                   r.Field<bool>("isActive") == true
                 );

                row.DefaultCellStyle.BackColor = hasReply ? Color.LightGreen : dgvPTEC.DefaultCellStyle.BackColor;

            }
        }

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
                    tempClientId = Convert.ToInt32(ds.Tables[0].Rows[0]["clientId"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_INCOMETAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(ex.Message.ToString(), "UC_PTEC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                txtClientName.ReadOnly = true;
                txtTradeName.ReadOnly = true;
                txtTaskName.ReadOnly = true;
                txtYear.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtYear.ReadOnly = true;

                cmbWorkStatus.Items.Remove("Filed");

                if (ROLE == "Admin")
                {
                    btnSave.Enabled = true;
                }

            }
        }

        #endregion
    }
}
