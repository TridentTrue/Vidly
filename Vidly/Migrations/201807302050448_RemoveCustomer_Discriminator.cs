namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomer_Discriminator : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
