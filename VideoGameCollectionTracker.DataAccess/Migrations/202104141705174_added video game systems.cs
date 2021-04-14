namespace VideoGameCollectionTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvideogamesystems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoGameSystem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VideoGameSystem");
        }
    }
}
