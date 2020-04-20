using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    public class CategoriesController : ApiController
    {

        private ApplicationDbContext context;
        public CategoriesController()
        {
            context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCategories()
        {
            var categories = context.ProjectCategories.ToList()
                .Select(Mapper.Map<ProjectCategory, ProjectCategoryDto>);
            return Ok(categories);
        }

        [HttpGet]
        public IHttpActionResult EditCategoriesInProject()
        {
            var project = new ProjectWithCategoriesViewModel()
            {
                ProjectCategories = context.ProjectCategories.ToList()
            };
            return Ok(project);
        }

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
            var categories = context.ProjectCategories.ToList();


            var viewmodel = new ProjectWithCategoriesViewModel()
            {
                ProjectCategories = categories,
                Project = project
            };

            return Ok(viewmodel);
        }

        [HttpPost]
        public IHttpActionResult Save(Project project, string[] category)
        {


            if (project.ID == 0)
            {
                if (category != null)
                {
                    PopulateProjectCategory(project, category);
                }
                context.Projects.Add(project);
            }
            else
            {
                var projectDb = context.Projects.Include(p => p.ProjectCategories).Single(p => p.ID == project.ID);
                if (category != null)
                {
                    if (projectDb.ProjectCategories.Count() == 0)
                    {
                        PopulateProjectCategory(projectDb, category);
                    }
                    else
                    {
                        UpdateProjectCategory(projectDb, category);
                    }
                }


            }
            context.SaveChanges();
            return Ok(project);
        }

        public void UpdateProjectCategory(Project project, string[] category)
        {
            foreach (var categoriesdb in context.ProjectCategories)
            {
                if (category.Contains(categoriesdb.ID.ToString()))
                {
                    if (!project.ProjectCategories.Contains(categoriesdb))
                    {
                        project.ProjectCategories.Add(categoriesdb);
                    }
                }
                else
                {
                    if (project.ProjectCategories.Contains(categoriesdb))
                    {
                        project.ProjectCategories.Remove(categoriesdb);
                    }
                }
            }
        }

        public void PopulateProjectCategory(Project project, string[] category)
        {
            var categoriesDb = context.ProjectCategories.ToList();
            //var trainerCourses = new HashSet<int>(trainer.Courses.Select(c => c.ID));
            foreach (var categoryId in category)
            {
                project.ProjectCategories.Add(categoriesDb.Where(l => l.ID.ToString() == categoryId).FirstOrDefault());
            }
        }
    }
}
