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
    internal class cls_WorkTypeDL
    {
        #region WORK-TYPE DATA LAYER

        internal int saveWorkTypeData(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_workType";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 1);
                objPro.objCmd.Parameters.AddWithValue("@workTypeName", objPro.workTypeName);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_WORKTYPE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal int updateWorkTypeData(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_workType";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 2);
                objPro.objCmd.Parameters.AddWithValue("@workTypeId", objPro.workTypeID);
                objPro.objCmd.Parameters.AddWithValue("@workTypeName", objPro.workTypeName);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_WORKTYPE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal int deleteWorkTypeData(clsProperties objPro)
        {
            try
            {
                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandText = "usp_workType";
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.Parameters.AddWithValue("@intMode", 3);
                objPro.objCmd.Parameters.AddWithValue("@workTypeId", objPro.workTypeID);

                objPro.flag = objPro.objCmd.ExecuteNonQuery();
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_WORKTYPE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.flag;
        }

        internal DataSet workTypeData(clsProperties objPro)
        {
            try
            {
                objPro.objDs = new DataSet();

                objPro.objCon = new clsConnection();
                objPro.objCon.openConnection();
                objPro.objCmd = new SqlCommand();
                objPro.objCmd.Connection = objPro.objCon.con;
                objPro.objCmd.CommandType = CommandType.StoredProcedure;
                objPro.objCmd.CommandText = "usp_workType";
                objPro.objCmd.Parameters.AddWithValue("@intMode", 4);
                objPro.objDa = new SqlDataAdapter(objPro.objCmd);

                objPro.objDa.Fill(objPro.objDs);
                objPro.objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_WORKTYPE_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objPro.objDs;
        }

        #endregion 

    }
}
