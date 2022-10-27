namespace WebApplicationBookStore3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookStore5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "DownloadNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "ReadingNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ReadingNumber");
            DropColumn("dbo.Books", "DownloadNumber");
        }
    }
}
