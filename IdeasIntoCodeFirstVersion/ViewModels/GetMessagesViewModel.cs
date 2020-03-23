using IdeasIntoCodeFirstVersion.Models;
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
    }
}