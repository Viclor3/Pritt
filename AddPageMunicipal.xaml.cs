using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Pritt.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace Pritt
{
    /// <summary>
    /// Логика взаимодействия для AddPageMunicipal.xaml
    /// </summary>
    public partial class AddPageMunicipal : Page
    {
        private string sql;
        private MySqlConnection conn = new MySqlConnection();
        private MySqlDataAdapter cmd;
        DataTable dataTable = new DataTable();
        string connectionString = "SERVER=localhost;DATABASE=Pritt;UID=root;PASSWORD=;";

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = "select Organizations.FullName as CustomerName from Organizations";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbContractor.Items.Add(reader["CustomerName"].ToString());
                }
                reader.Close();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbCustomer.Items.Add(reader["CustomerName"].ToString());
                }
                reader.Close();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public AddPageMunicipal()
        {
            InitializeComponent();
        }

        private void BtnGoBack_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            string typedContractNumber = txContractNumber.Text;

            DateTime selectedAgreementDate = txAgreementDate.SelectedDate.Value;
            string formattedAgreementDate = selectedAgreementDate.ToString("yyyy-MM-dd HH:mm:ss");

            DateTime selectedValidity = txValidityDate.SelectedDate.Value;
            string formattedValidityDate = selectedValidity.ToString("yyyy-MM-dd HH:mm:ss");

            string comboBoxCustomer = cbCustomer.SelectedItem.ToString();
            string comboBoxContractor = cbContractor.SelectedItem.ToString();

            string queryCustomer = "SELECT Id FROM Organizations WHERE FullName = @CustomerFullName";
            string queryContractor = "SELECT Id FROM Organizations WHERE FullName = @ContractorFullName";

            conn.Open();

            MySqlCommand cmdCustomer = new MySqlCommand(queryCustomer, conn);
            cmdCustomer.Parameters.AddWithValue("@CustomerFullName", comboBoxCustomer);
            int customerId = Convert.ToInt32(cmdCustomer.ExecuteScalar());

            MySqlCommand cmdContractor = new MySqlCommand(queryContractor, conn);
            cmdContractor.Parameters.AddWithValue("@ContractorFullName", comboBoxContractor);
            int contractorId = Convert.ToInt32(cmdContractor.ExecuteScalar());

            try
            {
                string queryResult = "INSERT INTO MunicipalContracts (ContractNumber, AgreementDate, ValidityDate, CustomerId, ContractorId) VALUES (@ContractNumber, @AgreementDate, @ValidityDate, @CustomerId, @ContractorId)";

                MySqlCommand cmdResult = new MySqlCommand(queryResult, conn);
                cmdResult.Parameters.AddWithValue("@ContractNumber", typedContractNumber);
                cmdResult.Parameters.AddWithValue("@AgreementDate", formattedAgreementDate);
                cmdResult.Parameters.AddWithValue("@ValidityDate", formattedValidityDate);
                cmdResult.Parameters.AddWithValue("@CustomerId", customerId);
                cmdResult.Parameters.AddWithValue("@ContractorId", contractorId);

                cmdResult.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();

            MessageBox.Show("Успешно добавлено");
            NavigationService.Navigate(new DataPage());
        }

    }
}
