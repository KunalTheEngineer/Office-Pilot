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
        int clId, flag, tempAccId, tempClientId;
        string service, businessName, clientAddress;
        #endregion

        #region Class and Objects
        DataTable dt;
        DataSet ds, ds1;
        cls_EmployeeDL employeeDL;
        clsProperties objPro;
        cls_AccountingDL accountingDL;
        cls_Query query;
        cls_BusinessDL bus;
        private CommonUC common;
        #endregion

        private void ucAccounting_Load(object sender, EventArgs e)
        {
            common = new CommonUC();
            pnlAccounting.Controls.Clear();
            common.service = "ACCOUNTING";
            pnlAccounting.Controls.Add(common);

            common.FormDataInfo += CommonUC_FormDataInfo;
            serviceName = common.service;

            BindEmployee();
            show();

            cmbAllocatedTo.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

        }

        private void CommonUC_FormDataInfo(object sender, FormDataInfoEventArgs e)
        {
            txtClientName.Text = e.clientName;
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

                if (txtWorkType.Text == string.Empty)
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

                clId = common.clientId;

                objPro.clientID = clId;
                objPro.clientName = txtClientName.Text;
                objPro.accountService = common.service;
                objPro.accountInputDate = dtpInputDate.Value;
                objPro.accountWorktype = txtWorkType.Text;
                objPro.accountAllocatedEmp = cmbAllocatedTo.Text;
                objPro.accountDueDate = dtpDueDate.Value;
                objPro.accountWorkPeriod = txtWorkPeriod.Text;
                objPro.accountStatus = cmbWorkStatus.Text;
                objPro.accountYear = txtYear.Text;

                accountingDL = new cls_AccountingDL();
                flag = accountingDL.saveData(objPro);

                if (flag == 1)
                {
                    //MessageBox.Show("Record Saved...");
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

                if (txtWorkType.Text == string.Empty)
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
                objPro.accountInputDate = dtpInputDate.Value;
                objPro.accountWorktype = txtWorkType.Text;
                objPro.accountAllocatedEmp = cmbAllocatedTo.Text;
                objPro.accountDueDate = dtpDueDate.Value;
                objPro.accountWorkPeriod = txtWorkPeriod.Text;
                objPro.accountStatus = cmbWorkStatus.Text;
                objPro.accountYear = txtYear.Text;

                accountingDL = new cls_AccountingDL();
                flag = accountingDL.updateData(objPro);

                if (flag == 1)
                {

                    if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "DONE")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "ACCOUNTING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dial == DialogResult.Yes)
                        {
                            frm_Narration narr = new frm_Narration();
                            narr.clientName = txtClientName.Text;
                            narr.service = common.service;
                            narr.amount = "";
                            narr.workType = txtWorkType.Text;
                            narr.businessName = businessName;
                            narr.clientAddress = clientAddress;

                            narr.Show();
                        }
                    }

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void dgvAllInOne_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowQuery();
        }

        private void txtWorkType_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvAllInOne_SelectionChanged(object sender, EventArgs e)
        {
            dgvAllInOne.ClearSelection();
        }

        private void dgvAllInOne_CellClick(object sender, DataGridViewCellEventArgs e)
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
                txtWorkPeriod.Text = dgvAllInOne.Rows[objPro.rowID].Cells[8].Value.ToString();
                cmbWorkStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                tempAccId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[10].Value.ToString());
                txtYear.Text = dgvAllInOne.Rows[objPro.rowID].Cells[11].Value.ToString();
                tempClientId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[12].Value.ToString());

                tempEmployeeName = cmbAllocatedTo.Text;
                tempClientName = txtClientName.Text;
                tempWorkType = txtWorkType.Text;

                bus = new cls_BusinessDL();
                ds = new DataSet();

                ds = bus.getBusinessName(tempClientName, tempClientId);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    businessName = ds.Tables[0].Rows[0]["c_BusinessName"].ToString();
                    clientAddress = ds.Tables[0].Rows[0]["c_Address"].ToString();
                }
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
                string worktype = row.Cells["WorkType"].Value.ToString();

                service = "ACCOUNTING";
                var queryRow = ds1.Tables[0].AsEnumerable().FirstOrDefault(r =>
                   r.Field<string>("EmployeeName") == employee &&
                   r.Field<string>("clientName") == client &&
                   r.Field<string>("service") == service &&
                   r.Field<string>("workType") == worktype
                 //&&
                 //!string.IsNullOrEmpty(r.Field<string>("queryByEmp"))
                 );


                bool hasQuery = false;

                if (queryRow != null)
                {
                    object val = queryRow["HasQuery"];

                    if (val != DBNull.Value && int.TryParse(val.ToString(), out int parsed))
                    {
                        hasQuery = parsed == 1;
                    }
                }

                // row.DefaultCellStyle.BackColor = hasQuery ? Color.OrangeRed : DefaultBackColor;
                row.Cells["btnQuery"].Style.BackColor = hasQuery ? Color.Crimson : DefaultBackColor;
               // row.Cells["btnQuery"].Style.ForeColor = Color.White;
                //if(hasQuery)
                //{
                //    DataGridViewCell buttonCell = row.Cells["btnQuery"];
                //    buttonCell.Style.BackColor = Color.Red;
                //    buttonCell.Style.ForeColor = Color.Black;
                //}
            }
        }

        private void Clear()
        {
            dtpInputDate.Text = DateTime.Now.ToString();
            txtClientName.Clear();
            txtWorkType.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            dtpDueDate.Text = DateTime.Now.ToString();
            txtWorkPeriod.Clear();
            cmbWorkStatus.SelectedIndex = 0;
            txtYear.Clear();

            btnSave.Enabled = true;

            common.ClearControls();

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
                    dgvAllInOne.Columns["a_Year"].Visible = false;
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
