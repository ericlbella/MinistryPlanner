namespace MinistryPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pastor", "State", c => c.Int(nullable: false));
            AlterColumn("dbo.Parishoner", "State", c => c.Int(nullable: false));
            AlterColumn("dbo.Visitor", "State", c => c.Int(nullable: false));
            DropColumn("dbo.Parishoner", "StateOfChurch");
            DropColumn("dbo.Pastor", "StateOfChurch");
            DropColumn("dbo.Visitor", "StateOfChurch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visitor", "StateOfChurch", c => c.Int(nullable: false));
            AddColumn("dbo.Pastor", "StateOfChurch", c => c.Int(nullable: false));
            AddColumn("dbo.Parishoner", "StateOfChurch", c => c.Int(nullable: false));
            AlterColumn("dbo.Visitor", "State", c => c.String());
            AlterColumn("dbo.Parishoner", "State", c => c.String());
            DropColumn("dbo.Pastor", "State");
        }
    }
}
