using specialization_roadmap.DataAccess;
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

        //public List<SpecializationModel> specializationModels { get; set; }     

        public SpecializationModel SelectedModel { get; set; }

        /*
        public ObservableCollection<SpecializationModel> observableSpecializationModels()
        {

            ObservableCollection<SpecializationModel> observableSpecializationModels = new ObservableCollection<SpecializationModel>();
            
            foreach (SpecializationModel group in specializationRepository.GetAllSpecialization)
            {
                observableSpecializationModels.DataGroup.Add(observableSpecializationModels);
            }



            return specializationRepository;
        }*/

        

        public SpecializationController()
        {
            connection = new DatabaseManager();
            specializationRepository = new SpecializationRepository(connection);
            LoadDataAsync();
            specializationRepository = new SpecializationRepository();
        }

        private ObservableCollection<SpecializationModel> specializationModels { get; set; }

        public ObservableCollection<SpecializationModel> GetAllSpecializationO()
        {
            return specializationRepository.GetAllSpecializationTrackObservation();
        }

        public List<SpecializationModel> GetAllSpecialization()
        {
            return specializationRepository.GetAllSpecializationTrack();
        }

        private async void LoadDataAsync()
        {
            specializationModels = await specializationRepository.GetSpecializationModelsAsync();
        }


        public SpecializationModel GetSpecializationTrackById(int id)
        {
            return specializationRepository.GetSpecializationTrackById(id);
        }
        
        public SpecializationModel GetSpecializationByIndex(int index)
        {
            return specializationRepository.GetSpecializationTrackByIndex(index);
        }

        public List<SpecializationModel> SearchSpecializationTrack(string name, bool status)
        {
            return specializationRepository.SearchSpecializationTrack(name, status);
        }
        
    }
}
