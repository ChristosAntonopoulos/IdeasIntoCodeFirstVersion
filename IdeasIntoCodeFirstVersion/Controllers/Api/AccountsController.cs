using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    public class AccountsController : ApiController
    {
        private ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;
        public AccountsController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public IHttpActionResult Login(LoginViewModel model)
        {
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


    }
}