using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25.Frames
{
    public partial class ucShowReport : UserControl
    {
        public ucShowReport()
        {
            InitializeComponent();
        }

        public int rptId { get; set; }

        public string title { get; set; }

        string year, month;

        string fromDate;
        string uptoDate;

        cls_ReportsDL report;
        DataSet ds;
        DataTable dt;

        private void ucShowReport_Load(object sender, EventArgs e)
        {
            lblIncomeYear.Visible = false;
            txtIncomeYear.Visible = false;
            txtFromDate.Visible = false;
            txtupToDate.Visible = false;
            lblFromDate.Visible = false;
            lblUptoDate.Visible = false;
            lblMonth.Visible = false;
            cmbMonth.Visible = false;

            if (rptId == 1)
            {
                lblService.Text = title;
            }
            else if (rptId == 2)
            {
                lblService.Text = title;
                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
            }
            else if (rptId == 3)
            {
                lblService.Text = title;
                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
            }
            else if (rptId == 4)
            {
                lblService.Text = title;
            }
            else if (rptId == 5)
            {
                lblService.Text = title;
                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
            }
            else if (rptId == 6)
            {
                lblService.Text = title;
            }
            else if (rptId == 7)
            {
                lblService.Text = title;
            }
            else if (rptId == 8)
            {
                lblService.Text = title;
            }
            else if (rptId == 9)
            {
                lblService.Text = title;
                lblMonth.Visible = true;
                cmbMonth.Visible = true;
                cmbMonth.SelectedIndex = 0;
            }
            else if (rptId == 10)
            {
                lblService.Text = title;
            }
            else if (rptId == 11)
            {
                lblService.Text = title;
            }
            else 
            {
                lblService.Text = title;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                //CLIENTS REPORT
                if(rptId == 1)
                {
                    this.reportViewer1.Refresh();
                  
                    report = new cls_ReportsDL();
                    ds = report.showClients();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptClients.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //INCOME TAX REPORT
                if (rptId == 2)
                {
                    this.reportViewer1.Refresh();
                    year = txtIncomeYear.Text;

                    report = new cls_ReportsDL();
                    ds = report.showIncomeTax("INCOME TAX", year);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptIncomeTax.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                       

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }

                }

                //ACCOUNTING REPORT
                if (rptId == 3)
                {
                    this.reportViewer1.Refresh();
                    year = txtIncomeYear.Text;

                    report = new cls_ReportsDL();
                    ds = report.showAccounting(year);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptAccounting.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //PAN/TAN REPORT
                if (rptId == 4)
                {
                    this.reportViewer1.Refresh();
                    year = txtIncomeYear.Text;

                    report = new cls_ReportsDL();
                    ds = report.showPanTan();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptPanTan.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //PTEC/PTRC REPORT
                if (rptId == 5)
                {
                    this.reportViewer1.Refresh();
                    year = txtIncomeYear.Text;

                    report = new cls_ReportsDL();
                    ds = report.showPtecPtrc("PTEC / PTRC", year);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptPtecPtrc.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //SHOPACT REPORT
                if (rptId == 6)
                {
                    this.reportViewer1.Refresh();

                    report = new cls_ReportsDL();
                    ds = report.showShopAct("SHOPACT");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptShopAct.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //UDYAM REPORT
                if (rptId == 7)
                {
                    this.reportViewer1.Refresh();

                    report = new cls_ReportsDL();
                    ds = report.showUdyam("UDYAM");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptUdyam.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //TDS REPORT
                if(rptId == 8)
                {
                    this.reportViewer1.Refresh();

                    report = new cls_ReportsDL();
                    ds = report.showTDS("TDS");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptTDS.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //GST REPORT
                if(rptId == 9)
                {
                    this.reportViewer1.Refresh();
                    month = cmbMonth.Text;

                    report = new cls_ReportsDL();
                    ds = report.showGST("GST", month);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptGST.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //ALL IN ONE REPORT
                if(rptId == 10)
                {
                    this.reportViewer1.Refresh();
                    month = cmbMonth.Text;

                    report = new cls_ReportsDL();
                    ds = report.showAllInOne("ALL IN ONE");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptAllInOne.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //INVOICES REPORT
                if(rptId == 11)
                {
                    this.reportViewer1.Refresh();
                    month = cmbMonth.Text;

                    report = new cls_ReportsDL();
                    ds = report.showInvoices();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptInvoices.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

                //EMPLOYEE REPORT
                if(rptId == 12)
                {
                    this.reportViewer1.Refresh();
                    month = cmbMonth.Text;

                    report = new cls_ReportsDL();
                    ds = report.showEmployee();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptEmployee.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                        reportViewer1.LocalReport.DataSources.Add(rds);
                        rds.Value = dt;

                        this.reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found...");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
