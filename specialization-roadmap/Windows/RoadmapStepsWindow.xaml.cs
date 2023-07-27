using MySql.Data.MySqlClient;
using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        //public List<String> rResources { get; set; }



        public RoadmapStepsWindow(SpecializationModel specialization, int courseID, int step)
        {
            InitializeComponent();
            this.specializationModel = specialization;
            this.SpecializationID = this.specializationModel.Id;

            this.currentStep = step;
            LoadDataAsync(this.SpecializationID, this.currentStep);

     
            
            cTitle = this.courseModel.Title;
            cDescription = this.courseModel.Description;
            //rStatus = courseModel.Status;
            //rResources = courseModel.ResourcesLinks;
            //currentStep = courseModel.Step;
            //MessageBox.Show("After Update Query \r Title: " + this.courseModel.Title+ ", step: " + step);
            DataContext = this;
            fill_listbox(courseID);
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
            fill_listbox(courseID);
        }

        // setting current step
        public void setCourseStep(int specializationID, int courseID)
        {
            DatabaseManager databaseManager = new DatabaseManager();
            try
            {
                databaseManager.OpenConnection(true);

                string query = "SELECT roadmap.Step FROM course JOIN roadmap ON course.CourseID = roadmap.CourseID WHERE roadmap.SpecializationID = @specializationID AND roadmap.CourseID = @CourseId; ";
               
                using (MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@CourseId", courseID);
                    command.Parameters.AddWithValue("@specializationID", specializationID);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            this.currentStep = reader.GetInt32("Step");
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

        }

       
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

        private void markCompletedButton_Click(object sender,RoutedEventArgs e) { }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            RoadmapStepsWindow roadmapStepsWindow1 = new RoadmapStepsWindow(this.specializationModel, this.courseModel.Id, this.currentStep, true);
            roadmapStepsWindow1.Show();
            this.Close();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            RoadmapStepsWindow roadmapStepsWindow2 = new RoadmapStepsWindow(this.specializationModel, this.courseModel.Id, this.currentStep, false);
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
    
        public void fill_listbox(int CourseID)
        {
            LoadSResourcesAsync(CourseID);
            resourceListBox.ItemsSource = ResourceCollection;
        }

        public class Resource
        {
            public string Text { get; set; }
            public string Hyperlink { get; set; }
        }
        public  ObservableCollection<Resource> Resources { get; set; }

        private ObservableCollection<Resource> resourceCollection { get; set; }
        public ObservableCollection<Resource> ResourceCollection
        {
            get { return resourceCollection; }
            set { resourceCollection = value; }
        }

        private async void LoadSResourcesAsync(int CourseID)
        {
            ResourceCollection = await this.GetResources(CourseID);
        }

        public async Task<ObservableCollection<Resource>> GetResources(int CourseID)
        {
            ObservableCollection<Resource> resources = new ObservableCollection<Resource>();
            DatabaseManager databaseManager = new DatabaseManager();
            try
            {
                if(!databaseManager.OpenConnection(true))
                {

                }
                string query = "SELECT r.Title, r.Link FROM `resources` AS r WHERE r.CourseID = @courseID";
                using (MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection()))
                {
                    command.Parameters.AddWithValue("@courseID", CourseID);
                    
                    using(MySqlDataReader reader = command.ExecuteReader())
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

        private void resourceListBox_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            var model = (TextBlock)sender;
            if (model.Tag is Resource resource)
            {
                System.Diagnostics.Process.Start(resource.Hyperlink);
            }
        }
    }
}
