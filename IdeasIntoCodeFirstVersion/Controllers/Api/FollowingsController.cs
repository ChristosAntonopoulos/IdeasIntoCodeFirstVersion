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
                var following = new Follow()
                {
                    FolloweeID = followingDto.FolloweeID,
                    FollowerID = developer.ID,
                    TimeStamp = DateTime.Now
                };
                var notification = new Notification() { Developer = developer, TimeStamp = DateTime.Now, Type = NotificationType.Followed };
                context.DeveloperNotifications.Add(new DeveloperNotification() { DeveloperID = followingDto.FolloweeID, Notification = notification, Developer = developer });
                context.Follows.Add(following);
            }         
            context.SaveChanges();
            return Ok();
        }

    }
}
