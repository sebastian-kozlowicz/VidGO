namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGenresToMovieGenres : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Genres", newName: "MovieGenres");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "MovieGenreId");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId", newName: "IX_MovieGenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_MovieGenreId", newName: "IX_GenreId");
            RenameColumn(table: "dbo.Movies", name: "MovieGenreId", newName: "GenreId");
            RenameTable(name: "dbo.MovieGenres", newName: "Genres");
        }
    }
}
