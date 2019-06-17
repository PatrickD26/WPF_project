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

namespace WPF_project
{
    /// <summary>
    /// Logique d'interaction pour Admin_log.xaml
    /// </summary>
    public partial class Admin_log : Window
    {
        public Admin_log()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin_modify admin_modify = new Admin_modify();
            admin_modify.Show();
            this.Hide();
        }

    }
}
