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
    public partial class ucTDS : UserControl
    {
        public ucTDS()
        {
            InitializeComponent();
        }

        CommonUC common;
        clsProperties objPro;
        DataTable dt;
        cls_EmployeeDL employeeDL;
        cls_TdsDL cls_TdsDL;
        cls_ClientUserPassDL clientUserPassDL;
        DataSet ds, ds1;
        cls_Query query;
        cls_BusinessDL bus;
      
        int flag, clId, tempTdsId, tempClientId;
        string tempEmployeeName, tempClientName, tempWorkType, serviceName, service, businessName, clientAddress;
        int present = 0;

        private void ucTDS_Load(object sender, EventArgs e)
        {
            common = new CommonUC();
            pnlMainForm.Controls.Clear();
            common.service = "TDS";
            pnlMainForm.Controls.Add(common);

            BindEmployee();
            show();
            serviceName = common.service;

            common.FormDataInfo += CommonUC_FormDataInfo;

            cmbAllocatedTo.SelectedIndex = 0;
            cmbPeriod.SelectedIndex = 0;
            cmbFilingSt.SelectedIndex = 0;
            
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkType.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtUname.Text == string.Empty)
                {
                    MessageBox.Show("Enter Username", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPass.Text == string.Empty)
                {
                    MessageBox.Show("Enter Password", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtYear.Text == string.Empty)
                {
                    MessageBox.Show("Enter Year", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                clId = common.clientId;

                objPro.clientID = clId;
                objPro.clientName = txtClientName.Text;
                objPro.tdsService = common.service;
                objPro.tdsInputDate = dtpInputDate.Value;
                objPro.tdsWorktype = txtWorkType.Text;
                objPro.tdsAllocatedEmp = cmbAllocatedTo.Text;
                objPro.tdsDueDate = dtpDueDate.Value;
                objPro.tdsYear = txtYear.Text;
                objPro.tdsPeriod = cmbPeriod.Text;
                objPro.tdsStatus = cmbFilingSt.Text;

                objPro.username = txtUname.Text;
                objPro.password = txtPass.Text; 
                objPro.workService = common.service;

                cls_TdsDL = new cls_TdsDL();
                flag = cls_TdsDL.saveData(objPro);

                if(flag == 1)
                {
                    flag = 0;

                    if(present == 0)
                    {
                        clientUserPassDL = new cls_ClientUserPassDL();
                        flag = clientUserPassDL.saveClientUserNamePassword(objPro);
                    }

                    //MessageBox.Show("Record Saved...");

                    common.ClearControls();
                    Clear();
                    show();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvTDS_SelectionChanged(object sender, EventArgs e)
        {
            dgvTDS.ClearSelection();
        }

        private void dgvTDS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowQuery();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void Clear()
        {
            dtpInputDate.Text = DateTime.Now.ToString();
            txtClientName.Clear();
            txtWorkType.Clear();
            cmbAllocatedTo.SelectedIndex = 0;   
            dtpDueDate.Text = DateTime.Now.ToString();
            txtYear.Clear();
            txtUname.Clear();
            txtPass.Clear();
            cmbPeriod.SelectedIndex = 0;
            cmbFilingSt.SelectedIndex = 0;

            btnSave.Enabled = true;
        }

        private void dgvTDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSave.Enabled = false;

                objPro = new clsProperties();

                objPro.rowID = e.RowIndex;
                
                if(dgvTDS.Rows.Count > 0)
                {
                    dtpInputDate.Text = dgvTDS.Rows[objPro.rowID].Cells[3].Value.ToString();
                    txtClientName.Text = dgvTDS.Rows[objPro.rowID].Cells[4].Value.ToString();
                    txtWorkType.Text = dgvTDS.Rows[objPro.rowID].Cells[5].Value.ToString();
                    cmbAllocatedTo.Text = dgvTDS.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();
                    dtpDueDate.Text = dgvTDS.Rows[objPro.rowID].Cells[7].Value.ToString();
                    cmbPeriod.Text = dgvTDS.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                    cmbFilingSt.Text = dgvTDS.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                    txtYear.Text = dgvTDS.Rows[objPro.rowID].Cells[10].Value.ToString();
                    tempTdsId = Convert.ToInt32(dgvTDS.Rows[objPro.rowID].Cells[11].Value.ToString());
                    tempClientId = Convert.ToInt32(dgvTDS.Rows[objPro.rowID].Cells[12].Value.ToString());

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

                if (e.ColumnIndex == dgvTDS.Columns["btnQuery"].Index)
                {
                    frm_Query query = new frm_Query(tempEmployeeName);

                    query.serviceName = serviceName;
                    query.clientName = tempClientName;
                    query.employeeName = tempEmployeeName;
                    query.workTypeName = tempWorkType;

                    query.ShowDialog();
                }

                if (e.ColumnIndex == dgvTDS.Columns["btnReply"].Index)
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
                MessageBox.Show(ex.Message.ToString(), "UC_TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkType.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtUname.Text == string.Empty)
                {
                    MessageBox.Show("Enter Username", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPass.Text == string.Empty)
                {
                    MessageBox.Show("Enter Password", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtYear.Text == string.Empty)
                {
                    MessageBox.Show("Enter Year", "TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                clId = common.clientId;

                objPro.clientID = clId;
                objPro.tdsId = tempTdsId;
                objPro.clientName = txtClientName.Text;
                objPro.tdsService = common.service;
                objPro.tdsInputDate = dtpInputDate.Value;
                objPro.tdsWorktype = txtWorkType.Text;
                objPro.tdsAllocatedEmp = cmbAllocatedTo.Text;
                objPro.tdsDueDate = dtpDueDate.Value;
                objPro.tdsYear = txtYear.Text;
                objPro.tdsPeriod = cmbPeriod.Text;
                objPro.tdsStatus = cmbFilingSt.Text;

                objPro.clientID = tempClientId;
                objPro.username = txtUname.Text;
                objPro.password = txtPass.Text;
                objPro.workService = common.service;

                cls_TdsDL = new cls_TdsDL();
                flag = cls_TdsDL.updateData(objPro);

                if (flag == 1)
                {
                    flag = 0;

                    clientUserPassDL = new cls_ClientUserPassDL();
                    flag = clientUserPassDL.updateClientUserNamePassword(objPro);

                    if (cmbFilingSt.SelectedItem != null && cmbFilingSt.SelectedItem.ToString() == "FILED")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "TDS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                    common.ClearControls();
                    Clear();
                    show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_TDS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void show()
        {
            cls_TdsDL = new cls_TdsDL();
            ds = new DataSet();

            ds = cls_TdsDL.showData();

            if (ds.Tables[0].Rows.Count < 0)
            {

            }
            else
            {
                dgvTDS.DataSource = ds.Tables[0];
                dgvTDS.Columns["tdsId"].Visible = false;
                dgvTDS.Columns["t_Year"].Visible = false;
                dgvTDS.Columns["clientId"].Visible = false;
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

        private void ShowQuery()
        {
            query = new cls_Query();
            ds1 = new DataSet();

            ds1 = query.QueryRaisedByEmp();

            foreach (DataGridViewRow row in dgvTDS.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClientName"].Value?.ToString();
                string workType = row.Cells["WorkType"].Value?.ToString();
                service = "TDS";
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
