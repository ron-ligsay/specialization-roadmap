using MySql.Data.MySqlClient;
using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for RoadmapStepsWindow.xaml
    /// </summary>
    public partial class RoadmapStepsWindow : Window
    {

        public SpecializationModel specializationModel = new SpecializationModel();
        public CourseModel roadmapStepModel = new CourseModel();

        public string rTitle { get; set; }
        public string rDescription { get; set; }
        public bool rStatus { get; set; }
        public List<string> rResources { get; set; }



        public RoadmapStepsWindow(int specializationID, int courseID)
        {
            InitializeComponent();

            rTitle = roadmapStepModel.Title;
            rDescription = roadmapStepModel.Description;
            rStatus = roadmapStepModel.Status;
            rResources = roadmapStepModel.ResourcesLinks;

            DataContext = this;

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
            RoadmapStepsWindow roadmapStepsWindow = new RoadmapStepsWindow(1,1);
            roadmapStepsWindow.Show();
            this.Close();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            RoadmapStepsWindow roadmapStepsWindow = new RoadmapStepsWindow(1,1);
            roadmapStepsWindow.Show();
            this.Close();
        }
    }
}
