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
    internal class cls_EnquiryDL
    {
        #region COMMON SQL OBJECTS FOR ENQUIRY DL

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
                objCmd.CommandText = "usp_Enquiry";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 1);
                objCmd.Parameters.AddWithValue("@e_Name", objPro.enquiryName);
                objCmd.Parameters.AddWithValue("@e_Service", objPro.enquiryService);
                objCmd.Parameters.AddWithValue("@e_Mobile", objPro.enquiryMobile);
                objCmd.Parameters.AddWithValue("@e_Email", objPro.enquiryEmail);
                objCmd.Parameters.AddWithValue("@e_Date", objPro.enquiryDate);

                flag = objCmd.ExecuteNonQuery();

                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_ENQUIRY_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_Enquiry";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@intMode", 2);
                objCmd.Parameters.AddWithValue("@e_Name", objPro.enquiryName);
                objCmd.Parameters.AddWithValue("@e_Service", objPro.enquiryService);
                objCmd.Parameters.AddWithValue("@e_Mobile", objPro.enquiryMobile);
                objCmd.Parameters.AddWithValue("@e_Email", objPro.enquiryEmail);
                objCmd.Parameters.AddWithValue("@e_Date", objPro.enquiryDate);
                objCmd.Parameters.AddWithValue("@enquiryId", objPro.enquiryId);

                flag = objCmd.ExecuteNonQuery();

                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_ENQUIRY_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                objCmd.CommandText = "usp_Enquiry";
                objCmd.Parameters.AddWithValue("@intMode", 3);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DL_ENQUIRY_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }
    }
}
