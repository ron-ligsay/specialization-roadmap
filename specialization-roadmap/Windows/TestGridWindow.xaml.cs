using specialization_roadmap.Controllers;
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

namespace specialization_roadmap.Windows
{
    /// <summary>
    /// Interaction logic for TestGridWindow.xaml
    /// </summary>
    public partial class TestGridWindow : Window
    {
        public bool TestContent { get; set; }
        public string currentTitle { get; set; }
        public string nextTitle { get; set; }

        public TestGridWindow()
        {
            InitializeComponent();

            RoadmapStepModel currentRoadmapStepModel = new RoadmapStepModel();
            RoadmapStepModel nextRoadmapStepModel = new RoadmapStepModel();
            RoadmapController roadmapController = new RoadmapController();



            currentRoadmapStepModel = roadmapController.GetRoadmapStepsByIndex(0);

            //bool isContains = currentRoadmapStepModel.containsSpecializationId(1);

            //roadmapController.SearchRoadmapStep()
            //TestContent = isContains;

            //nextRoadmapStepModel = roadmapController.GetNextRoadmapStep(currentRoadmapStepModel, 1);
            nextRoadmapStepModel = roadmapController.GetNextRoadmapStep(1, 1);

            currentTitle = currentRoadmapStepModel.Title;
            nextTitle = nextRoadmapStepModel.Title;


            DataContext = this;
        }
    }
}
