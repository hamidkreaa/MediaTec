namespace MediaTec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'430d61b6-b628-4bfd-80a0-a0b92dd96bda', N'a.kreaa@pkn.de', 0, N'AJ2rItD3Pvf9VjB1bHq2WMUR8JyL19ZRWfLJ6wx1bLCXzc6pIHb27toMVrSQjgrX2g==', N'f9464e1c-e3da-462b-90a1-037c3081212f', NULL, 0, 0, NULL, 1, 0, N'a.kreaa@pkn.de')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a5ab0640-7439-4bd1-a051-a7411fd2a864', N'guest@pkn.de', 0, N'AKsipj9krbVZ6YmONAf+P3KKMmyY6KdidmionOFRt15EoD8cnHHPfpzh8UskDU/OUQ==', N'754f6b48-892b-4d4f-821e-01fb9a977c06', NULL, 0, 0, NULL, 1, 0, N'guest@pkn.de')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de6f356d-edf1-4c33-bd46-e80fc1de8b25', N'admin@pkn.de', 0, N'AEK5gLte8jZLfTNqb27NUfD0helsuj6a9gsDaidlXf49T/Nd2TkU01A9jI9HbgFI3A==', N'30fcbe38-6469-4c71-b98c-d0ba7a015fd2', NULL, 0, 0, NULL, 1, 0, N'admin@pkn.de')
               
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7b0f5563-0c6d-42c0-b34b-1305a46beede', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'de6f356d-edf1-4c33-bd46-e80fc1de8b25', N'7b0f5563-0c6d-42c0-b34b-1305a46beede')
");
        }
        
        public override void Down()
        {
        }
    }
}
