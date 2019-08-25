namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteIsManagerAndAddUserRoleToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "IsManager");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsManager", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
    }
}
