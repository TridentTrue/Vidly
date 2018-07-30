namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypesToContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Discriminator");
        }
    }
}
