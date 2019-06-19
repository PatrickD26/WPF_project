using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
using WPF_project.CoucheMétier.ServerComponent;

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
            MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
            List<Models.Question> questions = win.dbConnection.orientationServerComponent.RetriveOrientationQuestion();
        }

    } 

}
