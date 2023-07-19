using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Repositories
{
    public class RoadmapRepository : RoadmapStepModel
    {
        public List<RoadmapStepModel> GetAllRoadmapSteps()
        {
            return RoadmapDataSource();
        }

        public RoadmapStepModel GetRoadmapStepById(int id)
        {
            return RoadmapDataSource().FirstOrDefault(x => x.Id == id);
        }

        public RoadmapStepModel GetRoadmapStepById(int id, bool status)
        {
            return RoadmapDataSource().FirstOrDefault(x => x.Id == id && x.Status == status);
        }

        public RoadmapStepModel GetRoadmapStepByIndex(int index)
        {
            return RoadmapDataSource()[index];
        }

        //public List<RoadmapStepModel> GetRoadmapStepBySpecialization(int specializationId)
        //{
        //    return RoadmapDataSource().FirstOrDefault(x => x.specializationStepAt.Contains(specializationId));
        //}

        public List<RoadmapStepModel> SearchRoadmapStep(string name, bool status)
        {
            return RoadmapDataSource().Where(x => x.Title.Contains(name) && x.Status == status).ToList();
        }

        // Creating Specialization Repository
        private List<RoadmapStepModel> RoadmapDataSource()
        {
            return new List<RoadmapStepModel>()
            {
                new RoadmapStepModel
                {
                    Id = 1,
                    Title = "Internet",
                    Description = "The Internet is a global network of computers connected to each other which communicate through a standardized set of protocols.",
                    Status = true,
                    Rating = 3,
                    specializationStepAt = {1},
                    specializationStepOrderAt = {1},
                    ResourcesLinks = {
                        "https://cs.fyi/guide/how-does-internet-work",
                        "https://www.vox.com/2014/6/16/18076282/the-internet",
                        "http://web.stanford.edu/class/msande91si/www-spr04/readings/week1/InternetWhitepaper.htm",
                        "https://roadmap.sh/guides/what-is-internet"
                    }
                },
                new RoadmapStepModel
                {
                    Id = 2,
                    Title = "HTML",
                    Description = "HTML stands for HyperText Markup Language. It is used on the frontend and gives the structure to the webpage which you can style using CSS and make interactive using JavaScript.",
                    Status = true,
                    Rating = 3,
                    specializationStepAt = {1},
                    specializationStepOrderAt = {2},
                    ResourcesLinks = {
                        "https://cs.fyi/guide/how-does-internet-work",
                        "https://www.vox.com/2014/6/16/18076282/the-internet",
                        "http://web.stanford.edu/class/msande91si/www-spr04/readings/week1/InternetWhitepaper.htm",
                        "https://roadmap.sh/guides/what-is-internet"
                    }
                }
            };

        }
    }
}
