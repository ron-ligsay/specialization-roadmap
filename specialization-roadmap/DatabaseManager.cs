using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace specialization_roadmap
{
    public class DatabaseManager
    {
        private MySqlConnection connection;
        private string connectionString;

        public DatabaseManager()
        {
            connectionString = "server=localhost; user=root; database=specialization-roadmap-test; password=";
            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public bool OpenConnection(bool connected)
        {
            if (connected)
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException e)
                {

                    return false;
                }
            }
            return false;
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public void ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            try
            {
                OpenConnection();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User registered successfully!");
                    }
                    else
                    {
                        MessageBox.Show("User registration failed.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            CloseConnection();
        }

        public DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OpenConnection();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        public MySqlConnection GetConnection()
        {
            return this.connection;
        }

    }
}
