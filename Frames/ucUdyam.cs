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
    public partial class ucUdyam : UserControl
    {
        public ucUdyam()
        {
            InitializeComponent();
        }

        #region CLASS & OBJECTS

        CommonUC common;
        DataTable dt;
        DataSet ds, ds1;
        cls_EmployeeDL employeeDL;
        cls_ClientUserPassDL clientUserPassDL;
        cls_UdyamDL clsUdyamDL;
        clsProperties objPro;
        cls_Query query;
        cls_BusinessDL bus;
        cls_ClientsDL client;
       

        #endregion

        #region VARIABLES

        int flag, clientId, tempUdyamId, tempClientId;
        string tempEmployeeName, tempClientName, tempWorkType, serviceName, service, businessName, clientAddress;

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

        private void Clear()
        {
            dtpInputDate.Text = DateTime.Now.ToString();
            txtClientName.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            dtpDueDate.Text = DateTime.Now.ToString();
            txtFees.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            txtTaskName.Clear();
            txtTradeName.Clear();
            txtDescription.Clear();

            btnSave.Enabled = true;
        }

        private void show()
        {
            ds = new DataSet();
            clsUdyamDL = new cls_UdyamDL();

            ds = clsUdyamDL.showData();

            if (ds.Tables[0].Rows.Count < 0)
            {

            }
            else
            {
                dgvUdyam.DataSource = ds.Tables[0];

                dgvUdyam.Columns["clientId"].Visible = false;
                dgvUdyam.Columns["udyamId"].Visible = false;
                dgvUdyam.Columns["u_Fees"].Visible = false;
            }
        }

        #endregion

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "UDYAM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "UDYAM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFees.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fees Amount", "UDYAM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                objPro.clientID = tempClientId;
                objPro.clientName = txtClientName.Text;
                objPro.udyamTradeName = txtTradeName.Text;
                objPro.udyamInputDate = dtpInputDate.Value;
                objPro.udyamTaskName = txtTaskName.Text;
                objPro.udyamAllocatedEmp = cmbAllocatedTo.Text;
                objPro.udyamDueDate = dtpDueDate.Value;
                objPro.udyamFees = Convert.ToInt32(txtFees.Text);
                objPro.udyamFeeStatus = cmbFeesStatus.Text;
                objPro.udyamStatus = cmbWorkStatus.Text;
                objPro.udyamDescription = txtDescription.Text;

                clsUdyamDL = new cls_UdyamDL();
                flag = clsUdyamDL.saveData(objPro);

                if (flag == 1)
                {
                    Clear();
                    show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_UDYAM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "UDYAM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTaskName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Work Type", "UDYAM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtFees.Text == string.Empty)
                {
                    MessageBox.Show("Enter Fees Amount", "UDYAM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                objPro.udyamId = tempUdyamId;
                objPro.clientID = clientId;
                objPro.clientName = txtClientName.Text;
                objPro.udyamTradeName = txtTradeName.Text;
                objPro.udyamInputDate = dtpInputDate.Value;
                objPro.udyamTaskName = txtTaskName.Text;
                objPro.udyamAllocatedEmp = cmbAllocatedTo.Text;
                objPro.udyamDueDate = dtpDueDate.Value;
                objPro.udyamFees = Convert.ToInt32(txtFees.Text);
                objPro.udyamFeeStatus = cmbFeesStatus.Text;
                objPro.udyamStatus = cmbWorkStatus.Text;
                objPro.udyamDescription = txtDescription.Text;

                clsUdyamDL = new cls_UdyamDL();
                flag = clsUdyamDL.updateData(objPro);

                if (flag == 1)
                {

                    //if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "Done")
                    //{
                    //    DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "UDYAM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //    if (dial == DialogResult.Yes)
                    //    {
                    //        frm_Narration narr = new frm_Narration();
                    //        narr.clientName = txtClientName.Text;
                    //        narr.service = common.service;
                    //        narr.amount = txtFessAmt.Text;
                    //        narr.workType = txtWorkType.Text;
                    //        narr.businessName = businessName;
                    //        narr.clientAddress = clientAddress;

                    //        narr.Show();
                    //    }
                    //}

                    Clear();
                    show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_UDYAM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUdyam_SelectionChanged(object sender, EventArgs e)
        {
            dgvUdyam.ClearSelection();
        }

        private void ucUdyam_Load(object sender, EventArgs e)
        {
            BindSearch();
            BindEmployee();
            show();

            cmbAllocatedTo.SelectedIndex = 0;
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;

            // USER DEFINED EVENTS
            cmbWorkStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbWorkStatus.DrawItem += cmbWorkStatus_DrawItem;
        }

        private void dgvUdyam_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          //  ShowQuery();
            #region CHANGE STATUS COLORS

            Dictionary<string, Color> StatusColors = new Dictionary<string, Color>()
            {
                { "Not Started", ColorTranslator.FromHtml("#D6DCE4") },
                { "Waiting For Documents", ColorTranslator.FromHtml("#F4B084") },
                { "Document Received", ColorTranslator.FromHtml("#A9D08E") },
                { "Return Prepaired", ColorTranslator.FromHtml("#00B0F0") },
                { "Cancelled", ColorTranslator.FromHtml("#FF0000") },
                { "Complete", ColorTranslator.FromHtml("#FFC000") },
                { "Done", ColorTranslator.FromHtml("#FFFF00") }
            };

            if (dgvUdyam.Columns[e.ColumnIndex].Name == "Status")
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
        }

        private void dgvUdyam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            objPro = new clsProperties();

            objPro.rowID = e.RowIndex;

            if (dgvUdyam.Rows.Count > 0)
            {
                dtpInputDate.Text = dgvUdyam.Rows[objPro.rowID].Cells[2].Value.ToString();
                txtClientName.Text = dgvUdyam.Rows[objPro.rowID].Cells[3].Value.ToString();
                txtTradeName.Text = dgvUdyam.Rows[objPro.rowID].Cells[4].Value.ToString();
                txtTaskName.Text = dgvUdyam.Rows[objPro.rowID].Cells[5].Value.ToString();
                cmbAllocatedTo.Text = dgvUdyam.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();
                dtpDueDate.Text = dgvUdyam.Rows[objPro.rowID].Cells[7].Value.ToString();
                cmbWorkStatus.Text = dgvUdyam.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                cmbFeesStatus.Text = dgvUdyam.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                txtDescription.Text = dgvUdyam.Rows[objPro.rowID].Cells[10].Value.ToString();
                txtFees.Text = dgvUdyam.Rows[objPro.rowID].Cells[11].Value.ToString();
                tempUdyamId = Convert.ToInt32(dgvUdyam.Rows[objPro.rowID].Cells[12].Value.ToString());
                clientId = Convert.ToInt32(dgvUdyam.Rows[objPro.rowID].Cells[13].Value.ToString());

                //objPro.workService = common.service;

                //tempEmployeeName = cmbAllocatedTo.Text;
                //tempClientName = txtClientName.Text;
                //tempWorkType = txtWorkType.Text;
                //objPro.clientID = tempClientId;

                bus = new cls_BusinessDL();
                //ds = new DataSet();

                //ds = bus.getBusinessName(tempClientName, tempClientId);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    businessName = ds.Tables[0].Rows[0]["c_BusinessName"].ToString();
                //    clientAddress = ds.Tables[0].Rows[0]["c_Address"].ToString();
                //}
            }

            if (e.ColumnIndex == dgvUdyam.Columns["btnReply"].Index)
            {
                frm_Query query = new frm_Query(tempEmployeeName);

                query.serviceName = serviceName;
                query.clientName = tempClientName;
                query.employeeName = tempEmployeeName;
                query.workTypeName = tempWorkType;

                query.ShowDialog();
            }
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            if (txtClientName.Text == string.Empty)
            {
                txtTradeName.Clear();
            }
        }

        private void txtClientName_Leave(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void txtTradeName_Leave(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

    }
}
