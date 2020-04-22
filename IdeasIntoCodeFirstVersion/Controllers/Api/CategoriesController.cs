using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
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
        private readonly IUnitOfWork unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetCategories()
        {
            return Ok(unitOfWork.Categories.GetCategoriesAsDtos());
        }
    }
}
