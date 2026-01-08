using MetroFramework.Forms;
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

namespace Tax_Consultant_25
{
    public partial class frm_Login : MetroForm
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        clsProperties objPro;
        DataSet ds;
        cls_LoginDL clsLoginDL;
        Form1 form;
        private void frm_Login_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.loginUsername = txtUsername.Text;
                objPro.loginPassword = txtPassword.Text;
                objPro.loginRole = cmbRole.Text;

                ds = new DataSet();
                clsLoginDL = new cls_LoginDL();

                ds = clsLoginDL.Login(objPro);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.Hide();

                    form = new Form1();
                    form.empName = ds.Tables[0].Rows[0]["e_Name"].ToString();
                    form.role = cmbRole.Text;   
                    form.Show();

                }
                else
                {
                    MessageBox.Show("Please check Username and Password or Role...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "frm_Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = 0;
        }
    }
}
