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
using IdeasIntoCodeFirstVersion.Persistence;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;
        public HomeController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        public ActionResult Index()
        {
            
            return View();
        }

       

        public ActionResult Data(string searchString)
        {
            var developers = unitOfWork.Developers.GetAllDevelopersIncludeUser();
            var projects = unitOfWork.Projects.GetAllProjects();
            
            
            if (!string.IsNullOrEmpty(searchString))
            {
                developers = developers.Where(s => s.User.LastName.Contains(searchString)
                || s.User.Name.Contains(searchString));
                
                projects = projects.Where(p => p.Title.Contains(searchString));
            }

            var viewmodel = new SearchResultViewModel(developers, projects);
            

            return View(viewmodel);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }
    }
}