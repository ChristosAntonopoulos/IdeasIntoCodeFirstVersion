using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class MessageFormViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public int SenderID { get; set; }
        public Developer Sender { get; set; }

        [Required]
        public int ReceiverID { get; set; }
        public Developer Receiver { get; set; }
        public string ReceiverUserID { get; set; }

        [Required]
        public DateTime DatePosted { get; set; }
        public IEnumerable<ApplicationUser> Followers { get; set; }

        public static MessageFormViewModel GetMessageFormViewModel(int ID, Developer currentUser, IUnitOfWork unitOfWork)
        {
            var viewModel = new MessageFormViewModel();
            if (ID != currentUser.ID)
            {
                viewModel.ReceiverID = ID;
                viewModel.Receiver = unitOfWork.Developers.GetDeveloperWithUserUsingDeveloperId(ID);
            }
            else
            {
                viewModel.Followers = currentUser.Followers.Select(f => f.Follower.User);
            }

            return viewModel;
        }
    }
}