using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class ProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Project> Get10NewestProjects()
        {
            return _context.Projects.OrderBy(p => p.TimeStamp)
                .Include(c => c.Admin)
                .Include(p => p.Admin.User)
                .Take(10)
                .ToList();
        }
    }
}