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

        public string empName { get; set; }

        public string serviceName { get; set; }

        public string workTypeName { get; set; }

        public string clientName { get; set; }

        public string role { get; set; }

        public string employeeName { get; set; }

        private void frm_Query_Load(object sender, EventArgs e)
        {
            show();

            if(role == "User")
            {
                txtQueryByEmp.Enabled = true;
                txtReply.Enabled = false;
            }
            else
            {
                txtReply.Enabled = true;
                txtQueryByEmp.Enabled = false;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveEmp_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.workAllocatedEmpName = lblEmpName.Text;
                objPro.workTypeName = workTypeName;
                objPro.workService = serviceName;
                objPro.workQueryByEmp = txtQueryByEmp.Text;
                objPro.workQuerySolution = txtReply.Text;
                objPro.clientName = clientName;

                query = new cls_Query();

                flag = query.saveQueryByEmp(objPro);

                if (flag == 1)
                {
                    MessageBox.Show("Query Saved...");
                    Clear();
                    show();
                    txtQueryByEmp.Focus();
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

        private void show()
        {
            //try
            //{
            //    objPro = new clsProperties();
            //    query = new cls_Query();

            //    if(role == "User")
            //    {
            //        ds = query.QueryByEmp(lblEmpName.Text, serviceName, clientName);

            //    }
            //    else
            //    {
            //        ds = query.QueryByEmp(employeeName, serviceName, clientName);
            //    }

            //    if (ds != null)
            //    {
            //        dgvQuery.DataSource = ds.Tables[0];
            //        dgvQuery.Columns["queryEmpId"].Visible = false;
            //        dgvQuery.Columns["queryEmpName"].Visible = false;

            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), "FRM_QUERY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.workQueryByEmp = txtQueryByEmp.Text;
                objPro.workQuerySolution = txtReply.Text;
                objPro.workQueryByEmpId = Convert.ToInt32(lblQueryByEmpId.Text);

                query = new cls_Query();
                flag = query.updateQuerybyEmp(objPro);

                if (flag == 1)
                {
                    MessageBox.Show("Query Updated...");
                    Clear();
                    txtReply.Clear();
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

        private void dgvQuery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.rowID = e.RowIndex;

                btnSaveEmp.Enabled = false;

                if (dgvQuery.Rows.Count > 0)
                {
                    txtQueryByEmp.Text = dgvQuery.Rows[objPro.rowID].Cells[6].Value.ToString();
                    lblQueryByEmpId.Text = dgvQuery.Rows[objPro.rowID].Cells[0].Value.ToString();
                    txtReply.Text = dgvQuery.Rows[objPro.rowID].Cells[4].Value.ToString();

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

            btnSaveEmp.Enabled = true;
        }

        private void dgvQuery_SelectionChanged(object sender, EventArgs e)
        {
            dgvQuery.ClearSelection();
        }
    }
}
