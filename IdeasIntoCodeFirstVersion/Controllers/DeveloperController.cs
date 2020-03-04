using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class DeveloperController : Controller
    {
        private ApplicationDbContext context;
        public DeveloperController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


        public ActionResult DeveloperProfile(int ID)
        {
            var Developer = context.Developers.Include(u => u.ProgrammingLanguages).SingleOrDefault(u => u.ID == ID);

            return View(Developer);
        }



        // Developer/new

        public ActionResult New()
        {
            var programmingLanguages = context.ProgrammingLanguages.ToList();

            var viewModel = new DeveloperFormViewModel()
            {
                ProgrammingLanguages = programmingLanguages
            };

            return View("DeveloperForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Developer Developer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DeveloperFormViewModel
                {
                    ProgrammingLanguages = context.ProgrammingLanguages.ToList(),
                    Developer = Developer

                };

                return View("DeveloperForm", viewModel);

            }

            if (Developer.ID == 0)
            {
                context.Developers.Add(Developer);

            }
            else
            {
                var DeveloperDB = context.Developers.Single(u => u.ID == Developer.ID);
                DeveloperDB.Name = Developer.Name;
                DeveloperDB.LastName = Developer.LastName;
                DeveloperDB.ProgrammingLanguages = Developer.ProgrammingLanguages;
                DeveloperDB.GitHub = Developer.GitHub;
                DeveloperDB.Email = Developer.Email;
                DeveloperDB.BirthDate = Developer.BirthDate;
            }

            context.SaveChanges();

            return View("DeveloperProfile", Developer.ID);
        }

        public ActionResult Edit(int ID)
        {
            var Developer = context.Developers.SingleOrDefault(p => p.ID == ID);

            if (Developer == null)
                return HttpNotFound();


            var viewModel = new DeveloperFormViewModel()
            {
                ProgrammingLanguages = context.ProgrammingLanguages.ToList(),
                Developer = Developer

            };




            return View("DeveloperForm", viewModel);
        }
    }
}