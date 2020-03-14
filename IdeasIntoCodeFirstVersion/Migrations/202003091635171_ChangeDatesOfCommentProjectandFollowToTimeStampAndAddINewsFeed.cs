namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDatesOfCommentProjectandFollowToTimeStampAndAddINewsFeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "TimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Follows", "TimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "TimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.Comments", "DateAdded");
            DropColumn("dbo.Follows", "FollowStarted");
            DropColumn("dbo.Projects", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Follows", "FollowStarted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "DateAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.Projects", "TimeStamp");
            DropColumn("dbo.Follows", "TimeStamp");
            DropColumn("dbo.Comments", "TimeStamp");
        }
    }
}
