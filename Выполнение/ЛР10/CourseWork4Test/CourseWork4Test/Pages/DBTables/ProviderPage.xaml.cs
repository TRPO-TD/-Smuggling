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
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {
        public ProviderPage()
        {
            InitializeComponent();
            LoadDBTableProvider();
        }

        private void LoadDBTableProvider()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;

            cmd = "SELECT p_id as 'ID', p_title as 'Наимнование организации', a_id as 'Адрес (ID)', p_telNum as 'Телефонный номер', "+
                " p_surname as 'Фамилия отв лица', p_name as 'Имя отв лица', p_patronymic as 'Отчество отв лица' FROM Provider_";

            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("Provider");
            dataAdapter.Fill(dataTable);
            DataGridProvider.ItemsSource = dataTable.DefaultView;
        }

        private void NewRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTB.Text != "" && TelNumTB.Text != "+7 (   )    -  -" && AddressIDTB.Text != "" && SurnameTB.Text != "")
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"INSERT INTO Provider_ VALUES ('{TitleTB.Text}','{AddressIDTB.Text}','{TelNumTB.Text}','{SurnameTB.Text}','{NameTB.Text}','{PatronymicTB.Text}')";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                SurnameTB.Text = "";
                NameTB.Text = "";
                PatronymicTB.Text = "";
                AddressIDTB.Text = "";
                TelNumTB.Text = "+7 (   )   -  -  ";
                TitleTB.Text = "";

                LoadDBTableProvider();
            }
        }

        private void DeleteRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridProvider.SelectedIndex;
            DataGridRow dataGridRow = DataGridProvider.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridProvider.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridProvider.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"DELETE FROM Provider_ WHERE p_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadDBTableProvider();
            }
        }

        private void SaveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridProvider.SelectedIndex;
            DataGridRow dataGridRow = DataGridProvider.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridProvider.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridProvider.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"UPDATE Provider_ SET p_title = '{row.Row.ItemArray[1]}', " +
                                           $" a_id = {row.Row.ItemArray[2]}, " +
                                           $" p_telNum = '{row.Row.ItemArray[3]}', " +
                                           $" p_surname = '{row.Row.ItemArray[4]}', " +
                                           $" p_name = '{row.Row.ItemArray[5]}', " +
                                           $" p_patronymic = '{row.Row.ItemArray[6]}' " +
                                           $" WHERE p_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись обновлена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadDBTableProvider();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrameBack();
        }

        private void DataGridProvider_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridProvider.Columns[0].IsReadOnly = true;
        }

        private void DataGridProvider_Selected(object sender, RoutedEventArgs e)
        {
            SaveTableBtn.IsEnabled = true;
        }
    }
}
