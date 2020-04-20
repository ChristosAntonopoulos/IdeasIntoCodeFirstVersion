using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class ProjectWithProgrammingLanguagesViewModel
    {
      
        public Project Project { get; set; }
        public ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}