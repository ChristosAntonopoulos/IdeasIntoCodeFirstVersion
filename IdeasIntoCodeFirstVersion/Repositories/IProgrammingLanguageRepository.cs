using System.Collections.Generic;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IProgrammingLanguageRepository
    {
        List<ProgrammingLanguage> GetLanguages();
        IEnumerable<ProgrammingLanguageDto> GetProgrammingLanguageDtos();
    }
}