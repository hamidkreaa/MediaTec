namespace MediaTec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscriebedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscriebedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscriebedToNewsletter");
        }
    }
}
