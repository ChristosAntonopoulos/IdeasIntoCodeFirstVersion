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
using IdeasIntoCodeFirstVersion.Interface;

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
            string searchString = "d";
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

        
        [HttpGet]
        public IHttpActionResult Edit(int ID)
        {
            //var currentUserID = User.Identity.GetUserId();

            //var currentUserID = "c8b92021-4913-4a83-a79f-4d56ef1a12bc";
            var developer = unitOfWork.Developers.GetDeveloperWithEverythingUsingDeveloperId(ID);
            //if (developer == null)
            //    return HttpNotFound();

            return Ok( developer);
        }
        public IHttpActionResult GetDeveloper(int ID)
        {
            //var userId = User.Identity.GetUserId();

            
            var developer = unitOfWork.Developers.GetDeveloperWithEverythingUsingDeveloperId(ID);
           

            return Ok(developer);
        }

        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    Byte[] b = File.ReadAllBytes(@"E:\Test.jpg");   // You can use your own method over here.
        //    return File(b, "image/jpeg");
        //}
        //GET/ API/developers/developerprofile/
        [HttpGet]
        public IHttpActionResult DeveloperProfile(int ID )
        {
            //var userId = User.Identity.GetUserId();

            var developer = unitOfWork.Developers.GetDeveloperWithEverythingUsingDeveloperId(ID);
            var viewModel = new DeveloperProfileViewModel
            {
                DeveloperOfProfile = developer,
                ConnectedDeveloperAlreadyFollowsProfileDeveloper = context.Follows.Any(f => f.Follower.ID == ID && f.Followee.ID == ID),
                ShowActionButtons = !(developer.ID == ID)
            };

            return Ok(viewModel);
        }

        [HttpPost]        
        public IHttpActionResult RegisterForm(Developer developer)
        {
            //var userID = User.Identity.GetUserId();
            var developerDb = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(developer.ID);
            developerDb.GitHub = developer.GitHub;
            developerDb.Linkedin = developer.Linkedin;
            developerDb.BirthDate = developer.BirthDate;
            context.SaveChanges();
           
            return Ok(developerDb);
        }


        [HttpGet]
        public IHttpActionResult NewsFeed()
        {
           // var userId = User.Identity.GetUserId();
            var userId= "c8b92021-4913-4a83-a79f-4d56ef1a12bc";
            var developerId = unitOfWork.Developers.GetDeveloperIDUsingUserID(userId);
            var newsFeedList = new List<INewsFeed>();
            var follows = unitOfWork.Follows.GetFolloweesIdsUsingDeveloperId(developerId);
            var comments = unitOfWork.Comments.GetCommentsOfFollowees(follows);
            //Εδω φερνει λιστα απο τους followers των followees?
            var followers = unitOfWork.Follows.GetFollowersOfFollowees(follows);

            newsFeedList.AddRange(comments);
            newsFeedList.AddRange(followers);
            newsFeedList.AddRange(unitOfWork.Projects.Get10NewestProjects());


            return Ok(newsFeedList.OrderBy(n => n.TimeStamp).ToList());
        }
    }
}
