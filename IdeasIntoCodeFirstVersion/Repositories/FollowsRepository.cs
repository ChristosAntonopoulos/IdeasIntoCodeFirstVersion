using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class FollowsRepository : IFollowsRepository
    {
        private readonly ApplicationDbContext _context;
        public FollowsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<int> GetFolloweesIdsUsingDeveloperId(int developerId)
        {
            return _context.Follows.Where(f => f.FollowerID == developerId).Select(f => f.FolloweeID).ToList();
        }

        public List<Follow> GetFollowersOfFollowees(List<int> followees)
        {
            return _context.Follows
                .Where(f => followees
                .Contains(f.FollowerID))
                .OrderBy(f => f.TimeStamp)
                .Include(f => f.Followee)
                .Include(f => f.Followee.User)
                .Include(f => f.Follower)
                .Include(f => f.Follower.User)
                .Take(10).ToList();
        }

        public List<Developer> GetFollowers(int ID)
        {
            return _context.Follows.Where(f => f.FolloweeID == ID).Select(f => f.Follower)
                .Include(f => f.User)
                .ToList();
        }

        public List<Developer> GetFollowees(int ID)
        {
            return _context.Follows.Where(f => f.FollowerID == ID).Select(f => f.Followee)
                .Include(f => f.User)
                .ToList();
        }

        public Follow GetFollow(int followerID, int followeeID)
        {
                return _context.Follows.Single(f => f.FolloweeID == followeeID && f.FollowerID == followerID);
        }

        public void Add(Follow following)
        {
            _context.Follows.Add(following);
        }

        public void Delete(Follow follow)
        {
            _context.Follows.Remove(follow);
        }
    }
}