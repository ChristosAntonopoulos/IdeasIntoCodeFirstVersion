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
            var Developer = context.Developers
                .Include(d => d.ProgrammingLanguages)
                .Include(d => d.User)
                .SingleOrDefault(p => p.User.Id == currentUserID);
            if (Developer == null)
                return HttpNotFound();
            var viewModel = new DeveloperFormViewModel()
            {
                Developer = Developer
            };

            return View("DeveloperForm", viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Developer developer, string[] programmingLanguage)
        {
            var userID = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                PopulateDeveloperProgrammingLanguages(developer, programmingLanguage);
                var viewModel = new DeveloperFormViewModel
                {                    
                    Developer = developer
                };
                return View("DeveloperForm", viewModel);
            }
            var DeveloperDB = context.Developers.Include(d=>d.User).Include(d => d.ProgrammingLanguages).Single(u => u.User.Id == userID);
            if (programmingLanguage != null)
            {
                if (DeveloperDB.ProgrammingLanguages.Count() == 0)
                {
                    PopulateDeveloperProgrammingLanguages(DeveloperDB, programmingLanguage);
                }
                else
                {
                    UpdateDeveloperProgrammingLanguages(DeveloperDB, programmingLanguage);
                }
            }
            var fileName = Path.GetFileName(developer.ProfilePicture.FileName);
            var rondom = Guid.NewGuid() + fileName;
            DeveloperDB.Picture = Path.Combine(Server.MapPath("~/Content/Images/ProfilePicture/" + DeveloperDB.ID), rondom);
            if (!Directory.Exists(Server.MapPath("~/Content/Images/ProfilePicture/" + DeveloperDB.ID)))
            {
                Directory.CreateDirectory(Server.MapPath("~/Content/Images/ProfilePicture/" + DeveloperDB.ID));
            }
            developer.ProfilePicture.SaveAs(DeveloperDB.Picture);           
            DeveloperDB.User.Name = developer.User.Name;
            DeveloperDB.User.LastName = developer.User.LastName;
            DeveloperDB.GitHub = developer.GitHub;
            DeveloperDB.User.Email = developer.User.Email;
            DeveloperDB.BirthDate = developer.BirthDate;
            context.SaveChanges();
            var developerID = context.Developers.Where(d => d.User.Id == userID).Select(d => d.ID).SingleOrDefault();
            return RedirectToAction("DeveloperProfile",new { id = developerID });
        }

        private void UpdateDeveloperProgrammingLanguages(Developer developer, string[] programmingLanguage)
        {

            foreach (var language in context.ProgrammingLanguages)
            {
                if (programmingLanguage.Contains(language.ID.ToString()))
                {
                    if (!developer.ProgrammingLanguages.Contains(language))
                    {
                        developer.ProgrammingLanguages.Add(language);
                        

                    }
                }
                else
                {
                    if (developer.ProgrammingLanguages.Contains(language))
                    {
                        developer.ProgrammingLanguages.Remove(language);
                    }
                }
            }
        }
        
        private void PopulateDeveloperProgrammingLanguages(Developer developer, string[] programmingLanguage)
        {
            var programminglanguagesDb = context.ProgrammingLanguages.ToList();
            foreach (var programmingLanguageID in programmingLanguage)
            {
                developer.ProgrammingLanguages.Add(programminglanguagesDb.Where(p => p.ID.ToString() == programmingLanguageID).FirstOrDefault());

            }
        }

       

       

    }
}