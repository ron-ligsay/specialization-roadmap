using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Entities
{
    public interface ICourse
    {
        public static int Id { get; set; }
        public static string Name { get; set; } = string.Empty;
        public static string Description { get; set; } = string.Empty;
        public static double Progress { get; set; }
        public static bool Status { get; set; }

    }
}
