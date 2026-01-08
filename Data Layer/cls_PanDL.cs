using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tax_Consultant_25.Data_Layer
{
    internal class cls_PanDL
    {
        #region COMMON SQL OBJECTS FOR PAN DL

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
                objCmd.CommandText = "usp_PanTan";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@p_Service", objPro.panService);
                objCmd.Parameters.AddWithValue("@p_WorkType", objPro.panWorkType);
                objCmd.Parameters.AddWithValue("@p_InputDate", objPro.panInputDate);
                objCmd.Parameters.AddWithValue("@p_AllocatedTo", objPro.panAllocatedEmp);
                objCmd.Parameters.AddWithValue("@p_DueDate", objPro.panDueDate);
                objCmd.Parameters.AddWithValue("@p_PanTanNo", objPro.panTanNo);
                objCmd.Parameters.AddWithValue("@p_Fees", objPro.panFees);
                objCmd.Parameters.AddWithValue("@p_FeeStatus", objPro.panFeeStatus);
                objCmd.Parameters.AddWithValue("@p_Status", objPro.panStatus);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_PAN_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_PanTan";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@p_Service", objPro.panService);
                objCmd.Parameters.AddWithValue("@p_WorkType", objPro.panWorkType);
                objCmd.Parameters.AddWithValue("@p_InputDate", objPro.panInputDate);
                objCmd.Parameters.AddWithValue("@p_AllocatedTo", objPro.panAllocatedEmp);
                objCmd.Parameters.AddWithValue("@p_DueDate", objPro.panDueDate);
                objCmd.Parameters.AddWithValue("@p_PanTanNo", objPro.panTanNo);
                objCmd.Parameters.AddWithValue("@p_Fees", objPro.panFees);
                objCmd.Parameters.AddWithValue("@p_FeeStatus", objPro.panFeeStatus);
                objCmd.Parameters.AddWithValue("@p_Status", objPro.panStatus);
                objCmd.Parameters.AddWithValue("@panId",objPro.panId);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_PAN_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_PanTan";
                objCmd.Parameters.AddWithValue("@intMode", 3);
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
    }
}
