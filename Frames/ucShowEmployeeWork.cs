using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25.Frames
{
    public partial class ucShowEmployeeWork : UserControl
    {
        public ucShowEmployeeWork()
        {
            InitializeComponent();
        }

        cls_LoginDL clsLoginDL;
        DataSet ds, ds1;
        cls_Query query;

        string tempName;

        public string empName { get; set; }

        public string empRole { get; set; }

        private void ucShowEmployeeWork_Load(object sender, EventArgs e)
        {

            show();
            dgvShowEmployeeWork.Refresh();

            this.BeginInvoke(new Action(() =>
            {
                dgvShowEmployeeWork.ClearSelection();
            }));

        }

        private void ShowReply()
        {
            query = new cls_Query();
            ds1 = new DataSet();

            ds1 = query.QuerySolutionByAdmin(empName);

            foreach (DataGridViewRow row in dgvShowEmployeeWork.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string employee = row.Cells["EmployeeName"].Value?.ToString();
                string client = row.Cells["ClientName"].Value?.ToString();
                string service = row.Cells["Service"].Value?.ToString();

                bool hasReply = ds1.Tables[0].AsEnumerable().Any(r =>
                    r.Field<string>("queryEmpName") == employee &&
                    r.Field<string>("queryClientName") == client &&
                    r.Field<string>("queryServiceName") == service &&
                    !string.IsNullOrEmpty(r.Field<string>("querySolution"))
                  );

                if (hasReply)
                {
                    row.DefaultCellStyle.BackColor = Color.LimeGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = DefaultBackColor;
                }

            }
        }

        private void show()
        {
            clsLoginDL = new cls_LoginDL();
            ds = new DataSet();

            if (empRole == "User")
            {
                ds = clsLoginDL.showLoginEmployeeWork(empName);

                if (ds.Tables[0].Rows.Count < 0)
                {
                    
                }
                else
                {
                    dgvShowEmployeeWork.DataSource = ds.Tables[0];
                    dgvShowEmployeeWork.Columns["EmployeeName"].Visible = false;
                }
            }
            else
            {
                ds = clsLoginDL.showAdminLogin();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvShowEmployeeWork.DataSource = ds.Tables[0];
                    dgvShowEmployeeWork.Columns["EmployeeName"].Visible = true;
                }
            }

        }

        private void dgvShowEmployeeWork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvShowEmployeeWork.Rows.Count > 0)
                {

                    if (e.ColumnIndex == dgvShowEmployeeWork.Columns["btnQuery"].Index)
                    {

                        if (empRole == "User")
                        {
                            frm_Query query = new frm_Query(empName);

                            query.role = empRole;

                            query.serviceName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[2].Value.ToString();
                            query.workTypeName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[5].Value.ToString();
                            query.clientName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[6].Value.ToString();
                            

                            query.ShowDialog();
                        }
                        else
                        {
                            tempName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[7].Value.ToString();

                            frm_Query query = new frm_Query(tempName);

                            query.role = empRole;

                            query.serviceName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[2].Value.ToString();
                            query.clientName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[6].Value.ToString();
                            query.workTypeName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[5].Value.ToString();
                            query.employeeName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[7].Value.ToString();

                            query.ShowDialog();
                        }

                    }

                    if (e.ColumnIndex == dgvShowEmployeeWork.Columns["btnReply"].Index)
                    {
                        if (empRole == "User")
                        {
                            frm_Query query = new frm_Query(empName);

                            query.role = empRole;

                            query.serviceName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[2].Value.ToString();
                            query.clientName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[6].Value.ToString();
                            query.workTypeName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[5].Value.ToString();

                            query.ShowDialog();
                        }
                        else
                        {
                            tempName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[7].Value.ToString();

                            frm_Query query = new frm_Query(tempName);

                            query.role = empRole;

                            query.serviceName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[2].Value.ToString();
                            query.clientName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[6].Value.ToString();
                            query.workTypeName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[5].Value.ToString();
                            query.employeeName = dgvShowEmployeeWork.Rows[e.RowIndex].Cells[7].Value.ToString();

                            query.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_EMPLOYEE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        // used to not show selection (.i.e blue color) on first row of datagrid
        private void dgvShowEmployeeWork_SelectionChanged(object sender, EventArgs e)
        {
            dgvShowEmployeeWork.ClearSelection();
        }

        // used to change the background color of row dynamically
        private void dgvShowEmployeeWork_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowReply();
        }

    }
}
