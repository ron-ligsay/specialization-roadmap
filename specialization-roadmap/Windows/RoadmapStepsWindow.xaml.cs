using MySql.Data.MySqlClient;
using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace specialization_roadmap
{
    /// <summary>
    /// Interaction logic for RoadmapStepsWindow.xaml
    /// </summary>
    public partial class RoadmapStepsWindow : Window
    {

        public SpecializationModel specializationModel = new SpecializationModel();
        public CourseModel courseModel;
        //public CourseModel CourseModel
        //{
        //    get { return courseModel; }
        //    set
        //    {
        //        courseModel = value;
        //    }
        //}

        public CourseController CourseController;
        public int currentStep;

        public int SpecializationID;

        public string Title { get; set; }
        public string Description { get; set; }
        public bool rStatus { get; set; }
        //public List<string> rResources { get; set; }



        public RoadmapStepsWindow(int specializationID, int courseID)
        {
            InitializeComponent();
            MessageBox.Show("At Roadmap Step Window \r SpecializationID: " + specializationID + ", courseID: " + courseID);
           

            this.SpecializationID = specializationID;

            LoadDataAsync(specializationID, this.currentStep);

            this.currentStep = thisStep(specializationID, courseID);

            MessageBox.Show("Current Step " + this.currentStep);

            updateContent(specializationID, this.currentStep);

            DataContext = this;
        }


        public int thisStep(int specializationID, int courseID)
        {
            DatabaseManager databaseManager = new DatabaseManager();
            int currentStep = this.currentStep;


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
                            MessageBox.Show("last specialization reader is empty");
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
            this.currentStep = currentStep;
            return currentStep;
        }

        public int getStep(int specializationID, int courseID)
        {
            DatabaseManager Connection = new DatabaseManager();
            //Connection.OpenConnection(true);
            int currentStep = 0;
            try
            {
                if (!Connection.OpenConnection(true))
                {
                    MessageBox.Show("Unable to connect to course/roadmap step database");
                    return 0;
                }

                string sql = "SELECT roadmap.Step" +
                             "FROM course JOIN roadmap ON course.CourseID = roadmap.CourseID " +
                             "WHERE roadmap.CourseID = @courseId " +
                             "AND roadmap.SpecializationID = @specializationID";

                using MySqlCommand command1 = new(sql, Connection.GetConnection());
                command1.Parameters.AddWithValue("@courseId", courseID);
                command1.Parameters.AddWithValue("@specializationID", specializationID);

                MySqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    currentStep = reader.GetInt32(reader.GetOrdinal("Step"));
                }

                //if (reader.HasRows && reader.Read())
                //{
                //    currentStep = reader.GetInt32(reader.GetOrdinal("Step"));

                //}

                //using (MySqlCommand command = new(sql, Connection.GetConnection()))
                //{
                //    command.Parameters.AddWithValue("@courseID ", courseID);
                //    command.Parameters.AddWithValue("@specializationID", specializationID);


                //    using (MySqlDataReader reader = command.ExecuteReader())
                //    {

                //        this.currentStep = reader.GetInt32(reader.GetOrdinal("Step"));

                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Step error: " + ex);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return currentStep;
        }

        public void updateContent(int specializationID, int step)
        {
            MessageBox.Show("At Update Query \r SpecializationID: " + specializationID + ", step: " + step);
            LoadDataAsync(SpecializationID, step);
            last(SpecializationID, step);
            Title = this.courseModel.Title;
            Description = this.courseModel.Description;
            //rStatus = courseModel.Status;
            //rResources = courseModel.ResourcesLinks;
            //currentStep = courseModel.Step;
            MessageBox.Show("After Update Query \r Title: " + this.courseModel.Title+ ", step: " + step);
            DataContext = this;

        }
        private void last(int specializationID, int step)
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

            }
            databaseManager.CloseConnection();
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            SpecializationWindow specializationWindow = new SpecializationWindow(specializationModel);
            specializationWindow.Show();
            this.Close();
        }

        private void markCompletedButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            //RoadmapStepsWindow roadmapStepsWindow = new RoadmapStepsWindow(SpecializationID, currentStep + 1);
            currentStep += 1;
            updateContent(this.SpecializationID, this.currentStep+1);
            //roadmapStepsWindow.Show();
            //this.Close();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            //RoadmapStepsWindow roadmapStepsWindow = new RoadmapStepsWindow(SpecializationID, currentStep - 1);
            currentStep -= 1;
            updateContent(this.SpecializationID, this.currentStep-1);

            //roadmapStepsWindow.Show();
            //this.Close();
        }

        private async void LoadDataAsync(int specializationID, int step)
        {
            this.courseModel = await GetStepModelAsync(specializationID, step);
        }


        public async Task<CourseModel> GetStepModelAsync(int specializationID, int step)
        {
            DatabaseManager Connection = new DatabaseManager();
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
                        //while (await reader.ReadAsync())
                        //{
                        //    int roadmapStep = reader.GetOrdinal("Step");


                        //    CourseModel course = new()
                        //    {
                        //        Title = reader.GetString("Course"),
                        //        Description = reader.GetString("Description"),
                        //        Step = roadmapStep
                        //    };
                        //    roadmapStepModel = course;
                        //}
                        if (reader.Read())
                        {
                            //this.Title = reader.GetString("CourseName");
                            //this.Description = reader.GetString("CourseDescription");
                            int roadmapStep = reader.GetOrdinal("Step");
                            MessageBox.Show("" +
                                 reader.GetString("Course") +
                                 reader.GetOrdinal("Step") +
                                 reader.GetString("Description") 
                                );
                            
                            CourseModel course = new()
                            {
                                Title = reader.GetString("Course"),
                                Description = reader.GetString("Description"),
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
    }
}
