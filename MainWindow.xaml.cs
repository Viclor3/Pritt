using MySql.Data.MySqlClient;
using Pritt;
using System.Windows;
using System.Windows.Navigation;

namespace Pritt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new LoginPage());
        }

    }
}
