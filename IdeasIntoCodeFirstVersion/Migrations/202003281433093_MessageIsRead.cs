namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageIsRead : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "IsRead");
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsRead");
        }
    }
}
