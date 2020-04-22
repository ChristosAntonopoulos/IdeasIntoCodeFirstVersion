using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class DeveloperNotificationRepository
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

        public List<Notification> GetNotificationsIncludeProjectDeveloperUser(int ID)
        {
            return _context.DeveloperNotifications
                .Where(un => un.Developer.ID == ID && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Developer)
                .Include(n => n.Project)
                .Include(n => n.Developer.User)
                .ToList();
        }
    }
}