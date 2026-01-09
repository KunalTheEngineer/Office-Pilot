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

        #endregion

        private void ucAllInOne_Load(object sender, EventArgs e)
        {

            BindEmployee();
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
                if(txtClientName.Text == string.Empty)
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

                objPro = new clsProperties();

                clId = common.clientId;

                objPro.clientID = clId;
                objPro.incomeInputDate = dtpInputDate.Value;
                objPro.clientName = txtClientName.Text;
                objPro.incomeService = common.service;
                objPro.incomeWorkType = txtTaskName.Text;
                objPro.incomeAllocatedEmpName = cmbAllocatedTo.Text;
                objPro.incomeDueDate = dtpDueDate.Value;
                objPro.incomeTypeOfReturn = txtReturn.Text;
                objPro.incomeYear = txtYear.Text;
                objPro.incomeFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.incomeFeeStatus = cmbFeesStatus.Text;
                objPro.incomeStatus = cmbWorkStatus.Text;

               

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
                    txtTaskName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[5].Value.ToString();
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
                    tempWorkType = txtTaskName.Text;
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

                objPro = new clsProperties();

                objPro.incomeInputDate = dtpInputDate.Value;
                objPro.clientName = txtClientName.Text;
                objPro.incomeWorkType = txtTaskName.Text;
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
                            narr.workType = txtTaskName.Text;
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
            //query = new cls_Query();
            //ds1 = new DataSet();

            //ds1 = query.QueryRaisedByEmp();

            //foreach (DataGridViewRow row in dgvAllInOne.Rows)
            //{
            //    if (row.IsNewRow)
            //        continue;

            //    string employee = row.Cells["EmployeeName"].Value?.ToString();
            //    string client = row.Cells["ClientName"].Value?.ToString();
            //    string service = "INCOME TAX";
            //    string workType = row.Cells["WorkType"].Value?.ToString();

            //    var hasQuery = ds1.Tables[0].AsEnumerable().FirstOrDefault(r =>
            //       r.Field<string>("EmployeeName") == employee &&
            //       r.Field<string>("clientName") == client &&
            //       r.Field<string>("service") == service &&
            //        r.Field<string>("workType") == workType
            //     //&&   
            //     //!string.IsNullOrEmpty(r.Field<string>("queryByEmp"))
            //     );


            //    if (hasQuery != null && hasQuery.Field<int>("HasQuery") == 1)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.Red;
            //    }
            //    else
            //    {
            //        row.DefaultCellStyle.BackColor = DefaultBackColor;
            //    }
            //}
        }

        private void Clear()
        {

            //MAIN FORM

            dtpInputDate.Text = DateTime.Now.ToString();
            txtClientName.Clear();
            txtTaskName.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            dtpDueDate.Text = DateTime.Now.ToString();
            txtReturn.Clear();
            txtYear.Clear();

            txtFessAmt.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

            btnSave.Enabled = true;

            present = 0;
        }

        private void lblFeesAMT_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

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
