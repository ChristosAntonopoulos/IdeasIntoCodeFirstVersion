namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DeveloperID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.DeveloperID)
                .Index(t => t.DeveloperID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        GitHub = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ProgrammingLanguages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Developers", t => t.AdminID, cascadeDelete: true)
                .Index(t => t.AdminID);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        SenderID = c.Int(nullable: false),
                        ReceiverID = c.Int(nullable: false),
                        DatePosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Developers", t => t.ReceiverID)
                .ForeignKey("dbo.Developers", t => t.SenderID, cascadeDelete: true)
                .Index(t => t.SenderID)
                .Index(t => t.ReceiverID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ProgrammingLanguageDevelopers",
                c => new
                    {
                        ProgrammingLanguage_ID = c.Int(nullable: false),
                        Developer_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProgrammingLanguage_ID, t.Developer_ID })
                .ForeignKey("dbo.ProgrammingLanguages", t => t.ProgrammingLanguage_ID, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.Developer_ID, cascadeDelete: true)
                .Index(t => t.ProgrammingLanguage_ID)
                .Index(t => t.Developer_ID);
            
            CreateTable(
                "dbo.ProjectProgrammingLanguages",
                c => new
                    {
                        Project_ID = c.Int(nullable: false),
                        ProgrammingLanguage_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ID, t.ProgrammingLanguage_ID })
                .ForeignKey("dbo.Projects", t => t.Project_ID, cascadeDelete: true)
                .ForeignKey("dbo.ProgrammingLanguages", t => t.ProgrammingLanguage_ID, cascadeDelete: true)
                .Index(t => t.Project_ID)
                .Index(t => t.ProgrammingLanguage_ID);
            
            CreateTable(
                "dbo.ProjectCategoryProjects",
                c => new
                    {
                        ProjectCategory_ID = c.Int(nullable: false),
                        Project_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectCategory_ID, t.Project_ID })
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategory_ID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ID, cascadeDelete: true)
                .Index(t => t.ProjectCategory_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.TeamDevelopers",
                c => new
                    {
                        Team_ProjectID = c.Int(nullable: false),
                        Developer_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_ProjectID, t.Developer_ID })
                .ForeignKey("dbo.Teams", t => t.Team_ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.Developer_ID, cascadeDelete: true)
                .Index(t => t.Team_ProjectID)
                .Index(t => t.Developer_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "DeveloperID", "dbo.Developers");
            DropForeignKey("dbo.Developers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "SenderID", "dbo.Developers");
            DropForeignKey("dbo.Messages", "ReceiverID", "dbo.Developers");
            DropForeignKey("dbo.TeamDevelopers", "Developer_ID", "dbo.Developers");
            DropForeignKey("dbo.TeamDevelopers", "Team_ProjectID", "dbo.Teams");
            DropForeignKey("dbo.Teams", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectCategoryProjects", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.ProjectCategoryProjects", "ProjectCategory_ID", "dbo.ProjectCategories");
            DropForeignKey("dbo.ProjectProgrammingLanguages", "ProgrammingLanguage_ID", "dbo.ProgrammingLanguages");
            DropForeignKey("dbo.ProjectProgrammingLanguages", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.Comments", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "AdminID", "dbo.Developers");
            DropForeignKey("dbo.ProgrammingLanguageDevelopers", "Developer_ID", "dbo.Developers");
            DropForeignKey("dbo.ProgrammingLanguageDevelopers", "ProgrammingLanguage_ID", "dbo.ProgrammingLanguages");
            DropIndex("dbo.TeamDevelopers", new[] { "Developer_ID" });
            DropIndex("dbo.TeamDevelopers", new[] { "Team_ProjectID" });
            DropIndex("dbo.ProjectCategoryProjects", new[] { "Project_ID" });
            DropIndex("dbo.ProjectCategoryProjects", new[] { "ProjectCategory_ID" });
            DropIndex("dbo.ProjectProgrammingLanguages", new[] { "ProgrammingLanguage_ID" });
            DropIndex("dbo.ProjectProgrammingLanguages", new[] { "Project_ID" });
            DropIndex("dbo.ProgrammingLanguageDevelopers", new[] { "Developer_ID" });
            DropIndex("dbo.ProgrammingLanguageDevelopers", new[] { "ProgrammingLanguage_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Messages", new[] { "ReceiverID" });
            DropIndex("dbo.Messages", new[] { "SenderID" });
            DropIndex("dbo.Teams", new[] { "ProjectID" });
            DropIndex("dbo.Projects", new[] { "AdminID" });
            DropIndex("dbo.Developers", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "ProjectID" });
            DropIndex("dbo.Comments", new[] { "DeveloperID" });
            DropTable("dbo.TeamDevelopers");
            DropTable("dbo.ProjectCategoryProjects");
            DropTable("dbo.ProjectProgrammingLanguages");
            DropTable("dbo.ProgrammingLanguageDevelopers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.Teams");
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.Projects");
            DropTable("dbo.ProgrammingLanguages");
            DropTable("dbo.Developers");
            DropTable("dbo.Comments");
        }
    }
}
