using MySql.Data.MySqlClient;
using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace specialization_roadmap.Repositories
{
    public class ResourceRepository
    {

        private DatabaseManager Connection;

        public ResourceRepository(DatabaseManager connection)
        {
            this.Connection = connection;
        }

      
        public async Task<ObservableCollection<Resource>> GetResources(int CourseID)
        {
            ObservableCollection<Resource> resources = new ObservableCollection<Resource>();
            DatabaseManager databaseManager = new DatabaseManager();
            try
            {
                if (!databaseManager.OpenConnection(true))
                {

                }
                string query = "SELECT r.Title, r.Link FROM `resources` AS r WHERE r.CourseID = @courseID";
                using (MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@courseID", CourseID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            Resource resource = new()
                            {
                                Text = reader.GetString("Title"),
                                Hyperlink = reader.GetString("Link")
                            };
                            resources.Add(resource);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get Link Resources :" + ex);
            }
            finally
            {
                databaseManager.CloseConnection();
            }

            return resources;
        }

    }
}
