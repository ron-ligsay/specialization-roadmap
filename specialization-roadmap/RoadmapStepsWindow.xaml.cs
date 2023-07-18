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
        public RoadmapStepsWindow()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            SpecializationWindow specializationWindow = new SpecializationWindow();
            specializationWindow.Show();
            this.Close();
        }

        private void markCompletedButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            RoadmapStepsWindow roadmapStepsWindow = new RoadmapStepsWindow();
            roadmapStepsWindow.Show();
            this.Close();
        }
        
    }
}
