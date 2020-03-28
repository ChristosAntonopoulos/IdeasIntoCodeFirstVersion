namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureAndDescriptionToDeveloper : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Developers", "Description");
        }
    }
}
