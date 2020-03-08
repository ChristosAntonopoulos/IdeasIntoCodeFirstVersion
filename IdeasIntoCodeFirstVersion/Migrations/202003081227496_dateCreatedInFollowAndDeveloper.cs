namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateCreatedInFollowAndDeveloper : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Follows", "FollowStarted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Follows", "FollowStarted");
            DropColumn("dbo.Developers", "DateCreated");
        }
    }
}
