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
    internal class cls_IncomeTaxDL
    {
        #region COMMON SQL OBJECTS FOR INCOME TAX DL

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
                objCmd.CommandText = "usp_IncomeTax";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@i_Service", objPro.incomeService);
                objCmd.Parameters.AddWithValue("@i_TaskName", objPro.incomeTaskName);
                objCmd.Parameters.AddWithValue("@i_TradeName", objPro.incomeTradeName);
                objCmd.Parameters.AddWithValue("@i_InputDate", objPro.incomeInputDate);
                objCmd.Parameters.AddWithValue("@i_RecurringTask", objPro.incomeRecurringTask);
                objCmd.Parameters.AddWithValue("@i_Periodicity", objPro.incomePeriodicity);
                objCmd.Parameters.AddWithValue("@i_AllocatedEmpName", objPro.incomeAllocatedEmpName);
                objCmd.Parameters.AddWithValue("@i_DueDate", objPro.incomeDueDate);
                objCmd.Parameters.AddWithValue("@i_TypeOfReturn", objPro.incomeTypeOfReturn);
                objCmd.Parameters.AddWithValue("@i_Year", objPro.incomeYear);
                objCmd.Parameters.AddWithValue("@i_Fees", objPro.incomeFees);
                objCmd.Parameters.AddWithValue("@i_FeeStatus", objPro.incomeFeeStatus);
                objCmd.Parameters.AddWithValue("@i_Status", objPro.incomeStatus);
                objCmd.Parameters.AddWithValue("@i_Description", objPro.incomeDescription);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_INCOME_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_IncomeTax";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@i_Service", objPro.incomeService);
                objCmd.Parameters.AddWithValue("@i_TaskName", objPro.incomeTaskName);
                objCmd.Parameters.AddWithValue("@i_TradeName", objPro.incomeTradeName);
                objCmd.Parameters.AddWithValue("@i_InputDate", objPro.incomeInputDate);
                objCmd.Parameters.AddWithValue("@i_RecurringTask", objPro.incomeRecurringTask);
                objCmd.Parameters.AddWithValue("@i_Periodicity", objPro.incomePeriodicity);
                objCmd.Parameters.AddWithValue("@i_AllocatedEmpName", objPro.incomeAllocatedEmpName);
                objCmd.Parameters.AddWithValue("@i_DueDate", objPro.incomeDueDate);
                objCmd.Parameters.AddWithValue("@i_TypeOfReturn", objPro.incomeTypeOfReturn);
                objCmd.Parameters.AddWithValue("@i_Year", objPro.incomeYear);
                objCmd.Parameters.AddWithValue("@i_Fees", objPro.incomeFees);
                objCmd.Parameters.AddWithValue("@i_FeeStatus", objPro.incomeFeeStatus);
                objCmd.Parameters.AddWithValue("@i_Status", objPro.incomeStatus);
                objCmd.Parameters.AddWithValue("@i_Description", objPro.incomeDescription);
                objCmd.Parameters.AddWithValue("@incomeId", objPro.incomeId);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_WORKMASTER_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }
        
        internal DataSet ShowData(string ROLE, string EMPLOYEENAME)
        {
            try
            {

                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_IncomeTax";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objCmd.Parameters.AddWithValue("@Role", ROLE);
                objCmd.Parameters.AddWithValue("@i_AllocatedEmpName", EMPLOYEENAME);
                objCmd.Parameters.AddWithValue("@i_Service", "INCOME TAX");
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_WORKMASTER_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet ShowWorkByEmpName(clsProperties objPro)
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_IncomeTax";
                objCmd.Parameters.AddWithValue("@intMode", 5);
                objCmd.Parameters.AddWithValue("@i_AllocatedEmpName", objPro.workAllocatedEmpName);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_QUERY_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }
    }
}
