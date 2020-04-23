using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
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

        public IEnumerable<ProgrammingLanguageDto> GetProgrammingLanguageDtos()
        {
            return _context.ProgrammingLanguages.ToList()
                .Select(Mapper.Map<ProgrammingLanguage, ProgrammingLanguageDto>);
        }
    }
}