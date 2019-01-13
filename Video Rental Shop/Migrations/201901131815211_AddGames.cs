namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGames : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(),
                        NumberInStock = c.Int(),
                        NumberAvailable = c.Int(),
                        GenreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            AddColumn("dbo.Rentals", "Game_Id", c => c.Int());
            CreateIndex("dbo.Rentals", "Game_Id");
            AddForeignKey("dbo.Rentals", "Game_Id", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropIndex("dbo.Rentals", new[] { "Game_Id" });
            DropIndex("dbo.Games", new[] { "GenreId" });
            DropColumn("dbo.Rentals", "Game_Id");
            DropTable("dbo.Games");
        }
    }
}
