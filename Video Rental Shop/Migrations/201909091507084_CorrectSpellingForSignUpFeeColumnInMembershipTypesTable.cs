namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectSpellingForSignUpFeeColumnInMembershipTypesTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.MembershipTypes", "SingUpFee", "SignUpFee");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.MembershipTypes", "SignUpFee", "SingUpFee");
        }
    }
}
