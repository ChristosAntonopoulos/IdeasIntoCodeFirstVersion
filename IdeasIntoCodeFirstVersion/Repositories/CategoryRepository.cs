using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProjectCategory> GetCategories()
        {
            return _context.ProjectCategories.ToList();
        }

        public IEnumerable<ProjectCategoryDto> GetCategoriesAsDtos()
        {
            return _context.ProjectCategories.ToList().Select(Mapper.Map<ProjectCategory, ProjectCategoryDto>);
        }
    }
}