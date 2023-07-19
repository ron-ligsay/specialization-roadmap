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

        public string specializationTitle
        {
            get
            {
                return specializationModel.Title;
            }
            set
            {
                specializationModel.Title = value;
            }
        }

        public SpecializationWindow()
        {
            InitializeComponent();

            //List<SpecializationModel> track = new List<SpecializationModel>();

            //SpecializationModel special_frontend = new SpecializationModel();
            //special_frontend.Id = 1000;
            //special_frontend.Title = "Front-End Developer";
            //special_frontend.Description = "Designs and creates the look of a website.";
            //special_frontend.Progress = 0.0;
            //special_frontend.Status = false;

            //track.Add(special_frontend);

            // this.DataContext = special_frontend;


            specializationModel = specializationController.GetSpecializationByIndex(0);
            //this.DataContext = specializationController.GetSpecializationByIndex(0);

            RoadmapController roadmapController = new RoadmapController();
            RoadmapStepModel roadmapStepModel = new RoadmapStepModel();

            roadmapStepModel = roadmapController.GetAllRoadmapStepsBySpecialization(specializationModel.Id);


            //RoadmapStep1TitleLabel.Content = specializationController.GetSpecializationByIndex(0).Title;
            RoadmapStep1TitleLabel.Content = roadmapStepModel.Title;
            RoadmapStep1IdLabel.ContentStringFormat = roadmapStepModel.Id.ToString();

            DataContext = this;
        }
        /// TODO: Pass objects of the Roadmap Step selected or assigned in the Button
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoadmapStep1_Click(object sender, RoutedEventArgs e)
        {
            RoadmapStepsWindow roadmapStepsWindow = new RoadmapStepsWindow();
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

    class Specialization_Test : ISpecialization
    {
        public Specialization_Test()
        {
            
           
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Progress { get; set; }
        public bool Status { get; set; }
    }
}
