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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client()
        {
            InitializeComponent();
            LoadDBTableClient();
        }

        private void LoadDBTableClient()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;

            cmd = "SELECT cl_id as 'ID', cl_surname as 'Фамилия', cl_name as 'Имя', cl_patronymic as 'Отчество', a_id as 'Адрес (ID)', cl_telNum as 'Телефонный номер', cs_id as 'Статус клиента (ID)' FROM Client";

            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("Client");
            dataAdapter.Fill(dataTable);
            DataGridClient.ItemsSource = dataTable.DefaultView;
        }

        private void NewRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SurnameTB.Text != "" && TelNumTB.Text != "+7 (   )    -  -")
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"INSERT INTO Client VALUES ('{SurnameTB.Text}','{NameTB.Text}','{PatronymicTB.Text}','{AddressIDTB.Text}','{TelNumTB.Text}','{ClientStatusTB.Text}')";

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
                ClientStatusTB.Text = "";

                LoadDBTableClient();
            }
        }

        private void DeleteRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridClient.SelectedIndex;
            DataGridRow dataGridRow = DataGridClient.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridClient.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridClient.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"DELETE FROM Client WHERE cl_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadDBTableClient();
            }
        }

        private void SaveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridClient.SelectedIndex;
            DataGridRow dataGridRow = DataGridClient.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridClient.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridClient.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"UPDATE Client SET cl_surname = '{row.Row.ItemArray[1]}', "+
                                           $" cl_name = '{row.Row.ItemArray[2]}', "+
                                           $" cl_patronymic = '{row.Row.ItemArray[3]}', "+
                                           $" a_id = {row.Row.ItemArray[4]}, "+
                                           $" cl_telNum = '{row.Row.ItemArray[5]}', "+
                                           $" cs_id = {row.Row.ItemArray[6]} " +
                                           $" WHERE cl_id = {row.Row.ItemArray[0]}";

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
            LoadDBTableClient();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrameBack();
        }

        private void DataGridClient_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridClient.Columns[0].IsReadOnly = true;
        }

        private void DataGridClient_Selected(object sender, RoutedEventArgs e)
        {
            SaveTableBtn.IsEnabled = true;
        }

    }
}
