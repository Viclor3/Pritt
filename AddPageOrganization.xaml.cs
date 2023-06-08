using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
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
    /// Логика взаимодействия для AddPageOrganization.xaml
    /// </summary>
    public partial class AddPageOrganization : Page
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

                string queryOrganizationTypes = "select OrganizationTypes.Name as OrganizationTypeName from OrganizationTypes";
                string queryLocalities = "select Localities.Name as LocalityName from Localities";

                MySqlCommand cmd = new MySqlCommand(queryOrganizationTypes, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbCategory.Items.Add(reader["OrganizationTypeName"].ToString());
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

        public AddPageOrganization()
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

            string typedFullName = txFullName.Text;
            string typedInn = txInn.Text;
            string typedKpp = txKpp.Text;
            string typedAddress = txAddress.Text;
            string typedLegal = txLegal.Text;

            string comboBoxCategory = cbCategory.SelectedItem.ToString();
            string comboBoxLocality = cbLocality.SelectedItem.ToString();

            string queryOrganizationTypes = "select Id from OrganizationTypes where Name = '" + comboBoxCategory + "'";
            string queryLocalities = "select Id from Localities where Name ='" + comboBoxLocality + "'";

            conn.Open();

            MySqlCommand cmdSpeciment = new MySqlCommand(queryOrganizationTypes, conn);
            int typeId = Convert.ToInt32(cmdSpeciment.ExecuteScalar());
            MySqlCommand cmdLocality = new MySqlCommand(queryLocalities, conn);
            int localityId = Convert.ToInt32(cmdLocality.ExecuteScalar());

            try
            {
                string queryResult = "INSERT INTO Organizations (FullName, Inn, Kpp, RegistrationAddress, OrganizationTypeId, NaturalOrLegalPerson, LocalityId) VALUES (@FullName, @Inn, @Kpp, @RegistrationAddress, @Type, @Legal, @Locality)";

                MySqlCommand cmdResult = new MySqlCommand(queryResult, conn);
                cmdResult.Parameters.AddWithValue("@FullName", typedFullName);
                cmdResult.Parameters.AddWithValue("@Inn", typedInn);
                cmdResult.Parameters.AddWithValue("@Kpp", typedKpp);
                cmdResult.Parameters.AddWithValue("@RegistrationAddress", typedAddress);
                cmdResult.Parameters.AddWithValue("@Type", typeId);
                cmdResult.Parameters.AddWithValue("@Legal", typedLegal);
                cmdResult.Parameters.AddWithValue("@Locality", localityId);

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
        
    }
}
