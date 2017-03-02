namespace MVCappli_rest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'34ccf1bf-4c73-4de1-a251-c3ac0e676ff2', N'admin@movierental.com', 0, N'AMmCD3Bfb0ohqSNS0ljhxmwQW6DY0CUdU12VRHE4/tVGueEhG2aimUYpe+i9TL/Y1A==', N'b409ccd2-a969-420d-850d-b63d8cc7a62d', NULL, 0, 0, NULL, 1, 0, N'admin@movierental.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'373b0e00-15c5-41a2-ab35-bd1c08e8f8f6', N'leelarajeshsayanatest@gmail.com', 0, N'AAH+hM0Rph26u8syI3SClxmweuNnVMiAMtZYPfWqIvAWsmNvXKGqCRwxlgz7n1GA1g==', N'9083dce9-a9ff-4fee-a978-1ff771228b76', NULL, 0, 0, NULL, 1, 0, N'leelarajeshsayanatest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fa0939b7-0649-4d00-99c9-8ac024eab9ce', N'rajesh@gmail.com', 0, N'AAhJYos0mR/Chytonn3PDWOxX0kz8kJ86sOeBhq/mkGpPEjd8E40BF3RlbS5HPxpNA==', N'3f47fda1-8bea-482a-9d45-4ae9fbe383a3', NULL, 0, 0, NULL, 1, 0, N'rajesh@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5b1f83a3-bb27-4048-82ea-f8b83dba4f4c', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34ccf1bf-4c73-4de1-a251-c3ac0e676ff2', N'5b1f83a3-bb27-4048-82ea-f8b83dba4f4c')

");
        }
        
        public override void Down()
        {
        }
    }
}
