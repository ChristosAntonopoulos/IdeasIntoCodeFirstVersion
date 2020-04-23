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
using System.Web.Http.Cors;
using IdeasIntoCodeFirstVersion.Persistence;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext context;

        private readonly UnitOfWork unitOfWork;
        public FollowingsController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }
        public IEnumerable<Developer> GetListOfFollowers(int ID, string list)
        {
            var developer = context.Developers.SingleOrDefault(d => d.ID == ID);
            var listToDisplay = new List<Developer>();
            if (list == "Followers")
            {
                listToDisplay = unitOfWork.Follows.GetFollowers(ID);
            }
            else if (list == "Following")
            {
                listToDisplay = unitOfWork.Follows.GetFollowees(ID);
            }
            return listToDisplay;
        }

        //POST /api/followings
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            
            var developer = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(followingDto.FollowerID);
            var following = new Follow(developer.ID, followingDto.FolloweeID);
            context.DeveloperNotifications.Add(new DeveloperNotification(followingDto.FolloweeID, new Notification(developer, NotificationType.Followed)));
            unitOfWork.Follows.Add(following);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UnFollow(FollowingDto followingDto)
        {
            var developer = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(followingDto.FollowerID);
            var follow = unitOfWork.Follows.GetFollow(developer.ID, followingDto.FolloweeID);
            unitOfWork.Follows.Delete(follow);
            unitOfWork.Complete();
            return Ok();
        }
    }
}
