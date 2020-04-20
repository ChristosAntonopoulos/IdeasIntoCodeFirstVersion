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


namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    public class ProgrammingLanguagesController : ApiController
    {

        private ApplicationDbContext context;
        public ProgrammingLanguagesController()
        {
            context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetProgrammingLanguages()
        {
            var programminglanguages = context.ProgrammingLanguages.ToList()
                .Select(Mapper.Map<ProgrammingLanguage, ProgrammingLanguageDto>);
            return Ok(programminglanguages);
        }
        //create new
      [HttpGet]
        public IHttpActionResult EditProgrammingLanguagesInProject()
        {
            var project = new ProjectWithProgrammingLanguagesViewModel()
            {
                ProgrammingLanguages = context.ProgrammingLanguages.ToList()
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

            Project project = context.Projects
                .SingleOrDefault(p => p.ID == id);
            //if (trainer == null)
            //{
            //    return HttpNotFound();
            //}
            var programmingLanguages = context.ProgrammingLanguages.ToList();


            var viewmodel = new ProjectWithProgrammingLanguagesViewModel()
            {
                ProgrammingLanguages = programmingLanguages,
                Project=project
            };

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
                context.Projects.Add(project);
            }
            else
            {
                var projectDb = context.Projects.Include(p=>p.ProgrammingLanguages).Single(p => p.ID == project.ID);
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
                        context.SaveChanges();
            return Ok(project);
        }

        public void UpdateProjectLanguage(Project project, string[] language)
        {
            foreach (var languagesdb in context.ProgrammingLanguages)
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
            var languagesDb = context.ProgrammingLanguages.ToList();
            //var trainerCourses = new HashSet<int>(trainer.Courses.Select(c => c.ID));
            foreach (var languageId in language)
            {
                project.ProgrammingLanguages.Add(languagesDb.Where(l=> l.ID.ToString() == languageId).FirstOrDefault());
            }
        }

    }
}
