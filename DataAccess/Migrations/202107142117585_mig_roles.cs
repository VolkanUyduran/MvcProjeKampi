namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 20),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Admins", "Roles_RoleId", c => c.Int());
            CreateIndex("dbo.Admins", "Roles_RoleId");
            AddForeignKey("dbo.Admins", "Roles_RoleId", "dbo.Roles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "Roles_RoleId", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "Roles_RoleId" });
            DropColumn("dbo.Admins", "Roles_RoleId");
            DropTable("dbo.Roles");
        }
    }
}
