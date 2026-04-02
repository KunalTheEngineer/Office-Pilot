using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25.Frames
{
    public partial class ucEmployee : UserControl
    {
        public ucEmployee()
        {
            InitializeComponent();
        }

        DataSet ds;
        clsProperties objPro;
        cls_IncomeTaxDL incomeTaxDL;

        private void ucEmployee_Load(object sender, EventArgs e)
        {
            show();
        }

        private void show()
        {
            try
            {
                objPro = new clsProperties();
                incomeTaxDL = new cls_IncomeTaxDL();
                ds = new DataSet();

                objPro.workAllocatedEmpName = "Sanket Patil"; //Kunal Thakare  Aniket Jagtap  Sarthak

                ds = incomeTaxDL.ShowWorkByEmpName(objPro);

                if (ds != null)
                {
                    dgvAllInOne.DataSource = ds.Tables[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_EMPLOYEE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvAllInOne_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvAllInOne.Rows.Count > 0)
                {

                    if (e.ColumnIndex == dgvAllInOne.Columns["btnQuery"].Index)
                    {
                        frm_Query query = new frm_Query(objPro.workAllocatedEmpName);

                        query.empName = objPro.workAllocatedEmpName;
                        query.serviceName = dgvAllInOne.Rows[e.RowIndex].Cells[2].Value.ToString();
                        query.clientName = dgvAllInOne.Rows[e.RowIndex].Cells[4].Value.ToString();
                        query.workTypeName = dgvAllInOne.Rows[e.RowIndex].Cells[5].Value.ToString();


                        query.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
