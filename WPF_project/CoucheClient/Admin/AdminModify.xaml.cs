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
            CoucheClient.Admin.OrientationAdminPage orientationAdminPage = new CoucheClient.Admin.OrientationAdminPage();
            this.NavigationService.Navigate(orientationAdminPage);
        }
    }
}
