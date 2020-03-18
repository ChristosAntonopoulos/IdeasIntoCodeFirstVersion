namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDB : DbMigration
    {
        public override void Up()
        {
            Sql(@"USE [IdeasIntoCodeFirstVersionDataBase]
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'14cbb35a-d9b7-4f75-ad01-5f7912898cbf', N'chrisantonopoulos@hotmail.com', 0, N'ALxYpiWMzvpEKU4TL1dlUOaBO3X+jnp/hkODUMALZIJFL0uKAAMEV3t7VVrmFZxz4w==', N'a0c02686-0ce5-481a-b677-ce2fc88964dd', NULL, 0, 0, NULL, 1, 0, N'chrisantonopoulos@hotmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'389338c6-302e-4840-88b9-b6029fb00d47', N'fil@hotmail.com', 0, N'AH7sn24hSVqkXImD1dpZuog59Lql2SzoE4AP1kvh53Y63Hphzifwwglid0dkB+GDzw==', N'18d6dfe8-3f2d-40a5-8afb-8732c2664921', NULL, 0, 0, NULL, 1, 0, N'fil@hotmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7a9325dc-2e5d-4400-bfb5-2fb59e4a48a2', N'teo@hotmail.com', 0, N'AEn8ndZr7MeNueQtt/3SX7GRC6tL370R9HwseitAwaGvuTTYS1RccjcO+8kCup+jXQ==', N'77b53c1a-2f07-43c1-a7f7-a8b0198e5467', NULL, 0, 0, NULL, 1, 0, N'teo@hotmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9b8c9eb2-2d78-4765-a2bd-3c2c891e839c', N'bot@hotmail.com', 0, N'AKH1R5dQchjw0XpYdW5YYQw1W1O2zTYPKrqMAtA3xwnkYGCyyFZHRj8CtfcI6N2SWQ==', N'79bf8228-ba89-4887-bbf3-fe9b1c43001f', NULL, 0, 0, NULL, 1, 0, N'bot@hotmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c8b92021-4913-4a83-a79f-4d56ef1a12bc', N'dom@hotmail.com', 0, N'AHwRSv56IqyUy9OAvUXpZZL2FmzVKCb/g9XNktSATD6mr/2dFQC8FElUmN+Nuq1VyA==', N'c38c5553-57f6-4086-91cb-53b3e3f9ba05', NULL, 0, 0, NULL, 1, 0, N'dom@hotmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fea62c95-ef3f-4d13-9ce8-086533befc16', N'botsyst3m@hotmail.com', 0, N'AIaYcZXE9p7WaA94jBKJXZyZMv5I7CcLXZkuXF364QFt2/4U/p3lr3wG90MRoTgtcw==', N'04a2c1cb-e59a-4e98-b6c8-e2cc79d26b86', NULL, 0, 0, NULL, 1, 0, N'botsyst3m@hotmail.com')
SET IDENTITY_INSERT [dbo].[Developers] ON 

INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id], [DateCreated], [Picture]) VALUES (1, N'Korompos', N'Nikos', CAST(N'1994-01-01T00:00:00.0000000' AS DateTime2), N'test1@mail', N'test1git', NULL, CAST(N'1900-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id], [DateCreated], [Picture]) VALUES (2, N'Kalantas', N'Kwstas', CAST(N'1993-02-02T00:00:00.0000000' AS DateTime2), N'test2@mail', N'test2git', NULL, CAST(N'1900-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id], [DateCreated], [Picture]) VALUES (3, N'Koukos', N'Nikos', CAST(N'1993-03-03T00:00:00.0000000' AS DateTime2), N'test3@mail', N'test3git', NULL, CAST(N'1900-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id], [DateCreated], [Picture]) VALUES (14, N'Ant', N'Chris', CAST(N'1990-10-01T00:00:00.0000000' AS DateTime2), N'bot@hotmail.com', N'botgithub', N'9b8c9eb2-2d78-4765-a2bd-3c2c891e839c', CAST(N'2020-03-16T20:16:01.520' AS DateTime), NULL)
INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id], [DateCreated], [Picture]) VALUES (19, N'Che', N'Domi', CAST(N'1993-10-25T00:00:00.0000000' AS DateTime2), N'dom@hotmail.com', N'domgithub', N'c8b92021-4913-4a83-a79f-4d56ef1a12bc', CAST(N'1900-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id], [DateCreated], [Picture]) VALUES (21, N'Kont', N'fil', CAST(N'1995-10-10T00:00:00.0000000' AS DateTime2), N'fil@hotmail.com', N'filgithub', N'389338c6-302e-4840-88b9-b6029fb00d47', CAST(N'1900-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Developers] ([ID], [LastName], [Name], [BirthDate], [Email], [GitHub], [User_Id], [DateCreated], [Picture]) VALUES (22, N'Teo', N'teo', CAST(N'1965-01-01T00:00:00.0000000' AS DateTime2), N'teo@hotmail.com', N'teogithub', N'7a9325dc-2e5d-4400-bfb5-2fb59e4a48a2', CAST(N'1900-01-01T00:00:00.000' AS DateTime), NULL)

SET IDENTITY_INSERT [dbo].[Developers] OFF
INSERT [dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES (1, 2, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES (1, 3, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES (3, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES (14, 19, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES (14, 21, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES (14, 22, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES (19, 14, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES (21, 22, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES (22, 21, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Projects] ON 


INSERT [dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES (3, N'IdeasIntoCOde', N'To kalitero whatever project EVER', 0, 22, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES (5, N'GamersGrid', N'Tonight We Dine In Hell', 0, 14, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES (6, N'Humanity', N'fillipe etsi tha gineis TRANOS Developer', 0, 21, CAST(N'2020-03-11T13:31:09.210' AS DateTime))
INSERT [dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES (7, N'Cakefactory', N'miam miam miam', 1, 19, CAST(N'2020-03-11T13:31:09.210' AS DateTime))
INSERT [dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES (8, N'Barscanner', N'mono tsampa pota', 0, 19, CAST(N'2020-03-11T13:31:09.210' AS DateTime))
SET IDENTITY_INSERT [dbo].[Projects] OFF
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES (16, N'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia', 19, 5, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES (17, N'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable.', 22, 5, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES (19, N'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable.', 21, 6, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES (20, N'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don''t look even slightly believable.', 19, 6, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES (21, N'If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.', 14, 7, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES (22, N'If you are going to use a passage of Lorem Ipsum, you need to be sure there isn''t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.', 14, 6, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES (23, N'Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for ''lorem ipsum'' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).', 19, 7, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES (24, N'Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for ''lorem ipsum'' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).', 21, 5, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[ProgrammingLanguages] ON 


INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (1, 1)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (2, 1)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (3, 1)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (1, 2)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (4, 2)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (1, 3)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (2, 3)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (5, 3)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (1, 14)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (3, 14)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (4, 14)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (5, 14)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (1, 19)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (2, 19)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (2, 21)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (3, 21)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (2, 22)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (3, 22)
INSERT [dbo].[ProgrammingLanguageDevelopers] ([ProgrammingLanguage_ID], [Developer_ID]) VALUES (4, 22)

INSERT [dbo].[Teams] ([ProjectID]) VALUES (3)
INSERT [dbo].[Teams] ([ProjectID]) VALUES (5)
INSERT [dbo].[Teams] ([ProjectID]) VALUES (6)
INSERT [dbo].[Teams] ([ProjectID]) VALUES (7)
INSERT [dbo].[Teams] ([ProjectID]) VALUES (8)

INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (5, 14)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (7, 14)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (8, 14)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (5, 19)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (6, 19)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (7, 19)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (8, 19)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (5, 21)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (6, 21)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (5, 22)
INSERT [dbo].[TeamDevelopers] ([Team_ProjectID], [Developer_ID]) VALUES (6, 22)

INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (3, 1)
INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (5, 1)
INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (7, 1)

INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (5, 2)
INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (7, 2)

INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (5, 3)
INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (6, 3)

INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (6, 4)
INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (3, 5)
INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (5, 5)
INSERT [dbo].[ProjectProgrammingLanguages] ([Project_ID], [ProgrammingLanguage_ID]) VALUES (6, 5)




INSERT [dbo].[ProjectCategoryProjects] ([ProjectCategory_ID], [Project_ID]) VALUES (1, 5)
INSERT [dbo].[ProjectCategoryProjects] ([ProjectCategory_ID], [Project_ID]) VALUES (3, 5)
INSERT [dbo].[ProjectCategoryProjects] ([ProjectCategory_ID], [Project_ID]) VALUES (1, 6)
"
                );

        }
        
        public override void Down()
        {
        }
    }
}
