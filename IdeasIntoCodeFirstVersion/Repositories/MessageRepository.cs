using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class MessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Message GetMessage(int messageID)
        {
            return _context.Messages.Single(m => m.ID == messageID);
        }

        public IEnumerable<Message> GetSendMessages(Developer developer)
        {
            return _context.Messages
                   .Include(m => m.Receiver)
                   .Include(m => m.Receiver.User)
                   .Where(m => m.SenderID == developer.ID).ToList();
        }

        public IEnumerable<Message> GetReceivedMessages(Developer developer)
        {
            return _context.Messages
                   .Include(m => m.Sender)
                   .Include(m => m.Sender.User)
                   .Where(m => m.ReceiverID == developer.ID).ToList();
        }
        
    }
}