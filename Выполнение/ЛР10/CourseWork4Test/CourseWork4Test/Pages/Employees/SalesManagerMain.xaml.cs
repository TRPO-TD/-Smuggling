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

namespace CourseWork4Test.Pages.Employees
{
    /// <summary>
    /// Логика взаимодействия для SalesManagerMain.xaml
    /// </summary>
    public partial class SalesManagerMain : Page
    {
        public SalesManagerMain()
        {
            InitializeComponent();
        }

        private void ToClientTableBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/DBTables/Client.xaml");
        }

        private void ToDealCreationBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/DBTables/CreateDeal.xaml");
        }

        private void ToProviderTableBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/DBTables/ProviderPage.xaml");
        }

        private void ToVideoMediaTableBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/DBTables/VideoMedia.xaml");
        }

        private void ToVideoMediaOrderTableBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/DBTables/VideoMediaOrder.xaml");
        }

        private void ToAddressTableBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/DBTables/AddressPage.xaml");
        }
    }
}
