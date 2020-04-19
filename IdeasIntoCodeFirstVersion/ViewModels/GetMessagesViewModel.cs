using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class GetMessagesViewModel
    {
        public IEnumerable<Message> Messages { get; set; }
        public string WhatMessagesToGet { get; set; }

        public static GetMessagesViewModel GetMessages(Developer developer, string whatMessagesToGet, ApplicationDbContext context, UnitOfWork unitOfWork)
        {
            var messages = new GetMessagesViewModel();

            if (whatMessagesToGet == "Send")
            {
                messages.Messages = unitOfWork.Messages.GetSendMessages(developer);
                messages.WhatMessagesToGet = whatMessagesToGet;
            }
            else if(whatMessagesToGet == "Received")
            {
                messages.Messages = unitOfWork.Messages.GetReceivedMessages(developer);
                messages.WhatMessagesToGet = whatMessagesToGet;
            }
            return messages;
        }
 
    }
}