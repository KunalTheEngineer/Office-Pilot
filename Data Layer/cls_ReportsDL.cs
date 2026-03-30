using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace Tax_Consultant_25.Data_Layer
{
    internal class cls_ReportsDL
    {
        public string fromDate {  get; set; }

        public string uptoDate { get; set; }

        #region COMMON SQL OBJECTS FOR REPORTS DL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public int flag { get; set; }

        #endregion

        internal DataSet showIncomeTax(string status, string year, string monthName)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@year", year);
                objCmd.Parameters.AddWithValue("@status", status);
                objCmd.Parameters.AddWithValue("@monthName", monthName);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showAccounting(string accyear, string status)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objCmd.Parameters.AddWithValue("@year", accyear);
                objCmd.Parameters.AddWithValue("@status", status);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showPanTan(string status)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 7);
                objCmd.Parameters.AddWithValue("@status", status);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showPtecPtrc(string status, string year)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 8);
                objCmd.Parameters.AddWithValue("@status", status);
                objCmd.Parameters.AddWithValue("@year", year);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showShopAct(string status)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 4);
                objCmd.Parameters.AddWithValue("@status", status);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showUdyam(string status)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 5);
                objCmd.Parameters.AddWithValue("@status", status);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showTDS(string status, string monthName, string year)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 6);
                objCmd.Parameters.AddWithValue("@status", status);
                objCmd.Parameters.AddWithValue("@year", year);
                objCmd.Parameters.AddWithValue("@monthName", monthName);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showGST(string status, string year, string gstType, string monthName)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@status", status);
                objCmd.Parameters.AddWithValue("@monthName", monthName);
                objCmd.Parameters.AddWithValue("@gstType", gstType);
                objCmd.Parameters.AddWithValue("@year", year);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }
         
        internal DataSet showAllInOne(string status, string year)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 9);
                objCmd.Parameters.AddWithValue("@status", status);
                objCmd.Parameters.AddWithValue("@year", year);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showInvoices()
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 10);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showClients()
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 10);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showEmployee(string empType)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 11);
                objCmd.Parameters.AddWithValue("@empType", empType);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet AllClientReport(string status, string month, int year, string clientName, int clientId)
        {
            objDs = new DataSet();

            try
            {
               
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Reports";
                objCmd.Parameters.AddWithValue("@intMode", 12);
                objCmd.Parameters.AddWithValue("@status", status);
                objCmd.Parameters.AddWithValue("@monthName", month);
                objCmd.Parameters.AddWithValue("@intYear", year);
                //objCmd.Parameters.AddWithValue("@clientID", clientId);
                //objCmd.Parameters.AddWithValue("@clientName", clientName);
                // ClientId
                if (clientId == 0)
                    objCmd.Parameters.AddWithValue("@clientId", DBNull.Value);
                else
                    objCmd.Parameters.AddWithValue("@clientId", clientId);

                // ClientName
                if (string.IsNullOrWhiteSpace(clientName))
                    objCmd.Parameters.AddWithValue("@clientName", DBNull.Value);
                else
                    objCmd.Parameters.AddWithValue("@clientName", clientName);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_REPORTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }
    }
}
