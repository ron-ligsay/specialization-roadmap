using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        //    //return RoadmapDataSource().FirstOrDefault(x => x.specializationStepAt.Contains(specializationId));
            
        //    for (RoadmapStepModel roadmapStepModel: this.GetAllRoadmapSteps)
        //    {
        //        if roadmapStepModel.specializationStepAt.Contains(specializationId){
        //            return roadmapStepModel;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    } 
        //    //return RoadmapDataSource().containsSpecializationId(specializationId);
        //}

        public List<RoadmapStepModel> SearchRoadmapStep(string name, bool status)
        {
            return RoadmapDataSource().Where(x => x.Title.Contains(name) && x.Status == status).ToList();
        }

        // Creating Specialization Repository
        private List<RoadmapStepModel> RoadmapDataSource()
        {
            List<RoadmapStepModel> modelList = new List<RoadmapStepModel>();
            
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

            RoadmapStepModel htmlRoadmapStepModel = new RoadmapStepModel();
            htmlRoadmapStepModel.Id = 2;
            htmlRoadmapStepModel.Title = "HTML";
            htmlRoadmapStepModel.Description = "The Internet is a global network of computers connected to each other which communicate through a standardized set of protocols.";
            htmlRoadmapStepModel.Status = true;
            htmlRoadmapStepModel.Rating = 3;
            //List<int> stepAt = new List<int>() { 1 };
            htmlRoadmapStepModel.specializationStepAt = stepAt;
            //List<int> orderAt = new List<int>() { 1 };
            htmlRoadmapStepModel.specializationStepOrderAt = orderAt;
            /*List<string> links = new List<string>() {
                "https://cs.fyi/guide/how-does-internet-work",
                "https://www.vox.com/2014/6/16/18076282/the-internet",
                "http://web.stanford.edu/class/msande91si/www-spr04/readings/week1/InternetWhitepaper.htm",
                "https://roadmap.sh/guides/what-is-internet"
            };*/
            htmlRoadmapStepModel.ResourcesLinks = links;

            RoadmapStepModel cssRoadmapStepModel = new RoadmapStepModel();
            cssRoadmapStepModel.Id = 3;
            cssRoadmapStepModel.Title = "CSS";
            cssRoadmapStepModel.Description = "The Internet is a global network of computers connected to each other which communicate through a standardized set of protocols.";
            cssRoadmapStepModel.Status = true;
            cssRoadmapStepModel.Rating = 3;
            //List<int> stepAt = new List<int>() { 1 };
            cssRoadmapStepModel.specializationStepAt = stepAt;
            //List<int> orderAt = new List<int>() { 1 };
            cssRoadmapStepModel.specializationStepOrderAt = orderAt;
            /*List<string> links = new List<string>() {
                "https://cs.fyi/guide/how-does-internet-work",
                "https://www.vox.com/2014/6/16/18076282/the-internet",
                "http://web.stanford.edu/class/msande91si/www-spr04/readings/week1/InternetWhitepaper.htm",
                "https://roadmap.sh/guides/what-is-internet"
            };*/
            cssRoadmapStepModel.ResourcesLinks = links;
            
            
            modelList.Add(internetRoadmapStepModel);
            modelList.Add(htmlRoadmapStepModel);
            modelList.Add(cssRoadmapStepModel);
            
            
            return modelList;
            /*
            return new List<RoadmapStepModel>()
            {
                new RoadmapStepModel()
                {
                    Id = 1,
                    Title = "Internet",
                    Description = "The Internet is a global network of computers connected to each other which communicate through a standardized set of protocols.",
                    Status = true,
                    Rating = 3,
                    specializationStepAt = {0,1},
                    specializationStepOrderAt = {0,1},
                    ResourcesLinks = {
                        "https://cs.fyi/guide/how-does-internet-work",
                        "https://www.vox.com/2014/6/16/18076282/the-internet",
                        "http://web.stanford.edu/class/msande91si/www-spr04/readings/week1/InternetWhitepaper.htm",
                        "https://roadmap.sh/guides/what-is-internet"
                    }
                },
                new RoadmapStepModel()
                {
                    Id = 2,
                    Title = "HTML",
                    Description = "HTML stands for HyperText Markup Language. It is used on the frontend and gives the structure to the webpage which you can style using CSS and make interactive using JavaScript.",
                    Status = true,
                    Rating = 3,
                    specializationStepAt = {0,1},
                    specializationStepOrderAt = {0,2},
                    ResourcesLinks = {
                        "https://cs.fyi/guide/how-does-internet-work",
                        "https://www.vox.com/2014/6/16/18076282/the-internet",
                        "http://web.stanford.edu/class/msande91si/www-spr04/readings/week1/InternetWhitepaper.htm",
                        "https://roadmap.sh/guides/what-is-internet"
                    }
                },
                new RoadmapStepModel()
                {
                    Id = 3,
                    Title = "HTML",
                    Description = "HTML stands for HyperText Markup Language. It is used on the frontend and gives the structure to the webpage which you can style using CSS and make interactive using JavaScript.",
                    Status = true,
                    Rating = 3,
                    specializationStepAt = {0,1},
                    specializationStepOrderAt = {0,2},
                    ResourcesLinks = {
                        "https://cs.fyi/guide/how-does-internet-work",
                        "https://www.vox.com/2014/6/16/18076282/the-internet",
                        "http://web.stanford.edu/class/msande91si/www-spr04/readings/week1/InternetWhitepaper.htm",
                        "https://roadmap.sh/guides/what-is-internet"
                    }
                }
            };*/

        }
    }
}
