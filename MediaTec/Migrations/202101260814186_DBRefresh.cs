namespace MediaTec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBRefresh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
