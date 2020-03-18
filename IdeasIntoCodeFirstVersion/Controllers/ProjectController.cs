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

            var project = context.Projects.Include(p => p.Team.TeamMembers)
                .Include(p=>p.Admin)
                .Include(p=>p.ProgrammingLanguages)
                .Include(p=>p.ProjectCategories)
                .Include(p=>p.Comments).Single(p=>p.ID==ID);      

            var viewModel = new ProjectViewModel()
            {
                Project = project,
                 Developer = developer
            };

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

        [Authorize]
        public ActionResult New()
        {
            var userID = User.Identity.GetUserId();
            var viewModel = new ProjectFormViewModel()
            {
                //ProgrammingLanguages = context.ProgrammingLanguages.ToList(),
                //ProjectCategories = context.ProjectCategories.ToList(),
                
                
                Project=new Project { AdminID=context.Developers.Where(d=>d.User.Id== userID).SingleOrDefault().ID }

            };

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
                var viewModel = new ProjectFormViewModel
                {
                    //ProgrammingLanguages = context.ProgrammingLanguages.ToList(),
                    Project = project

                };

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


            }
            else
            {

                var projectDB = context.Projects.Include(p => p.ProgrammingLanguages).Include(p=>p.ProjectCategories).Single(u => u.ID == project.ID);
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


            var viewModel = new ProjectFormViewModel()
            {
                ProgrammingLanguages = programmingLanguages,
                ProjectCategories = projectCategories,
                Project = project

            };


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