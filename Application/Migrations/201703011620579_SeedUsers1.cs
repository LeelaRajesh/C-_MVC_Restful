namespace MVCappli_rest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'83d25de4-13fd-4412-a312-4892402a60f4', N'admin@movierentals.com', 0, N'ALdfWP4cVft2CHjdRvtNROo9pnLazegnUVHALcmQXIfBBT2xMdK+8tc4dBLUO+h6kQ==', N'1608694a-6f29-40ea-82e5-cb291287e5ad', NULL, 0, 0, NULL, 1, 0, N'admin@movierentals.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bef667b5-3fad-4f3f-853d-31298db42632', N'rajesh@gmail.com', 0, N'AACpMtQEbgi1fGyodSx7CbE+1l40MSiRkCsSc/0gWSUAnNj/u5bhIXinfQxMN1hrBg==', N'5740223e-88e2-453f-ad6d-04ff62113dd8', NULL, 0, 0, NULL, 1, 0, N'rajesh@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ee9e4804-465f-4258-9ce8-f7ee2a5f8a16', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'83d25de4-13fd-4412-a312-4892402a60f4', N'ee9e4804-465f-4258-9ce8-f7ee2a5f8a16')
");

        }
        
        public override void Down()
        {
        }
    }
}
