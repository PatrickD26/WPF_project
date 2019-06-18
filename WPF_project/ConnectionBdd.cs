using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_project
{
  
    public class ConnectionBdd
    {
        private NpgsqlConnection connection;
        string connectionString = String.Format("Server={0};Port={1};User Id ={2};Password={3};Database={4}",
            "localhost", 5432, "postgres", "test", "ways");

        public void ConnectToDataBase()
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show("connection ok");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("erreur de connection à la base de données");
            }

        }
     
    }
}
