using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class ProgrammingLanguageRepository
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
    }
}