using System.Collections.Generic;
using System.Linq;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IMessageRepository
    {
        Message GetMessage(int ID);
        IQueryable<Message> GetMessagesReceived(int ID);
        IEnumerable<Message> GetReceivedMessagesIncludeSender(int userID);
        IEnumerable<Message> GetSendMessagesIncludeReceiver(int userID);
    }
}