using System.Collections.Generic;
using System.Linq;
using IdeasIntoCodeFirstVersion.Dtos;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IProjectRepository
    {
        void Add(Project project);
        bool CheckIfProjectExist(Developer developer, JoinDto joinDto);
        Project FindProject(int? id);
        List<Project> Get10NewestProjects();
        Project GetProject(int? ID);
        Project GetProjectIncludeProgrammingLanguages(int? ID);
        Project GetProjectIncludeProjectCategories(int? ID);
        Project GetProjectIncludeTeamMembersAndAdmin(JoinDto joinDto);
        Project GetProjectWithProgrammingLanguagesAndCategories(int ID);
        IQueryable<Project> GetProjects();
        void Remove(Project project);
    }
}