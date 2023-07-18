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
        public static new string Title { get; set; } = string.Empty;
        public static new string Description { get; set; } = string.Empty;
        public static new bool Status { get; set; }
        
        public static double Rating { get; set; }

    }

    public class SpecializationModel : ISpecialization
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        
        public double Rating { get; set; }
        public double Progress { get; set; }
    }
    
}
