using specialization_roadmap.Entities;
using specialization_roadmap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Controllers
{
    public class RoadmapController
    {
        private readonly RoadmapRepository roadmapRepository = null;

        public RoadmapController()
        {
            roadmapRepository = new RoadmapRepository();
        }

        public List<RoadmapStepModel> GetAllRoadmaps()
        {
            return roadmapRepository.GetAllRoadmapSteps();
        }

        public RoadmapStepModel GetRoadmapStepsByIndex(int index)
        {
            return roadmapRepository.GetRoadmapStepByIndex(index);
        }

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
    }
}
