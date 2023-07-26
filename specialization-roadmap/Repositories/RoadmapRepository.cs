using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Tls;
using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace specialization_roadmap.Repositories
{
    public class RoadmapRepository
    {

        private DatabaseManager Connection;

        public RoadmapRepository(DatabaseManager connection)
        {
            this.Connection = connection;
        }
        
        public async Task<ObservableCollection<RoadmapStepModel>> GetStepModelsAsync(int specializationID)
        {
            ObservableCollection<RoadmapStepModel> roadmapStepModels = new ObservableCollection<RoadmapStepModel>();
            try
            {
                if (!Connection.OpenConnection(true))
                {
                    MessageBox.Show("Unable to connect to course/roadmap step database");
                    return roadmapStepModels;
                }

                string sql = "SELECT Step, course.CourseName AS Course," +
                             "course.CourseDescription AS Description FROM roadmap" +
                             "INNER JOIN specialization ON roadmap.SpecializationID = specialization.SpecializationID" +
                             "INNER JOIN course ON roadmap.CourseID = course.CourseID" +
                             "WHERE roadmap.SpecializationID = " +
                             specializationID;

                using (MySqlCommand command = new(sql, Connection.GetConnection()))
                {
                    // command.Parameters.AddWithValue("@count", count);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            int roadmapStep = reader.GetOrdinal("Step");


                            RoadmapStepModel step = new()
                            {
                                Title = reader.GetString("Title"),
                                Description = reader.GetString("Description"),
                                Step = roadmapStep
                            };
                            roadmapStepModels.Add(step);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("step error");
            }
            finally
            {
                Connection.CloseConnection();
            }
            return roadmapStepModels;
        }
        
        /*
        public List<RoadmapStepModel> GetAllRoadmapSteps()
        {
            return RoadmapDataSource();
        }

        public RoadmapStepModel GetRoadmapStepById(int id)
        {
            return RoadmapDataSource().FirstOrDefault(x => x.Id == id);
        }

        public RoadmapStepModel GetRoadmapStepById(int id, bool status)
        {
            return RoadmapDataSource().FirstOrDefault(x => x.Id == id && x.Status == status);
        }

        public RoadmapStepModel GetRoadmapStepByIndex(int index)
        {
            return RoadmapDataSource()[index];
        }
        */


   
    }
}
