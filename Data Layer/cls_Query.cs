using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace Tax_Consultant_25.Data_Layer
{
    internal class cls_Query
    {
        #region COMMON SQL OBJECTS FOR WORK MASTER DL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public DataTable dt { get; set; }

        public int flag { get; set; }

        #endregion

        clsProperties objPro;

        internal int saveQueryByEmp(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_QueryByEmp";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 1);
                objPro.objCmd.Parameters.AddWithValue("@queryEmpName", objPro.workAllocatedEmpName);
                objPro.objCmd.Parameters.AddWithValue("@queryServiceName", objPro.workService);
                objPro.objCmd.Parameters.AddWithValue("@queryClientName", objPro.clientName);
                objPro.objCmd.Parameters.AddWithValue("@queryByEmp", objPro.workQueryByEmp);
                objPro.objCmd.Parameters.AddWithValue("@querySolution", objPro.workQuerySolution);
                objPro.objCmd.Parameters.AddWithValue("@workType", objPro.workTypeName);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_QUERY_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal int updateQuerybyEmp(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_QueryByEmp";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 2);
                objPro.objCmd.Parameters.AddWithValue("@queryEmpId",objPro.workQueryByEmpId);
                objPro.objCmd.Parameters.AddWithValue("@querySolution", objPro.workQuerySolution);
                objPro.objCmd.Parameters.AddWithValue("@queryByEmp", objPro.workQueryByEmp);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_QUERY_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal DataSet QueryByEmp(string empName, string service, string client)
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_QueryByEmp";
                objCmd.Parameters.AddWithValue("@intMode", 5);
                objCmd.Parameters.AddWithValue("@queryEmpName", empName);
                objCmd.Parameters.AddWithValue("@queryServiceName", service);
                objCmd.Parameters.AddWithValue("@queryClientName", client );
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

        internal DataSet QuerySolutionByAdmin(string empName)
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_QueryByEmp";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objCmd.Parameters.AddWithValue("@queryEmpName", empName);
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

        internal DataSet QueryRaisedByEmp()
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_QueryByEmp";
                objCmd.Parameters.AddWithValue("@intMode", 4);
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

        internal DataSet FinishedGSTClients()
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_QueryByEmp";
                objCmd.Parameters.AddWithValue("@intMode", 6);
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
