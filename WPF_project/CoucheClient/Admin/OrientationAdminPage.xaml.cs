using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        MainWindow win = (MainWindow)System.Windows.Application.Current.MainWindow;
        List<Models.Question> questions;
        List<Models.Question> questionsGame;

        Models.Question questionAModifier;
        List<Models.Response> reponsesAModifier;

        public OrientationAdminPage()
        {
            InitializeComponent();

            this.questions = win.dbConnection.orientationService.RetriveOrientationQuestion();
            this.questionsGame = win.dbConnection.gameService.RetrieveGameQuestions();

            listeViewQuestion.ItemsSource = questions;
            listeViewQuestionGame.ItemsSource = questionsGame;
        }


        /// <summary>
        ///  Dele an Orientation Question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Models.Question q = listeViewQuestion.SelectedItem as Models.Question;
            win.dbConnection.orientationService.DeleteQuestion(q);
            this.questions = win.dbConnection.orientationService.RetriveOrientationQuestion();
            listeViewQuestion.ItemsSource = questions;
            listeViewQuestion.Items.Refresh();
        }

        /// <summary>
        /// Delete a Game Question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DeleteGame(object sender, RoutedEventArgs e)
        {
            Models.Question q = listeViewQuestionGame.SelectedItem as Models.Question;
            win.dbConnection.gameService.DeleteQuestion(q);
            this.questionsGame = win.dbConnection.gameService.RetrieveGameQuestions();
            listeViewQuestion.ItemsSource = questionsGame;
            listeViewQuestion.Items.Refresh();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if (Label.Text != "" && (((ComboBoxItem)ComboBoxIsGame.SelectedItem).Content != ((ComboBoxItem)ComboBoxIsOrientation.SelectedItem).Content)
                && Reponse1.Text != "" && Reponse2.Text != "" && Reponse3.Text != "")
            {
                bool ControleComboBox(string s)
                {
                    if (s == "true")
                    {
                        return true;
                    }
                    else
                        return false;
                }

                int ControleComboBoxFiliere(string s)
                {
                    if(s == "AP")
                    {
                        return 1;
                    } else
                    {
                        return 2;
                    }
                }

                Models.Question q = new Models.Question()
                {
                    IsGame = ControleComboBox(((ComboBoxItem)ComboBoxIsGame.SelectedItem).Content as string),
                    Label = Label.Text,
                    IsOrientation = ControleComboBox(((ComboBoxItem)ComboBoxFiliere.SelectedItem).Content as string),
                    FiliereId = ControleComboBoxFiliere(((ComboBoxItem)ComboBoxFiliere.SelectedItem).Content as string),
                };

                win.dbConnection.orientationService.AddQuestion(q);
                int idQuestionAdd = win.dbConnection.orientationService.GetQuestionId();

                List<string> reponses = new List<string>();

                reponses.Add(Reponse1.Text);
                reponses.Add(Reponse2.Text);
                reponses.Add(Reponse3.Text);

                foreach (string reponse in reponses)
                {
                    Models.Response rep = new Models.Response()
                    {
                        Questionid = idQuestionAdd,
                        Label = reponse
                    };

                    win.dbConnection.orientationService.AddResponse(rep);
                }

                if (q.IsOrientation == true)
                {
                    this.questions = win.dbConnection.orientationService.RetriveOrientationQuestion();
                    listeViewQuestion.ItemsSource = questions;
                    listeViewQuestion.Items.Refresh();
                }
                else
                {
                    this.questionsGame = win.dbConnection.gameService.RetrieveGameQuestions();
                    listeViewQuestionGame.ItemsSource = questionsGame;
                    listeViewQuestionGame.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Pour ajouter une question, renseignez tous les champs.");
            }

        }

        private void Button_Modif_Orientation(object sender, RoutedEventArgs e)
        {
            questionAModifier = listeViewQuestion.SelectedItem as Models.Question;
            reponsesAModifier = win.dbConnection.orientationService.GetQuestionAnswers(questionAModifier.Id);

            ModifLabel.Text = questionAModifier.Label;
            ModifReponse1.Text = reponsesAModifier[0].Label;
            ModifReponse2.Text = reponsesAModifier[1].Label;
            ModifReponse3.Text = reponsesAModifier[2].Label;
        }

        private void Button_Modif_Game(object sender, RoutedEventArgs e)
        {
            questionAModifier = listeViewQuestionGame.SelectedItem as Models.Question;
            reponsesAModifier = win.dbConnection.gameService.GetQuestionAnswers(questionAModifier.Id);

            ModifLabel.Text = questionAModifier.Label;
            ModifReponse1.Text = reponsesAModifier[0].Label;
            ModifReponse2.Text = reponsesAModifier[1].Label;
            ModifReponse3.Text = reponsesAModifier[2].Label;
        }

        private void Button_Valider_Modif(object sender, RoutedEventArgs e)
        {
            if (ModifLabel.Text != "" && ModifReponse1.Text != "" && ModifReponse2.Text != "" && ModifReponse3.Text != "")
            {
                if (questionAModifier.IsOrientation == true)
                {
                    win.dbConnection.orientationService.UpdateQuestion(questionAModifier.Id, ModifLabel.Text);

                    reponsesAModifier[0].Label = ModifReponse1.Text;
                    reponsesAModifier[1].Label = ModifReponse2.Text;
                    reponsesAModifier[2].Label = ModifReponse3.Text;

                    foreach (Models.Response response in reponsesAModifier)
                    {
                        win.dbConnection.orientationService.UpdateResponse(questionAModifier.Id, response.Id, response.Label);
                    }

                    this.questions = win.dbConnection.orientationService.RetriveOrientationQuestion();
                    listeViewQuestion.ItemsSource = questions;
                    listeViewQuestion.Items.Refresh();
                }
                else if (questionAModifier.IsGame == true)
                {
                    win.dbConnection.gameService.UpdateQuestion(questionAModifier.Id, ModifLabel.Text);

                    reponsesAModifier[0].Label = ModifReponse1.Text;
                    reponsesAModifier[1].Label = ModifReponse2.Text;
                    reponsesAModifier[2].Label = ModifReponse3.Text;

                    foreach (Models.Response response in reponsesAModifier)
                    {
                        win.dbConnection.orientationService.UpdateResponse(questionAModifier.Id, response.Id, response.Label);
                    }

                    this.questionsGame = win.dbConnection.gameService.RetrieveGameQuestions();
                    listeViewQuestionGame.ItemsSource = questionsGame;
                    listeViewQuestionGame.Items.Refresh();
                }
            } else
            {
                MessageBox.Show("Pour valider, les champs ne peuvent pas être null");
            }
           

        }

        private void Button_Annuler_Modif(object sender, RoutedEventArgs e)
        {
            ModifLabel.Text = "";
            ModifReponse1.Text = "";
            ModifReponse2.Text = "";
            ModifReponse3.Text = "";
        }

        private void Button_Orientation_Down(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Orientation_Up(object sender, RoutedEventArgs e)
        {

        }
    }
}
