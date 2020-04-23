using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    public class CommentsController : ApiController
    {
        
        private IUnitOfWork unitOfWork;
        public CommentsController(IUnitOfWork unitOfWork)
        {
            
            this.unitOfWork = unitOfWork;
        }

        // Post: Comment
        [HttpPost]
        public void AddComment(int currentProjectID, string commentText, int ID)
        {
            //var userId = User.Identity.GetUserId();
            var developer = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(ID);
            var comment = new Comment(commentText, developer, currentProjectID);
            unitOfWork.Comments.Add(comment);
            unitOfWork.Complete();
        }
    }
}
