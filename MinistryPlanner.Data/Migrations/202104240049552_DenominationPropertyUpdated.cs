namespace MinistryPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DenominationPropertyUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Church", "Denomination", c => c.Int(nullable: false));
            DropColumn("dbo.Church", "DenominationOfChurch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Church", "DenominationOfChurch", c => c.Int(nullable: false));
            DropColumn("dbo.Church", "Denomination");
        }
    }
}
