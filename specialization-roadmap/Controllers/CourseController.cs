using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Tls;
using specialization_roadmap.Entities;
using specialization_roadmap.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace specialization_roadmap.Controllers
{
    public class CourseController
    {
        private readonly CourseRepository roadmapRepository;
        private readonly DatabaseManager Connection;

        public CourseController(int specializationID)
        {
            Connection = new DatabaseManager();
            roadmapRepository = new CourseRepository(Connection);
            LoadStepModelsAsync(specializationID);
        }

        public CourseController(int specializationID, int step)
        {
            Connection = new DatabaseManager();
            roadmapRepository = new CourseRepository(Connection);
            LoadStepModelAsync(specializationID, step);
        }



        private CourseModel roadmapStep { get; set; }
        public CourseModel RoadmapStep
        {
            get { return roadmapStep; }
            set { roadmapStep = value; }
        }
        
         private async void LoadStepModelAsync(int specializationID, int step)
         {
            RoadmapStep = await roadmapRepository.GetStepModelAsync(specializationID, step);
         }

        private ObservableCollection<CourseModel> roadmapSteps {get; set;}
        public ObservableCollection<CourseModel> RoadmapSteps
        {
            get { return roadmapSteps; }
            set { roadmapSteps = value; }
        }

        private async void LoadStepModelsAsync(int specializationID)
        {
            RoadmapSteps = await roadmapRepository.GetStepModelsAsync(specializationID);
        }

        public int thisStep(int specializationID, int courseID)
        {
            DatabaseManager databaseManager = new DatabaseManager();
            int currentStep = 0;


            try
            {

                databaseManager.OpenConnection(true);
                string query = "SELECT roadmap.Step FROM course JOIN roadmap ON course.CourseID = roadmap.CourseID WHERE roadmap.SpecializationID = @specializationID AND roadmap.CourseID = @CourseId; ";

                using (MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@CourseId ", courseID);
                    command.Parameters.AddWithValue("@specializationID", specializationID);
                    command.ExecuteNonQuery();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows && reader.Read())
                        {
                            currentStep = reader.GetInt32("Step");
                        }
                        else
                        {
                            MessageBox.Show("last specialization reader is empty");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("last specialization query error" + ex);
            }
            finally
            {
                databaseManager.CloseConnection();
            }
            return currentStep;
        }



        /*
        public List<RoadmapStepModel> GetAllRoadmaps()
        {
            return roadmapRepository.GetAllRoadmapSteps();
        }

        public RoadmapStepModel GetRoadmapStepsByIndex(int index)
        {
            return roadmapRepository.GetRoadmapStepByIndex(index);
        }*/

        //public RoadmapController GetRoadmapStepById(int id)
        //{
        //    return roadmapRepository.GetRoadmapStepById(id);
        //}

        //public RoadmapStepModel GetAllRoadmapStepsBySpecialization(int specializationId)
        //{
        //    return roadmapRepository.GetRoadmapStepBySpecialization(specializationId);
        //}

        //public List<RoadmapStepModel> GetRoadmapStepsBySpecialization(int specializationId)
        //{
        //    return roadmapRepository.GetRoadmapStepBySpecialization(specializationId);
        //}

        //public RoadmapStepModel GetRoadmapStepsBySpecialization(int specializationId, int index)
        //{
        //    //return GetRoadmapStepsBySpecialization[index];
        //    //foreach  (object step in GetRoadmapStepsBySpecialization(specializationId){
        //    //    int stepId = step[1].Id;
        //    //}

        //    //return GetRoadmapStepById(stepId);
        //    return GetRoadmapStepsBySpecialization.IndexOf(index);
        //}
        /*
        public List<RoadmapStepModel> SearchRoadmapStep(string name, bool status)
        {
            return roadmapRepository.SearchRoadmapStep(name, status);
        }

        public RoadmapStepModel GetNextRoadmapStep(RoadmapStepModel roadmapStepModel, int specializationId)
        {
            return roadmapRepository.GetNextRoadmapStep(roadmapStepModel, specializationId);
        }

        public RoadmapStepModel GetNextRoadmapStep(int specializationId, int step)
        {
            return roadmapRepository.GetNextRoadmapStep(specializationId, step);
        }

        public RoadmapStepModel GetNextRoadmapStep()
        {
            return ;
        }
        */
    }
}
