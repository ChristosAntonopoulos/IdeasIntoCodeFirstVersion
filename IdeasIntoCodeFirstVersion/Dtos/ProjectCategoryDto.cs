using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.DTOs
{
    public class ProjectCategoryDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<ProjectDto> Projects { get; set; }
    }
}