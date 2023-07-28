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

        private readonly CourseController courseController;
        private SpecializationModel specializationModel;


        public string sTitle { get; set; }
        public string sDescription { get; set; }
        public bool sStatus { get; set; }
        public double sProgress { get; set; }


        public SpecializationWindow(SpecializationModel _specializationModel)
        {
            InitializeComponent();
            this.specializationModel = _specializationModel;
            setWindowDataContext();

            CourseController roadmap = new CourseController(_specializationModel.Id);
            RoadmapStepsItemControl.ItemsSource = roadmap.RoadmapSteps;
        }

        public void setWindowDataContext()
        {
            sTitle = this.specializationModel.Title;
            sDescription = this.specializationModel.Description;
            sStatus = this.specializationModel.Status;
            sProgress = this.specializationModel.Progress;

            DataContext = this;
        }
    
        private void RoadmapStep1_Click(object sender, RoutedEventArgs e)
        {
            var model = (TextBlock)sender;
            if (model.Tag is CourseModel courseModel)
            {
                CourseController course = new CourseController(this.specializationModel.Id, courseModel.Id);
                int step = course.CurrentStep;
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
    }
}
