using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdeasIntoCodeFirstVersion.ViewModels;
using System.Data.Entity;
using IdeasIntoCodeFirstVersion.Interface;
using Microsoft.AspNet.Identity;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        public HomeController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    var currentUserID=User.Identity.GetUserId();

            //    return RedirectToAction("DeveloperProfile",1);

            //}
            return View();
        }

        [Authorize]
       public ActionResult NewsFeed()
        {
            var userId = User.Identity.GetUserId();
            var developerid = context.Developers.Where(d => d.User.Id == userId).Select(d => d.ID).SingleOrDefault();
            var newsFeedList = new List<INewsFeed>();
            var follows = context.Follows.Where(f=>f.FollowerID== developerid).Select(f => f.FolloweeID).ToList();
            var comments = context.Comments.Where(c=> follows.Contains(c.DeveloperID)).OrderBy(c=>c.TimeStamp).Include(c=>c.Developer).Include(c=>c.Project).Include(c => c.Project.Admin).Take(10).ToList();
            var followers = context.Follows.Where(f => follows.Contains(f.FollowerID)).OrderBy(f => f.TimeStamp).Include(f=>f.Followee).Include(f => f.Follower).Take(10).ToList();
            //var projects = context.Projects.Where(p => follows.Contains(p.AdminID)).OrderBy(p => p.TimeStamp).Take(10);

            //var comments = from s in context.Comments
            //               join sa in context.Follows on s.DeveloperID equals sa.FolloweeID
            //               where sa.FollowerID == id
            //               select s;
            newsFeedList.AddRange(comments);
            newsFeedList.AddRange(followers);
            newsFeedList.AddRange(context.Projects.OrderBy(p => p.TimeStamp).Include(c => c.Admin).Take(10).ToList());




            //var viewModel = new NewsFeedViewModel
            //{
            //    Followers = followers,
            //    Projects = context.Projects.OrderBy(p => p.TimeStamp).Take(10).ToList(),
            //    Comments = comments.ToList()
            //    };
           // newsFeedList = newsFeedList.OrderBy(n => n.TimeStamp).ToList();

            return View(newsFeedList.OrderBy(n=>n.TimeStamp).ToList());
        }

        public ActionResult Data(string searchString)
        {

            var developers = from d in context.Developers
                             select d;
            var projects = from p in context.Projects
                           select p;
            
            if (!string.IsNullOrEmpty(searchString))
            {
                
                developers = developers.Where(s => s.User.LastName.Contains(searchString)
                || s.User.Name.Contains(searchString));

                projects = projects.Where(p => p.Title.Contains(searchString));
            }
            var viewmodel = new SearchResultViewModel()
            {
                Developers = developers.ToList(),
                Projects = projects.ToList()
            };

            return View(viewmodel);
        }

        public ActionResult Search()
        {
            return View();
        }
    }
}