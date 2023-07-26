﻿using specialization_roadmap.Entities;
using specialization_roadmap.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Controllers
{
    public class SpecializationController
    {

        private readonly DatabaseManager connection;
        private readonly SpecializationRepository specializationRepository;
        
        //for selecting a single model
        //public SpecializationModel SelectedModel { get; set; }


        public SpecializationController()
        {
            connection = new DatabaseManager();
            specializationRepository = new SpecializationRepository(connection);
            LoadDataAsync();
        }

        private ObservableCollection<specialization> specializationModels { get; set; }
        public ObservableCollection<specialization> SpecializationModels
        {
            get { return specializationModels; }
            set
            {
                specializationModels = value;
            }
        }


        private async void LoadDataAsync()
        {
            specializationModels = await specializationRepository.GetSpecializationModelsAsync();
        }

        
        
    }
}
