using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Repositories
{
    public class SpecializationRepository
    {
        public List<SpecializationTrack> GetSpecializationTrack() 
        {
            return DataSource();
        }

        public SpecializationTrack GetSpecializationTrackId(int id)
        {
            return DataSource().FirstOrDefault(x => x.Id == id);
        }

        public List<SpecializationTrack> SearchSpecializationTrack(string name, bool status)
        {
            return DataSource().Where(x=> x.Name == name && x.Status == status).ToList();
        }
        private List<SpecializationTrack> DataSource() 
        {
            return new List<SpecializationTrack>()
            {
                new SpecializationTrack() {
                    Id=1, Name="Font-end Developer", Description="Description",
                    Progress=0.3,Status=false,Rating=3.5
                },
                new SpecializationTrack() {
                    Id=1, Name="Back-end Developer", Description="Description",
                    Progress=0.0,Status=false,Rating=4.5
                },
                new SpecializationTrack() {
                    Id=1, Name="Full Stack Developer", Description="Description",
                    Progress=0.0,Status=false,Rating=1.5
                },
                new SpecializationTrack() {
                    Id=1, Name="Application Developer", Description="Description",
                    Progress=0.0,Status=false,Rating=5.0
                }
            };
        }
    }
}
