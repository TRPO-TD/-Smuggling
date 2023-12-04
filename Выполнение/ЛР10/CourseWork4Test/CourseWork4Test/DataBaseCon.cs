using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork4Test
{
    internal class DataBaseCon
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(local); Initial Catalog=courseWork4TRPO; Integrated Security=True;");
        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=ADCLG1; Initial Catalog=courseWork4TRPO; Integrated Security=True;");

        public void closeConnetion()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public void openConnetion()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

    }
}
