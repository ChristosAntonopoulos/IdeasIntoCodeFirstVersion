using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            var categoriesDb = context.ProjectCategories.ToList();
            var categories = categoriesDb.Select(Mapper.Map<ProjectCategory, ProjectCategoryDto>);
            return Ok(categories);
        }
    }
}
