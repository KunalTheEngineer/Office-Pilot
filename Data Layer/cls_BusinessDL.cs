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
    internal class cls_BusinessDL
    {

        #region COMMON SQL OBJECTS FOR BUSINESS DL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public DataTable dt { get; set; }

        public int flag { get; set; }

        #endregion

        internal DataSet getBusinessName(string name, int id)
        {
			try
			{
                objDs = new DataSet();

                objCon = new clsConnection();
                objCon.openConnection();
                objCmd = new SqlCommand();
                objCmd.Connection = objCon.con;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "usp_Clients";
                objCmd.Parameters.AddWithValue("@intMode", 9);
                objCmd.Parameters.AddWithValue("@clientId", id);
                objCmd.Parameters.AddWithValue("@c_Name", name);
                objDa = new SqlDataAdapter(objCmd);
                objDa.Fill(objDs);
                objCon.con.Close();
            }
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message.ToString(), "DL_BUSINESS_DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return objDs;
        }

        
    }
}
