using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class ProjectWithDeveloperViewModel
    {
        public Project Project { get; set; }
        public Developer Developer { get; set; }
    }
}