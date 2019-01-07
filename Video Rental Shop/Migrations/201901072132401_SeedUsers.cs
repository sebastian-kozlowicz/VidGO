namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"  INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'26701bd2-1051-4f88-b7eb-fae6ec5b387d', N'guest@gmail.com', 0, N'ABhY7wjc0nVzhlF0f3YWthgK8yeSI6xlFJBMNff7UCL52azvQurAsVIs5GewHCzVcw==', N'1e8c3b3a-481f-4601-8f4c-0387a8d3e7aa', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f159b3e7-fa5d-4877-b32a-f52646af0d20', N'admin@gmail.com', 0, N'AGxArz/C+ubeUTT2Xs3iFyd0mJ5PYzPcBMyh81yWGKmSU6IgLHcVqPKqEcpwA0CwRg==', N'9d090c72-d116-402c-8867-f94c68da3bde', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'372257fb-f1f8-4690-976f-60b36b870a93', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f159b3e7-fa5d-4877-b32a-f52646af0d20', N'372257fb-f1f8-4690-976f-60b36b870a93')
            ");
        }

        public override void Down()
        {
        }
    }
}
