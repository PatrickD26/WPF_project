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

namespace WPF_project.CoucheClient.Game
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Game : Page
    {
        List<Models.Question> questionArray;
        public Game()
        {
            InitializeComponent();
            MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
            win.dbConnection.gameService.retrieveGameQuestions();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("BONJOUR");
        }
    }
}
