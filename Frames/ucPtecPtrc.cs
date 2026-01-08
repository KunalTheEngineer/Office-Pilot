
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

        CommonUC common;
        DataTable dt;
        DataSet ds, ds1;
        cls_EmployeeDL employeeDL;
        clsProperties objPro;
        cls_PtecDL ptecDL;
        cls_ClientUserPassDL clientUserPassDL;
        cls_Query query;
        cls_BusinessDL bus;

        int clId, flag, tempPtecId, tempClientId;
        int present = 0;
        string tempEmployeeName, tempClientName, tempWorkType, serviceName, service, businessName, clientAddress; 

        private void ucPtecPtrc_Load(object sender, EventArgs e)
        {
            common = new CommonUC();
            pnlPtrec.Controls.Clear();
            common.service = "PTEC / PTRC";
            pnlPtrec.Controls.Add(common);

            BindEmployee();
            show();
            serviceName = common.service;
            
            common.FormDataInfo += CommonUC_FormDataInfo;

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
                MessageBox.Show(ex.Message.ToString(), "UC_PTEC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CommonUC_FormDataInfo(object sender, FormDataInfoEventArgs e)
        {
            if (e.Username != string.Empty && e.Password != string.Empty)
            {
                present = 1;
            }

            txtClientName.Text = e.clientName;
            txtUname.Text = e.Username;
            txtPass.Text = e.Password;
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

                if (txtWorkType.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtYear.Text == string.Empty)
                {
                    MessageBox.Show("Enter Year", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (txtPtecNo.Text == string.Empty)
                //{
                //    MessageBox.Show("Enter PTEC / PTRC NUMBER", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                if (txtUname.Text == string.Empty)
                {
                    MessageBox.Show("Enter Username", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPass.Text == string.Empty)
                {
                    MessageBox.Show("Enter Password", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFessAmt.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fess Amount", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                clId = common.clientId;

                objPro.ptecId = tempPtecId;
                objPro.clientID = clId;
                objPro.clientName = txtClientName.Text;
                objPro.ptecService = common.service;
                objPro.ptecInputDate = dtpInputDate.Value;
                objPro.ptecWorktype = txtWorkType.Text;
                objPro.ptecAllocatedEmp = cmbAllocatedTo.Text;
                objPro.ptecDueDate = dtpDueDate.Value;
                objPro.ptecYear = txtYear.Text;
                objPro.ptecNo = txtPtecNo.Text;
                objPro.ptecFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.ptecFeeStatus = cmbFeesStatus.Text;
                objPro.ptecStatus = cmbWorkStatus.Text;

                objPro.workService = objPro.ptecService;
                objPro.clientID = tempClientId;
                objPro.username = txtUname.Text;
                objPro.password = txtPass.Text;

                ptecDL = new cls_PtecDL();
                flag = ptecDL.updateData(objPro);

                if (flag == 1)
                {
                    flag = 0;

                    clientUserPassDL = new cls_ClientUserPassDL();
                    flag = clientUserPassDL.updateClientUserNamePassword(objPro);

                    if(cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "DONE")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "PTEC/PTRC", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                    common.ClearControls();
                    show();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_PTEC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvPTEC_SelectionChanged(object sender, EventArgs e)
        {
            dgvPTEC.ClearSelection();
        }

        private void dgvPTEC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowQuery();
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

                if (txtWorkType.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtYear.Text == string.Empty)
                {
                    MessageBox.Show("Enter Year", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (txtPtecNo.Text == string.Empty)
                //{
                //    MessageBox.Show("Enter PTEC / PTRC NUMBER", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                if (txtUname.Text == string.Empty)
                {
                    MessageBox.Show("Enter Username", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPass.Text == string.Empty)
                {
                    MessageBox.Show("Enter Password", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFessAmt.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fess Amount", "PTEC / PTRC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                objPro = new clsProperties();

                clId = common.clientId;

                objPro.clientID = clId;
                objPro.clientName = txtClientName.Text;
                objPro.ptecService = common.service;
                objPro.ptecInputDate = dtpInputDate.Value;
                objPro.ptecWorktype = txtWorkType.Text;
                objPro.ptecAllocatedEmp = cmbAllocatedTo.Text;
                objPro.ptecDueDate = dtpDueDate.Value;
                objPro.ptecYear = txtYear.Text;
                objPro.ptecNo = txtPtecNo.Text;
                objPro.ptecFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.ptecFeeStatus = cmbFeesStatus.Text;
                objPro.ptecStatus = cmbWorkStatus.Text;

                objPro.username = txtUname.Text;
                objPro.password = txtPass.Text;
                objPro.workService = objPro.ptecService;

                ptecDL = new cls_PtecDL();
                flag = ptecDL.saveData(objPro);

                if(flag == 1)
                {
                    flag = 0;

                    clientUserPassDL = new cls_ClientUserPassDL();
                    flag = clientUserPassDL.saveClientUserNamePassword(objPro);

                    //MessageBox.Show("Record Saved...");

                    common.ClearControls();
                    show();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_PTEC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void dgvPTEC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            objPro = new clsProperties();

            objPro.rowID = e.RowIndex;

            if (dgvPTEC.Rows.Count > 0)
            {
                dtpInputDate.Text = dgvPTEC.Rows[objPro.rowID].Cells[3].Value.ToString();
                txtClientName.Text = dgvPTEC.Rows[objPro.rowID].Cells[4].Value.ToString();
                txtWorkType.Text = dgvPTEC.Rows[objPro.rowID].Cells[5].Value.ToString();
                cmbAllocatedTo.Text = dgvPTEC.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();
                dtpDueDate.Text = dgvPTEC.Rows[objPro.rowID].Cells[7].Value.ToString();
                cmbWorkStatus.Text = dgvPTEC.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                cmbFeesStatus.Text = dgvPTEC.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                txtYear.Text = dgvPTEC.Rows[objPro.rowID].Cells[10].Value.ToString();
                txtFessAmt.Text = dgvPTEC.Rows[objPro.rowID].Cells[11].Value.ToString();
                txtPtecNo.Text = dgvPTEC.Rows[objPro.rowID].Cells[12].Value.ToString();
                tempPtecId = Convert.ToInt32(dgvPTEC.Rows[objPro.rowID].Cells[13].Value.ToString());
                tempClientId = Convert.ToInt32(dgvPTEC.Rows[objPro.rowID].Cells[14].Value.ToString());

                objPro.workService = common.service;

                tempEmployeeName = cmbAllocatedTo.Text;
                tempClientName = txtClientName.Text;
                tempWorkType = txtWorkType.Text;
                objPro.clientID = tempClientId;

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

            if (e.ColumnIndex == dgvPTEC.Columns["btnQuery"].Index)
            {
                frm_Query query = new frm_Query(tempEmployeeName);

                query.serviceName = serviceName;
                query.clientName = tempClientName;
                query.employeeName = tempEmployeeName;
                query.workTypeName = tempWorkType;

                query.ShowDialog();
            }

            if (e.ColumnIndex == dgvPTEC.Columns["btnReply"].Index)
            {
                frm_Query query = new frm_Query(tempEmployeeName);

                query.serviceName = serviceName;
                query.clientName = tempClientName;
                query.employeeName = tempEmployeeName;
                query.workTypeName = tempWorkType;

                query.ShowDialog();
            }
        }

        private void show()
        {
            ptecDL = new cls_PtecDL();
            ds = new DataSet();

            ds = ptecDL.showData();

            if (ds.Tables[0].Rows.Count < 0)
            {

            }
            else
            {
                dgvPTEC.DataSource = ds.Tables[0];
                dgvPTEC.Columns["ptecId"].Visible = false;
                dgvPTEC.Columns["p_Year"].Visible = false;
                dgvPTEC.Columns["p_Fees"].Visible = false;
                dgvPTEC.Columns["clientId"].Visible = false;
                dgvPTEC.Columns["p_PtecPtrcNo"].Visible = false;
            }

               
        }

        private void showClientUsernamePasswordOnDGVClick()
        {
            ds = null;

            ds = new DataSet();
            clientUserPassDL = new cls_ClientUserPassDL();
            ds = clientUserPassDL.getClientUsernamePasword(objPro);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtUname.Text = ds.Tables[0].Rows[0]["clientUsername"].ToString();
                txtPass.Text = ds.Tables[0].Rows[0]["clientPassword"].ToString();
            }
        }

        private void Clear()
        {
            dtpInputDate.Text = DateTime.Now.ToString();
            txtClientName.Clear();
            txtWorkType.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            dtpDueDate.Text = DateTime.Now.ToString();
            txtYear.Clear();
            txtPtecNo.Clear();
            txtUname.Clear();
            txtPass.Clear();
            txtFessAmt.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

            btnSave.Enabled = true;
        }

        private void ShowQuery()
        {
            query = new cls_Query();
            ds1 = new DataSet();

            ds1 = query.QueryRaisedByEmp();

            foreach (DataGridViewRow row in dgvPTEC.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClientName"].Value?.ToString();
                string workType = row.Cells["WorkType"].Value?.ToString();
                service = "PTEC / PTRC";
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
