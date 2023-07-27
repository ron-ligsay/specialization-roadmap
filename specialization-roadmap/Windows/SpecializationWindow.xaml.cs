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
    /// <summary>
    /// Interaction logic for SpecializationWindow.xaml
    /// </summary>
    public partial class SpecializationWindow : Window
    {
        public SpecializationController specializationController = new SpecializationController();
        public SpecializationModel specializationModel;

        public CourseController roadmapController;
        public CourseModel roadmapStepModel1 = new CourseModel();
        public CourseModel roadmapStepModel2 = new CourseModel();
        public CourseModel roadmapStepModel3 = new CourseModel();

        public string sTitle { get; set; }
        public string sDescription { get; set; }
        public bool sStatus { get; set; }
        public double sProgress { get; set; }
        public string r1Title { get; set; }
        public string r2Title { get; set; }
        public string r3Title { get; set; }
        public int r1Id { get; set; }
        public int r2Id { get; set; }
        public int r3Id { get; set; }


        public SpecializationWindow(SpecializationModel _specializationModel)
        {
            InitializeComponent();

            this.specializationModel = _specializationModel;
            
            sTitle = this.specializationModel.Title;
            sDescription = this.specializationModel.Description;
            sStatus = this.specializationModel.Status;
            sProgress = this.specializationModel.Progress;

            DataContext = this;

            //this.DataContext = new RoadmapController(_specializationModel.Id);

            CourseController roadmap = new CourseController(_specializationModel.Id);
            RoadmapStepsItemControl.ItemsSource = roadmap.RoadmapSteps;


        }
    
        private void RoadmapStep1_Click(object sender, RoutedEventArgs e)
        {
            var model = (TextBlock)sender;
            if (model.Tag is CourseModel courseModel)
            {
                MessageBox.Show(courseModel.Title);
                RoadmapStepsWindow roadmapStepsWindow = new RoadmapStepsWindow(this.specializationModel.Id, courseModel.Id);
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
