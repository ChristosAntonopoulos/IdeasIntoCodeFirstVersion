namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDb : DbMigration
    {
        public override void Up()
        {
            Sql(@"USE [IdeasIntoCodeFirstVersionDataBase]
                GO
                SET IDENTITY_INSERT [dbo].[Developers] ON
                INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id]) VALUES (1, N'Korompos', N'Nikos', CAST(N'1994-01-01T00:00:00.000' AS DateTime), N'test1@mail', N'test1git', NULL)
                INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id]) VALUES (2, N'Kalantas', N'Kwstas', CAST(N'1993-02-02T00:00:00.000' AS DateTime), N'test2@mail', N'test2git', NULL)
                INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id]) VALUES (3, N'Koukos', N'Nikos', CAST(N'1993-03-03T00:00:00.000' AS DateTime), N'test3@mail', N'test3git', NULL)
                SET IDENTITY_INSERT [dbo].[Developers] OFF
                SET IDENTITY_INSERT [dbo].[Projects] ON
                INSERT [dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID]) VALUES (1, N'Testproject1', N'randomdescription', 1, 1)
                INSERT [dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID]) VALUES (2, N'TestProject2', N'randomdescription2', 1, 2)
                SET IDENTITY_INSERT [dbo].[Projects] OFF
                INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (1, 1)
                INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (2, 1)
                INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (3, 1)
                INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (1, 2)
                INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (4, 2)
                INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (1, 3)
                INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (2, 3)
                INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (5, 3)
                INSERT [dbo].[Teams] ([ProjectID]) VALUES (1)
                INSERT [dbo].[Teams] ([ProjectID]) VALUES (2)
                INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (1, 1)
                INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (2, 1)
                INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (1, 2)
                INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (2, 2)
                INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (1, 3)
                INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (1, 1)
                INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (2, 1)
                INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (1, 2)
                INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (2, 2)
                INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (1, 3)
                INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (2, 4)
                INSERT [dbo].[ProjectCategoryProjects] ([ProjectCategory_ID], [Project_ID]) VALUES (1, 1)
                INSERT [dbo].[ProjectCategoryProjects] ([ProjectCategory_ID], [Project_ID]) VALUES (2, 1)
                INSERT [dbo].[ProjectCategoryProjects] ([ProjectCategory_ID], [Project_ID]) VALUES (3, 1)
                INSERT [dbo].[ProjectCategoryProjects] ([ProjectCategory_ID], [Project_ID]) VALUES (1, 2)
                INSERT [dbo].[ProjectCategoryProjects] ([ProjectCategory_ID], [Project_ID]) VALUES (5, 2)
                ");
        }
        
        public override void Down()
        {
        }
    }
}
