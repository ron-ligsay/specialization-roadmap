using specialization_roadmap.Controllers;
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
            SpecializationRepository specializationRepository = new SpecializationRepository();

            // statusComboBox.ItemsSource = (System.Collections.IEnumerable)specializationRepository;
            // statusComboBox.DisplayMemberPath = "Name";
            // statusComboBox.SelectedValuePath = "Id";
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            SpecializationWindow specializationWindow = new SpecializationWindow();
            specializationWindow.Show();
            this.Close();
        }
    }
}
