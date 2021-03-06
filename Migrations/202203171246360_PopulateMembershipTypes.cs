namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes (SignUpFee,DurationInMonths,DiscountRate) Values (0,0,0)");
            Sql("Insert into MembershipTypes (SignUpFee,DurationInMonths,DiscountRate) Values (30,1,10)");
            Sql("Insert into MembershipTypes (SignUpFee,DurationInMonths,DiscountRate) Values (90,3,15)");
            Sql("Insert into MembershipTypes (SignUpFee,DurationInMonths,DiscountRate) Values (300,12,15)");
        }
        
        public override void Down()
        {
        }
    }
}
