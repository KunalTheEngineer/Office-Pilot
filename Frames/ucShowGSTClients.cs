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
    public partial class ucShowGSTClients : UserControl
    {
        public ucShowGSTClients()
        {
            InitializeComponent();
        }

        cls_GSTClients gst;
        DataSet ds, ds1;
        Form1 mainForm;
        ucGST gs;
        cls_Query query;

        List<int> filledClients = new List<int>();
        string selectedType;

        private void ucShowGSTClients_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
        }

        private void dgvGSTClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvGSTClients.Columns["btnFill"].Index)
            {
                mainForm = this.FindForm() as Form1;

                ucShowGSTClients clients = new ucShowGSTClients();

                if (mainForm != null)
                {
                    gs = new ucGST();

                    if (dgvGSTClients.Columns[e.ColumnIndex].Name == "btnFill")
                    {
                        var row = dgvGSTClients.Rows[e.RowIndex];

                        if (row.DefaultCellStyle.BackColor == Color.LightGreen)
                        {

                            gs.clientFilled = 1;

                            //MessageBox.Show("Client Already Filled...!", "GST CLIENTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return;
                        }
                        else
                        {
                            gs.clientFilled = 0;
                        }
                    }

                    gs.clientName = dgvGSTClients.Rows[e.RowIndex].Cells[1].Value.ToString();
                    gs.gstNumber = dgvGSTClients.Rows[e.RowIndex].Cells[2].Value.ToString();
                    gs.gstUsername = dgvGSTClients.Rows[e.RowIndex].Cells[3].Value.ToString();
                    gs.gstPassword = dgvGSTClients.Rows[e.RowIndex].Cells[4].Value.ToString();
                    gs.clientId = Convert.ToInt32(dgvGSTClients.Rows[e.RowIndex].Cells[5].Value.ToString());

                    gs.gstType = dgvGSTClients.Rows[e.RowIndex].Cells[7].Value.ToString();
                    gs.Month = dgvGSTClients.Rows[e.RowIndex].Cells[8].Value.ToString();

                    if (gs.gstUsername == string.Empty && gs.gstPassword == string.Empty)
                    {
                        gs.present = 0;
                    }
                    else
                    {
                        gs.present = 1;
                    }

                    gs.OnCloseFill += (s, ev) =>
                    {
                        // Mark client as filled
                        if (!filledClients.Contains(gs.clientId))
                            filledClients.Add(gs.clientId);

                        // Reload DataGridView form
                        mainForm.switchControl(clients);


                    };

                    mainForm.switchControl(gs);


                }
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedType = cmbType.SelectedItem.ToString();

            if (selectedType == "Monthly")
            {
                gst = new cls_GSTClients();
                ds = new DataSet();

                ds = gst.LoadMonthlyClientsData();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvGSTClients.DataSource = ds.Tables[0];

                    dgvGSTClients.Columns["c_GSTNo"].Visible = false;
                    dgvGSTClients.Columns["clientUsername"].Visible = false;
                    dgvGSTClients.Columns["clientPassword"].Visible = false;
                    dgvGSTClients.Columns["clientId"].Visible = false;
                    dgvGSTClients.Columns["c_GSTType"].Visible = false;
                }
            }
            else
            {
                gst = new cls_GSTClients();
                ds = new DataSet();

                ds = gst.LoadQuartelyClientsData();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvGSTClients.DataSource = ds.Tables[0];

                    dgvGSTClients.Columns["c_GSTNo"].Visible = false;
                    dgvGSTClients.Columns["clientUsername"].Visible = false;
                    dgvGSTClients.Columns["clientPassword"].Visible = false;
                    dgvGSTClients.Columns["clientId"].Visible = false;
                    dgvGSTClients.Columns["c_GSTType"].Visible = false;
                }
                else
                {
                    //MessageBox.Show("NO QUARTELY GST CLIENTS AVAILABLE !", "GST CLIENTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvGSTClients.DataSource = ds.Tables[0];
                    return;
                }

            }
        }

        private void dgvGSTClients_SelectionChanged(object sender, EventArgs e)
        {
            dgvGSTClients.ClearSelection();
        }

        private void dgvGSTClients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ShowGSTFilledClients();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            mainForm = this.FindForm() as Form1;

            gs = new ucGST();
            ucShowGSTClients clients = new ucShowGSTClients();

            gs.OnCloseFill += (s, ev) =>
            {
                // Mark client as filled
                if (!filledClients.Contains(gs.clientId))
                    filledClients.Add(gs.clientId);

                // Reload DataGridView form
                mainForm.switchControl(clients);


            };

            mainForm.switchControl(gs);
        }

        private void ShowGSTFilledClients()
        {
            query = new cls_Query();
            ds1 = new DataSet();

            ds1 = query.FinishedGSTClients();

            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            foreach (DataGridViewRow row in dgvGSTClients.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string client = row.Cells["ClientName"].Value?.ToString();
                string returntype = row.Cells["ReturnType"].Value?.ToString();
                string service = "GST";

                var gstRow = ds1.Tables[0].AsEnumerable().FirstOrDefault(r =>
                r.Field<string>("clientName") == client &&
                r.Field<string>("service") == service &&
                r.Field<string>("ReturnType") == returntype &&
                r.Field<int>("Month") == currentMonth &&
                r.Field<int>("Year") == currentYear
                );

                bool isAddedGST = false;

                if (gstRow != null)
                {
                    object val = gstRow["IsAddedToGST"];
                    if (val != DBNull.Value && int.TryParse(val.ToString(), out int parsed))
                    {
                        isAddedGST = parsed == 1;
                    }
                }

                row.DefaultCellStyle.BackColor = isAddedGST ? Color.LightGreen : DefaultBackColor;


            }
        }
    }
}
