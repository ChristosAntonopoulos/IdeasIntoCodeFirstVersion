namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMessagesFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "SenderID", "dbo.Developers");
            AddForeignKey("dbo.Messages", "SenderID", "dbo.Developers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderID", "dbo.Developers");
            AddForeignKey("dbo.Messages", "SenderID", "dbo.Developers", "ID", cascadeDelete: true);
        }
    }
}
