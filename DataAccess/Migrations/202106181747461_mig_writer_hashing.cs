namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_hashing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterPasswordHash", c => c.Binary(maxLength: 200));
            AddColumn("dbo.Writers", "WriterPasswordSalt", c => c.Binary());

            DropColumn("dbo.Writers", "WriterPassword");
            
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "SpamMail", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "İmportantMail", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "UnRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            DropColumn("dbo.Messages", "IsRead");
            DropColumn("dbo.Writers", "WriterPasswordSalt");
            DropColumn("dbo.Writers", "WriterPasswordHash");
        }
    }
}
