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
    public partial class ucAllOne : UserControl
    {
        public ucAllOne()
        {
            InitializeComponent();
        }

        CommonUC common;
        DataTable dt;
        cls_EmployeeDL employeeDL;
        clsProperties objPro;
        DataSet ds, ds1;
        cls_AllInOne clsAllOne;
        cls_ClientUserPassDL clientUserPassDL;
        cls_Query query;
        cls_BusinessDL bus;
        cls_ClientsDL client;

        int clId, flag, tempAllOneId, tempClientId;
        string service;
        string tempEmployeeName, tempClientName, tempWorkType, serviceName, businessName, clientAddress;

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

        private void ucAllOne_Load(object sender, EventArgs e)
        {
            BindSearch();
            BindEmployee();
            show();

            cmbAllocatedTo.SelectedIndex = 0;
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            cmbRecurringTask.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;

            // USER DEFINED EVENTS
            cmbWorkStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbWorkStatus.DrawItem += cmbWorkStatus_DrawItem;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.clientID = tempClientId;
                objPro.clientName = txtClientName.Text;
                objPro.allOneTradeName = txtTradeName.Text;
                objPro.allOneTaskName = txtTaskName.Text;
                objPro.allOneInputDate = dtpInputDate.Value;
                objPro.allOneAllocatedEmp = cmbAllocatedTo.Text;
                objPro.allOneDueDate = dtpDueDate.Value;
                objPro.allOneYear = txtYear.Text;
                objPro.allOneFee = string.IsNullOrWhiteSpace(txtFessAmt.Text) ? 0 : Convert.ToInt32(txtFessAmt.Text);
                objPro.allOneFeeStatus = cmbFeesStatus.Text;
                objPro.allOneStatus = cmbWorkStatus.Text;
                objPro.allOneDescription = txtDescription.Text;
                objPro.allOneTypeOfReturn = txtReturn.Text;
                objPro.allOneRecurringTask = cmbRecurringTask.Text;
                objPro.allOnePeriodicity = cmbPeriodicity.Text;

                clsAllOne = new cls_AllInOne();
                flag = clsAllOne.saveData(objPro);

                if (flag >= 1)
                {
                    show();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            if(txtClientName.Text == string.Empty)
            {
                txtTradeName.Clear();
            }
        }

        private void txtClientName_Leave(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void dgvAllOne_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

            if (dgvAllOne.Columns[e.ColumnIndex].Name == "Status")
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

        private void txtTradeName_Leave(object sender, EventArgs e)
        {
            SearchClient();
        }

        private void dgvAllOne_SelectionChanged(object sender, EventArgs e)
        {
            dgvAllOne.ClearSelection();
        }

        private void dgvAllOne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            objPro = new clsProperties();

            objPro.rowID = e.RowIndex;

            if (dgvAllOne.Rows.Count >= 0)
            {
                dtpInputDate.Text = dgvAllOne.Rows[objPro.rowID].Cells[3].Value.ToString();
                txtClientName.Text = dgvAllOne.Rows[objPro.rowID].Cells[4].Value.ToString();
                txtTaskName.Text = dgvAllOne.Rows[objPro.rowID].Cells[5].Value.ToString();
                cmbAllocatedTo.Text = dgvAllOne.Rows[objPro.rowID].Cells[6].Value.ToString().Trim();
                dtpDueDate.Text = dgvAllOne.Rows[objPro.rowID].Cells[7].Value.ToString();
                txtFessAmt.Text = dgvAllOne.Rows[objPro.rowID].Cells[10].Value.ToString();
                cmbFeesStatus.Text = dgvAllOne.Rows[objPro.rowID].Cells[9].Value.ToString().Trim();
                cmbWorkStatus.Text = dgvAllOne.Rows[objPro.rowID].Cells[8].Value.ToString().Trim();
                txtYear.Text = dgvAllOne.Rows[objPro.rowID].Cells[11].Value.ToString().Trim();
                tempAllOneId = Convert.ToInt32(dgvAllOne.Rows[objPro.rowID].Cells[13].Value.ToString());
                tempClientId = Convert.ToInt32(dgvAllOne.Rows[objPro.rowID].Cells[14].Value.ToString());

            }

            if (e.ColumnIndex == dgvAllOne.Columns["btnReply"].Index)
            {
                frm_Query query = new frm_Query(tempEmployeeName);

                query.serviceName = serviceName;
                query.clientName = tempClientName;
                query.employeeName = tempEmployeeName;
                query.workTypeName = tempWorkType;

                query.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                clId = common.clientId;

                objPro.clientID = clId;
                objPro.allOneId = tempAllOneId;
                objPro.clientName = txtClientName.Text;
                objPro.allOneService = common.service;
                objPro.allOneInputDate = dtpInputDate.Value;
                objPro.allOneWorktype = txtWorkType.Text;
                objPro.allOneAllocatedEmp = cmbAllocatedTo.Text;
                objPro.allOneDueDate = dtpDueDate.Value;
                objPro.allOneYear = txtYear.Text;
                objPro.allOneNumber = txtNo.Text;
                objPro.allOneFee = string.IsNullOrWhiteSpace(txtFessAmt.Text) ? 0 : Convert.ToInt32(txtFessAmt.Text);
                objPro.allOneFeeStatus = cmbFeesStatus.Text;
                objPro.allOneStatus = cmbWorkStatus.Text;

                objPro.clientID = tempClientId;
                objPro.username = txtUname.Text;
                objPro.password = txtPass.Text;
                objPro.workService = common.service;

                clsAllOne = new cls_AllInOne();
                flag = clsAllOne.updateData(objPro);

                if (flag == 1)
                {
                    flag = 0;

                    clientUserPassDL = new cls_ClientUserPassDL();
                    flag = clientUserPassDL.updateClientUserNamePassword(objPro);

                    if (cmbWorkStatus.SelectedItem != null && cmbWorkStatus.SelectedItem.ToString() == "DONE")
                    {
                        DialogResult dial = MessageBox.Show("DO YOU WANT TO PRINT BILL ?", "ALL IN ONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                    //MessageBox.Show("Record Saved...");

                    common.ClearControls();
                    show();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowQuery()
        {
            //query = new cls_Query();
            //ds1 = new DataSet();

            //ds1 = query.QueryRaisedByEmp();

            //foreach (DataGridViewRow row in dgvAllOne.Rows)
            //{
            //    if (row.IsNewRow)
            //        continue;

            //    string employee = row.Cells["EmployeeName"].Value?.ToString();
            //    string client = row.Cells["ClientName"].Value?.ToString();

            //    service = "ALL IN ONE";
            //    var queryRow = ds1.Tables[0].AsEnumerable().FirstOrDefault(r =>
            //       r.Field<string>("EmployeeName") == employee &&
            //       r.Field<string>("clientName") == client &&
            //       r.Field<string>("service") == service
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

        private void show()
        {
            //ds = new DataSet();
            //clsAllOne = new cls_AllInOne();

            //ds = clsAllOne.showData();

            //if (ds.Tables[0].Rows.Count < 0)
            //{

            //}
            //else
            //{
            //    dgvAllOne.DataSource = ds.Tables[0];

            //    dgvAllOne.Columns["a_Fees"].Visible = false;
            //    dgvAllOne.Columns["a_Year"].Visible = false;
            //    dgvAllOne.Columns["a_Number"].Visible = false;
            //    dgvAllOne.Columns["clientId"].Visible = false;
            //    dgvAllOne.Columns["allOneId"].Visible = false;
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
            txtYear.Clear();
            txtFessAmt.Clear();
            cmbFeesStatus.SelectedIndex = 0;
            cmbWorkStatus.SelectedIndex = 0;
            txtTaskName.Clear();
            txtTradeName.Clear();
            cmbRecurringTask.SelectedIndex = 0;
            cmbPeriodicity.SelectedIndex = 0;
            txtDescription.Clear();

            btnSave.Enabled = true;
        }

    }
}
