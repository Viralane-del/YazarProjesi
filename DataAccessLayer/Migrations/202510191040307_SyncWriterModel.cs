namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncWriterModel : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 100));
            //DropColumn("dbo.Writers", "WriterMail");
        }
    }
}
