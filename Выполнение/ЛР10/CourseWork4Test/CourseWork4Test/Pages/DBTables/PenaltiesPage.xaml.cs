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
    /// Логика взаимодействия для PenaltiesPage.xaml
    /// </summary>
    public partial class PenaltiesPage : Page
    {
        public PenaltiesPage()
        {
            InitializeComponent();
            LoadDBTableDamagePenalty();
            LoadDBTableDelayPenalty();
        }

        private void LoadDBTableDamagePenalty()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;

            cmd = "SELECT dmgp_id as 'ID', d_id as 'Сделка (ID)', dmgp_ammount as 'Сумма штрафа', dmgp_description as 'Описание' FROM Damage_penalty";

            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("DamagePenalty");
            dataAdapter.Fill(dataTable);
            DataGridDamagePenalty.ItemsSource = dataTable.DefaultView;
        }

        private void NewRecordDamageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DamageDealTB.Text != "" && DamagePenaltyAmmountTB.Text != "")
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"INSERT INTO Damage_penalty VALUES ('{DamageDealTB.Text}','{DamagePenaltyAmmountTB.Text}','{DamageDescriptionTB.Text}')";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DamageDealTB.Text = "";
                DamagePenaltyAmmountTB.Text = "";
                DamageDescriptionTB.Text = "";

                LoadDBTableDamagePenalty();
            }
        }

        private void DeleteRecordDamageBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridDamagePenalty.SelectedIndex;
            DataGridRow dataGridRow = DataGridDamagePenalty.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;

            DataRowView row = DataGridDamagePenalty.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridDamagePenalty.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"DELETE FROM Damage_penalty WHERE dmgp_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadDBTableDamagePenalty();
            }
        }

        private void SaveTableDamageBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridDamagePenalty.SelectedIndex;
            DataGridRow dataGridRow = DataGridDamagePenalty.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;

            DataRowView row = DataGridDamagePenalty.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridDamagePenalty.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"UPDATE Damage_penalty SET d_ip = {row.Row.ItemArray[1]}, dmgp_ammount = '{row.Row.ItemArray[2]}', dmgp_description = '{row.Row.ItemArray[3]}'  WHERE dmgp_id = {row.Row.ItemArray[0]}";

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

        private void UpdateDamageBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadDBTableDamagePenalty();
        }

        private void DataGridDamagePenalty_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridDamagePenalty.Columns[0].IsReadOnly = true;
        }

        private void DataGridDamagePenalty_Selected(object sender, RoutedEventArgs e)
        {
            SaveTableDamageBtn.IsEnabled = true;
        }



        private void LoadDBTableDelayPenalty()
        {
            DataBaseCon dbcon = new DataBaseCon();
            dbcon.openConnetion();
            string cmd;

            cmd = "SELECT delp_id as 'ID', d_id as 'Сделка (ID)', delp_ammount as 'Сумма штрафа', delp_description as 'Описание' FROM Delay_penalty";

            SqlCommand createCommand = new SqlCommand(cmd, dbcon.getConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable("DelayPenalty");
            dataAdapter.Fill(dataTable);
            DataGridDelayPenalty.ItemsSource = dataTable.DefaultView;
        }

        private void NewRecordDelayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DelayDealTB.Text != "" && DelayPenaltyAmmountTB.Text != "")
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"INSERT INTO Delay_penalty VALUES ('{DelayDealTB.Text}','{DelayPenaltyAmmountTB.Text}','{DelayDescriptionTB.Text}')";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DelayDealTB.Text = "";
                DelayPenaltyAmmountTB.Text = "";
                DelayDescriptionTB.Text = "";

                LoadDBTableDelayPenalty();
            }
        }

        private void DeleteRecordDelayBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridDelayPenalty.SelectedIndex;
            DataGridRow dataGridRow = DataGridDelayPenalty.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;

            DataRowView row = DataGridDelayPenalty.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridDelayPenalty.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"DELETE FROM Delay_penalty WHERE delp_id = {row.Row.ItemArray[0]}";

                    SqlCommand sqlCommand = new SqlCommand(cmd, dbcon.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadDBTableDamagePenalty();
            }
        }

        private void SaveTableDelayBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGridDelayPenalty.SelectedIndex;
            DataGridRow dataGridRow = DataGridDelayPenalty.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;

            DataRowView row = DataGridDelayPenalty.SelectedItem as DataRowView;

            if (dataGridRow.GetIndex() >= 0 && dataGridRow.GetIndex() <= DataGridDelayPenalty.Items.Count - 1)
            {
                try
                {
                    DataBaseCon dbcon = new DataBaseCon();
                    dbcon.openConnetion();
                    string cmd;

                    cmd = $"UPDATE Delay_penalty SET d_ip = {row.Row.ItemArray[1]}, delp_ammount = '{row.Row.ItemArray[2]}', delp_description = '{row.Row.ItemArray[3]}'  WHERE delp_id = {row.Row.ItemArray[0]}";

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

        private void UpdateDelayBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadDBTableDelayPenalty();
        }

        private void DataGridDelayPenalty_AutoGeneratedColumns(object sender, EventArgs e)
        {
            DataGridDelayPenalty.Columns[0].IsReadOnly = true;
        }

        private void DataGridDelayPenalty_Selected(object sender, RoutedEventArgs e)
        {
            SaveTableDelayBtn.IsEnabled = true;
        }




        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            SupportClass.NavigateFrameBack();
        }
    }
}
