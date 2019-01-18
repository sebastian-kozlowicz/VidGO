namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGamePlatformsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GamePlatforms (Id, Name) VALUES (1, 'PC')");
            Sql("INSERT INTO GamePlatforms (Id, Name) VALUES (2, 'PlayStation 3')");
            Sql("INSERT INTO GamePlatforms (Id, Name) VALUES (3, 'PlayStation 4')");
            Sql("INSERT INTO GamePlatforms (Id, Name) VALUES (4, 'Xbox 360')");
            Sql("INSERT INTO GamePlatforms (Id, Name) VALUES (5, 'Xbox One')");
        }

        public override void Down()
        {
            Sql("DELETE FROM GamePlatforms");
        }
    }
}
