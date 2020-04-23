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
            var message = context.Messages.Single(m => m.ID == messageID);
            Message.MarkAsRead(message);
            context.SaveChanges();
        }

       public ActionResult GetMessages(string whatMessagesToGet)
        {
            var userId = User.Identity.GetUserId();
            var user = unitOfWork.Developers.GetDeveloperIncludeUser(userId);
            var messages = new GetMessagesViewModel();
            if (whatMessagesToGet == "Send")
            {
                 messages.Messages = context.Messages
                    .Include(m => m.Receiver)
                    .Include(m => m.Receiver.User)
                    .Where(m => m.SenderID == user.ID).ToList();
                 messages.WhatMessagesToGet = whatMessagesToGet;
            }
            else if (whatMessagesToGet == "Received")
            {
                 messages.Messages = context.Messages
                    .Include(m => m.Sender)
                    .Include(m => m.Sender.User)
                    .Where(m => m.ReceiverID == user.ID).ToList();
                 messages.WhatMessagesToGet = whatMessagesToGet;
            }
            else
                return RedirectToAction("DeveloperProfile", "Developer", new { controller = "Developer", action = "DeveloperProfile", id = user.ID });
            return View(messages);
        }

        // GET: Message
        public ActionResult SendMessage(int ID)
        {
            var userId = User.Identity.GetUserId();
            var currentUser = context.Developers
                .Include(d => d.Followers.Select(f => f.Follower.User))
                .Include(d => d.User)
                .Single(d => d.User.Id == userId);
            var viewModel = new MessageFormViewModel();
            if (ID != currentUser.ID)
            {
                viewModel.ReceiverID = ID;
                viewModel.Receiver = context.Developers.Include(d => d.User).Single(d => d.ID == ID);
            }
            else
            {
                viewModel.Followers = currentUser.Followers.Select(f => f.Follower.User);
            }
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
                viewModel.ReceiverID = context.Developers.Single(d => d.UserID == viewModel.ReceiverUserID).ID;
            }
            
            var userId = User.Identity.GetUserId();
            var sender = context.Developers.Single(d => d.User.Id == userId);
            var receiver = context.Developers.Single(d => d.ID == viewModel.ReceiverID);
            var message = new Message(viewModel.Subject, viewModel.Text, sender, receiver);            
            context.DeveloperNotifications.Add(new DeveloperNotification(receiver, new Notification(sender, NotificationType.Messaged)));               
            sender.SendMessage(message);
            context.SaveChanges();
            return RedirectToAction("DeveloperProfile", "Developer", new { controller = "Developer", action = "DeveloperProfile", id = viewModel.ReceiverID });
        }
    }
}