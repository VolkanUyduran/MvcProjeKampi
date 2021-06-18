namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_draft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Trash", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Read", c => c.Boolean(nullable: false));
            DropTable("dbo.Drafts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        DraftId = c.Int(nullable: false, identity: true),
                        ReceiverMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        DraftContent = c.String(),
                        DraftDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DraftId);
            
            DropColumn("dbo.Messages", "Read");
            DropColumn("dbo.Messages", "IsRead");
            DropColumn("dbo.Messages", "Trash");
            DropColumn("dbo.Messages", "IsDraft");
        }
    }
}
