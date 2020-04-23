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

        public static GetMessagesViewModel GetMessagesReceivedOrSend(string whatMessagesToGet, IUnitOfWork unitOfWork, int userID)
        {
            var messages = new GetMessagesViewModel();
            if (whatMessagesToGet == "Send")
            {
                messages.Messages = unitOfWork.Messages.GetSendMessagesIncludeReceiver(userID);
                messages.WhatMessagesToGet = whatMessagesToGet;
            }
            else if (whatMessagesToGet == "Received")
            {
                messages.Messages = unitOfWork.Messages.GetReceivedMessagesIncludeSender(userID);
                messages.WhatMessagesToGet = whatMessagesToGet;
            }
            else
                return messages;
            return messages;
        }
    }
}