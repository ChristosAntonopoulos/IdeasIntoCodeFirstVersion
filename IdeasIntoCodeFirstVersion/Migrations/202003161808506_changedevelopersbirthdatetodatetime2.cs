namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedevelopersbirthdatetodatetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Developers", "BirthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Developers", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
