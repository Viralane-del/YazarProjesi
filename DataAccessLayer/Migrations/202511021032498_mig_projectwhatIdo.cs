namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_projectwhatIdo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectWhatIdoes",
                c => new
                    {
                        ProjectWhatIdoID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProjectWhatIdoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectWhatIdoes");
        }
    }
}
