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

namespace WPF_project.CoucheClient.Admin
{
    /// <summary>
    /// Logique d'interaction pour OrientationAdminPage.xaml
    /// </summary>
    public partial class OrientationAdminPage : Page
    {
        public OrientationAdminPage()
        {
            
            InitializeComponent();
            ChargerQuestions();
        }


        public void ChargerQuestions()
        {
            ConnectionBdd connection = new ConnectionBdd();
            connection.ConnectToDataBase();
            
            Models.Question questions = new Models.Question();

            NpgsqlCommand command = new NpgsqlCommand("select * from public.Question where isOrientation = true", connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();

        }

      
    }
}
