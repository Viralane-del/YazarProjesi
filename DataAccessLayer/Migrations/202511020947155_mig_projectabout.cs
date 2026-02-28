namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_projectabout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectAbouts",
                c => new
                    {
                        ProjectAboutID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectLevel = c.String(),
                    })
                .PrimaryKey(t => t.ProjectAboutID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectAbouts");
        }
    }
}
