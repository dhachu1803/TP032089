namespace MaerskContainerWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chgFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cargoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cargoes", new[] { "UserId" });
            AddColumn("dbo.Cargoes", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cargoes", "CustomerId");
            AddForeignKey("dbo.Cargoes", "CustomerId", "dbo.Customers", "id", cascadeDelete: false);
            DropColumn("dbo.Cargoes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cargoes", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Cargoes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Cargoes", new[] { "CustomerId" });
            DropColumn("dbo.Cargoes", "CustomerId");
            CreateIndex("dbo.Cargoes", "UserId");
            AddForeignKey("dbo.Cargoes", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
