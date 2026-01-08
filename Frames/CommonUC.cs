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

namespace Tax_Consultant_25.Frames
{
    public partial class CommonUC : UserControl
    {

        public CommonUC()
        {
            InitializeComponent();
        }

        DataSet ds, ds2;
        DataTable dt;
        cls_ClientsDL clients;
        clsProperties objPro;
        cls_ClientUserPassDL user;

        public EventHandler<FormDataInfoEventArgs> FormDataInfo;

        public int clId { get; set; }

        public int clientId => clId;

        public string service { get; set; }

        public string BusinessName { get; set; }

        private void CommonUC_Load(object sender, EventArgs e)
        {
            lblService.Text = service;

            BindSearch();

            txtSearch.Focus();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();
                clients = new cls_ClientsDL();
                ds = new DataSet();

                objPro.search = txtSearch.Text;

                ds = clients.searchClientData(objPro);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    clId = Convert.ToInt32(ds.Tables[0].Rows[0]["clientId"].ToString());
                    txtName.Text = ds.Tables[0].Rows[0]["c_Name"].ToString();
                    txtFatherName.Text = ds.Tables[0].Rows[0]["c_FatherName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["c_Address"].ToString();
                    txtPAN.Text = ds.Tables[0].Rows[0]["c_PAN"].ToString();
                    dtpDate.Text = ds.Tables[0].Rows[0]["c_DOB"].ToString();
                    txtUserId.Text = ds.Tables[0].Rows[0]["c_UserId"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["c_EmailId"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["c_Mobile"].ToString();
                    txtPassword.Text = ds.Tables[0].Rows[0]["c_Password"].ToString();
                    txtStatus.Text = ds.Tables[0].Rows[0]["c_Status"].ToString();
                    txtAdharNo.Text = ds.Tables[0].Rows[0]["c_AdharNo"].ToString();
                    txtBusinessName.Text = ds.Tables[0].Rows[0]["c_BusinessName"].ToString();

                    objPro.clientGender = ds.Tables[0].Rows[0]["c_Gender"].ToString();
                    objPro.clientMarritialStatus = ds.Tables[0].Rows[0]["c_MarritialStautus"].ToString();
                    objPro.clientResidencial = ds.Tables[0].Rows[0]["c_Residencial"].ToString();

                    if (objPro.clientGender == "Male")
                    {
                        rbtnMale.Checked = true;
                    }
                    else
                    {
                        rbtnFemale.Checked = true;
                    }

                    if (objPro.clientMarritialStatus == "UnMarried")
                    {
                        rbtnMarried.Checked = true;
                    }
                    else
                    {
                        rbtnUnMarried.Checked = true;
                    }

                    if (objPro.clientResidencial == "Indian")
                    {
                        rbtnIndian.Checked = true;
                    }
                    else
                    {
                        rbtnNonIndian.Checked = true;
                    }

                    ds = null;

                    ds = new DataSet();
                    user = new cls_ClientUserPassDL();

                    objPro.clientID = clId;
                    objPro.workService = lblService.Text;

                    ds = user.getClientUsernamePasword(objPro);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtUserId.Text = ds.Tables[0].Rows[0]["clientUsername"].ToString();
                        txtPassword.Text = ds.Tables[0].Rows[0]["clientPassword"].ToString();
                    }
                    else
                    {
                        txtUserId.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                    }

                    FormDataInfo?.Invoke(this, new FormDataInfoEventArgs
                    {
                        clientName = txtName.Text,
                        Username = txtUserId.Text,
                        Password = txtPassword.Text
                    });

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BindSearch()
        {
            try
            {
                ds = new DataSet();
                clients = new cls_ClientsDL();
                ds = clients.bindClientsData();

                AutoCompleteStringCollection autoList = new AutoCompleteStringCollection();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        autoList.Add(ds.Tables[0].Rows[i]["c_Name"].ToString());
                        autoList.Add(ds.Tables[0].Rows[i]["c_Mobile"].ToString());
                    }

                    this.txtSearch.AutoCompleteCustomSource = autoList;
                    txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ALLINONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ClearControls()
        {
            //CLIENT CLEAR
             txtSearch.Clear();
             txtName.Clear();
             txtFatherName.Clear();
             txtBusinessName.Clear();
             txtStatus.Clear();
             txtAddress.Clear();
             txtAdharNo.Clear();
             txtPAN.Clear();
             dtpDate.Text = DateTime.Now.ToString(); 
             txtUserId.Clear();
             txtEmail.Clear();
             txtMobile.Clear();
             txtPassword.Clear(); 
        }
    }
}
