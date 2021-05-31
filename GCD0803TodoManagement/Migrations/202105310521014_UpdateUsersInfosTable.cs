namespace GCD0803TodoManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsersInfosTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserInfoes", new[] { "UserId" });
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserInfoes", "UserId");
            CreateIndex("dbo.UserInfoes", "UserId");
            DropColumn("dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "Id", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.UserInfoes", new[] { "UserId" });
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.UserInfoes", "Id");
            CreateIndex("dbo.UserInfoes", "UserId");
        }
    }
}
