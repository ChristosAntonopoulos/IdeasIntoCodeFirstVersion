using System.Collections.Generic;
using System.Linq;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IDeveloperRepository
    {
        int GetAdminId(string userID);
        IQueryable<Developer> GetAllDevelopersIncludeUser();
        int GetDeveloperIDUsingUserID(string userID);
        Developer GetDeveloperIncludeProject(string userId);
        Developer GetDeveloperIncludeUser(string userId);
        Developer GetDeveloperIncludeUserFollowers(string userID);
        List<Developer> GetDevelopersToUpdate(int developerID);
        Developer GetDeveloperWithEverythingUsingDeveloperId(int? ID);
        Developer GetDeveloperWithUserAndProgrammingLanguagesUsingUserId(string userID);
        Developer GetDeveloperWithUserUsingDeveloperId(int? ID);
        Developer GetDeveloperWithFirstOrDefault(string userID);
    }
}