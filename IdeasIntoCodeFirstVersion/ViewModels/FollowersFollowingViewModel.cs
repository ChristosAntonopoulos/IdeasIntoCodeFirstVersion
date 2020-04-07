using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class FollowersFollowingViewModel
    {
        public int ID { get; set; }
        public string WhatListToGet { get; set; }

        public FollowersFollowingViewModel()
        { }
        public FollowersFollowingViewModel(int Id, string whatListToGet)
        {
            ID = Id;
            WhatListToGet = whatListToGet;
        }
    }
}