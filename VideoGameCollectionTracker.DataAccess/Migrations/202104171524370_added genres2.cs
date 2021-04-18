namespace VideoGameCollectionTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgenres2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genre", "VideoGame_Id", "dbo.VideoGame");
            DropIndex("dbo.Genre", new[] { "VideoGame_Id" });
            CreateTable(
                "dbo.VideoGameGenre",
                c => new
                    {
                        VideoGame_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VideoGame_Id, t.Genre_Id })
                .ForeignKey("dbo.VideoGame", t => t.VideoGame_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.VideoGame_Id)
                .Index(t => t.Genre_Id);
            
            DropColumn("dbo.Genre", "VideoGame_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genre", "VideoGame_Id", c => c.Int());
            DropForeignKey("dbo.VideoGameGenre", "Genre_Id", "dbo.Genre");
            DropForeignKey("dbo.VideoGameGenre", "VideoGame_Id", "dbo.VideoGame");
            DropIndex("dbo.VideoGameGenre", new[] { "Genre_Id" });
            DropIndex("dbo.VideoGameGenre", new[] { "VideoGame_Id" });
            DropTable("dbo.VideoGameGenre");
            CreateIndex("dbo.Genre", "VideoGame_Id");
            AddForeignKey("dbo.Genre", "VideoGame_Id", "dbo.VideoGame", "Id");
        }
    }
}
