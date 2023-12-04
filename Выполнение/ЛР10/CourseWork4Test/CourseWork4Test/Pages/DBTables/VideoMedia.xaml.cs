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
    /// Логика взаимодействия для VideoMedia.xaml
    /// </summary>
    public partial class VideoMedia : Page
    {
        public VideoMedia()
        {
            InitializeComponent();
            LoadDBTableVM();
        }


        private void LoadDBTableVM()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;

            cmd = "SELECT vm_id as 'ID', c_id as 'Фильм (ID)', vmo_id as 'Поставка (ID)', vmt_id as 'Тип видеоносителя (ID)'"+
                ", vm_dailyRentPrice as 'Стоимость аренды в сутки', vm_durability as 'Общая прочность', vm_price as 'Общая стоимость' FROM Video_media";

            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("Client");
            dataAdapter.Fill(dataTable);
            DataGridVM.ItemsSource = dataTable.DefaultView;
        }

        private void NewRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CinemaTB.Text != "" && TypeTB.Text != "")
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;
                    
                    cmd = $"INSERT INTO Video_media VALUES ({CinemaTB.Text},"+
                        (VMOTB.Text != "" ? VMOTB.Text : "NULL")+ "," +
                        $"{TypeTB.Text},"+
                        (RentPriceTB.Text != "" ? RentPriceTB.Text : "250") + "," +
                        (DurabilityTB.Text != "" ? DurabilityTB.Text : "2") + "," +
                        (PriceTB.Text != "" ? PriceTB.Text : "1000") + ")";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                CinemaTB.Text = "";
                VMOTB.Text = "";
                TypeTB.Text = "";
                RentPriceTB.Text = "";
                DurabilityTB.Text = "";
                PriceTB.Text = "";

                LoadDBTableVM();
            }
        }

        private void DeleteRecordBtn_Click(object sender, RoutedEventArgs e)
        {   
            var index = DataGridVM.SelectedIndex;
            DataGridRow dataGridRow = DataGridVM.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridVM.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridVM.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"DELETE FROM Video_media WHERE vm_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadDBTableVM();
            }
        }

        private void SaveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridVM.SelectedIndex;
            DataGridRow dataGridRow = DataGridVM.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridVM.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridVM.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"UPDATE Video_media SET c_id = {row.Row.ItemArray[1]}, " +
                                           $" vmo_id = {row.Row.ItemArray[2]}, " +
                                           $" vmt_id = {row.Row.ItemArray[3]}, " +
                                           $" vm_dailyRentPrice = {row.Row.ItemArray[4]}, " +
                                           $" vm_durability = {row.Row.ItemArray[5]}, " +
                                           $" vm_price = {row.Row.ItemArray[6]} " +
                                           $" WHERE vm_id = {row.Row.ItemArray[0]}";

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
            LoadDBTableVM();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrameBack();
        }

        private void DataGridVM_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridVM.Columns[0].IsReadOnly = true;
        }

        private void DataGridVM_Selected(object sender, RoutedEventArgs e)
        {
            SaveTableBtn.IsEnabled = true;
        }

    }
}
