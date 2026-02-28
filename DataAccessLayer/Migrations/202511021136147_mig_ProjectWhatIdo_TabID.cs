namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_ProjectWhatIdo_TabID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectWhatIdoes", "TabID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectWhatIdoes", "TabID");
        }
    }
}
