using System.Collections.Generic;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface ICategoryRepository
    {
        List<ProjectCategory> GetCategories();
    }
}