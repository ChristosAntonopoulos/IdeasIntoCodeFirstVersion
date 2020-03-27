using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace IdeasIntoCodeFirstVersion.Controllers.API
{
    public class DevelopersController : ApiController
    {
        private ApplicationDbContext context;
        public DevelopersController()
        {
            context = new ApplicationDbContext();
        }

        //GET/ API/developers
        public IHttpActionResult GetDevelopers()
        {
            var userId = User.Identity.GetUserId();
            var dev = context.Developers
                        .Include(d => d.Comments)
                        .Include(d => d.RecievedMessages)
                        .Include(d => d.SendMessages).SingleOrDefault(d => d.UserID == userId);
            return Ok(dev);
        }
    }
}
