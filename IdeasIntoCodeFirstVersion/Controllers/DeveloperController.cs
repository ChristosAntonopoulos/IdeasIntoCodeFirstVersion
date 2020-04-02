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

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class DeveloperController : Controller
    {
        private ApplicationDbContext context;
        public DeveloperController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Authorize]
        public ActionResult NewsFeed()
        {
            var userId = User.Identity.GetUserId();
            var developerid = context.Developers.Where(d => d.User.Id == userId).Select(d => d.ID).SingleOrDefault();
            var newsFeedList = new List<INewsFeed>();
            var follows = context.Follows.Where(f => f.FollowerID == developerid).Select(f => f.FolloweeID).ToList();
            var comments = context.Comments.Where(c => follows.Contains(c.DeveloperID))
                .OrderBy(c => c.TimeStamp)
                .Include(c => c.Developer)
                .Include(c => c.Developer.User)
                .Include(c => c.Project)
                .Include(c => c.Project.Admin)
                .Take(10).ToList();

            var followers = context.Follows
                .Where(f => follows
                .Contains(f.FollowerID))
                .OrderBy(f => f.TimeStamp)
                .Include(f => f.Followee)
                .Include(f => f.Followee.User)
                .Include(f => f.Follower)
                .Include(f => f.Follower.User)
                .Take(10).ToList();

            newsFeedList.AddRange(comments);
            newsFeedList.AddRange(followers);
            newsFeedList.AddRange(context.Projects.OrderBy(p => p.TimeStamp).Include(c => c.Admin).Include(p => p.Admin.User).Take(10).ToList());


            return View(newsFeedList.OrderBy(n => n.TimeStamp).ToList());
        }


        public ActionResult DeveloperProfile(int? ID)
        {
            var userId = User.Identity.GetUserId(); 
            if (ID == null)
            {
                RedirectToAction("DeveloperProfile", ID=context.Developers.Where(d => d.UserID == userId).Select(d => d.ID).SingleOrDefault());                   
            } 
            var developer = context.Developers
                .Include(u => u.ProgrammingLanguages)
                .Include(d => d.ProjectsOwned)
                .Include(d => d.Followers)
                .Include(d => d.Following)
                .Include(d => d.SendMessages)
                .Include(d => d.RecievedMessages)
                .Include(d => d.User)
                .SingleOrDefault(u => u.ID == ID);
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
            var developer = context.Developers
                .Include(d => d.ProgrammingLanguages)
                .Include(d => d.User)
                .SingleOrDefault(p => p.User.Id == currentUserID);
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
            var DeveloperDB = context.Developers.Include(d=>d.User).Include(d => d.ProgrammingLanguages).Single(u => u.User.Id == userID);
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
            DeveloperDB.User.Name = developer.User.Name;
            DeveloperDB.User.LastName = developer.User.LastName;
            DeveloperDB.GitHub = developer.GitHub;
            DeveloperDB.User.Email = developer.User.Email;
            DeveloperDB.BirthDate = developer.BirthDate;
            context.SaveChanges();
            var developerID = context.Developers.Where(d => d.User.Id == userID).Select(d => d.ID).SingleOrDefault();
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