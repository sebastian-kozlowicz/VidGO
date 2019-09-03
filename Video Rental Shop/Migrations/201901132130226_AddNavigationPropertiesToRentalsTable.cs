namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavigationPropertiesToRentalsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Rentals", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Rentals", name: "Game_Id", newName: "GameId");
            RenameColumn(table: "dbo.Rentals", name: "Movie_Id", newName: "MovieId");
            RenameIndex(table: "dbo.Rentals", name: "IX_Movie_Id", newName: "IX_MovieId");
            RenameIndex(table: "dbo.Rentals", name: "IX_Game_Id", newName: "IX_GameId");
            AlterColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "CustomerId");
            AddForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            AlterColumn("dbo.Rentals", "CustomerId", c => c.Int());
            RenameIndex(table: "dbo.Rentals", name: "IX_GameId", newName: "IX_Game_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_MovieId", newName: "IX_Movie_Id");
            RenameColumn(table: "dbo.Rentals", name: "MovieId", newName: "Movie_Id");
            RenameColumn(table: "dbo.Rentals", name: "GameId", newName: "Game_Id");
            RenameColumn(table: "dbo.Rentals", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
