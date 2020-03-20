using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class MessageController : Controller
    {
        private ApplicationDbContext context;
        public MessageController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Message
        public ActionResult SendMessage(int receiverID)
        {
            var viewModel = new MessageFormViewModel
            {
                ReceiverID = receiverID,
                Receiver = context.Developers.Single(d => d.ID == receiverID)
            };
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

            var userId = User.Identity.GetUserId();
            var sender = context.Developers.Single(d => d.User.Id == userId);
            var receiver = context.Developers.Single(d => d.ID == viewModel.ReceiverID);
            var message = new Message(viewModel.Subject, viewModel.Text, sender, receiver);
            sender.SendMessage(message);
            context.SaveChanges();
            return RedirectToAction("DeveloperProfile", "Developer", new { controller = "Developer", action = "DeveloperProfile", id = viewModel.ReceiverID });
        }
    }
}