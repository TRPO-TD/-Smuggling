using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DatabaseConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(local);
                                                            Initial Catalog=courseWork4TRPO;
                                                            Integrated Security=True;");
            sqlConnection.Open();

            bool areOpened = false, expectedResult = true;
            if (sqlConnection.State == ConnectionState.Open)
            { areOpened = true; };

            Assert.AreEqual(areOpened, expectedResult);
            sqlConnection.Close();
        }

        [TestMethod]
        public void EmployeeLogin()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(local);
                                                            Initial Catalog=courseWork4TRPO;
                                                            Integrated Security=True;");
            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string loginUser = "whmngnum1", loginPassword = "j|3ezHuu$F";

            string querystr = $"SELECT usr.ulogin, usr.upassword, ut.ut_name FROM User_ as usr " +
                              $"JOIN User_type as ut ON usr.ut_id = ut.ut_id " +
                              $"WHERE ulogin = '{loginUser}' AND upassword = '{loginPassword}'";

            SqlCommand command = new SqlCommand(querystr, sqlConnection);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dataTable);

            sqlConnection.Close();

            Assert.AreEqual(dataTable.Rows[0][2].ToString(), "warehouse_manager");
        }

        [TestMethod]
        public void FreeVideoMediaAmmount()
        {
            List<int> expected = new List<int> { 2, 11 };
            List<int> actual = new List<int>();

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(local);
                                                            Initial Catalog=courseWork4TRPO;
                                                            Integrated Security=True;");
            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystr =
                "SELECT COUNT (vm.vm_id) " +
                "FROM Video_media AS vm " +
                "JOIN Video_media_type AS vmt ON vm.vmt_id = vmt.vmt_id " +
                "JOIN Cinema as cin ON cin.c_id = vm.c_id " +
                "WHERE NOT EXISTS (SELECT * FROM Deal_Video_media AS dvm WHERE vm.vm_id = dvm.vm_id) " +
                "UNION " +
                "SELECT COUNT (vm.vm_id ) " +
                "FROM Video_media AS vm " +
                "LEFT OUTER JOIN Deal_Video_media AS dvm ON vm.vm_id = dvm.vm_id " +
                "LEFT OUTER JOIN Deal AS d ON d.d_id = dvm.d_id " +
                "WHERE d.d_isCompleted = 1 ";

            SqlCommand command = new SqlCommand(querystr, sqlConnection);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dataTable);

            actual.Add(Convert.ToInt32(dataTable.Rows[0][0].ToString()));
            actual.Add(Convert.ToInt32(dataTable.Rows[1][0].ToString()));

            CollectionAssert.AreEqual(actual,expected);
            sqlConnection.Close();

        }
    }
}
