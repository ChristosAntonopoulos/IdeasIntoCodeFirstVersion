﻿using IdeasIntoCodeFirstVersion.Models;
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

        [Required]
        public DateTime DatePosted { get; set; }
    }
}