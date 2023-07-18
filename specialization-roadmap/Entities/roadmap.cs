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
        public new string Name { get; set; }
        public new string Description { get; set; }
        //public new double Progress { get; set; }
        public new bool Status { get; set; }
        public new int Rating { get; set; }
    }

    public class RoadmapStep : IRoadmap
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public double Progress { get; set; }
        public bool Status { get; set; }
        public int Rating { get; set; }
    }
}
