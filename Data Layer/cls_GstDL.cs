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
    internal class cls_GstDL
    {

        #region COMMON SQL OBJECTS FOR GST DL

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
                objCmd.CommandText = "usp_GST";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@g_Service", objPro.gstService);
                objCmd.Parameters.AddWithValue("@g_InputDate", objPro.gstInputDate);
                objCmd.Parameters.AddWithValue("@g_TradeName", objPro.gstTradeName);
                objCmd.Parameters.AddWithValue("@g_DueDate", objPro.gstDueDate);
                objCmd.Parameters.AddWithValue("@g_TaskName", objPro.gstTaskName);
                objCmd.Parameters.AddWithValue("@g_AllocatedTo", objPro.gstAllocatedTo);
                objCmd.Parameters.AddWithValue("@g_RecurringTask", objPro.gstRecurringTask);
                objCmd.Parameters.AddWithValue("@g_Periodicity", objPro.gstPeriodicity);
                objCmd.Parameters.AddWithValue("@g_Period", objPro.gstPeriod);
                objCmd.Parameters.AddWithValue("@g_FinancialYear", objPro.gstFinancialYear);
                objCmd.Parameters.AddWithValue("@g_Status", objPro.gstStatus);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_GST_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_GST";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@g_Service", objPro.gstService);
                objCmd.Parameters.AddWithValue("@g_InputDate", objPro.gstInputDate);
                objCmd.Parameters.AddWithValue("@g_TradeName", objPro.gstTradeName);
                objCmd.Parameters.AddWithValue("@g_DueDate", objPro.gstDueDate);
                objCmd.Parameters.AddWithValue("@g_TaskName", objPro.gstTaskName);
                objCmd.Parameters.AddWithValue("@g_AllocatedTo", objPro.gstAllocatedTo);
                objCmd.Parameters.AddWithValue("@g_RecurringTask", objPro.gstRecurringTask);
                objCmd.Parameters.AddWithValue("@g_Periodicity", objPro.gstPeriodicity);
                objCmd.Parameters.AddWithValue("@g_Period", objPro.gstPeriod);
                objCmd.Parameters.AddWithValue("@g_FinancialYear", objPro.gstFinancialYear);
                objCmd.Parameters.AddWithValue("@g_Status", objPro.gstStatus);
                objCmd.Parameters.AddWithValue("@gstId", objPro.gstId);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_GST_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }

        internal DataSet show(string ROLE, string EMPLOYEENAME)
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand(); ;
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_GST";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objCmd.Parameters.AddWithValue("@g_AllocatedTo", EMPLOYEENAME);
                objCmd.Parameters.AddWithValue("@g_Service", "GST");
                objCmd.Parameters.AddWithValue("@Role", ROLE);
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
