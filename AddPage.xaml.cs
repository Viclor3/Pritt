using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Pritt
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private string sql;
        private MySqlConnection conn = new MySqlConnection();
        private MySqlDataAdapter cmd;
        DataTable dataTable = new DataTable();
        string connectionString = "SERVER=localhost;DATABASE=Pritt;UID=root;PASSWORD=;";

        public AddPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                string querySpecies = "select Species.Name as CategoryName from Species";
                string queryGenders = "select Genders.Name as SexName from Genders";
                string queryLocalities = "select Localities.Name as LocalityName from Localities";

                MySqlCommand cmd = new MySqlCommand(querySpecies, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbCategory.Items.Add(reader["CategoryName"].ToString());
                }
                reader.Close();

                cmd.CommandText = queryGenders;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbSex.Items.Add(reader["SexName"].ToString());
                }
                reader.Close();

                cmd.CommandText = queryLocalities;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbLocality.Items.Add(reader["LocalityName"].ToString());
                }
                reader.Close();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txRegistrationNumber.Text) && dtBirthday.SelectedDate.HasValue && !string.IsNullOrEmpty(txChipNumber.Text) && cbCategory.SelectedItem != null && !string.IsNullOrEmpty(txNickname.Text) && cbSex.SelectedItem != null && !string.IsNullOrEmpty(txSpecialSigns.Text) && cbLocality.SelectedItem != null)

            {
                MySqlConnection conn = new MySqlConnection(connectionString);

                string typedRegistrationNumber = txRegistrationNumber.Text;
                string typedChipNumber = txChipNumber.Text;
                string typedNickname = txNickname.Text;
                string typedSpecialSigns = txSpecialSigns.Text;

                DateTime selectedDate = dtBirthday.SelectedDate.Value;
                string formattedDate = selectedDate.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime newDateTime = DateTime.ParseExact(formattedDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                string comboBoxCategory = cbCategory.SelectedItem.ToString();
                string comboBoxSex = cbSex.SelectedItem.ToString();
                string comboBoxLocality = cbLocality.SelectedItem.ToString();

                string querySpecies = "select Id from Species where Name = '" + comboBoxCategory + "'";
                string queryGenders = "select Id from Genders where Name ='" + comboBoxSex + "'";
                string queryLocalities = "select Id from Localities where Name ='" + comboBoxLocality + "'";

                conn.Open();

                MySqlCommand cmdSpeciment = new MySqlCommand(querySpecies, conn);
                int speciesId = Convert.ToInt32(cmdSpeciment.ExecuteScalar());
                MySqlCommand cmdGender = new MySqlCommand(queryGenders, conn);
                int genderId = Convert.ToInt32(cmdGender.ExecuteScalar());
                MySqlCommand cmdLocality = new MySqlCommand(queryLocalities, conn);
                int localityId = Convert.ToInt32(cmdLocality.ExecuteScalar());
                
                try
                {
                    string queryResult = "INSERT INTO Animals (RegistrationNumber, Birthday, ChipNumber, CategoryId, Nickname, SexId, SpecialSigns, LocalityId) VALUES (@RegistrationNumber, @Birthday, @ChipNumber, @CategoryId, @Nickname, @SexId, @SpecialSigns, @LocalityId)";

                    MySqlCommand cmdResult = new MySqlCommand(queryResult, conn);
                    cmdResult.Parameters.AddWithValue("@RegistrationNumber", typedRegistrationNumber);
                    cmdResult.Parameters.AddWithValue("@Birthday", newDateTime);
                    cmdResult.Parameters.AddWithValue("@ChipNumber", typedChipNumber);
                    cmdResult.Parameters.AddWithValue("@CategoryId", speciesId);
                    cmdResult.Parameters.AddWithValue("@Nickname", typedNickname);
                    cmdResult.Parameters.AddWithValue("@SexId", genderId);
                    cmdResult.Parameters.AddWithValue("@SpecialSigns", typedSpecialSigns);
                    cmdResult.Parameters.AddWithValue("@LocalityId", localityId);

                    cmdResult.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("" + ex);
                }
                
                conn.Close();

                MessageBox.Show("Успешно добавлено");
                NavigationService.Navigate(new DataPage());
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void BtnGoBack_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
