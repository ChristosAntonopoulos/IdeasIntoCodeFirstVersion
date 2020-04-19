using System.Collections.Generic;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface IProgrammingLanguageRepository
    {
        List<ProgrammingLanguage> GetLanguages();
        List<ProgrammingLanguage> GetLanguagesUsingSearchString(string searchString);
        ProgrammingLanguage GetProgrammingLanguage(int ID);
    }
}