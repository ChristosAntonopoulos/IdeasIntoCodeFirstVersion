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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Data(string searchString)
        {

            var developers = from d in context.Developers
                             select d;
            var projects = from p in context.Projects
                           select p;
            
            if (!string.IsNullOrEmpty(searchString))
            {
                
                developers = developers.Where(s => s.LastName.Contains(searchString)
                || s.Name.Contains(searchString));

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