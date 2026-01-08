using MetroFramework.Animation;
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
    internal class cls_EmployeeDL
    {
        #region COMMON SQL OBJECTS FOR EMPLOYEE DL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public int flag { get; set; }

        DataTable dt;

        #endregion

        #region EMPLOYEE DATA LAYER

        internal int saveEmployeeData(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_Employee";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 1);
                objPro.objCmd.Parameters.AddWithValue("@empName", objPro.empName);
                objPro.objCmd.Parameters.AddWithValue("@empMobile", objPro.empMobile);
                objPro.objCmd.Parameters.AddWithValue("@empUsername", objPro.empUsername);
                objPro.objCmd.Parameters.AddWithValue("@empPassword", objPro.empPassword);
                objPro.objCmd.Parameters.AddWithValue("@empRole",objPro.empRole);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_EMPLOYEE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal int updateEmployeeData(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_Employee";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 2);
                objPro.objCmd.Parameters.AddWithValue("@empId", objPro.empId);
                objPro.objCmd.Parameters.AddWithValue("@empName", objPro.empName);
                objPro.objCmd.Parameters.AddWithValue("@empMobile", objPro.empMobile);
                objPro.objCmd.Parameters.AddWithValue("@empUsername", objPro.empUsername);
                objPro.objCmd.Parameters.AddWithValue("@empPassword", objPro.empPassword);
                objPro.objCmd.Parameters.AddWithValue("@empRole", objPro.empRole);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_EMPLOYEE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal int deleteEmployeeData(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_Employee";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 3);
                objPro.objCmd.Parameters.AddWithValue("@empId", objPro.empId);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_EMPLOYEE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal DataSet EmployeeData()
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Employee";
                objCmd.Parameters.AddWithValue("@intMode", 4);
                objDa = new SqlDataAdapter(objCmd);

                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_EMPLOYEE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal DataTable bindEmployee()
        {
            dt = new DataTable();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Employee";
                objCmd.Parameters.AddWithValue("@intMode", 5);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(dt);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_EMPLOYEE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return dt;
        }

        #endregion
    }
}
