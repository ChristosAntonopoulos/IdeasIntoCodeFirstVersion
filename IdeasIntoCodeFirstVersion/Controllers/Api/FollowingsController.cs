using IdeasIntoCodeFirstVersion.Dtos;
using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext context;
        public FollowingsController()
        {
            context = new ApplicationDbContext();
        }
        public IEnumerable<Developer> GetListOfFollowers(int ID, string list)
        {
            var developer = context.Developers.SingleOrDefault(d => d.ID == ID);
            var listToDisplay = new List<Developer>();
            if (list == "Followers")
            {
                listToDisplay = context.Follows.Where(f => f.FolloweeID == ID).Select(f => f.Follower)
                .Include(f => f.User)
                .ToList();
            }
            else if (list == "Following")
            {
                listToDisplay = context.Follows.Where(f => f.FollowerID == ID).Select(f => f.Followee)
                .Include(f => f.User)
                .ToList();
            }
            return listToDisplay;
        }

        //POST /api/followings
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            var developer = context.Developers.Where(d => d.User.Id == userId).SingleOrDefault();
            if (context.Follows.Any(f => f.FolloweeID == followingDto.FolloweeID && f.FollowerID == developer.ID))
            {
                var follow = context.Follows.Single(f => f.FolloweeID == followingDto.FolloweeID && f.FollowerID == developer.ID);
                context.Follows.Remove(follow);
            }
            else
            {
                var following = new Follow(developer.ID, followingDto.FolloweeID);
                context.DeveloperNotifications.Add(new DeveloperNotification(followingDto.FolloweeID, new Notification(developer, NotificationType.Followed)));
                context.Follows.Add(following);
            }
            context.SaveChanges();
            return Ok();
        }

    }
}
