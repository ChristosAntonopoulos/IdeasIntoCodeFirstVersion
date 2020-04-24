using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class Message
    {
        
        public int ID { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Text { get; set; }
        
        [Required]
        [ForeignKey("Sender")]
        public int SenderID { get; set; }
        public Developer Sender { get; set; }

        [Required]
        [ForeignKey("Receiver")]
        public int ReceiverID { get; set; }
        public Developer Receiver { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsRead { get; set; }

        private Message()
        {

        }

        public Message(string subject, string text, Developer sender, Developer receiver)
        {
            Subject = subject;
            Text = text;
            Sender = sender;
            SenderID = sender.ID;
            Receiver = Receiver;
            ReceiverID = receiver.ID;
            DatePosted = DateTime.Now;
        }

        public static void MarkAsRead(Message message)
        {
            message.IsRead = true;
        }
    }

    
}