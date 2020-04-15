using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public DeveloperRepository Developers { get; private set; }
        public FollowsRepository Follows { get; private set; }
        public CommentRepository Comments { get; private set; }
        public ProjectRepository Projects { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Developers = new DeveloperRepository(context);
            Follows = new FollowsRepository(context);
            Comments = new CommentRepository(context);
            Projects = new ProjectRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}