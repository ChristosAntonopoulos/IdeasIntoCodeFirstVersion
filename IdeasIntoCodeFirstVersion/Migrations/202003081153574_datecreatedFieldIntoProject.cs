namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datecreatedFieldIntoProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "DateCreated");
        }
    }
}
