using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
using IdeasIntoCodeFirstVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.App_Start
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Developer, DeveloperDto>();
            CreateMap<DeveloperDto, Developer>();
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>();
            CreateMap<ProgrammingLanguageDto, ProgrammingLanguage>();
            CreateMap<ProjectCategory, ProjectCategoryDto>();
            CreateMap<ProjectCategoryDto, ProjectCategory>();
        }
    }
}