﻿using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository Categories { get;private set; }
        public ProgrammingLanguageRepository ProgrammingLanguages { get;private set; }
        public DeveloperRepository Developers { get;private set; }
        public ProjectRepository Projects { get;private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            ProgrammingLanguages = new ProgrammingLanguageRepository(context);
            Developers = new DeveloperRepository(context);
            Projects = new ProjectRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}