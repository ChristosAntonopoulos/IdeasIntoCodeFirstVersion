﻿using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class DeveloperFormViewModel
    {
        public int ProgrammingLanguagesID { get; set; }
        public IEnumerable<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public Developer Developer { get; set; }    
    }
}