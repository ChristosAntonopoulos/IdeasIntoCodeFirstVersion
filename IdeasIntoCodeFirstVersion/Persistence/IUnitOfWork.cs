using IdeasIntoCodeFirstVersion.Repositories;

namespace IdeasIntoCodeFirstVersion.Persistence
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IDeveloperNotificationRepository DeveloperNotifications { get; }
        IDeveloperRepository Developers { get; }
        IFollowsRepository Follows { get; }
        IMessageRepository Messages { get; }
        IProgrammingLanguageRepository ProgrammingLanguages { get; }
        IProjectRepository Projects { get; }

        void Complete();
    }
}