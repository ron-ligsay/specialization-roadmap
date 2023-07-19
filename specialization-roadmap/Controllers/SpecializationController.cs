using specialization_roadmap.Entities;
using specialization_roadmap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Controllers
{
    public class SpecializationController
    {
        private readonly SpecializationRepository specializationRepository = null;

        public SpecializationController()
        {
            specializationRepository = new SpecializationRepository();
        }

        public List<SpecializationModel> GetAllSpecialization()
        {
            return specializationRepository.GetAllSpecializationTrack();
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
