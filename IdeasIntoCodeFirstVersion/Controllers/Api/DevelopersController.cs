using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            return Ok(context.Developers.ToList());
        }
    }
}
