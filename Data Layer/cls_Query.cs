using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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

        // EMPLOYEE SAVES QUERY 
        internal int saveQueryByEmp(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_Chat";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 1);
                objPro.objCmd.Parameters.AddWithValue("@workId", objPro.workID);
                objPro.objCmd.Parameters.AddWithValue("@q_EmpName", objPro.workAllocatedEmpName);
                objPro.objCmd.Parameters.AddWithValue("@q_Service", objPro.workService);
                objPro.objCmd.Parameters.AddWithValue("@q_ClientName", objPro.clientName);

                if(objPro.workRole == "User")
                {
                    objPro.objCmd.Parameters.AddWithValue("@q_QueryText", objPro.workQueryByEmp);
                    objPro.objCmd.Parameters.AddWithValue("@q_HasQuery", 1);
                }
                else
                {
                    objPro.objCmd.Parameters.AddWithValue("@q_ReplyText", objPro.workQuerySolution);
                    objPro.objCmd.Parameters.AddWithValue("@q_IsClosed", 1);
                }

                objPro.objCmd.Parameters.AddWithValue("@q_TaskName", objPro.workTaskName);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_QUERY_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        // ADMIN REPLIES BACK TO QUERY
        internal int updateQuerybyEmp(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_Chat";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 4);
                objPro.objCmd.Parameters.AddWithValue("@queryId",objPro.workQueryId);
                objPro.objCmd.Parameters.AddWithValue("@q_QueryText", objPro.workQueryByEmp);
                objPro.objCmd.Parameters.AddWithValue("@q_ReplyText", objPro.workQuerySolution);

                if (objPro.workRole == "User")
                {    
                    objPro.objCmd.Parameters.AddWithValue("@q_HasQuery", 1);
                }
                else
                {    
                    objPro.objCmd.Parameters.AddWithValue("@q_IsClosed", 1);
                }

                    
                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_QUERY_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        // SHOW ROW RED COLOR  IF QUERY HAS BEEN RAISED
        internal DataSet QueryRaisedByEmp(string service)
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Chat";
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@q_Service", service);
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

        // SHOW QUERY OF EMPLOYEE TO ADMIN
        internal DataSet SHOWEMPQUERY(string empName, string service, string client, string taskName, int workId)
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Chat";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objCmd.Parameters.AddWithValue("@q_EmpName", empName);
                objCmd.Parameters.AddWithValue("@q_Service", service);
                objCmd.Parameters.AddWithValue("@q_ClientName", client );
                objCmd.Parameters.AddWithValue("@q_TaskName", taskName);
                objCmd.Parameters.AddWithValue("@workId", workId);
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

        // SHOW EMPLOYEE QUERY THAT HAS BEEN RIASED
        internal DataSet SHOWADMINREPLY(string empName, string service, string client, string taskName, int workId)
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Chat";
                objCmd.Parameters.AddWithValue("@intMode", 5);
                objCmd.Parameters.AddWithValue("@q_EmpName", empName);
                objCmd.Parameters.AddWithValue("@q_Service", service);
                objCmd.Parameters.AddWithValue("@q_ClientName", client);
                objCmd.Parameters.AddWithValue("@q_TaskName", taskName);
                objCmd.Parameters.AddWithValue("@workId", workId);
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

        // SHOW ROW GREEN COLOR IF REPLY HAS BEEN MADE
        internal DataSet showReplyByAdmin(string service)
        {
            try
            {
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Chat";
                objCmd.Parameters.AddWithValue("@intMode", 6);
                objCmd.Parameters.AddWithValue("@q_Service", service);
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

        // DELETE CHAT
        internal int deleteChat(int id)
        {
            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandText = "usp_Chat";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 7);
                objCmd.Parameters.AddWithValue("@queryId", id);

                flag = objCmd.ExecuteNonQuery();
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_QUERY_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flag;
        }
    }
}
