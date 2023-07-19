using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
using specialization_roadmap.Model;
using specialization_roadmap.Repositories;
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
    /// Interaction logic for SpecializationListWindow.xaml
    /// </summary>
    public partial class SpecializationListWindow : Window
    {
        private readonly ViewModel viewmodel;

        public SpecializationListWindow()
        {
            InitializeComponent();

            // Dropdown Item ListSpecializationModel
          
            // using entities model
            SpecializationModel specializationModels = new SpecializationModel();
            statusComboBox.ItemsSource = specializationModels.CreateSpecializationModelList();
            statusComboBox.DisplayMemberPath = "Title";
            statusComboBox.SelectedValuePath = "Id";

            // using repository
            SpecializationRepository specializationRepository = new SpecializationRepository();
            statusComboBox2.ItemsSource = specializationRepository.GetAllSpecializationTrack();
            statusComboBox2.DisplayMemberPath = "Title";
            statusComboBox2.SelectedValuePath = "Description";

            // DataGrid

            this.viewmodel = new ViewModel
            {
                specializationModels = new List<SpecializationModel>()
                {
                    new SpecializationModel
                    {
                        Id = 1,
                        Title = "Title",
                        Description = "Description",
                        Status = false,
                        Progress = 0.2,
                        Rating = 3

                    },
                    new SpecializationModel
                    {
                        Id = 1,
                        Title = "Title",
                        Description = "Description",
                        Status = false,
                        Progress = 0.2,
                        Rating = 3

                    }
                }
            };
            this.DataContext = this.viewmodel.specializationModels;
            this.DataContext = specializationRepository.GetAllSpecializationTrack();

            SpecializationDataGrid.ItemsSource = specializationRepository.GetAllSpecializationTrack();


        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            SpecializationWindow specializationWindow = new SpecializationWindow();
            specializationWindow.Show();
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
    }
}
