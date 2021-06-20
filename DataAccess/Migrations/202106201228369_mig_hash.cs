namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_hash : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterPasswordHash", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterPasswordHash", c => c.Binary(maxLength: 200));
        }
    }
}
