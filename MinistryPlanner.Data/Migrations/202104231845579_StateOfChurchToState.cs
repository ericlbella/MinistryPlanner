namespace MinistryPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StateOfChurchToState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Church", "State", c => c.Int(nullable: false));
            DropColumn("dbo.Church", "StateOfChurch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Church", "StateOfChurch", c => c.Int(nullable: false));
            DropColumn("dbo.Church", "State");
        }
    }
}
