namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetWillCascadeOnDeleteToTrueForGamesTableInRentalsRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Rentals", "GameId", "dbo.Games");
            AddForeignKey("dbo.Rentals", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "GameId", "dbo.Games");
            AddForeignKey("dbo.Rentals", "GameId", "dbo.Games", "Id");
        }
    }
}
