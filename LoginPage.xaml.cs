using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private string username, password, sql;
        private Connection conn = new Connection();
        private MySqlCommand cmd;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Authorization(object sender, RoutedEventArgs e)
        {
            username = TbLogin.Text;
            password = TbPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполнены не все поля");
            }
            else
            {
                sql = "select Login,Password from Users where Login = '" + username + "' and Password = '" + password + "'";
                if (conn.OpenConnection() == true)
                {
                    try
                    {
                        cmd = new MySqlCommand(sql, conn.get_connection());
                        object a = cmd.ExecuteScalar();
                        if (a == null)
                        {
                            MessageBox.Show("Данные введены неверно");
                        }
                        else
                        {
                            NavigationService.Navigate(new DataPage());
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                }
            }
            TbLogin.Text = "";
            TbPassword.Text = "";
            conn.CloseConnection();
        }
    }
}
