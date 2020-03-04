namespace IdeasIntoCodeFirstVersion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesProgrammingLanguages : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProgrammingLanguages (Name) VALUES ('c#')");
            Sql("INSERT INTO ProgrammingLanguages (Name) VALUES ('java')");
            Sql("INSERT INTO ProgrammingLanguages (Name) VALUES ('python')");
            Sql("INSERT INTO ProgrammingLanguages (Name) VALUES ('javascript')");
            Sql("INSERT INTO ProgrammingLanguages (Name) VALUES ('CSS!!!!!')");
            Sql("INSERT INTO ProjectCategories (Name) VALUES ('Games')");
            Sql("INSERT INTO ProjectCategories (Name) VALUES ('Entertainment')");
            Sql("INSERT INTO ProjectCategories (Name) VALUES ('Social')");
            Sql("INSERT INTO ProjectCategories (Name) VALUES ('Food')");
            Sql("INSERT INTO ProjectCategories (Name) VALUES ('Shopping')");
        }
        
        public override void Down()
        {
        }
    }
}
