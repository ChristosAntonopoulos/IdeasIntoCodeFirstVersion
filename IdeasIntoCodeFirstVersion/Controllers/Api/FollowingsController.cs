﻿using IdeasIntoCodeFirstVersion.Dtos;
using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
                return BadRequest("The followers already exists");

            var following = new Follow()
            {
                FolloweeID = followingDto.FolloweeID,
                FollowerID = developer.ID
            };

            context.Follows.Add(following);
            context.SaveChanges();

            return Ok();
        }

    }
}