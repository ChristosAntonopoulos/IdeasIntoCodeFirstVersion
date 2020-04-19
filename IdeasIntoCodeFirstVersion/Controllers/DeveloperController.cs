using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;
using System.IO;
using IdeasIntoCodeFirstVersion.Interface;
using IdeasIntoCodeFirstVersion.Persistence;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class DeveloperController : Controller
    {
        private ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;
        public DeveloperController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


        [Authorize]
        public ActionResult RegisterForm(int? ID)
        {
            var userId = User.Identity.GetUserId();
            if (ID == null)
            {
                RedirectToAction("RegisterForm", ID = unitOfWork.Developers.GetDeveloperIDUsingUserID(userId));
            }
            var developer = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(ID);


            return View("RegisterForm", developer);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterForm(Developer developer)
        {
            var userID = User.Identity.GetUserId();
            var developerDb = unitOfWork.Developers.GetDeveloperIncludeUser(userID);

            
            developerDb.GitHub = developer.GitHub;
            developerDb.Linkedin = developer.Linkedin;
            developerDb.BirthDate = developer.BirthDate;
            context.SaveChanges();
            var developerID = developerDb.ID;
            return RedirectToAction("DeveloperProfile", new { id = developerID });
        }

        [Authorize]
        public ActionResult NewsFeed()
        {
            var userId = User.Identity.GetUserId();
            var developerId = unitOfWork.Developers.GetDeveloperIDUsingUserID(userId);
            var newsFeedList = new List<INewsFeed>();
            var follows = unitOfWork.Follows.GetFolloweesIdsUsingDeveloperId(developerId);
            var comments = unitOfWork.Comments.GetCommentsOfFollowees(follows);
            //Εδω φερνει λιστα απο τους followers των followees?
            var followers = unitOfWork.Follows.GetFollowersOfFollowees(follows);

            newsFeedList.AddRange(comments);
            newsFeedList.AddRange(followers);
            newsFeedList.AddRange(unitOfWork.Projects.Get10NewestProjects());


            return View(newsFeedList.OrderBy(n => n.TimeStamp).ToList());
        }


        [Authorize]
        public ActionResult DeveloperProfile(int? ID)
        {
            var userId = User.Identity.GetUserId(); 
            if (ID == null)
            {
                RedirectToAction("DeveloperProfile", ID=unitOfWork.Developers.GetDeveloperIDUsingUserID(userId));                   
            }
            var developer = unitOfWork.Developers.GetDeveloperWithEverythingUsingDeveloperId(ID);
            var viewModel = new DeveloperProfileViewModel
            {
                DeveloperOfProfile = developer,
                ConnectedDeveloperAlreadyFollowsProfileDeveloper = context.Follows.Any(f=>f.Follower.UserID==userId && f.Followee.ID==ID),
                ShowActionButtons = !(developer.UserID==userId)
            };
          
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit()
        {
            var currentUserID = User.Identity.GetUserId();
            var developer = unitOfWork.Developers.GetDeveloperWithUserAndProgrammingLanguagesUsingUserId(currentUserID);
            if (developer == null)
                return HttpNotFound();

            return View("DeveloperForm", developer);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Developer developer, string[] programmingLanguage)
        {
            var userID = User.Identity.GetUserId();
            var AllProgrammingLanguage = context.ProgrammingLanguages.ToList();
            if (!ModelState.IsValid)
            {
                ProgrammingLanguage.UpdateDeveloperProgrammingLanguages(developer.ProgrammingLanguages.ToList(), programmingLanguage, AllProgrammingLanguage);
              
                return View("DeveloperForm", developer);
            }
            var DeveloperDB = unitOfWork.Developers.GetDeveloperWithUserAndProgrammingLanguagesUsingUserId(userID);
            if (programmingLanguage != null)
            {
                ProgrammingLanguage.UpdateDeveloperProgrammingLanguages(developer.ProgrammingLanguages.ToList(), programmingLanguage, AllProgrammingLanguage);
            }
            var fileName = Path.GetFileName(developer.ProfilePicture.FileName);
            DeveloperDB.Picture = Guid.NewGuid() + fileName;
            var path = Path.Combine(Server.MapPath("~/Content/Images/ProfilePicture/" + DeveloperDB.ID), DeveloperDB.Picture);
            if (!Directory.Exists(Server.MapPath("~/Content/Images/ProfilePicture/" + DeveloperDB.ID)))
            {
                Directory.CreateDirectory(Server.MapPath("~/Content/Images/ProfilePicture/" + DeveloperDB.ID));
            }
            developer.ProfilePicture.SaveAs(path);           
            //DeveloperDB.User.Name = developer.User.Name;
            //DeveloperDB.User.LastName = developer.User.LastName;
            DeveloperDB.GitHub = developer.GitHub;
            DeveloperDB.Linkedin = developer.Linkedin;
            DeveloperDB.User.Email = developer.User.Email;
            DeveloperDB.BirthDate = developer.BirthDate;
            unitOfWork.Complete();
            var developerID = unitOfWork.Developers.GetDeveloperIDUsingUserID(userID);
            return RedirectToAction("DeveloperProfile",new { id = developerID });
        }


        //[HttpGet]
        //public ActionResult Get()
        //{
        //    var path = Server.MapPath("/Content/Images/homepage.jpg");
        //    //var path = Path.Combine(dir, ".jpg"); //validate the path for security or use other means to generate the path.
        //    return base.File(path, "image/jpg");
            
        //}




    }
}