using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_project.CoucheMétier.ServerComponent
{
    public class UserServerComponent
    {

        NpgsqlConnection connection;

        public UserServerComponent(NpgsqlConnection dbConnect){
           this.connection = dbConnect;
        }

        public void RetrieveUserRanking()
        {
             
            NpgsqlCommand command = new NpgsqlCommand("select * from public.player limit 10", connection);
            try
            {
                this.connection.Open();
                NpgsqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    MessageBox.Show(dataReader[1].ToString());
                }
                this.connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
