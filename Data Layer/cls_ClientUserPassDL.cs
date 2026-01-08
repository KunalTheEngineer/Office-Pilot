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
    internal class cls_ClientUserPassDL
    {

        #region COMMON SQL OBJECTS FOR CLIENTS USERNAME PASSWORD DL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public int flag { get; set; }

        #endregion

        internal int saveClientUserNamePassword(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_ClientUserPass";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 1);
                objPro.objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objPro.objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objPro.objCmd.Parameters.AddWithValue("@clientWorkService", objPro.workService);
                objPro.objCmd.Parameters.AddWithValue("@clientUsername", objPro.username);
                objPro.objCmd.Parameters.AddWithValue("@clientPassword", objPro.password);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_WORKMASTER_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal DataSet getClientUsernamePasword(clsProperties objPro)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_ClientUserPass";
                objCmd.Parameters.AddWithValue("@intMode", 4);
                objCmd.Parameters.AddWithValue("@clientId",objPro.clientID);
                objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objDa = new SqlDataAdapter(objCmd);

                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_CLIENTS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        internal int updateClientUserNamePassword(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_ClientUserPass";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 3);
                objPro.objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objPro.objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);
                objPro.objCmd.Parameters.AddWithValue("@clientWorkService", objPro.workService);
                objPro.objCmd.Parameters.AddWithValue("@clientUsername", objPro.username);
                objPro.objCmd.Parameters.AddWithValue("@clientPassword", objPro.password);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_WORKMASTER_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal int deleteClientUserPass(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_ClientUserPass";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 5);
                objPro.objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                //objPro.objCmd.Parameters.AddWithValue("@clientName", objPro.clientName);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_WORKMASTER_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }
    }
}
