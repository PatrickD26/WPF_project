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
    public partial class Homepage : Window
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CoucheClient.Admin.AdminLog admin_log = new CoucheClient.Admin.AdminLog();
            admin_log.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CoucheClient.Orientation.OrientationWelcome orientation = new CoucheClient.Orientation.OrientationWelcome();          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CoucheClient.Game.Game game = new CoucheClient.Game.Game();
            game.Show();
            this.Hide();
        }
    }
}
