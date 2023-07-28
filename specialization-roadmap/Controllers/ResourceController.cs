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
    public class ResourceController
    {
        private readonly ResourceRepository resourceRepository;
        private readonly DatabaseManager Connection;

        public ResourceController(int CourseID)
        {
            Connection = new DatabaseManager();
            resourceRepository = new ResourceRepository(Connection);
            LoadResourcesAsync(CourseID);
        }


        // this should be on ResourceController
        /// <summary>
        /// Getting Resources
        /// </summary>
        private ObservableCollection<Resource> resourceCollection { get; set; }
        public ObservableCollection<Resource> ResourceCollection
        {
            get { return resourceCollection; }
            set { resourceCollection = value; }
        }

        private async void LoadResourcesAsync(int CourseID)
        {
            
            ResourceCollection = await resourceRepository.GetResources(CourseID);
        }
    }
}
