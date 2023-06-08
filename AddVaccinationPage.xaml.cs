using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Pritt
{
    /// <summary>
    /// Логика взаимодействия для AddVaccinationPage.xaml
    /// </summary>
    public partial class AddVaccinationPage : Page
    {
        private string sql;
        private MySqlConnection conn = new MySqlConnection();
        private MySqlDataAdapter cmd;
        DataTable dataTable = new DataTable();
        string connectionString = "SERVER=localhost;DATABASE=Pritt;UID=root;PASSWORD=;";

        public AddVaccinationPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                string queryAnimals = "SELECT Nickname FROM Animals";
                string queryVaccinationTypes = "SELECT VaccinationTypes.Name FROM VaccinationTypes";
                string queryVets = "SELECT LastName FROM Users WHERE RoleId = '3'";
                string queryMunicipalContracts = "SELECT ContractNumber FROM MunicipalContracts";

                MySqlCommand cmd = new MySqlCommand(queryAnimals, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    animalComboBox.Items.Add(new ComboBoxItem { Content = reader["Nickname"].ToString() });
                }
                reader.Close();

                cmd.CommandText = queryVaccinationTypes;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vaccinationTypeComboBox.Items.Add(new ComboBoxItem { Content = reader["Name"].ToString() });
                }
                reader.Close();

                cmd.CommandText = queryVets;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vetComboBox.Items.Add(new ComboBoxItem { Content = reader["LastName"].ToString() });
                }
                reader.Close();

                cmd.CommandText = queryMunicipalContracts;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    municipalContractComboBox.Items.Add(new ComboBoxItem { Content = reader["ContractNumber"].ToString() });
                }
                reader.Close();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (animalComboBox.SelectedItem != null && vaccinationDatePicker.SelectedDate.HasValue && !string.IsNullOrEmpty(serialNumberTextBox.Text) && expirationDatePicker.SelectedDate.HasValue && vetComboBox.SelectedItem != null && municipalContractComboBox.SelectedItem != null && vaccinationTypeComboBox.SelectedItem != null)
            {
                MySqlConnection conn = new MySqlConnection(connectionString);

                int animalId = Convert.ToInt32(((ComboBoxItem)animalComboBox.SelectedItem).Tag);
                DateTime vaccinationDate = vaccinationDatePicker.SelectedDate.Value;
                string serialNumber = serialNumberTextBox.Text;
                DateTime expirationDate = expirationDatePicker.SelectedDate.Value;
                int vetId = Convert.ToInt32(((ComboBoxItem)vetComboBox.SelectedItem).Tag);
                int municipalContractId = Convert.ToInt32(((ComboBoxItem)municipalContractComboBox.SelectedItem).Tag);
                int typeId = Convert.ToInt32(((ComboBoxItem)vaccinationTypeComboBox.SelectedItem).Tag);

                try
                {
                    conn.Open();

                    string query = "INSERT INTO Vaccinations (AnimalId, VaccinationDate, SerialNumber, ExpirationDate, VetId, MunicipalContractId, TypeId) VALUES (@AnimalId, @VaccinationDate, @SerialNumber, @ExpirationDate, @VetId, @MunicipalContractId, @TypeId)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AnimalId", animalId);
                    cmd.Parameters.AddWithValue("@VaccinationDate", vaccinationDate);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                    cmd.Parameters.AddWithValue("@VetId", vetId);
                    cmd.Parameters.AddWithValue("@MunicipalContractId", municipalContractId);
                    cmd.Parameters.AddWithValue("@TypeId", typeId);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Успешно добавлено");
                    NavigationService.Navigate(new DataPage());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
