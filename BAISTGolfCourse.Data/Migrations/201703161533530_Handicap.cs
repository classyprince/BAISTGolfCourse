namespace BAISTGolfCourse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Handicap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Handicaps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.PlayerScores", "HandicapID", c => c.Int());
            CreateIndex("dbo.PlayerScores", "HandicapID");
            AddForeignKey("dbo.PlayerScores", "HandicapID", "dbo.Handicaps", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerScores", "HandicapID", "dbo.Handicaps");
            DropIndex("dbo.PlayerScores", new[] { "HandicapID" });
            DropColumn("dbo.PlayerScores", "HandicapID");
            DropTable("dbo.Handicaps");
        }
    }
}
