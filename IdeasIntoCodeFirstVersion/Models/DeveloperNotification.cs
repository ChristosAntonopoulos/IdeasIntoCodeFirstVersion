using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class DeveloperNotification
    {
        [Key]
        [Column(Order = 1)]
        public int DeveloperID { get; private set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }

        public Developer Developer { get; private set; }
        public Notification Notification { get; private set; }
        public bool IsRead { get; set; }

        public DeveloperNotification()
        {

        }

        public DeveloperNotification(Developer developer, Notification notification)
        {
            if (developer == null)
                throw new ArgumentNullException("user");

            if (notification == null)
                throw new ArgumentNullException("notification");

            Developer = developer;
            Notification = notification;
        }

        public DeveloperNotification(int developerId, Notification notification)
        {
           

            if (notification == null)
                throw new ArgumentNullException("notification");

            DeveloperID = developerId;
            Notification = notification;
        }

    }
}