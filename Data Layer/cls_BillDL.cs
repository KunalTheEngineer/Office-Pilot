using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tax_Consultant_25.Data_Layer
{
    internal class cls_BillDL
    {
        #region COMMON SQL OBJECTS FOR BILL DL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public DataTable dt { get; set; }

        public int flag { get; set; }

        #endregion

        internal int saveBillData(clsProperties objPro)
        {
            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_Bill";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientName", objPro.billClientName);
                objCmd.Parameters.AddWithValue("@businessName", objPro.billBusinessName);
                objCmd.Parameters.AddWithValue("@service", objPro.billService);
                objCmd.Parameters.AddWithValue("@workType", objPro.billWorkType);
                objCmd.Parameters.AddWithValue("@amount", objPro.billAmount);
                objCmd.Parameters.AddWithValue("@totalAmount", objPro.billTotalAmount);
                objCmd.Parameters.AddWithValue("@narration", objPro.billNarration);
                objCmd.Parameters.AddWithValue("@clientAddress", objPro.billClientAddress);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_BUSINESS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }

        internal int saveInvoiceData(clsProperties objPro)
        {
            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_Bill";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 4);
                objCmd.Parameters.AddWithValue("@clientName", objPro.billClientName);
                objCmd.Parameters.AddWithValue("@businessName", objPro.billBusinessName);
                objCmd.Parameters.AddWithValue("@service", objPro.billService);
                objCmd.Parameters.AddWithValue("@workType", objPro.billWorkType);
                objCmd.Parameters.AddWithValue("@amount", objPro.billAmount);
                objCmd.Parameters.AddWithValue("@totalAmount", objPro.billTotalAmount);
                objCmd.Parameters.AddWithValue("@narration", objPro.billNarration);
                objCmd.Parameters.AddWithValue("@clientAddress", objPro.billClientAddress);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_BUSINESS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }

        internal int deleteDataFromBillTable()
        {
            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_Bill";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 3);
                
                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_BUSINESS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }

        internal DataSet getBillData()
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Bill";
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_BUSINESS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet getInvoiceNumber()
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Bill";
                objCmd.Parameters.AddWithValue("@intMode", 5);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_BUSINESS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }
    }
}
