using System.Collections.Generic;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IDeveloperNotificationRepository
    {
        void Add(Developer sender, Developer receiver);
        void Add(Project project, Developer developer);
        void Add(Developer developer, int followeeID);
        List<Notification> GetNotificationsIncludeProjectDeveloperUser(int ID);
    }
}