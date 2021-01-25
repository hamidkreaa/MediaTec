namespace MediaTec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMoths, DiscountRate) VALUES(1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMoths, DiscountRate) VALUES(2, 30, 1, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMoths, DiscountRate) VALUES(3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMoths, DiscountRate) VALUES(12, 300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
