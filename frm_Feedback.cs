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
    public partial class frm_Feedback : MetroForm
    {
        public frm_Feedback()
        {
            InitializeComponent();
        }

        clsProperties objPro;
        cls_FeedbackDL feedbackDL;
        DataSet ds;

        int flag = 0;

        public string name { get; set; }

        public string service { get; set; }

        public string mobile { get; set; }

        public int enqId { get; set; }

        private void frm_Feedback_Load(object sender, EventArgs e)
        {
            txtName.Text = name;
            txtMobile.Text = mobile;
            txtService.Text = service;

            show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFeedback.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtFeedback.Text ==  string.Empty)
            {
                MessageBox.Show("Enter Feedback...");
                return;
            }

            objPro = new clsProperties();

            objPro.feedbackEnqID = enqId;   
            objPro.feedbackName = txtName.Text;
            objPro.feedbackService = txtService.Text;
            objPro.feedbackMobile = txtMobile.Text;
            objPro.feedbackDate = dtpDate.Value;
            objPro.feedbackGiven = txtFeedback.Text;

            feedbackDL = new cls_FeedbackDL();
            flag = feedbackDL.saveData(objPro);

            if(flag == 1)
            {
                MessageBox.Show("Record Saved...");
                show();
            }
            
        }

        private void show()
        {
            objPro = new clsProperties();


            objPro.feedbackEnqID = enqId;

            feedbackDL = new cls_FeedbackDL();
            ds = feedbackDL.ShowData(objPro);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvFeedback.DataSource = ds.Tables[0];

                dgvFeedback.Columns["serial"].Visible = false;
            }
        }

        private void dgvFeedback_SelectionChanged(object sender, EventArgs e)
        {
            dgvFeedback.ClearSelection();
        }
    }
}
