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
using IdeasIntoCodeFirstVersion.Persistence;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class ProjectController : Controller
    {
        private IUnitOfWork unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult MyProject()
        {
            var userId = User.Identity.GetUserId();
            var developer = unitOfWork.Developers.GetDeveloperIncludeProject(userId);
          
            return View(developer);
        }
        // GET: Project
        public ActionResult ProjectProfile(int ID)
        {
            var userId = User.Identity.GetUserId();
            var developer = unitOfWork.Developers.GetDeveloperIncludeUser(userId);
            var project =unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(ID);
            
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
            var viewModel = new ProjectFormViewModel(new Project(unitOfWork.Developers.GetAdminId(userID)));

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

                unitOfWork.Projects.Add(project);
                var newsFeedHub = new NewsFeedTickerHub();
                var userId = User.Identity.GetUserId();
                var currentDev = unitOfWork.Developers.GetDeveloperWithFirstOrDefault(userId);
                var path = Server.MapPath("/Content/Images/homepage.jpg");
                
                var pic = base.File(path, "image/jpg");

                newsFeedHub.SendNotification(unitOfWork.Developers.GetDevelopersToUpdate(project.AdminID), project,currentDev, pic);

            }
            else
            {
                
                if (programmingLanguage != null)
                {
                    if (unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(project.ID).ProgrammingLanguages.Count() == 0)
                    {
                        PopulateProjectProgrammingLanguages(unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(project.ID), programmingLanguage);
                    }
                    else
                    {
                        UpdateProjectProgrammingLanguages(unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(project.ID), programmingLanguage);
                    }
                    if (unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(project.ID).ProjectCategories.Count() == 0)
                    {
                        PopulateProejectCategories(unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(project.ID), category);
                    }
                    else
                    {
                        UpdateProjectCategories(unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(project.ID), category);
                    }


                }
                unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(project.ID).Description = project.Description;
                unitOfWork.Projects.GetProjectWithProgrammingLanguagesAndCategories(project.ID).Title = project.Title;

               
            }

            unitOfWork.Complete();

            return View("ProjectProfile",project);
        }

        //allagh
           
        private void UpdateProjectProgrammingLanguages(Project project, int[] programmingLanguage)
        {

            foreach (var language in unitOfWork.ProgrammingLanguages.GetLanguages())
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
            foreach (var categoryDB in unitOfWork.Categories.GetCategories())
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
                project.ProjectCategories.Add(unitOfWork.Categories.GetCategories().Where(p => p.ID.ToString() == categoryID).FirstOrDefault());

            }
        }

        private void PopulateProjectProgrammingLanguages(Project project, int[] programmingLanguage)
        {
            foreach (var programmingLanguageID in programmingLanguage)
            {
                project.ProgrammingLanguages.Add(unitOfWork.ProgrammingLanguages.GetLanguages().Where(p => p.ID == programmingLanguageID).FirstOrDefault());

            }
        }
      
        [Authorize]
        public ActionResult Edit(int ID)
        {
            
            var project =unitOfWork.Projects.FindProject(ID);

            if (project == null)
                return HttpNotFound();
            //allagh
            var viewModel = new ProjectFormViewModel(project,unitOfWork.Categories.GetCategories(),unitOfWork.ProgrammingLanguages.GetLanguages());
 
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
            var project =unitOfWork.Projects.FindProject(id);

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
            var project = unitOfWork.Projects.FindProject(id);
            unitOfWork.Projects.Remove(project);
            unitOfWork.Complete();
            return RedirectToAction("ProjectProfile");
        }

    }
}