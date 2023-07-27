using MySql.Data.MySqlClient;
using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace specialization_roadmap
{

    public partial class SpecializationWindow : Window
    {
        public SpecializationModel specializationModel;


        public string sTitle { get; set; }
        public string sDescription { get; set; }
        public bool sStatus { get; set; }
        public double sProgress { get; set; }


        public SpecializationWindow(SpecializationModel _specializationModel)
        {
            InitializeComponent();
            this.specializationModel = _specializationModel;
            
            sTitle = this.specializationModel.Title;
            sDescription = this.specializationModel.Description;
            sStatus = this.specializationModel.Status;
            sProgress = this.specializationModel.Progress;

            DataContext = this;

            CourseController roadmap = new CourseController(_specializationModel.Id);
            RoadmapStepsItemControl.ItemsSource = roadmap.RoadmapSteps;


        }
    
        private void RoadmapStep1_Click(object sender, RoutedEventArgs e)
        {
            var model = (TextBlock)sender;
            if (model.Tag is CourseModel courseModel)
            {
                //MessageBox.Show(courseModel.Title);
                int step = getCourseStep(this.specializationModel.Id, courseModel.Id);
                RoadmapStepsWindow roadmapStepsWindow = new RoadmapStepsWindow(this.specializationModel, courseModel.Id, step);
                roadmapStepsWindow.Show();
                this.Close();
            }      
        }


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        public int getCourseStep(int specializationID, int courseID)
        {
            DatabaseManager databaseManager = new DatabaseManager();
            int currentStep = 0; // Initialize currentStep with a default value

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
    }
    

}
