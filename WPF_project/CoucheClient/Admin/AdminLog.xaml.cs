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
using System.Windows.Shapes;

namespace WPF_project.CoucheClient.Admin
{
    /// <summary>
    /// Logique d'interaction pour Admin_log.xaml
    /// </summary>
    public partial class AdminLog : Page
    {
        MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;

        public AdminLog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text != "" && password.Text != "")
            {
                Models.Admin identifiers = new Models.Admin()
                {
                    Login = login.Text,
                    Mdp = password.Text
                };

                int authorized = win.dbConnection.connectionService.ControlAccess(identifiers);
                if(authorized != 0)
                {
                    CoucheClient.Admin.OrientationAdminPage adminModifyPage = new CoucheClient.Admin.OrientationAdminPage();
                    this.NavigationService.Navigate(adminModifyPage);
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect.");
                }
            } else
            {
                MessageBox.Show("Veuillez remplir tout les champs.");
            }



        }

    }
}
