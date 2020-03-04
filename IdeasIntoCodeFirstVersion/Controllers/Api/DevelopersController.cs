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
        public IHttpActionResult GetDevelopers(/*string searchstring*/)
        {
            //var developersQuery = context.Developers.AsQueryable();
            //if (!String.IsNullOrWhiteSpace(query))
            //    developersQuery = developersQuery.Where(d => d.FullName.Contains(query));
            //var developers = developersQuery.ToList()
            //    .Select(Mapper.Map<Developer, DeveloperDto>);
            //var dev = context.Developers.Where(d => d.Name.Contains(searchstring)
            //  || d.LastName.Contains(searchstring)).Select(Mapper.Map<Developer, DeveloperDto>)
            //    .ToList();
            var dev = context.Developers.ToList();
            return Ok(dev);
        }
    }
}
