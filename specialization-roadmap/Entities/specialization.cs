using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Entities
{
    public interface ISpecialization : ICourse
    {

        public static new int Id { get; set; }
        public static new string Name { get; set; } = string.Empty;
        public static new string Description { get; set; } = string.Empty;
        public static new double Progress { get; set; }
        public static new bool Status { get; set; }

    }

    public class SpecializationTrack : ISpecialization
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Progress { get; set; }
        public bool Status { get; set; }
    }
    
}
