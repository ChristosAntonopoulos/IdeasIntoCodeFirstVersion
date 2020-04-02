using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.DTOs
{
    public class ProjectDto
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]

        public string Description { get; set; }

        public bool Active { get; set; }

        public DateTime TimeStamp { get; set; }


    }
}