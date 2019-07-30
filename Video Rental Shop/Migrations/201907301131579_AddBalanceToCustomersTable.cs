namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBalanceToCustomersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Balance");
        }
    }
}
