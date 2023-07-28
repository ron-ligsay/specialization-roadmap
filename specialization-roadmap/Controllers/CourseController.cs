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
        private readonly CourseRepository courseRepository;
        private readonly DatabaseManager Connection;

        public CourseController(int specializationID)
        {
            Connection = new DatabaseManager();
            courseRepository = new CourseRepository(Connection);
            LoadStepModelsAsync(specializationID);
        }

        public CourseController(int specializationID, int step, bool model)
        {
            Connection = new DatabaseManager();
            courseRepository = new CourseRepository(Connection);
            LoadCourseDataAsync(specializationID, step);
        }

        public CourseController(int specializationID, int courseID)
        {
            Connection = new DatabaseManager();
            courseRepository = new CourseRepository(Connection);
            //LoadStepModelsAsync(specializationID);
            LoadStep(specializationID, courseID);
        }

        
 

        /// <summary>
        /// Getting the Course
        /// </summary>
        private CourseModel roadmapStep { get; set; }
        public CourseModel RoadmapStep
        {
            get { return roadmapStep; }
            set { roadmapStep = value; }
        }

        /// <summary>
        /// Gets the Course Model need sID, and Step and provide the id, title, description, and step
        /// </summary>
        /// <param name="specializationID"></param>
        /// <param name="step"></param>

        /// public CourseModel course get set
        private CourseModel course { get; set; }
        /// public CourseModel Course get return set = value
        public CourseModel Course
        {
            get { return course; }
            set { course = value; }
        }

        private async void LoadCourseDataAsync(int specializationID, int step)
        {
            Course = courseRepository.GetCourseModel(specializationID, step);
        }

        /// <summary>
        /// Getting the Courses
        /// </summary>
        private ObservableCollection<CourseModel> roadmapSteps {get; set;}
        public ObservableCollection<CourseModel> RoadmapSteps
        {
            get { return roadmapSteps; }
            set { roadmapSteps = value; }
        }

        private async void LoadStepModelsAsync(int specializationID)
        {
            RoadmapSteps = await courseRepository.GetStepModelsAsync(specializationID);
        }

        /// <summary>
        /// Getting the Steps
        /// </summary>
        private int currentStep { get; set; }
        public int CurrentStep
        {
            get { return currentStep; }
            set { currentStep = value; }
        }

        //getCourseStep
        public void LoadStep(int specializationID, int courseID)
        {
            CurrentStep = courseRepository.getCourseStep(specializationID, courseID);
        }

        // this should be on controller
        //public int thisStep(int specializationID, int courseID)
        //{
        //    DatabaseManager databaseManager = new DatabaseManager();
        //    int currentStep = 0;


        //    try
        //    {

        //        databaseManager.OpenConnection(true);
        //        string query = "SELECT roadmap.Step FROM course JOIN roadmap ON course.CourseID = roadmap.CourseID WHERE roadmap.SpecializationID = @specializationID AND roadmap.CourseID = @CourseId; ";

        //        using (MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection()))
        //        {
        //            command.Parameters.AddWithValue("@CourseId ", courseID);
        //            command.Parameters.AddWithValue("@specializationID", specializationID);
        //            command.ExecuteNonQuery();
        //            using (MySqlDataReader reader = command.ExecuteReader())
        //            {

        //                if (reader.HasRows && reader.Read())
        //                {
        //                    currentStep = reader.GetInt32("Step");
        //                }
        //                else
        //                {
        //                    MessageBox.Show("last specialization reader is empty");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("last specialization query error" + ex);
        //    }
        //    finally
        //    {
        //        databaseManager.CloseConnection();
        //    }
        //    return currentStep;
        //}



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
        /* other old methods
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
