﻿using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;

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


        public ActionResult DeveloperProfile(int ID)
        {
            var userId = User.Identity.GetUserId();

            Developer connectedDeveloper = null;//Αυτη η γραμμη μαζι με την if που την συνοδευει 
            if (userId != null)                //χρειαστηκε επειδη αυτην τη στιγμη στην βαση μου υπαρχουν παραπανω απο ενας Developers χωρις να εχουν User 
                connectedDeveloper = context.Developers.SingleOrDefault(d => d.User.Id == userId);
            var developer = context.Developers
                .Include(u => u.ProgrammingLanguages)
                .Include(d=>d.ProjectsOwned)
                .Include(d => d.Followers)
                .Include(d => d.User)
                .SingleOrDefault(u => u.ID == ID);
            var viewModel = new DeveloperProfileViewModel
            {
                DeveloperOfProfile = developer,
                NegativeToShowActionButtons = true,
                ConnectedDeveloperAlreadyFollowsProfileDeveloper = false
            };
            if (connectedDeveloper != null)
            {
                if (developer.ID != connectedDeveloper.ID)
                    viewModel.NegativeToShowActionButtons = false;
                
                var testFollow = new Follow() { FollowerID = connectedDeveloper.ID, FolloweeID = developer.ID };
                if (developer.Followers.Contains(developer.Followers.SingleOrDefault(f => f.FollowerID == connectedDeveloper.ID)))
                    viewModel.ConnectedDeveloperAlreadyFollowsProfileDeveloper = true;
            }
            return View(viewModel);
        }



        // Developer/new
        [Authorize]
        public ActionResult New()
        { 

            return View("DeveloperForm");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Developer developer, string[] programmingLanguage)
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

            if (developer.ID == 0)
            {
                if (programmingLanguage!=null)
                {
                    PopulateDeveloperProgrammingLanguages(developer, programmingLanguage);
                }

               
                developer.User = context.Users.Single(u => u.Id == userID);
                developer.DateCreated = DateTime.Now;
                

                context.Developers.Add(developer);


            }
            else
            {
               
                var DeveloperDB = context.Developers.Include(d=>d.ProgrammingLanguages).Single(u => u.ID == developer.ID);
                if (programmingLanguage != null)
                {
                    if (DeveloperDB.ProgrammingLanguages.Count()==0)
                    {
                        PopulateDeveloperProgrammingLanguages(DeveloperDB, programmingLanguage);
                    }
                    else
                    {
                        UpdateDeveloperProgrammingLanguages(DeveloperDB, programmingLanguage);
                    }
                    
                }
                DeveloperDB.Name = developer.Name;
                DeveloperDB.LastName = developer.LastName;
                DeveloperDB.GitHub = developer.GitHub;
                DeveloperDB.Email = developer.Email;
                DeveloperDB.BirthDate = developer.BirthDate;
            }

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

        [Authorize]
        public ActionResult Edit()
        {
            var currentUserID = User.Identity.GetUserId();
            var Developer = context.Developers.Include(d=>d.ProgrammingLanguages).SingleOrDefault(p => p.User.Id== currentUserID);

            if (Developer == null)
                return HttpNotFound();


            var viewModel = new DeveloperFormViewModel()
            {
              
                Developer = Developer

            };

            return View("DeveloperForm", viewModel);
        }

        // GET: Instructor/Delete/5
        //[Authorize]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var developer = context.Developers.Find(id);

        //    if (developer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(developer);
        //}

        //// POST: Instructor/Delete/5
        //[Authorize]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var developer = context.Developers.Find(id);
        //    context.Developers.Remove(developer);
        //    context.SaveChanges();
        //    return RedirectToAction("Index","Home");
        //}

    }
}