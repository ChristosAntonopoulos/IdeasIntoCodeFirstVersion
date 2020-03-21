namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotifications : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectProgrammingLanguages", newName: "ProgrammingLanguageProjects");
            DropPrimaryKey("dbo.ProgrammingLanguageProjects");
            CreateTable(
                "dbo.DeveloperNotifications",
                c => new
                    {
                        DeveloperID = c.Int(nullable: false),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeveloperID, t.NotificationId })
                .ForeignKey("dbo.Developers", t => t.DeveloperID, cascadeDelete: true)
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .Index(t => t.DeveloperID)
                .Index(t => t.NotificationId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Developer_ID = c.Int(),
                        Project_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Developers", t => t.Developer_ID)
                .ForeignKey("dbo.Projects", t => t.Project_ID)
                .Index(t => t.Developer_ID)
                .Index(t => t.Project_ID);
            
            AddPrimaryKey("dbo.ProgrammingLanguageProjects", new[] { "ProgrammingLanguage_ID", "Project_ID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.DeveloperNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "Developer_ID", "dbo.Developers");
            DropForeignKey("dbo.DeveloperNotifications", "DeveloperID", "dbo.Developers");
            DropIndex("dbo.Notifications", new[] { "Project_ID" });
            DropIndex("dbo.Notifications", new[] { "Developer_ID" });
            DropIndex("dbo.DeveloperNotifications", new[] { "NotificationId" });
            DropIndex("dbo.DeveloperNotifications", new[] { "DeveloperID" });
            DropPrimaryKey("dbo.ProgrammingLanguageProjects");
            DropTable("dbo.Notifications");
            DropTable("dbo.DeveloperNotifications");
            AddPrimaryKey("dbo.ProgrammingLanguageProjects", new[] { "Project_ID", "ProgrammingLanguage_ID" });
            RenameTable(name: "dbo.ProgrammingLanguageProjects", newName: "ProjectProgrammingLanguages");
        }
    }
}
