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
        cls_ClientsDL client;

        int clientId, flag, tempPanId, tempClientId;
        string tempEmployeeName, tempWorkType, serviceName, tempClientName, service, businessName, clientAddress;

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

        #region EVENTS

        private void ucPAN_Load(object sender, EventArgs e)
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

                objPro.clientID = clientId;
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
                objPro.panId = tempPanId;

                panDL = new cls_PanDL();
                flag = panDL.updateData(objPro);

                if (flag == 1)
                {
                    //if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "DONE")
                    //{
                    //    DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "PAN/TAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                    show();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_PAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void txtTradeName_Leave(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void dgvAllInOne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            objPro = new clsProperties();

            objPro.rowID = e.RowIndex;

            if (dgvAllInOne.Rows.Count > 0)
            {
                dtpInputDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[2].Value.ToString();
                txtClientName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[3].Value.ToString();
                txtTradeName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[4].Value.ToString();
                txtTaskName.Text = dgvAllInOne.Rows[objPro.rowID].Cells[5].Value.ToString();
                cmbAllocatedTo.Text = dgvAllInOne.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();
                dtpDueDate.Text = dgvAllInOne.Rows[objPro.rowID].Cells[7].Value.ToString();
                cmbWorkStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                txtDescription.Text = dgvAllInOne.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                cmbFeesStatus.Text = dgvAllInOne.Rows[objPro.rowID].Cells[10].Value.ToString().Trim();
                txtFees.Text = dgvAllInOne.Rows[objPro.rowID].Cells[11].Value.ToString();
                clientId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[12].Value.ToString());
                tempPanId = Convert.ToInt32(dgvAllInOne.Rows[objPro.rowID].Cells[13].Value.ToString());




            }



            if (e.ColumnIndex == dgvAllInOne.Columns["btnReply"].Index)
            {
                frm_Query query = new frm_Query(tempEmployeeName);

                query.serviceName = serviceName;
                query.clientName = tempClientName;
                query.employeeName = tempEmployeeName;
                query.workTypeName = tempWorkType;

                query.ShowDialog();
            }
        }

        private void dgvAllInOne_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowQuery();

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

            if (dgvAllInOne.Columns[e.ColumnIndex].Name == "Status")
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

        private void dgvAllInOne_SelectionChanged(object sender, EventArgs e)
        {
            dgvAllInOne.ClearSelection();
        }

        #endregion

        #region FUNCTIONS

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
                    dgvAllInOne.Columns["p_Fees"].Visible = false;
                    dgvAllInOne.Columns["clientId"].Visible = false;
                    dgvAllInOne.Columns["clientId"].Visible = false;
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
            txtTaskName.Clear();
            cmbAllocatedTo.SelectedIndex = 0;
            dtpDueDate.Text = DateTime.Now.ToString();
            txtFees.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            txtTradeName.Clear();

            btnSave.Enabled = true;
        }

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
            //    string workType = row.Cells["WorkType"].Value?.ToString();
            //    service = "PAN / TAN";
            //    var queryRow = ds1.Tables[0].AsEnumerable().FirstOrDefault(r =>
            //       r.Field<string>("EmployeeName") == employee &&
            //       r.Field<string>("clientName") == client &&
            //       r.Field<string>("service") == service &&
            //        r.Field<string>("workType") == workType
            //     //&&
            //     //!string.IsNullOrEmpty(r.Field<string>("queryByEmp"))
            //     );


            //    bool hasQuery = false;

            //    if (queryRow != null)
            //    {
            //        object val = queryRow["HasQuery"];

            //        if (val != DBNull.Value && int.TryParse(val.ToString(), out int parsed))
            //        {
            //            hasQuery = parsed == 1;
            //        }
            //    }

            //    row.DefaultCellStyle.BackColor = hasQuery ? Color.Red : DefaultBackColor;

            //}
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
                MessageBox.Show(ex.Message.ToString(), "UC_PAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
