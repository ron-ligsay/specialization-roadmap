using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Entities
{
    public interface IRoadmap : ISpecialization
    {
        public new int Id { get; set; }
        public new string Title { get; set; }
        public new string Description { get; set; }
        public new bool Status { get; set; }
        
        public new int Rating { get; set; }
        public List<int>? specializationStepAt { get; set; }
        public List<int>? specializationStepOrderAt { get; set; }
        public List<string> ResourcesLinks { get; set; }
    }

    public class RoadmapStepModel : IRoadmap
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        
        public int Rating { get; set; }
        
        /// <summary>
        /// Reference ID List to ID of the Specialization
        /// </summary>
        public List<int>? specializationStepAt { get; set; }
        
        /// <summary>
        /// Declares the step order in the roadmap
        /// </summary>
        public List<int>? specializationStepOrderAt { get; set; }
        public List<string> ResourcesLinks { get; set; }

        public bool containsSpecializationId(int specializationId)
        {
            return specializationStepAt.Contains(specializationId);
        }
        
        public List<RoadmapStepModel> CreateSpecializationModelList()
        {
            List<RoadmapStepModel> roadmapStepModels = new List<RoadmapStepModel>();

            RoadmapStepModel internetRoadmapStepModel = new RoadmapStepModel();
            internetRoadmapStepModel.Id = 1;
            internetRoadmapStepModel.Title = "Internet";
            internetRoadmapStepModel.Description = "The Internet is a global network of computers connected to each other which communicate through a standardized set of protocols.";
            internetRoadmapStepModel.Status = true;
            internetRoadmapStepModel.Rating = 3;
            List<int> stepAt = new List<int>() { 1 };
            internetRoadmapStepModel.specializationStepAt = stepAt;
            List<int> orderAt = new List<int>() { 1 };
            internetRoadmapStepModel.specializationStepOrderAt = orderAt;
            List<string> links = new List<string>() {
                "https://cs.fyi/guide/how-does-internet-work",
                "https://www.vox.com/2014/6/16/18076282/the-internet",
                "http://web.stanford.edu/class/msande91si/www-spr04/readings/week1/InternetWhitepaper.htm",
                "https://roadmap.sh/guides/what-is-internet"
            };
            internetRoadmapStepModel.ResourcesLinks = links;

            roadmapStepModels.Add(internetRoadmapStepModel);

            return roadmapStepModels;

        }
    }
}
