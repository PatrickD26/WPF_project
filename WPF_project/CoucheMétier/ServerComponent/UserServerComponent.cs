using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
               
            NpgsqlCommand command = new NpgsqlCommand("select * from public.Question where IsOrientation = true");
            try
            {
                this.connection.Open();
                //NpgsqlDataReader dataReader = command.ExecuteReader();
                Console.WriteLine("ça marche !");
                this.connection.Close();
            }
            catch
            {
                Console.WriteLine("hello");
            }
        }
    }
}
