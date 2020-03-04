namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowerID = c.Int(nullable: false),
                        FolloweeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FollowerID, t.FolloweeID })
                .ForeignKey("dbo.Developers", t => t.FollowerID, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.FolloweeID)
                .Index(t => t.FollowerID)
                .Index(t => t.FolloweeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FolloweeID", "dbo.Developers");
            DropForeignKey("dbo.Follows", "FollowerID", "dbo.Developers");
            DropIndex("dbo.Follows", new[] { "FolloweeID" });
            DropIndex("dbo.Follows", new[] { "FollowerID" });
            DropTable("dbo.Follows");
        }
    }
}
