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
        public IHttpActionResult GetProjects()
        {
            return Ok(context.Projects.ToList());
        }

        [HttpPost]
        
        public IHttpActionResult Join(JoinDto joinDto)
        {
            var userId = User.Identity.GetUserId();
            var developer = context.Developers.Where(d => d.User.Id == userId).SingleOrDefault();

            
            var exists = context.Projects.Include(p => p.Team.TeamMembers)
                .Any(d => d.Team.TeamMembers.Any(t => t.ID == developer.ID) &&
                  d.ID == joinDto.ProjectID);   

            if (exists)
                return BadRequest("The join already exists");           
           
            var project = context.Projects
                .Include(p => p.Team.TeamMembers)
                .Include(p=>p.Admin)
                .Where(p=>p.ID==joinDto.ProjectID).SingleOrDefault();

            project.Team.TeamMembers.Add(developer);
            context.DeveloperNotifications.Add(new DeveloperNotification(project.Admin,new Notification(developer,project,NotificationType.JoinRequest)));
            context.SaveChanges();
            return Ok();
        }
    }
}
