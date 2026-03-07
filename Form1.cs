using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using Tax_Consultant_25.Frames;
namespace Tax_Consultant_25
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string role { get; set; }

        public string empName { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            lblTime.Text = "Time : " + DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = "Date : " + DateTime.Now.ToString("dd'/'MM'/'yyyy");

            // ALL EMPLOYEE AND ADMIN ENABLE / DISABLE BUTTONS/TXTBOXES FROM HERE

            if (role == "User")
            {
                pnlMainForm.Controls.Clear();
                ucShowEmployeeWork uc = new ucShowEmployeeWork();
                uc.Dock = DockStyle.Fill;
                uc.EMPLOYEENAME = empName;
                uc.ROLE = role;
                pnlMainForm.Controls.Add(uc);
            }
            else
            {
                pnlMainForm.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Time : " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        public void switchControl(UserControl newControl)
        {
            pnlMainForm.Controls.Clear();
            newControl.Dock = DockStyle.Fill;
            pnlMainForm.Controls.Add(newControl);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pctGST_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucGST ucGST = new ucGST();
            ucGST.Dock = DockStyle.Fill;
            ucGST.ROLE = role;
            ucGST.EMPLOYEENAME = empName;
            pnlMainForm.Controls.Add(ucGST);
        }

        private void pctIncomeTax_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucAllInOne ucAllInOne = new ucAllInOne();
            ucAllInOne.Dock = DockStyle.Fill;
            ucAllInOne.ROLE = role;
            ucAllInOne.EMPLOYEENAME = empName;
            pnlMainForm.Controls.Add(ucAllInOne);
        }

        private void pctAccounting_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucAccounting acc = new ucAccounting();
            acc.Dock = DockStyle.Fill;
            acc.ROLE = role;
            acc.EMPLOYEENAME = empName;
            pnlMainForm.Controls.Add(acc);
        }

        private void pctShopAct_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucShopAct sp = new ucShopAct();
            sp.Dock = DockStyle.Fill;
            sp.ROLE = role;
            sp.EMPLOYEENAME = empName; 
            pnlMainForm.Controls.Add(sp);
        }

        private void pctUdyam_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucUdyam udyam = new ucUdyam();
            udyam.Dock = DockStyle.Fill;
            udyam.ROLE = role;
            udyam.EMPLOYEENAME = empName;
            pnlMainForm.Controls.Add(udyam);
        }

        private void pctTDS_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucTDS td = new ucTDS();
            td.Dock = DockStyle.Fill;
            td.ROLE = role;
            td.EMPLOYEENAME = empName;
            pnlMainForm.Controls.Add(td);
        }

        private void pctPAN_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucPAN pan = new ucPAN();
            pan.Dock = DockStyle.Fill;
            pan.ROLE = role;
            pan.EMPLOYEENAME = empName;
            pnlMainForm.Controls.Add(pan);
        }

        private void pctPTEC_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucPtecPtrc ptec = new ucPtecPtrc();
            ptec.Dock = DockStyle.Fill;
            ptec.ROLE = role;
            ptec.EMPLOYEENAME = empName;
            pnlMainForm.Controls.Add(ptec);

        }

        private void pctAllInOne_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucAllOne one = new ucAllOne();
            one.Dock = DockStyle.Fill;
            one.ROLE = role;
            one.EMPLOYEENAME = empName;
            pnlMainForm.Controls.Add(one);
        }

        private void pctReports_Click(object sender, EventArgs e)
        {
            if(role == "User")
            {

            }
            else
            {
                //pnlMainForm.Controls.Clear();
                //ucReports reports = new ucReports();
                //reports.Dock = DockStyle.Fill;
                //pnlMainForm.Controls.Add(reports);
            }

        }

        private void pctClientManager_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            upAddClients client = new upAddClients();
            client.Dock = DockStyle.Fill;
            pnlMainForm.Controls.Add(client);
        }

        private void pctShowEmpWork_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucShowEmployeeWork emp = new ucShowEmployeeWork();
            emp.Dock = DockStyle.Fill;
            emp.ROLE = role;
            emp.EMPLOYEENAME = empName;
            pnlMainForm.Controls.Add(emp);
        }

        private void pctAddEmployee_Click(object sender, EventArgs e)
        {

            if(role == "User")
            {

            }
            else
            {
                pnlMainForm.Controls.Clear();
                ucAddEmployee uc = new ucAddEmployee();
                pnlMainForm.BackgroundImage = null;
                pnlMainForm.Controls.Add(uc);
                CenterUserForm(uc, pnlMainForm);
            }

        }

        private void CenterUserForm(UserControl uc1, Panel panel)
        {
            int x = (panel.Width - uc1.Width) / 2;
            int y = (panel.Height - uc1.Height) / 2;

            uc1.Location = new Point(x, y);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Clear();
            ucEnquiry uc = new ucEnquiry();
            // uc.Dock = DockStyle.Fill;
            pnlMainForm.BackgroundImage = null;
            pnlMainForm.Controls.Add(uc);
            CenterUserForm(uc, pnlMainForm);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
