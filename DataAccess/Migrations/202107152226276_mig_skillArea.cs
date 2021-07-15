namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_skillArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillAreas",
                c => new
                    {
                        SkillAreaId = c.Int(nullable: false, identity: true),
                        Area = c.String(maxLength: 100),
                        AreaDetails = c.String(),
                    })
                .PrimaryKey(t => t.SkillAreaId);
            
            AddColumn("dbo.Talents", "SkillAreaId", c => c.Int());
            CreateIndex("dbo.Talents", "SkillAreaId");
            AddForeignKey("dbo.Talents", "SkillAreaId", "dbo.SkillAreas", "SkillAreaId");
            DropColumn("dbo.Talents", "TalentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Talents", "TalentName", c => c.String());
            DropForeignKey("dbo.Talents", "SkillAreaId", "dbo.SkillAreas");
            DropIndex("dbo.Talents", new[] { "SkillAreaId" });
            DropColumn("dbo.Talents", "SkillAreaId");
            DropTable("dbo.SkillAreas");
        }
    }
}
