namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetWillCascadeOnDeleteToTrueForMoviesTableInRentalsRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "MovieId", "dbo.Movies");
            AddForeignKey("dbo.Rentals", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "MovieId", "dbo.Movies");
            AddForeignKey("dbo.Rentals", "MovieId", "dbo.Movies", "Id");
        }
    }
}
