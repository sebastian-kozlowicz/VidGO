namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AssignDate = c.DateTime(),
                        ExpiryDate = c.DateTime(),
                        MembershipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.MembershipTypeId);
            
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Memberships", "Id", "dbo.Customers");
            DropForeignKey("dbo.Memberships", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Memberships", new[] { "MembershipTypeId" });
            DropIndex("dbo.Memberships", new[] { "Id" });
            DropTable("dbo.Memberships");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
