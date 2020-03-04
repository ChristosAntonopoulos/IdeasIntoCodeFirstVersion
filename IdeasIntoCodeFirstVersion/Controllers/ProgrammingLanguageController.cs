using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class ProgrammingLanguageController : Controller
    {
        private ApplicationDbContext context;
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
        
    }
}