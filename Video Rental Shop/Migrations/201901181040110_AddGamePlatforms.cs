namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGamePlatforms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamePlatforms",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GamePlatforms");
        }
    }
}
