using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IdeasIntoCodeFirstVersion.Persistence;

namespace IdeasIntoCodeFirstVersion.Controllers
{
    public class ProgrammingLanguageController : Controller
    {
       
        private readonly IUnitOfWork unitOfWork;
        public ProgrammingLanguageController(IUnitOfWork unitOfWork)
        {
           
            this.unitOfWork = unitOfWork;
        }
       
        // GET: ProgrammingLanguage

        public ActionResult ShowSelectedProgrammingLanguage(int ID)
        {
            var programmingLanguageToAdd = unitOfWork.ProgrammingLanguages.GetProgrammingLanguage(ID); 
            return PartialView("_AddProgrammingLanguages", programmingLanguageToAdd);
        }

        public ActionResult FindProgrammingLanguageList (string searchString)
        {
            var programmingLanguages = unitOfWork.ProgrammingLanguages.GetLanguagesUsingSearchString(searchString);
            return PartialView("_ProgrammingLanguageSearchResult", programmingLanguages);
        }

        public ActionResult AddProgrammingLanguage()
        {
            var currentUserID = User.Identity.GetUserId();
            var developer = unitOfWork.Developers.GetDeveloperWithUserAndProgrammingLanguagesUsingUserId(currentUserID);
            if (developer == null)
                return HttpNotFound();

            return View("AddProgrammingLanguage", developer);
            //var programmingLanguages = context.ProgrammingLanguages.Where(p => p.Name.StartsWith(searchString)).ToList();
        }

    }
}