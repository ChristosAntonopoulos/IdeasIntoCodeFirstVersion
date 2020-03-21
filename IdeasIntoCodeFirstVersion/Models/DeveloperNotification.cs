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
        public int DeveloperID { get;  set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get;  set; }

        public Developer Developer { get;  set; }
        public Notification Notification { get;  set; }
        public bool IsRead { get; set; }

        public DeveloperNotification()
        {

        }

        //public DeveloperNotification(Developer developer, Notification notification)
        //{
        //    if (developer == null)
        //        throw new ArgumentNullException("user");

        //    if (notification == null)
        //        throw new ArgumentNullException("notification");

        //    Developer = developer;
        //    Notification = notification;
        //}

    }
}