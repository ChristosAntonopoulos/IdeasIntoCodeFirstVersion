using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdeasIntoCodeFirstVersion.ViewModels;
using System.Data.Entity;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class FollowController : Controller
    {
        private ApplicationDbContext context;
        public FollowController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Follow
        public ActionResult GetListOfFollowers(int ID)
        {
            var developer = context.Developers.SingleOrDefault(d => d.ID == ID);
            var listOfFollowers = context.Follows.Where(f => f.FolloweeID == ID).Select(f => f.Follower)
                .Include(f => f.User)
                .ToList();
            var viewModel = new ListOfFollowersFolloweesViewModel(listOfFollowers, "Followers");
            return View("GetListOfFollowersFollowees", viewModel);
        }

        public ActionResult GetListFollowees(int ID)
        {
            var developer = context.Developers.SingleOrDefault(d => d.ID == ID);
            var listOfFollowers = context.Follows.Where(f => f.FollowerID == ID).Select(f => f.Followee).ToList();
            var viewModel = new ListOfFollowersFolloweesViewModel(listOfFollowers, "Followees");
            return View("GetListOfFollowersFollowees", viewModel);        
        }
    }
}