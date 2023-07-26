using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Entities
{

    public class CourseModel : ITemplate
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Step { get; set; }
        public bool Status { get; set; }
        public int Rating { get; set; }
        public List<string> ResourcesLinks { get; set; }
    }
}
