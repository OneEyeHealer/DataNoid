namespace DataNoidAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        AppUserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.Long(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Department = c.String(),
                        JobRole = c.String(),
                    })
                .PrimaryKey(t => t.AppUserId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AppUserId = c.Int(nullable: false),
                        DefaultAddressType = c.Boolean(nullable: false),
                        HouseNo = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Pincode = c.Int(nullable: false),
                        Landmark = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Addresses", new[] { "AppUserId" });
            DropTable("dbo.Addresses");
            DropTable("dbo.AppUsers");
        }
    }
}
