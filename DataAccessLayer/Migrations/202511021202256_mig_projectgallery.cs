namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_projectgallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectGalleries",
                c => new
                    {
                        ProjectGalleryID = c.Int(nullable: false, identity: true),
                        ProjectImageURL = c.String(),
                        ProjectName = c.String(),
                    })
                .PrimaryKey(t => t.ProjectGalleryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectGalleries");
        }
    }
}
