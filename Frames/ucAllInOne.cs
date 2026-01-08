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

        private CommonUC common;

        DataSet ds, ds1;
        DataTable dt;
        cls_ClientsDL clients;
        clsProperties objPro;
        cls_ClientUserPassDL user;
        cls_IncomeTaxDL incomeTaxDL;
        cls_EmployeeDL employeeDL;
        cls_Query query;
        cls_BusinessDL bus;

        #endregion

        #region VARIABLES

        int flag = 0;
        int clId = 0;
        int tempIncomeId = 0;
        int tempClientId = 0;
        int present = 0;

        string tempEmployeeName;
        string serviceName;
        string tempWorkType;
        string tempClientName, businessName, clientAddress;

        #endregion

        private void ucAllInOne_Load(object sender, EventArgs e)
        {
            common = new CommonUC();
            pnlMainForm.Controls.Clear();
            common.service = "INCOME TAX";
            pnlMainForm.Controls.Add(common);

            common.FormDataInfo += CommonUC_FormDataInfo;
            serviceName = common.service;

            BindEmployee();
            show();

            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            //cmbQueryEmp.SelectedIndex = 0;
            //cmbQuerySol.SelectedIndex = 0;
        }

        private void CommonUC_FormDataInfo(object sender, FormDataInfoEventArgs e)
        {
            if(e.Username != string.Empty && e.Password != string.Empty)
            {
                present = 1;
            }

            txtClientName.Text = e.clientName;
            txtUname.Text = e.Username;
            txtPass.Text = e.Password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkType.Text == string.Empty)
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

                if (txtUname.Text == string.Empty)
                {
                    MessageBox.Show("Enter UserName", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPass.Text == string.Empty)
                {
                    MessageBox.Show("Enter Password", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFessAmt.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fees Amount", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                clId = common.clientId;

                objPro.clientID = clId;
                objPro.incomeInputDate = dtpInputDate.Value;
                objPro.clientName = txtClientName.Text;
                objPro.incomeService = common.service;
                objPro.incomeWorkType = txtWorkType.Text;
                objPro.incomeAllocatedEmpName = cmbAllocatedTo.Text;
                objPro.incomeDueDate = dtpDueDate.Value;
                objPro.incomeTypeOfReturn = txtReturn.Text;
                objPro.incomeYear = txtYear.Text;
                objPro.incomeFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.incomeFeeStatus = cmbFeesStatus.Text;
                objPro.incomeStatus = cmbWorkStatus.Text;

                objPro.username = txtUname.Text;
                objPro.password = txtPass.Text;
                objPro.workService = common.service;

                flag = incomeTaxDL.saveData(objPro);

                if (flag == 1)
                {
                    if(present == 0)
                    {
                        user = new cls_ClientUserPassDL();

                        user.saveClientUserNamePassword(objPro);
                    }

                    //MessageBox.Show("Record Saved...");
                    Clear();
                    show();
                    common.ClearControls();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    dtpInputDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[3].Value.ToString();
                    txtClientName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[4].Value.ToString();
                    txtWorkType.Text = dgvAllInOne.Rows[objPro.rowID].Cells[5].Value.ToString();
                    cmbAllocatedTo.Text = dgvAllInOne.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();
                    dtpDueDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[7].Value.ToString();
                    cmbWorkStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                    cmbFeesStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                    txtReturn.Text = dgvAllInOne.Rows[objPro.rowID].Cells[10].Value.ToString();
                    txtYear.Text = dgvAllInOne.Rows[objPro.rowID].Cells[11].Value.ToString();
                    txtFessAmt.Text = dgvAllInOne.Rows[objPro.rowID].Cells[12].Value.ToString();
                    tempClientId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[13].Value.ToString());
                    tempIncomeId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[14].Value.ToString());

                    objPro.clientID = tempClientId;
                    objPro.workService = common.service;
                    objPro.incomeId = tempIncomeId;

                    tempEmployeeName = cmbAllocatedTo.Text;
                    tempWorkType = txtWorkType.Text;
                    tempClientName = txtClientName.Text;

                    bus = new cls_BusinessDL();
                    ds = new DataSet();

                    ds = bus.getBusinessName(tempClientName, tempClientId);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        businessName = ds.Tables[0].Rows[0]["c_BusinessName"].ToString();
                        clientAddress = ds.Tables[0].Rows[0]["c_Address"].ToString();
                    }

                    showClientUsernamePasswordOnDGVClick();
                }


                if (e.ColumnIndex == dgvAllInOne.Columns["btnQuery"].Index)
                {
                    frm_Query query = new frm_Query(tempEmployeeName);

                    query.employeeName = tempEmployeeName;
                    query.serviceName = serviceName;
                    query.clientName = tempClientName;
                    query.workTypeName = tempWorkType;

                    query.ShowDialog();
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

                if (txtWorkType.Text == string.Empty)
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

                if (txtUname.Text == string.Empty)
                {
                    MessageBox.Show("Enter UserName", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPass.Text == string.Empty)
                {
                    MessageBox.Show("Enter Password", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFessAmt.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fees Amount", "INCOME TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                objPro.incomeInputDate = dtpInputDate.Value;
                objPro.clientName = txtClientName.Text;
                objPro.incomeWorkType = txtWorkType.Text;
                objPro.incomeAllocatedEmpName = cmbAllocatedTo.Text;
                objPro.incomeDueDate = dtpDueDate.Value;
                objPro.incomeTypeOfReturn = txtReturn.Text;
                objPro.incomeYear = txtYear.Text;
                objPro.incomeFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.incomeFeeStatus = cmbFeesStatus.Text;
                objPro.incomeStatus = cmbWorkStatus.Text;
                objPro.incomeId = tempIncomeId;

                objPro.clientID = tempClientId;
                objPro.workService = common.service;
                objPro.username = txtUname.Text;
                objPro.password = txtPass.Text;

                incomeTaxDL = new cls_IncomeTaxDL();
                flag = incomeTaxDL.updateData(objPro);

                if (flag == 1)
                {

                    flag = 0;

                    user = new cls_ClientUserPassDL();
                    flag = user.updateClientUserNamePassword(objPro);
                    //MessageBox.Show("Record Updated...");

                    if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "FILED")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "INCOME TAX", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dial == DialogResult.Yes)
                        {
                            frm_Narration narr = new frm_Narration();
                            narr.clientName = txtClientName.Text;
                            narr.service = common.service;
                            narr.amount = txtFessAmt.Text;
                            narr.workType = txtWorkType.Text;
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
                MessageBox.Show(ex.Message.ToString(), "UC_INCOME_TAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvAllInOne_SelectionChanged(object sender, EventArgs e)
        {
            dgvAllInOne.ClearSelection();
        }

        private void dgvAllInOne_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowQuery();
        }

        #region FUNCTIONS

        private void ShowQuery()
        {
            query = new cls_Query();
            ds1 = new DataSet();

            ds1 = query.QueryRaisedByEmp();

            foreach (DataGridViewRow row in dgvAllInOne.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClientName"].Value?.ToString();
                string service = "INCOME TAX";
                string workType = row.Cells["WorkType"].Value?.ToString();

                var hasQuery = ds1.Tables[0].AsEnumerable().FirstOrDefault(r =>
                   r.Field<string>("EmployeeName") == employee &&
                   r.Field<string>("clientName") == client &&
                   r.Field<string>("service") == service &&
                    r.Field<string>("workType") == workType
                 //&&   
                 //!string.IsNullOrEmpty(r.Field<string>("queryByEmp"))
                 );


                if (hasQuery != null && hasQuery.Field<int>("HasQuery") == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = DefaultBackColor;
                }
            }
        }

        private void Clear()
        {

            //MAIN FORM

            dtpInputDate.Text = DateTime.Now.ToString();
            txtClientName.Clear();
            txtWorkType.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            dtpDueDate.Text = DateTime.Now.ToString();
            txtReturn.Clear();
            txtYear.Clear();
            txtUname.Clear();
            txtPass.Clear();
            txtFessAmt.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

            btnSave.Enabled = true;

            present = 0;
        }

        private void show()
        {
            try
            {
                incomeTaxDL = new cls_IncomeTaxDL();
                ds = new DataSet();

                ds = incomeTaxDL.ShowData();

                if (ds.Tables[0].Rows.Count >= 0)
                {
                    dgvAllInOne.DataSource = ds.Tables[0];
                    dgvAllInOne.Columns["i_TypeOfReturn"].Visible = false;
                    dgvAllInOne.Columns["i_Year"].Visible = false;
                    dgvAllInOne.Columns["i_Fees"].Visible = false;
                    dgvAllInOne.Columns["clientId"].Visible = false;
                    dgvAllInOne.Columns["incomeId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showClientUsernamePasswordOnDGVClick()
        {
            ds = null;

            ds = new DataSet();
            user = new cls_ClientUserPassDL();
            ds = user.getClientUsernamePasword(objPro);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtUname.Text = ds.Tables[0].Rows[0]["clientUsername"].ToString();
                txtPass.Text = ds.Tables[0].Rows[0]["clientPassword"].ToString();
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
