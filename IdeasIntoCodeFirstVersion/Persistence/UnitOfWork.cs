using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICategoryRepository Categories { get; private set; }
        public IProgrammingLanguageRepository ProgrammingLanguages { get; private set; }
        public IDeveloperRepository Developers { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public IFollowsRepository Follows { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public IMessageRepository Messages { get; private set; }
        public IDeveloperNotificationRepository DeveloperNotifications { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            ProgrammingLanguages = new ProgrammingLanguageRepository(context);
            Developers = new DeveloperRepository(context);
            Projects = new ProjectRepository(context);
            Follows = new FollowsRepository(context);
            Comments = new CommentRepository(context);
            Messages = new MessageRepository(context);
            DeveloperNotifications = new DeveloperNotificationRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}