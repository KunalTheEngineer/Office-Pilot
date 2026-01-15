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
    internal class cls_PtecDL
    {
        #region COMMON SQL OBJECTS FOR PTEC DL

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
                objCmd.CommandText = "usp_Ptec";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@p_TradeName", objPro.ptecTradeName);
                objCmd.Parameters.AddWithValue("@p_TaskName", objPro.ptecTaskName);
                objCmd.Parameters.AddWithValue("@p_InputDate", objPro.ptecInputDate);
                objCmd.Parameters.AddWithValue("@p_AllocatedTo", objPro.ptecAllocatedEmp);
                objCmd.Parameters.AddWithValue("@p_DueDate", objPro.ptecDueDate);
                objCmd.Parameters.AddWithValue("@p_RecurringTask", objPro.ptecRecurringTask);
                objCmd.Parameters.AddWithValue("@p_Periodicity", objPro.ptecPeriodicity);
                objCmd.Parameters.AddWithValue("@p_Year", objPro.ptecYear);
                objCmd.Parameters.AddWithValue("@p_Fees", objPro.ptecFees);
                objCmd.Parameters.AddWithValue("@p_FeeStatus", objPro.ptecFeeStatus);
                objCmd.Parameters.AddWithValue("@p_Status", objPro.ptecStatus);
                objCmd.Parameters.AddWithValue("@p_Description", objPro.ptecDescription);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_PTEC_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_Ptec";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@p_TaskName", objPro.ptecTaskName);
                objCmd.Parameters.AddWithValue("@p_InputDate", objPro.ptecInputDate);
                objCmd.Parameters.AddWithValue("@p_AllocatedTo", objPro.ptecAllocatedEmp);
                objCmd.Parameters.AddWithValue("@p_DueDate", objPro.ptecDueDate);
                objCmd.Parameters.AddWithValue("@p_RecurringTask", objPro.ptecRecurringTask);
                objCmd.Parameters.AddWithValue("@p_Periodicity", objPro.ptecPeriodicity);
                objCmd.Parameters.AddWithValue("@p_Year", objPro.ptecYear);
                objCmd.Parameters.AddWithValue("@p_Fees", objPro.ptecFees);
                objCmd.Parameters.AddWithValue("@p_FeeStatus", objPro.ptecFeeStatus);
                objCmd.Parameters.AddWithValue("@p_Status", objPro.ptecStatus);
                objCmd.Parameters.AddWithValue("@p_Description", objPro.ptecDescription);
                objCmd.Parameters.AddWithValue("@ptecId", objPro.ptecId);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_PTEC_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Ptec";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_PTEC_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }
    }
}
