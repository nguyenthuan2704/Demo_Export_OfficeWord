namespace Demo_Export_OfficeWord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB_First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Report_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id, cascadeDelete: true)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Inbox = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        Require = c.String(nullable: false),
                        Reason = c.String(nullable: false),
                        Solution = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Links = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "Report_Id", "dbo.Reports");
            DropIndex("dbo.Pictures", new[] { "Report_Id" });
            DropTable("dbo.Reports");
            DropTable("dbo.Pictures");
        }
    }
}
