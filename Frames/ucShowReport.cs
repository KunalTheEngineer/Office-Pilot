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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tax_Consultant_25.Frames
{
    public partial class ucShowReport : UserControl
    {
        public ucShowReport()
        {
            InitializeComponent();
        }

        string STATUS, GSTTYPE, YEAR, MONTHNAME;
        int rptID;

        cls_ReportsDL report;
        DataSet ds;
        DataTable dt;

        private void ucShowReport_Load(object sender, EventArgs e)
        {
            SetReportFilters(cmbReportType.Text);

            cmbReportType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbGSTType.SelectedIndex = 0;
            cmbMonth.SelectedIndex = 0;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                ////CLIENTS REPORT
                //if(rptId == 1)
                //{
                //    this.reportViewer1.Refresh();

                //    report = new cls_ReportsDL();
                //    ds = report.showClients();

                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        dt = new DataTable();
                //        dt = ds.Tables[0];
                //        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptClients.rdlc";
                //        reportViewer1.LocalReport.DataSources.Clear();
                //        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                //        reportViewer1.LocalReport.DataSources.Add(rds);
                //        rds.Value = dt;

                //        this.reportViewer1.LocalReport.Refresh();
                //        reportViewer1.RefreshReport();
                //    }
                //    else
                //    {
                //        MessageBox.Show("No Records Found...");
                //    }
                //}

                //INCOME TAX REPORT
                if (rptID == 2)
                {
                    this.reportViewer1.Refresh();
                    YEAR = txtIncomeYear.Text;
                    STATUS = cmbStatus.Text;
                    MONTHNAME = cmbMonth.Text;

                    report = new cls_ReportsDL();
                    ds = report.showIncomeTax(STATUS, YEAR, MONTHNAME);

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
                if (rptID == 3)
                {
                    this.reportViewer1.Refresh();
                    YEAR = txtIncomeYear.Text;
                    STATUS = cmbStatus.Text;

                    report = new cls_ReportsDL();
                    ds = report.showAccounting(YEAR, STATUS);

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

                //SHOPACT
                if(rptID == 4)
                {
                    this.reportViewer1.Refresh();
                    STATUS = cmbStatus.Text;

                    report = new cls_ReportsDL();
                    ds = report.showShopAct(STATUS);

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

                //UDYAM 
                if(rptID == 5)
                {
                    this.reportViewer1.Refresh();

                    STATUS = cmbStatus.Text;

                    report = new cls_ReportsDL();
                    ds = report.showUdyam(STATUS);

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
                
                //TDS
                if(rptID == 6)
                {
                    this.reportViewer1.Refresh();
                    STATUS = cmbStatus.Text;  
                    MONTHNAME = cmbMonth.Text;
                    YEAR = txtIncomeYear.Text;

                    report = new cls_ReportsDL();
                    ds = report.showTDS(STATUS, MONTHNAME, YEAR);

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

                ////PAN/TAN REPORT
                //if (rptId == 4)
                //{
                //    this.reportViewer1.Refresh();
                //    year = txtIncomeYear.Text;

                //    report = new cls_ReportsDL();
                //    ds = report.showPanTan();

                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        dt = new DataTable();
                //        dt = ds.Tables[0];
                //        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptPanTan.rdlc";
                //        reportViewer1.LocalReport.DataSources.Clear();
                //        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                //        reportViewer1.LocalReport.DataSources.Add(rds);
                //        rds.Value = dt;

                //        this.reportViewer1.LocalReport.Refresh();
                //        reportViewer1.RefreshReport();
                //    }
                //    else
                //    {
                //        MessageBox.Show("No Records Found...");
                //    }
                //}

                ////PTEC/PTRC REPORT
                //if (rptId == 5)
                //{
                //    this.reportViewer1.Refresh();
                //    year = txtIncomeYear.Text;

                //    report = new cls_ReportsDL();
                //    ds = report.showPtecPtrc("PTEC / PTRC", year);

                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        dt = new DataTable();
                //        dt = ds.Tables[0];
                //        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptPtecPtrc.rdlc";
                //        reportViewer1.LocalReport.DataSources.Clear();
                //        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                //        reportViewer1.LocalReport.DataSources.Add(rds);
                //        rds.Value = dt;

                //        this.reportViewer1.LocalReport.Refresh();
                //        reportViewer1.RefreshReport();
                //    }
                //    else
                //    {
                //        MessageBox.Show("No Records Found...");
                //    }
                //}

                

                
                

                ////GST REPORT
                //if(rptId == 9)
                //{
                //    this.reportViewer1.Refresh();
                //    month = cmbMonth.Text;

                //    report = new cls_ReportsDL();
                //    ds = report.showGST("GST", month);

                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        dt = new DataTable();
                //        dt = ds.Tables[0];
                //        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptGST.rdlc";
                //        reportViewer1.LocalReport.DataSources.Clear();
                //        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                //        reportViewer1.LocalReport.DataSources.Add(rds);
                //        rds.Value = dt;

                //        this.reportViewer1.LocalReport.Refresh();
                //        reportViewer1.RefreshReport();
                //    }
                //    else
                //    {
                //        MessageBox.Show("No Records Found...");
                //    }
                //}

                ////ALL IN ONE REPORT
                //if(rptId == 10)
                //{
                //    this.reportViewer1.Refresh();
                //    month = cmbMonth.Text;

                //    report = new cls_ReportsDL();
                //    ds = report.showAllInOne("ALL IN ONE");

                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        dt = new DataTable();
                //        dt = ds.Tables[0];
                //        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptAllInOne.rdlc";
                //        reportViewer1.LocalReport.DataSources.Clear();
                //        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                //        reportViewer1.LocalReport.DataSources.Add(rds);
                //        rds.Value = dt;

                //        this.reportViewer1.LocalReport.Refresh();
                //        reportViewer1.RefreshReport();
                //    }
                //    else
                //    {
                //        MessageBox.Show("No Records Found...");
                //    }
                //}

                ////INVOICES REPORT
                //if(rptId == 11)
                //{
                //    this.reportViewer1.Refresh();
                //    month = cmbMonth.Text;

                //    report = new cls_ReportsDL();
                //    ds = report.showInvoices();

                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        dt = new DataTable();
                //        dt = ds.Tables[0];
                //        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptInvoices.rdlc";
                //        reportViewer1.LocalReport.DataSources.Clear();
                //        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                //        reportViewer1.LocalReport.DataSources.Add(rds);
                //        rds.Value = dt;

                //        this.reportViewer1.LocalReport.Refresh();
                //        reportViewer1.RefreshReport();
                //    }
                //    else
                //    {
                //        MessageBox.Show("No Records Found...");
                //    }
                //}

                ////EMPLOYEE REPORT
                //if(rptId == 12)
                //{
                //    this.reportViewer1.Refresh();
                //    month = cmbMonth.Text;

                //    report = new cls_ReportsDL();
                //    ds = report.showEmployee();

                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        dt = new DataTable();
                //        dt = ds.Tables[0];
                //        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptEmployee.rdlc";
                //        reportViewer1.LocalReport.DataSources.Clear();
                //        ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                //        reportViewer1.LocalReport.DataSources.Add(rds);
                //        rds.Value = dt;

                //        this.reportViewer1.LocalReport.Refresh();
                //        reportViewer1.RefreshReport();
                //    }
                //    else
                //    {
                //        MessageBox.Show("No Records Found...");
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetReportFilters(cmbReportType.Text);
        }

        #region FUNCTIONS

        private void SetReportFilters(string ReportType)
        {
            lblIncomeYear.Visible = false;
            txtIncomeYear.Visible = false;
            lblGSTType.Visible = false;
            cmbGSTType.Visible = false;
            lblMonth.Visible = false;
            cmbMonth.Visible = false;

            if (ReportType == "GST")
            {
                lblGSTType.Visible = true;
                cmbGSTType.Visible = true;

                lblIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;

                rptID = 1;
            }
            else if (ReportType == "INCOME TAX")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
                lblMonth.Visible = true;
                cmbMonth.Visible = true;

                rptID = 2;

            }
            else if (ReportType == "ACCOUNTING")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;

                rptID = 3;
            }
            else if (ReportType == "SHOPACT")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;

                lblIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;

                rptID = 4;
            }
            else if (ReportType == "UDYAM")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;

                lblIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;

                rptID = 5;
            }
            else if (ReportType == "TDS")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;

                lblMonth.Visible = true;
                cmbMonth.Visible = true;
                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;

                rptID = 6;
            }
            else if (ReportType == "PAN/TAN")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;

                rptID = 7;
            }
            else if (ReportType == "PTEC/PTRC")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
            }
            else if (ReportType == "OTHER SERVICES")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
            } 
        }

        #endregion
    }
}
