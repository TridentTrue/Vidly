namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsToCustomerAndMovieModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Discriminator");
        }
    }
}
