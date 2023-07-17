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
using System.Windows.Shapes;

namespace specialization_roadmap
{
    /// <summary>
    /// Interaction logic for SpecializationWindow.xaml
    /// </summary>
    public partial class SpecializationWindow : Window
    {
        public SpecializationWindow()
        {
            InitializeComponent();

            List<SpecializationTrack> track = new List<SpecializationTrack>();

            SpecializationTrack special_frontend = new SpecializationTrack();
            special_frontend.Id = 1000;
            special_frontend.Title = "Front-End Developer";
            special_frontend.Description = "Designs and creates the look of a website.";
            special_frontend.Progress = 0.0;
            special_frontend.Status = false;
            
            track.Add(special_frontend);
        }
    }
}
