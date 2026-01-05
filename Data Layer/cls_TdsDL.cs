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
    internal class cls_TdsDL
    {
        #region COMMON SQL OBJECTS FOR TDS DL

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
                objCmd.CommandText = "usp_TDS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objCmd.Parameters.AddWithValue("@t_TradeName", objPro.tdsTradeName);
                objCmd.Parameters.AddWithValue("@t_InputDate ", objPro.tdsInputDate);
                objCmd.Parameters.AddWithValue("@t_TaskName", objPro.tdsTaskName);
                objCmd.Parameters.AddWithValue("@t_AllocatedTo", objPro.tdsAllocatedEmp);
                objCmd.Parameters.AddWithValue("@t_DueDate", objPro.tdsDueDate);
                objCmd.Parameters.AddWithValue("@t_Year", objPro.tdsYear);
                objCmd.Parameters.AddWithValue("@t_RecurringTask", objPro.tdsRecurringTask);
                objCmd.Parameters.AddWithValue("@t_Periodicity", objPro.tdsPeriodicity);
                objCmd.Parameters.AddWithValue("@t_Status", objPro.tdsStatus);
                objCmd.Parameters.AddWithValue("@t_Description", objPro.tdsDescription);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();

            }
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message.ToString(), "DL_TDS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_TDS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@t_InputDate ", objPro.tdsInputDate);
                objCmd.Parameters.AddWithValue("@t_TaskName", objPro.tdsTaskName);
                objCmd.Parameters.AddWithValue("@t_AllocatedTo", objPro.tdsAllocatedEmp);
                objCmd.Parameters.AddWithValue("@t_DueDate", objPro.tdsDueDate);
                objCmd.Parameters.AddWithValue("@t_Year", objPro.tdsYear);
                objCmd.Parameters.AddWithValue("@t_RecurringTask", objPro.tdsRecurringTask);
                objCmd.Parameters.AddWithValue("@t_Periodicity", objPro.tdsPeriodicity);
                objCmd.Parameters.AddWithValue("@t_Status", objPro.tdsStatus);
                objCmd.Parameters.AddWithValue("@t_Description", objPro.tdsDescription);
                objCmd.Parameters.AddWithValue("@tdsId", objPro.tdsId);

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
                objCmd.CommandText = "usp_TDS";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objCmd.Parameters.AddWithValue("@t_Service", "TDS");
                objCmd.Parameters.AddWithValue("@t_AllocatedTo", EMPLOYEENAME);
                objCmd.Parameters.AddWithValue("@Role", ROLE);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_TDS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }
    }
}
