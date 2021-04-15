namespace MinistryPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Church", "Address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Church", "City", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Church", "Zip", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Church", "Zip", c => c.String(nullable: false));
            AlterColumn("dbo.Church", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Church", "Address", c => c.String(nullable: false));
        }
    }
}
