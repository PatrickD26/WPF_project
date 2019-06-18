using Npgsql;
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

namespace WPF_project
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NpgsqlConnection connection;
        string connectionString = String.Format("Server={0};Port={1};User Id ={2};Password={3};Database={4}",
            "localhost", 5432, "postgres", "test", "ways");

        public MainWindow()
        {
            InitializeComponent();

        }

        
       private void Button_Click(object sender, RoutedEventArgs e)
        {
            Homepage.Homepage home = new Homepage.Homepage();
            home.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show("connection ok");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("erreur de connection à la base de données");
            }
        }
    }
}
