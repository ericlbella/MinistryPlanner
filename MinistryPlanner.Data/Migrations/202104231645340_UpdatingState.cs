namespace MinistryPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parishoner", "StateOfChurch", c => c.Int(nullable: false));
            AddColumn("dbo.Pastor", "StateOfChurch", c => c.Int(nullable: false));
            AddColumn("dbo.Visitor", "StateOfChurch", c => c.Int(nullable: false));
            AlterColumn("dbo.Parishoner", "State", c => c.String());
            AlterColumn("dbo.Visitor", "State", c => c.String());
            DropColumn("dbo.Pastor", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pastor", "State", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Visitor", "State", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Parishoner", "State", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Visitor", "StateOfChurch");
            DropColumn("dbo.Pastor", "StateOfChurch");
            DropColumn("dbo.Parishoner", "StateOfChurch");
        }
    }
}
