using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25.Frames
{
    public partial class ucEnquiry : UserControl
    {
        public ucEnquiry()
        {
            InitializeComponent();
        }

        clsProperties objPro;
        cls_EnquiryDL enquiryDL;
        DataSet ds;

        int flag = 0;
        int enqId = 0;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if(txtName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "ENQUIRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(txtService.Text == string.Empty)
                {
                    MessageBox.Show("Enter Service", "ENQUIRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if(txtMobile.Text == string.Empty)
                //{
                //    MessageBox.Show("Enter Client Mobile Number", "ENQUIRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                objPro = new clsProperties();

                objPro.enquiryName = txtName.Text;
                objPro.enquiryService = txtService.Text;
                objPro.enquiryMobile = txtMobile.Text;
                objPro.enquiryEmail = txtEmailId.Text;
                objPro.enquiryDate = dtpTime.Value;

                enquiryDL = new cls_EnquiryDL();
                flag = enquiryDL.saveData(objPro);

                if(flag == 1)
                {
                    //MessageBox.Show("Record Saved...");
                    showData();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ENQUIRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showData()
        {
            enquiryDL = new cls_EnquiryDL();
            ds = enquiryDL.ShowData();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvEnquiry.DataSource = ds.Tables[0];
                dgvEnquiry.Columns["enquiryId"].Visible = false;
            }
        }

        private void ucEnquiry_Load(object sender, EventArgs e)
        {
            showData();
            dgvEnquiry.AutoGenerateColumns = false;

            txtName.Focus();
        }

        private void Clear()
        {
            txtName.Clear();
            txtService.Clear();
            txtMobile.Clear();
            txtEmailId.Clear();
            dtpTime.Text = DateTime.Now.ToString();

            btnSave.Enabled = true;
        }

        private void dgvEnquiry_SelectionChanged(object sender, EventArgs e)
        {
            dgvEnquiry.ClearSelection();
        }

        private void dgvEnquiry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            objPro = new clsProperties();

            objPro.rowID = e.RowIndex;  

            if(dgvEnquiry.Rows.Count > 0)
            {
                txtName.Text = dgvEnquiry.Rows[objPro.rowID].Cells[2].Value.ToString();
                txtService.Text = dgvEnquiry.Rows[objPro.rowID].Cells[3].Value.ToString();
                txtMobile.Text = dgvEnquiry.Rows[objPro.rowID].Cells[4].Value.ToString();
                dtpTime.Text = dgvEnquiry.Rows[objPro.rowID].Cells[5].Value.ToString();
                enqId = Convert.ToInt32(dgvEnquiry.Rows[objPro.rowID].Cells[6].Value.ToString());
                txtEmailId.Text = dgvEnquiry.Rows[objPro.rowID].Cells[7].Value.ToString();
            }

            if(e.ColumnIndex == dgvEnquiry.Columns["btnFeedback"].Index)
            {
                frm_Feedback feed = new frm_Feedback();
                feed.name = txtName.Text;
                feed.service = txtService.Text;
                feed.mobile = txtMobile.Text;
                feed.enqId = enqId;
                feed.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == string.Empty)
                {
                    MessageBox.Show("Enter Client Name", "ENQUIRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtService.Text == string.Empty)
                {
                    MessageBox.Show("Enter Service", "ENQUIRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (txtMobile.Text == string.Empty)
                //{
                //    MessageBox.Show("Enter Client Mobile Number", "ENQUIRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                objPro = new clsProperties();

                objPro.enquiryName = txtName.Text;
                objPro.enquiryService = txtService.Text;
                objPro.enquiryMobile = txtMobile.Text;
                objPro.enquiryEmail = txtEmailId.Text;
                objPro.enquiryDate = dtpTime.Value;
                objPro.enquiryId = enqId;

                enquiryDL = new cls_EnquiryDL();
                flag = enquiryDL.updateData(objPro);

                if (flag == 1)
                {
                    //MessageBox.Show("Record Updated...");
                    showData();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ENQUIRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
