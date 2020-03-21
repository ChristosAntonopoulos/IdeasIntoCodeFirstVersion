namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveNamaFullnameLastNameToApplicationUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Developers", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.Developers", name: "IX_User_Id", newName: "IX_UserID");
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Developers", "LastName");
            DropColumn("dbo.Developers", "Name");
            DropColumn("dbo.Developers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Developers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Developers", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Developers", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "LastName");
            RenameIndex(table: "dbo.Developers", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Developers", name: "UserID", newName: "User_Id");
        }
    }
}
