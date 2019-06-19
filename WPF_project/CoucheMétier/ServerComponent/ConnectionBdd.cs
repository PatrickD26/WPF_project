﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows;
using WPF_project.CoucheClient.Admin;
using WPF_project.CoucheMétier.ServerComponent;

namespace WPF_project
{

    public class ConnectionBdd
    {
        public static string connectionString = String.Format("Server={0};Port={1};User Id ={2};Password={3};Database={4}",
            "localhost", 5432, "postgres", "test", "ways");
        public static NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        public UserServerComponent userService = new UserServerComponent(connection);
        public OrientationAdminPage orientationAdminPage = new OrientationAdminPage(connection);

        
      
        public NpgsqlConnection ConnectToDataBase()
        {
            
            try
            {
                connection.Open();
                MessageBox.Show("connection ok");
                return connection;
            }
            catch
            {
                MessageBox.Show("erreur de connection à la base de données");
            }

            return connection;

        }




    }
}
