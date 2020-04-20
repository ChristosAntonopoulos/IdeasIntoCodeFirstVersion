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
            
            //var userId = User.Identity.GetUserId();
            var developer = unitOfWork.Developers.GetDeveloperIncludeUser(ID);
            
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
            var ID = 1;
            //var viewModel = new ProjectFormViewModel(new Project(unitOfWork.Developers.GetAdminId(userID)));
            var viewModel = new ProjectFormViewModel(new Project(ID));

            return Ok( viewModel);
        }

        [HttpGet]
        public IHttpActionResult Edit(int ID)
        {
            ID = 1;
            var project = unitOfWork.Projects.FindProject(ID);

            //if (project == null)
            //    return HttpNotFound();
            //allagh
            var viewModel = new ProjectFormViewModel(project, unitOfWork.Categories.GetCategories(), unitOfWork.ProgrammingLanguages.GetLanguages());

            return Ok( viewModel);
        }


        [HttpPost]
        public IHttpActionResult Save(Project project)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProjectFormViewModel(project);

                return Ok(viewModel);
            }

            if (project.ID == 0)
            {
                project.TimeStamp = DateTime.Now;

                unitOfWork.Projects.Add(project);
                var newsFeedHub = new NewsFeedTickerHub();
                //var currentDev = context.Developers.Where(d => d.User.Id == userId).Include(d => d.User).FirstOrDefault();
                //var path = Server.MapPath("/Content/Images/homepage.jpg");

                //var pic = base.File(path, "image/jpg");

                //newsFeedHub.SendNotification(unitOfWork.Developers.GetDevelopersToUpdate(project.AdminID), project, currentDev, pic);

            }
            else
            {
                var projectDb = unitOfWork.Projects.FindProject(project.ID);
                projectDb.Title = project.Title;
                projectDb.Description = project.Description;
            }
            unitOfWork.Complete();
            return Ok(project);
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
