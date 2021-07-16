namespace DataNoidAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        TaskName = c.String(),
                        TaskDescription = c.String(),
                        TaskStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ModuleId", "dbo.Modules");
            DropIndex("dbo.Tasks", new[] { "ModuleId" });
            DropTable("dbo.Tasks");
        }
    }
}
