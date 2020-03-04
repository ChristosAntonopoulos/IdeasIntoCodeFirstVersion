using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.DTOs
{
    public class CommentDto
    {
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        public int DeveloperID { get; set; }
        public DeveloperDto Developer { get; set; }
        [Required]
        public int ProjectID { get; set; }
        public ProjectDto Project { get; set; }
    }
}