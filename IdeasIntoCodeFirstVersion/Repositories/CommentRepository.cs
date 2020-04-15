using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class CommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Comment> GetCommentsOfFollowees(List<int> followees)
        {
            return _context.Comments.Where(c => followees.Contains(c.DeveloperID))
                .OrderBy(c => c.TimeStamp)
                .Include(c => c.Developer)
                .Include(c => c.Developer.User)
                .Include(c => c.Project)
                .Include(c => c.Project.Admin)
                .Take(10).ToList();
        }
    }
}