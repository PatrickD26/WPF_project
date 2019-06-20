using Npgsql;
using NpgsqlTypes;
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

        public GameServerComponent(NpgsqlConnection connection)
        {
            this.connection = connection;
        }



        public List<Models.Question> RetrieveGameQuestions()
        {
            List<Models.Question> questions = new List<Models.Question>();
            string sql = @"SELECT * FROM QUESTION WHERE ISGAME = true";
            NpgsqlCommand com = connection.CreateCommand();
            com.CommandText = sql;

            try
            {
                this.connection.Open();

                NpgsqlDataReader dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    Models.Question question = new Models.Question()
                    {
                        IsGame = (bool)dataReader[0],
                        Label = dataReader[1].ToString(),
                        IsOrientation = (bool)dataReader[2],
                        Id = Int32.Parse(dataReader[3].ToString()),
                        Ordre = Int32.Parse(dataReader[4].ToString()),
                        FiliereId = Int32.Parse(dataReader[5].ToString()),
                        Answer = Int32.Parse(dataReader[6].ToString()),

                    };

                    questions.Add(question);

                }

                this.connection.Close();
                return questions;
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection fail: " + e.Message);
                this.connection.Close();
                return questions;
            }

        }

        public void DeleteQuestion(Models.Question q)
        {
            int idQuestion = q.Id;

            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM QUESTION WHERE ID = :idQuestion", connection);

            command.Parameters.Add(new NpgsqlParameter("idQuestion", NpgsqlDbType.Integer));
            command.Parameters[0].Value = idQuestion;

            try
            {
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();
                MessageBox.Show("Question n°: " + q.Id + " supprimée.");
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection fail: " + e.Message);
                this.connection.Close();
            }
        }

        public List<Models.Response> GetQuestionAnswers(int id)
        {
            List<Models.Response> responses = new List<Models.Response>();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM RESPONSE WHERE QUESTIONID = :questionId", connection);

            command.Parameters.Add(new NpgsqlParameter("questionId", NpgsqlDbType.Integer));
            command.Parameters[0].Value = id;

            try
            {
                this.connection.Open();
                NpgsqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Models.Response reponse = new Models.Response()
                    {
                        Questionid = (int)dataReader[0],
                        Label = dataReader[1].ToString(),
                        Id = Int32.Parse(dataReader[2].ToString())
                    };

                    responses.Add(reponse);
                }
                this.connection.Close();
                return responses;

            }
            catch (Exception e)
            {
                MessageBox.Show("Connection fail: " + e.Message);
                this.connection.Close();
                return responses;
            }
        }

        public void UpdateQuestion(int id, string label)
        {
            NpgsqlCommand command = new NpgsqlCommand("UPDATE QUESTION SET LABEL = :label WHERE ID = :questionId", connection);

            command.Parameters.Add(new NpgsqlParameter("label", NpgsqlDbType.Text));
            command.Parameters[0].Value = label;
            command.Parameters.Add(new NpgsqlParameter("questionId", NpgsqlDbType.Integer));
            command.Parameters[1].Value = id;

            try
            {
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Connection fail: " + e.Message);
                this.connection.Close();
            }
        }

        public void UpdateResponse(int id, int reponseId, string label)
        {
            NpgsqlCommand command = new NpgsqlCommand("UPDATE RESPONSE SET LABEL = :label WHERE QUESTIONID = :questionId AND ID = :responseId", connection);

            command.Parameters.Add(new NpgsqlParameter("label", NpgsqlDbType.Text));
            command.Parameters[0].Value = label;
            command.Parameters.Add(new NpgsqlParameter("questionId", NpgsqlDbType.Integer));
            command.Parameters[1].Value = id;
            command.Parameters.Add(new NpgsqlParameter("responseId", NpgsqlDbType.Integer));
            command.Parameters[2].Value = reponseId;


            try
            {
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Connection fail: " + e.Message);
                this.connection.Close();
            }
        }
    }
}
