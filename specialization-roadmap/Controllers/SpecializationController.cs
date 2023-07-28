using specialization_roadmap.Entities;
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


        public SpecializationController()
        {
            connection = new DatabaseManager();
            specializationRepository = new SpecializationRepository(connection);
            LoadDataAsync();
        }


        public SpecializationController(int limit)
        {
            connection = new DatabaseManager();
            specializationRepository = new SpecializationRepository(connection);
            LoadDataAsync(limit);
        }

        private ObservableCollection<SpecializationModel> specializationModels { get; set; }
        public ObservableCollection<SpecializationModel> SpecializationModels
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

        private async void LoadDataAsync(int limit)
        {
            specializationModels = await specializationRepository.GetSpecializationModelsAsync(limit);
        }
    }
}
