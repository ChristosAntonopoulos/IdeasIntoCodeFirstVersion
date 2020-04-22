using System.Collections.Generic;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface ICategoryRepository
    {
        List<ProjectCategory> GetCategories();
        IEnumerable<ProjectCategoryDto> GetCategoriesAsDtos();
    }
}