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

namespace WPF_project.CoucheClient.Homepage
{
    /// <summary>
    /// Logique d'interaction pour Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CoucheClient.Admin.AdminLog logPage = new CoucheClient.Admin.AdminLog();
            this.NavigationService.Navigate(logPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CoucheClient.Orientation.OrientationWelcome orientationPage = new CoucheClient.Orientation.OrientationWelcome();
            this.NavigationService.Navigate(orientationPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CoucheClient.Game.Game gamePage = new CoucheClient.Game.Game();
            this.NavigationService.Navigate(gamePage);
        }
    }
}
