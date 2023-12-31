﻿using specialization_roadmap.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace specialization_roadmap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }
    

        private void Specialization_01_Click(object sender, RoutedEventArgs e)
        {
            SpecializationWindow specializationWindow = new SpecializationWindow();
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
