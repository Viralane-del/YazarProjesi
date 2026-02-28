namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_projecttestimonials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectTestimonials",
                c => new
                    {
                        TestimonialID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        City = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.TestimonialID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectTestimonials");
        }
    }
}
