using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
using IdeasIntoCodeFirstVersion.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IdeasIntoCodeFirstVersion.Controllers.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessagesController : ApiController
    {
        private ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;

        public MessagesController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
       public IHttpActionResult Messages(int id)
        {
             var messages = unitOfWork.Messages.GetMessagesReceived(id);
            return Ok(messages);
        }
        [HttpPost]
        public void MarkAsRead(int messageID)
        {
            var message = unitOfWork.Messages.GetMessage(messageID);
            Message.MarkAsRead(message);
            unitOfWork.Complete();
        }

        [HttpGet]
        public IHttpActionResult AllReceivedMessages(int ID)
        {
            var user = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(ID);
            var messages = GetMessagesViewModel.GetMessagesReceivedOrSend("Received", unitOfWork, user.ID);
            return Ok(messages);
        }
        [HttpGet]
        public IHttpActionResult GetSendMessages(int ID)
        {
            //var userId = User.Identity.GetUserId();
            var user = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(ID);
            var messages = GetMessagesViewModel.GetMessagesReceivedOrSend("Send", unitOfWork, user.ID);
            return Ok(messages);
        }
        //public IHttpActionResult GetMessages(string whatMessagesToGet, int developerID)
        //{
        //    //var userId = User.Identity.GetUserId();
        //    var user = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(developerID);
        //    var messages = GetMessagesViewModel.GetMessagesReceivedOrSend(whatMessagesToGet, unitOfWork, user.ID);
        //    return Ok(messages);
        //}

        // GET: Message
        [HttpGet]
        [Route("api/messages/sendMessage/{id},{currentId}")]
        public IHttpActionResult SendMessage(int ID, int currentUserID)
        {
            //var userId = User.Identity.GetUserId();
            var currentUser = unitOfWork.Developers.GetDeveloperIncludeFollowersIncludeUser(currentUserID);
            var viewModel = MessageFormViewModel.GetMessageFormViewModel(ID, currentUser, unitOfWork);
            return Ok(viewModel);
        }

        //POST : Message
        //[ValidateAntiForgeryToken]
        [Authorize]
        [HttpPost]
        public void SendMessage(MessageFormViewModel viewModel, int userID)
        {
            if (!ModelState.IsValid)
                //return BadRequest();
            if (viewModel.ReceiverUserID != null)
            {
                    viewModel.ReceiverID = unitOfWork.Developers.GetDeveloperIDUsingUserID(viewModel.ReceiverUserID);
                   //context.Developers.Single(d => d.UserID == viewModel.ReceiverUserID).ID;
            }
            //var userId = User.Identity.GetUserId();
            var sender = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(userID);
            var receiver = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(viewModel.ReceiverID);
            var message = new Message(viewModel.Subject, viewModel.Text, sender, receiver);
            unitOfWork.DeveloperNotifications.Add(sender, receiver);
            sender.SendMessage(message);
            unitOfWork.Complete();
            //return RedirectToAction("DeveloperProfile", "Developer", new { controller = "Developer", action = "DeveloperProfile", id = viewModel.ReceiverID });
        }
    }
}
