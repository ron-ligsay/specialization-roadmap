using MySql.Data.MySqlClient;
using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace specialization_roadmap
{

    public partial class RoadmapStepsWindow : Window
    {

        public SpecializationModel specializationModel;
        public int SpecializationID;

        public CourseModel courseModel;
        public int currentStep;

        public string cTitle { get; set; }
        public string cDescription { get; set; }
        public bool rStatus { get; set; }
        //public List<string> rResources { get; set; }



        public RoadmapStepsWindow(SpecializationModel specialization, int courseID, int step)
        {
            InitializeComponent();
            this.specializationModel = specialization;
            this.SpecializationID = this.specializationModel.Id;

            //MessageBox.Show("At Roadmap Step Window \r SpecializationID: " + SpecializationID + ", courseID: " + courseID);
            
            //this.currentStep = getCourseStep(this.SpecializationID, courseID);
            this.currentStep = step;
            LoadDataAsync(this.SpecializationID, this.currentStep);

            //MessageBox.Show("Current Step " + this.currentStep);

            ///updateContent(this.SpecializationID, this.currentStep);
            //updateModel(SpecializationID, this.currentStep);
            
            cTitle = this.courseModel.Title;
            cDescription = this.courseModel.Description;
            //rStatus = courseModel.Status;
            //rResources = courseModel.ResourcesLinks;
            //currentStep = courseModel.Step;
            //MessageBox.Show("After Update Query \r Title: " + this.courseModel.Title+ ", step: " + step);
            
            DataContext = this;  
        }

        public RoadmapStepsWindow(SpecializationModel specialization, int courseID, int step, bool whichStep)
        {
            InitializeComponent();
            this.currentStep = step;
            this.specializationModel = specialization;
            this.SpecializationID = this.specializationModel.Id;
            if (whichStep) { this.currentStep++; }
            else { this.currentStep--;  }

            LoadDataAsync(this.SpecializationID, this.currentStep);


            cTitle = this.courseModel.Title;
            cDescription = this.courseModel.Description;


            DataContext = this;
        }

        // setting current step
        public void setCourseStep(int specializationID, int courseID)
        {
            DatabaseManager databaseManager = new DatabaseManager();

            //int step = 0; // Initialize currentStep with a default value

            try
            {
                databaseManager.OpenConnection(true);

                string query = "SELECT roadmap.Step FROM course JOIN roadmap ON course.CourseID = roadmap.CourseID WHERE roadmap.SpecializationID = @specializationID AND roadmap.CourseID = @CourseId; ";
               
                using (MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@CourseId", courseID);
                    command.Parameters.AddWithValue("@specializationID", specializationID);
                    //command.ExecuteNonQuery();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            this.currentStep = reader.GetInt32("Step");
                        }
                        else
                        {
                            MessageBox.Show("No roadmap data found for the given specialization and course.");
                            //step = this.currentStep;
                        }
                        //MessageBox.Show("thisStep try passing specializationID: " + specializationID + ", and courseID: " + courseID + " to get current step which is " + currentStep);
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

            //MessageBox.Show("Current step: " + currentStep);
            //return step;
        }

       

        //public void updateContent(int specializationID, int step)
        //{
        //    //MessageBox.Show("At Update Query \r SpecializationID: " + specializationID + ", step: " + step);
        //    //LoadDataAsync(SpecializationID, step);
        //    updateModel(SpecializationID, step);
        //    cTitle = this.courseModel.Title;
        //    cDescription = this.courseModel.Description;
        //    //rStatus = courseModel.Status;
        //    //rResources = courseModel.ResourcesLinks;
        //    //currentStep = courseModel.Step;
        //    //MessageBox.Show("After Update Query \r Title: " + this.courseModel.Title+ ", step: " + step);
        //    DataContext = this;

        //}

        /// <summary>
        /// Updates the this.CourseModel
        /// </summary>
        /// <param name="specializationID"></param>
        /// <param name="step"></param>
        private void updateModel(int specializationID, int step)
        {
            DatabaseManager databaseManager = new DatabaseManager();
            databaseManager.OpenConnection(true);
            string query = "SELECT course.*, roadmap.Step " +
                             "FROM course JOIN roadmap ON course.CourseID = roadmap.CourseID " +
                             "WHERE roadmap.SpecializationID = @specializationID AND roadmap.Step = @step " +
                             "ORDER BY roadmap.Step ASC";

            MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection());
            command.Parameters.AddWithValue("@specializationID", specializationID);
            command.Parameters.AddWithValue("@step", step);
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                this.courseModel.Id = reader.GetInt32("CourseId");
                this.courseModel.Title = reader.GetString("CourseName");
                this.courseModel.Description = reader.GetString("CourseDescription");
                this.courseModel.Step = step;
                MessageBox.Show("title: " + this.courseModel.Title + ", step: " + this.courseModel.Step);
            }
            databaseManager.CloseConnection();
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("going back to specialization model: " + this.specializationModel.Title);
            SpecializationWindow specializationWindow = new SpecializationWindow(this.specializationModel);
            specializationWindow.Show();
            this.Close();
        }

        private void markCompletedButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            //this.currentStep += 1;
            RoadmapStepsWindow roadmapStepsWindow1 = new RoadmapStepsWindow(this.specializationModel, this.courseModel.Id, this.currentStep, true);
            //updateContent(this.SpecializationID, this.currentStep);
            roadmapStepsWindow1.Show();
            this.Close();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            //this.currentStep -= 1;
            RoadmapStepsWindow roadmapStepsWindow2 = new RoadmapStepsWindow(this.specializationModel, this.courseModel.Id, this.currentStep, false);
            //updateContent(this.SpecializationID, this.currentStep);
            roadmapStepsWindow2.Show();
            this.Close();
        }


        /// <summary>
        /// Gets the Course Model need sID, and Step and provide the id, title, description, and step
        /// </summary>
        /// <param name="specializationID"></param>
        /// <param name="step"></param>
        private async void LoadDataAsync(int specializationID, int step)
        {
            this.courseModel = await GetStepModelAsync(specializationID, step);
        }

        public async Task<CourseModel> GetStepModelAsync(int specializationID, int step)
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
                             //"ORDER BY roadmap.Step ASC";


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
    }
}
