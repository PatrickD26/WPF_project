using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_project.CoucheMétier.ServerComponent
{
    public class OrientationServerComponent
    {
        NpgsqlConnection connection;


        public OrientationServerComponent(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        public List<Models.Question> RetriveOrientationQuestion()
        {
            List<Models.Question> questions = new List<Models.Question>();
            string sql = @"SELECT * FROM QUESTION WHERE ISORIENTATION = true";
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
                        Id = Int32.Parse(dataReader[3].ToString())
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

        public void AddQuestion(Models.Question q)
        {
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO QUESTION(isgame, label, isorientation, filiere) VALUES (:isGame, :label, :isOrientation, :filiereId)", connection);

            command.Parameters.Add(new NpgsqlParameter("isGame", NpgsqlDbType.Boolean));
            command.Parameters[0].Value = q.IsGame;
            command.Parameters.Add(new NpgsqlParameter("label", NpgsqlDbType.Text));
            command.Parameters[1].Value = q.Label;
            command.Parameters.Add(new NpgsqlParameter("isOrientation", NpgsqlDbType.Boolean));
            command.Parameters[2].Value = q.IsOrientation;
            command.Parameters.Add(new NpgsqlParameter("filiereId", NpgsqlDbType.Integer));
            command.Parameters[3].Value = q.FiliereId;

            try
            {
                this.connection.Open();
                command.ExecuteNonQuery();
                this.connection.Close();
                MessageBox.Show("Question ajoutée.");
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection fail: " + e.Message);
                this.connection.Close();
                
            }
        }

        public int GetQuestionId()
        {
            NpgsqlCommand getIdQuestion = new NpgsqlCommand("SELECT MAX(ID) FROM QUESTION", connection);

            try
            {
                this.connection.Open();
                NpgsqlDataReader dataReader = getIdQuestion.ExecuteReader();
                int idQuestion = 0;
                while (dataReader.Read())
                {
                    idQuestion = Int32.Parse(dataReader[0].ToString());
                }
                this.connection.Close();
                return idQuestion;
            }
            catch(Exception e)
            {
                MessageBox.Show("Connection fail: " + e.Message);
                this.connection.Close();
                return 0;
            }
          
        }

        public void AddResponse(Models.Response r)
        {
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO RESPONSE VALUES (:questionId, :label)", connection);

            command.Parameters.Add(new NpgsqlParameter("questionId", NpgsqlDbType.Integer));
            command.Parameters[0].Value = r.Questionid;
            command.Parameters.Add(new NpgsqlParameter("label", NpgsqlDbType.Text));
            command.Parameters[1].Value = r.Label;
    

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

