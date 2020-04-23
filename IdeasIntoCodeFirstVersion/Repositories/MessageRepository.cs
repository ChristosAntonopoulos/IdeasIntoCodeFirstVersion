using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class MessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Message> GetMessagesReceived(int ID)
        {
            return _context.Messages.Where(m => m.ReceiverID == ID);
        }

        public Message GetMessage(int ID)
        {
            return _context.Messages.Single(m => m.ID == ID);
        }

        public IEnumerable<Message> GetSendMessagesIncludeReceiver(int userID)
        {
           var mes= _context.Messages
                   .Include(m => m.Receiver)
                   .Include(m => m.Receiver.User)
                   .Where(m => m.SenderID == userID).ToList();
            return mes;
        }

        public IEnumerable<Message> GetReceivedMessagesIncludeSender(int userID)
        {
            return _context.Messages
                   .Include(m => m.Sender)
                   .Include(m => m.Sender.User)
                   .Where(m => m.ReceiverID == userID).ToList();
        }
    }
}