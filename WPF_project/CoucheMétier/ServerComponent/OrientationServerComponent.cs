using Npgsql;
using System;
using System.Collections.Generic;
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

            //NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Question; ", this.connection);
            NpgsqlCommand com = connection.CreateCommand();
            com.CommandText = sql;

            try
            {
                this.connection.Open();
                MessageBox.Show("Connection ok");

                NpgsqlDataReader dateReader = com.ExecuteReader();
                while (dateReader.Read())
                {
                    Models.Question question = new Models.Question()
                    {

                        Id = Int32.Parse(dateReader[0].ToString()),
                        IsGame = (bool)dateReader[1],
                        Label = dateReader[2].ToString(),
                        ResponseId = Int32.Parse(dateReader[3].ToString()),
                        IsOrientation = (bool)dateReader[4]
                    };

                    questions.Add(question);

                }
                
                this.connection.Close();
                return questions;
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection fail: " + e.Message);
                return questions;
            }

        }

    }
}

