﻿using IdeasIntoCodeFirstVersion.Interface;
using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class NewsFeedViewModel
    {
        public ICollection<INewsFeed> NewsFeeds { get; set; }
        
        //public ICollection<Follow> Followers { get; set; }

        //public List<Comment> Comments { get; set; }
    }
}