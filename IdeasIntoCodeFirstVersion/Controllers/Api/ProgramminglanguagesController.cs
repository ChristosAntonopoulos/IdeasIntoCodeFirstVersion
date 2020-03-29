using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    public class ProgrammingLanguagesController : ApiController
    {

        private ApplicationDbContext context;
        public ProgrammingLanguagesController()
        {
            context = new ApplicationDbContext();
        }

        public IHttpActionResult GetProgrammingLanguages()
        {
            return Ok(context.ProgrammingLanguages.ToList().Select(Mapper.Map<ProgrammingLanguage, ProgrammingLanguageDto>));
        }
    }
}
