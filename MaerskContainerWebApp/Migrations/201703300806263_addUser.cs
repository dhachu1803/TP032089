namespace MaerskContainerWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cargoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cargoes", "UserId");
            AddForeignKey("dbo.Cargoes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cargoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cargoes", new[] { "UserId" });
            DropColumn("dbo.Cargoes", "UserId");
        }
    }
}
