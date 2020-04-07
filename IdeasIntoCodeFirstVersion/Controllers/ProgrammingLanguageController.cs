using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class ProgrammingLanguageController : Controller
    {
        private  ApplicationDbContext context;
        public ProgrammingLanguageController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: ProgrammingLanguage

        public ActionResult ShowSelectedProgrammingLanguage(int ID)
        {
            var programmingLanguageToAdd = context.ProgrammingLanguages.Single(p => p.ID == ID); 

            return PartialView("_AddProgrammingLanguages", programmingLanguageToAdd);
        }

        public ActionResult FindProgrammingLanguageList (string searchString)
        {

            var programmingLanguages = context.ProgrammingLanguages.Where(p => p.Name.StartsWith(searchString)).ToList();

            return PartialView("_ProgrammingLanguageSearchResult", programmingLanguages);
        }

        public ActionResult AddProgrammingLanguage()
        {
            var currentUserID = User.Identity.GetUserId();
            var developer = context.Developers
                .Include(d => d.ProgrammingLanguages)
                .Include(d => d.User)
                .SingleOrDefault(p => p.User.Id == currentUserID);
            if (developer == null)
                return HttpNotFound();

            return View("AddProgrammingLanguage", developer);
            //var programmingLanguages = context.ProgrammingLanguages.Where(p => p.Name.StartsWith(searchString)).ToList();
            
        }

    }
}