using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext context;
        public CommentController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // Post: Comment
        [HttpPost]
        public void AddComment(int currentProjectID, string commentText)
        {
            var userId = User.Identity.GetUserId();
            var developer = context.Developers.Single(d => d.User.Id == userId);
            var comment = new Comment()
            {
                Text = commentText,
                ProjectID = currentProjectID,
                DeveloperID = developer.ID,
                TimeStamp = DateTime.Now
            };
            context.Comments.Add(comment);
            context.SaveChanges();

        }
    }
}