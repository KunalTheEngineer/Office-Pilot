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
    public partial class upAddClients : UserControl
    {
        public upAddClients()
        {
            InitializeComponent();
        }

        #region CLASS & OBJECTS

        clsProperties objPro;
        cls_ClientsDL client;
        cls_ClientUserPassDL clientUserPassDL;
        DataSet ds, ds1;

        #endregion

        #region VARIABLES
        int flag = 0;
        int clID = 0;

        List<List<TextBox>> textboxGroups = new List<List<TextBox>>();

        int startX = 40;     // left margin
        int startY = 30;     // <-- moved UP
        int gapX = 40;
        int gapY = 8;
        int txtWidth = 217;
        int txtHeight = 29;
        int maxPerRow = 3;
        // ALWAYS 3 textboxes per row
        // ADD 4 boxes

        public int clId { get; set; }

        #endregion

        #region EVENTS

        private void upAddClients_Load(object sender, EventArgs e)
        {
            show();

            cmbStatus.SelectedIndex = 0;
            cmbGSTType.SelectedIndex = 0;

            txtGSTNo.Enabled = false;
            cmbGSTType.Enabled = false;

            BindSearch();

            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.clientName = txtName.Text;
                objPro.clientFatherName = txtFatherName.Text;
                objPro.clientAddress = txtAddress.Text;
                objPro.clientDOB = dtpDOB.Value;
                objPro.clientMobile = txtMobile.Text;
                objPro.clientPAN = txtPan.Text;

                if (rbtnMarried.Checked == true)
                {
                    objPro.clientMarritialStatus = rbtnMarried.Text;
                }
                else
                {
                    objPro.clientMarritialStatus = rbtnUnMarried.Text;
                }

                if (rbtnMale.Checked == true)
                {
                    objPro.clientGender = rbtnMale.Text;
                }
                else
                {
                    objPro.clientGender = rbtnFemale.Text;
                }

                if (rbtnIndian.Checked == true)
                {
                    objPro.clientResidencial = rbtnIndian.Text;
                }
                else
                {
                    objPro.clientResidencial = rbtnNonIndian.Text;
                }

                objPro.clientEmail = txtEmail.Text;
                objPro.clientAdharNo = txtAdharNo.Text;
                objPro.clientBusinessName = txtBusinessName.Text;
                objPro.clientGSTNo = txtGSTNo.Text;
                objPro.clientStatus = cmbStatus.Text;
                objPro.clientGSTtype = cmbGSTType.Text;

                if (chkGST.Checked == true)
                {
                    objPro.isGSTClient = true;
                }
                else
                {
                    objPro.isGSTClient = false;
                }

                client = new cls_ClientsDL();
                flag = client.saveClientsData(objPro);

                ds = new DataSet();
                ds = client.getClientsId(objPro);

                objPro.clientID = Convert.ToInt32(ds.Tables[0].Rows[0]["clientId"].ToString());

                if (flag == 1)
                {
                    var boxes = pnlAddTxt.Controls.OfType<TextBox>().OrderBy(t => t.Top).ThenBy(t => t.Left).ToList();

                    for (int i = 0; i < boxes.Count; i += 3)
                    {
                        string col1 = boxes.Count > i ? boxes[i].Text : "";
                        string col2 = boxes.Count > i + 1 ? boxes[i + 1].Text : "";
                        string col3 = boxes.Count > i + 2 ? boxes[i + 2].Text : "";

                        objPro.workService = col1;
                        objPro.username = col2;
                        objPro.password = col3;

                        clientUserPassDL = new cls_ClientUserPassDL();
                        flag = clientUserPassDL.saveClientUserNamePassword(objPro);
                    }

                    foreach (var txt in boxes)
                    {
                        txt.Clear();
                    }

                    clear();
                    show();
                    BindSearch();

                    int removed = 0;

                    for (int i = pnlAddTxt.Controls.Count - 1; i >= 0; i--)
                    {

                        if (pnlAddTxt.Controls[i] is TextBox txt)
                        {
                            pnlAddTxt.Controls.Remove(txt);
                            txt.Dispose();
                            removed++;
                        }
                    }

                    ReflowTextboxes();

                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_CLIENT_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.clientID = clId;
                objPro.clientName = txtName.Text;
                objPro.clientFatherName = txtFatherName.Text;
                objPro.clientAddress = txtAddress.Text;
                objPro.clientDOB = dtpDOB.Value;
                objPro.clientMobile = txtMobile.Text;
                objPro.clientPAN = txtPan.Text;

                if (rbtnMarried.Checked == true)
                {
                    objPro.clientMarritialStatus = rbtnMarried.Text;
                }
                else
                {
                    objPro.clientMarritialStatus = rbtnUnMarried.Text;
                }

                if (rbtnMale.Checked == true)
                {
                    objPro.clientGender = rbtnMale.Text;
                }
                else
                {
                    objPro.clientGender = rbtnFemale.Text;
                }

                if (rbtnIndian.Checked == true)
                {
                    objPro.clientResidencial = rbtnIndian.Text;
                }
                else
                {
                    objPro.clientResidencial = rbtnNonIndian.Text;
                }

                objPro.clientEmail = txtEmail.Text;
                objPro.clientAdharNo = txtAdharNo.Text;
                objPro.clientBusinessName = txtBusinessName.Text;
                objPro.clientGSTNo = txtGSTNo.Text;
                objPro.clientGSTtype = cmbGSTType.Text;
                objPro.clientStatus = cmbStatus.Text;

                if (chkGST.Checked == true)
                {
                    objPro.isGSTClient = true;
                }
                else
                {
                    objPro.isGSTClient = false;
                }

                client = new cls_ClientsDL();
                flag = client.updateClientsData(objPro);

                if (flag == 1)
                {

                    var boxes = pnlAddTxt.Controls.OfType<TextBox>().OrderBy(t => t.Top).ThenBy(t => t.Left).ToList();

                    clientUserPassDL = new cls_ClientUserPassDL();
                    flag = clientUserPassDL.deleteClientUserPass(objPro);

                    for (int i = 0; i < boxes.Count; i += 3)
                    {
                        string col1 = boxes.Count > i ? boxes[i].Text : "";
                        string col2 = boxes.Count > i + 1 ? boxes[i + 1].Text : "";
                        string col3 = boxes.Count > i + 2 ? boxes[i + 2].Text : "";

                        objPro.workService = col1;
                        objPro.username = col2;
                        objPro.password = col3;

                        clientUserPassDL = new cls_ClientUserPassDL();
                        flag = clientUserPassDL.saveClientUserNamePassword(objPro);
                    }

                    foreach (var txt in boxes)
                    {
                        txt.Clear();
                    }

                    clear();
                    show();

                    int removed = 0;

                    for (int i = pnlAddTxt.Controls.Count - 1; i >= 0; i--)
                    {

                        if (pnlAddTxt.Controls[i] is TextBox txt)
                        {
                            pnlAddTxt.Controls.Remove(txt);
                            txt.Dispose();
                            removed++;
                        }
                    }

                    ReflowTextboxes();

                    return;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ADDCLIENTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();

                objPro.clientID = clID;

                client = new cls_ClientsDL();
                flag = client.deleteClientsData(objPro);

                if (flag == 1)
                {
                    //MessageBox.Show("Record Deleted...");
                    clear();
                    show();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_CLIENT_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void chkGST_CheckedChanged(object sender, EventArgs e)
        {
            bool isGSt = chkGST.Checked;

            txtGSTNo.Enabled = isGSt;
            cmbGSTType.Enabled = isGSt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<TextBox> group = new List<TextBox>();

            for (int i = 0; i < 3; i++)
            {
                TextBox txt = new TextBox();

                txt.Width = txtWidth;
                txt.Height = txtHeight;

                int index = textboxGroups.Count;      // how many exist already

                int row = index / maxPerRow;          // row number
                int col = index % maxPerRow;          // column number

                txt.Left = startX + (col * (txtWidth + gapX));
                txt.Top = startY + (row * (txtHeight + gapY));

                pnlAddTxt.Controls.Add(txt);

                textboxGroups.Add(group);               // store it
            }

            ReflowTextboxes();

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int removed = 0;

            for (int i = pnlAddTxt.Controls.Count - 1; i >= 0; i--)
            {
                if (removed == 3)
                    break;

                if (pnlAddTxt.Controls[i] is TextBox txt)
                {
                    pnlAddTxt.Controls.Remove(txt);
                    txt.Dispose();
                    removed++;
                }
            }

            ReflowTextboxes();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                objPro = new clsProperties();
                client = new cls_ClientsDL();
                ds = new DataSet();

                objPro.search = txtSearch.Text;

                ds = client.searchClientData(objPro);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    clId = Convert.ToInt32(ds.Tables[0].Rows[0]["clientId"].ToString());
                    txtName.Text = ds.Tables[0].Rows[0]["c_Name"].ToString();
                    txtFatherName.Text = ds.Tables[0].Rows[0]["c_FatherName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["c_Address"].ToString();
                    txtPan.Text = ds.Tables[0].Rows[0]["c_PAN"].ToString();
                    dtpDOB.Text = ds.Tables[0].Rows[0]["c_DOB"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["c_EmailId"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["c_Mobile"].ToString();
                    cmbStatus.Text = ds.Tables[0].Rows[0]["c_Status"].ToString();
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
                        rbtnUnMarried.Checked = true;
                    }
                    else
                    {
                        rbtnMarried.Checked = true;
                    }

                    if (objPro.clientResidencial == "Indian")
                    {
                        rbtnIndian.Checked = true;
                    }
                    else
                    {
                        rbtnNonIndian.Checked = true;
                    }

                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["isGSTClient"].ToString()) == true)
                    {
                        chkGST.Checked = true;
                    }
                    else
                    {
                        chkGST.Checked = false;
                    }

                    txtGSTNo.Text = ds.Tables[0].Rows[0]["c_GSTNo"].ToString();
                    cmbGSTType.Text = ds.Tables[0].Rows[0]["c_GSTType"].ToString();

                 //   pnlAddTxt.Controls.Clear();

                    objPro.clientID = clId;
                    objPro.clientName = txtName.Text;

                    clientUserPassDL = new cls_ClientUserPassDL();
                    ds = new DataSet();

                    ds = clientUserPassDL.getClientUsernamePasword(objPro);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string dService = ds.Tables[0].Rows[i]["clientWorkService"].ToString();
                        string dUsername = ds.Tables[0].Rows[i]["clientUsername"].ToString();
                        string dPassword = ds.Tables[0].Rows[i]["clientPassword"].ToString();

                        createTextbox(dService);
                        createTextbox(dUsername);
                        createTextbox(dPassword);
                    }

                }

                ReflowTextboxes();

                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_ADDCLIENTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvClients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvClients.Columns["Column6"].DisplayIndex = dgvClients.Columns.Count - 1;
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            objPro = new clsProperties();

            objPro.rowID = e.RowIndex;

            if (dgvClients.Rows.Count > 0)
            {
                objPro.clientID = Convert.ToInt32(dgvClients.Rows[objPro.rowID].Cells[0].Value.ToString());
                clId = objPro.clientID;
                txtName.Text = dgvClients.Rows[objPro.rowID].Cells[1].Value.ToString();
                objPro.clientName = txtName.Text;
                txtFatherName.Text = dgvClients.Rows[objPro.rowID].Cells[2].Value.ToString();
                txtAddress.Text = dgvClients.Rows[objPro.rowID].Cells[3].Value.ToString();
                dtpDOB.Text = dgvClients.Rows[objPro.rowID].Cells[4].Value.ToString();
                txtMobile.Text = dgvClients.Rows[objPro.rowID].Cells[5].Value.ToString();
                txtPan.Text = dgvClients.Rows[objPro.rowID].Cells[6].Value.ToString();

                if (dgvClients.Rows[objPro.rowID].Cells[7].Value.ToString() == "Married")
                {
                    rbtnMarried.Checked = true;
                }
                else
                {
                    rbtnUnMarried.Checked = true;
                }

                if (dgvClients.Rows[objPro.rowID].Cells[8].Value.ToString() == "Male")
                {
                    rbtnMale.Checked = true;
                }
                else
                {
                    rbtnFemale.Checked = true;
                }

                if (dgvClients.Rows[objPro.rowID].Cells[9].Value.ToString() == "Indian")
                {
                    rbtnIndian.Checked = true;
                }
                else
                {
                    rbtnNonIndian.Checked = true;
                }

                txtEmail.Text = dgvClients.Rows[objPro.rowID].Cells[10].Value.ToString();
                txtAdharNo.Text = dgvClients.Rows[objPro.rowID].Cells[11].Value.ToString();
                txtBusinessName.Text = dgvClients.Rows[objPro.rowID].Cells[12].Value.ToString();
                cmbStatus.Text = dgvClients.Rows[objPro.rowID].Cells[13].Value.ToString();
                txtGSTNo.Text = dgvClients.Rows[objPro.rowID].Cells[14].Value.ToString();
                cmbGSTType.Text = dgvClients.Rows[objPro.rowID].Cells[15].Value.ToString();

                if (Convert.ToBoolean(dgvClients.Rows[objPro.rowID].Cells[16].Value.ToString()) == true)
                {
                    chkGST.Checked = true;
                }
                else
                {
                    chkGST.Checked = false;
                }


                clientUserPassDL = new cls_ClientUserPassDL();
                ds1 = new DataSet();

                ds1 = clientUserPassDL.getClientUsernamePasword(objPro);

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    string dService = ds1.Tables[0].Rows[i]["clientWorkService"].ToString();
                    string dUsername = ds1.Tables[0].Rows[i]["clientUsername"].ToString();
                    string dPassword = ds1.Tables[0].Rows[i]["clientPassword"].ToString();

                    createTextbox(dService);
                    createTextbox(dUsername);
                    createTextbox(dPassword);
                }
            }

            ReflowTextboxes();
        }

        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            dgvClients.ClearSelection();
        }

        #endregion

        #region FUNCTIONS

        private void clear()
        {
            txtName.Clear();
            txtFatherName.Clear();
            txtAddress.Clear();
            dtpDOB.Text = string.Empty;
            txtMobile.Clear();
            txtPan.Clear();
            rbtnMarried.Checked = false;
            rbtnUnMarried.Checked = false;
            rbtnIndian.Checked = false;
            rbtnNonIndian.Checked = false;
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
            txtEmail.Clear();
            txtAdharNo.Clear();
            txtBusinessName.Clear();
            cmbStatus.SelectedIndex = 0;
            txtGSTNo.Clear();
            cmbGSTType.SelectedIndex = 0;
            txtSearch.Clear();

            chkGST.Checked = false;

            flag = 0;
            clID = 0;

            btnSave.Enabled = true;
            show();
        }

        private void show()
        {
            try
            {
                client = new cls_ClientsDL();

                ds = client.ClientsData();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvClients.DataSource = ds.Tables[0];

                    dgvClients.Columns["isGSTClient"].Visible = false;
                    dgvClients.Columns["c_FatherName"].Visible = false;
                    dgvClients.Columns["c_MarritialStautus"].Visible = false;
                    dgvClients.Columns["c_Gender"].Visible = false;
                    dgvClients.Columns["c_Residencial"].Visible = false;
                    dgvClients.Columns["c_GSTNo"].Visible = false;
                    dgvClients.Columns["c_GSTType"].Visible = false;
                    dgvClients.Columns["clientId"].Visible = false;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "UC_CLIENT_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void ReflowTextboxes()
        {
            int index = 0;

            var boxes = pnlAddTxt.Controls
                .OfType<TextBox>()
                .OrderBy(c => c.TabIndex)   // keep creation order
                .ToList();

            foreach (var txt in boxes)
            {
                int row = index / maxPerRow;
                int col = index % maxPerRow;

                txt.Left = startX + (col * (txtWidth + gapX));
                txt.Top = startY + (row * (txtHeight + gapY));

                index++;
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

        private TextBox createTextbox(string value)
        {
            TextBox txt = new TextBox();
            txt.Width = txtWidth;
            txt.Height = txtHeight;
            txt.Text = value;
            pnlAddTxt.Controls.Add(txt);
            return txt;
        }

        #endregion
    }
}

