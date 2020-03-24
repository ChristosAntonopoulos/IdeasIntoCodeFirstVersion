using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class ProjectViewModel
    {
        public Project Project { get;  set; }
        public bool? Action { get; set; }
        public Developer Developer { get; set; }

        public ProjectViewModel()
        {

        }

        public ProjectViewModel(Developer developer,Project project)
        {
            Developer = developer;
            Project = project;
        }
    }
}