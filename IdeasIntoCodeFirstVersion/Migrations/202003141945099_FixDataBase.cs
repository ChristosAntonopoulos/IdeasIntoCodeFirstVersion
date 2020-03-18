namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Developers", "Picture");
        }
    }
}
