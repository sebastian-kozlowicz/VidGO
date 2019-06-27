namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceToGamesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Price");
        }
    }
}
