using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class ProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Project FindProject(int? id)
        {
            return _context.Projects.Find(id);
        }

        public Project GetProjectWithProgrammingLanguagesAndCategories(int ID)
        {
            return _context.Projects
              .Include(p => p.Team.TeamMembers.Select(t => t.User))
              .Include(p => p.Admin)
              .Include(p => p.Admin.User)
              .Include(p => p.ProgrammingLanguages)
              .Include(p => p.ProjectCategories)
              .Include(p => p.Comments.Select(c => c.Developer).Select(c => c.User)).Single(p => p.ID == ID);
            
        }
        public List<Project> Get10NewestProjects()
        {
            return _context.Projects.OrderBy(p => p.TimeStamp)
                .Include(c => c.Admin)
                .Include(p => p.Admin.User)
                .Take(10)
                .ToList();
        }

        public void Add(Project project)
        {
            _context.Projects.Add(project);
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }
    }
}