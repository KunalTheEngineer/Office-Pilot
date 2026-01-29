using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tax_Consultant_25.Data_Layer
{
    internal class cls_ShopActDL
    {
        #region COMMON SQL OBJECTS FOR SHOPACT DL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public DataTable dt { get; set; }

        public int flag { get; set; }

        #endregion

        internal int saveData(clsProperties objPro)
        {
            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_ShopAct";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@s_InputDate", objPro.shopActInputDate);
                objCmd.Parameters.AddWithValue("@s_TradeName", objPro.shopActTradeName);
                objCmd.Parameters.AddWithValue("@s_AllocatedTo", objPro.shopActAllocatedEmp);
                objCmd.Parameters.AddWithValue("@s_TaskName", objPro.shopActTaskName);
                objCmd.Parameters.AddWithValue("@s_DueDate", objPro.shopActDueDate);
                objCmd.Parameters.AddWithValue("@s_Fees", objPro.shopActFees);
                objCmd.Parameters.AddWithValue("@s_FeeStatus", objPro.shopActFeeStatus);
                objCmd.Parameters.AddWithValue("@s_Status", objPro.shopActStatus);
                objCmd.Parameters.AddWithValue("@s_Description", objPro.shopActDescription);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_SHOPACT_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }

        internal int updateData(clsProperties objPro)
        {
            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_ShopAct";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@s_InputDate", objPro.shopActInputDate);
                objCmd.Parameters.AddWithValue("@s_AllocatedTo", objPro.shopActAllocatedEmp);
                objCmd.Parameters.AddWithValue("@s_TaskName", objPro.shopActTaskName);
                objCmd.Parameters.AddWithValue("@s_DueDate", objPro.shopActDueDate);
                objCmd.Parameters.AddWithValue("@s_Fees", objPro.shopActFees);
                objCmd.Parameters.AddWithValue("@s_FeeStatus", objPro.shopActFeeStatus);
                objCmd.Parameters.AddWithValue("@s_Status", objPro.shopActStatus);
                objCmd.Parameters.AddWithValue("@s_Description", objPro.shopActDescription);
                objCmd.Parameters.AddWithValue("@shopActId", objPro.shopActId);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_SHOPACT_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }

        internal DataSet showData()
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();;
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_ShopAct";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_SHOPACT_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

    }
}
