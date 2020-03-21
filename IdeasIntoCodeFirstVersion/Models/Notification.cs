using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class Notification
    {
        public int ID { get; private set; }
        public DateTime TimeStamp { get;  set; }

        public NotificationType Type { get;  set; }

        public ICollection<DeveloperNotification> DeveloperNotifications { get; set; }

        public Developer Developer { get; set; }

        public Project Project { get; set; }
             

    }
}