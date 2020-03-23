using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class DeveloperProfileViewModel
    {
        public Developer DeveloperOfProfile { get; set; }
        public bool ShowActionButtons { get; set; } = true;
        public bool ConnectedDeveloperAlreadyFollowsProfileDeveloper { get; set; }
    }
}