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
    public partial class frm_Narration : MetroForm
    {
        public frm_Narration()
        {
            InitializeComponent();
        }

        clsProperties objPro;
        cls_BillDL clsBill;
        DataSet ds;
        int flag;

        public string clientName { get; set; }

        public string businessName { get; set; }

        public string service {  get; set; }

        public string amount { get; set; }

        public string workType { get; set; }

        decimal totalAmount = 0;

        public string clientAddress { get; set; }

        private void frm_Narration_Load(object sender, EventArgs e)
        {
            lblClName.Text = clientName;
            lblBusName.Text = businessName;
            lblAmt.Text = amount;
            lblBillAbt.Text = service;
            lblDesc.Text = workType;    
            lblAddress.Text = clientAddress;
            
            clsBill = new cls_BillDL();
            flag = clsBill.deleteDataFromBillTable();
            flag = 0;
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            objPro = new clsProperties();
            clsBill = new cls_BillDL();

            objPro.billClientName = lblClName.Text;
            objPro.billBusinessName = lblBusName.Text;
            objPro.billClientAddress = lblAddress.Text;
            objPro.billAmount = lblAmt.Text;
            objPro.billTotalAmount = txtAmount.Text;
            objPro.billService = lblBillAbt.Text;
            objPro.billWorkType = lblDesc.Text;
            objPro.billNarration = txtNarration.Text;

            flag = clsBill.saveBillData(objPro);

            if(flag == 1)
            {
                flag = clsBill.saveInvoiceData(objPro);
            }

            clsBill = new cls_BillDL();
            ds = new DataSet();

            ds = clsBill.getInvoiceNumber();

            frm_Bill bill = new frm_Bill();

            bill.name = lblClName.Text;
            bill.invoiceNo = ds.Tables[0].Rows[0]["invoiceNo"].ToString();

            bill.Show();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
