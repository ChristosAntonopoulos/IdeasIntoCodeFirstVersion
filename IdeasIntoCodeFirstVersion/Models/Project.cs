﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class Project
    {

        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]

        public string Description { get; set; }

        public bool Active { get; set; }

        public int AdminID { get; set; }

        [ForeignKey("AdminID")]
        public  Developer Admin { get; set; }
       
        public Team Team { get; set; }


        public ICollection<ProjectCategory> ProjectCategories { get; set; }

        public ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public ICollection<Comment> Comments { get; set; }




    }
}