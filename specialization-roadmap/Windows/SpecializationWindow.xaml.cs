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
        public SpecializationModel specializationModel = new SpecializationModel();

        public RoadmapController roadmapController;
        public RoadmapStepModel roadmapStepModel1 = new RoadmapStepModel();
        public RoadmapStepModel roadmapStepModel2 = new RoadmapStepModel();
        public RoadmapStepModel roadmapStepModel3 = new RoadmapStepModel();

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

            RoadmapController roadmap = new RoadmapController(_specializationModel.Id);
            RoadmapStepsItemControl.ItemsSource = roadmap.RoadmapSteps;


        }
        /// TODO: Pass objects of the Roadmap Step selected or assigned in the Button
        /// <summary>
        /// https://www.youtube.com/watch?v=sbwK7NjkwME
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoadmapStep1_Click(object sender, RoutedEventArgs e)
        {
            

            RoadmapStepsWindow roadmapStepsWindow = new RoadmapStepsWindow(this.specializationModel,this.roadmapStepModel1);
            roadmapStepsWindow.Show();
            this.Close();
        }


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

   
}
