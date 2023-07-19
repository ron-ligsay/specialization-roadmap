using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Repositories
{
    /// TODO: Instead of repository use database
    /// <summary>
    /// 
    /// </summary>
    public class SpecializationRepository : SpecializationModel
    {
        public List<SpecializationModel> GetAllSpecializationTrack() 
        {
            return DataSource();
        }

        public SpecializationModel GetSpecializationTrackById(int id)
        {
            return DataSource().FirstOrDefault(x => x.Id == id);
        }

        public SpecializationModel GetSpecializationTrackById(int id, bool status)
        {
            return DataSource().FirstOrDefault(x => x.Id == id && x.Status == status);
        }

        public SpecializationModel GetSpecializationTrackByIndex(int order)
        {
            return DataSource()[order];
        }

        public List<SpecializationModel> SearchSpecializationTrack(string name, bool status)
        {
            return DataSource().Where(x=> x.Title.Contains(name) && x.Status == status).ToList();
        }
        
        // Creating Specialization Repository
        private List<SpecializationModel> DataSource() 
        {
            return new List<SpecializationModel>()
            {
                new SpecializationModel() {
                    Id=1, Title="Font-end Developer", Description="Font-end Developer Description",
                    Progress=1,Status=true,Rating=3.5
                },
                new SpecializationModel() {
                    Id=1, Title="Back-end Developer", Description="Back-end Developer Description",
                    Progress=1,Status=true,Rating=4.5
                },
                new SpecializationModel() {
                    Id=1, Title="Full Stack Developer", Description="Full Stack Developer Description",
                    Progress=0.0,Status=false,Rating=1.5
                },
                new SpecializationModel() {
                    Id=1, Title="Application Developer", Description="Application Developer Description",
                    Progress=0.0,Status=false,Rating=5.0
                }
            };
        }
    }
}
