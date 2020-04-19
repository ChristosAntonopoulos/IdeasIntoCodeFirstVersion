using System.Collections.Generic;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IFollowsRepository
    {
        List<int> GetFolloweesIdsUsingDeveloperId(int developerId);
        List<Follow> GetFollowersOfFollowees(List<int> followees);

        bool CheckIfDeveloperFollowsDeveloperOfProfile(string userID, int? ID);
    }
}