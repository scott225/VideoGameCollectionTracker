namespace VideoGameCollectionTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        VideoGame_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VideoGame", t => t.VideoGame_Id)
                .Index(t => t.VideoGame_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genre", "VideoGame_Id", "dbo.VideoGame");
            DropIndex("dbo.Genre", new[] { "VideoGame_Id" });
            DropTable("dbo.Genre");
        }
    }
}
