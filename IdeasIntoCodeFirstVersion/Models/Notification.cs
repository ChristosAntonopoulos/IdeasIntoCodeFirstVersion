using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class Notification
    {
        public int ID { get; private set; }
        public DateTime TimeStamp { get;  private set; }

        public NotificationType Type { get; private set; }

        public ICollection<DeveloperNotification> DeveloperNotifications { get; private set; }

        public Developer Developer { get; private set; }

        public Project Project { get; private set; }

        protected Notification()
        {

        }

        public Notification(Developer developer,NotificationType notificationType)
        {
            if (developer == null)
                throw new ArgumentNullException("developer");
            TimeStamp = DateTime.Now;
            Developer = developer;
            Type = notificationType;
            DeveloperNotifications = new List<DeveloperNotification>();
        }

        public Notification(Developer developer, Project project, NotificationType notificationType)
        {
            if (developer == null)
                throw new ArgumentNullException("developer");

            if (project == null)
                throw new ArgumentNullException("project");
            TimeStamp = DateTime.Now;
            Developer = developer;
            Project = project;
            Type = notificationType;
            DeveloperNotifications = new List<DeveloperNotification>();
        }


    }
}