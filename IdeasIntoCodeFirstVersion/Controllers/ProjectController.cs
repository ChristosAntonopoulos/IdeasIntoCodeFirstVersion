using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.ViewModels;
using System.Net;
using Microsoft.AspNet.Identity;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class ProjectController : Controller
    {

        private ApplicationDbContext context;
        public ProjectController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Project
      

        public ActionResult ProjectProfile(int ID)
        {
            var userId = User.Identity.GetUserId();
            var developer =context.Developers.Where(d => d.User.Id == userId).SingleOrDefault();
            //allagh
            var project = GetProject(ID);
            
            //allagh
            var viewModel=new ProjectViewModel(developer, project);
            

            if (developer.ID!=project.AdminID)
            {
                viewModel.Action = true;
            }
            foreach (var member in project.Team.TeamMembers)
            {
                if(member.ID==developer.ID && developer.ID != project.AdminID)
                {
                    viewModel.Action = false;
                }
            }

            return View(viewModel);
        }

        //allagh
        private Project GetProject(int ID)
        {
            var project = context.Projects.Include(p => p.Team.TeamMembers)
              .Include(p => p.Admin)
              .Include(p => p.ProgrammingLanguages)
              .Include(p => p.ProjectCategories)
              .Include(p => p.Comments).Single(p => p.ID == ID);
            return project;
        }

        [Authorize]
        public ActionResult New()
        {
            var userID = User.Identity.GetUserId();
            var viewModel = new ProjectFormViewModel(new Project(GetAdminId(userID)));
            //{
            //    //ProgrammingLanguages = context.ProgrammingLanguages.ToList(),
            //    //ProjectCategories = context.ProjectCategories.ToList(),

            //    Project = new Project(GetAdminId(userID))
            //    //Project=new Project { AdminID=GetAdminId(userID) }

            //};

            return View("ProjectForm", viewModel);
        }

        private int GetAdminId(string userID)
        {
            var AdminID = context.Developers.Where(d => d.User.Id == userID).SingleOrDefault().ID;
            return AdminID;
        }

        [Authorize]
        [HttpPost]
        public ActionResult Save(Project project,int[] programmingLanguage,string[] category)
        {

            if (!ModelState.IsValid)
            {
                PopulateProjectProgrammingLanguages(project, programmingLanguage);
                PopulateProejectCategories(project, category);
                //allagh
                var viewModel = new ProjectFormViewModel(project);
                //{
                //    //ProgrammingLanguages = context.ProgrammingLanguages.ToList(),
                //    Project = project

                //};

                return View("ProjectForm", viewModel);

            }
            
            if (project.ID == 0)
            {
                if (programmingLanguage != null)
                {
                    PopulateProjectProgrammingLanguages(project, programmingLanguage);
                    PopulateProejectCategories(project, category);
                }

                project.TimeStamp = DateTime.Now;

                context.Projects.Add(project);
                var newsFeedHub = new NewsFeedTickerHub();

                var userID = User.Identity.GetUserId();

                //var applicationUsersToUpdateNewsFeed = GetUsersToUpdate(userID);
                //allagh
                newsFeedHub.SendNotification(GetUsersToUpdate(userID), project);





            }
            else
            {
                //factory pattern???
                //var projectDB = context.Projects.Include(p => p.ProgrammingLanguages).Include(p=>p.ProjectCategories).Single(u => u.ID == project.ID);
                var projectDB = GetProject(project.ID);
                if (programmingLanguage != null)
                {
                    if (projectDB.ProgrammingLanguages.Count() == 0)
                    {
                        PopulateProjectProgrammingLanguages(projectDB, programmingLanguage);
                    }
                    else
                    {
                        UpdateProjectProgrammingLanguages(projectDB, programmingLanguage);
                    }
                    if (projectDB.ProjectCategories.Count() == 0)
                    {
                        PopulateProejectCategories(projectDB, category);
                    }
                    else
                    {
                        UpdateProjectCategories(projectDB, category);
                    }


                }
                projectDB.Description = project.Description;
                projectDB.Title = project.Title;

               
            }

            context.SaveChanges();

            return View("ProjectProfile",project);
        }

        //allagh
        private List<ApplicationUser> GetUsersToUpdate(string userID)
        {
            var applicationUsersToUpdateNewsFeed=context.Developers
                    .Where(d => d.Followers.Select(f => f.Followee == context.Developers
                    .Where(dev => dev.User.Id == userID).FirstOrDefault()).FirstOrDefault())
                    .Select(developer => developer.User).ToList();
            return applicationUsersToUpdateNewsFeed;
        }        
        private void UpdateProjectProgrammingLanguages(Project project, int[] programmingLanguage)
        {

            foreach (var language in context.ProgrammingLanguages)
            {
                if (programmingLanguage.Contains(language.ID))
                {
                    if (!project.ProgrammingLanguages.Contains(language))
                    {
                        project.ProgrammingLanguages.Add(language);


                    }
                }
                else
                {
                    if (project.ProgrammingLanguages.Contains(language))
                    {
                        project.ProgrammingLanguages.Remove(language);
                    }
                }
            }           
        }

        private void UpdateProjectCategories(Project project, string[] category)
        {
            foreach (var categoryDB in context.ProjectCategories)
            {
                if (category.Contains(categoryDB.ID.ToString()))
                {
                    if (!project.ProjectCategories.Contains(categoryDB))
                    {
                        project.ProjectCategories.Add(categoryDB);


                    }
                }
                else
                {
                    if (project.ProjectCategories.Contains(categoryDB))
                    {
                        project.ProjectCategories.Remove(categoryDB);
                    }
                }


            }
        }

        private void PopulateProejectCategories(Project project, string[] category)
        {

            var categoriesDB = context.ProjectCategories.ToList();
            foreach (var categoryID in category)
            {
                project.ProjectCategories.Add(categoriesDB.Where(p => p.ID.ToString() == categoryID).FirstOrDefault());

            }
        }

        private void PopulateProjectProgrammingLanguages(Project project, int[] programmingLanguage)
        {

            var programminglanguagesDb = context.ProgrammingLanguages.ToList();
            foreach (var programmingLanguageID in programmingLanguage)
            {
                project.ProgrammingLanguages.Add(programminglanguagesDb.Where(p => p.ID == programmingLanguageID).FirstOrDefault());

            }
        }

        [Authorize]
        public ActionResult Edit(int ID)
        {
            var project = context.Projects.SingleOrDefault(p => p.ID == ID);

            if (project == null)
                return HttpNotFound();

            var programmingLanguages = context.ProgrammingLanguages.ToList();

            var projectCategories = context.ProjectCategories.ToList();

            //allagh
            var viewModel = new ProjectFormViewModel(project, projectCategories, programmingLanguages);
          


            return View("ViewerForm", viewModel);
        }

        // GET: Instructor/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = context.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Instructor/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var project = context.Projects.Find(id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("ProjectProfile");
        }

    }
}