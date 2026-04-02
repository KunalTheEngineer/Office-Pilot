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

        string STATUS, GSTTYPE, YEAR, MONTHNAME, EMPLOYEE, CLIENTNAME;
        int rptID, INTYEAR, CLIENTID=0;

        cls_ReportsDL report;
        DataSet ds;
        DataTable dt;
        clsProperties objPro;
        cls_ClientsDL client;

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(txtSearch.Text == string.Empty)
            {
                CLIENTID = 0;
                CLIENTNAME = "";
            }
            else
            {
                SearchClient();
            }
        }

        private void ucShowReport_Load(object sender, EventArgs e)
        {
            SetReportFilters(cmbReportType.Text);
            BindSearch();

            cmbReportType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbGSTType.SelectedIndex = 0;
            cmbMonth.SelectedIndex = 0;
            cmbEmployee.SelectedIndex = 0;
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                // GST REPORT
                if(rptID == 1)
                {
                    this.reportViewer1.Refresh();

                    YEAR = txtIncomeYear.Text;
                    STATUS = cmbStatus.Text;
                    MONTHNAME = cmbMonth.Text;
                    GSTTYPE = cmbGSTType.Text;

                    report = new cls_ReportsDL();
                    ds = report.showGST(STATUS, YEAR, GSTTYPE, MONTHNAME);

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

                //PAN/TAN REPORT
                if(rptID == 7)
                {
                    this.reportViewer1.Refresh();

                    STATUS = cmbStatus.Text;

                    report = new cls_ReportsDL();
                    ds = report.showPanTan(STATUS);

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

                ////PTEC/PTRC REPORT
                if (rptID == 8)
                {
                    this.reportViewer1.Refresh();
                    YEAR = txtIncomeYear.Text;
                    STATUS = cmbStatus.Text;

                    report = new cls_ReportsDL();
                    ds = report.showPtecPtrc(STATUS, YEAR);

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

                // OTHER SERVCES
                if(rptID == 9)
                {
                    this.reportViewer1.Refresh();

                    STATUS = "ALL ONE";
                    YEAR = txtIncomeYear.Text;

                    report = new cls_ReportsDL();
                    ds = report.showAllInOne(STATUS, YEAR);

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

                // CLIENTS REPORT
                if(rptID == 10)
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

                // EMPLOYEES REPORT
                if (rptID == 11)
                {
                    this.reportViewer1.Refresh();
                    EMPLOYEE = cmbEmployee.Text;

                    report = new cls_ReportsDL();
                    ds = report.showEmployee(EMPLOYEE);

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

                // SPECIFIC CLIENT TASK COMPLETED REPORT
                if(rptID == 12)
                {
                    this.reportViewer1.Refresh();

                    STATUS = cmbStatus.Text;

                    MONTHNAME = cmbMonth.Text;
                    INTYEAR = DateTime.Now.Year;

                    report = new cls_ReportsDL();
                    ds = report.AllClientReport(STATUS, MONTHNAME, INTYEAR, CLIENTNAME, CLIENTID);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = new DataTable();
                        dt = ds.Tables[0];
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Tax_Consultant_25.Reports.rptSpecificClient.rdlc";
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

                // INVOICES REPORT
                if(rptID == 13)
                {
                    this.reportViewer1.Refresh();

                    MONTHNAME = cmbMonth.Text;
                    INTYEAR = DateTime.Now.Year;

                    report = new cls_ReportsDL();
                    ds = report.showInvoices(MONTHNAME, INTYEAR);

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
                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
                lblMonth.Visible = true;
                cmbMonth.Visible = true;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;

                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                rptID = 1;
            }
            else if (ReportType == "INCOME TAX")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
                lblMonth.Visible = true;
                cmbMonth.Visible = true;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;

                rptID = 2;

            }
            else if (ReportType == "ACCOUNTING")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;

                rptID = 3;
            }
            else if (ReportType == "SHOPACT")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                lblIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;

                rptID = 4;
            }
            else if (ReportType == "UDYAM")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                lblIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;

                rptID = 5;
            }
            else if (ReportType == "TDS")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                lblMonth.Visible = true;
                cmbMonth.Visible = true;
                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;

                rptID = 6;
            }
            else if (ReportType == "PAN/TAN")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                txtIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;

                rptID = 7;
            }
            else if (ReportType == "PTEC/PTRC")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;

                rptID = 8;
            }
            else if (ReportType == "OTHER SERVICES")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                lblIncomeYear.Visible = true;
                txtIncomeYear.Visible = true;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;

                rptID = 9;
            }
            else if(ReportType == "CLIENTS")
            {
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblStatus.Visible = false;
                cmbStatus.Visible = false;
                lblIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                rptID = 10;
            }
            else if(ReportType == "EMPLOYEES")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;
                lblStatus.Visible = false;
                cmbStatus.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;

                lblEmployee.Visible = true;
                cmbEmployee.Visible = true;

                rptID = 11;
            }
            else if(ReportType == "SPECIFIC CLIENT")
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;    

                lblSearch.Visible = true;
                txtSearch.Visible = true;
                lblStatus.Visible = true;
                cmbStatus.Visible = true;
                lblMonth.Visible = true;
                cmbMonth.Visible = true;

                rptID = 12;
            }
            else
            {
                cmbGSTType.Visible = false;
                lblGSTType.Visible = false;
                lblIncomeYear.Visible = false;
                txtIncomeYear.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                lblSearch.Visible = false;
                txtSearch.Visible = false;
                lblStatus.Visible = false;
                cmbStatus.Visible = false;
               
                lblMonth.Visible = true;
                cmbMonth.Visible = true;

                rptID = 13;
            }
        }

        private void SearchClient()
        {
            try
            {
                objPro = new clsProperties();
                client = new cls_ClientsDL();
                ds = new DataSet();

                objPro.search = !string.IsNullOrWhiteSpace(txtSearch.Text) ? txtSearch.Text.Trim() : txtSearch.Text.Trim();

                ds = client.searchClientTradeName(objPro);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSearch.Text = ds.Tables[0].Rows[0]["c_Name"].ToString();
               //     txtTradeName.Text = ds.Tables[0].Rows[0]["c_BusinessName"].ToString();
                    CLIENTID = Convert.ToInt32(ds.Tables[0].Rows[0]["clientId"].ToString());
                    // businessName = txtTradeName.Text;
                    // clientAddress = ds.Tables[0].Rows[0]["c_Address"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_INCOMETAX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BindSearch()
        {
            try
            {
                ds = new DataSet();
                client = new cls_ClientsDL();
                ds = client.bindClientsData();

                AutoCompleteStringCollection autoList = new AutoCompleteStringCollection();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        autoList.Add(ds.Tables[0].Rows[i]["c_Name"].ToString());
                        autoList.Add(ds.Tables[0].Rows[i]["c_Mobile"].ToString());
                        autoList.Add(ds.Tables[0].Rows[i]["c_BusinessName"].ToString());
                    }

                    this.txtSearch.AutoCompleteCustomSource = autoList;
                    txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    //this.txtTradeName.AutoCompleteCustomSource = autoList;
                    //txtTradeName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //txtTradeName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
