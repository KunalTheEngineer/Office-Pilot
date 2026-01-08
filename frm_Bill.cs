using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
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
    public partial class frm_Bill : MetroForm
    {
        public frm_Bill()
        {
            InitializeComponent();
        }

        cls_BillDL bill;
        DataSet ds;
        DataTable dt;

        public string name { get; set; }

        public string invoiceNo { get; set; }

        private void frm_Bill_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.Refresh();
           
            bill = new cls_BillDL();
            ds = new DataSet();

            ds = bill.getBillData();
            
            if (ds.Tables[0].Rows.Count > 0)
            {

                dt = new DataTable();
                dt = ds.Tables[0];

                reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Bills.Invoice.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                reportViewer1.LocalReport.DataSources.Add(rds);
                rds.Value = dt;

                ReportParameter inNo = new ReportParameter("invoiceNo", invoiceNo);
                this.reportViewer1.LocalReport.SetParameters(inNo);


                this.reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("No Records Found...");
            }
        }

    }
}
