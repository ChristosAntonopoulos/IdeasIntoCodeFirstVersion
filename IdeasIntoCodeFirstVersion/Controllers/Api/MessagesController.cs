using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    public class MessagesController : ApiController
    {
        private ApplicationDbContext context;

        public MessagesController()
        {
            context = new ApplicationDbContext();
        }

        [HttpGet]
       public IHttpActionResult Messages(int id)
        {
             var messages = context.Messages.Where(m => m.ReceiverID == id);
            return Ok(messages);
        }
    }
}
