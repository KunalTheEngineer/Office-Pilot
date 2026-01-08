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
    public partial class ucShopAct : UserControl
    {
        public ucShopAct()
        {
            InitializeComponent();
        }

        CommonUC common;
        DataTable dt;
        DataSet ds, ds1;
        cls_EmployeeDL employeeDL;
        cls_ClientUserPassDL clientUserPassDL;
        cls_ShopActDL shopActDL;
        clsProperties objPro;
        cls_Query query;
        cls_BusinessDL bus;

        int clId, flag, tempShopActId, tempClientId;
        int present = 0;
        string tempEmployeeName, tempClientName, tempWorkType, serviceName, service, businessName, clientAddress;

        private void ucShopAct_Load(object sender, EventArgs e)
        {
            common = new CommonUC();
            pnlMainForm.Controls.Clear();
            common.service = "SHOPACT";
            pnlMainForm.Controls.Add(common);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void dgvShopAct_SelectionChanged(object sender, EventArgs e)
        {
            dgvShopAct.ClearSelection();
        }

        private void dgvShopAct_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowQuery();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkType.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtUname.Text == string.Empty)
                {
                    MessageBox.Show("Enter Username", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPass.Text == string.Empty)
                {
                    MessageBox.Show("Enter Password", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFessAmt.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fess Amount", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                clId = common.clientId;

                objPro.clientID = clId;
                objPro.clientName = txtClientName.Text;
                objPro.shopActService = common.service;
                objPro.shopActInputDate = dtpInputDate.Value;
                objPro.shopActWorktype = txtWorkType.Text;
                objPro.shopActAllocatedEmp = cmbAllocatedTo.Text;
                objPro.shopActDueDate = dtpDueDate.Value;
                objPro.shopActFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.shopActFeeStatus = cmbFeesStatus.Text;
                objPro.shopActStatus = cmbWorkStatus.Text;

                objPro.username = txtUname.Text;
                objPro.password = txtPass.Text;
                objPro.workService = objPro.shopActService;

                shopActDL = new cls_ShopActDL();
                flag = shopActDL.saveData(objPro);

                if(flag == 1)
                {
                    flag = 0;

                    if (present == 0)
                    {
                        clientUserPassDL = new cls_ClientUserPassDL();
                        flag = clientUserPassDL.saveClientUserNamePassword(objPro);
                    }

                    //MessageBox.Show("Record Saved...");

                    common.ClearControls();
                    show();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvShopAct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;

                objPro = new clsProperties();

                objPro.rowID = e.RowIndex;

                if(dgvShopAct.Rows.Count >= 0)
                {
                    dtpInputDate.Text = dgvShopAct.Rows[objPro.rowID].Cells[3].Value.ToString();
                    txtClientName.Text = dgvShopAct.Rows[objPro.rowID].Cells[4].Value.ToString();
                    txtWorkType.Text = dgvShopAct.Rows[objPro.rowID].Cells[5].Value.ToString();
                    cmbAllocatedTo.Text = dgvShopAct.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();
                    dtpDueDate.Text = dgvShopAct.Rows[objPro.rowID].Cells[7].Value.ToString();
                    txtFessAmt.Text = dgvShopAct.Rows[objPro.rowID].Cells[10].Value.ToString();
                    cmbFeesStatus.Text = dgvShopAct.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                    cmbWorkStatus.Text = dgvShopAct.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                    tempShopActId = Convert.ToInt32(dgvShopAct.Rows[objPro.rowID].Cells[11].Value.ToString());
                    tempClientId = Convert.ToInt32(dgvShopAct.Rows[objPro.rowID].Cells[12].Value.ToString());

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

                if (e.ColumnIndex == dgvShopAct.Columns["btnQuery"].Index)
                {
                    frm_Query query = new frm_Query(tempEmployeeName);

                    query.serviceName = serviceName;
                    query.clientName = tempClientName;
                    query.employeeName = tempEmployeeName;
                    query.workTypeName = tempWorkType;

                    query.ShowDialog();
                }

                if (e.ColumnIndex == dgvShopAct.Columns["btnReply"].Index)
                {
                    frm_Query query = new frm_Query(tempEmployeeName);

                    query.serviceName = serviceName;
                    query.clientName = tempClientName;
                    query.employeeName = tempEmployeeName;
                    query.workTypeName = tempWorkType;

                    query.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkType.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtUname.Text == string.Empty)
                {
                    MessageBox.Show("Enter Username", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPass.Text == string.Empty)
                {
                    MessageBox.Show("Enter Password", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFessAmt.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fess Amount", "SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();
                clId = common.clientId;

                objPro.shopActId = tempShopActId;
                objPro.shopActService = common.service;
                objPro.shopActInputDate = dtpInputDate.Value;
                objPro.shopActWorktype = txtWorkType.Text;
                objPro.shopActAllocatedEmp = cmbAllocatedTo.Text;
                objPro.shopActDueDate = dtpDueDate.Value;
                objPro.shopActFees = Convert.ToInt32(txtFessAmt.Text);
                objPro.shopActFeeStatus = cmbFeesStatus.Text;
                objPro.shopActStatus = cmbWorkStatus.Text;

                objPro.clientID = tempClientId;
                objPro.workService = common.service;
                objPro.username = txtUname.Text;
                objPro.password = txtPass.Text;

                shopActDL = new cls_ShopActDL();
                flag = shopActDL.updateData(objPro);

                if(flag == 1)
                {
                    flag = 0;

                    clientUserPassDL = new cls_ClientUserPassDL();
                    flag = clientUserPassDL.updateClientUserNamePassword(objPro);

                    if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "DONE")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "SHOPACT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                    Clear();
                    show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_SHOPACT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Clear()
        {
            dtpInputDate.Text = DateTime.Now.ToString();
            txtClientName.Clear();
            txtWorkType.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            dtpDueDate.Text = DateTime.Now.ToString();
            txtUname.Clear();
            txtPass.Clear();
            txtFessAmt.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

            btnSave.Enabled = true;
        }

        private void show()
        {
            ds = new DataSet();
            shopActDL = new cls_ShopActDL();

            ds = shopActDL.showData();

            if (ds.Tables[0].Rows.Count < 0)
            {

            }
            else
            {
                dgvShopAct.DataSource = ds.Tables[0];

                dgvShopAct.Columns["shopActId"].Visible = false;
                dgvShopAct.Columns["s_Fees"].Visible = false;
                dgvShopAct.Columns["clientId"].Visible = false;
            }

                
        }

        private void ShowQuery()
        {
            query = new cls_Query();
            ds1 = new DataSet();

            ds1 = query.QueryRaisedByEmp();

            foreach (DataGridViewRow row in dgvShopAct.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClientName"].Value?.ToString();
                string workType = row.Cells["WorkType"].Value?.ToString();
                service = "SHOPACT";
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
