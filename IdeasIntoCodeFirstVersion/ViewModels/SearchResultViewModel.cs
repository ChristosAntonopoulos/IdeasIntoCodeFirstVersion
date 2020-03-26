using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class SearchResultViewModel
    {
        public IEnumerable<Developer> Developers { get; set; }

        public IEnumerable<Project> Projects { get; set; }


        public SearchResultViewModel()
        {

        }
        public SearchResultViewModel(IQueryable<Developer> developers,IQueryable<Project> projects)
        {
            Developers = developers.ToList();
            Projects = projects.ToList();
        }



    }
}