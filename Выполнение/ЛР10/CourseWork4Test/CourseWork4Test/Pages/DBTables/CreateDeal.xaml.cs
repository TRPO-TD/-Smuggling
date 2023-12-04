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
using Microsoft.VisualBasic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using Xceed.Wpf.AvalonDock.Themes;
using System.Reflection;

namespace CourseWork4Test.Pages.DBTables
{
    /// <summary>
    /// Логика взаимодействия для CreateDeal.xaml
    /// </summary>
    public partial class CreateDeal : Page
    {
        public CreateDeal()
        {
            InitializeComponent();
            LoadDBTableDeal();
        }

        private void LoadDBTableDeal()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;

            cmd = "SELECT [d_id] as 'ID', [e_id] as 'Сотрудник (ID)', [cl_id] as 'Клиент (ID)', [d_tDate] as 'Дата взятия в аренду', [d_tCompletionDate] as 'Дата завершения аренды (по договору)', [d_cost] as 'Стоимость сделки', [d_isCompleted] as 'Сделка завершена' FROM [Deal]";

            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("Deal");
            dataAdapter.Fill(dataTable);
            DataGridDeal.ItemsSource = dataTable.DefaultView;
        }

        private void NewRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeTB.Text != "" && ClientTB.Text != "" && tCompletionDateTB.Text != "    -  -")
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"INSERT INTO Deal VALUES ({EmployeeTB.Text}, {ClientTB.Text}, convert(date, GETDATE()), '{tCompletionDateTB.Text}', 0, 0) ";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                EmployeeTB.Text = "";
                ClientTB.Text = "";
                tCompletionDateTB.Text = "";

                LoadDBTableDeal();
            }
        }

        private void DeleteRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridDeal.SelectedIndex;
            DataGridRow dataGridRow = DataGridDeal.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridDeal.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridDeal.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"DELETE FROM Deal WHERE d_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadDBTableDeal();
            }
        }

        private void SaveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridDeal.SelectedIndex;
            DataGridRow dataGridRow = DataGridDeal.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
            //var item = DataGridCinema.ItemContainerGenerator.ItemFromContainer(row);

            DataRowView row = DataGridDeal.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridDeal.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"UPDATE Deal SET e_id = {row.Row.ItemArray[1]}, " +
                                           $" cl_id = {row.Row.ItemArray[2]}, " +
                                           $" d_tDate = '{row.Row.ItemArray[3]}', " +
                                           $" d_tCompletionDate = '{row.Row.ItemArray[4]}', " +
                                           $" d_cost = {row.Row.ItemArray[5]}, " +
                                           $" d_isCompleted = {Convert.ToByte(row.Row.ItemArray[6])} " +
                                           $" WHERE d_id = {row.Row.ItemArray[0]}";

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
            LoadDBTableDeal();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrameBack();
        }

        private void DataGridDeal_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridDeal.Columns[0].IsReadOnly = true;
        }

        private void DataGridDeal_Selected(object sender, RoutedEventArgs e)
        {
            SaveTableBtn.IsEnabled = true;
            AddAvaibleVMBtn.IsEnabled = true;
            DeleteAvaibleVMBtn.IsEnabled = true;
        }

        private void AddAvaibleVMBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var input = Interaction.InputBox("Введите номер видеоносителя:", "Добавление видеоносителя в сделку");
                if (input != "")
                {
                    int resultsAmmount = 0;

                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd = "SELECT COUNT(vm.vm_id) " +
                               " FROM Video_media AS vm " +
                               " Left JOIN Video_media_order as vmo ON vm.vmo_id = vmo.vmo_id " +
                               " Left JOIN Provider_ as p ON p.p_id = vmo.p_id " +
                              $" WHERE(NOT EXISTS(SELECT * FROM Deal_Video_media AS dvm WHERE vm.vm_id = dvm.vm_id) AND vm.vm_id = {input}) " +
                               " UNION " +
                               "SELECT COUNT(vm.vm_id) " +
                                "FROM Video_media AS vm " +
                                 " LEFT OUTER JOIN Deal_Video_media AS dvm ON vm.vm_id = dvm.vm_id " +
                                 " LEFT OUTER JOIN Deal AS d ON d.d_id = dvm.d_id " +
                                $" WHERE(d.d_isCompleted = 1 AND vm.vm_id = {input}) ";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            resultsAmmount += sqlDataReader.GetInt32(0);
                        }
                    }

                    sqlDataReader.Close();


                    if (resultsAmmount == 1)
                    {
                        var index = DataGridDeal.SelectedIndex;
                        DataGridRow dataGridRow = DataGridDeal.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                        DataRowView row = DataGridDeal.SelectedItem as DataRowView;

                        cmd = $" INSERT INTO Deal_Video_media VALUES ({input},{row.Row.ItemArray[0]})";

                        SqlCommand sqlCommand1 = new SqlCommand(cmd, dbcon.getConnection());
                        sqlCommand1.ExecuteNonQuery();

                        cmd = $" UPDATE Deal SET d_cost = 0 WHERE d_id = {row.Row.ItemArray[0]}";

                        SqlCommand sqlCommand2 = new SqlCommand(cmd, dbcon.getConnection());
                        sqlCommand2.ExecuteNonQuery();

                        MessageBox.Show("Запись добавлена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Такого видеоносителя нет в списке свободных", "Ошибка");
                    }
                    LoadDBTableDeal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteAvaibleVMBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = DataGridDeal.SelectedIndex;
                DataGridRow dataGridRow = DataGridDeal.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                DataRowView row = DataGridDeal.SelectedItem as DataRowView;
                var input = Interaction.InputBox("Введите номер видеоносителя:", "Удаление видеоносителя из сделки");
                if (input != "")
                {
                    int resultsAmmount = 0;

                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd =
                               "SELECT COUNT(vm.vm_id) " +
                                "FROM Video_media AS vm " +
                                 " LEFT OUTER JOIN Deal_Video_media AS dvm ON vm.vm_id = dvm.vm_id " +
                                 " LEFT OUTER JOIN Deal AS d ON d.d_id = dvm.d_id " +
                                $" WHERE (vm.vm_id = {input} and d.d_id = {row.Row.ItemArray[0]}) ";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            resultsAmmount += sqlDataReader.GetInt32(0);
                        }
                    }

                    sqlDataReader.Close();


                    if (resultsAmmount == 1)
                    {


                        cmd = $" DELETE FROM Deal_Video_media WHERE d_id = {row.Row.ItemArray[0]} and vm_id = {input}";

                        SqlCommand sqlCommand1 = new SqlCommand(cmd, dbcon.getConnection());
                        sqlCommand1.ExecuteNonQuery();

                        cmd = $" UPDATE Deal SET d_cost = 0 WHERE d_id = {row.Row.ItemArray[0]}";

                        SqlCommand sqlCommand2 = new SqlCommand(cmd, dbcon.getConnection());
                        sqlCommand2.ExecuteNonQuery();

                        MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Такого видеоносителя нет в используемых", "Ошибка");
                    }
                    LoadDBTableDeal();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToAvaibleVMBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/DBTables/AvaibleVMPage.xaml");
        }

        private void ToPenaltiesBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrame("Pages/DBTables/PenaltiesPage.xaml");
        }
    }
}
