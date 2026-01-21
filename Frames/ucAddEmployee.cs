using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25.Frames
{
    public partial class ucAddEmployee : UserControl
    {
        public ucAddEmployee()
        {
            InitializeComponent();
        }

        clsProperties objPro;
        cls_EmployeeDL employee;
        int flag=0;
        DataSet ds;
        private void ucAddEmployee_Load(object sender, EventArgs e)
        {
            show();
            cmbRole.SelectedIndex = 0;

            txtEmpName.Focus();
        }

        private void show()
        {
            try
            {
                employee = new cls_EmployeeDL();

                ds = employee.EmployeeData();

                dgvEmployee.DataSource = ds.Tables[0];
                dgvEmployee.Columns["empId"].Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                clear();

                return;
            }
        }

        private void clear()
        {
            show();
            txtEmpName.Clear();
            txtEmpMobile.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmpName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Employee Name", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtEmpMobile.Text == string.Empty)
                {
                    MessageBox.Show("Enter Employee Mobile Number", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtUsername.Text == string.Empty)
                {
                    MessageBox.Show("Enter Employee Username", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Enter Employee Password", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(cmbRole.SelectedIndex == 0)
                {
                    MessageBox.Show("Select Employee Role", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objPro = new clsProperties();

                objPro.empName = txtEmpName.Text;
                objPro.empMobile = txtEmpMobile.Text;
                objPro.empUsername = txtUsername.Text;
                objPro.empPassword = txtPassword.Text;
                objPro.empRole = cmbRole.Text;

                employee = new cls_EmployeeDL();
               flag = employee.saveEmployeeData(objPro);
                if (flag==1)
                {
                    //MessageBox.Show("Record Saved.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    clear();  
                    show();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_EMPLOYEE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtEmpName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Employee Name", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtEmpMobile.Text == string.Empty)
                {
                    MessageBox.Show("Enter Employee Mobile Number", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtUsername.Text == string.Empty)
                {
                    MessageBox.Show("Enter Employee Username", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Enter Employee Password", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbRole.SelectedIndex == 0)
                {
                    MessageBox.Show("Select Employee Role", "ROLE CREATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                employee = new cls_EmployeeDL();

                objPro.empName = txtEmpName.Text;
                objPro.empMobile = txtEmpMobile.Text;
                objPro.empUsername = txtUsername.Text;
                objPro.empPassword = txtPassword.Text;
                objPro.empRole = cmbRole.Text;

                flag = employee.updateEmployeeData(objPro);

                if (flag == 1)
                {
                    //MessageBox.Show("Record Updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();  
                    show();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_EMPLOYEE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                btnSave.Enabled = false;
                objPro = new clsProperties();

                objPro.rowID = e.RowIndex;

                if (dgvEmployee.Rows.Count > 0)
                {
                    objPro.empId = Convert.ToInt32(dgvEmployee.Rows[objPro.rowID].Cells[0].Value.ToString());
                    txtEmpName.Text =  dgvEmployee.Rows[objPro.rowID].Cells[2].Value.ToString();
                    txtEmpMobile.Text =  dgvEmployee.Rows[objPro.rowID].Cells[3].Value.ToString();
                    txtUsername.Text =  dgvEmployee.Rows[objPro.rowID].Cells[4].Value.ToString();
                    txtPassword.Text =  dgvEmployee.Rows[objPro.rowID].Cells[5].Value.ToString();
                    cmbRole.Text = dgvEmployee.Rows[objPro.rowID].Cells[6].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_EMPLOYEE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            employee = new cls_EmployeeDL();

            flag = employee.deleteEmployeeData(objPro);

            if (flag == 1)
            {
                //MessageBox.Show("Record Deleted.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                show();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }


        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            dgvEmployee.ClearSelection();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
