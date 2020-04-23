using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.ViewModels;
using System.Data.Entity;
using IdeasIntoCodeFirstVersion.Persistence;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    public class ProgrammingLanguagesController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;
        public ProgrammingLanguagesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult GetProgrammingLanguages()
        {
            var programminglanguages = unitOfWork.ProgrammingLanguages.GetProgrammingLanguageDtos();
            return Ok(programminglanguages);
        }
        //create new
      [HttpGet]
        public IHttpActionResult EditProgrammingLanguagesInProject()
        {
            var project = new ProjectWithProgrammingLanguagesViewModel()
            {
                ProgrammingLanguages = unitOfWork.ProgrammingLanguages.GetLanguages()
            };
            return Ok(project);
        }

        //edit
        [HttpGet]
        public IHttpActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Ok();
            }

            Project project = unitOfWork.Projects.GetProject(id);
            //if (trainer == null)
            //{
            //    return HttpNotFound();
            //}
            var programmingLanguages = unitOfWork.ProgrammingLanguages.GetLanguages();
            var viewmodel = new ProjectWithProgrammingLanguagesViewModel(project, programmingLanguages);
            return Ok( viewmodel);
        }

        [HttpPost]
        public IHttpActionResult Save(Project project, string[] language)
        {
            if (project.ID == 0)
            {
                if (language != null)
                {
                    PopulateProjectLanguage(project, language);
                }
                unitOfWork.Projects.Add(project);
            }
            else
            {
                var projectDb = unitOfWork.Projects.GetProjectIncludeProgrammingLanguages(project.ID);
                if (language != null)
                {
                    if (projectDb.ProgrammingLanguages.Count() == 0)
                    {
                        PopulateProjectLanguage(projectDb, language);
                    }
                    else
                    {
                        UpdateProjectLanguage(projectDb, language);
                    }
                }
               

            }
                        unitOfWork.Complete();
            return Ok(project);
        }

        public void UpdateProjectLanguage(Project project, string[] language)
        {
            foreach (var languagesdb in unitOfWork.ProgrammingLanguages.GetLanguages())
            {
                if (language.Contains(languagesdb.ID.ToString()))
                {
                    if (!project.ProgrammingLanguages.Contains(languagesdb))
                    {
                        project.ProgrammingLanguages.Add(languagesdb);
                    }
                }
                else
                {
                    if (project.ProgrammingLanguages.Contains(languagesdb))
                    {
                        project.ProgrammingLanguages.Remove(languagesdb);
                    }
                }
            }
        }

        public void PopulateProjectLanguage(Project project, string[] language)
        {
            var languagesDb = unitOfWork.ProgrammingLanguages.GetLanguages();
            //var trainerCourses = new HashSet<int>(trainer.Courses.Select(c => c.ID));
            foreach (var languageId in language)
            {
                project.ProgrammingLanguages.Add(languagesDb.Where(l=> l.ID.ToString() == languageId).FirstOrDefault());
            }
        }

    }
}
