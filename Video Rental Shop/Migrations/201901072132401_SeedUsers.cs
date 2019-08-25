namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f159b3e7-fa5d-4877-b32a-f52646af0d20', N'admin@gmail.com', 0, N'AH36n9Y7vtXthrghZ/vzyi+IDnioOIOK2g8VQrsiK8oNP3K4F3ZmKN17gN9d10tzWw==', N'321de6bc-fac3-4896-b290-a563c826ccd4', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'26701bd2-1051-4f88-b7eb-fae6ec5b387d', N'guest@gmail.com', 0, N'ADs4EJWPWS0tj0qgBwspnEaJdTHSb2z+YFlpnoFZdaJrYGaN9dWavk9VVg/N+gferg==', N'b753ba0f-f9cd-45c4-bd8a-a5a706efd6e3', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'372257fb-f1f8-4690-976f-60b36b870a93', N'CanManageProducts')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f159b3e7-fa5d-4877-b32a-f52646af0d20', N'372257fb-f1f8-4690-976f-60b36b870a93')
            ");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM [dbo].[AspNetUsers]
                DELETE FROM [dbo].[AspNetRoles]
                DELETE FROM [dbo].[AspNetUserRoles]
            ");
        }
    }
}
