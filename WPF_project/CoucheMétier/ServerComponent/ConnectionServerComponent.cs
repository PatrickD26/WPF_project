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
    public class ConnectionServerComponent
    {
        NpgsqlConnection connection;

        public ConnectionServerComponent(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        public int ControlAccess(Models.Admin identifiers)
        {
            int id = 0;
            NpgsqlCommand command = new NpgsqlCommand("SELECT ID FROM ADMIN WHERE LOGIN = :login AND MDP = :mdp", connection);

            command.Parameters.Add(new NpgsqlParameter("login", NpgsqlDbType.Text));
            command.Parameters[0].Value = identifiers.Login;
            command.Parameters.Add(new NpgsqlParameter("mdp", NpgsqlDbType.Text));
            command.Parameters[1].Value = identifiers.Mdp;

            try
            {
                this.connection.Open();
                NpgsqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    id = (int)dataReader[0];
                }
                this.connection.Close();
                return id;

            }
            catch
            {
                MessageBox.Show("Connection fail to database");
                this.connection.Close();
                return id;
            }
        }

    }
}
