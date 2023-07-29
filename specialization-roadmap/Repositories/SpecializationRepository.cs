using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Tls;
using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace specialization_roadmap.Repositories
{
    public class SpecializationRepository
    {
        private readonly DatabaseManager Connection;

        public SpecializationRepository(DatabaseManager connection)
        {
            this.Connection = connection;
        }

        // Gets All the specialization Data
        public async Task<ObservableCollection<SpecializationModel>> 
            GetSpecializationModelsAsync()
        {
            ObservableCollection<SpecializationModel> specializationModels = new();
            try
            {
                if(!Connection.OpenConnection(true))
                {
                    MessageBox.Show("did not connect");
                    return specializationModels;
                }

                string sql = "SELECT * FROM `specialization`"+
                             "ORDER BY specializationID ASC";
                
                using (MySqlCommand command = new(sql, Connection.GetConnection()))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            SpecializationModel specialization = new()
                            {
                                Id = reader.GetInt32("SpecializationID"),
                                Title = reader.GetString("SpecializationName"),
                                Description = reader.GetString("SpecializationDescription")
                            };

                            specializationModels.Add(specialization);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return specializationModels;
        }

        // Gets the first limit rows in the specialization Data
        public async Task<ObservableCollection<SpecializationModel>> 
            GetSpecializationModelsAsync(int limit)
        {
            ObservableCollection<SpecializationModel> specializationModels = new();
            try
            {
                if (!Connection.OpenConnection(true))
                {
                    MessageBox.Show("did not connect");
                    return specializationModels;
                }

                string sql = "SELECT * FROM `specialization`" +
                             "ORDER BY specialization.LastOpenDate DESC LIMIT @limit";

                using (MySqlCommand command = new(sql, Connection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@limit", limit);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            SpecializationModel specialization = new()
                            {
                                Id = reader.GetInt32("SpecializationID"),
                                Title = reader.GetString("SpecializationName"),
                                Description = reader.GetString("SpecializationDescription")
                            };

                            specializationModels.Add(specialization);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return specializationModels;
        }
    }
}
