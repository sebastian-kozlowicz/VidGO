namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGameGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GameGenres (Id, Name) VALUES (1, 'Strategy')");
            Sql("INSERT INTO GameGenres (Id, Name) VALUES (2, 'Simulation')");
            Sql("INSERT INTO GameGenres (Id, Name) VALUES (3, 'Adventure')");
            Sql("INSERT INTO GameGenres (Id, Name) VALUES (4, 'Action')");
            Sql("INSERT INTO GameGenres (Id, Name) VALUES (5, 'Stealth Shooter')");
            Sql("INSERT INTO GameGenres (Id, Name) VALUES (6, 'Combat')");
            Sql("INSERT INTO GameGenres (Id, Name) VALUES (7, 'Educational')");
            Sql("INSERT INTO GameGenres (Id, Name) VALUES (8, 'Role-Playing')");
        }

        public override void Down()
        {
            Sql("DELETE FROM GameGenres");
        }
    }
}
