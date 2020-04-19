using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
using IdeasIntoCodeFirstVersion.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class MessageController : Controller
    {
        private ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;
        public MessageController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        public void MarkAsRead(int messageID)
        {
            var message = unitOfWork.Messages.GetMessage(messageID);
            Message.MarkAsRead(message);
            unitOfWork.Complete();
        }

       public ActionResult GetMessages(string whatMessagesToGet)
        {
            var userId = User.Identity.GetUserId();
            var user = unitOfWork.Developers.GetDeveloperIncludeUser(userId);
            var messages = GetMessagesViewModel.GetMessages(user, whatMessagesToGet, context, unitOfWork);
            if (messages == null)
                return RedirectToAction("DeveloperProfile", "Developer", new { controller = "Developer", action = "DeveloperProfile", id = user.ID });
            //if (whatMessagesToGet == "Send")
            //{
            //     messages.Messages = context.Messages
            //        .Include(m => m.Receiver)
            //        .Include(m => m.Receiver.User)
            //        .Where(m => m.SenderID == user.ID).ToList();
            //     messages.WhatMessagesToGet = whatMessagesToGet;
            //}
            //else if (whatMessagesToGet == "Received")
            //{
            //     messages.Messages = context.Messages
            //        .Include(m => m.Sender)
            //        .Include(m => m.Sender.User)
            //        .Where(m => m.ReceiverID == user.ID).ToList();
            //     messages.WhatMessagesToGet = whatMessagesToGet;
            //}
            //else
            //    return RedirectToAction("DeveloperProfile", "Developer", new { controller = "Developer", action = "DeveloperProfile", id = user.ID });

            return View(messages);
        }

        // GET: Message
        public ActionResult SendMessage(int ID)
        {
            var userId = User.Identity.GetUserId();
            var currentUser = unitOfWork.Developers.GetDeveloperIncludeUserFollowers(userId);
            var viewModel = MessageFormViewModel.CreateMessageFormViewModel(ID, currentUser, unitOfWork);
            return View(viewModel);
        }

        //POST : Message
        [ValidateAntiForgeryToken]
        [Authorize]
        [HttpPost]
        public ActionResult SendMessage(MessageFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("SendMessage", viewModel);
            if (viewModel.ReceiverUserID != null)
            {
                viewModel.ReceiverID = unitOfWork.Developers.GetDeveloperIDUsingUserID(viewModel.ReceiverUserID);
                //context.developers.single(d => d.userid == viewmodel.receiveruserid).id;
            }
            
            var userId = User.Identity.GetUserId();
            var sender = unitOfWork.Developers.GetDeveloperIncludeUser(userId);
            var receiver = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(viewModel.ReceiverID);
            //context.Developers.Single(d => d.ID == viewModel.ReceiverID);
            var message = new Message(viewModel.Subject, viewModel.Text, sender, receiver);
            unitOfWork.DeveloperNotifications.Add(sender, receiver);
            //context.DeveloperNotifications.Add(new DeveloperNotification(receiver, new Notification(sender, NotificationType.Messaged)));               
            sender.SendMessage(message);
            unitOfWork.Complete();
            return RedirectToAction("DeveloperProfile", "Developer", new { controller = "Developer", action = "DeveloperProfile", id = viewModel.ReceiverID });
        }
    }
}