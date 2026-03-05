using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Tax_Consultant_25.Frames
{
    public partial class ucGST : UserControl
    {
        public ucGST()
        {
            InitializeComponent();
        }

        #region CLASS & OBJECTS

        public event EventHandler OnCloseFill;

        DataTable dt;
        DataSet ds, ds1, ds2;
        cls_EmployeeDL employeeDL;
        clsProperties objPro;
        cls_GstDL gstDL;
        cls_ClientUserPassDL cls_ClientUserPassDL;
        cls_Query query;
        cls_BusinessDL bus;
        cls_ClientsDL client;

        #endregion

        #region VARIABLES

        string serviceName;
        string prevMonthName;
        string tempEmployeeName, tempClientName, tempClientType, tempReturn, tempTaskName;
        string service, businessName, clientAddress, CLIENTNAME;

        int flag, tempGSTId, tempClientId;

        #endregion

        #region PUBLIC VARIABLES

        public string clientName { get; set; }

        public string workType { get; set; }

        public string gstType { get; set; }

        public string gstNumber { get; set; }

        public int clientId { get; set; }

        public int present { get; set; }

        public string gstUsername { get; set; }

        public string gstPassword { get; set; }

        public string type { get; set; }

        public string Month { get; set; }

        public int clientFilled { get; set; }

        public string ROLE { get; set; }

        public string EMPLOYEENAME { get; set; }

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
                MessageBox.Show(ex.Message.ToString(), "UC_GST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Clear()
        {
            txtClientName.Clear();
            txtTradeName.Clear();
            txtPeriod.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            cmbRecurringTask.SelectedIndex = 0;
            cmbTaskName.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;
            txtPeriod.Clear();
            txtFinancialYear.Clear();

            if (ROLE == "Admin")
            {
                btnSave.Enabled = true;
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
                    }

                    this.txtClientName.AutoCompleteCustomSource = autoList;
                    txtClientName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ChangeMonth()
        {
            DateTime previousMonth = dtpInputDate.Value.AddMonths(-1);

            txtPeriod.Text = previousMonth.ToString("MMMM").ToUpper();
        }

        private void ShowQuery()
        {
            query = new cls_Query();
            ds1 = new DataSet();

            ds1 = query.QueryRaisedByEmp("GST");

            foreach (DataGridViewRow row in dgvGST.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClientName"].Value?.ToString();
                string worktype = row.Cells["WorkType"].Value.ToString();
                string service = "GST";

                bool hasQuery = ds1.Tables[0].AsEnumerable().Any(r =>
                   r.Field<string>("q_EmpName") == employee &&
                   r.Field<string>("q_ClientName") == client &&
                   r.Field<string>("q_Service") == service &&
                   r.Field<string>("q_TaskName") == worktype &&
                   r.Field<bool>("hasQuery") == true &&
                   r.Field<bool>("isActive") == true
                 );

                row.DefaultCellStyle.BackColor = hasQuery ? Color.LightCoral : dgvGST.DefaultCellStyle.BackColor;

            }

        }

        private void ShowReply()
        {
            query = new cls_Query();
            ds2 = new DataSet();

            ds2 = query.showReplyByAdmin("GST");

            foreach (DataGridViewRow row in dgvGST.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClientName"].Value?.ToString();
                string worktype = row.Cells["WorkType"].Value.ToString();
                string service = "GST";

                bool hasReply = ds2.Tables[0].AsEnumerable().Any(r =>
                   r.Field<string>("q_EmpName") == employee &&
                   r.Field<string>("q_ClientName") == client &&
                   r.Field<string>("q_Service") == service &&
                   r.Field<string>("q_TaskName") == worktype &&
                   r.Field<bool>("isClosed") == true &&
                   r.Field<bool>("isActive") == true
                 );

                row.DefaultCellStyle.BackColor = hasReply ? Color.LightGreen : dgvGST.DefaultCellStyle.BackColor;

            }
        }

        private void show()
        {
            try
            {
                gstDL = new cls_GstDL();
                ds = new DataSet();

                ds = gstDL.show(ROLE, EMPLOYEENAME);

                if (ds.Tables[0].Rows.Count >= 0)
                {
                    dgvGST.DataSource = ds.Tables[0];

                    if (ROLE == "User")
                    {
                        dgvGST.Columns["EMPLOYEENAME"].Visible = false;

                    }

                    dgvGST.Columns["gstId"].Visible = false;
                    dgvGST.Columns["clientId"].Visible = false;
                    dgvGST.Columns["clientName"].Visible = false;
                    dgvGST.Columns["g_RecurringTask"].Visible = false;
                    dgvGST.Columns["g_Periodicity"].Visible = false;
                    dgvGST.Columns["g_FinancialYear"].Visible = false;
                    dgvGST.Columns["serial"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
                MessageBox.Show(ex.Message.ToString(), "UC_GST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cmbTaskName.Enabled = false;

                txtClientName.ReadOnly = true;
                txtTradeName.ReadOnly = true;
                txtFinancialYear.ReadOnly = true;

                cmbWorkStatus.Items.Remove("Filed");

                if (ROLE == "Admin")
                {
                    btnSave.Enabled = true;
                }

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
                ColorTranslator.FromHtml("#FFC000"), // Nill
                ColorTranslator.FromHtml("#FFC000"), // Complit
                ColorTranslator.FromHtml("#FFFF00"), // Filed
                ColorTranslator.FromHtml("#FCE4D6")  // Other
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

        private void cmbTaskName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            // Background colors mapped to each GST form
            Color[] bgColors =
            {
                ColorTranslator.FromHtml("#D6DCE4"), // GST R-1
                ColorTranslator.FromHtml("#F4B084"), // GST R-3B
                ColorTranslator.FromHtml("#A9D08E"), // GST R-4
                ColorTranslator.FromHtml("#00B0F0"), // GST R-5
                ColorTranslator.FromHtml("#C6E0B4"), // GST R-5A
                ColorTranslator.FromHtml("#BDD7EE"), // GST R-6
                ColorTranslator.FromHtml("#FFE699"), // GST R-7
                ColorTranslator.FromHtml("#F8CBAD"), // GST R-8
                ColorTranslator.FromHtml("#FFC7CE"), // GST R-9
                ColorTranslator.FromHtml("#FFD966"), // GST R-10
                ColorTranslator.FromHtml("#B4C6E7"), // GST R-11
                ColorTranslator.FromHtml("#E2EFDA"), // CMP-08
                ColorTranslator.FromHtml("#FCE4D6"), // ITC-04
                ColorTranslator.FromHtml("#FFF2CC")  // IFF
             };

            Color backColor = bgColors[e.Index];

            // ⭐ DO NOT darken selected item — keeps DGV-style look
            using (Brush backgroundBrush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

            using (Brush textBrush = new SolidBrush(Color.Black))
                e.Graphics.DrawString(
                    cmbTaskName.Items[e.Index].ToString(),
                    e.Font,
                    textBrush,
                    e.Bounds
                );

            e.DrawFocusRectangle();
        }

        #endregion

        #region EVENTS

        private void ucGST_Load(object sender, EventArgs e)
        {
            ApplyEmployeePermissions();

            BindEmployee();

            cmbAllocatedTo.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            cmbTaskName.SelectedIndex = 0;
            cmbRecurringTask.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;

            BindSearch();

            ChangeMonth();

            show();

            // USER DEFINED EVENTS
            cmbWorkStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbWorkStatus.DrawItem += cmbWorkStatus_DrawItem;

            cmbTaskName.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTaskName.DrawItem += cmbTaskName_DrawItem;
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

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateDates();
        }

        private void dgvGST_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (ROLE == "User")
            {
                foreach (DataGridViewRow row in dgvGST.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }

                    row.Cells["btnReply"].Value = "QUERY";
                    dgvGST.Columns["btnReply"].HeaderText = "QUERY";
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvGST.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }

                    row.Cells["btnReply"].Value = "REPLY";
                    dgvGST.Columns["btnReply"].HeaderText = "REPLY";
                }
            }
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            if (txtClientName.Text == string.Empty)
            {
                txtTradeName.Clear();
            }
        }

        private void txtTradeName_Leave(object sender, EventArgs e)
        {
            SearchClient();  
        }

        private void dtpInputDate_ValueChanged(object sender, EventArgs e)
        {
            ChangeMonth();
            ValidateDates();
        }

        private void txtClientName_Leave(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtClientName.Text == string.Empty)
            {
                MessageBox.Show("Enter Client Name", "GST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPeriod.Text == string.Empty)
            {
                MessageBox.Show("Enter Month", "GST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!ValidateDates())
            {
                return;
            }

            objPro = new clsProperties();

            objPro.clientID = tempClientId;
            objPro.clientName = txtClientName.Text;
            objPro.gstService = "GST";
            objPro.gstInputDate = dtpInputDate.Value;
            objPro.gstTradeName = txtTradeName.Text;
            objPro.gstDueDate = dtpDueDate.Value;
            objPro.gstTaskName = cmbTaskName.Text;
            objPro.gstAllocatedTo = cmbAllocatedTo.Text;
            objPro.gstRecurringTask = cmbRecurringTask.Text;
            objPro.gstPeriodicity = cmbPeriodicity.Text;
            objPro.gstPeriod = txtPeriod.Text;
            objPro.gstFinancialYear = txtFinancialYear.Text;
            objPro.gstStatus = cmbWorkStatus.Text;

            gstDL = new cls_GstDL();
            flag = gstDL.saveData(objPro);

            if (flag >= 1)
            {
                Clear();
                show();
                ChangeMonth();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "GST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPeriod.Text == string.Empty)
                {
                    MessageBox.Show("Enter Month", "GST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(!ValidateDates())
                {
                    return;
                }

                objPro = new clsProperties();

                objPro.clientID = clientId;
                objPro.clientName = txtClientName.Text;
                objPro.gstService = "GST";
                objPro.gstInputDate = dtpInputDate.Value;
                objPro.gstTradeName = txtTradeName.Text;
                objPro.gstDueDate = dtpDueDate.Value;
                objPro.gstTaskName = cmbTaskName.Text;
                objPro.gstAllocatedTo = cmbAllocatedTo.Text;
                objPro.gstRecurringTask = cmbRecurringTask.Text;
                objPro.gstPeriodicity = cmbPeriodicity.Text;
                objPro.gstPeriod = txtPeriod.Text;
                objPro.gstFinancialYear = txtFinancialYear.Text;
                objPro.gstStatus = cmbWorkStatus.Text;
                objPro.gstId = tempGSTId;

                gstDL = new cls_GstDL();
                flag = gstDL.updateData(objPro);

                if (flag >= 1)
                {

                    if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "Filed")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "GST", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dial == DialogResult.Yes)
                        {
                            frm_Narration narr = new frm_Narration();
                            narr.clientName = txtClientName.Text;
                            narr.service = "GST";
                            narr.amount = "";
                            narr.workType = tempTaskName;
                            narr.businessName = businessName;
                            narr.clientAddress = clientAddress;

                            narr.Show();
                        }
                    }

                    Clear();
                    show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_GST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvGST_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
                { "Nill", ColorTranslator.FromHtml("#FFC000") },
                { "Complete", ColorTranslator.FromHtml("#FFC000") },
                { "Filed", ColorTranslator.FromHtml("#FFFF00") },
                { "Other", ColorTranslator.FromHtml("#FCE4D6") }
            };

            if (dgvGST.Columns[e.ColumnIndex].Name == "Status")
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

            #region CHANGE TASK NAME COLORS

            Dictionary<string, Color> GstColors = new Dictionary<string, Color>()
            {
                { "GST R-1",  ColorTranslator.FromHtml("#D6DCE4") },
                { "GST R-3B", ColorTranslator.FromHtml("#F4B084") },
                { "GST R-4",  ColorTranslator.FromHtml("#A9D08E") },
                { "GST R-5",  ColorTranslator.FromHtml("#00B0F0") },
                { "GST R-5A", ColorTranslator.FromHtml("#C6E0B4") },
                { "GST R-6",  ColorTranslator.FromHtml("#BDD7EE") },
                { "GST R-7",  ColorTranslator.FromHtml("#FFE699") },
                { "GST R-8",  ColorTranslator.FromHtml("#F8CBAD") },
                { "GST R-9",  ColorTranslator.FromHtml("#FFC7CE") },
                { "GST R-10", ColorTranslator.FromHtml("#FFD966") },
                { "GST R-11", ColorTranslator.FromHtml("#B4C6E7") },
                { "CMP-08",   ColorTranslator.FromHtml("#E2EFDA") },
                { "ITC-04",   ColorTranslator.FromHtml("#FCE4D6") },
                { "IFF",      ColorTranslator.FromHtml("#FFF2CC") }
            };

            if (dgvGST.Columns[e.ColumnIndex].Name == "TaskName")
            {
                if (e.Value != null)
                {
                    string gst = e.Value.ToString();

                    if (GstColors.ContainsKey(gst))
                    {
                        e.CellStyle.BackColor = GstColors[gst];
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }

            #endregion

            if (dgvGST.Columns[e.ColumnIndex].Name == "btnReply")
            {
                string text = dgvGST.Rows[e.RowIndex].Cells["btnReply"].Value?.ToString();

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

        private void dgvGST_SelectionChanged(object sender, EventArgs e)
        {
            dgvGST.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void dgvGST_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;

                objPro = new clsProperties();

                objPro.rowID = e.RowIndex;

                if (dgvGST.Rows.Count > 0)
                {
                    txtTradeName.Text = dgvGST.Rows[objPro.rowID].Cells[2].Value.ToString();
                    cmbTaskName.Text = dgvGST.Rows[objPro.rowID].Cells[3].Value.ToString().Trim();
                    txtPeriod.Text = dgvGST.Rows[objPro.rowID].Cells[4].Value.ToString().Trim();
                    dtpInputDate.Text = dgvGST.Rows[objPro.rowID].Cells[5].Value.ToString();
                    dtpDueDate.Text = dgvGST.Rows[objPro.rowID].Cells[6].Value.ToString();
                    cmbAllocatedTo.Text = dgvGST.Rows[objPro.rowID].Cells[7].Value.ToString().Trim();
                    cmbRecurringTask.Text = dgvGST.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                    cmbPeriodicity.Text = dgvGST.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                    txtFinancialYear.Text = dgvGST.Rows[objPro.rowID].Cells[10].Value.ToString().Trim();
                    txtClientName.Text = dgvGST.Rows[objPro.rowID].Cells[11].Value.ToString().Trim();
                    cmbWorkStatus.Text = dgvGST.Rows[objPro.rowID].Cells[12].Value.ToString().Trim();
                    tempGSTId = Convert.ToInt32(dgvGST.Rows[objPro.rowID].Cells[13].Value.ToString());
                    clientId = Convert.ToInt32(dgvGST.Rows[objPro.rowID].Cells[14].Value.ToString());
                    tempEmployeeName = dgvGST.Rows[objPro.rowID].Cells[7].Value.ToString().Trim();
                    tempTaskName = dgvGST.Rows[objPro.rowID].Cells[3].Value.ToString().Trim();

                    CLIENTNAME = dgvGST.Rows[objPro.rowID].Cells[11].Value.ToString().Trim();

                    GetClientAddress();
                }

                if (e.ColumnIndex == dgvGST.Columns["btnReply"].Index)
                {
                    frm_Query query = new frm_Query(tempEmployeeName);

                    query.workId = tempGSTId;
                    query.role = ROLE;
                    query.employeeName = tempEmployeeName;
                    query.serviceName = "GST";
                    query.clientName = txtClientName.Text;
                    query.taskName = tempTaskName;
                    query.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_GST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

    }

}
