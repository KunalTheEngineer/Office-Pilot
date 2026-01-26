using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25.Frames
{
    public partial class ucPAN : UserControl
    {
        public ucPAN()
        {
            InitializeComponent();
        }

        CommonUC common;
        DataTable dt;
        DataSet ds, ds1;
        cls_EmployeeDL employeeDL;
        cls_PanDL panDL;
        clsProperties objPro;
        cls_Query query;
        cls_BusinessDL bus;

        int clId, flag, panId, tempClientId;
        string tempEmployeeName, tempWorkType, serviceName, tempClientName, service, businessName, clientAddress;

        private void ucPAN_Load(object sender, EventArgs e)
        {

            BindEmployee();
            show();

            cmbAllocatedTo.SelectedIndex = 0;
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

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
                MessageBox.Show(ex.Message.ToString(), "UC_PAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvAllInOne_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "PAN TAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "PAN TAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                

                if (txtFees.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fees Amount", "PAN TAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                objPro.panId = panId;
                objPro.clientName = txtClientName.Text;
                objPro.panService = common.service;
                objPro.panInputDate = dtpInputDate.Value;
                objPro.panWorkType = txtWorkType.Text;
                objPro.panAllocatedEmp = cmbAllocatedTo.Text;
                objPro.panDueDate = dtpDueDate.Value;
                objPro.panTanNo = txtPANNo.Text;
                objPro.panFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.panFeeStatus = cmbFeesStatus.Text;
                objPro.panStatus = cmbWorkStatus.Text;

                panDL = new cls_PanDL();
                flag = panDL.updateData(objPro);

                if (flag == 1)
                {
                    if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "DONE")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "PAN/TAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                    //MessageBox.Show("Record Updated...");
                    show();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_PAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgvAllInOne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            objPro = new clsProperties();

            objPro.rowID = e.RowIndex;

            //if (dgvAllInOne.Rows.Count > 0)
            //{
            //    dtpInputDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[3].Value.ToString();
            //    txtClientName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[4].Value.ToString();
            //    txtWorkType.Text = dgvAllInOne.Rows[objPro.rowID].Cells[5].Value.ToString();
            //    cmbAllocatedTo.Text = dgvAllInOne.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();
            //    dtpDueDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[7].Value.ToString();
            //    cmbFeesStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
            //    cmbWorkStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
            //    panId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[10].Value.ToString());
            //    txtPANNo.Text = dgvAllInOne.Rows[objPro.rowID].Cells[11].Value.ToString();
            //    txtFessAmt.Text = dgvAllInOne.Rows[objPro.rowID].Cells[12].Value.ToString();
            //    tempClientId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[13].Value.ToString());

            //    tempEmployeeName = cmbAllocatedTo.Text;
            //    tempClientName = txtClientName.Text;
            //    tempWorkType = txtWorkType.Text;

            //    bus = new cls_BusinessDL();
            //    ds = new DataSet();

            //    ds = bus.getBusinessName(tempClientName, tempClientId);

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        businessName = ds.Tables[0].Rows[0]["c_BusinessName"].ToString();
            //        clientAddress = ds.Tables[0].Rows[0]["c_Address"].ToString();
            //    }
            //}

            //if (e.ColumnIndex == dgvAllInOne.Columns["btnQuery"].Index)
            //{
            //    frm_Query query = new frm_Query(tempEmployeeName);

            //    query.serviceName = serviceName;
            //    query.clientName = tempClientName;
            //    query.employeeName = tempEmployeeName;
            //    query.workTypeName = tempWorkType;

            //    query.ShowDialog();
            //}

            //if (e.ColumnIndex == dgvAllInOne.Columns["btnReply"].Index)
            //{
            //    frm_Query query = new frm_Query(tempEmployeeName);

            //    query.serviceName = serviceName;
            //    query.clientName = tempClientName;
            //    query.employeeName = tempEmployeeName;
            //    query.workTypeName = tempWorkType;

            //    query.ShowDialog();
            //}
        }

        private void dgvAllInOne_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowQuery();
        }

        private void dgvAllInOne_SelectionChanged(object sender, EventArgs e)
        {
            dgvAllInOne.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "PAN TAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "PAN TAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFees.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fees Amount", "PAN TAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                clId = common.clientId;

                objPro.clientID = tempClientId;
                objPro.clientName = txtClientName.Text;
                objPro.panTradeName = txtTradeName.Text;
                objPro.panInputDate = dtpInputDate.Value;
                objPro.panTaskName = txtTaskName.Text;
                objPro.panAllocatedEmp = cmbAllocatedTo.Text;
                objPro.panDueDate = dtpDueDate.Value;
                objPro.panFees = Convert.ToInt32(txtFees.Text);
                objPro.panFeeStatus = cmbFeesStatus.Text;
                objPro.panStatus = cmbWorkStatus.Text;
                objPro.panDescription = txtDescription.Text;

                panDL = new cls_PanDL();
                flag = panDL.saveData(objPro);

                if (flag == 1)
                {
                    show();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_PAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void show()
        {

            try
            {
                panDL = new cls_PanDL();
                ds = new DataSet();

                ds = panDL.ShowData();

                if (ds.Tables[0].Rows.Count < 0)
                {
                    
                }
                else
                {
                    dgvAllInOne.DataSource = ds.Tables[0];
                    dgvAllInOne.Columns["panId"].Visible = false;
                    dgvAllInOne.Columns["p_PanTanNo"].Visible = false;
                    dgvAllInOne.Columns["p_Fees"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_PAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Clear()
        {
            dtpInputDate.Text = DateTime.Now.ToString();
            txtClientName.Clear();
            txtWorkType.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            dtpDueDate.Text = DateTime.Now.ToString();
            txtPANNo.Clear();
            txtFessAmt.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

            common.ClearControls();
        }

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
                string workType = row.Cells["WorkType"].Value?.ToString();
                service = "PAN / TAN";
                var queryRow = ds1.Tables[0].AsEnumerable().FirstOrDefault(r =>
                   r.Field<string>("EmployeeName") == employee &&
                   r.Field<string>("clientName") == client &&
                   r.Field<string>("service") == service &&
                    r.Field<string>("workType") == workType
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

                row.DefaultCellStyle.BackColor = hasQuery ? Color.Red : DefaultBackColor;

            }
        }
    }
}
