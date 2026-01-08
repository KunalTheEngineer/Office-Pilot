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
    internal class cls_AccountingDL
    {
        #region COMMON SQL OBJECTS FOR ACCOUNTING DL

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
                objCmd.CommandText = "usp_Accounting";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@a_Service", objPro.accountService);
                objCmd.Parameters.AddWithValue("@a_WorkType", objPro.accountWorktype);
                objCmd.Parameters.AddWithValue("@a_InputDate", objPro.accountInputDate);
                objCmd.Parameters.AddWithValue("@a_AllocatedEmpName", objPro.accountAllocatedEmp);
                objCmd.Parameters.AddWithValue("@a_DueDate", objPro.accountDueDate);
                objCmd.Parameters.AddWithValue("@a_WorkPeriod", objPro.accountWorkPeriod);
                objCmd.Parameters.AddWithValue("@a_Status", objPro.accountStatus);
                objCmd.Parameters.AddWithValue("@a_Year", objPro.accountYear);

                flag = objCmd.ExecuteNonQuery();

                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_INCOME_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }

        internal DataSet ShowData()
        {
            try
            {

                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Accounting";
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_ACCOUNTING_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal int updateData(clsProperties objPro)
        {
            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_Accounting";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objCmd.Parameters.AddWithValue("@a_WorkType", objPro.accountWorktype);
                objCmd.Parameters.AddWithValue("@a_InputDate", objPro.accountInputDate);
                objCmd.Parameters.AddWithValue("@a_AllocatedEmpName", objPro.accountAllocatedEmp);
                objCmd.Parameters.AddWithValue("@a_DueDate", objPro.accountDueDate);
                objCmd.Parameters.AddWithValue("@a_WorkPeriod", objPro.accountWorkPeriod);
                objCmd.Parameters.AddWithValue("@a_Status", objPro.accountStatus);
                objCmd.Parameters.AddWithValue("@a_Year", objPro.accountYear);
                objCmd.Parameters.AddWithValue("@accountId",objPro.accountId);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_INCOME_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }
    }
}
