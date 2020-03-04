using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.DTOs
{
    public class ProgrammingLanguageDto
    {
        public int ID { get; set; }


        [Required]
        public string Name { get; set; }

        public ICollection<ProjectDto> Projects { get; set; }

        public ICollection<DeveloperDto> Developers { get; set; }
    }
}