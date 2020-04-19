using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IDeveloperNotificationRepository
    {
        void Add(Developer sender, Developer receiver);
    }
}