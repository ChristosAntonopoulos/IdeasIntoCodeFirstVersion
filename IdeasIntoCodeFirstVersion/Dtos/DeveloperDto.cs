using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.DTOs
{
    public class DeveloperDto
    {
        public int ID { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + Name;
            }
        }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }
        public string GitHub { get; set; }
        public ICollection<ProjectDto> ProjectsOwned { get; set; }
    }
}