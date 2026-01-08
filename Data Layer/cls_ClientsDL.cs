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
    internal class cls_ClientsDL
    {
        #region COMMON SQL OBJECTS FOR CLIENTS DL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public int flag { get; set; }

        #endregion

        #region Clients Data Layer

        internal int saveClientsData(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_Clients";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 1);
                objPro.objCmd.Parameters.AddWithValue("@c_Name", objPro.clientName);
                objPro.objCmd.Parameters.AddWithValue("@c_FatherName", objPro.clientFatherName);
                objPro.objCmd.Parameters.AddWithValue("@c_Address", objPro.clientAddress);
                objPro.objCmd.Parameters.AddWithValue("@c_DOB", objPro.clientDOB);
                objPro.objCmd.Parameters.AddWithValue("@c_Mobile", objPro.clientMobile);
                objPro.objCmd.Parameters.AddWithValue("@c_PAN", objPro.clientPAN);
                objPro.objCmd.Parameters.AddWithValue("@c_MarritialStatus", objPro.clientMarritialStatus);
                objPro.objCmd.Parameters.AddWithValue("@c_Gender", objPro.clientGender);
                objPro.objCmd.Parameters.AddWithValue("@c_Residencial", objPro.clientResidencial);
                objPro.objCmd.Parameters.AddWithValue("@c_EmailId", objPro.clientEmail);
                objPro.objCmd.Parameters.AddWithValue("@c_AdharNo", objPro.clientAdharNo);
                objPro.objCmd.Parameters.AddWithValue("@c_BusinessName", objPro.clientBusinessName);
                objPro.objCmd.Parameters.AddWithValue("@c_Status", objPro.clientStatus);
                objPro.objCmd.Parameters.AddWithValue("@c_GSTno", objPro.clientGSTNo);
                objPro.objCmd.Parameters.AddWithValue("@c_GSTtype", objPro.clientGSTtype);
                objPro.objCmd.Parameters.AddWithValue("@isGSTClient", objPro.isGSTClient);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_CLIENTS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal int updateClientsData(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_Clients";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 2);
                objPro.objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);
                objPro.objCmd.Parameters.AddWithValue("@c_Name", objPro.clientName);
                objPro.objCmd.Parameters.AddWithValue("@c_FatherName", objPro.clientFatherName);
                objPro.objCmd.Parameters.AddWithValue("@c_Address", objPro.clientAddress);
                objPro.objCmd.Parameters.AddWithValue("@c_DOB", objPro.clientDOB);
                objPro.objCmd.Parameters.AddWithValue("@c_Mobile", objPro.clientMobile);
                objPro.objCmd.Parameters.AddWithValue("@c_PAN", objPro.clientPAN);
                objPro.objCmd.Parameters.AddWithValue("@c_MarritialStatus", objPro.clientMarritialStatus);
                objPro.objCmd.Parameters.AddWithValue("@c_Gender", objPro.clientGender);
                objPro.objCmd.Parameters.AddWithValue("@c_Residencial", objPro.clientResidencial);
                objPro.objCmd.Parameters.AddWithValue("@c_EmailId", objPro.clientEmail);
                objPro.objCmd.Parameters.AddWithValue("@c_AdharNo", objPro.clientAdharNo);
                objPro.objCmd.Parameters.AddWithValue("@c_BusinessName", objPro.clientBusinessName);
                objPro.objCmd.Parameters.AddWithValue("@c_Status", objPro.clientStatus);
                objPro.objCmd.Parameters.AddWithValue("@c_GSTno", objPro.clientGSTNo);
                objPro.objCmd.Parameters.AddWithValue("@c_GSTtype", objPro.clientGSTtype);
                objPro.objCmd.Parameters.AddWithValue("@isGSTClient", objPro.isGSTClient);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_CLIENTS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal int deleteClientsData(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_Clients";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 3);
                objPro.objCmd.Parameters.AddWithValue("@clientId", objPro.clientID);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_CLIENTS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal DataSet ClientsData()
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Clients";
                objCmd.Parameters.AddWithValue("@intMode", 4);
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

        internal DataSet bindClientsData()
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Clients";
                objCmd.Parameters.AddWithValue("@intMode", 5);
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

        internal DataSet searchClientData(clsProperties objPro)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Clients";
                objCmd.Parameters.AddWithValue("@intMode", 6);
                objCmd.Parameters.AddWithValue("@search", objPro.search);
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

        internal DataSet getClientsId(clsProperties objPro)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Clients";
                objCmd.Parameters.AddWithValue("@intMode", 10);
                objCmd.Parameters.AddWithValue("@c_Name", objPro.clientName);
                objCmd.Parameters.AddWithValue("@c_Mobile", objPro.clientMobile);
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

        internal DataSet searchClientTradeName(clsProperties objPro)
        {
            objDs = new DataSet();

            try
            {
                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Clients";
                objCmd.Parameters.AddWithValue("@intMode", 11);
                objCmd.Parameters.AddWithValue("@search", objPro.search);
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

        #endregion

    }
}
