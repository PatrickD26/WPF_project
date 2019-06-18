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
        public AdminLog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CoucheClient.Admin.AdminModify adminModifyPage = new CoucheClient.Admin.AdminModify();
            this.NavigationService.Navigate(adminModifyPage);
        }

    }
}
