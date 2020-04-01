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
using System.IO;

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


        //allagh
        private List<ProjectCategory> GetCategories()
        {
            var categories = context.ProjectCategories.ToList();
            return categories;
        }

        private List<ProgrammingLanguage> GetLanguages()
        {
            var languages = context.ProgrammingLanguages.ToList();
            return languages;
        }

        private List<Developer> GetDevelopersToUpdate(int devID)
        {
            var developersToUpdateNewsFeed = context.Follows
                    .Where(f => f.FolloweeID== devID)
                    .Select(f => f.Follower).ToList();
                    
                   
                   
                   
                    
            
            return developersToUpdateNewsFeed;
        }

        private int GetAdminId(string userID)
        {
            var AdminID = context.Developers.Where(d => d.User.Id == userID).SingleOrDefault().ID;
            return AdminID;
        }

        private Project GetProjectOnly(int? id)
        {
            var project = context.Projects.Find(id);
            return project;
        }

        private Project GetProject(int ID)
        {
            var project = context.Projects              
              .Include(p => p.Team.TeamMembers.Select(t=>t.User))
              .Include(p => p.Admin)
              .Include(p=>p.Admin.User)
              .Include(p => p.ProgrammingLanguages)
              .Include(p => p.ProjectCategories)
              .Include(p => p.Comments.Select(c=>c.Developer).Select(c=>c.User)).Single(p => p.ID == ID);
            return project;
        }

        public ActionResult MyProject()
        {
            var userId = User.Identity.GetUserId();
            var developer = context.Developers.Include(d => d.ProjectsOwned)
           .Include(d => d.TeamParicipating.Select(t => t.Project)).SingleOrDefault(d => d.UserID == userId);
            
          
            return View(developer);
        }
        // GET: Project
        public ActionResult ProjectProfile(int ID)
        {
            var userId = User.Identity.GetUserId();
            var developer =context.Developers.Where(d => d.User.Id == userId).Include(d=>d.User).SingleOrDefault();
           
            var project = GetProject(ID);
            
            var viewModel=new ProjectViewModel(developer, project);
            
            if (developer.ID!=project.AdminID)
            {
                viewModel.IsActive();
            }

            project.ModifyInActive(developer, viewModel);
           
            return View(viewModel);
        }

       

        [Authorize]
        public ActionResult New()
        {
            var userID = User.Identity.GetUserId();
            var viewModel = new ProjectFormViewModel(new Project(GetAdminId(userID)));

            return View("ProjectForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Save(Project project,int[] programmingLanguage,string[] category)
        {

            if (!ModelState.IsValid)
            {
                PopulateProjectProgrammingLanguages(project, programmingLanguage);
                PopulateProejectCategories(project, category);
                
                var viewModel = new ProjectFormViewModel(project);

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
                var userId = User.Identity.GetUserId();
                var currentDev = context.Developers.Where(d => d.User.Id == userId).Include(d => d.User).FirstOrDefault();
                var path = Server.MapPath("/Content/Images/homepage.jpg");
                
                var pic = base.File(path, "image/jpg");

                newsFeedHub.SendNotification(GetDevelopersToUpdate(project.AdminID), project,currentDev, pic);

            }
            else
            {
                
                if (programmingLanguage != null)
                {
                    if (GetProject(project.ID).ProgrammingLanguages.Count() == 0)
                    {
                        PopulateProjectProgrammingLanguages(GetProject(project.ID), programmingLanguage);
                    }
                    else
                    {
                        UpdateProjectProgrammingLanguages(GetProject(project.ID), programmingLanguage);
                    }
                    if (GetProject(project.ID).ProjectCategories.Count() == 0)
                    {
                        PopulateProejectCategories(GetProject(project.ID), category);
                    }
                    else
                    {
                        UpdateProjectCategories(GetProject(project.ID), category);
                    }


                }
                GetProject(project.ID).Description = project.Description;
                GetProject(project.ID).Title = project.Title;

               
            }

            context.SaveChanges();

            return View("ProjectProfile",project);
        }

        //allagh
           
        private void UpdateProjectProgrammingLanguages(Project project, int[] programmingLanguage)
        {

            foreach (var language in GetLanguages())
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
            foreach (var categoryDB in GetCategories())
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
            foreach (var categoryID in category)
            {
                project.ProjectCategories.Add(GetCategories().Where(p => p.ID.ToString() == categoryID).FirstOrDefault());

            }
        }

        private void PopulateProjectProgrammingLanguages(Project project, int[] programmingLanguage)
        {
            foreach (var programmingLanguageID in programmingLanguage)
            {
                project.ProgrammingLanguages.Add(GetLanguages().Where(p => p.ID == programmingLanguageID).FirstOrDefault());

            }
        }
      
        [Authorize]
        public ActionResult Edit(int ID)
        {
            
            var project = GetProjectOnly(ID);
            if (project == null)
                return HttpNotFound();
            //allagh
            var viewModel = new ProjectFormViewModel(project, GetCategories(), GetLanguages());
          


            return View("ViewerForm", viewModel);
        }

        //// GET: Instructor/Delete/5
        //[Authorize]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var project = GetProjectOnly(id);

        //    if (project == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(project);
        //}

        //// POST: Instructor/Delete/5
        //[Authorize]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var project = GetProjectOnly(id);
        //    context.Projects.Remove(project);
        //    context.SaveChanges();
        //    return RedirectToAction("ProjectProfile");
        //}

    }
}