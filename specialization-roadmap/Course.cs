using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap
{
    public interface ICourse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Progress { get; set; }
        public bool status { get; set; }

    }
}
