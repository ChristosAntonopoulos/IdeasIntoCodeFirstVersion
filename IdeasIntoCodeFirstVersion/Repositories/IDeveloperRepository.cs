using System.Collections.Generic;
using System.Linq;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IDeveloperRepository
    {
        int GetAdminId(string userID);
        int GetDeveloperIDUsingUserID(string userID);
        Developer GetDeveloperIncludeFollowersIncludeUser(int ID);
        Developer GetDeveloperIncludeProject(string userId);
        Developer GetDeveloperIncludeProjectUsingId(int ID);
        Developer GetDeveloperIncludeUser(int developerId);
        Developer GetDeveloperIncludeUser(string userId);
        Developer GetDeveloperIncludeUserUsingUserId(string userID);
        List<Developer> GetDevelopersToUpdate(int developerID);
        Developer GetDeveloperWithEverythingUsingDeveloperId(int? ID);
        Developer GetDeveloperWithUserAndProgrammingLanguagesUsingUserId(string userID);
        Developer GetDeveloperWithUserUsingDeveloperId(int? ID);

        bool CheckIfCurrentUserFollowsUserOfProfile(int ID, int currentUserID);
        IQueryable<Developer> GetDevelopersIncludeUsers();
        void Add(Developer developer);
    }
}