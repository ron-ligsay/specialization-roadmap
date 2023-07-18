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

        public List<string> ResourcesLinks { get; set; }
    }

    public class RoadmapStep : IRoadmap
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        
        public int Rating { get; set; }

        public List<string>? ResourcesLinks { get; set; }
    }
}
