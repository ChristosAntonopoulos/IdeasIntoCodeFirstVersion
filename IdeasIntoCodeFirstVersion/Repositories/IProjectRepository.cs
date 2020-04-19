using System.Collections.Generic;
using System.Linq;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IProjectRepository
    {
        void Add(Project project);
        Project FindProject(int? id);
        List<Project> Get10NewestProjects();
        IQueryable<Project> GetAllProjects();
        Project GetProjectWithProgrammingLanguagesAndCategories(int ID);
        void Remove(Project project);
    }
}