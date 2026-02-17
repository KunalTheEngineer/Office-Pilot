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
    internal class cls_UdyamDL
    {
        #region COMMON SQL OBJECTS FOR UDYAM DL

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
                objCmd.CommandText = "usp_Udyam";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@u_TradeName", objPro.udyamTradeName);
                objCmd.Parameters.AddWithValue("@u_TaskName", objPro.udyamTaskName);
                objCmd.Parameters.AddWithValue("@u_InputDate", objPro.udyamInputDate);
                objCmd.Parameters.AddWithValue("@u_AllocatedTo", objPro.udyamAllocatedEmp);
                objCmd.Parameters.AddWithValue("@u_DueDate", objPro.udyamDueDate);
                objCmd.Parameters.AddWithValue("@u_Fees", objPro.udyamFees);
                objCmd.Parameters.AddWithValue("@u_FeeStatus", objPro.udyamFeeStatus);
                objCmd.Parameters.AddWithValue("@u_Status", objPro.udyamStatus);
                objCmd.Parameters.AddWithValue("@u_Description", objPro.udyamDescription);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_UDYAM_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_Udyam";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@u_TaskName", objPro.udyamTaskName);
                objCmd.Parameters.AddWithValue("@u_InputDate", objPro.udyamInputDate);
                objCmd.Parameters.AddWithValue("@u_AllocatedTo", objPro.udyamAllocatedEmp);
                objCmd.Parameters.AddWithValue("@u_DueDate", objPro.udyamDueDate);
                objCmd.Parameters.AddWithValue("@u_Fees", objPro.udyamFees);
                objCmd.Parameters.AddWithValue("@u_FeeStatus", objPro.udyamFeeStatus);
                objCmd.Parameters.AddWithValue("@u_Status", objPro.udyamStatus);
                objCmd.Parameters.AddWithValue("@u_Description", objPro.udyamDescription);
                objCmd.Parameters.AddWithValue("@udyamId", objPro.udyamId);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_UDYAM_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }

        internal DataSet showData(string ROLE, string EMPLOYEENAME)
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Udyam";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objCmd.Parameters.AddWithValue("@Role", ROLE);
                objCmd.Parameters.AddWithValue("@u_AllocatedTo", EMPLOYEENAME);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_UDYAM_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }
    }
}
