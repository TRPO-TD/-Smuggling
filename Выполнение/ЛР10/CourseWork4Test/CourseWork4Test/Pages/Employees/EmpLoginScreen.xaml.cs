using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork4Test.Pages.Employees
{
    /// <summary>
    /// Логика взаимодействия для EmpLoginScreen.xaml
    /// </summary>
    public partial class EmpLoginScreen : Page
    {
        DataBaseCon db = new DataBaseCon();

        public EmpLoginScreen()
        {
            InitializeComponent();
        }

        private void LoginBtn_CLick(object sender, RoutedEventArgs e)
        {
            var loginUser = LoginTB.Text;
            var loginPassword = PasswordB.Password;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystr = $"SELECT usr.ulogin, usr.upassword, ut.ut_name FROM User_ as usr " + 
                              $"JOIN User_type as ut ON usr.ut_id = ut.ut_id " +
                              $"WHERE ulogin = '{loginUser}' AND upassword = '{loginPassword}'";

            SqlCommand command = new SqlCommand(querystr, db.getConnection());
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                

                switch (dataTable.Rows[0][2].ToString())
                {
                    default:
                    case "warehouse_manager":
                        {
                            SupportClass.NavigateFrame("Pages/Employees/WHmanagerMain.xaml");
                        }
                        break;
                    case "sales_manager":
                        {
                            SupportClass.NavigateFrame("Pages/Employees/SalesManagerMain.xaml");
                        }
                        break;
                    case "administrator":
                        {
                            SupportClass.NavigateFrame("Pages/Employees/AdministratorMain.xaml");
                        }
                        break;            
                }

            }
            else
            {
                MessageBox.Show("Такого сочетания логина и пароля не существует в базе!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
