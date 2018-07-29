namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveErroneousPropertyFromMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Movies", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MyProperty", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
