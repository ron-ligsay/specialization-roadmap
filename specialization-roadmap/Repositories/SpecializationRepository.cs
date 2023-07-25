using specialization_roadmap.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public SpecializationModel specializationModel { get; set; }

        public SpecializationModel SelectedModel { get; set; }

        public List<SpecializationModel> specializationModels { get; set; }

        public ObservableCollection<SpecializationModel> GetAllSpecializationTrackObservation()
        {
            return DataSourceObservation();
        }

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

        /*
        internal IEnumerable<SpecializationModel> GetAllSpecialization()
        {
            throw new NotImplementedException();
        }*/

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
                    Id=2, Title="Back-end Developer", Description="Back-end Developer Description",
                    Progress=1,Status=true,Rating=4.5
                },
                new SpecializationModel() {
                    Id=3, Title="Full Stack Developer", Description="Full Stack Developer Description",
                    Progress=0.0,Status=false,Rating=1.5
                },
                new SpecializationModel() {
                    Id=4, Title="Application Developer", Description="Application Developer Description",
                    Progress=0.0,Status=false,Rating=5.0
                }
            };
        }

        // Creating Specialization Repository
        private ObservableCollection<SpecializationModel> DataSourceObservation()
        {
            return new ObservableCollection<SpecializationModel>()
            {
                new SpecializationModel() {
                    Id=1, Title="Font-end Developer", Description="Font-end Developer Description",
                    Progress=1,Status=true,Rating=3.5
                },
                new SpecializationModel() {
                    Id=2, Title="Back-end Developer", Description="Back-end Developer Description",
                    Progress=1,Status=true,Rating=4.5
                },
                new SpecializationModel() {
                    Id=3, Title="Full Stack Developer", Description="Full Stack Developer Description",
                    Progress=0.0,Status=false,Rating=1.5
                },
                new SpecializationModel() {
                    Id=4, Title="Application Developer", Description="Application Developer Description",
                    Progress=0.0,Status=false,Rating=5.0
                }
            };
        }

        public SpecializationRepository()
        {
            this.specializationModels = this.DataSource();

        }

    }
}
