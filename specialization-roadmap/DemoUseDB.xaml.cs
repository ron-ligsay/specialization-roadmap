using MySql.Data.MySqlClient;
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
    /// Interaction logic for DemoUseDB.xaml
    /// </summary>
    public partial class DemoUseDB : Window
    {
        public DemoUseDB()
        {
            InitializeComponent();
            PopulateDataGrid(0);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (radioFront.IsChecked == true)
            {
                PopulateDataGrid(1);
            }
            else if (radioBack.IsChecked == true)
            {
                PopulateDataGrid(2);
            }
        }

        private void PopulateDataGrid(int req)
        {
            DatabaseManager dbManager = new DatabaseManager();

            // Show all specializations in the datagrid
            string query2 = "SELECT * FROM specialization";
            var dataTable2 = dbManager.ExecuteQuery(query2);
            dataGridViewSpecializations.ItemsSource = dataTable2.DefaultView;

            // Show all courses in the datagrid
            string query3 = "SELECT * FROM course";
            var dataTable3 = dbManager.ExecuteQuery(query3);
            dataGridViewCourses.ItemsSource = dataTable3.DefaultView;

            // Show roadmap in the datagrid
            string query4 = "SELECT Step, course.CourseName AS Course, course.CourseDescription AS Description FROM roadmap INNER JOIN specialization ON roadmap.SpecializationID = specialization.SpecializationID INNER JOIN course ON roadmap.CourseID = course.CourseID WHERE roadmap.SpecializationID = @specId";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@specId", req),
            };
            var dataTable4 = dbManager.ExecuteQuery(query4, parameters);
            dataGridViewSpecCourse.ItemsSource = dataTable4.DefaultView;

            // Show all the resources of a roamap in the datagrid
            string query5 = "SELECT Step, course.CourseName AS Course, resources.Title, resources.Link FROM `roadmap` INNER JOIN specialization ON roadmap.SpecializationID = specialization.SpecializationID INNER JOIN course ON roadmap.CourseID = course.CourseID INNER JOIN resources ON course.CourseID = resources.CourseID WHERE roadmap.SpecializationID = @specId ORDER BY Step;";
            MySqlParameter[] parameters2 =
            {
                new MySqlParameter("@specId", req),
            };
            var dataTable5 = dbManager.ExecuteQuery(query5, parameters2);
            dataGridViewResources.ItemsSource = dataTable5.DefaultView;
        }

    }
}
