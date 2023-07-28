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

        public CourseModel GetCourseModel(int specializationID, int step)
        {
            DatabaseManager Connection = new DatabaseManager();
            CourseModel roadmapStepModel = new CourseModel();
            //MessageBox.Show("specializationID: " + specializationID + ", step: " + step);
            try
            {
                if (!Connection.OpenConnection(true))
                {
                    MessageBox.Show("Unable to connect to course/roadmap step database");
                    return roadmapStepModel;
                }

                string sql = "SELECT course.*, roadmap.Step " +
                             "FROM course JOIN roadmap ON course.CourseID = roadmap.CourseID " +
                             "WHERE roadmap.SpecializationID = @specializationID AND roadmap.Step = @step ";



                using (MySqlCommand command = new MySqlCommand(sql, Connection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@specializationID", specializationID);
                    command.Parameters.AddWithValue("@step", step);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
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
                        else
                        {
                            MessageBox.Show("Getting Step Course Model Failed");
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


        // get courses step
        public int getCourseStep(int specializationID, int courseID)
        {
            DatabaseManager databaseManager = new DatabaseManager();
            int currentStep = 0; // Initialize currentStep with a default value

            try
            {
                databaseManager.OpenConnection(true);
                string query = "SELECT roadmap.Step FROM course JOIN roadmap ON course.CourseID = roadmap.CourseID WHERE roadmap.SpecializationID = @specializationID AND roadmap.CourseID = @courseId";
                using (MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@courseId", courseID);
                    command.Parameters.AddWithValue("@specializationID", specializationID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            currentStep = reader.GetInt32("Step");
                        }
                        else
                        {
                            MessageBox.Show("No roadmap data found for the given specialization and course.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("RoadmapStepWindow query error" + ex);
            }
            finally
            {
                databaseManager.CloseConnection();
            }
            return currentStep;
        }

        public bool UpdateCourseStatus(int courseID, bool status)
        {
            DatabaseManager databaseManager = new DatabaseManager();
            
            try
            {
                databaseManager.OpenConnection(true);

                string query = "Update course SET CourseStatus = @Status WHERE CourseID = @CourseID";

                using (MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@CourseID", courseID);
                    command.Parameters.AddWithValue("@Status", status);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0; // Return true if the update was successful
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
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
