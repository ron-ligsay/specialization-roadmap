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
    public class CourseRepository
    {

        private DatabaseManager Connection;

        public CourseRepository(DatabaseManager connection)
        {
            this.Connection = connection;
        }

        public async Task<CourseModel> GetStepModelAsync(int specializationID, int step)
        {
            CourseModel roadmapStepModel = new CourseModel();
            try
            {
                if (!Connection.OpenConnection(true))
                {
                    MessageBox.Show("Unable to connect to course/roadmap step database");
                    return roadmapStepModel;
                }

                string sql = "SELECT course.*, roadmap.Step " +
                             "FROM course JOIN roadmap ON course.CourseID = roadmap.CourseID " +
                             "WHERE roadmap.SpecializationID = @specializationID AND roadmap.Step = @step " +
                             "ORDER BY roadmap.Step ASC";
                             

                using (MySqlCommand command = new MySqlCommand(sql, Connection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@specializationID", specializationID);
                    command.Parameters.AddWithValue("@step", step);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            int roadmapStep = reader.GetOrdinal("Step");


                            CourseModel course = new()
                            {
                                Id = reader.GetInt32("CourseID"),
                                Title = reader.GetString("CourseName"),
                                Description = reader.GetString("CourseDescription"),
                                Step = roadmapStep
                            };
                            roadmapStepModel = course;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Step error: " + ex);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return roadmapStepModel;
        }

        public async Task<ObservableCollection<CourseModel>> GetStepModelsAsync(int specializationID)
        {
            ObservableCollection<CourseModel> roadmapStepModels = new ObservableCollection<CourseModel>();
            try
            {
                if (!Connection.OpenConnection(true))
                {
                    MessageBox.Show("Unable to connect to course/roadmap step database");
                    return roadmapStepModels;
                }

                string sql = "SELECT roadmap.Step, course.*" +
                             "FROM roadmap " +
                             "INNER JOIN specialization ON roadmap.SpecializationID = specialization.SpecializationID " +
                             "INNER JOIN course ON roadmap.CourseID = course.CourseID " +
                             "WHERE roadmap.SpecializationID = @specializationID";

                using (MySqlCommand command = new MySqlCommand(sql, Connection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@specializationID", specializationID);

                    // command.Parameters.AddWithValue("@count", count);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            int roadmapStep = reader.GetOrdinal("Step");


                            CourseModel step = new()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CourseID")),
                                Title = reader.GetString(reader.GetOrdinal("CourseName")),
                                Description = reader.GetString(reader.GetOrdinal("CourseDescription")),
                                Step = roadmapStep
                            };
                            roadmapStepModels.Add(step);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Step error: "+ ex);
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
