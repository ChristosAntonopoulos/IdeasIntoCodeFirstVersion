﻿using IdeasIntoCodeFirstVersion.Models;
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

        public bool CheckIfDeveloperFollowsDeveloperOfProfile(string userID, int? ID)
        {
            return _context.Follows.Any(f => f.Follower.UserID == userID && f.Followee.ID == ID);
        }

        public IEnumerable<Developer> GetFollowersIncludeUser(int developerID)
        {
            return _context.Follows.Where(f => f.FolloweeID == developerID).Select(f => f.Follower)
                .Include(f => f.User)
                .ToList();
        }

        public IEnumerable<Developer> GetFolloweesIncludeUser(int developerID)
        {
            return _context.Follows.Where(f => f.FollowerID == developerID).Select(f => f.Followee)
                .Include(f => f.User)
                .ToList();
        }


    }
}