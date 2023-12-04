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
using System.Data.Entity;
using System.Net;
using System.Security.Policy;
using System.Xml.Linq;

namespace CourseWork4Test.Pages.DBTables
{
    /// <summary>
    /// Логика взаимодействия для Cinema.xaml
    /// </summary>
    public partial class Cinema : Page
    {
        public Cinema()
        {
            InitializeComponent();
            LoadDBTableCinema();   
        }

        private void LoadDBTableCinema()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;

            cmd = "SELECT c_id as 'ID', c_name as 'Наименование фильма', c_description as 'Описание фильма' FROM Cinema";

            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("Cinema");
            dataAdapter.Fill(dataTable);
            DataGridCinema.ItemsSource = dataTable.DefaultView;
        }

        private void NewRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CinemaTB.Text != "" && CinemaDescriptionTB.Text != "")
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"INSERT INTO Cinema VALUES ('{CinemaTB.Text}','{CinemaDescriptionTB.Text}')";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                CinemaTB.Text = "";
                CinemaDescriptionTB.Text = "";
                LoadDBTableCinema();
            }
            else
            {
                MessageBox.Show("Заполните поля для ввода корректными данными", "Внимание!");
            }
        }

        private void DeleteRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridCinema.SelectedIndex;
            DataGridRow dataGridRow = DataGridCinema.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridCinema.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridCinema.Items.Count-1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"DELETE FROM Cinema WHERE c_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadDBTableCinema();
            }
        }

        private void SaveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridCinema.SelectedIndex;
            DataGridRow dataGridRow = DataGridCinema.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridCinema.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridCinema.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"UPDATE Cinema SET  c_name = '{row.Row.ItemArray[1]}', c_description = '{row.Row.ItemArray[2]}'  WHERE c_id = {row.Row.ItemArray[0]}";

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
            LoadDBTableCinema();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrameBack();
        }

        private void DataGridCinema_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridCinema.Columns[0].IsReadOnly = true;
        }

        private void DataGridCinema_Selected(object sender, RoutedEventArgs e)
        {
            SaveTableBtn.IsEnabled = true;
        }
    }
}
