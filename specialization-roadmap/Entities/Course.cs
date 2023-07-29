using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Entities
{

    public class CourseModel : ITemplate
    {
        public int Step { get; set; }
        public List<string> ResourcesLinks { get; set; }
    }
}
