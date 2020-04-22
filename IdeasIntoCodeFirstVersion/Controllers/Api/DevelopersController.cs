using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.IO;
using IdeasIntoCodeFirstVersion.Persistence;

namespace IdeasIntoCodeFirstVersion.Controllers.API
{
    public class DevelopersController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public DevelopersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    Byte[] b = File.ReadAllBytes(@"E:\Test.jpg");   // You can use your own method over here.
        //    return File(b, "image/jpeg");
        //}
        //GET/ API/developers
        public IHttpActionResult GetDevelopers()
        {
            var userId = User.Identity.GetUserId();
            var dev = unitOfWork.Developers.GetDeveloperIncludeUser(userId);
            return Ok(dev);
        }
    }
}
