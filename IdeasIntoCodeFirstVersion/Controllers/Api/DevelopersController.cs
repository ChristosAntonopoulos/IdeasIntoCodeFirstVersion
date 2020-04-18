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
using System.IO;
using IdeasIntoCodeFirstVersion.Persistence;
using IdeasIntoCodeFirstVersion.ViewModels;
using System.Web.Http.Cors;

namespace IdeasIntoCodeFirstVersion.Controllers.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DevelopersController : ApiController
    {
        private ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;
        public DevelopersController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }


        [HttpGet]
        public IHttpActionResult Data()
        {
            var searchString = "d";
            var developers = context.Developers.Include(d => d.User);
            var projects = context.Projects.AsQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                developers = developers.Where(s => s.User.LastName.Contains(searchString)
                || s.User.Name.Contains(searchString));

                projects = projects.Where(p => p.Title.Contains(searchString));
            }

            var viewmodel = new SearchResultViewModel(developers, projects);


            return Ok(viewmodel);
        }
        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    Byte[] b = File.ReadAllBytes(@"E:\Test.jpg");   // You can use your own method over here.
        //    return File(b, "image/jpeg");
        //}
        //GET/ API/developers/developerprofile/
        [HttpPost]
        public IHttpActionResult DeveloperProfile(int bob)
        {
            var userId = User.Identity.GetUserId();
            var ID = 1;
           
            var developer = unitOfWork.Developers.GetDeveloperWithEverythingUsingDeveloperId(ID);
            var viewModel = new DeveloperProfileViewModel
            {
                DeveloperOfProfile = developer,
                ConnectedDeveloperAlreadyFollowsProfileDeveloper = context.Follows.Any(f => f.Follower.ID == ID && f.Followee.ID == ID),
                ShowActionButtons = !(developer.ID == ID)
            };

            return Ok(viewModel);
        }
        

    }
}
