using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.ViewModels;
using System.Net;

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
            var project = context.Projects.Include(p => p.Team.TeamMembers)
                .Include(p=>p.Admin)
                .Include(p=>p.ProgrammingLanguages)
                .Include(p=>p.ProjectCategories).Single(p=>p.ID==ID);
            
            return View(project);
        }

        public ActionResult New(int ID)
        {
            
            var viewModel = new ProjectFormViewModel()
            {
                ProgrammingLanguages = context.ProgrammingLanguages.ToList(),
                ProjectCategories = context.ProjectCategories.ToList(),
                Project=new Project { AdminID=ID}

            };

            return View("ProjectForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Project project,int[] programmingLanguage)
        {
            var programmingLanguages = new List<ProgrammingLanguage>();
            var categories = new List<ProjectCategory>();

            foreach (var languageID in programmingLanguage)
            {
                programmingLanguages.Add(context.ProgrammingLanguages.Find(languageID));

            }
            //foreach (var categoryID in selectedCategories)
            //{
            //    categories.Add(context.ProjectCategories.Find(categoryID));
            //}

            project.ProgrammingLanguages = programmingLanguages;

            project.ProjectCategories = categories;

            if (!ModelState.IsValid)
            {
                var viewModel = new ProjectFormViewModel
                {
                    ProgrammingLanguages = programmingLanguages,
                    Project = project,
                    ProjectCategories =categories
                };

                return View("ProjectForm", viewModel);

            }
           

            if (project.ID == 0)
            {
                project.DateCreated = DateTime.Now;
                context.Projects.Add(project);

            }
            else
            {
                var projectDB = context.Projects.Single(p => p.ID == project.ID);
                projectDB.Title = project.Title;
                projectDB.Description = project.Description;
                
                
            }

            context.SaveChanges();

            return View("Profile", project.ID);
        }

        public ActionResult Edit(int ID)
        {
            var project = context.Projects.SingleOrDefault(p => p.ID == ID);

            if (project == null)
                return HttpNotFound();

            var programmingLanguages = context.ProgrammingLanguages.ToList();

            var projectCategories = context.ProjectCategories.ToList();


            var viewModel = new ProjectFormViewModel()
            {
                ProgrammingLanguages = programmingLanguages,
                ProjectCategories = projectCategories,
                Project = project

            };


            return View("ViewerForm", viewModel);
        }

        // GET: Instructor/Delete/5
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