using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class ProgrammingLanguageRepository : IProgrammingLanguageRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgrammingLanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProgrammingLanguage> GetLanguages()
        {
            return _context.ProgrammingLanguages.ToList();
        }

        public ProgrammingLanguage GetProgrammingLanguage(int ID)
        {
            return _context.ProgrammingLanguages.Single(p => p.ID == ID);
        }

        public List<ProgrammingLanguage> GetLanguagesUsingSearchString(string searchString)
        {
            return _context.ProgrammingLanguages.Where(p => p.Name.StartsWith(searchString)).ToList();
        }

    }
}