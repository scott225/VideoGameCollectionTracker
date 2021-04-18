namespace VideoGameCollectionTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvideogames2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VideoGameSystem", "VideoGame_Id", "dbo.VideoGame");
            DropIndex("dbo.VideoGameSystem", new[] { "VideoGame_Id" });
            CreateTable(
                "dbo.VideoGameSystemVideoGame",
                c => new
                    {
                        VideoGameSystem_Id = c.Int(nullable: false),
                        VideoGame_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VideoGameSystem_Id, t.VideoGame_Id })
                .ForeignKey("dbo.VideoGameSystem", t => t.VideoGameSystem_Id, cascadeDelete: true)
                .ForeignKey("dbo.VideoGame", t => t.VideoGame_Id, cascadeDelete: true)
                .Index(t => t.VideoGameSystem_Id)
                .Index(t => t.VideoGame_Id);
            
            DropColumn("dbo.VideoGameSystem", "VideoGame_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VideoGameSystem", "VideoGame_Id", c => c.Int());
            DropForeignKey("dbo.VideoGameSystemVideoGame", "VideoGame_Id", "dbo.VideoGame");
            DropForeignKey("dbo.VideoGameSystemVideoGame", "VideoGameSystem_Id", "dbo.VideoGameSystem");
            DropIndex("dbo.VideoGameSystemVideoGame", new[] { "VideoGame_Id" });
            DropIndex("dbo.VideoGameSystemVideoGame", new[] { "VideoGameSystem_Id" });
            DropTable("dbo.VideoGameSystemVideoGame");
            CreateIndex("dbo.VideoGameSystem", "VideoGame_Id");
            AddForeignKey("dbo.VideoGameSystem", "VideoGame_Id", "dbo.VideoGame", "Id");
        }
    }
}
