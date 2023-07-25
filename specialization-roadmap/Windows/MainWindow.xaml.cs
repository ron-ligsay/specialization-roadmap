using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
using specialization_roadmap.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace specialization_roadmap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SpecializationController specializationController = new SpecializationController();
        public SpecializationRepository specializationRepository = new SpecializationRepository();
        public SpecializationModel specializationModel = new SpecializationModel();

        public string sTitle { get; set; }
        public ObservableCollection<SpecializationModel> SpecializationViewModels { get; set; }

        public MainWindow()
        {
            InitializeComponent();   
            
            specializationModel = specializationController.GetSpecializationByIndex(0);

            sTitle = specializationModel.Title;


            DatabaseManager databaseManager = new DatabaseManager();



            SpecializationViewModels = specializationRepository.GetAllSpecializationTrackObservation();

            DataContext = this;

        }
    

        private void Specialization_01_Click(object sender, RoutedEventArgs e)
        {
            SpecializationWindow specializationWindow = new SpecializationWindow(specializationModel);
            specializationWindow.Show();
            this.Close();
        }

        private void SpecializationListButton_Click(object sender, RoutedEventArgs e)
        {
            SpecializationListWindow specializationListWindow = new SpecializationListWindow();
            specializationListWindow.Show();
            this.Close();
        }
    }

    
}
