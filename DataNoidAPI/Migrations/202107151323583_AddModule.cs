namespace DataNoidAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        AppUserId = c.Int(nullable: false),
                        ModuleName = c.String(),
                        ModuleDescription = c.String(),
                        ModuleStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Modules", new[] { "AppUserId" });
            DropTable("dbo.Modules");
        }
    }
}
