using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_project.CoucheMétier.ServerComponent
{
    public class GameServerComponent
    {
        NpgsqlConnection connection;

        public GameServerComponent(NpgsqlConnection dbConnect)
        {
            this.connection = dbConnect;
        }

        public void retrieveGameQuestions()
        {
            NpgsqlCommand command = new NpgsqlCommand("select * from question where isgame=true", connection);
            List<Models.Question> questionArray = new List<Models.Question>();
            try
            {
                this.connection.Open();
                NpgsqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    MessageBox.Show((String)dataReader[1]);
                    //Models.Question retrievedQuestion = new Models.Question();
                    //retrievedQuestion.IsGame = (bool)dataReader[0];
                    //retrievedQuestion.Label = (String)dataReader[1];
                    //retrievedQuestion.IsOrientation = (bool)dataReader[2];
                    //retrievedQuestion.Id = (int)dataReader[3];
                    //retrievedQuestion.QuestionAnswers = retrieveGameAnswers(retrievedQuestion);
                    //questionArray.Add(retrievedQuestion); 
                }
                this.connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
          //  return questionArray;
        }

        public List<Models.Response> retrieveGameAnswers(Models.Question question)
        {
            List<Models.Response> responseArray = new List<Models.Response>();
            NpgsqlCommand command = new NpgsqlCommand("select * from response WHERE questionid=:id", connection);
            command.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer);
            command.Parameters[0].Value = question.Id;
            try
            {
                this.connection.Open();
                NpgsqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Models.Response retrievedResponse = new Models.Response();
                    retrievedResponse.Id = (int)dataReader[0];
                    retrievedResponse.Questionid = (int)dataReader[1];
                    retrievedResponse.Label = (String)dataReader[2];
                    question.QuestionAnswers.Add(retrievedResponse);
                }
                this.connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return responseArray;
        }
    }
}
