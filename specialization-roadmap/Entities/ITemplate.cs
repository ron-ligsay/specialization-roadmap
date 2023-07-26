using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Entities
{
    public interface ITemplate
    {
        public static int Id { get; set; }
        public static string Title { get; set; } = string.Empty;
        public static string Description { get; set; } = string.Empty;
        public static bool Status { get; set; }

    }
}
