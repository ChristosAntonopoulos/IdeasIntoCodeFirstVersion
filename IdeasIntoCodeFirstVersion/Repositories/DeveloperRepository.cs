using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class DeveloperRepository
    {
        private readonly ApplicationDbContext _context;
        public DeveloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Developer GetDeveloperWithUserUsingDeveloperId(int? ID)
        {
            return _context.Developers
                .Include(d => d.User)
                .SingleOrDefault(u => u.ID == ID);
        }
        public Developer GetDeveloperWithUserUsingUserId(string userID)
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
    }
}