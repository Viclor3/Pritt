using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System.Windows;

namespace Pritt
{
    public class Connection
    {
        private MySqlConnection conn;

        public Connection()
        {
            Initialize();
        }

        private void Initialize()
        {
            string connectionString = "SERVER=localhost;DATABASE=Pritt;UID=root;PASSWORD=;";
            conn = new MySqlConnection(connectionString);

        }

        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException e) 
            {
                switch (e.Number)
                {
                    case 0: 
                        MessageBox.Show("Невозможно подключиться к базе данных");
                        break;
                    case 1045:
                        MessageBox.Show("Введены неверные данные");
                        break;
                }
                return false;
            }
        }

        public void CloseConnection()
        {
            this.conn.Close();
        }

        public MySqlConnection get_connection()
        {
            return this.conn;
        }
    }
}
