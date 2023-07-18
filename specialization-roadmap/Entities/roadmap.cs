﻿using System;
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
        public new double Progress { get; set; }
        public new bool Status { get; set; }
        public new int Rating { get; set; }
    }
}
