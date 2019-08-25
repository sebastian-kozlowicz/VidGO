namespace Video_Rental_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAndSeedNewUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"DELETE FROM [dbo].[AspNetUsers]
                DELETE FROM [dbo].[AspNetRoles]
                DELETE FROM [dbo].[AspNetUserRoles]
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserRole]) VALUES (N'26cae2e5-27ab-4b81-b628-9c5432089066', N'employee@demo.com', 0, N'AGeT4dAwD59bMekJvgajNEEBnaITVOgOa54FMtOzHv/EZhnjruShb4l+/006i60l0Q==', N'2d90f2ea-e11e-4c7c-be85-b5809eb88a34', NULL, 0, 0, NULL, 1, 0, N'employee@demo.com', 1)
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserRole]) VALUES (N'807ae916-9f6d-4840-b370-8833b9d7b527', N'guest@demo.com', 0, N'AFWpVwNKPBArRTmMcEkcqBQBlCzjDqe13w5XpmG/0HmsJOmKt01rQ+X5oGhIYFcbEQ==', N'85c61d06-b27d-4340-b2c3-ce35cf559ba5', NULL, 0, 0, NULL, 1, 0, N'guest@demo.com', 2)
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserRole]) VALUES (N'dbba582a-85e4-40f0-b93c-9db4c997cc0c', N'manager@demo.com', 0, N'ADr/6jSqvvg7W4PWkzRq6Jfgc6srn5hyaootRHGPuLifTngOZNslf1zhBIlyzw0NjQ==', N'2555eb86-0245-41a0-9b83-e5aea623e9e8', NULL, 0, 0, NULL, 1, 0, N'manager@demo.com', 0)
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'08a515e2-c884-4b31-b170-af06a646ad8a', N'CanDoAllManipulationsOnEntities')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3785bba4-47a5-4552-8cb0-414cdc8b7360', N'CanDoManipulationsOnEntitiesExceptDeletion')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dbba582a-85e4-40f0-b93c-9db4c997cc0c', N'08a515e2-c884-4b31-b170-af06a646ad8a')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'26cae2e5-27ab-4b81-b628-9c5432089066', N'3785bba4-47a5-4552-8cb0-414cdc8b7360')
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
