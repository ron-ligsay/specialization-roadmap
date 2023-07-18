using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
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
        public SpecializationListWindow()
        {
            InitializeComponent();

            SpecializationModel specializationModels = new SpecializationModel();


            // Dropdown Item ListSpecializationModel
            // statusComboBox.ItemsSource = (System.Collections.IEnumerable)specializationModels;
            statusComboBox.ItemsSource = specializationModels.CreateSpecializationModelList();
            statusComboBox.DisplayMemberPath = "Title";
            statusComboBox.SelectedValuePath = "Id";
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
    }
}
