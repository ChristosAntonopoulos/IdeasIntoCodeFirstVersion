using IdeasIntoCodeFirstVersion.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class Follow:INewsFeed
    {
        [Key, Column(Order = 0)]
        public int FollowerID { get; set; }
        public Developer Follower { get; set; }

        public DateTime TimeStamp { get; set; }

        [Key, Column(Order = 1)]
        public int FolloweeID { get; set; }
        public Developer Followee { get; set; }
    }
}