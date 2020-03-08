using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class ProgrammingLanguage
    {
        public int ID { get; set; }


        [Required]
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }

        public  ICollection<Developer> Developers { get; set; }

        public ProgrammingLanguage()
        {
            Projects = new List<Project>();
            Developers = new List<Developer>();
        }
             

        

        
    }
}