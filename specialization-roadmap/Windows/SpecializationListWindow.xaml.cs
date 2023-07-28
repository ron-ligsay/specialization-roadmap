using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
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


        public SpecializationListWindow()
        {
            InitializeComponent();
            SpecializationController controller = new SpecializationController();
            this.DataContext = controller.SpecializationModels;
            //this.DataContext = controller.SpecializationModels;

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
