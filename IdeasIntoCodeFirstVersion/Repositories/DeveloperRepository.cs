using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class DeveloperRepository
    {
        private readonly ApplicationDbContext _context;

        public DeveloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Developer> GetDevelopersToUpdate(int developerID)
        {
            return _context.Follows
                    .Where(f => f.FolloweeID == developerID)
                    .Select(f => f.Follower).ToList();
        }

        public Developer GetDeveloperIncludeProject(string userId)
        {
            return _context.Developers.Include(d => d.ProjectsOwned)
           .Include(d => d.TeamParicipating.Select(t => t.Project)).SingleOrDefault(d => d.UserID == userId);

        }

        public Developer GetDeveloperIncludeUser(string userId)
        {
            return _context.Developers.Where(d => d.User.Id == userId).Include(d => d.User).SingleOrDefault();

        }

        public int GetAdminId(string userID)
        {
            return _context.Developers.Where(d => d.User.Id == userID).SingleOrDefault().ID;
        }
    }
}