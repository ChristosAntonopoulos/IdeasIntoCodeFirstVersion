using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class FollowingController : Controller
    {
        //private ApplicationDbContext context;
        //public FollowingController()
        //{
        //    context = new ApplicationDbContext();
        //}
        // GET: Following
        public ActionResult GetListOfFollowers(int ID, string whatListToGet)
        {
            //var developer = context.Developers.Single(d => d.ID == ID);
            var viewModel = new FollowersFollowingViewModel(ID, whatListToGet);
            return View(viewModel);
        }
    }
}