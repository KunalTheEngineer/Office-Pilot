using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Tax_Consultant_25.Data_Layer
{
    internal class clsConnection
    {
        public string connection = ConfigurationManager.ConnectionStrings["commonCon"].ConnectionString;

        public SqlConnection con = new SqlConnection();

        public void openConnection()
        {
            con = new SqlConnection(connection);

            if (con.State == ConnectionState.Open || con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
        }

    }
}
