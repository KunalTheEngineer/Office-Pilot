using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tax_Consultant_25.Frames
{
    public partial class ucReports : UserControl
    {
        public ucReports()
        {
            InitializeComponent();
        }

        Form1 mainForm;
        ucShowReport show;

        private void btnClientReport_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if(mainForm !=  null)
            {
                show = new ucShowReport();
                show.rptId = 1;
                show.title = "Client Report";
                mainForm.switchControl(show);
            }
        }

        private void btnIncomeRpt_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if(mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 2;
                show.title = "Income Tax Report";
                mainForm.switchControl(show);
            }
        }

        private void btnAccoutingRpt_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if(mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 3;
                show.title = "Accounting Report";
                mainForm.switchControl(show);
            }
        }

        private void btnPanTan_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if(mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 4;
                show.title = "PAN/TAN Report";
                mainForm.switchControl(show);
            }
        }

        private void btnPtrcReport_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if (mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 5;
                show.title = "PTEC/PTRC Report";
                mainForm.switchControl(show);
            }
        }

        private void btnShopActRpt_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if (mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 6;
                show.title = "SHOPACT REPORT";
                mainForm.switchControl(show);
            }
            
        }

        private void btnUdyam_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if (mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 7;
                show.title = "UDYAM REPORT";
                mainForm.switchControl(show);
            }
        }

        private void btnTDS_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if (mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 8;
                show.title = "TDS REPORT";
                mainForm.switchControl(show);
            }
        }

        private void btnGST_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if (mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 9;
                show.title = "GST REPORT";
                mainForm.switchControl(show);
            }
        }

        private void btnAllInOne_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if (mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 10;
                show.title = "ALL IN ONE REPORT";
                mainForm.switchControl(show);
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if (mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 11;
                show.title = "INVOICES REPORT";
                mainForm.switchControl(show);
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            if (mainForm != null)
            {
                show = new ucShowReport();
                show.rptId = 12;
                show.title = "EMPLOYEE REPORT";
                mainForm.switchControl(show);   
            }
        }
    }
}
