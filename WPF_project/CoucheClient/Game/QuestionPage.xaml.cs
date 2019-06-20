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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_project.CoucheClient.Game
{
    /// <summary>
    /// Logique d'interaction pour QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        int index = 0;
        List<Models.Question> questions;
        int score = 0;

        public QuestionPage()
        {
            InitializeComponent();
        }

        public QuestionPage(List<Models.Question> question_list)
        {
            InitializeComponent();
            questions = question_list;
            question_label.Content = question_list[0].Label;
            liste_reponse.ItemsSource = question_list[0].QuestionAnswers;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VerificationReponse(liste_reponse.SelectedItem as Models.Response, questions[index]);
            if(questions.Count > index)
            {
                index += 1;
                UpdateQuestionView(index);
            }
        
            
        }

        public void VerificationReponse(Models.Response reponseSelected, Models.Question question)
        {
            if(question.Answer == reponseSelected.Id)
            {
                score += 1;
            }
        }

        public void UpdateQuestionView(int i)
        {
            question_label.Content = questions[i].Label;
            liste_reponse.ItemsSource = questions[i].QuestionAnswers;
            liste_reponse.Items.Refresh();
        }
    }
}
