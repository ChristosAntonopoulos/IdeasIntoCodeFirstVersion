using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.ViewModels
{
    public class ProjectFormViewModel
    {
        public int? ID { get; set; }
        public ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public ICollection<ProjectCategory> ProjectCategories { get; set; }

        public Project Project { get; set; }

        [Required]
        [Display(Name ="Programming Languages")]
        public int? ProgrammingLanguagesID { get; set; }

        [Required]
        [Display(Name = "Project Categories")]
        public int? ProjectCategoryID { get; set; }

        public string Title
        {
            get
            {
                return ID != 0 ? "Edit Project" : "New Project";
            }
        }

        public ProjectFormViewModel()
        {

        }
        public ProjectFormViewModel(Project project,List<ProjectCategory> projectCategories,List<ProgrammingLanguage> programmingLanguages)
        {
            ProgrammingLanguages = programmingLanguages;
            Project = project;
            ProjectCategories = projectCategories;
        }
        public ProjectFormViewModel(Project project)
        {
            Project = project;
        }
    }
}