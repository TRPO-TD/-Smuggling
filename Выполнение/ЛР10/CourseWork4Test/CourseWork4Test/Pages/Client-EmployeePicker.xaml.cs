using System;
using System.Collections.Generic;
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
using CourseWork4Test;


namespace CourseWork4Test.Pages
{
    /// <summary>
    /// Логика взаимодействия для Client_EmployeePicker.xaml
    /// </summary>
    public partial class Client_EmployeePicker : Page
    {
        public Client_EmployeePicker()
        {
            InitializeComponent();
        }

        private void ToClientBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/Client/ClientMainPage.xaml");
        }

        private void ToEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/Employees/EmpLoginScreen.xaml");
        }
    }
}
