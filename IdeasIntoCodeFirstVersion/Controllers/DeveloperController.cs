using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

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
        public ActionResult Save(Developer developer, string[] programmingLanguage)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DeveloperFormViewModel
                {
                    ProgrammingLanguages = context.ProgrammingLanguages.ToList(),
                    Developer = developer

                };

                return View("DeveloperForm", viewModel);

            }

            if (developer.ID == 0)
            {
                if (programmingLanguage!=null)
                {
                    PopulateDeveloperProgrammingLanguages(developer, programmingLanguage);
                }
                             
                context.Developers.Add(developer);


            }
            else
            {
               
                var DeveloperDB = context.Developers.Include(d=>d.ProgrammingLanguages).Single(u => u.ID == developer.ID);
                if (programmingLanguage != null)
                {
                    if (DeveloperDB.ProgrammingLanguages.Count()==0)
                    {
                        PopulateDeveloperProgrammingLanguages(DeveloperDB, programmingLanguage);
                    }
                    else
                    {
                        UpdateDeveloperProgrammingLanguages(DeveloperDB, programmingLanguage);
                    }
                    
                }
                DeveloperDB.Name = developer.Name;
                DeveloperDB.LastName = developer.LastName;
                DeveloperDB.GitHub = developer.GitHub;
                DeveloperDB.Email = developer.Email;
                DeveloperDB.BirthDate = developer.BirthDate;
            }

            context.SaveChanges();

            return View("DeveloperProfile", developer.ID);
        }

        public void UpdateDeveloperProgrammingLanguages(Developer developer, string[] programmingLanguage)
        {

            foreach (var language in context.ProgrammingLanguages)
            {
                if (programmingLanguage.Contains(language.ID.ToString()))
                {
                    if (!developer.ProgrammingLanguages.Contains(language))
                    {
                        developer.ProgrammingLanguages.Add(language);
                        

                    }
                }
                else
                {
                    if (developer.ProgrammingLanguages.Contains(language))
                    {
                        developer.ProgrammingLanguages.Remove(language);
                    }
                }
            

            }
        }
           


        public void PopulateDeveloperProgrammingLanguages(Developer developer, string[] programmingLanguage)
        {

            var programminglanguagesDb = context.ProgrammingLanguages.ToList();
            foreach (var programmingLanguageID in programmingLanguage)
            {
                developer.ProgrammingLanguages.Add(programminglanguagesDb.Where(p => p.ID.ToString() == programmingLanguageID).FirstOrDefault());

            }
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

        // GET: Instructor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var developer = context.Developers.Find(id);

            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var developer = context.Developers.Find(id);
            context.Developers.Remove(developer);
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}