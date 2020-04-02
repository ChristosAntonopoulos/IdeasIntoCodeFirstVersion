namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinkedintoDeveloperModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "Linkedin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Developers", "Linkedin");
        }
    }
}
