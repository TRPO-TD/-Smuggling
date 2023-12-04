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
    /// Логика взаимодействия для VideoMediaOrder.xaml
    /// </summary>
    public partial class VideoMediaOrder : Page
    {
        public VideoMediaOrder()
        {
            InitializeComponent();
            LoadDBTableVMO();
        }

        private void LoadDBTableVMO()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;

            cmd = "SELECT [vmo_id] as 'ID', [vmo_tData] as 'Дата заказа', [vmo_tCompletionDate] as 'Дата ожидаемого прибытия', [p_id] as 'Поставщик', [e_id] as 'Сотрудник', [vmo_isCompleted] as 'Сделка завершена' FROM [Video_media_order]";

            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("Client");
            dataAdapter.Fill(dataTable);
            DataGridVMO.ItemsSource = dataTable.DefaultView;
        }

        private void NewRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProviderTB.Text != "" && EmployeeTB.Text != "" && tDateTB.Text != "    -  -" && tCompletionDateTB.Text != "    -  -") 
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = "INSERT INTO Video_media_order VALUES ( " +
                        (tDateTB.Text != "    -  -" ? "convert(date,'"+tDateTB.Text+"')" : " convert(date, GETDATE())") + ", " +
                        (tCompletionDateTB.Text != "    -  -" ? "convert(date,'" + tCompletionDateTB.Text+"')"  : " convert(date, GETDATE())") + ", " +
                       $"{Convert.ToInt32(ProviderTB.Text)}, {Convert.ToInt32(EmployeeTB.Text)}, " +
                        (tCompletionTB.Text != "" ? tCompletionTB.Text : "0") + ")";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ProviderTB.Text = "";
                EmployeeTB.Text = "";
                tDateTB.Text = "";
                tCompletionDateTB.Text = "";
                tCompletionTB.Text = "";

                LoadDBTableVMO();
            }
        }

        private void DeleteRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridVMO.SelectedIndex;
            DataGridRow dataGridRow = DataGridVMO.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridVMO.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridVMO.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"DELETE FROM Video_media_order WHERE vmo_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadDBTableVMO();
            }
        }

        private void SaveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridVMO.SelectedIndex;
            DataGridRow dataGridRow = DataGridVMO.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridVMO.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridVMO.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"UPDATE Video_media_order SET vmo_tData = '{row.Row.ItemArray[1]}', " +
                                           $" vmo_tCompletionDate = '{row.Row.ItemArray[2]}', " +
                                           $" p_id = {row.Row.ItemArray[3]}, " +
                                           $" e_id = {row.Row.ItemArray[4]}, " +
                                           $" vmo_isCompleted = {Convert.ToByte(row.Row.ItemArray[5])} " +
                                           $" WHERE vmo_id = {row.Row.ItemArray[0]}";

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
            LoadDBTableVMO();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrameBack();
        }

        private void DataGridVMO_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridVMO.Columns[0].IsReadOnly = true;
        }

        private void DataGridVMO_Selected(object sender, RoutedEventArgs e)
        {
            SaveTableBtn.IsEnabled = true;
        }

    }
}
