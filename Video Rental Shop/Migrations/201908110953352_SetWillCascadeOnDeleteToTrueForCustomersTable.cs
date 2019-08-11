namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetWillCascadeOnDeleteToTrueForCustomersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Memberships", "Id", "dbo.Customers");
            AddForeignKey("dbo.Memberships", "Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Memberships", "Id", "dbo.Customers");
            AddForeignKey("dbo.Memberships", "Id", "dbo.Customers", "Id");
        }
    }
}
