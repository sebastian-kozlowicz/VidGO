namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGamePlatformColumnToGamesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "GamePlatformId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Games", "GamePlatformId");
            AddForeignKey("dbo.Games", "GamePlatformId", "dbo.GamePlatforms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GamePlatformId", "dbo.GamePlatforms");
            DropIndex("dbo.Games", new[] { "GamePlatformId" });
            DropColumn("dbo.Games", "GamePlatformId");
        }
    }
}
