﻿using System;
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
                .Include(p => p.Comments.Select(c => c.Developer))
                .Include(p=>p.ProjectCategories).Single(p=>p.ID==ID);
            
            return View(project);
        }

        public ActionResult New(int ID)
        {
            
            var viewModel = new ProjectFormViewModel()
            {
                //ProgrammingLanguages = context.ProgrammingLanguages.ToList(),
                //ProjectCategories = context.ProjectCategories.ToList(),
                Project=new Project { AdminID=ID}

            };

            return View("ProjectForm", viewModel);
        }


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

                project.DateCreated = DateTime.Now;

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

                //DeveloperDB.Name = project.Name;
                //DeveloperDB.LastName = developer.LastName;
                //DeveloperDB.GitHub = developer.GitHub;
                //DeveloperDB.Email = developer.Email;
                //DeveloperDB.BirthDate = developer.BirthDate;
            }

            context.SaveChanges();

            return View("ProjectProfile",project);
        }
           
        //    if (!ModelState.IsValid)
        //    {
        //        var viewModel = new ProjectFormViewModel
        //        {
        //            //ProgrammingLanguages = programmingLanguages,
                    
        //            //ProjectCategories =categories,
        //            Project = project
        //        };

        //        return View("ProjectForm", viewModel);

        //    }
           

        //    if (project.ID == 0)
        //    {
        //        project.DateCreated = DateTime.Now;
        //        context.Projects.Add(project);

        //    }
        //    else
        //    {
        //        var projectDB = context.Projects.Single(p => p.ID == project.ID);
        //        projectDB.Title = project.Title;
        //        projectDB.Description = project.Description;
                
                
        //    }

        //    context.SaveChanges();

        //    return View("Profile", project.ID);
        //}

        public void UpdateProjectProgrammingLanguages(Project project, int[] programmingLanguage)
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

        public void UpdateProjectCategories(Project project, string[] category)
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

        public void PopulateProejectCategories(Project project, string[] category)
        {

            var categoriesDB = context.ProjectCategories.ToList();
            foreach (var categoryID in category)
            {
                project.ProjectCategories.Add(categoriesDB.Where(p => p.ID.ToString() == categoryID).FirstOrDefault());

            }
        }

        public void PopulateProjectProgrammingLanguages(Project project, int[] programmingLanguage)
        {

            var programminglanguagesDb = context.ProgrammingLanguages.ToList();
            foreach (var programmingLanguageID in programmingLanguage)
            {
                project.ProgrammingLanguages.Add(programminglanguagesDb.Where(p => p.ID == programmingLanguageID).FirstOrDefault());

            }
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