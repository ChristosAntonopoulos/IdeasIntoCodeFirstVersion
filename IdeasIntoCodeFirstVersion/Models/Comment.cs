using IdeasIntoCodeFirstVersion.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class Comment:INewsFeed
    {
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        [Required]
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
        [Required]
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public Comment()
        {
                
        }

        public Comment(string commentText, int projectId, int developerId)
        {
            Text = commentText;
            ProjectID = projectId;
            DeveloperID = developerId;
            TimeStamp = DateTime.Now;
        }
    }

}