namespace MinistryPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Church",
                c => new
                    {
                        ChurchId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        NumberMembers = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ChurchId);
            
            CreateTable(
                "dbo.Parishoner",
                c => new
                    {
                        IndividualId = c.Int(nullable: false, identity: true),
                        Officer = c.Boolean(nullable: false),
                        OfficerTitle = c.String(),
                        ChurchId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(),
                        HomePhone = c.String(),
                        CellPhone = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 30),
                        State = c.String(nullable: false, maxLength: 20),
                        Zip = c.String(nullable: false, maxLength: 20),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.IndividualId)
                .ForeignKey("dbo.Church", t => t.ChurchId, cascadeDelete: true)
                .Index(t => t.ChurchId);
            
            CreateTable(
                "dbo.Pastor",
                c => new
                    {
                        IndividualId = c.Int(nullable: false, identity: true),
                        SeniorPastor = c.Boolean(nullable: false),
                        AssistantPastor = c.Boolean(nullable: false),
                        YouthPastor = c.Boolean(nullable: false),
                        SongLeader = c.Boolean(nullable: false),
                        ChurchId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(),
                        HomePhone = c.String(),
                        CellPhone = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 30),
                        State = c.String(nullable: false, maxLength: 20),
                        Zip = c.String(nullable: false, maxLength: 20),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.IndividualId)
                .ForeignKey("dbo.Church", t => t.ChurchId, cascadeDelete: true)
                .Index(t => t.ChurchId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Visitor",
                c => new
                    {
                        IndividualId = c.Int(nullable: false, identity: true),
                        DateVisited = c.DateTime(nullable: false),
                        ChurchId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(),
                        HomePhone = c.String(),
                        CellPhone = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 30),
                        State = c.String(nullable: false, maxLength: 20),
                        Zip = c.String(nullable: false, maxLength: 20),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.IndividualId)
                .ForeignKey("dbo.Church", t => t.ChurchId, cascadeDelete: true)
                .Index(t => t.ChurchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitor", "ChurchId", "dbo.Church");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Pastor", "ChurchId", "dbo.Church");
            DropForeignKey("dbo.Parishoner", "ChurchId", "dbo.Church");
            DropIndex("dbo.Visitor", new[] { "ChurchId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Pastor", new[] { "ChurchId" });
            DropIndex("dbo.Parishoner", new[] { "ChurchId" });
            DropTable("dbo.Visitor");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Pastor");
            DropTable("dbo.Parishoner");
            DropTable("dbo.Church");
        }
    }
}
