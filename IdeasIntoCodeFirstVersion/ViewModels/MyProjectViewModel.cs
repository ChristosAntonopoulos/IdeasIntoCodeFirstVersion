using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class MyProjectViewModel
    {
        public List<Project> MyProjects { get; set; }
        public List<Project> ProjectParticipates { get; set; }
        public MyProjectViewModel(List<Project> myprojects,List<Project> projectsparticipates)
        {
            MyProjects = myprojects;
            ProjectParticipates = projectsparticipates;
        }
    }
}