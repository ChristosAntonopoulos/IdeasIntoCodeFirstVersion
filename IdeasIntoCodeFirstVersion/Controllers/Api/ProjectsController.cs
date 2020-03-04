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
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext context;
        public ProjectsController()
        {
            context = new ApplicationDbContext();
        }
        //GET/ API/projects
        public IHttpActionResult GetProjects(/*string searchstring*/)
        {
            //var projectsQuery = context.Projects.AsQueryable();
            //if (!String.IsNullOrWhiteSpace(query))
            //    projectsQuery = projectsQuery.Where(p => p.Title.Contains(query));
            //var projects = projectsQuery.ToList()
            //    .Select(Mapper.Map<Project, ProjectDto>);
            //var projects = context.Projects.Where(d => d.Title.Contains(searchstring)).Select(Mapper.Map<Project, ProjectDto>)
            // .ToList();

            var projects = context.Projects.ToList();
            return Ok(projects);
        }
    }
}
