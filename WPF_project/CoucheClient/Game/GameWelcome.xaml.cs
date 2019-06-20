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
        int score = 0;
        public Game()
        {
            InitializeComponent();
            MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
            questionArray = win.dbConnection.gameService.RetrieveGameQuestions();
            foreach(Models.Question question in questionArray)
            {
                question.QuestionAnswers = win.dbConnection.gameService.GetQuestionAnswers(question.Id);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("BONJOUR");
        }

        private void correctAnswer()
        {
            score += 1;
        }
    }
}
