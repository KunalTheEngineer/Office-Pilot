
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
    internal class cls_AllInOne
    {
        #region COMMON SQL OBJECTS FOR ALL IN ONE DL

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
                objCmd.CommandText = "usp_AllOne";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@a_TradeName", objPro.allOneTradeName);
                objCmd.Parameters.AddWithValue("@a_InputDate", objPro.allOneInputDate);
                objCmd.Parameters.AddWithValue("@a_TaskName", objPro.allOneTaskName);
                objCmd.Parameters.AddWithValue("@a_AllocatedTo", objPro.allOneAllocatedEmp);
                objCmd.Parameters.AddWithValue("@a_DueDate", objPro.allOneDueDate);
                objCmd.Parameters.AddWithValue("@a_Year", objPro.allOneYear);
                objCmd.Parameters.AddWithValue("@a_Fees", objPro.allOneFee);
                objCmd.Parameters.AddWithValue("@a_FeeStatus", objPro.allOneFeeStatus);
                objCmd.Parameters.AddWithValue("@a_Status", objPro.allOneStatus);
                objCmd.Parameters.AddWithValue("@a_Description", objPro.allOneDescription);
                objCmd.Parameters.AddWithValue("@a_RecurringTask", objPro.allOneRecurringTask);
                objCmd.Parameters.AddWithValue("@a_Periodicity", objPro.allOnePeriodicity);
                objCmd.Parameters.AddWithValue("@a_TypeOfReturn", objPro.allOneTypeOfReturn);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();

            }
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message.ToString(), "DL_ALLINEONE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_AllOne";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@allOneId", objPro.allOneId);
                objCmd.Parameters.AddWithValue("@a_InputDate", objPro.allOneInputDate);
                objCmd.Parameters.AddWithValue("@a_TaskName", objPro.allOneTaskName);
                objCmd.Parameters.AddWithValue("@a_AllocatedTo", objPro.allOneAllocatedEmp);
                objCmd.Parameters.AddWithValue("@a_DueDate", objPro.allOneDueDate);
                objCmd.Parameters.AddWithValue("@a_Year", objPro.allOneYear);
                objCmd.Parameters.AddWithValue("@a_Fees", objPro.allOneFee);
                objCmd.Parameters.AddWithValue("@a_FeeStatus", objPro.allOneFeeStatus);
                objCmd.Parameters.AddWithValue("@a_Status", objPro.allOneStatus);
                objCmd.Parameters.AddWithValue("@a_Description", objPro.allOneDescription);
                objCmd.Parameters.AddWithValue("@a_RecurringTask", objPro.allOneRecurringTask);
                objCmd.Parameters.AddWithValue("@a_Periodicity", objPro.allOnePeriodicity);
                objCmd.Parameters.AddWithValue("@a_TypeOfReturn", objPro.allOneTypeOfReturn);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_ALLINEONE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd = new SqlCommand(); ;
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_AllOne";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_ALLINEONE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

    }
}
