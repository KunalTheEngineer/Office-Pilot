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
    internal class cls_LoginDL
    {
        #region COMMON SQL OBJECTS FOR LOGIN DL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public DataTable dt { get; set; }

        public int flag { get; set; }

        #endregion

        internal DataSet Login(clsProperties objPro)
        {
			try
			{
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_Employee";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 6);
                objCmd.Parameters.AddWithValue("@empUsername", objPro.loginUsername);
                objCmd.Parameters.AddWithValue("@empPassword", objPro.loginPassword);
                objCmd.Parameters.AddWithValue("@empRole", objPro.loginRole);
                objDa = new SqlDataAdapter(objCmd);
                objDs = new DataSet();

                objDa.Fill(objDs);
                objCon.con.Close();
            }
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message.ToString(), "LOGIN_DL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showLoginEmployeeWork(string empName)
        {
            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_Employee";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 7);
                objCmd.Parameters.AddWithValue("@empName", empName);
                objDa = new SqlDataAdapter(objCmd);
                objDs = new DataSet();

                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "LOGIN_DL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataSet showAdminLogin()
        {
            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_Employee";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 8);
                objDa = new SqlDataAdapter(objCmd);
                objDs = new DataSet();

                objDa.Fill(objDs);
                objCon.con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "LOGIN_DL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }
    }
}
