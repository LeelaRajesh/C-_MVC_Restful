namespace MVCappli_rest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES(genre) VALUES('Comedy')");
            Sql("INSERT INTO GENRES(genre) VALUES('Action')");
            Sql("INSERT INTO GENRES(genre) VALUES('Family')");
            Sql("INSERT INTO GENRES(genre) VALUES('Romance')");
            
        }
        
        public override void Down()
        {
        }
    }
}
