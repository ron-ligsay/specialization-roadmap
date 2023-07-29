using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specialization_roadmap.Entities
{
    public class Study
    {
        public Study() { }
        
        public Study(int _Id, string _Title, string _Description, bool _Status)
        {
            this.Id = _Id;
            this.Title = _Title;
            this.Description = _Description;
            this.Status = _Status;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
