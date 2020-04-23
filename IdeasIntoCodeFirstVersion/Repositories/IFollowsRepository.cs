using System.Collections.Generic;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IFollowsRepository
    {
        void Add(Follow following);
        void Delete(Follow follow);
        Follow GetFollow(int followerID, int followeeID);
        List<Developer> GetFollowees(int ID);
        List<int> GetFolloweesIdsUsingDeveloperId(int developerId);
        List<Developer> GetFollowers(int ID);
        List<Follow> GetFollowersOfFollowees(List<int> followees);
    }
}