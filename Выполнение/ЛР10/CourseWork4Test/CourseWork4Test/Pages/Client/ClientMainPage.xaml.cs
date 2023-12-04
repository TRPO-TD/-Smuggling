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

namespace CourseWork4Test.Pages.Client
{
    /// <summary>
    /// Логика взаимодействия для ClientMainPage.xaml
    /// </summary>
    public partial class ClientMainPage : Page
    {
        public ClientMainPage()
        {
            InitializeComponent();
        }

        private void ClientVideoMediaBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/Client/ClientVideoMedia.xaml");
        }

        private void ClietnQuestionsBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/Client/ClientQuestions.xaml");
        }

        private void ClientMoreInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/Client/ClientMoreInfo.xaml");
        }
    }
}
