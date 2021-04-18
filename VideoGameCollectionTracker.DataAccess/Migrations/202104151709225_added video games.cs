namespace VideoGameCollectionTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvideogames : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoGame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VideoGameSystem", "VideoGame_Id", c => c.Int());
            CreateIndex("dbo.VideoGameSystem", "VideoGame_Id");
            AddForeignKey("dbo.VideoGameSystem", "VideoGame_Id", "dbo.VideoGame", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoGameSystem", "VideoGame_Id", "dbo.VideoGame");
            DropIndex("dbo.VideoGameSystem", new[] { "VideoGame_Id" });
            DropColumn("dbo.VideoGameSystem", "VideoGame_Id");
            DropTable("dbo.VideoGame");
        }
    }
}
