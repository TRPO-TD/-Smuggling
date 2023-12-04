using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace CourseWork4Test.Pages.DBTables
{
    /// <summary>
    /// Логика взаимодействия для AvaibleVMPage.xaml
    /// </summary>
    public partial class AvaibleVMPage : Page
    {
        public AvaibleVMPage()
        {
            InitializeComponent();
            StandartFillDataGrid();
        }

        public void StandartFillDataGrid()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;
            if (checkBox.IsChecked == true)
            {
                cmd = "SELECT vm.vm_id AS ID, " +
                             "cin.c_name as 'Фильм', " +
                             "p.p_title as 'Поставщик', " +
                             "vm.vmo_id as 'Номер поставки (ID)', " +
                             "vmt.vmt_name as 'Тип видеоносителя', " +
                             "vm.vm_dailyRentPrice as 'Цена аренды в сутки', " +
                             "vm.vm_durability as 'Прочность', " +
                             "vm.vm_price as 'Себестоимость' " +
                      "FROM Video_media AS vm  " +
                             "JOIN Video_media_type AS vmt ON  vm.vmt_id = vmt.vmt_id " +
                             "JOIN Cinema as cin ON cin.c_id = vm.c_id " +
                             "Left JOIN Video_media_order as vmo ON vm.vmo_id = vmo.vmo_id " +
                             "Left JOIN Provider_ as p ON p.p_id = vmo.p_id " +
                            $"WHERE (NOT EXISTS (SELECT * FROM Deal_Video_media AS dvm WHERE vm.vm_id = dvm.vm_id) AND cin.c_name LIKE '%{textBox.Text}%') " +
                            " UNION " +
                      "SELECT vm.vm_id AS ID, " +
                             "cin.c_name as 'Фильм', " +
                             "p.p_title as 'Поставщик', " +
                             "vm.vmo_id as 'Номер поставки (ID)', " +
                             "vmt.vmt_name as 'Тип видеоносителя', " +
                             "vm.vm_dailyRentPrice as 'Цена аренды в сутки', " +
                             "vm.vm_durability as 'Прочность', " +
                             "vm.vm_price as 'Себестоимость' " +
                      "FROM Video_media AS vm  " +
                             "JOIN Video_media_type AS vmt ON  vm.vmt_id = vmt.vmt_id " +
                             "JOIN Cinema as cin ON cin.c_id = vm.c_id " +
                             "Left JOIN Video_media_order as vmo ON vm.vmo_id = vmo.vmo_id " +
                             "Left JOIN Provider_ as p ON p.p_id = vmo.p_id " +
                             "LEFT OUTER JOIN Deal_Video_media AS dvm ON vm.vm_id = dvm.vm_id " +
                             "LEFT OUTER JOIN Deal AS d ON d.d_id = dvm.d_id " +
                            $"WHERE (d.d_isCompleted = 1 AND cin.c_name LIKE '%{textBox.Text}%')";
            }
            else
            {
                cmd = "SELECT vm.vm_id as ID, " +
                                "cin.c_name as 'Фильм', " +
                                "p.p_title as 'Поставщик', " +
                                "vm.vmo_id as 'Номер поставки (ID)', " +
                                "vmt.vmt_name as 'Тип видеоносителя', " +
                                "vm.vm_dailyRentPrice as 'Цена аренды в сутки', " +
                                "vm.vm_durability as 'Прочность', " +
                                "vm.vm_price as 'Себестоимость' " +
                        "FROM Video_media AS vm " +
                                "JOIN Video_media_type AS vmt ON  vm.vmt_id = vmt.vmt_id " +
                                "JOIN Cinema as cin ON cin.c_id = vm.c_id " +
                                "Left JOIN Video_media_order as vmo ON vm.vmo_id = vmo.vmo_id " +
                                "Left JOIN Provider_ as p ON p.p_id = vmo.p_id " +
                               $"WHERE cin.c_name LIKE '%{textBox.Text}%' ";
            }


            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("AvaibleVM");
            dataAdapter.Fill(dataTable);
            AvaibleVM.ItemsSource = dataTable.DefaultView; // Сам вывод 
        }

        private void SearchOKBtn_Click(object sender, RoutedEventArgs e)
        {
            StandartFillDataGrid();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            StandartFillDataGrid();
            textBox.Text = "";
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrameBack();
        }
    }
}
