namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_admin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Byte(nullable: false));
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 100));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
        }
    }
}
