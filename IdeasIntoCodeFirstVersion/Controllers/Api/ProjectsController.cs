using AutoMapper;
using IdeasIntoCodeFirstVersion.Dtos;
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

        [HttpPost]
        
        public IHttpActionResult Join(JoinDto joinDto)
        {
            //var userId = User.Identity.GetUserId();
            var developers = context.Developers;
            bool exist = true;
            var teams = context.Teams.Include(t => t.TeamMembers);
            foreach (var team in teams)
            {
                foreach (var developer in developers)
                {
                   exist= team.TeamMembers.Any(t => t.ID == developer.ID);
                }
                
            }
            var exists = context.Projects.Any(p=>p.ID == joinDto.ProjectID);

            if (exists && exist)
                return BadRequest("The attendance already exists");



            var join = new Team
            {
                ProjectID = joinDto.ProjectID
                //TeamMembers
            };

            context.Teams.Add(join);
            context.SaveChanges();
            return Ok();
        }
    }
}
