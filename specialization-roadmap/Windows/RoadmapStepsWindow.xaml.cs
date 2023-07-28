using MySql.Data.MySqlClient;
using specialization_roadmap.Controllers;
using specialization_roadmap.Entities;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;



namespace specialization_roadmap
{

    public partial class RoadmapStepsWindow : Window
    {
        private readonly CourseController courseController;

        private SpecializationModel specializationModel;
        private CourseModel courseModel;

        private int SpecializationID;
        public int currentStep;

        public string cTitle { get; set; }
        public string cDescription { get; set; }
        public bool rStatus { get; set; }

        public string specializationTitle { get; set; }


        public RoadmapStepsWindow(SpecializationModel specialization, int courseID, int step)
        {
            InitializeComponent();
            initialize(specialization, courseID, step);
            
            CourseController courseController = new CourseController(SpecializationID, step,true);
            courseModel = courseController.Course;

            setContext(courseID);
        }

        public RoadmapStepsWindow(SpecializationModel specialization, int courseID, int step, bool whichStep)
        {
            InitializeComponent();
            initialize(specialization, courseID, step);
            
            if (whichStep) { this.currentStep++; }
            else { this.currentStep--;  }

            CourseController courseController = new CourseController(SpecializationID, this.currentStep, true);
            courseModel = courseController.Course;

            setContext(courseID);
        }

        public void setContext(int courseID)
        {
            specializationTitle = this.specializationTitle;
            cTitle = this.courseModel.Title;
            cDescription = this.courseModel.Description;
            rStatus = this.courseModel.Status;
            //currentStep = courseModel.Step;

            DataContext = this;
            fill_listbox(courseID);
        }

        public void initialize(SpecializationModel specialization, int courseID, int step)
        {
            this.specializationTitle = specialization.Title;
            this.currentStep = step;
            this.specializationModel = specialization;
            this.SpecializationID = this.specializationModel.Id;
        }

        public void fill_listbox(int CourseID)
        {
            ResourceController resourceController = new ResourceController(CourseID);
            resourceListBox.ItemsSource = resourceController.ResourceCollection;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("going back to specialization model: " + this.specializationModel.Title);
            SpecializationWindow specializationWindow = new SpecializationWindow(this.specializationModel);
            specializationWindow.Show();
            this.Close();
        }

        

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            RoadmapStepsWindow roadmapStepsWindow1 = new RoadmapStepsWindow(this.specializationModel, this.courseModel.Id, this.currentStep, true);
            roadmapStepsWindow1.Show();
            this.Close();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            RoadmapStepsWindow roadmapStepsWindow2 = new RoadmapStepsWindow(this.specializationModel, this.courseModel.Id, this.currentStep, false);
            roadmapStepsWindow2.Show();
            this.Close();
        }


        

      
        // event: open the resource link to a browser
        private void resourceListBox_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            var model = (ListBox)sender;
            var listmodel2 = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;

            //MessageBox.Show("Opening Link to " + listmodel2 + " \r " + model);

            if (model.Tag != null)
            {
                //MessageBox.Show("Opening Link to " + model.Tag);
                //System.Diagnostics.Process.Start(model.Hyperlink);
            }
            else { //MessageBox.Show("item is null");
                   }

            if (sender is ListBox listbox && listbox.SelectedItem is Resource resource)
            {
                if (!string.IsNullOrEmpty(resource.Hyperlink))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(resource.Hyperlink);
                    }
                    catch
                    {
                        MessageBox.Show("try 1 did not work");
                    }
                    try
                    {
                        System.Diagnostics.Process.Start(new ProcessStartInfo(resource.Hyperlink));
                        e.Handled = true;
                    }
                    catch
                    {
                        MessageBox.Show("try 2 did not work");

                    }
                }
                else { MessageBox.Show("Listbox Empty"); }
            }
        }






        private void markCompletedButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is CourseController courseController && courseController.SelectedCourse != null)
            {
                // Update the status of the selected cocurse to true "Complete";
                //courseController.SelectedCourse.Status = true;

                // Notify the UI that the Status property has changed
                //courseController.NotifyPropertyChange("SelectedCourse");
                int courseID = courseController.SelectedCourse.Id;
                bool newStatus = true;
                //DatabaseManager databaseManager = new DatabaseManager();
                bool updateSuccessful = courseController.UpdateCourseStatus(courseID, newStatus);

                if (updateSuccessful)
                {
                    courseController.SelectedCourse.Status = true;
                    //courseController.NotifyPropertyChanged("SelectedCourse");
                    this.courseModel.Status = true;
                    Console.WriteLine("Status updated successfully");
                }
                else
                {
                    Console.WriteLine("Failed to update status.");
                }
            }

        }
    }
}
