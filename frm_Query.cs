using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tax_Consultant_25.Data_Layer;
using Tax_Consultant_25.Frames;

namespace Tax_Consultant_25
{
    public partial class frm_Query : MetroForm
    {
        string servicetype;

        public frm_Query(string empName)
        {
            InitializeComponent();
            lblEmpName.Text = empName;
        }

        clsProperties objPro;
        cls_Query query;
        int flag = 0;
        DataSet ds;

        #region VARIABLES

        public string empName { get; set; }

        public string taskName { get; set; }

        public string serviceName { get; set; }

        public string workTypeName { get; set; }

        public string clientName { get; set; }

        public string role { get; set; }

        public string employeeName { get; set; }

        public int workId { get; set; }

        int queryID, tempWorkId;
        string tempService, tempTaskName, tempCLientName, tempEmpName;

        #endregion

        private void frm_Query_Load(object sender, EventArgs e)
        {

            show();

            if (role == "User")
            {
                txtQueryByEmp.Enabled = true;
                txtReply.Enabled = false;
            }
            else
            {
                txtReply.Enabled = true;
                txtQueryByEmp.Enabled = false;

                lblEmpName.Visible = true;
                lblEmpName.Text = employeeName;
            }

        }

        private void show()
        {
            try
            {
                //objPro = new clsProperties();
                query = new cls_Query();
                ds = new DataSet();

                if (role == "Admin" && ds != null)
                {
                    ds = query.SHOWEMPQUERY(employeeName, serviceName, clientName, taskName, workId);
                }
                else
                {
                    ds = query.SHOWADMINREPLY(employeeName, serviceName, clientName, taskName, workId);
                }


                if (ds != null)
                {
                    dgvQuery.DataSource = ds.Tables[0];

                    dgvQuery.Columns["q_EmpName"].Visible = false;
                    dgvQuery.Columns["workId"].Visible = false;
                    dgvQuery.Columns["queryId"].Visible = false;
                    dgvQuery.Columns["repliedDate"].Visible = false;
                    dgvQuery.Columns["hasQuery"].Visible = false;
                    dgvQuery.Columns["isClosed"].Visible = false;
                    dgvQuery.Columns["isActive"].Visible = false;
                    dgvQuery.Columns["createdDate"].Visible = false;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "FRM_QUERY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvQuery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.rowID = e.RowIndex;

                btnSave.Enabled = false;

                if (dgvQuery.Rows.Count > 0)
                {

                    queryID = Convert.ToInt32(dgvQuery.Rows[objPro.rowID].Cells[1].Value.ToString());
                    tempWorkId = Convert.ToInt32(dgvQuery.Rows[objPro.rowID].Cells[2].Value.ToString());
                    tempService = dgvQuery.Rows[objPro.rowID].Cells[3].Value.ToString();
                    tempTaskName = dgvQuery.Rows[objPro.rowID].Cells[4].Value.ToString();
                    tempCLientName = dgvQuery.Rows[objPro.rowID].Cells[5].Value.ToString();
                    tempEmpName = dgvQuery.Rows[objPro.rowID].Cells[6].Value.ToString();
                    txtQueryByEmp.Text = dgvQuery.Rows[objPro.rowID].Cells[7].Value.ToString();
                    txtReply.Text = dgvQuery.Rows[objPro.rowID].Cells[8].Value.ToString();
                }

                if(e.ColumnIndex == dgvQuery.Columns["btClose"].Index)
                {
                    if (e.RowIndex < 0)
                        return;

                    query = new cls_Query();
                    int fg = query.deleteChat(queryID);

                    if(fg == 1)
                    {
                        show();
                        txtQueryByEmp.Clear();
                        txtReply.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "FRM_QUERY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Clear()
        {
            txtQueryByEmp.Clear();
            txtReply.Clear();

            btnSave.Enabled = true;
        }

        private void dgvQuery_SelectionChanged(object sender, EventArgs e)
        {
            dgvQuery.ClearSelection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.workRole = role;
                objPro.workQueryId = queryID;
                objPro.workQuerySolution = txtReply.Text;
                objPro.workQueryByEmp = txtQueryByEmp.Text;

                query = new cls_Query();
                flag = query.updateQuerybyEmp(objPro);

                if (flag == 1)
                {
                    Clear();
                    show();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "FRM_QUERY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();
                query = new cls_Query();

                objPro.workAllocatedEmpName = employeeName;
                objPro.workTaskName = taskName;
                objPro.workService = serviceName;
                objPro.workQueryByEmp = txtQueryByEmp.Text;
                objPro.workQuerySolution = txtReply.Text;
                objPro.clientName = clientName;
                objPro.workID = workId;
                objPro.workRole = role;

                flag = query.saveQueryByEmp(objPro);

                if (flag == 1)
                {
                    Clear();
                    show();
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "FRM_QUERY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvQuery_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvQuery.Columns["Column2"].DisplayIndex = 1;
            dgvQuery.Columns["Column3"].DisplayIndex = 2;
            dgvQuery.Columns["btClose"].DisplayIndex = dgvQuery.Columns.Count - 1;
        }
    }
}
