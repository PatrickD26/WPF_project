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

namespace WPF_project.CoucheClient.Admin
{
    /// <summary>
    /// Logique d'interaction pour OrientationAdminPage.xaml
    /// </summary>
    public partial class OrientationAdminPage : Page
    {
        NpgsqlConnection connection;

        public OrientationAdminPage()
        {
            InitializeComponent();
        }

        public OrientationAdminPage(NpgsqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();

            RetriveOrientationQuestion();

        }


        public void RetriveOrientationQuestion()
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
            }
            catch(Exception e)
            {
                MessageBox.Show("Connection fail" + e.Message);
            }

        }
     
    }
}
