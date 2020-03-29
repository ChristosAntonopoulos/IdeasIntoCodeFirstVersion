using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class ProgrammingLanguage
    {
        public int ID { get; set; }


        [Required]
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }

        public  ICollection<Developer> Developers { get; set; }

        public ProgrammingLanguage()
        {
            Projects = new List<Project>();
            Developers = new List<Developer>();
        }


        public  static void UpdateDeveloperProgrammingLanguages(List<ProgrammingLanguage> listToUpdate, string[] programmingLanguage, List<ProgrammingLanguage> AllProgrammingLanguages)
        {

            foreach (var language in AllProgrammingLanguages)
            {
                if (programmingLanguage.Contains(language.ID.ToString()))
                {
                    if (!listToUpdate.Contains(language))
                    {
                        listToUpdate.Add(language);


                    }
                }
                else
                {
                    if (listToUpdate.Contains(language))
                    {
                        listToUpdate.Remove(language);
                    }
                }
            }
        }

        //private void PopulateDeveloperProgrammingLanguages(Developer developer, string[] programmingLanguage)
        //{
        //    var programminglanguagesDb = context.ProgrammingLanguages.ToList();
        //    foreach (var programmingLanguageID in programmingLanguage)
        //    {
        //        developer.ProgrammingLanguages.Add(programminglanguagesDb.Where(p => p.ID.ToString() == programmingLanguageID).FirstOrDefault());

        //    }
        //}



    }
}