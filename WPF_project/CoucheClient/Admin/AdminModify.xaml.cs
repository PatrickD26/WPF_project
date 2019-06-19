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
    /// Logique d'interaction pour AdminModify.xaml
    /// </summary>
    public partial class AdminModify : Page
    {
        public AdminModify()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrientationAdminPage orientationAdminPage = new OrientationAdminPage();
            this.NavigationService.Navigate(orientationAdminPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Orientation.OrientationWelcome orientationWelcomePage = new Orientation.OrientationWelcome();
            this.NavigationService.Navigate(orientationWelcomePage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Game.Game gamePage = new Game.Game();
            this.NavigationService.Navigate(gamePage);
        }
    }
}
