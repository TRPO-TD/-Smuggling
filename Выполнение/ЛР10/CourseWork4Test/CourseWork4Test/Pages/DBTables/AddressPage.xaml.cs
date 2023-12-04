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
    /// Логика взаимодействия для AddressPage.xaml
    /// </summary>
    public partial class AddressPage : Page
    {
        public AddressPage()
        {
            InitializeComponent();
            LoadDBTableAddress();
        }

        private void LoadDBTableAddress()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;

            cmd = "SELECT a_id as 'ID', a_locality as 'Населенный пункт', a_street as 'Улица', a_building as 'Здание' FROM Address_";

            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("Address");
            dataAdapter.Fill(dataTable);
            DataGridAddress.ItemsSource = dataTable.DefaultView;
        }

        private void NewRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BuildingTB.Text != "" && LocalityTB.Text != "" && StreetTB.Text != "")
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"INSERT INTO Address_ VALUES ('{LocalityTB.Text}','{StreetTB.Text}','{BuildingTB.Text}')";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LocalityTB.Text = "";
                BuildingTB.Text = "";
                StreetTB.Text = "";
                LoadDBTableAddress();
            }
        }

        private void DeleteRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridAddress.SelectedIndex;
            DataGridRow dataGridRow = DataGridAddress.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridAddress.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridAddress.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"DELETE FROM Address_ WHERE a_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadDBTableAddress();
            }
        }

        private void SaveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridAddress.SelectedIndex;
            DataGridRow dataGridRow = DataGridAddress.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridAddress.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridAddress.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"UPDATE Address_ SET a_locality = '{row.Row.ItemArray[1]}', " +
                                           $" a_street = '{row.Row.ItemArray[2]}', " +
                                           $" a_building = '{row.Row.ItemArray[3]}' " +
                                           $" WHERE a_id = {row.Row.ItemArray[0]}";

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
            LoadDBTableAddress();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrameBack();
        }

        private void DataGridAddress_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridAddress.Columns[0].IsReadOnly = true;
        }

        private void DataGridAddress_Selected(object sender, RoutedEventArgs e)
        {
            SaveTableBtn.IsEnabled = true;
        }

    }
}
