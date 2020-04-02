using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
        }

        public IEnumerable<Notification> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.DeveloperNotifications
                .Where(un => un.Developer.User.Id == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Developer)
                .Include(n => n.Project)
                .Include(n => n.Developer.User)
                .ToList();

            return notifications;
          
        }
    }
}
