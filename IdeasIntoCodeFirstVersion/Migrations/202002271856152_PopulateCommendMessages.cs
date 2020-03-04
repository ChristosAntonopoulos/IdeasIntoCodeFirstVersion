namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCommendMessages : DbMigration
    {
        public override void Up()
        {
            Sql(@"USE [IdeasIntoCodeFirstVersionDataBase]
                GO
                SET IDENTITY_INSERT [dbo].[Comments] ON
                INSERT [dbo].[Comments] ([ID], [Text], [DateAdded], [DeveloperID], [ProjectID]) VALUES (1, N'CommentText1', CAST(N'2020-02-27T00:00:00.000' AS DateTime), 1, 1)
                INSERT [dbo].[Comments] ([ID], [Text], [DateAdded], [DeveloperID], [ProjectID]) VALUES (2, N'CommentText2', CAST(N'2020-02-25T00:00:00.000' AS DateTime), 2, 1)
                INSERT [dbo].[Comments] ([ID], [Text], [DateAdded], [DeveloperID], [ProjectID]) VALUES (3, N'CommentText3', CAST(N'2020-02-21T00:00:00.000' AS DateTime), 3, 1)
                SET IDENTITY_INSERT [dbo].[Comments] OFF
                SET IDENTITY_INSERT [dbo].[Messages] ON
                INSERT [dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted]) VALUES (1, N'TestSubject1', N'asdaasfasfasd', 1, 2, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
                INSERT [dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted]) VALUES (2, N'TestSubject2', N'cvxcvxvcbxcbvxcb', 1, 3, CAST(N'2020-01-02T00:00:00.000' AS DateTime))
                INSERT [dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted]) VALUES (3, N'TestSubject3', N'jo;j;kj;ljk;', 2, 3, CAST(N'2020-03-03T00:00:00.000' AS DateTime))
                INSERT [dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted]) VALUES (4, N'TestSubject4', N'reotuieiotueio', 3, 1, CAST(N'2020-02-02T00:00:00.000' AS DateTime))
                SET IDENTITY_INSERT [dbo].[Messages] OFF
                ");
        }
        
        public override void Down()
        {
        }
    }
}
