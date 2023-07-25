using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
using specialization_roadmap.Model;
using specialization_roadmap.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for SpecializationListWindow.xaml
    /// </summary>
    public partial class SpecializationListWindow : Window
    {
        //private readonly ViewModel specializationRepository;
        private readonly SpecializationModel specializationModel;
        //private readonly SpecializationModel specializationModels;
        private readonly SpecializationRepository specializationRepository;
        private readonly SpecializationController specializationController;
        private readonly ViewModel viewModel;

        public SpecializationListWindow()
        {
            InitializeComponent();

            //this.viewModel = new ViewModel();

            //this.viewModel.SpecializationModelsIList = this.specializationRepository.specializationModelsIList();
            

           


            //this.specializationRepository.specializationModelsIList = this.specializationController.GetAllSpecializationO();

            //this.DataContext = this.specializationController.GetAllSpecializationTrackObservation();
            //this.DataContext = this.specializationRepository;

            this.specializationController = new SpecializationController();
            //SpecializationDataGrid.ItemsSource = this.specializationController.GetAllSpecialization();

            this.specializationRepository = new SpecializationRepository();
            SpecializationDataGrid.ItemsSource = this.specializationRepository.GetAllSpecializationTrack();


            // Dropdown Item ListSpecializationModel

            // using entities model
            this.specializationController = new SpecializationController();
            statusComboBox.ItemsSource = this.specializationController.GetAllSpecialization();
            statusComboBox.DisplayMemberPath = "Title";
            statusComboBox.SelectedValuePath = "Id";

            // using repository
            statusComboBox2.ItemsSource = this.specializationController.GetAllSpecialization();
            statusComboBox2.DisplayMemberPath = "Title";
            statusComboBox2.SelectedValuePath = "Description";

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void statusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(statusComboBox.SelectedValue.ToString());
        }

        private void statusComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(statusComboBox2.SelectedValue.ToString());
        }


        private void Openbutton_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (this.specializationRepository.SelectedModel == null)
            {
                MessageBox.Show("null model");
                //return;
            }

            if (this.specializationRepository.specializationModels.Contains(this.specializationRepository.SelectedModel))
            {
                MessageBox.Show("model is not in the repository");
                //return;
            }
            */

            SpecializationModel row = SpecializationDataGrid.SelectedItem as SpecializationModel;

            SpecializationWindow specializationWindow = new SpecializationWindow(row);
            specializationWindow.Show();
            this.Close();
        }

        private void SpecializationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                // fill items
            }
            return;
        }
    }
}
