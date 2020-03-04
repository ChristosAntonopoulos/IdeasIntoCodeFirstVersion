using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class SearchResultViewModel
    {
        public ICollection<Developer> Developers { get; set; }

        public ICollection<Project> Projects { get; set; }

        public string searchString { get; set; }

        


    }
}