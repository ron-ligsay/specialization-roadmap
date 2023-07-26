using Org.BouncyCastle.Crypto.Tls;
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
    public class RoadmapController
    {
        private readonly RoadmapRepository roadmapRepository;
        private readonly DatabaseManager Connection;

        public RoadmapController(int specializationID)
        {
            Connection = new DatabaseManager();
            roadmapRepository = new RoadmapRepository(Connection);
            LoadStepModelsAsync(specializationID);
        }

        private ObservableCollection<RoadmapStepModel> roadmapSteps {get; set;}
        public ObservableCollection<RoadmapStepModel> RoadmapSteps
        {
            get { return roadmapSteps; }
            set { roadmapSteps = value; }
        }

        private async void LoadStepModelsAsync(int specializationID)
        {
            RoadmapSteps = await roadmapRepository.GetStepModelsAsync(specializationID);
        }

        /*
        public List<RoadmapStepModel> GetAllRoadmaps()
        {
            return roadmapRepository.GetAllRoadmapSteps();
        }

        public RoadmapStepModel GetRoadmapStepsByIndex(int index)
        {
            return roadmapRepository.GetRoadmapStepByIndex(index);
        }*/

        //public RoadmapController GetRoadmapStepById(int id)
        //{
        //    return roadmapRepository.GetRoadmapStepById(id);
        //}

        //public RoadmapStepModel GetAllRoadmapStepsBySpecialization(int specializationId)
        //{
        //    return roadmapRepository.GetRoadmapStepBySpecialization(specializationId);
        //}

        //public List<RoadmapStepModel> GetRoadmapStepsBySpecialization(int specializationId)
        //{
        //    return roadmapRepository.GetRoadmapStepBySpecialization(specializationId);
        //}

        //public RoadmapStepModel GetRoadmapStepsBySpecialization(int specializationId, int index)
        //{
        //    //return GetRoadmapStepsBySpecialization[index];
        //    //foreach  (object step in GetRoadmapStepsBySpecialization(specializationId){
        //    //    int stepId = step[1].Id;
        //    //}

        //    //return GetRoadmapStepById(stepId);
        //    return GetRoadmapStepsBySpecialization.IndexOf(index);
        //}
        /*
        public List<RoadmapStepModel> SearchRoadmapStep(string name, bool status)
        {
            return roadmapRepository.SearchRoadmapStep(name, status);
        }

        public RoadmapStepModel GetNextRoadmapStep(RoadmapStepModel roadmapStepModel, int specializationId)
        {
            return roadmapRepository.GetNextRoadmapStep(roadmapStepModel, specializationId);
        }

        public RoadmapStepModel GetNextRoadmapStep(int specializationId, int step)
        {
            return roadmapRepository.GetNextRoadmapStep(specializationId, step);
        }

        public RoadmapStepModel GetNextRoadmapStep()
        {
            return ;
        }
        */
    }
}
