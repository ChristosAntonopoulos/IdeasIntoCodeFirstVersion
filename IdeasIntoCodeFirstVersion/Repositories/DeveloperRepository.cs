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


        //DOMI
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

        //api
        public Developer GetDeveloperIncludeUser(int developerId)
        {
            return _context.Developers.Include(d => d.User).SingleOrDefault(d=>d.ID==developerId);

        }
       

        public int GetAdminId(string userID)
        {
            return _context.Developers.Where(d => d.User.Id == userID).SingleOrDefault().ID;
        }


        //TED
        public Developer GetDeveloperIncludeProjectUsingId(int ID)
        {
            return _context.Developers.Include(d => d.ProjectsOwned)
          .Include(d => d.TeamParicipating.Select(t => t.Project)).SingleOrDefault(d => d.ID == ID);
        }

        public Developer GetDeveloperWithUserUsingDeveloperId(int? ID)
        {
            return _context.Developers
                .Include(d => d.User)
                .SingleOrDefault(u => u.ID == ID);
        }
        public Developer GetDeveloperIncludeUserUsingUserId(string userID)
        {
            return _context.Developers.Include(d => d.User)
                .Single(u => u.UserID == userID);
        }
        public int GetDeveloperIDUsingUserID(string userID)
        {
            return _context.Developers.Where(d => d.User.Id == userID).Select(d => d.ID).SingleOrDefault();
        }

        public Developer GetDeveloperWithEverythingUsingDeveloperId(int? ID)
        {
            return _context.Developers
                .Include(u => u.ProgrammingLanguages)
                .Include(d => d.ProjectsOwned)
                .Include(d => d.Followers)
                .Include(d => d.Following)
                .Include(d => d.SendMessages)
                .Include(d => d.RecievedMessages)
                .Include(d => d.User)
                .SingleOrDefault(u => u.ID == ID);
        }
        public Developer GetDeveloperWithUserAndProgrammingLanguagesUsingUserId(string userID)
        {
            return _context.Developers
                .Include(d => d.ProgrammingLanguages)
                .Include(d => d.User)
                .SingleOrDefault(p => p.User.Id == userID);
        }

        public Developer GetDeveloperIncludeFollowersIncludeUser(int ID)
        {
            return _context.Developers
                .Include(d => d.Followers.Select(f => f.Follower.User))
                .Include(d => d.User)
                .Single(d => d.ID == ID);
        }
    }
}