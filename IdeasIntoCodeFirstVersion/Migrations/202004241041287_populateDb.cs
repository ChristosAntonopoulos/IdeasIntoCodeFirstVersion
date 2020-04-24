namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateDb : DbMigration
    {
        public override void Up()
        {
            Sql(@"USE [IdeasIntoCodeFirstVersionDataBase] 
                GO
INSERT[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [LastName], [Name]) VALUES(N'389338c6-302e-4840-88b9-b6029fb00d47', N'fil@hotmail.com', 0, N'AH7sn24hSVqkXImD1dpZuog59Lql2SzoE4AP1kvh53Y63Hphzifwwglid0dkB+GDzw==', N'18d6dfe8-3f2d-40a5-8afb-8732c2664921', NULL, 0, 0, NULL, 1, 0, N'fil@hotmail.com', N'Kont', N'Fil')
INSERT[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [LastName], [Name]) VALUES(N'7a9325dc-2e5d-4400-bfb5-2fb59e4a48a2', N'teo@hotmail.com', 0, N'AEn8ndZr7MeNueQtt/3SX7GRC6tL370R9HwseitAwaGvuTTYS1RccjcO+8kCup+jXQ==', N'77b53c1a-2f07-43c1-a7f7-a8b0198e5467', NULL, 0, 0, NULL, 1, 0, N'teo@hotmail.com', N'Tsap', N'Teo')
INSERT[dbo].[AspNetUsers]
        ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [LastName], [Name]) VALUES(N'9b8c9eb2-2d78-4765-a2bd-3c2c891e839c', N'bot@hotmail.com', 0, N'AKH1R5dQchjw0XpYdW5YYQw1W1O2zTYPKrqMAtA3xwnkYGCyyFZHRj8CtfcI6N2SWQ==', N'79bf8228-ba89-4887-bbf3-fe9b1c43001f', NULL, 0, 0, NULL, 1, 0, N'bot@hotmail.com', N'Ant', N'Chris')
INSERT[dbo].[AspNetUsers]
        ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [LastName], [Name]) VALUES(N'c8b92021-4913-4a83-a79f-4d56ef1a12bc', N'dom@hotmail.com', 0, N'AHwRSv56IqyUy9OAvUXpZZL2FmzVKCb/g9XNktSATD6mr/2dFQC8FElUmN+Nuq1VyA==', N'c38c5553-57f6-4086-91cb-53b3e3f9ba05', NULL, 0, 0, NULL, 1, 0, N'dom@hotmail.com', N'Che', N'Domi')
SET IDENTITY_INSERT[dbo].[Developers]
        ON

INSERT[dbo].[Developers] ([ID], [BirthDate], [GitHub], [UserID], [DateCreated], [Picture], [Description], [Linkedin]) VALUES(1, CAST(N'1990-10-01T00:00:00.0000000' AS DateTime2), N'www.github.com/botgithub', N'9b8c9eb2-2d78-4765-a2bd-3c2c891e839c', CAST(N'2020-03-16T20:16:01.520' AS DateTime), N'1075605a-6f18-4f8c-bdc0-ff6620554bb1DeathNote.png', N'I''m not the monster he wants me to be. So I''m neither man nor beast. I''m something new entirely. With my own set of rules. I''m Dexter. Boo. I''m really more an apartment person. Makes me a … scientist.', N'www.linkedin.com/in/bot')
INSERT[dbo].[Developers] ([ID], [BirthDate], [GitHub], [UserID], [DateCreated], [Picture], [Description], [Linkedin]) VALUES(2, CAST(N'1993-10-25T00:00:00.0000000' AS DateTime2), N'www.github.com/domgithub', N'c8b92021-4913-4a83-a79f-4d56ef1a12bc', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'23840363-5f32-4b60-9e27-7a6b73a0e93dbike.jpg', N'(The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.', N'www.linkedin.com/in/dom')
INSERT[dbo].[Developers] ([ID], [BirthDate], [GitHub], [UserID], [DateCreated], [Picture], [Description], [Linkedin]) VALUES(3, CAST(N'1995-10-10T00:00:00.0000000' AS DateTime2), N'www.github.com/filgithub', N'389338c6-302e-4840-88b9-b6029fb00d47', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'0c46e504-d2b9-4b7d-b1c6-b5041d899991Pao13.jfif', N'I''m doing mental jumping jacks. Finding a needle in a haystack isn''t hard when every straw is computerized. I will not kill my sister. I will not kill my sister. I will not kill my sister. Only you could make those words cute', N'www.linkedin.com/in/filippos')
INSERT[dbo].[Developers] ([ID], [BirthDate], [GitHub], [UserID], [DateCreated], [Picture], [Description], [Linkedin]) VALUES(4, CAST(N'1965-01-01T00:00:00.0000000' AS DateTime2), N'www.github.com/teogithub', N'7a9325dc-2e5d-4400-bfb5-2fb59e4a48a2', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'74469f9b-9f28-4b5d-a49b-c1d8e27520afDnd.jfif', N'This man is a knight in shining armor. Like a sloth. I can do that. Oh I beg to differ, I think we have a lot to discuss. After all, you are a client. Watching ice melt. This is fun. God created pudding, and then he rested.', N'www.linkedin.com/in/teo')
SET IDENTITY_INSERT[dbo].[Developers]
        OFF
SET IDENTITY_INSERT[dbo].[Projects]
        ON

INSERT[dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES(1, N'IdeasIntoCOde', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ', 0, 4, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT[dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES(2, N'GamersGrid', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ', 0, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT[dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES(3, N'Humanity', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ', 1, 3, CAST(N'2020-03-11T13:31:09.210' AS DateTime))
INSERT[dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES(4, N'Cakefactory', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ', 1, 2, CAST(N'2020-03-11T13:31:09.210' AS DateTime))
INSERT[dbo].[Projects] ([ID], [Title], [Description], [Active], [AdminID], [TimeStamp]) VALUES(5, N'Barscanner', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ', 0, 2, CAST(N'2020-03-11T13:31:09.210' AS DateTime))
SET IDENTITY_INSERT[dbo].[Projects]
        OFF
SET IDENTITY_INSERT[dbo].[Notifications]
        ON

INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(1, CAST(N'2020-03-29T12:12:57.330' AS DateTime), 1, 2, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(2, CAST(N'2020-03-29T12:13:05.393' AS DateTime), 1, 2, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(3, CAST(N'2020-03-29T12:13:10.437' AS DateTime), 1, 2, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(4, CAST(N'2020-03-29T12:15:28.810' AS DateTime), 1, 1, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(5, CAST(N'2020-03-29T12:15:32.127' AS DateTime), 1, 1, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(6, CAST(N'2020-03-29T12:15:38.153' AS DateTime), 1, 1, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(7, CAST(N'2020-03-29T12:20:51.343' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(8, CAST(N'2020-03-29T12:20:55.033' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(9, CAST(N'2020-03-29T12:24:14.553' AS DateTime), 1, 3, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(10, CAST(N'2020-03-29T12:24:21.157' AS DateTime), 1, 3, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(11, CAST(N'2020-04-02T14:09:47.373' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(12, CAST(N'2020-04-02T14:17:45.900' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(13, CAST(N'2020-04-02T14:17:49.397' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(14, CAST(N'2020-04-02T14:32:06.793' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(15, CAST(N'2020-04-02T14:37:15.767' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(16, CAST(N'2020-04-02T14:37:17.973' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(17, CAST(N'2020-04-02T14:42:52.127' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(18, CAST(N'2020-04-02T14:44:33.750' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(19, CAST(N'2020-04-02T14:50:24.743' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(20, CAST(N'2020-04-02T14:50:29.883' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(21, CAST(N'2020-04-02T14:51:05.907' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(22, CAST(N'2020-04-02T16:02:24.193' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(23, CAST(N'2020-04-02T16:22:27.437' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(24, CAST(N'2020-04-02T16:22:29.110' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(25, CAST(N'2020-04-02T16:22:29.840' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(26, CAST(N'2020-04-02T16:22:30.533' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(27, CAST(N'2020-04-02T16:22:32.503' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(28, CAST(N'2020-04-02T16:22:45.793' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(29, CAST(N'2020-04-02T16:23:40.903' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(30, CAST(N'2020-04-02T16:24:19.633' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(31, CAST(N'2020-04-02T16:24:21.070' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(32, CAST(N'2020-04-02T16:24:22.047' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(33, CAST(N'2020-04-02T16:26:09.847' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(34, CAST(N'2020-04-02T16:26:43.210' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(35, CAST(N'2020-04-02T16:26:44.393' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(36, CAST(N'2020-04-02T16:26:44.800' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(37, CAST(N'2020-04-02T16:26:45.167' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(38, CAST(N'2020-04-02T16:26:48.087' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(39, CAST(N'2020-04-02T16:26:52.160' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(40, CAST(N'2020-04-02T16:27:04.460' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(41, CAST(N'2020-04-02T16:27:05.853' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(42, CAST(N'2020-04-02T16:27:12.507' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(43, CAST(N'2020-04-02T16:27:24.803' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(44, CAST(N'2020-04-02T16:27:30.943' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(45, CAST(N'2020-04-02T16:28:03.160' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(46, CAST(N'2020-04-02T16:28:03.533' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(47, CAST(N'2020-04-02T16:28:04.333' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(48, CAST(N'2020-04-02T16:28:05.420' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(49, CAST(N'2020-04-02T16:28:06.537' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(50, CAST(N'2020-04-07T14:47:12.410' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(51, CAST(N'2020-04-07T15:11:43.473' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(52, CAST(N'2020-04-07T15:11:44.303' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(53, CAST(N'2020-04-07T15:11:45.210' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(54, CAST(N'2020-04-15T19:10:55.550' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(55, CAST(N'2020-04-15T19:10:56.543' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(56, CAST(N'2020-04-15T19:10:57.387' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(57, CAST(N'2020-04-15T19:11:13.983' AS DateTime), 2, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(58, CAST(N'2020-04-15T20:18:21.567' AS DateTime), 2, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(59, CAST(N'2020-04-15T20:18:26.450' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(60, CAST(N'2020-04-19T03:30:54.757' AS DateTime), 2, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(61, CAST(N'2020-04-19T03:31:01.943' AS DateTime), 2, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(62, CAST(N'2020-04-19T03:31:04.210' AS DateTime), 1, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(63, CAST(N'2020-04-19T22:52:22.127' AS DateTime), 2, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(64, CAST(N'2020-04-19T22:52:27.190' AS DateTime), 2, 4, NULL)
INSERT[dbo].[Notifications] ([ID], [TimeStamp], [Type], [Developer_ID], [Project_ID]) VALUES(65, CAST(N'2020-04-19T22:52:28.807' AS DateTime), 1, 4, NULL)
SET IDENTITY_INSERT[dbo].[Notifications]
        OFF
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 4, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 5, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 6, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 54, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 55, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 56, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 57, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 63, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 64, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(1, 65, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(2, 1, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(2, 2, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(2, 3, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(2, 58, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(2, 59, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(2, 60, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(2, 61, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(2, 62, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(3, 9, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(3, 10, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(3, 51, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(3, 52, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(3, 53, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 7, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 8, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 11, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 12, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 13, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 14, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 15, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 16, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 17, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 18, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 19, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 20, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 21, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 22, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 23, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 24, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 25, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 26, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 27, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 28, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 29, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 30, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 31, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 32, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 33, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 34, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 35, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 36, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 37, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 38, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 39, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 40, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 41, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 42, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 43, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 44, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 45, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 46, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 47, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 48, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 49, 0)
INSERT[dbo].[DeveloperNotifications]
        ([DeveloperID], [NotificationId], [IsRead]) VALUES(4, 50, 0)
SET IDENTITY_INSERT[dbo].[Messages]
        ON

INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(1, N'Lorem Ipsum', N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 2, 4, CAST(N'2020-03-29T12:32:18.600' AS DateTime), 1)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(2, N'Lorem Ipsum', N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 2, 3, CAST(N'2020-03-29T12:32:34.527' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(3, N'Lorem Ipsum', N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 2, 1, CAST(N'2020-03-29T12:33:01.440' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(4, N'Lorem Ipsum', N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 4, 1, CAST(N'2020-03-29T12:34:53.137' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(5, N'Lorem Ipsum', N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 4, 3, CAST(N'2020-03-29T12:35:02.127' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(6, N'Lorem Ipsum', N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 2, 1, CAST(N'2020-03-29T12:35:37.910' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(7, N'Lorem Ipsum', N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 2, 3, CAST(N'2020-03-29T12:36:00.737' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(8, N'fwefwe', N'aedvwevwev', 4, 1, CAST(N'2020-04-15T19:11:13.983' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(9, N'cacd', N'acegvqev', 4, 2, CAST(N'2020-04-15T20:18:21.567' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(10, N'cqwefvwev', N'wevqwevwvw', 4, 2, CAST(N'2020-04-19T03:30:54.757' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(11, N'wevwvw', N'wevwvwv', 4, 2, CAST(N'2020-04-19T03:31:01.943' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(12, N'scwv', N'wevwev', 4, 1, CAST(N'2020-04-19T22:52:22.127' AS DateTime), 0)
INSERT[dbo].[Messages] ([ID], [Subject], [Text], [SenderID], [ReceiverID], [DatePosted], [IsRead]) VALUES(13, N'sadv', N'wevwev', 4, 1, CAST(N'2020-04-19T22:52:27.190' AS DateTime), 0)
SET IDENTITY_INSERT[dbo].[Messages]
        OFF
SET IDENTITY_INSERT[dbo].[Comments]
        ON

INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pellentesque orci eget placerat volutpat. Cras feugiat mauris pharetra feugiat pretium. Integer vulputate nisl sem, eu vestibulum mauris viverra vitae. Etiam congue, justo lobortis scelerisque pellentesque, odio risus cursus lorem, et tempor purus velit et risus. ', 2, 1, CAST(N'2020-03-29T12:13:46.870' AS DateTime))
INSERT[dbo].[Comments]
        ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(2, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pellentesque orci eget placerat volutpat. Cras feugiat mauris pharetra feugiat pretium. Integer vulputate nisl sem, eu vestibulum mauris viverra vitae. Etiam congue, justo lobortis scelerisque pellentesque, odio risus cursus lorem, et tempor purus velit et risus. 
', 2, 2, CAST(N'2020-03-29T12:14:34.440' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES (3, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pellentesque orci eget placerat volutpat. Cras feugiat mauris pharetra feugiat pretium. Integer vulputate nisl sem, eu vestibulum mauris viverra vitae. Etiam congue, justo lobortis scelerisque pellentesque, odio risus cursus lorem, et tempor purus velit et risus. ', 2, 4, CAST(N'2020-03-29T12:14:44.327' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(4, N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 4, 2, CAST(N'2020-03-29T12:21:34.233' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(5, N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 4, 4, CAST(N'2020-03-29T12:22:36.067' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(6, N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 4, 1, CAST(N'2020-03-29T12:23:32.383' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(7, N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 3, 3, CAST(N'2020-03-29T12:24:35.837' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(8, N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 3, 1, CAST(N'2020-03-29T12:24:47.743' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(9, N' Donec mollis nisi in justo scelerisque, ac lacinia justo feugiat. Sed accumsan ornare quam, vel commodo arcu dictum nec. Donec quis finibus massa. Pellentesque fringilla, sem ac laoreet sollicitudin, tortor lorem accumsan turpis, eget fringilla ipsum leo et libero. Mauris eleifend metus vel mattis tempus', 3, 4, CAST(N'2020-03-29T12:25:01.603' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(10, N'asqevqefwf', 4, 1, CAST(N'2020-04-07T15:05:58.107' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(11, N's vs vwvwv', 4, 2, CAST(N'2020-04-15T19:11:23.450' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(12, N'jjhjj', 4, 1, CAST(N'2020-04-17T20:44:21.347' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(13, N'kgtirf', 4, 1, CAST(N'2020-04-17T20:45:24.847' AS DateTime))
INSERT[dbo].[Comments] ([ID], [Text], [DeveloperID], [ProjectID], [TimeStamp]) VALUES(14, N'dvdsvvvvwsvqwe', 4, 2, CAST(N'2020-04-19T22:53:06.053' AS DateTime))
SET IDENTITY_INSERT[dbo].[Comments]
        OFF
SET IDENTITY_INSERT[dbo].[ProgrammingLanguages]
        ON

INSERT[dbo].[ProgrammingLanguages]
        ([ID], [Name]) VALUES(1, N'c#')
INSERT[dbo].[ProgrammingLanguages]
        ([ID], [Name]) VALUES(2, N'java')
INSERT[dbo].[ProgrammingLanguages]
        ([ID], [Name]) VALUES(3, N'python')
INSERT[dbo].[ProgrammingLanguages]
        ([ID], [Name]) VALUES(4, N'javascript')
INSERT[dbo].[ProgrammingLanguages]
        ([ID], [Name]) VALUES(5, N'CSS!!!!!')
SET IDENTITY_INSERT[dbo].[ProgrammingLanguages]
        OFF
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(1, 1)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(3, 1)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(4, 1)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(5, 1)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(1, 2)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(2, 2)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(2, 3)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(3, 3)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(2, 4)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(3, 4)
INSERT[dbo].[ProgrammingLanguageDevelopers]
        ([ProgrammingLanguage_ID], [Developer_ID]) VALUES(4, 4)
INSERT[dbo].[Teams]
        ([ProjectID]) VALUES(1)
INSERT[dbo].[Teams]
        ([ProjectID]) VALUES(2)
INSERT[dbo].[Teams]
        ([ProjectID]) VALUES(3)
INSERT[dbo].[Teams]
        ([ProjectID]) VALUES(4)
INSERT[dbo].[Teams]
        ([ProjectID]) VALUES(5)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(1, 1)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(3, 1)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(4, 1)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(1, 2)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(2, 2)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(3, 2)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(1, 3)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(2, 3)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(2, 4)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(3, 4)
INSERT[dbo].[TeamDevelopers]
        ([Team_ProjectID], [Developer_ID]) VALUES(4, 4)
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(1, 2, CAST(N'2020-03-29T12:15:28.810' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(1, 3, CAST(N'2020-03-29T12:15:32.127' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(1, 4, CAST(N'2020-03-29T12:15:38.153' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(2, 1, CAST(N'2020-03-29T12:12:57.330' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(2, 3, CAST(N'2020-03-29T12:13:05.393' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(2, 4, CAST(N'2020-03-29T12:13:10.437' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(3, 1, CAST(N'2020-03-29T12:24:14.553' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(3, 4, CAST(N'2020-03-29T12:24:21.157' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(4, 1, CAST(N'2020-04-19T22:52:28.807' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(4, 2, CAST(N'2020-04-19T03:31:04.210' AS DateTime))
INSERT[dbo].[Follows] ([FollowerID], [FolloweeID], [TimeStamp]) VALUES(4, 3, CAST(N'2020-04-07T15:11:45.210' AS DateTime))
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(1, 1)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(2, 1)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(3, 1)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(3, 2)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(4, 2)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(2, 3)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(3, 3)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(3, 4)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(1, 5)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(3, 5)
INSERT[dbo].[ProgrammingLanguageProjects]
        ([Project_ID], [ProgrammingLanguage_ID]) VALUES(4, 5)
SET IDENTITY_INSERT[dbo].[ProjectCategories]
        ON

INSERT[dbo].[ProjectCategories]
        ([ID], [Name]) VALUES(1, N'Games')
INSERT[dbo].[ProjectCategories]
        ([ID], [Name]) VALUES(2, N'Entertainment')
INSERT[dbo].[ProjectCategories]
        ([ID], [Name]) VALUES(3, N'Social')
INSERT[dbo].[ProjectCategories]
        ([ID], [Name]) VALUES(4, N'Food')
INSERT[dbo].[ProjectCategories]
        ([ID], [Name]) VALUES(5, N'Shopping')
SET IDENTITY_INSERT[dbo].[ProjectCategories]
        OFF
INSERT[dbo].[ProjectCategoryProjects]
        ([ProjectCategory_ID], [Project_ID]) VALUES(1, 1)
INSERT[dbo].[ProjectCategoryProjects]
        ([ProjectCategory_ID], [Project_ID]) VALUES(3, 2)
INSERT[dbo].[ProjectCategoryProjects]
        ([ProjectCategory_ID], [Project_ID]) VALUES(1, 3)
INSERT[dbo].[ProjectCategoryProjects]
        ([ProjectCategory_ID], [Project_ID]) VALUES(4, 4)
");
        }
        
        public override void Down()
        {
        }
    }
}
