using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
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
        private readonly UnitOfWork unitOfWork;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public IEnumerable<Notification> GetNotifications(int ID)
        {
            var notifications = unitOfWork.DeveloperNotifications.GetNotificationsIncludeProjectDeveloperUser(ID);
            return notifications;
        }
    }
}
