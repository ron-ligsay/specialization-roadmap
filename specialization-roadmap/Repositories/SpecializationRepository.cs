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
    /// TODO: Instead of repository use database
    /// <summary>
    /// 
    /// </summary>
    public class SpecializationRepository
    {

        //private Connection Conn;

        private readonly DatabaseManager Connection;

        public SpecializationRepository(DatabaseManager connection)
        {
            this.Connection = connection;
        }

        public async Task<ObservableCollection<SpecializationModel>> GetSpecializationModelsAsync()
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
                             "ORDER BY specializationID DESC";
                
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



    }
}
