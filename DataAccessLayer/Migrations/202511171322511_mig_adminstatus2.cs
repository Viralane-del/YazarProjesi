namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminstatus2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminStatus", c => c.String());
        }
    }
}
