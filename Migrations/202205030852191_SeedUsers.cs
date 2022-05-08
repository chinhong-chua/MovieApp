namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8caaef93-2486-4f6a-a317-24f3743b6cbd', N'admin@gmail.com', 0, N'AJpXVc5dmp7wWDtQrElEkbVVeXnPHfUhM7ppaHT/CVpSq6vSRplOg+Lp0OpNv3PV/w==', N'115223a1-29e5-494a-96e1-b9e19493a42e', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ad114978-5ed3-4902-874e-a22242dfd133', N'guest@gmail.com', 0, N'AKoyNWzBJizw1PoctYxdMaauNF39gVScYzLZ/XTm/V2OSHRhlfZFfayKZXzssIjpNg==', N'05d73637-ac87-492d-815c-90536cbbf3b8', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'18ea8e14-d2af-4fff-809e-b3223f84f6b2', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8caaef93-2486-4f6a-a317-24f3743b6cbd', N'18ea8e14-d2af-4fff-809e-b3223f84f6b2')

");
        }

        public override void Down()
        {
        }
    }
}
