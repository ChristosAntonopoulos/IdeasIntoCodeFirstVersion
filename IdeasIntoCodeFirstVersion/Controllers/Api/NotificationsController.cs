using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Notification> GetNotifications(int ID)
        {
           
            var notifications = context.DeveloperNotifications
                .Where(un => un.Developer.ID == ID && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Developer)
                .Include(n => n.Project)
                .Include(n => n.Developer.User)
                .ToList();

            return notifications;
          
        }
    }
}
