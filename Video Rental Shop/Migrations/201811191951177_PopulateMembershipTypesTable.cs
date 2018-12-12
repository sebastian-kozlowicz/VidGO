namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SingUpFee, DiscountRate) VALUES (1, 'Pay as You Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SingUpFee, DiscountRate) VALUES (2, 'Monthly', 1, 20, 10)");
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SingUpFee, DiscountRate) VALUES (3, 'Quarterly', 4, 80, 15)");
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SingUpFee, DiscountRate) VALUES (4, 'Annual', 12, 240, 20)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM MembershipTypes");
        }
    }
}
