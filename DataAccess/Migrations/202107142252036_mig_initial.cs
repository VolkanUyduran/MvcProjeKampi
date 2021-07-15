namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Admins", name: "Roles_RoleId", newName: "RoleId");
            RenameIndex(table: "dbo.Admins", name: "IX_Roles_RoleId", newName: "IX_RoleId");
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            AddColumn("dbo.Admins", "AdminMail", c => c.Binary());
            AddColumn("dbo.Admins", "StatusId", c => c.Int());
            AddColumn("dbo.Categories", "StatusId", c => c.Int());
            AddColumn("dbo.Headings", "StatusId", c => c.Int());
            AddColumn("dbo.Writers", "WriterUserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
            CreateIndex("dbo.Admins", "StatusId");
            CreateIndex("dbo.Categories", "StatusId");
            CreateIndex("dbo.Headings", "StatusId");
            AddForeignKey("dbo.Admins", "StatusId", "dbo.Status", "StatusId");
            AddForeignKey("dbo.Headings", "StatusId", "dbo.Status", "StatusId");
            AddForeignKey("dbo.Categories", "StatusId", "dbo.Status", "StatusId");
            DropColumn("dbo.Admins", "AdminRole");
            DropColumn("dbo.Headings", "HeadingStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "HeadingStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropForeignKey("dbo.Categories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Headings", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Admins", "StatusId", "dbo.Status");
            DropIndex("dbo.Headings", new[] { "StatusId" });
            DropIndex("dbo.Categories", new[] { "StatusId" });
            DropIndex("dbo.Admins", new[] { "StatusId" });
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            DropColumn("dbo.Writers", "WriterUserName");
            DropColumn("dbo.Headings", "StatusId");
            DropColumn("dbo.Categories", "StatusId");
            DropColumn("dbo.Admins", "StatusId");
            DropColumn("dbo.Admins", "AdminMail");
            DropTable("dbo.Status");
            RenameIndex(table: "dbo.Admins", name: "IX_RoleId", newName: "IX_Roles_RoleId");
            RenameColumn(table: "dbo.Admins", name: "RoleId", newName: "Roles_RoleId");
        }
    }
}
