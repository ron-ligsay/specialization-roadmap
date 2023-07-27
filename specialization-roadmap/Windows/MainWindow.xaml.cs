using MySql.Data.MySqlClient;
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
        public SpecializationController specializationController;
        public SpecializationModel specializationModel;


        //public string sTitle { get; set; }
        public ObservableCollection<SpecializationModel> specializations { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            LoadDataAsync();
            last();
            this.DataContext = new SpecializationController();
        }
       

        private async void LoadDataAsync()
        {
            this.specializationModel = await getLastSpecializationUsed();
        }

        private void last()
        {
            DatabaseManager databaseManager = new DatabaseManager();
            databaseManager.OpenConnection(true);
            string query = "SELECT * FROM `specialization` WHERE LastOpenDate=(SELECT MAX(LastOpenDate) FROM specialization);";
            MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection());
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                specializationModel.Id = reader.GetInt32("SpecializationId");
                specializationModel.Title = reader.GetString("SpecializationName");
                specializationModel.Description = reader.GetString("SpecializationDescription");
            }
            databaseManager.CloseConnection();
        }

        private async Task<SpecializationModel> getLastSpecializationUsed1()
        {
            SpecializationModel model = new();
            DatabaseManager Connection = new DatabaseManager();
            try
            {
                
                if(!Connection.OpenConnection(true))
                {
                    MessageBox.Show("error 1");
                    return model;
                }
                string query = "SELECT * FROM `specialization` WHERE LastOpenDate=(SELECT MAX(LastOpenDate) FROM specialization);";
                using (MySqlCommand command = new(query, Connection.GetConnection()))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            SpecializationModel smodel = new()
                            {
                                Id = reader.GetInt32("SpecializationID"),
                                Title = reader.GetString("SpecilizationName"),
                                Description = reader.GetString("SpecializationDescription"),
                                Status = false,
                                Rating = 0,
                                Progress = 0
                            };
                            model = smodel;
                        }
                    }
                }
                MessageBox.Show("catch2");


            }
            catch (Exception ex) 
            { 
                MessageBox.Show("catch"+ex);
            }
            finally
            {
                Connection.CloseConnection();
            }
            this.specializationModel = model;
            return model;
        }



        private async Task<SpecializationModel> getLastSpecializationUsed()
        {
            DatabaseManager databaseManager = new DatabaseManager();
            SpecializationModel specialization = new SpecializationModel();
            try
            {
               
                databaseManager.OpenConnection();
                string query = "SELECT * FROM `specialization` WHERE LastOpenDate=(SELECT MAX(LastOpenDate) FROM specialization);";
                using (MySqlCommand command = new MySqlCommand(query, databaseManager.GetConnection()))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows && reader.Read())
                        {
                            currentTitle.Text = reader.GetString("SpecializationName");
                        }
                        else
                        {
                            MessageBox.Show("last specialization reader is empty");
                        }
                        while (await reader.ReadAsync())
                        {
                            SpecializationModel model = new()
                            {
                                Id = reader.GetInt32("SpecializationID"),
                                Title = reader.GetString("SpecializationName"),
                                Description = reader.GetString("SpecializationDescription"),
                                Status = false,
                                Rating = 0,
                                Progress = 0
                            };

                            this.specializationModel = model;
                            specialization = model;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("last specialization query error"+ex);
            }
            finally
            {
                databaseManager.CloseConnection();
            }
            this.specializationModel = specialization;
            return specialization;

        }


        private void Specialization_01_Click(object sender, RoutedEventArgs e)
        {
            SpecializationWindow specializationWindow = new SpecializationWindow(this.specializationModel);
            specializationWindow.Show();
            this.Close();
        }

        private void SpecializationListButton_Click(object sender, RoutedEventArgs e)
        {
            SpecializationListWindow specializationListWindow = new SpecializationListWindow();
            specializationListWindow.Show();
            this.Close();
        }


        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var model = (TextBlock)sender;
            if (model.Tag is SpecializationModel specializationModel)
            {
                SpecializationWindow specializationWindow = new SpecializationWindow(specializationModel);
                specializationWindow.Show();
                this.Close();
            }
        }
        private void ContinueProgress_click(object sender, MouseButtonEventArgs e)
        {
            SpecializationWindow specializationWindow = new SpecializationWindow(this.specializationModel);
            specializationWindow.Show();
            this.Close();
        }

        private void Signout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }

    
}
