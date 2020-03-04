using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class ProjectFormViewModel
    {
        public ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public ICollection<ProjectCategory> ProjectCategories { get; set; }

        public Project Project { get; set; }
    }
}