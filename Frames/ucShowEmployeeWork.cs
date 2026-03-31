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
        DataSet ds;

        public string EMPLOYEENAME { get; set; }

        public string ROLE { get; set; }

        private void ucShowEmployeeWork_Load(object sender, EventArgs e)
        {

            show();
            dgvShowEmployeeWork.Refresh();

            this.BeginInvoke(new Action(() =>
            {
                dgvShowEmployeeWork.ClearSelection();
            }));

        }

        private void show()
        {
            clsLoginDL = new cls_LoginDL();
            ds = new DataSet();

            if (ROLE == "User")
            {
                ds = clsLoginDL.showLoginEmployeeWork(EMPLOYEENAME);

                if (ds.Tables[0].Rows.Count < 0)
                {
                    
                }
                else
                {
                    dgvShowEmployeeWork.DataSource = ds.Tables[0];

                    dgvShowEmployeeWork.Columns["EmployeeName"].Visible = false;
                    dgvShowEmployeeWork.Columns["TaskId"].Visible = false;
                    dgvShowEmployeeWork.Columns["HasQuery"].Visible = false;
                }
            }
            else
            {
                ds = clsLoginDL.showAdminLogin();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvShowEmployeeWork.DataSource = ds.Tables[0];
   
                    dgvShowEmployeeWork.Columns["TaskId"].Visible = false;
                    dgvShowEmployeeWork.Columns["HasQuery"].Visible = false;
                }
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

            #region CHANGE STATUS COLORS

            Dictionary<string, Color> StatusColors = new Dictionary<string, Color>()
            {
                { "Not Started", ColorTranslator.FromHtml("#D6DCE4") },
                { "Waiting For Documents", ColorTranslator.FromHtml("#F4B084") },
                { "Document Received", ColorTranslator.FromHtml("#A9D08E") },
                { "Return Prepaired", ColorTranslator.FromHtml("#00B0F0") },
                { "Cancelled", ColorTranslator.FromHtml("#FF0000") },
                { "Complete", ColorTranslator.FromHtml("#FFC000") },
                { "Pending", ColorTranslator.FromHtml("#C9C9FF") },
                { "In Process", ColorTranslator.FromHtml("#FFCCFF") },
                { "On Hold", ColorTranslator.FromHtml("#B4C6E7") },
                { "Tax Payable", ColorTranslator.FromHtml("#FFD966") },
                { "Tax Amount Received", ColorTranslator.FromHtml("#A2C4C9") },
                { "Return Filed", ColorTranslator.FromHtml("#EAD1DC") },
                { "Refund", ColorTranslator.FromHtml("#D9EAD3") }
               // { "Done", ColorTranslator.FromHtml("#FFFF00") }
            };

            if (dgvShowEmployeeWork.Columns[e.ColumnIndex].Name == "Status")
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

            #region SHOW ROW GREEN

            foreach(DataGridViewRow row in dgvShowEmployeeWork.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string status = row.Cells["status"].Value.ToString();

                if(status == "Filed" || status == "Done")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

            #endregion
        }

    }
}
