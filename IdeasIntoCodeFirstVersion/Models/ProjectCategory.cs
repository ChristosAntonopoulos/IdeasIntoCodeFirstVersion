using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class ProjectCategory
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ProjectCategory()
        {
            Projects = new List<Project>();
        }

    }
}