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
        public int FollowerID { get; protected set; }
        public Developer Follower { get; protected set; }

        public DateTime TimeStamp { get; set; }

        [Key, Column(Order = 1)]
        public int FolloweeID { get; protected set; }
        public Developer Followee { get; protected set; }

        protected Follow()
        {

        }

        public Follow(int followerID,int followeeID)
        {
            FollowerID = followerID;
            FolloweeID = followeeID;
            TimeStamp = DateTime.Now;


        }
    }
}