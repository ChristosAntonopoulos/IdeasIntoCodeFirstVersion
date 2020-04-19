﻿using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
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
        
        private readonly IUnitOfWork unitOfWork;
        public CommentController(IUnitOfWork unitOfWork)
        {
           
            this.unitOfWork = unitOfWork;
        }
       
        // Post: Comment
        [HttpPost]
        public void AddComment(int currentProjectID, string commentText)
        {
            var userId = User.Identity.GetUserId();
            var developer = unitOfWork.Developers.GetDeveloperIncludeUser(userId);
            var comment = new Comment(commentText, currentProjectID, developer.ID);
           
            unitOfWork.Comments.Add(comment);
            unitOfWork.Complete();
        }
    }
}