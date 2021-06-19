namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_talentcard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        About = c.String(),
                        TalentName = c.String(),
                        Percent = c.String(),
                    })
                .PrimaryKey(t => t.TalentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Talents");
        }
    }
}
