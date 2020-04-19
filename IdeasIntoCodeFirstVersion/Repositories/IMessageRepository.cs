using System.Collections.Generic;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IMessageRepository
    {
        Message GetMessage(int messageID);
        IEnumerable<Message> GetReceivedMessages(Developer developer);
        IEnumerable<Message> GetSendMessages(Developer developer);
    }
}