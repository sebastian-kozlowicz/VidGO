namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameGenres : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Games DROP CONSTRAINT [FK_dbo.Games_dbo.Genres_GenreId]");

            DropForeignKey("dbo.Games", "GenreId", "dbo.MovieGenres");
            DropIndex("dbo.Games", new[] { "GenreId" });
            CreateTable(
                "dbo.GameGenres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "GameGenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Games", "GameGenreId");
            AddForeignKey("dbo.Games", "GameGenreId", "dbo.GameGenres", "Id", cascadeDelete: true);
            DropColumn("dbo.Games", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "GenreId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Games", "GameGenreId", "dbo.GameGenres");
            DropIndex("dbo.Games", new[] { "GameGenreId" });
            DropColumn("dbo.Games", "GameGenreId");
            DropTable("dbo.GameGenres");
            CreateIndex("dbo.Games", "GenreId");
            AddForeignKey("dbo.Games", "GenreId", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
    }
}
