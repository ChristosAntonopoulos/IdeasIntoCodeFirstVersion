using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class DeveloperNotificationRepository : IDeveloperNotificationRepository
    {
        private readonly ApplicationDbContext _context;
        public DeveloperNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Developer sender, Developer receiver)
        {
            _context.DeveloperNotifications.Add(new DeveloperNotification(receiver, new Notification(sender, NotificationType.Messaged)));
        }
    }
}