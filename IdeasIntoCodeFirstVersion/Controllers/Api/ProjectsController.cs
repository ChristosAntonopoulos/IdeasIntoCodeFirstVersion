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
using IdeasIntoCodeFirstVersion.Persistence;
using IdeasIntoCodeFirstVersion.ViewModels;
using System.Web.Http.Cors;

namespace IdeasIntoCodeFirstVersion.Controllers.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext context;
        private UnitOfWork unitOfWork;
        public ProjectsController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public IHttpActionResult MyProject(int ID)
        {
            ID = 2;
            //var userId = User.Identity.GetUserId();
            var userId = context.Developers.Where(d => d.ID == ID).Select(d => d.UserID).FirstOrDefault();
            
            var developer = unitOfWork.Developers.GetDeveloperIncludeProject(userId);

            return Ok(developer);
        }

        [HttpGet]
        public IHttpActionResult ProjectProfile(int ID)
        {
            ID = 2;
            //var userId = User.Identity.GetUserId();
            var userId = "c8b92021-4913-4a83-a79f-4d56ef1a12bc";
            var developer = unitOfWork.Developers.GetDeveloperIncludeUser(userId);
            var project = unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(ID);

            var viewModel = new ProjectViewModel(developer, project);

            if (developer.ID != project.AdminID)
            {
                viewModel.IsActive();
            }

            project.ModifyInActive(developer, viewModel);

            return Ok(viewModel);
        }

       
        [HttpGet]
        public IHttpActionResult New()
        {
            //var userID = User.Identity.GetUserId();
            var userID = "c8b92021-4913-4a83-a79f-4d56ef1a12bc";
            var viewModel = new ProjectFormViewModel(new Project(unitOfWork.Developers.GetAdminId(userID)));

            return Ok( viewModel);
        }

        [HttpGet]
        public IHttpActionResult Edit(int ID)
        {
            ID = 2;
            var project = unitOfWork.Projects.FindProject(ID);

            //if (project == null)
            //    return HttpNotFound();
            //allagh
            var viewModel = new ProjectFormViewModel(project, unitOfWork.Categories.GetCategories(), unitOfWork.ProgrammingLanguages.GetLanguages());

            return Ok( viewModel);
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
