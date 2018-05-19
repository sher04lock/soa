namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookPageCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("public2.Books", "PageCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public2.Books", "PageCount");
        }
    }
}
